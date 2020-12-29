using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Areas.Customer.Controllers
{
    [Auth]
    public class CusModalController : BaseController
    {
        private readonly IPoolBanService _poolBanService;
        private readonly IEmployeeUserService _employeeUserService;

        private readonly IFavoritesService _favService;

        private readonly IUnitofWork _uow;
        public CusModalController(IUnitofWork uow,IPoolBanService poolBanService,
            IEmployeeUserService employeeUserService,IFavoritesService favService) : base(uow)
        {
            _uow = uow;
            _employeeUserService = employeeUserService;
            _poolBanService = poolBanService;
            _favService = favService;
        }

        // GET: Customer/CusModal
       
        public ActionResult getBanList()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
                //try catch kontrolü ile sabit err sayfasına yönledirebilirsin

                var ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;

                var employeList = _employeeUserService.getEmployee();

                var banList = _poolBanService.getBanList();

                var control = (from e in employeList
                               join ban in banList on e.ID equals ban.EmployeeID
                               where ban.CustomerID == ID
                               select new CusBanDTO
                               {
                                   ModelName=e.NickName,
                                   ModelID=ban.EmployeeID,
                                   Age=DateTime.Now.Year-e.BirthDate.Year,
                                   StatusID=e.StatusID,
                                  ImageUrl=e.ImageURL

                               }).ToList();

                return View(control);
            }

            
        }


        public ActionResult getFavList()
        {
            if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]) == null)
            {
                return RedirectToAction("LoginIndex", "PoolLogin", new { area = "" });
            }
            else
            {
                //try catch kontrolü ile sabit err sayfasına yönledirebilirsin

                var ID = ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).ID;

                var employeList = _employeeUserService.getEmployee();

                var favList = _favService.getFavorite(ID);

                var control = (from e in employeList
                               join fav in favList on e.ID equals fav.EmployeeID
                               where fav.CustomerID == ID
                               select new CusFavDTO
                               {
                                   ModelName = e.NickName,
                                   ModelID = fav.EmployeeID,
                                   StatusID=e.StatusID,
                                   ImageUrl=e.ImageURL
                               }).ToList();

                return View(control);
            }


        }



        

        public ActionResult outBan(int? CustomerId, int? EmployeeId)
        {
            if (CustomerId==null || EmployeeId==null || CustomerId==0 || EmployeeId==0)
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sonuc = _poolBanService.delBanModal(CustomerId, EmployeeId);
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





        public ActionResult outFav(int? CustomerId, int? EmployeeId)
        {
            if (CustomerId == null || EmployeeId == null || CustomerId == 0 || EmployeeId == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sonuc = _favService.delFav(CustomerId, EmployeeId);
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