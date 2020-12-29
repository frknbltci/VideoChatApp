using chat.CORE.Entities;
using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces.Admin
{
    public interface IAdminUserService
    {
        EAdminUserDTO GetUserByUnAPass(string username, string password);
        void Insert(EAdminUserDTO admin);

        List<AdminUser> getAdminList();

        List<PayChart> getPayList();

        List<chat.CORE.Entities.Employee> EmployeesList();



    }
}
