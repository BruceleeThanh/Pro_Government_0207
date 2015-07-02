using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CheckInRoomBookingEN
    {
        //============== FORM 1 =========
        public int IDBookingR { get; set; }
        public DateTime CheckInActual = DateTime.Parse("01/01/1900");
        public DateTime CheckOutPlan = DateTime.Parse("01/01/1900");
        public DateTime CheckOutActual = DateTime.Parse("01/01/1900");  // thoi diem nhan phong gan tam CheckoutActual = CheckOutPlan
        public List<RoomMemberEN> aListRoomMembers = new List<RoomMemberEN>();

        //============== FORM 2 =========
        public DateTime CreateDate = DateTime.Now;
        public int CustomerType;
        public int BookingType;
        public string Note;
        public int IDCustomerGroup;
        public int IDCustomer;
        public int IDCompany;
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

        public void AddCustomerToRoom(string CodeRoom, CustomerInfoEN aCustomerInfo)
        {
            for (int i = 0; i < aListRoomMembers.Count; i++)
            {
                if (aListRoomMembers[i].RoomCode == CodeRoom)
                {
                    aListRoomMembers[i].ListCustomer.Add(aCustomerInfo);
                }
            }
        }

        public void UpdateCustomerToRoom(string CodeRoom, CustomerInfoEN aCustomerInfo)
        {
            this.RemoveCustomerToRoom(aCustomerInfo.ID);
            this.AddCustomerToRoom(CodeRoom, aCustomerInfo);
        }

        public void RemoveCustomerToRoom(int IDCustomer)
        {
            for (int i = 0; i < aListRoomMembers.Count; i++)
            {

                for (int ii = 0; ii < aListRoomMembers[i].ListCustomer.Count; ii++)
                {
                    if (aListRoomMembers[i].ListCustomer[ii].ID == IDCustomer)
                    {
                        aListRoomMembers[i].ListCustomer.RemoveAt(ii);
                    }
                }
            }
        }

        public CustomerInfoEN GetCustomer(int IDCustomer)
        {

            for (int i = 0; i < aListRoomMembers.Count; i++)
            {
                for (int ii = 0; ii < aListRoomMembers[i].ListCustomer.Count; ii++)
                {
                    if (aListRoomMembers[i].ListCustomer[ii].ID == IDCustomer)
                    {
                        return aListRoomMembers[i].ListCustomer[ii];
                        break;
                    }
                }
            }
            return new CustomerInfoEN();
        }

    }


}
