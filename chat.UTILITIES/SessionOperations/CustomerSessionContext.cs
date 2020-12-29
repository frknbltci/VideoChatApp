using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.UTILITIES.SessionOperations
{
    public class CustomerSessionContext
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int BtPrice { get; set; }
        public bool IsActive { get; set; }
        public int StatusID { get; set; }
    }
}
