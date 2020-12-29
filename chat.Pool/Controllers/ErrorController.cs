using chat.DATA.UnitofWork;
using chat.Pool.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    [Auth]
    public class ErrorController : BaseController
    {
      
        public ErrorController(IUnitofWork uow) : base(uow)
        {
        }

        // GET: Error
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
       
        public ActionResult Page405()
        {
            Response.StatusCode = 405;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }

        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page502()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
        public ActionResult Page503()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View("PageError");
        }
    }
}