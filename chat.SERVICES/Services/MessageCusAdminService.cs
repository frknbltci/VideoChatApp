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
   public class MessageCusAdminService : IMessageCusAdminService
    {
        private readonly IGenericRepository<chat.CORE.Entities.MessageCusAdmin> _messageCusAdminRepository;

        private readonly IUnitofWork _uow;
        public MessageCusAdminService(UnitofWork uow)
        {
            _uow = uow;
            _messageCusAdminRepository = _uow.GetRepository<chat.CORE.Entities.MessageCusAdmin>();

        }

        public List<MessageCusAdmin> allMessageList(int ID)
        {
            return _messageCusAdminRepository.GetAll().Where(x => x.CusID == ID).ToList();
        }

        public List<MessageCusAdmin> messageList(int ID)
        {
            return _messageCusAdminRepository.GetAll().Where(x => x.CusID == ID).OrderByDescending(x=>x.ID).Take(5).ToList();
        }

        public bool senMessagetoCus(MessageDTO data)
        {
            try
            {
                var newMes = new MessageCusAdmin()
                {
                    About = data.About,
                    AdminID = data.AdminID,
                    CusID = data.ReceiveID,
                    Viewed = data.Viewed,
                    SendDate = data.SendDate,
                    Message = data.Messages
                };

                _messageCusAdminRepository.Insert(newMes);
            }
            catch (Exception)
            {

                return false;
            }
            _uow.SaveChanges();
            return true;

        }

        public void UpdateView(int ID)
        {
            var data = _messageCusAdminRepository.GetAll().Where(x => x.ID == ID).SingleOrDefault();
            if (data.Viewed==true)
            {
                data.Viewed = true;
            }
            else
            {
                data.Viewed = true;
                
            }
            _uow.SaveChanges();
        }
    }
}
