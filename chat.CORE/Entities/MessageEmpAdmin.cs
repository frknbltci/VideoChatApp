using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
   public class MessageEmpAdmin :Base
    {
        public int AdminID { get; set; }
        public int EmpID { get; set; }
        public string Message { get; set; }
        public bool Viewed { get; set; }

        public DateTime SendDate { get; set; }

        public string About { get; set; }
       
    }
}
