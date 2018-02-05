using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixerExchange.Utilities
{
    public class Rates
    {
        public string Provider { get; set; }

        public string Fr { get; set; }

        public string To { get; set; }

        public string Format { get; set; }

        public string ApiKey { get; set; }
    }
}