﻿using Sipay.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.UTILITIES.SessionOperations
{
    public class EmpCusSessionContext
    {

        public int ID { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int StatusID { get; set; }

        public string ImageUrl { get; set; }

        public int BtPrice { get; set; }

        public int Type { get; set; }

        public SipayTokenResponse Token { get; set; }
    }
}
