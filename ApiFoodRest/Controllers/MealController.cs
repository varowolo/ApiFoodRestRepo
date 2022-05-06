using ApiFoodRest.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiFoodRest.Controllers
{
    public class MealController : ApiController
    {
        //string Baseurl = " https://food-server.nairabox.com";

        private string authHdr = System.Configuration.ConfigurationManager.AppSettings["AuthHdrKey"];
        private string Baseurl = System.Configuration.ConfigurationManager.AppSettings["Baseurl"];

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public async Task<object> getAllMeals()
        {
            List<object> MealsInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer 12345");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage Res = await client.GetAsync("api/external/meal");
                //Storing the response Detail received from the web api
                var mealsResponse = Res.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + mealsResponse + Environment.NewLine + DateTime.Now);
                    if (Res.IsSuccessStatusCode)
                    {

                        //Deserializing the response received from web api and storing it into the Food List
                        MealsInfo = JsonConvert.DeserializeObject<List<object>>(mealsResponse);
                        //return (MealsInfo);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        MealsInfo.Add(fde);
                        //logger.Info("Response: " + " balance: " + "category:" + " id: " + " name: " + " restaurant: " + " choice: " + " options: " + foodError.balance + " -- " + foodError.category + "---" + foodError._id + "---" + foodError.name + "----" + foodError.restaurant + "--" + foodError.choice + "--" + "options" + Environment.NewLine + DateTime.Now);


                    }


                    else if (Res.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }
                    else if (Res.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }


                    else if (Res.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }

                    else if (Res.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(mealsResponse);
                        foodError.status = "false";
                    }
                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);

                }
                if (errors != null) return errors;
                return (MealsInfo);
            }


        }
        // [Authorize]
        [Route("api/Meal/MealCategory")]
        public async Task<object> getMealByCategory() 
        {
            List<object> catInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage rep = await client.GetAsync("api/external/mealByCategory/5c8a20f4da5a0f0ac24dfd6c");
                var catResponse = rep.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + catResponse + Environment.NewLine + DateTime.Now);
                    if (rep.IsSuccessStatusCode)
                    {

                        catInfo = JsonConvert.DeserializeObject<List<object>>(catResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        catInfo.Add(fde);
                    }
                    else if (rep.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }
                    else if (rep.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }


                    else if (rep.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                    else if (rep.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(catResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (catInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/Restaurant")]
        public async Task<object> GetmealByRestaurant()
        {
            List<object> restInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage ret = await client.GetAsync("api/external/mealByRestaurant/5c92f7e961d6604250824d4f");
                var restResponse = ret.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + restResponse + Environment.NewLine + DateTime.Now);
                    if (ret.IsSuccessStatusCode)
                    {

                        restInfo = JsonConvert.DeserializeObject<List<object>>(restResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        restInfo.Add(fde);
                    }
                    else if (ret.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }
                    else if (ret.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }


                    else if (ret.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                    else if (ret.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(restResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return restInfo;
            }
        }

        // [Authorize]
        [Route("api/Meal/Category")]
        public async Task<object> getmealCategorys()
        {
            List<object> caterInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage cate = await client.GetAsync("api/external/mealcategory");
                var categResponse = cate.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + categResponse + Environment.NewLine + DateTime.Now);

                    if (cate.IsSuccessStatusCode)
                    {
                        caterInfo = JsonConvert.DeserializeObject<List<object>>(categResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        caterInfo.Add(fde);
                    }

                    else if (cate.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }
                    else if (cate.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }


                    else if (cate.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                    else if (cate.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(categResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {

                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (caterInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/allRest")]
        public async Task<object> getAll()
        {
            List<object> FooInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage bes = await client.GetAsync("api/external/restaurant/");
                var besResponse = bes.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + besResponse + Environment.NewLine + DateTime.Now);
                    if (bes.IsSuccessStatusCode)
                    {
                        FooInfo = JsonConvert.DeserializeObject<List<object>>(besResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        FooInfo.Add(fde);
                    }

                    else if (bes.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }
                    else if (bes.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }


                    else if (bes.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                    else if (bes.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(besResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {

                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (FooInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/Featured")]
        public async Task<object> getFeatured()
        {
            List<object> RetInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage tes = await client.GetAsync("api/external/restaurantByFeatured/5");
                var tesResponse = tes.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + tesResponse + Environment.NewLine + DateTime.Now);
                    if (tes.IsSuccessStatusCode)
                    {

                        RetInfo = JsonConvert.DeserializeObject<List<object>>(tesResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        RetInfo.Add(fde);
                    }
                    else if (tes.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }
                    else if (tes.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }


                    else if (tes.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                    else if (tes.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(tesResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (RetInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/OneByID")]
        public async Task<object> getOneById()
        {
            List<object> eetInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage yes = await client.GetAsync("api/external/restaurant/5c92f7e961d6604250824d33");
                var yesResponse = yes.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + yesResponse + Environment.NewLine + DateTime.Now);
                    if (yes.IsSuccessStatusCode)
                    {

                        eetInfo = JsonConvert.DeserializeObject<List<object>>(yesResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";

                    }

                    else if (yes.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }
                    else if (yes.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }


                    else if (yes.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";

                    }

                    else if (yes.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                    else if (yes.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(yesResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);

                }
                if (errors != null) return errors;
                return (eetInfo);

            }
        }

        // [Authorize]
        [Route("api/Meal/Location")]
        public async Task<object> getByLocation()
        {
            List<object> beetInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage bet = await client.GetAsync("api/external/restaurantBylocation/5c92c20f3e45e118c8fb72a7");
                var betResponse = bet.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + betResponse + Environment.NewLine + DateTime.Now);
                    if (bet.IsSuccessStatusCode)
                    {

                        beetInfo = JsonConvert.DeserializeObject<List<object>>(betResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        beetInfo.Add(fde);
                    }

                    else if (bet.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = ("false");
                    }

                    else if (bet.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }
                    else if (bet.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }


                    else if (bet.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                    else if (bet.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(betResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {

                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (beetInfo);
            }
        }


        // [Authorize]
        [Route("api/Meal/Cuisine")]
        public async Task<object> getcuisine()
        {
            List<object> cusInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage cet = await client.GetAsync("api/external/cuisine");
                var cetResponse = cet.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + cetResponse + Environment.NewLine + DateTime.Now);
                    if (cet.IsSuccessStatusCode)
                    {

                        cusInfo = JsonConvert.DeserializeObject<List<object>>(cetResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        cusInfo.Add(fde);

                    }

                    else if (cet.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }
                    else if (cet.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }


                    else if (cet.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                    else if (cet.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(cetResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (cusInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/Choice")]
        public async Task<object> getselectChoice()
        {
            List<object> sesInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage ses = await client.GetAsync("api/external/selectChoice");
                var sesResponse = ses.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + sesResponse + Environment.NewLine + DateTime.Now);
                    if (ses.IsSuccessStatusCode)
                    {

                        sesInfo = JsonConvert.DeserializeObject<List<object>>(sesResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        sesInfo.Add(fde);
                    }

                    else if (ses.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }
                    else if (ses.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }


                    else if (ses.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                    else if (ses.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(sesResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (sesInfo);
            }
        }


        // [Authorize]
        [Route("api/Meal/City")]
        public async Task<object> getcity()
        {
            List<object> citInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage cit = await client.GetAsync("api/external/city");
                var citResponse = cit.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + citResponse + Environment.NewLine + DateTime.Now);
                    if (cit.IsSuccessStatusCode)
                    {

                        citInfo = JsonConvert.DeserializeObject<List<object>>(citResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        citInfo.Add(fde);
                    }
                    else if (cit.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }
                    else if (cit.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }


                    else if (cit.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (cit.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "02";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (citInfo);
            }
        }

        //[Authorize]
        [Route("api/Meal/allLocation")]
        public async Task<object> getallLocations()
        {
            List<object> locInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage loc = await client.GetAsync("api/external/location");
                var citResponse = loc.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + citResponse + Environment.NewLine + DateTime.Now);
                    if (loc.IsSuccessStatusCode)
                    {

                        locInfo = JsonConvert.DeserializeObject<List<object>>(citResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        locInfo.Add(fde);
                    }

                    else if (loc.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }
                    else if (loc.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }


                    else if (loc.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (loc.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {

                    foodError.statuscode = "01";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return locInfo;
            }
        }


        // [Authorize]
        [Route("api/Meal/LocByCity")]
        public async Task<object> getlocationByCity()
        {
            List<object> lbcInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage lbc = await client.GetAsync("api/external/locationByCity/5c77b818c69bb473a5251a6b");
                var citResponse = lbc.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + citResponse + Environment.NewLine + DateTime.Now);
                    if (lbc.IsSuccessStatusCode)
                    {

                        lbcInfo = JsonConvert.DeserializeObject<List<object>>(citResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        lbcInfo.Add(fde);
                    }

                    else if (lbc.StatusCode == HttpStatusCode.BadRequest)
                    {

                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }
                    else if (lbc.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }


                    else if (lbc.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                    else if (lbc.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(citResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {

                    foodError.statuscode = "01";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return lbcInfo;
            }
        }

        //[Authorize]
        [Route("api/Meal/Singleid")]
        public async Task<object> getSingleById()
        {
            List<object> wbcInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage wbc = await client.GetAsync("api/external/order/details/12343");
                var wbcResponse = wbc.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + wbcResponse + Environment.NewLine + DateTime.Now);
                    if (wbc.IsSuccessStatusCode)
                    {

                        wbcInfo = JsonConvert.DeserializeObject<List<object>>(wbcResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        wbcInfo.Add(fde);

                    }
                    else if (wbc.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }
                    else if (wbc.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }


                    else if (wbc.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "01";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (wbcInfo);
            }
        }

        // [Authorize]
        [Route("api/Meal/Listid")]
        public async Task<object> getListSingleById()
        {
            List<object> wbccInfo = new List<object>();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage wbcc = await client.GetAsync("api/external/order/list/12343");
                var wbcResponse = wbcc.Content.ReadAsStringAsync().Result;
                try
                {
                    logger.Info("Response: " + wbcResponse + Environment.NewLine + DateTime.Now);
                    if (wbcc.IsSuccessStatusCode)
                    {

                        wbccInfo = JsonConvert.DeserializeObject<List<object>>(wbcResponse);
                        Food fde = new Food();
                        fde.statuscode = "200";
                        fde.status = "Ok";
                        wbccInfo.Add(fde);
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }
                    else if (wbcc.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }


                    else if (wbcc.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbcc.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                }
                catch (Exception ex)
                {
                    foodError.statuscode = "01";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (wbccInfo);
            }
        }


        //[Authorize]
        [Route("api/Meal/Walbal")]
        public async Task<object> getwalletBalance()
        {
            Food fd = new Food();
            Food foodError = new Food();
            Error errors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                HttpResponseMessage wbc = await client.GetAsync("/api/external/balance");
                var wbcResponse = wbc.Content.ReadAsStringAsync().Result;

                try
                {
                    logger.Info("Response: " + " balance: " + wbcResponse + " -- " + Environment.NewLine + DateTime.Now);
                    if (wbc.IsSuccessStatusCode)
                    {
                        wbcResponse = wbc.Content.ReadAsStringAsync().Result;


                    }

                    else if (wbc.StatusCode == HttpStatusCode.BadGateway)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.BadRequest)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.NotFound)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Forbidden)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }
                    else if (wbc.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.NotImplemented)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.NoContent)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }

                    else if (wbc.StatusCode == HttpStatusCode.Conflict)
                    {
                        errors = JsonConvert.DeserializeObject<Error>(wbcResponse);
                        foodError.status = "false";
                    }


                }
                catch (Exception ex)
                {
                    foodError.statuscode = "01";
                    logger.Error(ex, "Something went wrong!. -- " + ex.Message);
                }
                if (errors != null) return errors;
                return (wbcResponse);
            }
        }


        [HttpPost]
        [Route("api/Meal/PostPlaceOrder")]
        public async Task<object> Postppp(OrderGet bug)
        {
            object wbcInfo = null;
            OrderGet foodError = new OrderGet();
            OrderGet fde = new OrderGet();
            OrderGet od = bug;
            Errors errors = null;
            Err er = null;
            Boolean statuss = true;

            if (String.IsNullOrEmpty(od.email))
            {
                er.statuscode = "99";
                er.message = "Invalid email address";
                statuss = false;

            }


            if (od.phone.Length == 11)
            {
                er.statuscode = "99";
                er.message = "Invalid phone";
                statuss = false;

            }
            else if (String.IsNullOrEmpty(od.order_id.ToString()))
            {
                er.statuscode = "99";
                er.message = "Invalid order id";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.restaurant))
            {
                er.statuscode = "99";
                er.message = "invalid restaurant";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_option))
            {
                er.statuscode = "99";
                er.message = "invalid delivery option";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.pickup_date))
            {
                try
                {
                    DateTime dat = Convert.ToDateTime(od.pickup_date);
                }

                catch (Exception ex)
                {

                    er.statuscode = "99";
                    er.message = "Invalid date";
                    statuss = false;
                    return er;

                }

                er.statuscode = "99";
                er.message = "empty date";
                statuss = false;

            }
            else if (String.IsNullOrEmpty(od.pickup_time))
            {
                try
                {
                    DateTime time = DateTime.Parse(od.pickup_time);
                }

                catch (Exception ex)
                {
                    er.statuscode = "99";
                    er.message = "Invalid date";
                    statuss = false;
                    return er;
                }
                er.statuscode = "99";
                er.message = "Invalid time";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_address))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_location))
            {
                er.statuscode = "99";
                er.message = "Invalid location";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_city))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_instruction))
            {
                er.statuscode = "99";
                er.message = "Invalid instruction";
                statuss = false;
            }
            else if (od.delivery_amount <= 0)
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (od.is_corp != 0)
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.payment_option))
            {
                er.statuscode = "99";
                er.message = "Invalid payment option";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.delivery_address))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.options[0]._id))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.options[0].qty))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            else if (String.IsNullOrEmpty(od.options[0].choice))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
            }
            else if (String.IsNullOrEmpty(od.options[0]._id))
            {
                er.statuscode = "99";
                er.message = "Invalid address";
                statuss = false;
            }
            //else if (od.options[0].options.Length == 0)
            //{
            //    er.statuscode = "99";
            //    er.message = "Invalid address";
            //    statuss = false;
            //}

            else
                 {
                 statuss = true;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                    HttpResponseMessage orb = await client.PostAsJsonAsync("api/external/order/placeorder", bug);
                    var orbResponse = orb.Content.ReadAsStringAsync().Result;
                    try
                    {
                        logger.Info("Response: " + orbResponse + Environment.NewLine + DateTime.Now);
                        if (orb.IsSuccessStatusCode)
                        {

                            wbcInfo = JsonConvert.DeserializeObject<object>(orbResponse);

                        }

                        else if (orb.StatusCode == HttpStatusCode.BadRequest)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            fde.status = "false";
                        }

                        else if (orb.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            fde.status = "false";

                        }

                        else if (orb.StatusCode == HttpStatusCode.NotImplemented)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            fde.status = "false";

                        }

                        else if (orb.StatusCode == HttpStatusCode.BadGateway)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            fde.status = "false";

                        }
                        else if (orb.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            foodError.status = "false";
                        }

                        else if (orb.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orbResponse);
                            foodError.status = "false";
                        }

                    }
                    catch (Exception ex)
                    {
                        fde.status = "400";
                        logger.Error(ex, "Bad Request", ex);
                    }
                }
                if (errors != null) return errors;
                else return wbcInfo;
            }
            if (statuss)
                return wbcInfo;
            else return er;
        }


        [HttpPost]
        [Route("api/Meal/PostGetOrders")]
        public async Task<object> Post(ord pug)
        {

            object ordInfo = null;
            Food foodError = new Food();
            Food fde = new Food();
            ord ob = pug;
            Errors errors = null;
            Errrror eer = null;
            Boolean status = true;

            if (String.IsNullOrEmpty(ob.email))
            {
                eer.statuscode = "99";
                eer.message = "Invalid email address";
                eer.status = false;

            }
            else
            {
                status = true;
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + authHdr);
                    HttpResponseMessage ors = await client.PostAsJsonAsync("api/external/order/get", pug);
                    var orsResponse = ors.Content.ReadAsStringAsync().Result;
                    try
                    {
                        logger.Info("Response: " + orsResponse + Environment.NewLine + DateTime.Now);
                        if (ors.IsSuccessStatusCode)
                        {
                            ordInfo = JsonConvert.DeserializeObject<object>(orsResponse);
                        }

                        else if (ors.StatusCode == HttpStatusCode.BadRequest)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            fde.status = "false";
                        }

                        else if (ors.StatusCode == HttpStatusCode.InternalServerError)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            fde.status = "false";

                        }

                        else if (ors.StatusCode == HttpStatusCode.NotImplemented)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            fde.status = "false";

                        }

                        else if (ors.StatusCode == HttpStatusCode.BadGateway)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            fde.status = "false";

                        }
                        else if (ors.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            foodError.status = "false";
                        }

                        else if (ors.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            errors = JsonConvert.DeserializeObject<Errors>(orsResponse);
                            foodError.status = "false";
                        }

                    }
                    catch (Exception ex)
                    {
                        ordInfo = ex;
                        fde.status = "400";
                        logger.Error(ex, "Bad Request", ex);
                    }

                    if (errors != null) return errors;
                    else   return ordInfo;
                }
              
            }
            if (status)
                return ordInfo;
            else return eer;
        }
    }
}


//C:\FoodApiLogs\RequestLogs/${date:format=yyyy-MM-dd}-api.log

//<target name = "logfile" xsi:type="File" fileName="${basedir}/Mylogs/${date:format=yyyy-MM-dd}.log"
//    layout="${level} (${longdate})  ${newline} ${newline}
//    Call Site: ${callsite} ${newline} 
//    Exception Type:${exception:format=Type}${newline}
//    Exception message:${exception:format=ToString,StackTrace}${newline} 
//    Stack Trace:${exception:format=Trace}${newline}  
//    Additional Info:${message} ${newline}" />

//<logger name = "*" minlevel="Trace" writeTo="logfile" />



//C:\FoodApiLogs\RequestLogs/${date:format=yyyy-MM-dd}-api.log




