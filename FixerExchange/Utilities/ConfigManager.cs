using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FixerExchange.Utilities
{
    public static class ConfigManager
    {
        public static string GetConfigValue(string key)
        {
            string value = string.Empty;
            try
            {
                value = ConfigurationManager.AppSettings[key];

            }
            catch (Exception ex)
            {
                value = "https://api.fixer.io";
            }
            return value;
        }

        public static Rates GetRatesInstance(Rates inputRates)
        {
            Rates resultRates = null;
            try
            {
                //Get query string values
                string provider = inputRates.Provider;
                string currency = inputRates.From;
                string symbol = inputRates.To;
                string format = inputRates.Format;
                if (string.IsNullOrEmpty(provider))
                {
                    provider = "Fixer";
                }
                if (string.IsNullOrEmpty(currency))
                {
                    currency = "USD";
                }
                if (string.IsNullOrEmpty(symbol))
                {
                    symbol = "INR";
                }
                if (string.IsNullOrEmpty(format))
                {
                    format = "text";
                }
                provider = provider.Trim().ToUpper();
                currency = currency.Trim().ToUpper();
                symbol = symbol.Trim().ToUpper();
                format = format.Trim().ToUpper();
                resultRates = new Rates();
                resultRates.Format = format;
                resultRates.From = currency;
                resultRates.To = symbol;
                resultRates.Format = format;
                resultRates.Provider = provider;
            }
            catch (Exception ex)
            {
                resultRates = null;
            }
            return resultRates;
        }

    }
}