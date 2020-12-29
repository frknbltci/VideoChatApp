using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chat.CORE.Entities;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;

namespace chat.Emp.Controllers
{
    public class EmpProfileController : BaseController
    {
        public ActionResult Index()
        {
          var data = _employeeService.empProfileEdit(8);
            /*  if session varsa data.url = sessindan url getir yoksa ~/Assets/Custom/Images/AnonimImg.jpg bas direk   */
            return View(data);
        }

        private readonly IEmployeeUserService _employeeService;
        private readonly IUnitofWork _uow;
        private EmployeeSessionContext _employeeSessionContext;

        public EmpProfileController(IUnitofWork uow,IEmployeeUserService employeeUserService)
               :base(uow)
        {
            _uow = uow;
           _employeeService = employeeUserService;
            _employeeSessionContext = new EmployeeSessionContext();
        }


        [HttpPost]
        public ActionResult ProfileSave(EEmployeeDTO employee,HttpPostedFileBase resim)
        {
            string yol;

            if (resim != null || resim.ContentLength > 0)
            {
                var uzanti = Path.GetExtension(resim.FileName);
                var resimadi = Guid.NewGuid() + uzanti;
                resim.SaveAs(Server.MapPath("/Assets/ModelImg/" + resimadi)); 
                yol= "/Assets/ModelImg/" + resimadi;

            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            EEmployeeDTO updateEmp = new EEmployeeDTO(){
            ImageURL = yol,
            About=employee.About,
             BankName = employee.BankName,
            BirthDate= employee.BirthDate,
            BodyTypeID=employee.BodyTypeID,
            Email=employee.Email,
            EyeColorID=employee.EyeColorID,
            FirstName=employee.FirstName,
            GenderID=employee.GenderID,
            HairColorID=employee.HairColorID,
            HairTypeID=employee.HairTypeID,
            IBAN=employee.IBAN,
            LastName=employee.LastName,
            Length=employee.Length,
            NickName=employee.NickName,
            Password=employee.Password,
            UserName=employee.UserName,
            Weight=employee.Weight,
            IsActive=true,
            StatusID=1 ,   //sESSİONDAN
            Confirmation=true

            };

          _employeeService.Update(updateEmp);
           
          //  AutoMapper.Mapper.DynamicMap(employee,updateEmp);
          

            return Json(true, JsonRequestBehavior.AllowGet);
        }



    }
}