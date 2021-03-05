using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Constants
{
    public static class ConfigurationConstants
    {
        public static string CurrencySymbol = ConfigurationManager.AppSettings["CurrencySymbol"];
    }
}
