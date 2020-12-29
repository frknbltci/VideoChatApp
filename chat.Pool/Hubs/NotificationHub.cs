using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Employee;
using Microsoft.AspNet.SignalR;

namespace chat.Pool.Hubs
{
    public class NotificationHub : Hub
    {
        public void SendMessage(int eid,int ownid,string name)
        {
            Clients.All.GetMessageOther(eid, ownid,name);
         
            Clients.All.GetMessageCaller(ownid);
        }

        public void SendRefuseMessage(int refuseid,string name)
        {
            Clients.All.GetRefuseMessageOther(refuseid, name);
        }
    
        public void SendRouteMessage(string roomNumber, int cusId,int empId)
        {
            Clients.All.GetSendRouteAll(roomNumber, cusId, empId);

        }

        public void SendAllUsers(string message)
        {
            Clients.All.SendAllUser(message);  
        }

        public void SendPoolMessage(string uname,string message,string imgUrl)
        {
            Clients.All.SendInfo(uname, message, imgUrl);
        }
       
        public void SendSpecialMessage(string messageSpecial,string uname,string imgUrl, int recId)
        {
            Clients.All.SendMessageOther(messageSpecial, uname, imgUrl, recId);
        }
        public void SendSpecialConvMessage(string messageSpecial, string uname, string imgUrl, int recId,int senderid)
        {
            Clients.All.SendMessageConvOther(messageSpecial, uname, imgUrl, recId,senderid);
        }

        public void SendSpecialGift(string gift, string uname, string imgUrl, int recId)
        {
            Clients.All.SendMessageGift(gift, uname, imgUrl, recId);
        }

        //public void SendConvMessage(string messageSpecial, string uname, string imgUrl, int recId,int empid,int cusid)
        //{
        //    Clients.All.GetMessageConv(messageSpecial, uname, imgUrl, recId,empid,cusid);
        //}

    }
}