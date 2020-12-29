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
    public class AdminUserService : IAdminUserService
    {
        private readonly IGenericRepository<AdminUser> _userRepository;
        private readonly IGenericRepository<chat.CORE.Entities.Employee> _employeeRepository;
        private readonly IGenericRepository<PayChart> _paychartRepository;
        private readonly IUnitofWork _uow;
        private EAdminUserDTO _adminUserDTO;

        public AdminUserService(UnitofWork uow)
        {
            _uow = uow;
            _userRepository = _uow.GetRepository<AdminUser>();
            _adminUserDTO = new EAdminUserDTO();
            _paychartRepository = _uow.GetRepository<PayChart>();
            _employeeRepository = _uow.GetRepository<chat.CORE.Entities.Employee>(); 
        }

        public List<CORE.Entities.Employee> EmployeesList()
        {
            return _employeeRepository.GetAll().ToList();
        }

        public List<AdminUser> getAdminList()
        {
            return  _userRepository.GetAll().ToList();
        }
       
        public List<PayChart> getPayList()
        {
            return _paychartRepository.GetAll().ToList();
        }

        public EAdminUserDTO GetUserByUnAPass(string username, string password)
        {
            var control = (from u in _userRepository.GetAll()
                           where u.UserName == username && u.Password == password
                           select new EAdminUserDTO
                           {
                               ID = u.ID,
                               Password = u.Password,
                               UserName = u.UserName
                           }).SingleOrDefault();
            return control;
        }

        public void Insert(EAdminUserDTO admin)
        {
            var use = AutoMapper.Mapper.DynamicMap<AdminUser>(admin);
            _userRepository.Insert(use);
            _uow.SaveChanges();
        }

    }
}
