using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class CusEmpDTO
    {
        public List<Customer> CustomerList { get; set; }

        public List<Employee> EmployeeList { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }


    }
}
