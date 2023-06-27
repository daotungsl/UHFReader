using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFReader
{
    public class AppSettings
    {
        public static int AccessEpcPerCount => Convert.ToInt32(ConfigurationManager.AppSettings["AccessEpcPerCount"]);
        public static int RejectEpcPerCount => Convert.ToInt32(ConfigurationManager.AppSettings["RejectEpcPerCount"]);
        public static int TimeHoldEpcPerSec => Convert.ToInt32(ConfigurationManager.AppSettings["TimeHoldEpcPerSec"]);

        
    }
}
