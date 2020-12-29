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
   public class MessagesService : IMessagesService
    {
        private readonly IGenericRepository<Messages> _messageRepository;

        private readonly IUnitofWork _uow;
        public MessagesService(UnitofWork uow)
        {
            _uow = uow;
            _messageRepository = _uow.GetRepository<Messages>();

        }

        public bool saveMessage(ConversationDTO gelen)
        {
            try
            {
                var newmessage = new Messages()
                {
                    CreatedDate = gelen.CreatedDate,
                    SenderID = (int)gelen.SenderID,
                    ReceiverID = (int)gelen.ReceiverID,
                    Message = gelen.Message
                };

                _messageRepository.Insert(newmessage);
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
