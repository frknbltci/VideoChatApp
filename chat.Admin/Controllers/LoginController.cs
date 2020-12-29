using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Admin;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index() {

            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
        
        
        }

        private readonly IAdminUserService _adminUserService;
        private readonly IUnitofWork _uow;
        private AdminSessionContext _adminSessionContext;
        public LoginController(IUnitofWork uow, IAdminUserService adminUserService)
            : base(uow)
        {
            _uow = uow;
            _adminUserService = adminUserService;
            _adminSessionContext = new AdminSessionContext();
        }

        [HttpPost]
        public ActionResult LoginControl(EAdminUserDTO login)
        {
            var result = _adminUserService.GetUserByUnAPass(login.UserName, login.Password);
            if (result != null && result.ID != 0)
            {
                AutoMapper.Mapper.DynamicMap(result, _adminSessionContext);
                Session["AdminSessionContext"] = _adminSessionContext;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/");
        }

    }
}