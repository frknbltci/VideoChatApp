using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace chat.DTO.EEntity
{
    public class PoolMainDTO
    {
        public List<Favorites> FavList { get; set; }
        public List<PoolBan> BanList { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Customer> CustomerList { get; set; }

    }
}
