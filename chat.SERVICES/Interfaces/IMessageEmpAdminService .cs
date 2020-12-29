using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chat.CORE.Entities;
using chat.DTO.EEntity;

namespace chat.SERVICES.Interfaces
{
   public interface IMessageEmpAdminService
    {
        List<MessageEmpAdmin> messageList(int ID);

        List<MessageEmpAdmin> allMessageList(int ID);

        void UpdateView(int ID);

        bool senMessagetoEmp(MessageDTO data);
    }
}
