using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NewBookingEN
    {
        //============== FORM 1 =========
        public DateTime CheckInActual = DateTime.Parse("01/01/1900");
        public DateTime CheckOutPlan = DateTime.Parse("01/01/1900");
        public DateTime CheckOutActual = DateTime.Parse("01/01/1900");  // thoi diem nhan phong gan tam CheckoutActual = CheckOutPlan
        public List<NewRoomMemberEN> aListNewRoomMembers = new List<NewRoomMemberEN>();

        //============== FORM 2 =========
        public DateTime CreateDate = DateTime.Now;
        public int CustomerType;
        public int BookingType;
        public string Note;
        public int IDCompany;
        public string NameCompany;
        public int IDCustomerGroup;
        public int IDCustomer;
        public string NameCustomer;
        public int IDSystemUser;
        public int PayMenthod;
        public int StatusPay;
        public decimal BookingMoney;
        public decimal ExchangeRate;
        public int Status;
        public int Type;
        public bool Disable;
        public int Level;
        public string Subject;
        public string Description;
        public DateTime DatePay = DateTime.Parse("01/01/1900");
        public DateTime DateEdit = DateTime.Parse("01/01/1900");

        //============== FORM 3 =========

        //Hiennv   25/11/2014
        public void InsertRoom(NewRoomMemberEN aNewRoomMemberEN)
        {
            this.aListNewRoomMembers.Insert(0, aNewRoomMemberEN);
        }
        //Hiennv   25/11/2014
        public List<NewRoomMemberEN> GetListRoomMemberByCodeRoom(string roomCode)
        {
            return this.aListNewRoomMembers.Where(r => r.RoomCode == roomCode).ToList();
        }
        //Hiennv    25/11/2014
        public void RemoveRoom(NewRoomMemberEN aNewRoomMemberEN)
        {
            this.aListNewRoomMembers.Remove(aNewRoomMemberEN);
        }
        //Hiennv  25/11/2014
        public NewRoomMemberEN IsCodeRoomExistInRoom(string RoomCode)
        {
            if (this.aListNewRoomMembers.Where(r => r.RoomCode == RoomCode).ToList().Count > 0)
            {
                return this.aListNewRoomMembers.Where(r => r.RoomCode == RoomCode).ToList()[0];
            }
            return null;
        }
    }
}
