using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class BookingRoom_ServiceEN : BookingRooms_Services
    {
        public string Service_Name { get; set; }
        public string Service_Unit { get; set; }
        

        // Thành sửa check số lượng dịch vụ âm 16/06/2015
 
        // Bắt đầu
        public decimal? Sum {
            //get { return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100 + 1); } 
            get {
                if (this.Quantity < 1) {
                    DatabaseDA aDatabaseDA = new DatabaseDA();
                    if (aDatabaseDA.BookingRooms_Services.Where(b => b.ID == this.ID).ToList().Count > 0) {
                        this.Quantity = aDatabaseDA.BookingRooms_Services.Where(b => b.ID == this.ID).ToList()[0].Quantity;
                    }
                    else {
                        this.Quantity = 1;
                    }
                }
                return (decimal)(this.Quantity.GetValueOrDefault(0)) * (decimal)(this.Cost.GetValueOrDefault(0)) * (decimal)(this.PercentTax.GetValueOrDefault(0) / 100 + 1);
            }
        }
        // Kết thúc 
    }
}
