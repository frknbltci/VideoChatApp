using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
    public partial class Favorites : Base
    {
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

    }
}
