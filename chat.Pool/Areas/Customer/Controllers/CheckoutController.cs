using chat.CORE.Constants;
using chat.DATA.UnitofWork;
using chat.Pool.Models;
using chat.UTILITIES.SessionOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin;
using Newtonsoft.Json;
using Sipay;
using Sipay.Models;
using Sipay.Requests;
using Sipay.Responses;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using chat.Pool.Attribute;
using chat.SERVICES.Interfaces;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Customer;

namespace chat.Pool.Areas.Customer.Controllers
{
    [Auth]
    public class CheckoutController : BaseController
    {
        private EmpCusSessionContext _empcusSessionContext;
        private  IPaymentService _paymentService;
        private  ICustomerUserService _customerUserService;

        public CheckoutController(IUnitofWork uow,IPaymentService paymentService, ICustomerUserService customerUserService) : base(uow)
        {
            _empcusSessionContext = new EmpCusSessionContext();
            _paymentService = paymentService;
            _customerUserService = customerUserService;
        }

        // GET: Customer/Checkout
        //[HttpGet]
        //public ActionResult Index(string id)
        //{
 
        //    ViewData["id"] = id;
        //    var guid = Guid.NewGuid().ToString();
        //    ViewData["guid"] = guid;

        //    if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(guid))
        //    {
        //        TempData["mes"] = "Hata ile karşılaşıldı.";
        //        return RedirectToAction("PaymentToSystem", "CusPayment", new { area = "Customer" });
        //    }

        //    switch (id)
        //    {
        //        case "fbx37dsfd0":
        //            ViewData["id"] = 50;
        //            break;
        //        case "fbx44dsfd0":
        //            ViewData["id"] = 110;
        //            break;

        //        case "fbx36dsfd0":
        //            ViewData["id"] = 220;
        //            break;
        //        case "fbx348dsfd0":
        //            ViewData["id"] = 1000;
        //            break;
        //        case "fbx3258xı7sfd0":
        //            ViewData["id"] = 2000;
        //            break;
        //        default:
        //            ViewData["id"] = 50;
        //            break;
        //    }

        //    return View();
        //}

        
        //public ActionResult SendForm(System.Web.Mvc.FormCollection form)
        //{
        //    try
        //    {
        //    var paymentForm = GetPaymentInfo(form);
        //    int CustomerId;

        //    Settings settings = new Settings();

        //    settings.AppID = ConstantsInfo.AppID;
        //    settings.AppSecret = ConstantsInfo.AppSecret;
        //    settings.MerchantKey = ConstantsInfo.MerchantKey;
        //    settings.BaseUrl = ConstantsInfo.BaseUrl;

        //    Item product = new Item();
        //    product.Description = "";
        //    product.Name = "Test Product";
        //    product.Quantity = 1;
        //    product.Price = paymentForm.Amount;


        //    Sipay3DPaymentRequest paymentRequest = new Sipay3DPaymentRequest(settings, paymentForm.SelectedPosData);

        //    paymentRequest.CCNo = paymentForm.CreditCardNumber.Replace(" ", "");
        //    paymentRequest.CCHolderName = paymentForm.CreditCardName;
        //    paymentRequest.CCV = paymentForm.CreditCardCvv2;
        //    paymentRequest.ExpiryYear = paymentForm.CreditCardExpireYear.ToString();
        //    paymentRequest.ExpiryMonth = paymentForm.CreditCardExpireMonth.ToString();
        //    paymentRequest.InvoiceDescription = "";
        //    paymentRequest.InvoiceId = paymentForm.OrderId;

        //    paymentRequest.ReturnUrl = "https://localhost:44322/Customer/Checkout/SuccessUrl";
        //    paymentRequest.CancelUrl = "https://localhost:44322/Customer/Checkout/CancelUrl";

        //    paymentRequest.Items.Add(product);

        //    string requestForm = paymentRequest.GenerateFormHtmlToRedirect(ConstantsInfo.BaseUrl + "/api/pay3d");

        //    if (form["CustomerId"]!=null)
        //    {
        //        CustomerId = Int16.Parse(form["CustomerId"]);
        //    }
        //    else
        //    {
        //            TempData["mes"] = "Ödeme işlemi sırasında hata oluştu. Tekrar deneyip, aynı sonuç ile karşılaştığınızda sistem yöneticisi ile iletişime geçiniz.";
        //            return RedirectToAction("PaymentToSystem", "CusPayment", new { area = "Customer" });
        //        }

