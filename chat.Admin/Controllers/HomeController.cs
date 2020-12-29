using chat.Admin.Attribute;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Admin.Controllers
{
    [AdminAuth]
    public class HomeController : BaseController
    {
        private readonly IGenericRepository<chat.CORE.Entities.PoolBan> _poolBanRepo;
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepo;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepo;
        private readonly IGenericRepository<chat.CORE.Entities.TimeLine> _timeLineRepo;


        private readonly IUnitofWork _uow;

        public HomeController(IUnitofWork uow, IGenericRepository<chat.CORE.Entities.TimeLine> timeLineRepo, IGenericRepository<chat.CORE.Entities.Employee> employeeRepo, IGenericRepository<chat.CORE.Entities.Customer> customerRepo, IGenericRepository<chat.CORE.Entities.PoolBan> poolBanRepo) : base(uow)
        {
            _uow = uow;
            _poolBanRepo = poolBanRepo;
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;
            _timeLineRepo = timeLineRepo;

        }

        // GET: Home
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return Redirect("/Login/Index");
            }
            else
            {
                //null dönüş ihtimali ?
                var banCount = _poolBanRepo.GetAll().ToList().Count;
                var customerCount = _customerRepo.GetAll().ToList().Count;
                var employeCount = _employeeRepo.GetAll().ToList().Count;
                var callCount = _timeLineRepo.GetAll().ToList().Count;


                var homeData = new AdminHomeDTO()
                {
                    BanCount = banCount,
                    CallCount = callCount,
                    CustomerCount = customerCount,
                    ModalCount = employeCount,
                    TotalUserCount = customerCount + employeCount


                };

                return View(homeData);

            }
           
        }
    }
}