using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chat.Admin.Attribute;
using chat.SERVICES.Interfaces.Customer;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class ACustomerController : BaseController
    {
        private readonly IGenericRepository<chat.CORE.Entities.Customer>  _customerRepository;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepository;



        private readonly ICustomerUserService _customerUserService;


        private readonly IUnitofWork _uow;

        public ACustomerController(IUnitofWork uow,
            IGenericRepository<chat.CORE.Entities.Customer> customerRepository,
             ICustomerUserService customerUserService, IGenericRepository<chat.CORE.Entities.Employee> employeeRepository) : base(uow)
        {
            _customerRepository = customerRepository;
            _customerUserService = customerUserService;
            _uow = uow;
            _employeeRepository = employeeRepository;
        }

        // GET: ACustomer
        public ActionResult Index()
        {

            var list = _customerRepository.GetAll().OrderByDescending(x => x.ID).ToList();

            return View(list);
        }

        public ActionResult UpdateStatus(int ID)
        {

            var sonuc = _customerUserService.UpdateIsStatus(ID);
            if (sonuc == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult UpdateIsActive(int ID)
        {

            var sonuc = _customerUserService.UpdateIsActive(ID);
            if (sonuc==true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult editCustomer(int? ID)
        {
            if (ID == null)
            {
                //Kontrol koy err sayfasına gönder
               return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["message"] = null;

                var cust = _customerRepository.Find((int)ID);
                return View(cust);
            }
            

        }



        //Düzenleme Ekranından alınacak
        public ActionResult editCus(chat.CORE.Entities.Customer gelen)
        {
            if (gelen.Email == null || gelen.Password == null || gelen.UserName == null)
            {

                TempData["message"] = "Alanlar boş bırakılamaz";
                return View("editCustomer");
            }
            else
            {
                var uname = _employeeRepository.GetAll().Where(x => x.UserName == gelen.UserName && x.ID !=gelen.ID).SingleOrDefault();
                var cusUname = _customerRepository.GetAll().Where(x => x.UserName == gelen.UserName && x.ID != gelen.ID).SingleOrDefault();
                var email = _employeeRepository.GetAll().Where(x => x.Email == gelen.Email && x.ID != gelen.ID).SingleOrDefault();
                var cusEmail = _customerRepository.GetAll().Where(x => x.Email == gelen.Email && x.ID != gelen.ID).SingleOrDefault();

                if (uname != null || cusUname != null || email != null || cusEmail != null)
                {
                    TempData["message"] = "<span style='color:red;'> Kullanıcı Adı veya Email kullanımda  </span>";
                    return View("editCustomer", gelen);
                }
                else
                {

                    var sonuc = _customerUserService.updateAdminCustomer(gelen);

                    if (sonuc == true)
                    {
                        TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                        return View("editCustomer", gelen);
                    }
                    else
                    {

                        TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";

                        return View("editCustomer", gelen);
                    }
                }


                //if (uname != null || cusUname != null)
                //{
                //    if (cusUname.ID==gelen.ID)
                //    {
                //        var sonuc = _customerUserService.updateAdminCustomer(gelen);

                //        if (sonuc == true)
                //        {
                //            TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                //            return View("editCustomer", gelen);
                //            //return Redirect("/ACustomer/editCustomer");
                //        }
                //        else
                //        {
                //            TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";
                //          return View("editCustomer", gelen);
                //            //return Redirect("/ACustomer/editCustomer");
                //        }
                //    }
                //    else
                //    {
                //        TempData["message"] = "<span style='color:red;'> Kullanıcı Adı Tanımlı  </span>";
                //        return View("editCustomer", gelen);
                //    }
                //    //kullanıcı adı var

                //}
                //else
                //{
                //    if (email != null || cusEmail != null)
                //    {
                //        //email var içerde
                //        TempData["message"] = "<span style='color:red;'> Email Tanımlı  </span>";
                //        return View("editCustomer", gelen);
                //    }
                //    else
                //    {


                //        var sonuc = _customerUserService.updateAdminCustomer(gelen);

                //        if (sonuc == true)
                //        {
                //            TempData["message"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";
                //            return View("editCustomer", gelen);
                //        }
                //        else
                //        {

                //            TempData["message"] = "<span style='color:red;'> İşlem Başarısız </span>";

                //            return View("editCustomer", gelen);
                //        }

                //    }
                //}
            }

        }

    }
}