using chat.CORE.Entities;
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
    public class TimeLineService : ITimeLineService
    {
        private readonly IGenericRepository<TimeLine> _timeLineRepository;
       
            private readonly IUnitofWork _uow;
        public TimeLineService(UnitofWork uow)
        {
            _uow = uow;
            _timeLineRepository = _uow.GetRepository<TimeLine>();
          
        }


        public void addConversation(TimeLine conv)
        {
            _timeLineRepository.Insert(conv);
            _uow.SaveChanges();

        }

        public TimeLine getTimeLine(string room_id, int userid, int empid)
        {
            var conv= _timeLineRepository.GetAll().Where(x => x.Room == room_id && x.CustomerID == userid && x.EmployeeID == empid).SingleOrDefault();
            if (conv !=null)
            {
                return conv;
            }
            else
            {
                return null;
            }
            
        }
    }
}
