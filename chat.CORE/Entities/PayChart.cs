using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace chat.CORE.Entities
{
    public partial class PayChart : Base
    {
       
        public int AdminID { get; set; }
        public int EmployeeID { get; set; }
        public string  Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        public string PayImg { get; set; }
     
    }
}
