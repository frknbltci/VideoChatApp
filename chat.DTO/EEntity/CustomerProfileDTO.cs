using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class CustomerProfileDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string uploadImgCus { get; set; }

        public string ImageUrl { get; set; }
        public string  Password { get; set; }
        public string  Email { get; set; }
        public int StatusID { get; set; }

        public string editCusOldImg { get; set; }

        public int BtPrice { get; set; }
        public List<Status> StatusList { get; set; }

    }
}
