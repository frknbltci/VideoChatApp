using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
   public class Messages : Base
    {
        
        public int ReceiverID { get; set; }
        public int SenderID { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
