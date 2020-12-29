using chat.DATA.UnitofWork;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Employee.Controllers
{
    [Auth]
    public class EmpMessagesController : BaseController
    {
        private readonly IMessageEmpAdminService _messageEmpAdminService;
        private readonly IAdminUserService _adminuserService;

        private readonly IUnitofWork _uow;
        public EmpMessagesController(IUnitofWork uow, IMessageEmpAdminService messageEmpAdminService, IAdminUserService adminuserService) : base(uow)
        {
            _uow = uow;
            _messageEmpAdminService = messageEmpAdminService;
            _adminuserService = adminuserService;
        }

        // GET: Employee/EmpMessages
        public ActionResult Messages()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return Redirect("/PoolLogin/LoginIndex");
            }
            else
            {

                var list = _messageEmpAdminService.allMessageList(((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID);

                var adminList = _adminuserService.getAdminList();

                var data = (from m in list
                            join ad in adminList on m.AdminID equals ad.ID
                            where m.EmpID == ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID
                            select new DTO.EEntity.MessageDTO
                            {
                                About = m.About,
                                AdminName = ad.UserName,
                                SendDate = m.SendDate.Date,
                                Messages = m.Message,
                                ID = m.ID,
                                Viewed = m.Viewed
                            }).ToList();

                return View(data);
            }
        }

        [HttpPost]
        public ActionResult changeView(int? ID)
        {
            if (ID == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    _messageEmpAdminService.UpdateView((int)ID);
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

        }



    }
}