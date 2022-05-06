using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFoodRest.Models
{

    public class MealsInfo
    {
        public Food[] NairaFood { get; set; }
    }

    public class Food
    {

        public object[] options { get; set; }
        public string status { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public City city_id { get; set; }
        public  Geo geo { get; set; }
        public Category category { get; set; }
        public Restaurant restaurant { get; set; }
        public string location_type { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int __v { get; set; }
        public string pack { get; set; }
        public int sorts { get; set; }
        public Choice choice { get; set; }
        public string balance { get; set; }
        public object[] pack_fee { get; set; }
       // public string error { get; set; }
        public Error errors { get; set; }
        public string statuscode { get; set; }
        public string code { get; set; }
        public OrderGet wbcInfo { get; set; }
    }


    public class Error
    {
        public string error { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }

    public class Category
    {
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class Restaurant
    {
        public bool status { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
    }

    public class Choice
    {
        public string[] choices { get; set; }
        public string _id { get; set; }
    }

    public class City
    {
      public string _id { get; set; }
      public string name { get; set; }
    }

    public class Geo
    {
        public string formatted { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public string place_id { get; set; } 

    }
   

 

}