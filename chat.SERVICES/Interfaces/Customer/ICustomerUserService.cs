using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chat.SERVICES.Interfaces.Customer
{
   public interface ICustomerUserService
    {

        chat.CORE.Entities.Customer getCustomerInfo(string Email, string Password);
        void decreaseBtPrice(int price,int cusId);

        CustomerProfileDTO cusProfileEdit(int? id);

        bool Update(CustomerProfileDTO data);

        bool addCustomer(CCustomerDTO data);

        bool UpdateIsActive(int ID);

        bool updateAdminCustomer(chat.CORE.Entities.Customer gelen);

        List<chat.CORE.Entities.Customer> getCusList();


        bool changeStatus(int? statusId, int? cusId);

        bool addBtPrice(int ID,int BtPrice);

        bool UpdateIsStatus(int ID);
    }
}

