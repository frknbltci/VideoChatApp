using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
    public partial class Employee : Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int GenderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int StatusID { get; set; }
        public int HairTypeID { get; set; }
        public int BodyTypeID { get; set; }
        public int EyeColorID { get; set; }
        public int HairColorID { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public string About { get; set; }

        public bool Confirmation { get; set; }
        public DateTime BirthDate { get; set; }

        public bool ContractAcceptance { get; set; }


    }
}
