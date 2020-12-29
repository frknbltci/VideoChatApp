using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Emp.Controllers
{
    public class EmpHomeController : BaseController
    {
        public EmpHomeController(IUnitofWork uow) : base(uow)
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}