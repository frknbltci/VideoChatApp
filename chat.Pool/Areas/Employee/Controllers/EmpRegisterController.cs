using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Employee.Controllers
{
    public class EmpRegisterController : BaseController
    {
        private readonly IEmployeeUserService _employeeService;
        private readonly IUnitofWork _uow;

        public EmpRegisterController(IUnitofWork uow, IEmployeeUserService employeeUserService) : base(uow)
        {
            _uow = uow;
            _employeeService = employeeUserService;
        }

        // GET: EmpRegister
        public ActionResult Index()
        {
            var lists=_employeeService.getRegisInfo();

            return View(lists);
        }



    }
}