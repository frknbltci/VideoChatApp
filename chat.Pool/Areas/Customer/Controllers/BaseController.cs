using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Customer.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IUnitofWork uow)
        {

        }
    }
}