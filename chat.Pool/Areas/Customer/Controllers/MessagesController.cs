using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chat.CORE.Entities;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Admin;
using chat.Pool.Attribute;

namespace chat.Pool.Areas.Customer.Controllers
{

    [Auth]
    public class MessagesController : BaseController
    {
        private readonly IMessageCusAdminService _messagecusadminservice;
        private readonly IAdminUserService _adminuserService;
        

        private readonly IUnitofWork _uow;
        public MessagesController(IUnitofWork uow,IMessageCusAdminService messagecusadminservice,IAdminUserService adminuserService) : base(uow)
        {
            _uow = uow;
            _messagecusadminservice = messagecusadminservice;
            _adminuserService = adminuserService;
        }
         
        // GET: Customer/Messages

        public ActionResult Messages()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"])==null)
            {
                return Redirect("/PoolLogin/LoginIndex");
            }
            else
            {

              var list = _messagecusadminservice.allMessageList(((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID);

                var adminList = _adminuserService.getAdminList();

                var data = (from m in list
                               join ad in adminList on m.AdminID equals ad.ID
                               where m.CusID == ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID
                               select new DTO.EEntity.MessageDTO
                               {
                                   About=m.About,
                                   AdminName=ad.UserName,
                                   SendDate=m.SendDate.Date,
                                   Messages=m.Message,
                                   ID=m.ID,
                                   Viewed=m.Viewed
                               }).ToList();

                return View(data);
            }

        }


        [HttpPost]
        public ActionResult changeView(int? ID)
        {
            if (ID==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                _messagecusadminservice.UpdateView((int)ID);
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