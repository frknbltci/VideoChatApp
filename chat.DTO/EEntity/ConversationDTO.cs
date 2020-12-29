using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class ConversationDTO
    {
   
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Sender1Img { get; set; }
        public string Sender2Img { get; set; }
        public string Receiver1Img { get; set; }
        public string Receiver2Img { get; set; }
        public string SenderName1 { get; set; }
        public string SenderName2 { get; set; }
        public string ReceiverName1{ get; set; }
        public string ReceiverName2{ get; set; }
        public int? ReceiverID { get; set; }
        public int? SenderID { get; set; }

    }
}
