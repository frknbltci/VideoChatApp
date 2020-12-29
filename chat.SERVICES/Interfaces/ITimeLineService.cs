using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat.SERVICES.Interfaces
{
   public interface ITimeLineService
    {
        void addConversation(TimeLine conv);
        TimeLine getTimeLine(string room_id, int userid, int empid);
    }
}