        //    PaymentDTO payment = new PaymentDTO()
        //    {
        //        CustomerId = CustomerId,
        //        OrderId = paymentForm.OrderId,
        //        PaymentDate = DateTime.Now,
        //        Price = paymentForm.Amount,
        //        Status = false
        //    };

        //    var sonuc = _paymentService.insertPayment(payment);

        //    if (sonuc==true)
        //    {
        //         return View("~/Areas/Customer/Views/Checkout/SendForm.cshtml", model: requestForm);
        //    }
        //    else
        //    {
        //            TempData["mes"] = "Ödeme işlemi sırasında hata oluştu. Tekrar deneyip, aynı sonuç ile karşılaştığınızda sistem yöneticisi ile iletişime geçiniz.";
        //            return RedirectToAction("PaymentToSystem", "CusPayment", new { area = "Customer" });
        //        }
        //    }
        //    catch (Exception _ex)
        //    {
        //        var err = _ex;
        //        TempData["mes"] = "Ödeme işlemi sırasında hata oluştu. Tekrar deneyip, aynı sonuç ile karşılaştığınızda sistem yöneticisi ile iletişime geçiniz.";
        //        return RedirectToAction("PaymentToSystem", "CusPayment",new { area="Customer" });
        //    }
        //}

        //public ActionResult SuccessUrl()
        //{
        //    try
        //    {
        //        string sipay_status = HttpContext.Request.QueryString["sipay_status"];
        //        string order_no = HttpContext.Request.QueryString["order_no"];
        //        string invoice_id = HttpContext.Request.QueryString["invoice_id"];
        //        var paymentData = _paymentService.getPayment(invoice_id);

        //        if (paymentData == null)
        //        {
        //            TempData["mes"] = "Ödeme işlemi sırasında hata oluştu. Kredi için sistem yöneticisi ile iletişim kurunuz.";
        //            return RedirectToAction("PaymentToSystem", "CusPayment", new { area = "Customer" });
        //        }
        //        else
        //        {
        //            int newPrice = 0;

        //            switch (paymentData.Price)
        //            {
        //                case 50:
        //                    newPrice = 100;
        //                    break;
        //                case 110:
        //                    newPrice = 250;
        //                    break;
        //                case 220:
        //                    newPrice = 500;
        //                    break;
        //                case 400:
        //                    newPrice = 1000;
        //                    break;
        //                case 2000:
        //                    newPrice = 5000;
        //                    break;
        //                default:

        //                    break;
        //            }

        //            var sonuc = _customerUserService.addBtPrice(paymentData.CustomerId, newPrice);

        //            if (sonuc == true)
        //            {
        //                PaymentDTO updData = new PaymentDTO()
        //                {
        //                    ID = paymentData.ID,
        //                    CustomerId = paymentData.CustomerId,
        //                    OrderId = paymentData.OrderId,
        //                    PaymentDate = paymentData.PaymentDate,
        //                    Price = paymentData.Price,
        //                    Status = true

        //                };
        //                _paymentService.updatePayment(updData);
        //            }
        //            else
        //            {

        //            }
        //        }
        //        string status_description = HttpContext.Request.QueryString["status_description"];
        //        string sipay_payment_method = HttpContext.Request.QueryString["sipay_payment_method"];

        //        string fullQuery = " invoice_id : " + invoice_id
        //             + "sipay_status :" + sipay_status + "order_no :" + order_no + "status_description :" + status_description
        //             + "sipay_payment_method :" + sipay_payment_method;

        //        ViewBag.SuccessMessage = fullQuery;
        //    }
        //    catch (Exception)
        //    {
        //        TempData["SucButNotAdd"] = "Sistemsel bir sıkıntı ile karşılaştıysanız yönetici ile iletişime geçin.";
        //        return View();
        //    }


        //    return View();
        //}

        //public ActionResult CancelUrl()
        //{
        //    string error_code = HttpContext.Request.QueryString["error-code"];
        //    string error = HttpContext.Request.QueryString["error"];
        //    string invoice_id = HttpContext.Request.QueryString["invoice_id"];

