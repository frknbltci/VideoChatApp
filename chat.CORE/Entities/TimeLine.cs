using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.CORE.Entities
{
    public partial class TimeLine : Base
    {
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime TotalTime { get; set; }

        public string Room { get; set; }

    }
}
