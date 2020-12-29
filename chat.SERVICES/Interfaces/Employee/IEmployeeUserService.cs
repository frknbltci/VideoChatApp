using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces.Employee
{
    public interface IEmployeeUserService
    {
        EmployeeProfileDTO empProfileEdit(int? id);

        chat.CORE.Entities.Employee getEmployeInfo(string Email, string Password);

        void Update(EEmployeeDTO data);

        EmployeeProfileDTO getRegisInfo();

        List<chat.CORE.Entities.Employee> getEmployee();

        bool addUser(EEmployeeDTO data);

        void updateStatus(int ID);

        bool updateAdminEmployee(chat.CORE.Entities.Employee data);


        bool UpdateIsActive(int ID);

      
        bool changeStatus(int? statusId, int? empId);

    }
}
