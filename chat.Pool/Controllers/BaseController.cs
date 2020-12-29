using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController(IUnitofWork uow)
        {

        }
    }
}