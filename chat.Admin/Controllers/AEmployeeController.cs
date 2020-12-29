using chat.Admin.Attribute;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class AEmployeeController : BaseController
    {

        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepository;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepository;


        private readonly IEmployeeUserService _empoyeeUserService;

        private readonly IUnitofWork _uow;

        public AEmployeeController(IUnitofWork uow,
            IGenericRepository<chat.CORE.Entities.Customer> customerRepository,
             IEmployeeUserService empoyeeUserService, IGenericRepository<chat.CORE.Entities.Employee> employeeRepository) : base(uow)
        {
            _customerRepository = customerRepository;
            _empoyeeUserService = empoyeeUserService;
            _uow = uow;
            _employeeRepository = employeeRepository;
        }

        // GET: AEmployee
        public ActionResult Index()
        {
            var list = _employeeRepository.GetAll().OrderByDescending(x => x.IsActive == false).ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult getEmp()
        {
            var list = _employeeRepository.GetAll().ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateIsActive(int ID)
        {

            var sonuc = _empoyeeUserService.UpdateIsActive(ID);
            if (sonuc == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult UpdateStatus(int ID)
        {

            var sonuc = _empoyeeUserService.changeStatus(2, ID);
            if (sonuc == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult editEmployee(int? ID)
        {
            if (ID == null)
            {
                //Kontrol koy err sayfasına gönder
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["message"] = null;

                var emp = _employeeRepository.Find((int)ID);
                return View(emp);
            }


        }

        //Düzenleme Ekranından alınacak
        public ActionResult editEmp(chat.CORE.Entities.Employee gelen)
        {
            if (gelen.Email == null || gelen.Password == null || gelen.UserName == null)
            {

                TempData["message"] = "Alanlar boş bırakılamaz";
                return View("editCustomer",gelen);
            }
            else
            {
                var uname = _employeeRepository.GetAll().Where(x => x.UserName == gelen.UserName && x.ID != gelen.ID).SingleOrDefault();
                var cusUname = _customerRepository.GetAll().Where(x => x.UserName == gelen.UserName && x.ID != gelen.ID).SingleOrDefault();
                var email = _employeeRepository.GetAll().Where(x => x.Email == gelen.Email && x.ID != gelen.ID).SingleOrDefault();
                var cusEmail = _customerRepository.GetAll().Where(x => x.Email == gelen.Email && x.ID != gelen.ID).SingleOrDefault();

                if (uname !=null || cusUname !=null ||email !=null || cusEmail !=null)
                {
                    TempData["message"] = "<span style='color:red;'> Kullanıcı Adı veya Email kullanımda  </span>";
                      return View("editEmployee", gelen);
                }
                else
                {
                    var sonuc = _empoyeeUserService.updateAdminEmployee(gelen);

                    if (sonuc == true)
                    {
                        TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                        return View("editEmployee", gelen);
                    }
                    else
                    {
                        TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";

                        return View("editEmployee", gelen);
                    }
                }



                //if (uname != null || cusUname != null)
                //{
                //    if (uname.ID == gelen.ID)
                //    {
                //        var sonuc = _empoyeeUserService.updateAdminEmployee(gelen);

                //        if (sonuc == true)
                //        {
                //            TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                //            return View("editEmployee", gelen);

                //        }
                //        else
                //        {
                //            TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";
                //            return View("editEmployee", gelen);

                //        }
                //    }
                //    else
                //    {
                //        TempData["message"] = "<span style='color:red;'> Kullanıcı Adı Tanımlı  </span>";
                //        return View("editEmployee", gelen);
                //    }
                //    //kullanıcı adı var

                //}
                //else
                //{
                //    if (email != null || cusEmail != null)
                //    {

                //        if (email.Email == gelen.Email)
                //        {
                //            var sonuc = _empoyeeUserService.updateAdminEmployee(gelen);

                //            if (sonuc == true)
                //            {
                //                TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                //                return View("editEmployee", gelen);

                //            }
                //            else
                //            {
                //                TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";
                //                return View("editEmployee", gelen);

                //            }
                //        }
                //        else
                //        {
                //            TempData["message"] = "<span style='color:red;'> Email Tanımlı  </span>";
                //            return View("editEmployee", gelen);
                //        }

                //        ////email var içerde
                //        //TempData["message"] = "<span style='color:red;'> Email Tanımlı  </span>";
                //        //return View("editEmployee", gelen);
                //    }
                //    else
                //    {
                //        var sonuc = _empoyeeUserService.updateAdminEmployee(gelen);

                //        if (sonuc == true)
                //        {
                //            TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                //            return View("editEmployee", gelen);
                //        }
                //        else
                //        {

                //            TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";

                //            return View("editEmployee", gelen);
                //        }

                //    }
                //}
            }

        }
    }
}