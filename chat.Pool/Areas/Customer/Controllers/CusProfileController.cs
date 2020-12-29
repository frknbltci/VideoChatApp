using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces.Customer;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Customer.Controllers
{
    [Auth]
    public class CusProfileController : BaseController
    {

        private readonly ICustomerUserService _customerService;
        private readonly IUnitofWork _uow;
        private EmpCusSessionContext _empcusSessionContext;


        public CusProfileController(IUnitofWork uow, ICustomerUserService customerService) : base(uow)
        {
            _uow = uow;
            _customerService = customerService;
            _empcusSessionContext = new EmpCusSessionContext();

        }

        // GET: Customer/CusProfile
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).UserName == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
                var data = _customerService.cusProfileEdit(((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID);

                _empcusSessionContext.ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;
                _empcusSessionContext.UserName = data.UserName;
                _empcusSessionContext.ImageUrl = data.ImageUrl;
                _empcusSessionContext.Type = 1;
                _empcusSessionContext.StatusID = data.StatusID;
                _empcusSessionContext.BtPrice = data.BtPrice;

                Session["EmpCusSessionContext"] = _empcusSessionContext;

                if (data.ImageUrl == null)
                {
                    data.ImageUrl = "~/Assets/Custom/Images/AnonimImg.jpg";
                }
                return View(data);

            }
            /*  if session varsa data.url = sessindan url getir yoksa ~/Assets/Custom/Images/AnonimImg.jpg bas direk   */
        }


        [HttpPost]
        public ActionResult ProfileSave(CustomerProfileDTO customer,HttpPostedFileBase resim)
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {

            string yol;
            try
            {
                if (customer.uploadImgCus != null)
                {
                        yol = customer.uploadImgCus;
                    }
                else
                {
    
                    yol = customer.editCusOldImg;
                }

                CustomerProfileDTO updateData = new CustomerProfileDTO()
                {
                    ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID,
                    UserName = customer.UserName,
                    StatusID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).StatusID,
                    Password = customer.Password,
                    Email = customer.Email,
                    ImageUrl = yol

                };

                _customerService.Update(updateData);

     
                TempData["mes"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";

                return Redirect("/Customer/CusProfile/Index");
            }
            catch (Exception)
            {
                TempData["mes"] = "err";
        

                return Redirect("/Customer/CusProfile/Index");
              
            }
            }

        }




        [HttpPost]

        public ActionResult changeStatus(int? statusId, int? cusId)
        {
            if (statusId == null || cusId == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sonuc = _customerService.changeStatus(statusId, cusId);
                if (sonuc == true)
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

