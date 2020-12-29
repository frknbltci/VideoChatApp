using chat.Admin.Attribute;
using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class AMessageController : BaseController
    {
        private readonly IGenericRepository<MessageCusAdmin> _messageCusRepository;


        private readonly IGenericRepository<MessageEmpAdmin> _messageEmpRepository;
        

        private readonly IGenericRepository<AdminUser> _adminUserRepository;

        private readonly ICustomerUserService  _customerUserService;

        private readonly IEmployeeUserService _employeeUserService;

        private readonly IMessageCusAdminService _messageCusAdminService;

        private readonly IMessageEmpAdminService _messageEmpAdminService;



        private readonly IUnitofWork _uow;
        public AMessageController(IUnitofWork uow, IGenericRepository<MessageCusAdmin> messageCusRepository, IGenericRepository<AdminUser> adminUserRepository , ICustomerUserService customerUserService, 
            IMessageCusAdminService messageCusAdminService , IGenericRepository<MessageEmpAdmin> messageEmpRepository,
            IEmployeeUserService employeeUserService ,
            IMessageEmpAdminService messageEmpAdminService) : base(uow)
        {
            _uow = uow;
            _messageCusRepository = messageCusRepository;
            _adminUserRepository = adminUserRepository;
            _customerUserService = customerUserService;
            _messageCusAdminService = messageCusAdminService;
            _messageEmpRepository = messageEmpRepository;
            _employeeUserService = employeeUserService;
            _messageEmpAdminService = messageEmpAdminService;
        }

        // GET: AMessage
        public ActionResult CustomerMessageList()
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {

                var list = _messageCusRepository.GetAll().ToList();
                var cus = _customerUserService.getCusList();
                var adminList = _adminUserRepository.GetAll().ToList();

                var data = (from m in list
                            join ad in adminList on m.AdminID equals ad.ID
                            join c in  cus on m.CusID equals c.ID
                            select new DTO.EEntity.MessageDTO
                            {
                                About = m.About,
                                AdminName = ad.UserName,
                                SendDate = m.SendDate.Date,
                                Messages = m.Message,
                                Name=c.UserName,
                                Email=c.Email,
                                CustomerList=cus
                                
                            }).ToList();

                return View(data);
            }
        }
        public ActionResult EmpMessageList()
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {

                var list = _messageEmpRepository.GetAll().ToList();
                var emp = _employeeUserService.getEmployee();
                var adminList = _adminUserRepository.GetAll().ToList();

                var data = (from m in list
                            join ad in adminList on m.AdminID equals ad.ID
                            join e in emp on m.EmpID equals e.ID
                            select new DTO.EEntity.MessageDTO
                            {
                                About = m.About,
                                AdminName = ad.UserName,
                                SendDate = m.SendDate.Date,
                                Messages = m.Message,
                                Name = e.UserName,
                                Email = e.Email,
                                EmployeeList=emp

                            }).ToList();

                return View(data);
            }
        }
        
        public ActionResult AllUserSend()
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult sendMessageToAllUsers(MessageDTO gelen)
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                try
                {
                    gelen.AdminID = ((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]).ID;
                    

                    foreach (var item in _customerUserService.getCusList())
                    {
                        gelen.SendDate = DateTime.Now.Date;
                        gelen.ReceiveID = item.ID;
                        _messageCusAdminService.senMessagetoCus(gelen);
                    }

                    foreach (var item in _employeeUserService.getEmployee())
                    {
                        gelen.SendDate = DateTime.Now.Date;
                        gelen.ReceiveID = item.ID;
                        _messageEmpAdminService.senMessagetoEmp(gelen);

                    }
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                return Json(true, JsonRequestBehavior.AllowGet);

            }

        }


        [HttpPost]
        public ActionResult sendMessageToCustomer(MessageDTO gelen)
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                try
                {
                    var AdminID = ((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]).ID;

                    gelen.AdminID = AdminID;
                    gelen.SendDate = DateTime.Now.Date;
                    gelen.Viewed = false;

                    var sonuc = _messageCusAdminService.senMessagetoCus(gelen);
                    if (sonuc == true)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }


            }
  
        }


        [HttpPost]
        public ActionResult sendMessageToEmployee(MessageDTO gelen)
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                try
                {
                    var AdminID = ((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]).ID;

                    gelen.AdminID = AdminID;
                    gelen.SendDate = DateTime.Now.Date;
                    gelen.Viewed = false;

                    var sonuc = _messageEmpAdminService.senMessagetoEmp(gelen);
                    if (sonuc == true)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }


            }

        }


    }
}