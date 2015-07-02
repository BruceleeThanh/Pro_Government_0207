using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
   public class RoomExtStatusEN : sp_RoomExt_GetCurrentStatusRooms_ByIDRoom_ByTime_Result
    {
       public int RoomStatus;

      
       public RoomExtStatusEN()
       {
         
           this.RoomStatus = 0;
           this.Code = "0";

           this.ID = 0;
           this.Bed1 = 0;
           this.Bed2 = 0;
           this.CostRef = 0;
           this.Sku = "000";
           this.Note = "";
           this.Type = 0;
           this.BookingRooms_ID = 0;
           this.BookingRs_BookingMoney = 0;
           this.BookingRs_CustomerType = 0;
           this.BookingRs_ID = 0;
           this.BookingRs_Subject = "";
           this.CheckInActual = DateTime.Parse("01/01/1900");
           this.CheckInPlan = DateTime.Parse("01/01/1900");
           this.CheckOutActual = DateTime.Parse("01/01/1900");
           this.CheckOutPlan = DateTime.Parse("01/01/1900");
           this.Color = true;
           this.Companies_ID = 0;
           this.Companies_Name = "";
           this.CostRef = 0;
           this.CustomerGroups_ID = 0;
           this.CustomerGroups_Name = "";
           this.Customers_Address = "";
           this.Customers_ID = 0;
           this.Customers_Name = "";
           this.Customers_Nationality = "";
           this.Customers_Tel = "";
       }

    }
}
