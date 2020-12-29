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
    public class CustomerPaymentService : ICustomerPaymentService
    {
        private readonly IGenericRepository<chat.CORE.Entities.CustomerPayment> _customerPaymentRepository;

        private readonly IUnitofWork _uow;
        public CustomerPaymentService(UnitofWork uow)
        {
            _uow = uow;
            _customerPaymentRepository = _uow.GetRepository<chat.CORE.Entities.CustomerPayment>();

        }


        //Müşterinin giftleri için ödediklerini tabloya ekliyoruz
        public bool addCusPay(int? price,int? cusId, int? empid)
        {
            if (cusId==null || empid==null || cusId==0 || empid==0 || price==null)
            {
                return false;
            }
            else
            {
                try
                {
                    chat.CORE.Entities.CustomerPayment newData = new chat.CORE.Entities.CustomerPayment()
                    {
                        CreatedTime = DateTime.Now,
                        CustomerID = (int)cusId,
                        EmployeeID = (int)empid,
                        PaymentCredit = (int)price
                    };

                    _customerPaymentRepository.Insert(newData);
                    _uow.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }
}
