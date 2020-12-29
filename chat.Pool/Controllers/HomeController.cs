using chat.DATA.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitofWork uow) : base(uow)
        {

        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Rules()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PayPage()
        {
            return View();
        } 
        [HttpGet]
        public ActionResult PrivacyPrinciples()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ReturnAndExchangeConditions()
        {

            return View();
        }

        [HttpGet]
        public ActionResult BankAndAccountInformation()
        {

            return View();
        }


         [HttpGet]
        public ActionResult ProtectionOfPersonalData()
        {

            return View();
        } 

        [HttpGet]
        public ActionResult TermsOfUse()
        {

            return View();
        }





    }
}