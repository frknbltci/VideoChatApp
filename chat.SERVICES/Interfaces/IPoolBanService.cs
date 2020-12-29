using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IPoolBanService
    {
        bool addBan(int? CustomerID,int? EmployeeID);

        List<PoolBan> getBanList();

        bool delBanModal(int? CustomerId, int? EmployeeId);
    }
}
