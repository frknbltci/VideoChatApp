using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class EDeserveDTO
    {

        public int ID { get; set; } 
        public DateTime Time { get; set; }

        public int Credit { get; set; }
        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public string Tipi { get; set; }

    }

    public class Lists
    {
        public List<EDeserveDTO> gifts { get; set; }
        public List<EDeserveDTO> calls { get; set; }
    }

}
