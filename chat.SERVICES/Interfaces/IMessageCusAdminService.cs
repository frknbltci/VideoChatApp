using chat.CORE.Entities;
using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IMessageCusAdminService 
    {

        //5 tane dönüyor anasayfaya
        List<MessageCusAdmin> messageList(int ID);

        List<MessageCusAdmin> allMessageList(int ID);

        void UpdateView(int ID);

        bool senMessagetoCus(MessageDTO data);

    }
}
