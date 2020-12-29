using chat.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace chat.DTO.EEntity
{
    public class EPayChartDTO
    {
        //Çeklilecek verilerin tiplerini oluştur

        public int ID { get; set; }
        public string AdminName { get; set; }

        public string Quantity { get; set; }

        public DateTime CreatedTime { get; set; }

        public string sPayImg { get; set; }

        public HttpPostedFileBase PayImg { get; set; }

        public List<PayChart> PayList { get; set; }

           

    }
}
