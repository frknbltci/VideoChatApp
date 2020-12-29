using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class MessageDTO
    {

        public int ID { get; set; }
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string About { get; set; }
        public string Messages { get; set; }

        public DateTime SendDate { get; set; }

        public bool Viewed { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int ReceiveID { get; set; }

        public List<Customer> CustomerList { get; set; }
        public List<Employee> EmployeeList { get; set; }

    }
}
