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
    public class PayChartService : IPayChartService
    {

        private readonly IGenericRepository<PayChart> _payChartRepository;

        private readonly IUnitofWork _uow;


        public PayChartService(UnitofWork uow)
        {
            _uow = uow;
            _payChartRepository = _uow.GetRepository<chat.CORE.Entities.PayChart>();

        }

        public bool savePayInfo(APaymentDTO gelen)
        {
            try
            {
                PayChart newInfo = new PayChart()
                {
                    AdminID = gelen.AdminID,
                    CreatedDate = gelen.CreatedDate,
                    EmployeeID = gelen.EmployeeID,
                    Quantity = gelen.Quantity,
                    PayImg = gelen.dIFile
                };

                _payChartRepository.Insert(newInfo);
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
