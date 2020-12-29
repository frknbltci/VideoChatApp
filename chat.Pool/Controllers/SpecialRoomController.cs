using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Interfaces.Employee;
using chat.UTILITIES.SessionOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chat.Pool.Controllers
{
    [Auth]
    public class SpecialRoomController : BaseController
    {
        private readonly ICustomerUserService _customerRepoService;
        private readonly IEmployeeUserService _employeeRepoService;
        private readonly ITimeLineService _timeLineRepoService;
        private readonly IUnitofWork _uow;
        private readonly ICustomerPaymentService _cuspayment;


        private EmpCusSessionContext _empcusSessionContext;


        private readonly IGenericRepository<Customer> _cusRepository;
        private readonly IGenericRepository<Employee> _empRepository;

        public SpecialRoomController(IUnitofWork uow, IEmployeeUserService employeeService,
            ITimeLineService timeLineRepoService, ICustomerUserService customerService,
            IGenericRepository<Customer> cusRepository, IGenericRepository<Employee> empRepository, ICustomerPaymentService cuspayment
            ) : base(uow)
        {
            _uow = uow;
            _employeeRepoService = employeeService;
            _timeLineRepoService = timeLineRepoService;
            _customerRepoService = customerService;
            _empcusSessionContext = new EmpCusSessionContext();

            _cusRepository = cusRepository;
            _empRepository = empRepository;
            _cuspayment = cuspayment;
        }

        // [Route("Odalar/{roomNumber}/{cusId}/{empId}")]
        //buraya artık random oda numaraları gelecek
        //[HttpPost]
        //public ActionResult Index(string roomNumber,int cusId, int empId)
        //{
        //   // var emp = _employeeRepoService.Find(empId);
        //    return View();
        //}

        [HttpGet]
        public ActionResult Oda(string room_id, int userid, int empid)
        {
            var varMi = _timeLineRepoService.getTimeLine(room_id, userid, empid);

            //session update

            if (varMi == null)
            {
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                ViewData["roomid"] = room_id + userid + empid;
                ViewData["roomid2"] = room_id + empid + userid;
                ViewData["empId"] = empid;
                ViewData["userId"] = userid;


                return View();
            }

        }

        public ActionResult createRoom(string roomNumber, int cusId, int empId)
        {
            //Bu kısımda ki endTime ve Total Time görüşme kapandığında güncellenip hesaplanma yapılacaktır.
            try
            {
                TimeLine newCon = new TimeLine()
                {
                    CustomerID = cusId,
                    EmployeeID = empId,
                    StartTime = DateTime.Now,
                    Room = roomNumber,
                    EndTime = DateTime.Now,
                    TotalTime = DateTime.Now

                };
                _timeLineRepoService.addConversation(newCon);

            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            //_customerRepoService.decreaseBtPrice(20, cusId);
            return Json(roomNumber, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void decCreditForCalling(int? cusId,int? empid)
        {
            if (cusId==null || empid==null || empid==0 || cusId==0)
            {

            }
            else
            {
                _customerRepoService.decreaseBtPrice(5, (int)cusId);
                _cuspayment.addCusPay(5,cusId, empid);
            }
        }


        public ActionResult decreaseForGift(int? cusId, int? empid, int? crd)
        {
            if (cusId == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (crd==null || crd==0) { crd = 10;}  
                    try
                    {
                        _customerRepoService.decreaseBtPrice((int)crd, (int)cusId);

                        _cuspayment.addCusPay(crd, cusId, empid);

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
            }
        }


        public ActionResult empOrCus(string UserName)
        {
            if (UserName == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var EmpMi = _empRepository.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                var CusMi = _cusRepository.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                if (EmpMi != null)
                {
                    if (CusMi != null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {

                        return Json("emp", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    if (CusMi == null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("cus", JsonRequestBehavior.AllowGet);
                    }
                }

            }
        }



        public ActionResult getCredit(string UserName)
        {
            if (UserName == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var EmpMi = _empRepository.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                var CusMi = _cusRepository.GetAll().Where(x => x.UserName == UserName).SingleOrDefault();

                if (EmpMi != null)
                {
                    if (CusMi != null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        return Json(EmpMi, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    if (CusMi == null)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(CusMi, JsonRequestBehavior.AllowGet);
                    }
                }

            }
        }


        //Odadakileri meşgule çek
        [HttpPost]
        public void inRoomChangeStatus(int? CusID,int? EmpID)
        {
            if (CusID==null ||CusID==0 || EmpID ==0 || EmpID==null)
            {

            }
            else
            {
                _customerRepoService.changeStatus(3, CusID);
                _employeeRepoService.changeStatus(3, EmpID);
            }


        }


        //Odadan çıktığında Meşgule çek
        [HttpPost]
        public void fromRoomChangeStatus(int? CusID, int? EmpID)
        {

            if (CusID == null || CusID == 0 || EmpID == 0 || EmpID == null)
            {

            }
            else
            {
                _customerRepoService.changeStatus(1, CusID);
                _employeeRepoService.changeStatus(1, EmpID);
            }
        }

        [HttpPost]

        public ActionResult sameCredit(int? iconid,int? cr)
        {
            int[] credits = { 10, 20, 10, 15,20,20,10,30,40,30,40,50,10,40,10,70,40,30,70,30,10,30,100,100,70,100,200,170,150 };

            if (iconid == null || iconid==0 || cr==0 || cr==null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                if (iconid==1)
                {
                    if (cr==credits[0])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid==2)
                {
                    if (cr == credits[1])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid == 3)
                {
                    if (cr == credits[2])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid == 4)
                {
                    if (cr == credits[3])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 5)
                {
                    if (cr == credits[4])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 6)
                {
                    if (cr == credits[5])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 7)
                {
                    if (cr == credits[6])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 8)
                {
                    if (cr == credits[7])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 9)
                {
                    if (cr == credits[8])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 10)
                {
                    if (cr == credits[9])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 11)
                {
                    if (cr == credits[10])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 12)
                {
                    if (cr == credits[11])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 13)
                {
                    if (cr == credits[12])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 14)
                {
                    if (cr == credits[13])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 15)
                {
                    if (cr == credits[14])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 16)
                {
                    if (cr == credits[15])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 17)
                {
                    if (cr == credits[16])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 18)
                {
                    if (cr == credits[17])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 19)
                {
                    if (cr == credits[18])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 20)
                {
                    if (cr == credits[19])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                } else if (iconid == 21)
                {
                    if (cr == credits[20])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid == 22)
                {
                    if (cr == credits[21])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                else if (iconid == 23)
                {
                    if (cr == credits[22])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                else if (iconid == 24)
                {
                    if (cr == credits[23])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                else if (iconid == 25)
                {
                    if (cr == credits[24])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                else if (iconid == 26)
                {
                    if (cr == credits[25])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                else if (iconid == 27)
                {
                    if (cr == credits[26])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid == 28)
                {
                    if (cr == credits[27])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (iconid == 29)
                {
                    if (cr == credits[28])
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }


    }
}