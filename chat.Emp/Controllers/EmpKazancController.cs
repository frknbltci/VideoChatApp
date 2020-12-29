using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Emp.Controllers
{
    public class EmpKazancController : BaseController
    {
        public EmpKazancController(IUnitofWork uow) : base(uow)
        {
        }

        // GET: EmpKazanc
        public ActionResult Index()
        {
            return View();
        }
    }
}