        //    string sipay_status = HttpContext.Request.QueryString["sipay_status"];
        //    string order_no = HttpContext.Request.QueryString["order_no"];
        //    string status_description = HttpContext.Request.QueryString["status_description"];
        //    string sipay_payment_method = HttpContext.Request.QueryString["sipay_payment_method"];

        //    string fullQuery = "error_code : " + error_code + " invoice_id : " + invoice_id + " error : " + error
        //         + "sipay_status :" + sipay_status + "order_no :" + order_no + "status_description :" + status_description
        //         + "sipay_payment_method :" + sipay_payment_method;
             
        //    ViewBag.Error = fullQuery;

            

        //    return View();
        //}
        //public PaymentModel GetPaymentInfo(System.Web.Mvc.FormCollection form)
        //{
        //    var paymentInfo = new PaymentModel();

        //    paymentInfo.CreditCardType = form["CreditCardType"];
        //    paymentInfo.CreditCardName = form["CardholderName"];

        //    if (!String.IsNullOrEmpty(form["card-number"]))
        //    {
        //        paymentInfo.CreditCardNumber = form["card-number"];
        //    }
        //    if (!String.IsNullOrEmpty(form["ExpireMonth"]))
        //    {
        //        paymentInfo.CreditCardExpireMonth = int.Parse(form["ExpireMonth"]);
        //    }
        //    if (!String.IsNullOrEmpty(form["ExpireYear"]))
        //    {
        //        paymentInfo.CreditCardExpireYear = int.Parse(form["ExpireYear"]);
        //    }

        //    if (!String.IsNullOrEmpty(form["Amount"]))
        //    {
        //        paymentInfo.Amount = decimal.Parse(form["Amount"]);
        //    }

        //    if (!String.IsNullOrEmpty(form["OrderId"]))
        //    {
        //        paymentInfo.OrderId = form["OrderId"];
        //    }
        //    paymentInfo.CreditCardCvv2 = form["CardCode"];

        //    if (!String.IsNullOrEmpty(form["SelectedPosData"]))
        //    {
        //        var posData = form["SelectedPosData"];

        //        paymentInfo.SelectedPosData = JsonConvert.DeserializeObject<PosData>(form["SelectedPosData"]);
        //    }

        //    if (!String.IsNullOrEmpty(form["Is3D"]))
        //    {
        //        paymentInfo.Is3D = (PaymentType)(Int32.TryParse(form["Is3D"], out int is3D) ? is3D : 0);

        //    }

        //    return paymentInfo;
        //}
        
        //public ActionResult CheckBinCode(string binCode, decimal amount, bool isRecurring)
        //{
        //    object result;
        //    if (binCode.Length >= 6)
        //    {
        //        Settings settings = new Settings();

        //        settings.AppID = ConstantsInfo.AppID;
        //        settings.AppSecret = ConstantsInfo.AppSecret;
        //        settings.MerchantKey = ConstantsInfo.MerchantKey;
        //        settings.BaseUrl = ConstantsInfo.BaseUrl;

        //        SipayGetPosRequest posRequest = new SipayGetPosRequest();

        //        posRequest.CreditCardNo = binCode;
        //        posRequest.Amount = amount;
        //        posRequest.CurrencyCode = "TRY";
        

        //        posRequest.IsRecurring = isRecurring;

        //        SipayGetPosResponse posResponse = SipayPaymentService.GetPos(posRequest, settings, GetAuthorizationToken(settings).Data.token);

        //        //GEÇİCİ

        //        for (int i = 0; i < posResponse.Data.Count; i++)
        //        {
        //            posResponse.Data[i].amount_to_be_paid = posResponse.Data[i].amount_to_be_paid + (i * 0.1M);
        //        }

        //         result = new { posResponse = posResponse, is_3d = GetAuthorizationToken(settings).Data.is_3d };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(false, JsonRequestBehavior.AllowGet);

        //}

        //public SipayTokenResponse GetAuthorizationToken(Settings settings)
        //{
        //    if (((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).Token == null)
        //    {
        //        SipayTokenResponse tokenResponse = SipayPaymentService.CreateToken(settings);

        //        _empcusSessionContext.Token = tokenResponse;

        //        Session["EmpCusSessionContext"] = _empcusSessionContext;
        //    }

        //    return ((chat.UTILITIES.SessionOperations.EmpCusSessionContext)Session["EmpCusSessionContext"]).Token;
        //}

    }
}