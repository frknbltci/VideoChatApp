using Newtonsoft.Json;
using Sipay.Helpers;
using Sipay.Models;
using Sipay.Requests;
using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sipay
{
    public class SipayPaymentService
    {

//        private static readonly HttpClient _httpClient;
//        static SipayPaymentService()
//        {
//#if !NETSTANDARD
//            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//#endif

//            _httpClient = new HttpClient();
//        }

//        public static SipayTokenResponse CreateToken(Settings settings)
//        {
//            SipayTokenRequest tokenRequest = new SipayTokenRequest();
//            tokenRequest.AppID = settings.AppID;
//            tokenRequest.AppSecret = settings.AppSecret;

//            SipayTokenResponse response = PostDataAsync<SipayTokenResponse, SipayTokenRequest>(settings.BaseUrl + "/api/token", tokenRequest);
//            return response;
//        }

//        public static SipayGetPosResponse GetPos(SipayGetPosRequest request, Settings settings, string token)
//        {
//            request.MerchantKey = settings.MerchantKey;
//            var header = new Dictionary<string, string>();
//            header.Add("Authorization", "Bearer " + token);

//            SipayGetPosResponse response = PostDataAsync<SipayGetPosResponse, SipayGetPosRequest>(settings.BaseUrl + "/api/getpos", request, header);

//            return response;
//        }

//        public static SipayPaymentResponse Pay(SipayPaymentRequest request, Settings settings, string token)
//        {
//            var header = new Dictionary<string, string>();
//            header.Add("Authorization", "Bearer " + token);

//            SipayPaymentResponse response = PostDataAsync<SipayPaymentResponse, SipayPaymentRequest>(settings.BaseUrl + "/api/pay", request, header);

//            return response;
//        }

//        public static SipayBrandedPaymentResponse BrandedPay(SipayBrandedPaymentRequest request, Settings settings)
//        {
//            var formDatas = new Dictionary<string, string>();
//            formDatas.Add("currency_code", request.currency_code);
//            formDatas.Add("invoice", JsonBuilder.SerializeToJsonString<Invoice>(request.invoice).ToString().Trim());
//            formDatas.Add("merchant_key", request._settings.MerchantKey);
//            formDatas.Add("name", request.name);
//            formDatas.Add("surname", request.surname);

//            SipayBrandedPaymentResponse response = PostUrlEncodedDataAsync<SipayBrandedPaymentResponse>(settings.BaseUrl + "/purchase/link", formDatas);

//            return response;
//        }

//        public static SipayGetOrderStatusResponse GetOrderStatus(SipayGetOrderStatusRequest request, Settings settings)
//        {
//            var formDatas = new Dictionary<string, string>();
//            formDatas.Add("merchant_key", request._settings.MerchantKey);
//            formDatas.Add("invoice_id", request.invoice_id);

//            SipayGetOrderStatusResponse response = PostUrlEncodedDataAsync<SipayGetOrderStatusResponse>(settings.BaseUrl + "/purchase/status", formDatas);

//            return response;
//        }

//        public static SipayRefundResponse Refund(SipayRefundRequest request, Settings settings, string token)
//        {
//            var header = new Dictionary<string, string>();
//            header.Add("Authorization", "Bearer " + token);

//            SipayRefundResponse response = PostDataAsync<SipayRefundResponse, SipayRefundRequest>(settings.BaseUrl + "/api/refund", request, header);

//            return response;
//        }

        //public static Sipay3DPayResponse Initialize3DPay(Sipay3DPaymentRequest request, Settings settings)
        //{

        //    //var header = new Dictionary<string, string>();
        //    //header.Add("Authorization", "Bearer " + token);

        //    SipayGetPosResponse response = PostDataAsync<Sipay3DPayResponse, Sipay3DPaymentRequest>(settings.BaseUrl + "/getpos", request);

        //    return response;
        //}


        //public static Response PostDataAsync<Response, Request>(string endPoint, Request dto, Dictionary<string, string> headers = null)
        //{

        //    HttpRequestMessage requestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(endPoint),
        //        Content = JsonBuilder.ToJsonString<Request>(dto)
        //    };

        //    if (headers != null)
        //    {
        //        foreach (var header in headers)
        //        {
        //            requestMessage.Headers.Add(header.Key, header.Value);
        //        }
        //    }

        //    var httpResponse = _httpClient.SendAsync(requestMessage).Result;

        //    // GEÇİCİ
        //    var t = httpResponse.Content.ReadAsStringAsync().Result;

        //    if (!httpResponse.IsSuccessStatusCode)
        //    {
        //        return default;
        //    }


        //    return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        //}

        //public static Response GetDataAsync<Response>(string endPoint)
        //{
        //    var httpResponse = _httpClient.GetAsync(endPoint).Result;

        //    if (!httpResponse.IsSuccessStatusCode)
        //    {
        //        return default;
        //    }

        //    return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        //}

        //public static Response PostUrlEncodedDataAsync<Response>(string endPoint, Dictionary<string, string> formDatas = null, Dictionary<string, string> headers = null)
        //{

        //    HttpRequestMessage requestMessage = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri(endPoint),
        //        Content = new FormUrlEncodedContent(formDatas)
        //    };

        //    if (headers != null)
        //    {
        //        foreach (var header in headers)
        //        {
        //            requestMessage.Headers.Add(header.Key, header.Value);
        //        }
        //    }

        //    var httpResponse = _httpClient.SendAsync(requestMessage).Result;

        //    // GEÇİCİ
        //    var t = httpResponse.Content.ReadAsStringAsync().Result;

        //    if (!httpResponse.IsSuccessStatusCode)
        //    {
        //        return default;
        //    }


        //    return JsonConvert.DeserializeObject<Response>(httpResponse.Content.ReadAsStringAsync().Result);
        //}


    }
}
