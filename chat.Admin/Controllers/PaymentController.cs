using chat.Admin.Attribute;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class PaymentController : BaseController
    {

        private readonly IEmployeeUserService _employeeUserService;


        private readonly IGenericRepository<chat.CORE.Entities.PayChart> _paychartRepository;
        private readonly IGenericRepository<chat.CORE.Entities.AdminUser> _adminRepository;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepository;
        private readonly IGenericRepository<chat.CORE.Entities.TimeLine> _timeLineRepository;
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepository;
        private readonly IGenericRepository<chat.CORE.Entities.CustomerPayment> _customerPaymentRepository;

        private readonly IPayChartService _paychartService;

        private IUnitofWork _uow;
        public PaymentController(IUnitofWork uow, IEmployeeUserService employeeUserService,
            IGenericRepository<chat.CORE.Entities.PayChart> paychartRepository,
            IGenericRepository<chat.CORE.Entities.AdminUser> adminRepository,
            IGenericRepository<chat.CORE.Entities.Employee> employeeRepository,
            IGenericRepository<chat.CORE.Entities.TimeLine> timeLineRepository,
            IGenericRepository<chat.CORE.Entities.Customer> customerRepository,
            IGenericRepository<chat.CORE.Entities.CustomerPayment> customerPaymentRepository,
             IPayChartService paychartService) : base(uow)
        {
            _uow = uow;
            _employeeUserService = employeeUserService;
            _paychartRepository = paychartRepository;
            _adminRepository = adminRepository;
            _employeeRepository = employeeRepository;
            _timeLineRepository = timeLineRepository;
            _customerRepository = customerRepository;
            _customerPaymentRepository = customerPaymentRepository;
            _paychartService = paychartService;
        }

        // GET: Payment
        public ActionResult makePayment()
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
               var uname =((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]).UserName;


                var payChartList = _paychartRepository.GetAll().ToList();
                var empList = _employeeUserService.getEmployee();
                var adminList = _adminRepository.GetAll().ToList();


                 var data = (from p in payChartList
                            join e in empList on p.EmployeeID equals e.ID
                            join a in adminList on p.AdminID equals a.ID
                            select new DTO.EEntity.APaymentDTO
                            {
                                Quantity =p.Quantity,
                                EmployeeName = "Adı Soyadı :" + e.FirstName +" " + e.LastName + " Kullancı Adı: " + e.UserName,
                                AdminName = a.UserName,
                                CreatedDate = p.CreatedDate.Date, 
                            });

                return View(data);

            }



       


        }


        public ActionResult takePayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sendPaymentInfo(APaymentDTO gelen)
        {
                 if (gelen.dfile != null)
                {
                //    var uzanti = Path.GetExtension(gelen.dfile.FileName);
                //    var resimadi = Guid.NewGuid() + uzanti;
                //var urlSchema = HttpContext.Request.Url.Scheme;
                //var url = HttpContext.Request.Url.Authority;
                //var strPath = urlSchema + "://" + url + "/Assets/Custom/DecImages/" + resimadi;

                //http://localhost:53176/Assets/Custom/DecImages/8dc35ae7-a957-4821-ba86-a42806823fd0.jpg
                //burda url düzgün alınmalı
                //gelen.dfile.SaveAs(Server.MapPath("/Assets/Custom/DecImages/" + resimadi));
                /*gelen.dfile.SaveAs(Server.MapPath(url+"/Assets/Custom/DecImages/" + resimadi));*/
                    //gelen.dIFile = strPath;
                /* gelen.dIFile = url+ "/Assets/Custom/DecImages/" + resimadi;*/
                }
            gelen.AdminID = ((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]).ID;
            gelen.CreatedDate = DateTime.Now.Date;

                   var sonuc=  _paychartService.savePayInfo(gelen);
            if (sonuc==true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult Deserve()
        {

            var emplist = _employeeUserService.getEmployee();

            AdminDeserveDTO dto = new AdminDeserveDTO()
            {
                EmpList = emplist
            };

            return View(dto);

        }

        [HttpPost]
        //Sadece Görüşme hakedişleri hesaplanıyor
        public ActionResult calcDeserve(DateTime StartDate, DateTime EndDate,int? EmpID)
        {
            var dataList=_customerPaymentRepository.GetAll().Where(x => x.CreatedTime >= StartDate && x.CreatedTime <= EndDate && x.EmployeeID == EmpID).ToList();

            var cusList = _customerRepository.GetAll().ToList();

            var control = (from da in dataList
                           join cus in cusList on da.CustomerID equals cus.ID
                           select new AdminDeserveDTO
                           {
                               CustomerName=cus.UserName,
                               startTime=da.CreatedTime,
                               Credit=da.PaymentCredit
                               
                           }).ToList();


            return Json(control, JsonRequestBehavior.AllowGet);
        }


    }
}