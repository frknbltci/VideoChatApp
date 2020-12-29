using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace chat.DTO.EEntity
{
   public class APaymentDTO
    {

        public int ID { get; set; }
        public string AdminName { get; set; }
        public string Quantity { get; set; }

        public int EmployeeID { get; set; }

        public int AdminID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PayImg { get; set; }

        public string EmployeeName { get; set; }

        public List<Employee> EmpList { get; set; }

        //Upload alıp kaydederken kullandığımız
        public HttpPostedFileBase dfile { get; set; } 

        //İçeride insert edilirken kullandığımız
        public string dIFile { get; set; }

    }
}
