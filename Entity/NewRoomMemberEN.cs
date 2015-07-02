using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NewRoomMemberEN
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
    }
}
