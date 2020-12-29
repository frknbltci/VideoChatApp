using chat.DATA.UnitofWork;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IUnitofWork uow)
        {

        }
    }
}