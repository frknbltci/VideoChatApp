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
   public class MessageEmpAdminService : IMessageEmpAdminService
    {

        private readonly IGenericRepository<chat.CORE.Entities.MessageEmpAdmin> _messageEmpAdminRepository;

        private readonly IUnitofWork _uow;
        public MessageEmpAdminService(UnitofWork uow)
        {
            _uow = uow;
            _messageEmpAdminRepository = _uow.GetRepository<chat.CORE.Entities.MessageEmpAdmin>();

        }

        public List<MessageEmpAdmin> allMessageList(int ID)
        {
            return _messageEmpAdminRepository.GetAll().Where(x => x.EmpID == ID).ToList();
        }

        public List<MessageEmpAdmin> messageList(int ID)
        {
            return _messageEmpAdminRepository.GetAll().Where(x => x.EmpID == ID).OrderByDescending(x=>x.ID).Take(5).ToList();
 
        }

        public bool senMessagetoEmp(MessageDTO data)
        {
            try
            {
                var newMes = new MessageEmpAdmin()
                {
                    About = data.About,
                    AdminID = data.AdminID,
                    EmpID = data.ReceiveID,
                    Viewed = data.Viewed,
                    SendDate = data.SendDate,
                    Message = data.Messages
                };

                _messageEmpAdminRepository.Insert(newMes);
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
            var data = _messageEmpAdminRepository.GetAll().Where(x => x.ID == ID).SingleOrDefault();
            if (data.Viewed == true)
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
