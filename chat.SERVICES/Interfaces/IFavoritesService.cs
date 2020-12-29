using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IFavoritesService
    {
        bool addFav(int? CustomerID,int? EmployeeID);
        bool delFav(int? CustomerID,int? EmployeeID);
        List<chat.CORE.Entities.Favorites> getFavorite(int CustomerID);

    }
}
