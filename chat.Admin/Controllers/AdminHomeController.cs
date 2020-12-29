using chat.Admin.Attribute;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class AdminHomeController : BaseController
    {

        private readonly IAdminUserService _adminUserService;
        private readonly IUnitofWork _uow;

        public AdminHomeController(UnitofWork uow, IAdminUserService adminUserService) : base(uow)
        {
            _uow = uow;
            _adminUserService = adminUserService;

        }

        public ActionResult Index()
        {
            var li = _adminUserService.EmployeesList();
            
            return View(li);
        }

        //public ActionResult Pieces()
        //{
        //    var gelen = _adminUserService.AmodelAdet();
        //    return Json(gelen, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult ActiveCheck(int? ID)
        //{
        //    if (ID != null)
        //    {
        //        _adminUserService.ActiveControl((int)ID);
        //        return Redirect("/AdminHome/Index");
        //    }
        //    else
        //    {
        //        return Redirect("/AdminHom/Index");
        //    }

        //}


    }
}