using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Customer.Controllers
{
    [Auth]
    public class CusPaymentController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IGenericRepository<chat.CORE.Entities.CustomerPayment> _customerPaymentRepoService;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepoService;
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepoService;
        public CusPaymentController(IUnitofWork uow, IGenericRepository<chat.CORE.Entities.CustomerPayment> customerPaymentRepoService,
            IGenericRepository<chat.CORE.Entities.Employee> employeeRepoService,
            IGenericRepository<chat.CORE.Entities.Customer> customerRepoService) : base(uow)
        {
            _uow = uow;
            _customerPaymentRepoService = customerPaymentRepoService;
            _employeeRepoService = employeeRepoService;
            _customerRepoService = customerRepoService;
        }

        // GET: Customer/CusPayment
        public ActionResult Index()
        {

            var ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;
            var empList = _employeeRepoService.GetAll().ToList();
            var payList = _customerPaymentRepoService.GetAll().Where(x=>x.CustomerID==ID).ToList();

            
            
            var list = (from p in payList
                           join e in empList on p.EmployeeID equals e.ID
                           where p.CustomerID==ID
                           select new EDeserveDTO
                           {
                             Credit=p.PaymentCredit,
                             Time=p.CreatedTime,
                             EmployeeName=e.UserName,
                             Tipi=(p.PaymentCredit==5) ? "5 Dakikalık Görüşme":"Hediye Gönderimi",
                             ID=p.ID

                           }).ToList();

            List<EDeserveDTO> newgiftList = new List<EDeserveDTO>();
            List<EDeserveDTO> newCallList = new List<EDeserveDTO>();

            foreach (var item in list)
            {
                if (item.Credit==5)
                {
                    newCallList.Add(item);
                }
                else
                {
                    newgiftList.Add(item);
                }
            }

            var gonder = new Lists()
            {
                gifts = newgiftList,
                calls = newCallList
            };

            return View(gonder);
        }

        public ActionResult PaymentToSystem()
        {
            return View();
        }
    }
}