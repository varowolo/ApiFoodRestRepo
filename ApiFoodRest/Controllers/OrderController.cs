using ApiFoodRest.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiFoodRest.Controllers
{
    public class OrderController : ApiController
    {
        ////string Baseurl = " https://food-server.nairabox.com";





        ////[HttpPost]
        ////[Route("api/Order/place")]
        ////public async Task<Ord> HttpPostplaceOrder(string email, string phone)
        ////{
        ////    Ord oo = new Ord();
        ////    using (var client = new HttpClient())
        ////    {
        ////        client.BaseAddress = new Uri(Baseurl);
        ////        client.DefaultRequestHeaders.Clear();
        ////        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        ////        client.DefaultRequestHeaders.Add("Authorization", "Bearer 12345");
        ////        HttpResponseMessage rsp = await client.PostAsJsonAsync("api/external/order/placeorder", new Ord { email = "femilsola@nairabox.com", phone = "090664897896", });

        ////        if (rsp.IsSuccessStatusCode)
        ////        {
        ////            var abcResponse = rsp.Content.ReadAsStringAsync().Result;
        ////            oo = JsonConvert.DeserializeObject<Ord>(abcResponse);
        ////        }

        ////        return (oo);
        ////    }

        ////}







        ////HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(TransFastFailureFeedBackEndPoint);
        ////webrequest.Headers.Add("Authorization", Token);
        ////        webrequest.Method = "POST";
        ////        string postData = "{\n \"tfPin\""" + TfPin + "\",\"ErrorCode\": \"" + ErrorCode + "\",\"Description\": \"" + Description + "\"}";
        ////        webrequest.ContentType = "application/json";
        ////        webrequest.ContentLength = postData.Length;

    }
    }

