using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Constants
{
   public class ConstantsInfo
    {

        public static string AppID = System.Web.Configuration.WebConfigurationManager.AppSettings["AppID"];

        public static string AppSecret = System.Web.Configuration.WebConfigurationManager.AppSettings["AppSecret"];


        public static string MerchantKey = System.Web.Configuration.WebConfigurationManager.AppSettings["MerchantKey"];

        public static string BaseUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["BaseUrl"];

      



    }
}
