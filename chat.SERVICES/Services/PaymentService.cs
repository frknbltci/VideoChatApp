using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.DTO.EEntity;
using chat.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Services
{
   public class PaymentService : IPaymentService
    {

        private readonly IGenericRepository<Payment> _paymentRepository;

        private readonly IUnitofWork _uow;
        public PaymentService(UnitofWork uow)
        {
            _uow = uow;
            _paymentRepository = _uow.GetRepository<Payment>();

        }

        public Payment getPayment(string OrderId)
        {
           return _paymentRepository.GetAll().Where(x => x.OrderId == OrderId && x.Status==false).SingleOrDefault();
        }

        public bool insertPayment(PaymentDTO gelen)
        {   
            try
            {
                Payment payment = new Payment()
                {
                    CustomerId = gelen.CustomerId,
                    OrderId = gelen.OrderId,
                    PaymentDate = gelen.PaymentDate,
                    Price = gelen.Price,
                    Status = gelen.Status
                };

                _paymentRepository.Insert(payment);
                _uow.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool updatePayment(PaymentDTO gelen)
        {
            try
            {
                var data = _paymentRepository.Find(gelen.ID);
                data.ID = gelen.ID;
                data.CustomerId = gelen.CustomerId;
                data.OrderId = gelen.OrderId;
                data.Price = gelen.Price;
                data.Status = gelen.Status;
                data.PaymentDate = gelen.PaymentDate;

                _uow.SaveChanges();

            }
            catch (Exception ex)
            {
                var err = ex;
                return false;
            }

            return true;
        }
    }
}
