using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IPayChartService
    {
        bool savePayInfo(APaymentDTO gelen);
    }
}
