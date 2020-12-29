using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Employee.Controllers
{
    public class EmpLoginController : BaseController
    {
        private readonly IEmployeeUserService _employeeService;
        private readonly IUnitofWork _uow;
        private EmployeeSessionContext _employeeSessionContext;

        public EmpLoginController(IUnitofWork uow, IEmployeeUserService employeeUserService)
            : base(uow)
        {
            _uow = uow;
            _employeeService = employeeUserService;
            _employeeSessionContext = new EmployeeSessionContext();
        }


        // GET: Employee/EmpLogin

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult doLogin(ELoginDTO gelen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var varMi = _employeeService.getEmployeInfo(gelen.Email, gelen.Password);
        //        if (varMi!=null)
        //        {
        //            _employeeSessionContext.ID = varMi.ID;
        //            _employeeSessionContext.UserName = varMi.UserName;

        //            Session["EmployeeSessionContext"] = _employeeSessionContext;

        //            return Json(true, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(false, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return View();
        //}


        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Employee/EmpLogin/Index");
        }
    }
}