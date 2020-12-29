using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace chat.DTO.EEntity
{
    public class EmployeeProfileDTO
    {
        public List<Gender> genderList { get; set; }

        public List<HairColors> hairColorList { get; set; }

        public List<HairTypes> hairTypesList { get; set; }

        public List<EyeColors> eyeColorList { get; set; }

        public List<BodyTypes> bodyTypesList { get; set; }

        public EEmployeeDTO employe { get; set; }

    }
}
