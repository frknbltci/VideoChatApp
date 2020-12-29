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
  public class PoolBanService: IPoolBanService
    {

        private readonly IGenericRepository<PoolBan> _poolBanRepository;

        private readonly IUnitofWork _uow;
        public PoolBanService(UnitofWork uow)
        {
            _uow = uow;
            _poolBanRepository = _uow.GetRepository<PoolBan>();

        }

        public bool addBan(int? CustomerID, int? EmployeeID)
        {
            if (CustomerID==null || EmployeeID==null)
            {
                return false;
            }
            {
                try
                {
                    PoolBan ban = new PoolBan()
                    {
                        EmployeeID = (int)EmployeeID,
                        CustomerID = (int)CustomerID
                    };
                    _poolBanRepository.Insert(ban);
                    _uow.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

                
            }
        }

        public bool delBanModal(int? CustomerId, int? EmployeeId)
        {
            if (CustomerId==null || EmployeeId==null)
            {
                return false;
            }
            else
            {
                try
                {
                   
                    var delPool = _poolBanRepository.GetAll().Where(x => x.CustomerID == CustomerId && x.EmployeeID == EmployeeId).SingleOrDefault();

                    _poolBanRepository.Delete(delPool);
                    _uow.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }

           
        }

        public List<PoolBan> getBanList()
        {
            return _poolBanRepository.GetAll().ToList();
        }
    }
}
