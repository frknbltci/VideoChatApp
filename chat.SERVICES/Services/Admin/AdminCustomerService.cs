using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chat.SERVICES.Services.Admin
{
    public class AdminCustomerService : IAdminCustomerService
    {
        private readonly IGenericRepository<chat.CORE.Entities.Customer> _customerRepository;
        private readonly IUnitofWork _uow;
        private EAdminCustomerDTO _adminCustomerDTO;

        public AdminCustomerService(UnitofWork uow)
        {
            _uow = uow;
            _customerRepository = _uow.GetRepository<chat.CORE.Entities.Customer>();
            _adminCustomerDTO = new EAdminCustomerDTO();
        }

        public List<EAdminCustomerDTO> CustomerList()
        {
            var li = (from c in _customerRepository.GetAll()
                      select new EAdminCustomerDTO
                      {
                          ID = c.ID,
                          BtPrice = c.BtPrice,
                          Email = c.Email,
                          IsActive = c.IsActive,
                          UserName = c.UserName,
                          ImageURL = c.ImageURL,
                      }).ToList();
            return li;
        }

    }
}
