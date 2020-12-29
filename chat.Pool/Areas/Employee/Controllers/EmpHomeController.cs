using chat.DATA.UnitofWork;
using chat.Pool.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Employee.Controllers
{
    [Auth]
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