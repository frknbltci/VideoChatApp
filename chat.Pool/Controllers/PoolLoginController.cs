using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{

    public class PoolLoginController : BaseController
    {

        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private EmpCusSessionContext _empcusSessionContext;

        private readonly IUnitofWork _uow;


        private readonly IEmployeeUserService _employe;
        private readonly ICustomerUserService _customer;

        public PoolLoginController(IUnitofWork uow, IGenericRepository<Employee> employeRepoService, IGenericRepository<Customer> customerRepoService , IEmployeeUserService employe,
            ICustomerUserService customer) : base(uow)
        {
            _empcusSessionContext = new EmpCusSessionContext();
            _employeeRepository = employeRepoService;
            _customerRepository = customerRepoService;
            _uow = uow;
            _employe = employe;
            _customer = customer;

        }

        // GET: PoolLogin
        public ActionResult LoginIndex()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "MainPage");
            } 
        }
      

        public ActionResult doLogin(CusEmpDTO gelen)
        {

            if (ModelState.IsValid)
            {
                var EmpvarMi = _employeeRepository.GetAll().Where(x => x.Email == gelen.Email && x.Password == gelen.Password).SingleOrDefault();

                var CusvarMi = _customerRepository.GetAll().Where(x => x.Email == gelen.Email && x.Password == gelen.Password).SingleOrDefault();

                if (EmpvarMi !=null)
                {
                    if (CusvarMi!=null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        if (EmpvarMi.IsActive==true)
                        {

                        _employe.updateStatus(EmpvarMi.ID);

                        _empcusSessionContext.ID = EmpvarMi.ID;
                        _empcusSessionContext.UserName = EmpvarMi.UserName;
                        _empcusSessionContext.ImageUrl = EmpvarMi.ImageURL;
                        _empcusSessionContext.NickName = EmpvarMi.NickName;
                        _empcusSessionContext.Type = 2;
                        _empcusSessionContext.StatusID = 1;
                          

                            Session["EmpCusSessionContext"] = _empcusSessionContext;

                            return Json("emp", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Hesap aktif değil
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    if (CusvarMi ==null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (CusvarMi.IsActive==true)
                        {
                            _customer.changeStatus(1, CusvarMi.ID);
                            _empcusSessionContext.ID = CusvarMi.ID;
                            _empcusSessionContext.UserName = CusvarMi.UserName;
                            _empcusSessionContext.ImageUrl = CusvarMi.ImageURL;
                            _empcusSessionContext.BtPrice = CusvarMi.BtPrice;
                            _empcusSessionContext.Type = 1;
                            _empcusSessionContext.StatusID = 1;

                            Session["EmpCusSessionContext"] = _empcusSessionContext;
                           return Json("cus", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Hesap Aktif Değil
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        
                    }
                }
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Logout()
        {
            //Anlık olarak durum güncellemesi yapılacak bütün logoutlarda
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {

                return Redirect("/PoolLogin/LoginIndex");
            }
            else
            {
                var uname= ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).UserName;

                var EmpvarMi = _employeeRepository.GetAll().Where(x => x.UserName == uname).SingleOrDefault();
                var CusvarMi = _customerRepository.GetAll().Where(x => x.UserName==uname).SingleOrDefault();

                if (EmpvarMi !=null)
                {
                    if (CusvarMi!=null)
                    {
              
                    }
                    else
                    {
                        //EmpStatus 2 olacak
                        _employe.changeStatus(2, EmpvarMi.ID);
                    }
                }
                else
                {
                    if (CusvarMi ==null)
                    {
                   
                    }
                    else
                    {
                        //Customer'ın durumu güncellenecek 2 olacak
                        _customer.changeStatus(2, CusvarMi.ID);
                    }
                }



                Session.Abandon();
                return Redirect("/PoolLogin/LoginIndex");
            }


            

            //..ok
        }
    }
}