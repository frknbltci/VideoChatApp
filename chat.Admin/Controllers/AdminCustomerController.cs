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
    public class AdminCustomerController : BaseController
    {
        private readonly IAdminCustomerService  _adminCustomerService;
        private readonly IUnitofWork _uow;

        public AdminCustomerController(IUnitofWork uow, IAdminCustomerService adminCustomerService) : base(uow)
        {
            _uow = uow;
            _adminCustomerService = adminCustomerService;
        }

        // GET: AdminCustomer
        public ActionResult Index()
        {
            var li = _adminCustomerService.CustomerList();
            return View(li);
        }
    }
}