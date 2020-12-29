using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IEmployeeUserService _employeeService;
        private readonly ICustomerUserService _customerService;

        private readonly IUnitofWork _uow;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employe;
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customer;

        public RegisterController(IUnitofWork uow, IEmployeeUserService employeeUserService, IGenericRepository<chat.CORE.Entities.Employee> employe, IGenericRepository<chat.CORE.Entities.Customer> customer
          , ICustomerUserService customerService) : base(uow)
        {
            _uow = uow;
            _employeeService = employeeUserService;
            _customerService = customerService;
            _employe = employe;
            _customer = customer;
        }

        // GET: EmpRegister
        public ActionResult Index()
        {
            var lists = _employeeService.getRegisInfo();
            return View(lists);
        }

        [HttpPost]
        public ActionResult makeRegister(EEmployeeDTO gelen)
        {
            if (gelen.Email == null || gelen.Password == null || gelen.UserName == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var uname = _employe.GetAll().Where(x => x.UserName == gelen.UserName).SingleOrDefault();
                var cusUname = _customer.GetAll().Where(x => x.UserName == gelen.UserName).SingleOrDefault();
                var email = _employe.GetAll().Where(x => x.Email == gelen.Email).SingleOrDefault();
                var cusEmail = _customer.GetAll().Where(x => x.Email == gelen.Email).SingleOrDefault();
                if (uname != null || cusUname != null)
                {
                    //kullanıcı adı var
                    return Json("uname", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (email != null || cusEmail != null)
                    {
                        //email var içerde
                        return Json("email", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (gelen.BodyTypeID==0) {gelen.BodyTypeID = 1; }

                        if (gelen.EyeColorID == 0) { gelen.EyeColorID = 1; }

                        if (gelen.HairTypeID == 0) { gelen.HairTypeID = 1; }

                        if (gelen.HairColorID == 0) { gelen.HairColorID = 1; }
                       

                        var sonuc = _employeeService.addUser(gelen);

                        if (sonuc == true)
                        {
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }

                    }
                }
            }

        }


        [HttpPost]
        public ActionResult makeCusRegister(CCustomerDTO gelen)
        {
            var uname = _employe.GetAll().Where(x => x.UserName == gelen.UserName).SingleOrDefault();
            var cusUname = _customer.GetAll().Where(x => x.UserName == gelen.UserName).SingleOrDefault();
            var email = _employe.GetAll().Where(x => x.Email == gelen.Email).SingleOrDefault();
            var cusEmail = _customer.GetAll().Where(x => x.Email == gelen.Email).SingleOrDefault();
            if (uname != null || cusUname != null)
            {
                //kullanıcı adı var
                return Json("uname", JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (email != null || cusEmail != null)
                {
                    //email var içerde
                    return Json("email", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var sonuc = _customerService.addCustomer(gelen);

                    if (sonuc == true)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }

            }

        }
    }
}