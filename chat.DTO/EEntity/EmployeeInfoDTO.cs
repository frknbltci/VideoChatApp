using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.DTO.EEntity
{
   public class EmployeeInfoDTO
    {
        public string EyeColorName { get; set; }
        public string BodyTypeName { get; set; }
        public string About { get; set; }
        public double  Length { get; set; }
        public double  Weight { get; set; }

        public string HairColorName { get; set; }
        public string HairTypeName { get; set; }

        public string ImgUrl { get; set; }
        public int Yas { get; set; }

        public int StatusId { get; set; }
    }
}
