using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFoodRest.Models
{
    public class ord
    {
        public string email { get; set; }
        public Errrror eer { get; set; }
       
    }

    public class Errrror
    {
        public string error { get; set; }
        public string message { get; set; }
        public string statuscode { get; set; }
        public bool status { get; set; }
    }


    //public class


    public class OrderGet
    {
        public string phone { get; set; }
        public string email { get; set; }
        public int order_id { get; set; }
        public Customer customer { get; set; }
        public Delivery delivery { get; set; }
        public string restaurant { get; set; }
        public string delivery_option { get; set; }
        public string pickup_date { get; set; }
        public string pickup_time { get; set; }
        public string delivery_address { get; set; }
        public string delivery_location { get; set; }
        public string delivery_city { get; set; }
        public string delivery_instruction { get; set; }
        public int delivery_amount { get; set; }
        public int is_corp { get; set; }
        public string payment_option { get; set; }
        public string payment_cash_comment { get; set; }
        public string order_comment { get; set; }
        public int charged_amount { get; set; }
        public bool statuss { get; set; }
        public string status { get; set; }
        public string promo_code { get; set; }
        public int check_order { get; set; }
        public string _id { get; set; }
        public Options[] options { get; set; }
        public Errors errors { get; set; }
        public Err er { get; set; }
    }

    public class Errors
    {
        public string error { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }

    public class Options
    {
        public string _id { get; set; }
        public string qty { get; set; }
        public string choice { get; set; }
        public object[] options { get; set; }
    }

    public class Customer
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Delivery
    {
        public string _id { get; set; }
        public string address { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string instruction { get; set; }

    }

    public class Err
    {
        public string error { get; set; }
        public string message { get; set; }
        public string statuscode { get; set; }

    }
}
















