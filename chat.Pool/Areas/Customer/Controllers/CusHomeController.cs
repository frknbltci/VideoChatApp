using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.Pool.Attribute;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Customer.Controllers
{

    [Auth]
    public class CusHomeController : BaseController
    {
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepoService;
        private EmpCusSessionContext _empcusSessionContext;

        public CusHomeController(IUnitofWork uow, IGenericRepository<chat.CORE.Entities.Customer> customerRepoService) : base(uow)
        {
            _customerRepoService = customerRepoService;
            _empcusSessionContext = new EmpCusSessionContext();
        }

        // GET: Customer/CusHome
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).UserName == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
                var usename = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).UserName;

                var CusvarMi = _customerRepoService.GetAll().Where(x => x.UserName == usename).SingleOrDefault();

                _empcusSessionContext.ID = CusvarMi.ID;
                _empcusSessionContext.UserName = CusvarMi.UserName;
                _empcusSessionContext.ImageUrl = CusvarMi.ImageURL;
                _empcusSessionContext.BtPrice = CusvarMi.BtPrice;
                _empcusSessionContext.Type = 1;
                _empcusSessionContext.StatusID = 1; // nasıl olsa mantıklı olur çevrim içi 1 / çevrim dışı 2 
                Session["EmpCusSessionContext"] = _empcusSessionContext;
                return View();
            }
        }
    }
}