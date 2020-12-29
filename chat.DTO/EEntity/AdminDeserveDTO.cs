using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class AdminDeserveDTO
    {
        public DateTime startTime { get; set; }

        public int Credit { get; set; }
        public string CustomerName { get; set; }

        public List<Employee> EmpList { get; set; }

    }
}
