using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
    public partial class Customer : Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int BtPrice { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int GenderID { get; set; }
        public int GenderChoiceID { get; set; }
        public int StatusID { get; set; }

        public bool ContractAcceptance { get; set; }
        
    }
}
