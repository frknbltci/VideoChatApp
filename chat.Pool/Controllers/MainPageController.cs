using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    [Auth]
    public class MainPageController : BaseController
    {
        //Direk Repository Üzerinden yapılanlar
        private readonly IGenericRepository<Employee> _employeRepoService;
        private readonly IGenericRepository<Customer> _customerRepoService;
        private EmpCusSessionContext _empcusSessionContext;

        private readonly IGenericRepository<HairColors> _haircolorRepoService;
        private readonly IGenericRepository<HairTypes> _hairTypesRepoService;
        private readonly IGenericRepository<EyeColors> _eyeColorsRepoService;
        private readonly IGenericRepository<BodyTypes> _bodyTypesRepoService;

        private readonly IGenericRepository<PoolBan> _poolBanRepoService;
        private readonly IGenericRepository<Messages> _messagesRepoService;
        private readonly IGenericRepository<CustomerPayment> _customerPaymentRepoService;


        /*Direk Repo Son*/
        private readonly IFavoritesService _favoritesService;

        private readonly IPoolBanService _poolbanService;

        private readonly IMessageEmpAdminService _empAdminMessageservice;
        private readonly IMessageCusAdminService _cusAdminMessageservice;
        private readonly IMessagesService _messageService;
        private readonly ICustomerUserService _cusUserService;
        private readonly ICustomerPaymentService _customerPaymentService;

        // private readonly IEmployeeUserService _employeeService;
        private readonly IUnitofWork _uow;
        public MainPageController(IUnitofWork uow, IMessageEmpAdminService empAdminMessageservice, IMessageCusAdminService cusAdminMessageservice, IGenericRepository<Employee> employeRepoService, IGenericRepository<Customer> customerRepoService, IFavoritesService favoritesService, IGenericRepository<HairColors> haircolorRepoService, IGenericRepository<HairTypes> hairTypesRepoService, IGenericRepository<EyeColors> eyeColorsRepoService, IGenericRepository<BodyTypes> bodyTypesRepoService,
            IGenericRepository<PoolBan> poolBanRepoService,
            IPoolBanService poolbanService,
            IGenericRepository<Messages> messagesRepoService,
            IMessagesService messageService,
            ICustomerUserService cusUserService,
            ICustomerPaymentService customerPaymentService,
            IGenericRepository<CustomerPayment> customerPaymentRepoService) : base(uow)
        {
            _uow = uow;
            _messageService = messageService;
            _employeRepoService = employeRepoService;
            _customerRepoService = customerRepoService;
            _empAdminMessageservice = empAdminMessageservice;
            _cusAdminMessageservice = cusAdminMessageservice;
            _favoritesService = favoritesService;
            _haircolorRepoService = haircolorRepoService;
            _hairTypesRepoService = hairTypesRepoService;
            _eyeColorsRepoService = eyeColorsRepoService;
            _bodyTypesRepoService = bodyTypesRepoService;
            _poolBanRepoService = poolBanRepoService;
            _poolbanService = poolbanService;
            _messagesRepoService = messagesRepoService;
            _cusUserService = cusUserService;
            _customerPaymentService = customerPaymentService;
            _customerPaymentRepoService = customerPaymentRepoService;

            _empcusSessionContext = new EmpCusSessionContext();
        }

        // GET: MainPage
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
                var ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;

                var usename= ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).UserName;

                var EmpvarMi = _employeRepoService.GetAll().Where(x => x.UserName == usename).SingleOrDefault();

                var CusvarMi = _customerRepoService.GetAll().Where(x => x.UserName == usename).SingleOrDefault();

                if (EmpvarMi != null)
                {
                    if (CusvarMi != null)
                    {
                       
                    }
                    else
                    {
                            TempData["type"] = "emp";
                            _empcusSessionContext.ID = EmpvarMi.ID;
                            _empcusSessionContext.UserName = EmpvarMi.UserName;
                            _empcusSessionContext.ImageUrl = EmpvarMi.ImageURL;
                            _empcusSessionContext.NickName = EmpvarMi.NickName;
                            _empcusSessionContext.Type = 2;
                            _empcusSessionContext.StatusID = 1;
                            Session["EmpCusSessionContext"] = _empcusSessionContext;

                    }
                }
                else
                {
                    if (CusvarMi == null)
                    {
                        
                    }
                    else
                    {
                            TempData["type"] = "cus";
                            _empcusSessionContext.ID = CusvarMi.ID;
                            _empcusSessionContext.UserName = CusvarMi.UserName;
                            _empcusSessionContext.ImageUrl = CusvarMi.ImageURL;
                            _empcusSessionContext.BtPrice = CusvarMi.BtPrice;
                            _empcusSessionContext.Type = 1;
                            _empcusSessionContext.StatusID = 1;
                        Session["EmpCusSessionContext"] = _empcusSessionContext;

                    }
                }


                var banList = _poolBanRepoService.GetAll().Where(x => x.CustomerID == ID).ToList();
                var employes = _employeRepoService.GetAll().Where(x => x.StatusID == 1).ToList();
                var favList = _favoritesService.getFavorite(ID);


                for (int k = 0; k < banList.Count; k++)
                {
                    for (int i = 0; i < employes.Count; i++)
                     {
                        if (employes[i].ID==banList[k].EmployeeID)
                        {
                            employes.Remove(employes[i]);
                        }
                    }
                }

                var customer = _customerRepoService.GetAll().Where(x=>x.StatusID==1).ToList();
                DTO.EEntity.PoolMainDTO pool = new DTO.EEntity.PoolMainDTO();
                pool.CustomerList = customer;
                if (banList.Count == 0)
                {
                    pool.EmployeeList = employes;
                }
                else
                {
                    pool.EmployeeList = employes;
                }
                pool.FavList = favList;
                

                return View(pool);
            }

        }

        [HttpPost]
        public ActionResult routuToHome(string UserName)
        {

            var EmpMi = _employeRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

            var CusMi = _customerRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

            if (EmpMi != null)
            {
                if (CusMi != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                else
                {

                    return Json("emp", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (CusMi == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("cus", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult getMessage(int? ID, string UserName)
        {
            if (ID == null || UserName == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var EmpMi = _employeRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                var CusMi = _customerRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                if (EmpMi != null)
                {
                    if (CusMi != null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {

                        var empMessageList = _empAdminMessageservice.messageList((int)ID);
                        return Json(empMessageList, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    if (CusMi == null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {

                        var cusMessageList = _cusAdminMessageservice.messageList((int)ID);
                        //List<chat.CORE.Entities.MessageCusAdmin> list;

                        //foreach (var item in cusMessageList)
                        //{
                        //    item.SendDate
                        //}

                        return Json(cusMessageList, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult routeToMessages(string UserName, int? ID)
        {
            if (ID == null || UserName == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var EmpMi = _employeRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                var CusMi = _customerRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                if (EmpMi != null)
                {
                    if (CusMi != null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        if (ID == EmpMi.ID)
                        {
                            return Json("emp", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Admin ile iletişime geçilsin hatası dönsün
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }

                    }
                }
                else
                {
                    if (CusMi == null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        if (ID == CusMi.ID)
                        {
                            return Json("cus", JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //Adminle İletişime Geçin
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }


        [HttpPost]
        public ActionResult addFav(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID == null || EmployeeID == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var sonuc = _favoritesService.addFav(CustomerID, EmployeeID);
                    if (sonuc == false)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }


        }


        public ActionResult getEmployeeInfo(int? ID)
        {
            if (ID == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var employe = _employeRepoService.GetAll().Where(x => x.ID == ID).SingleOrDefault();
                    var empHairColor = _haircolorRepoService.GetAll().Where(x => x.ID == employe.HairColorID).SingleOrDefault();
                    var empBodyType = _bodyTypesRepoService.GetAll().Where(x => x.ID == employe.BodyTypeID).SingleOrDefault();
                    var empEyeColor = _eyeColorsRepoService.GetAll().Where(x => x.ID == employe.EyeColorID).SingleOrDefault();
                    var empHairType = _hairTypesRepoService.GetAll().Where(x => x.ID == employe.HairTypeID).SingleOrDefault();

                    EmployeeInfoDTO emp = new EmployeeInfoDTO()
                    {
                        About = employe.About,
                        BodyTypeName = empBodyType.BodyTypeName,
                        EyeColorName = empEyeColor.ColorName,
                        HairColorName = empHairColor.ColorName,
                        HairTypeName = empHairType.HairType,
                        Length = employe.Length,
                        Weight = employe.Weight,
                        Yas = DateTime.Now.Year - employe.BirthDate.Year,
                        ImgUrl=employe.ImageURL,
                        StatusId=employe.StatusID
                       
                    };

                    return Json(emp, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }
        }


        [HttpPost]
        public ActionResult delFav(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID == null || EmployeeID == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                   var sonuc = _favoritesService.delFav(CustomerID, EmployeeID);
                    if (sonuc==true)
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
        public ActionResult addBan(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID==null || EmployeeID==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var sonuc = _poolbanService.addBan(CustomerID, EmployeeID);
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
        public ActionResult getUsers()
        {

            try
            {
                var data = _customerRepoService.GetAll().Where(x=>x.StatusID==1 || x.StatusID==3).Take(5).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            

            
        }


        [HttpPost]
        public ActionResult isStatusOnline(int? eid)
        {
            if (eid==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var emp = _employeRepoService.GetAll().Where(x => x.ID == eid).SingleOrDefault();
                return Json(emp.StatusID, JsonRequestBehavior.AllowGet);
            }

            
        }


        [HttpPost]
        public ActionResult isCreditSuit(int? CustomerId)
        {

            if (CustomerId==null || CustomerId==0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var price= _customerRepoService.Find((int)CustomerId).BtPrice;
                //Kredi Uygunluk koşulu 5
                if (price >= 5)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }


            }

        }


        //Conversation arka tarafa veri getirmek
        [HttpPost]
        public ActionResult getMessagesLastTen(int? SenderID,int? ReceiverID)
        {
            if (SenderID == null || ReceiverID == null || SenderID == 0 || ReceiverID == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var mlst = _messagesRepoService.GetAll().Where(x=>x.SenderID==SenderID && x.ReceiverID==ReceiverID || x.SenderID==ReceiverID && x.ReceiverID== SenderID).OrderByDescending(x=>x.CreatedDate).Take(10).ToList();
                    mlst.Reverse();
                    var cusList = _customerRepoService.GetAll().ToList();
                    var empList = _employeRepoService.GetAll().ToList();

                    var control = (from ml in mlst
                                   join cus in cusList on ml.SenderID equals cus.ID into mlcus
                                   from mc in mlcus.DefaultIfEmpty()
                                   join emp in empList on ml.SenderID equals emp.ID into mlemp
                                   from me in mlemp.DefaultIfEmpty()
                                   join g2 in cusList on ml.ReceiverID equals g2.ID into mlcus2
                                   from mc2 in mlcus2.DefaultIfEmpty()
                                   join e2 in empList on ml.ReceiverID equals e2.ID into mlemp2
                                   from me2 in mlemp2.DefaultIfEmpty()
                                   select new ConversationDTO
                                   {
                                       CreatedDate = ml.CreatedDate,
                                       Message = ml.Message,
                                       SenderID = ml.SenderID,
                                       ReceiverID = ml.ReceiverID,
                                       Sender1Img = mc?.ImageURL ?? String.Empty,
                                       SenderName1 = mc?.UserName ?? String.Empty,
                                       Sender2Img = me?.ImageURL ?? String.Empty,
                                       SenderName2 = me?.UserName ?? String.Empty,
                                       Receiver1Img = mc2?.ImageURL ?? String.Empty,
                                       Receiver2Img = me2?.ImageURL ?? String.Empty,
                                       ReceiverName1 = mc2?.UserName ?? String.Empty,
                                       ReceiverName2 = me2?.UserName ?? String.Empty

                                   }).ToList();


                    return Json(control, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }


            }

            //return Json(true, JsonRequestBehavior.AllowGet);

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult sendConv(ConversationDTO gelen)
        {
            if (gelen.SenderID==null || gelen.ReceiverID == null || gelen.ReceiverID==0 || gelen.SenderID==0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    gelen.CreatedDate = DateTime.Now;
                   var sonuc=_messageService.saveMessage(gelen);
                    if (sonuc==false)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult AccordingToUnameGetId(string UserName)
        {

            var EmpMi = _employeRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

            var CusMi = _customerRepoService.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

            if (EmpMi != null)
            {
                if (CusMi != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(EmpMi.ID, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (CusMi == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(CusMi.ID, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult ControlForMessageTime(int? SenderID, int? ReceiverID)
        {
            
            //var lastMessages = _messagesRepoService.GetAll().Where(x => x.SenderID == SenderID && x.ReceiverID == ReceiverID || x.SenderID == ReceiverID && x.ReceiverID == SenderID).OrderByDescending(x => x.CreatedDate).Take(10).ToList();

            var isPaid = _customerPaymentRepoService.GetAll().Where(x=>x.CustomerID==SenderID && x.EmployeeID==ReceiverID && x.PaymentCredit==1).OrderByDescending(x => x.CreatedTime).Take(1).SingleOrDefault();

            //var msg=lastMessages.Where(x => x.SenderID == SenderID).Take(1).SingleOrDefault();

            if (isPaid==null)
            {
                _cusUserService.decreaseBtPrice(1, (int)SenderID);
                _customerPaymentService.addCusPay(1, SenderID, ReceiverID);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var dm = DateTime.Now - isPaid.CreatedTime;
                if (dm.Days >= 1)
                {
                    _cusUserService.decreaseBtPrice(1, (int)SenderID);
                    _customerPaymentService.addCusPay(1, SenderID, ReceiverID);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
               
               

        }

       
        public ActionResult isSuitCreditForMessage(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID == null || CustomerID == 0 || EmployeeID==null || EmployeeID==0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var price = _customerRepoService.Find((int)CustomerID).BtPrice;
                //Kredi Uygunluk koşulu 1
                if (price >= 1)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var isPaid = _customerPaymentRepoService.GetAll().Where(x => x.CustomerID == CustomerID && x.EmployeeID == EmployeeID && x.PaymentCredit == 1).OrderByDescending(x => x.CreatedTime).Take(1).SingleOrDefault();

                    if (isPaid==null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var dm = DateTime.Now - isPaid.CreatedTime;
                        if (dm.Days < 1)
                        {
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(false, JsonRequestBehavior.AllowGet);
                        }
                        
                    }

                }
            }

        }

        [HttpPost]
        public ActionResult getCountOnline()
        {
            try
            {
                var CusCountOnline = _customerRepoService.GetAll().Where(x => x.StatusID == 1).Count();
                var EmpCountOnline = _employeRepoService.GetAll().Where(x => x.StatusID == 1).Count();

                List<int> countList = new List<int>();
                countList.Add(CusCountOnline);
                countList.Add(EmpCountOnline);
                return Json(countList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/PoolLogin/LoginIndex");
        }

    }
}


