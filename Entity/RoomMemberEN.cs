using System;
using System.Collections.Generic;
using DataAccess;

namespace Entity
{
    public class RoomMemberEN
    {
        public int IDBookingRooms { get; set; }
        public string RoomSku { get; set; }
        public string RoomCode { get; set; }
        public int RoomType { get; set; }
        public int RoomBed1 { get; set; }
        public int RoomBed2 { get; set; }
        public string RoomTypeDisplay { get; set; }
        public decimal RoomCostRef { get; set; }
        public decimal RoomCost { get; set; }
        public List<CustomerInfoEN> ListCustomer = new List<CustomerInfoEN>();

    }
}
