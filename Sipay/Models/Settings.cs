using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay.Models
{
    public class Settings
    {
        private string _merchant_key { get; set; }
        private string _app_id { get; set; }
        private string _app_secret { get; set; }
        private string _base_url { get; set; }

        public string AppID { get { return _app_id; } set { _app_id = value; } }
        public string AppSecret { get { return _app_secret; } set { _app_secret = value; } }
        public string MerchantKey { get { return _merchant_key; } set { _merchant_key = value; } }
        public string BaseUrl { get { return _base_url; } set { _base_url = value; } }


        public Settings()
        {
            //this._app_id = "0d1d9ee4018c9a611cfe1e7f0552f737";
            //this._app_secret = "30ce9744916ae49a62a2c57f23f8e6ec";
            //this._merchant_key = "$2y$10$8aMjyHXOJ1kPul48DOr2e.XfTkHZJceWrBY6T318iN5Ow4LAWzJaC";
        }

    }
}
