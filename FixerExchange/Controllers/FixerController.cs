using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using FixerExchange.Utilities;

namespace FixerExchange.Controllers
{
    public class FixerController : ApiController

    {
        // GET: Fixer

        [System.Web.Http.Route("api/rates")]
        public string GetRatesByCurrency([FromUri] Rates rate)
        {
            string response = string.Empty;
            try
            {
                RateFactory concreteFactory = new ConcreteRateFactory();
                IRateFactory rateFactory = concreteFactory.GetRateProvider(rate.Provider);
                if(rateFactory!=null)
                {
                    response = rateFactory.GetRateValue(rate);
                }
                else
                {
                    response = "Invalid provider type";
                }
              
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }

        public string Index()
        {
            return "Home";
        }
    }
}