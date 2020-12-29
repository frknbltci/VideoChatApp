using chat.DTO.EEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface IMessagesService
    {
        bool saveMessage(ConversationDTO gelen);
    }
}
