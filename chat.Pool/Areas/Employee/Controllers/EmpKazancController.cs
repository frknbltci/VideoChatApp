using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chat.DTO.EEntity;
using chat.UTILITIES.SessionOperations;
using chat.SERVICES.Interfaces.Employee;
using chat.SERVICES.Interfaces.Admin;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.DATA.GenericRepository;
using chat.CORE.Entities;

namespace chat.Pool.Areas.Employee.Controllers
{

    [Auth]
    public class EmpKazancController : BaseController
    {

        private readonly IEmployeeUserService _employeeService;
        private readonly IAdminUserService _adminService;
        private readonly IUnitofWork _uow;
        private EmployeeSessionContext _employeeSessionContext;



        private readonly ICustomerPaymentService _customerPaymentService;
        //private readonly IGenericRepository<chat.CORE.Entities.CustomerPayment> _cp;
        private readonly IGenericRepository<CustomerPayment> _cs;
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepoService;
        public EmpKazancController(IUnitofWork uow,IEmployeeUserService employeeUserService , IAdminUserService adminUserService ,
            ICustomerPaymentService customerPaymentService, IGenericRepository<CustomerPayment> cs,
            IGenericRepository<chat.CORE.Entities.Customer> customerRepoService) : base(uow)
        {
            _uow = uow;
            _employeeService = employeeUserService;
            _adminService = adminUserService;
            _employeeSessionContext = new EmployeeSessionContext();
            _customerPaymentService = customerPaymentService;
            _cs = cs;
            _customerRepoService = customerRepoService;
        }

        // GET: EmpKazanc
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
               var ID= ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;
                var adminList = _adminService.getAdminList();
                var payList = _adminService.getPayList();
                
                var control = (from p in payList
                               join ad in adminList on p.AdminID equals ad.ID
                               where p.EmployeeID == ID
                               select new EPayChartDTO
                               {
                                   AdminName = ad.UserName,
                                   Quantity = p.Quantity,
                                   CreatedTime = p.CreatedDate
                                   
                               }).ToList();


                return View(control);
            }
        }

        public  ActionResult ownDeserve()
        {

            return View();
        }

        [HttpPost]

        public ActionResult calcOwnDeserve(DateTime StartDate, DateTime EndDate, int EmpID)
        {
            var dataList = _cs.GetAll().Where(x => x.CreatedTime >= StartDate && x.CreatedTime <= EndDate && x.EmployeeID == EmpID).ToList();

            var cusList = _customerRepoService.GetAll().ToList();

            var control = (from da in dataList
                           join cus in cusList on da.CustomerID equals cus.ID
                           select new EDeserveDTO
                           {
                               CustomerName = cus.UserName,
                               Time = da.CreatedTime,
                               Credit = da.PaymentCredit

                           }).ToList();


            return Json(control, JsonRequestBehavior.AllowGet);
        }
    }
}