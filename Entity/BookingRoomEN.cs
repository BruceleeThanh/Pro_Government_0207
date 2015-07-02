using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class BookingRoomsEN : BookingRooms
    {
       public string RoomSku { get; set; }
       public string LevelBookingRoom { get; set; }
       public void SetValue(BookingRooms aBookingRooms)
       {
           this.ID = aBookingRooms.ID;
           this.IDBookingR = aBookingRooms.IDBookingR;
           this.CodeRoom = aBookingRooms.CodeRoom;
           this.Cost = aBookingRooms.Cost;
           this.PercentTax = aBookingRooms.PercentTax;
           this.CostRef_Rooms = aBookingRooms.CostRef_Rooms;
           this.Note = aBookingRooms.Note;
           this.CheckInPlan = aBookingRooms.CheckInPlan;
           this.CheckInActual = aBookingRooms.CheckInActual;
           this.CheckOutPlan = aBookingRooms.CheckOutPlan;
           this.CheckOutActual = aBookingRooms.CheckOutActual;
           this.BookingStatus = aBookingRooms.BookingStatus;
           this.Status = aBookingRooms.Status;
           this.StartTime = aBookingRooms.StartTime;
           this.EndTime = aBookingRooms.EndTime;
           this.IsAllDayEvent = aBookingRooms.IsAllDayEvent;
           this.Color = aBookingRooms.Color;
           this.IsRecurring = aBookingRooms.IsRecurring;
           this.IsEditable = aBookingRooms.IsEditable;
           this.AdditionalColumn1 = aBookingRooms.AdditionalColumn1;
           this.CostPendingRoom = aBookingRooms.CostPendingRoom;
           this.TimeInUse = aBookingRooms.TimeInUse;


       }
    }
}
