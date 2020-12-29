using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chat.CORE.Entities;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;

namespace chat.Pool.Areas.Employee.Controllers
{
   [Auth]
    public class EmpProfileController : BaseController
    {
        private readonly IEmployeeUserService _employeeService;
        private readonly IUnitofWork _uow;
        private EmpCusSessionContext _empcusSessionContext;

        public EmpProfileController(IUnitofWork uow, IEmployeeUserService employeeUserService)
              : base(uow)
        {
            _uow = uow;
            _employeeService = employeeUserService;
            _empcusSessionContext = new EmpCusSessionContext();

        }
        public ActionResult Index()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {

                var data = _employeeService.empProfileEdit(((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID);

                _empcusSessionContext.ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;
                _empcusSessionContext.UserName = data.employe.UserName;
                _empcusSessionContext.ImageUrl = data.employe.ImageURL;
                _empcusSessionContext.NickName = data.employe.NickName;
                _empcusSessionContext.Type = 2;
                _empcusSessionContext.StatusID = data.employe.StatusID;

                Session["EmpCusSessionContext"] = _empcusSessionContext;

                if (data.employe.ImageURL==null)
                {
                    data.employe.ImageURL = "~/Assets/Custom/Images/AnonimImg.jpg";
                }
                return View(data);

            }
            /*  if session varsa data.url = sessindan url getir yoksa ~/Assets/Custom/Images/AnonimImg.jpg bas direk   */
           
        }

 
        [HttpPost]
        public ActionResult ProfileSave(EEmployeeDTO employee,HttpPostedFileBase resim)
        {

            string yol;
            try
            {
                if (employee.uploadImgEmp != null )
                {
                    yol =employee.uploadImgEmp;
                }
                else
                {
                    yol = employee.editEmpOldImg;
                }

                EEmployeeDTO updateEmp = new EEmployeeDTO()
                {
                    ImageURL = yol,
                    About = employee.About,
                    BankName = employee.BankName,
                    BirthDate = employee.BirthDate,
                    BodyTypeID = employee.BodyTypeID,
                    Email = employee.Email,
                    EyeColorID = employee.EyeColorID,
                    FirstName = employee.FirstName,
                    GenderID = employee.GenderID,
                    HairColorID = employee.HairColorID,
                    HairTypeID = employee.HairTypeID,
                    IBAN = employee.IBAN,
                    LastName = employee.LastName,
                    Length = employee.Length,
                    NickName = employee.NickName,
                    Password = employee.Password,
                    UserName = employee.UserName,
                    Weight = employee.Weight,
                    IsActive = true,
                    StatusID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).StatusID,   
                    Confirmation = true

                };

                _employeeService.Update(updateEmp);
               

                TempData["mes"] = "<span style='color:green;'> Başarıyla Güncellendi </span>";

              
                return Redirect("/Employee/EmpProfile/Index");
            }
            catch (Exception)
            {
                TempData["mes"] = "err";
             

                return Redirect("/Employee/EmpProfile/Index");
              
            }
            
        }


        [HttpPost]
       
        public ActionResult changeStatus(int? statusId,int? empId)
        {
            if (statusId==null || empId==null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sonuc=_employeeService.changeStatus(statusId, empId);
                if (sonuc==true)
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