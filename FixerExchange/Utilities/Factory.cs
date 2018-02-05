using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FixerExchange.Utilities
{
    public interface IRateFactory
    {
        object GetRateValue(Rates inputRates);
    }

    public abstract class RateFactory
    {
        public abstract IRateFactory GetRateProvider(string provider);
    }

    public class ConcreteRateFactory : RateFactory
    {
        public override IRateFactory GetRateProvider(string provider)
        {
            switch (provider.ToUpper())
            {
                case "FIXER": return new Fixer();
                case "CURRENCYLAYER": return new CurrencyLayer();
                case "CURRENCYCONVERTERAPI": return new CurrencyConverterAPI();
                default: return null;
            }
        }
    }

    public class Fixer : IRateFactory
    {
        public object GetRateValue(Rates inputRates)
        {
            object response = string.Empty;
            try
            {
                Rates rateValues = ConfigManager.GetRatesInstance(inputRates);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigManager.GetConfigValue(rateValues.Provider));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = client.GetAsync("latest?base=" + rateValues.Fr + "&symbols=" + rateValues.To + "").Result;  // Blocking call 
                if (apiResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = apiResponse.Content.ReadAsStringAsync().Result;
                    if (rateValues.Format == "JSON")
                    {
                        response = jsonResponse;
                    }
                    else
                    {
                        var data = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                        response = data.Last.First.First.Last.Value<object>();
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }
    }

    public class CurrencyLayer : IRateFactory
    {
        public object GetRateValue(Rates inputRates)
        {
            object response = string.Empty;
            try
            {
                Rates rateValues = ConfigManager.GetRatesInstance(inputRates);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigManager.GetConfigValue(rateValues.Provider));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //currencylayer only supports USD as the source/from currency
                HttpResponseMessage apiResponse = client.GetAsync("api/live?" + "access_key=" + rateValues.ApiKey + "&currencies=" + rateValues.To).Result;  // Blocking call 
                if (apiResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = apiResponse.Content.ReadAsStringAsync().Result;
                    if (rateValues.Format == "JSON")
                    {
                        response = jsonResponse;
                    }
                    else
                    {
                        var data = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                        response = data.Last.First.First.Last.Value<object>();
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }
    }

    public class CurrencyConverterAPI : IRateFactory
    {
        public object GetRateValue(Rates inputRates)
        {
            object response = string.Empty;
            try
            {
                Rates rateValues = ConfigManager.GetRatesInstance(inputRates);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigManager.GetConfigValue(rateValues.Provider));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = client.GetAsync("api/v5/convert?" + "q=" + rateValues.Fr + "_" + rateValues.To).Result;  // Blocking call 
                if (apiResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = apiResponse.Content.ReadAsStringAsync().Result;
                    if (rateValues.Format == "JSON")
                    {
                        response = jsonResponse;
                    }
                    else
                    {
                        var data = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                        response = data.Last.First.First.Last.SelectToken("val").Value<object>();
                    }
                }
            }
            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }
    }
}