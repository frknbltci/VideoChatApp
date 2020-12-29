using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IGenericRepository<Favorites> _favoriteRepository;

        private readonly IUnitofWork _uow;
        public FavoritesService(UnitofWork uow)
        {
            _uow = uow;
            _favoriteRepository = _uow.GetRepository<Favorites>();

        }

        public bool addFav(int? CustomerID, int? EmployeeID)
        {
            var varMi= _favoriteRepository.GetAll().Where(x => x.EmployeeID == EmployeeID && x.CustomerID == CustomerID).SingleOrDefault();

            if (varMi != null)
            {
                return false;
            }
            else
            {
                Favorites data = new Favorites()
                {
                    CustomerID = (int)CustomerID,
                    EmployeeID = (int)EmployeeID
                };
                _favoriteRepository.Insert(data);
                _uow.SaveChanges();
                return true;
            }

            
        }

        public bool delFav(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID==null || EmployeeID==null)
            {
                return false;
            }
            else
            {
               var delData = _favoriteRepository.GetAll().Where(x => x.EmployeeID == EmployeeID && x.CustomerID == CustomerID).SingleOrDefault();
                _favoriteRepository.Delete(delData);
                if (delData==null)
                {
                    return false;
                }
                _uow.SaveChanges();
                return true;
            }
        }

        public List<Favorites> getFavorite(int CustomerID)
        {
            return _favoriteRepository.GetAll().Where(x => x.CustomerID == CustomerID).ToList();
        }

    }
}
