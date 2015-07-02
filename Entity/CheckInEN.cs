using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Entity
{

    public class CheckInEN
    {
        //============== FORM 1 =========
        public DateTime CheckInActual = DateTime.Parse("01/01/1900");
        public DateTime CheckOutPlan = DateTime.Parse("01/01/1900");
        public DateTime CheckOutActual = DateTime.Parse("01/01/1900");  // thoi diem nhan phong gan tam CheckoutActual = CheckOutPlan

        public List<RoomMemberEN> aListRoomMembers = new List<RoomMemberEN>();

        //============== FORM 2 =========
        public int IDBookingR;
        public DateTime CreateDate = DateTime.Now;
        public int CustomerType;
        public int BookingType;
        public string Note;
        public int IDCompany;
        public string NameCompany;
        public int IDCustomerGroup;
        public int IDCustomer;
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

                 for (int ii = 0; ii < aListRoomMembers[i].ListCustomer.Count ; ii++)
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
                    }
                }
            }
            return new CustomerInfoEN();
        }
        //Hiennv   18/11/2014
        public void InsertRoom(RoomMemberEN aRoomMemberEN)
        {
            this.aListRoomMembers.Insert(0, aRoomMemberEN);
        }
        //Hiennv   18/11/2014
        public List<RoomMemberEN> GetListRoomMemberByCodeRoom(string roomCode)
        {
            return this.aListRoomMembers.Where(r => r.RoomCode == roomCode).ToList();
        }
        //Hiennv    18/11/2014
        public void RemoveRoom(RoomMemberEN aRoomMemberEN)
        {
            this.aListRoomMembers.Remove(aRoomMemberEN);
        }

        //Hiennv  18/11/2014
        public List<CustomerInfoEN> GetListCustomerByRoomCode(string RoomCode)
        {

            for (int i = 0; i < this.aListRoomMembers.Count; i++)
            {
                if (this.aListRoomMembers[i].RoomCode == RoomCode)
                {
                    return this.aListRoomMembers[i].ListCustomer.Where(c => c.RoomCode == RoomCode).ToList();
                }
            }
            return null;
        }
        //Hiennv  27/11/2014
        public List<CustomerInfoEN> ClearAllListCustomer()
        {
            for (int i = 0; i < this.aListRoomMembers.Count; i++)
            {
                this.aListRoomMembers[i].ListCustomer.Clear();
            }
            return null;
        }


        //Hiennv  19/11/2014
        public CustomerInfoEN GetCustomerInfoByRoomCodeAndIDCustomer(string RoomCode, int IDCustomer)
        {

            for (int i = 0; i < this.aListRoomMembers.Count; i++)
            {
                if (this.aListRoomMembers[i].RoomCode == RoomCode)
                {
                    if (this.aListRoomMembers[i].ListCustomer.Where(c => c.RoomCode == RoomCode && c.ID == IDCustomer).ToList().Count > 0)
                    {
                        return this.aListRoomMembers[i].ListCustomer.Where(c => c.RoomCode == RoomCode && c.ID == IDCustomer).ToList()[0];
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            return null;
        }

        //Hiennv  18/11/2014
        public bool IsCustomerExistInRoom(string RoomCode, int IDCustomer)
        {

            for (int i = 0; i < this.aListRoomMembers.Count; i++)
            {
                if (this.aListRoomMembers[i].RoomCode == RoomCode)
                {
                    int count = this.aListRoomMembers[i].ListCustomer.Where(c => c.RoomCode == RoomCode && c.ID == IDCustomer).ToList().Count;
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Hiennv  19/11/2014
        public RoomMemberEN IsCodeRoomExistInRoom(string RoomCode)
        {
            if (this.aListRoomMembers.Where(r => r.RoomCode == RoomCode).ToList().Count > 0)
            {
                return this.aListRoomMembers.Where(r => r.RoomCode == RoomCode).ToList()[0];
            }
            return null;
        }
        //Hiennv  20/11/2014
        public void SetValuePepoleRepresentative(int IDCustomer)
        {

            for (int i = 0; i < this.aListRoomMembers.Count; i++)
            {
                for (int j = 0; j < this.aListRoomMembers[i].ListCustomer.Count; j++)
                {
                    this.aListRoomMembers[i].ListCustomer[j].PepoleRepresentative = false;

                    if (this.aListRoomMembers[i].ListCustomer[j].ID == IDCustomer)
                    {
                        this.aListRoomMembers[i].ListCustomer[j].PepoleRepresentative = true;
                    }
                }
            }

        }
        //Hienv      25/11/2014   lay ra thong tin cua room
        public Rooms GetInfoRooms(List<Rooms> aListRooms, string codeRoom)
        {
            try
            {
                List<Rooms> aListTemp = aListRooms.Where(r => r.Code == codeRoom && r.IDLang == 1).ToList();
                if (aListRooms.Count > 0)
                {
                    return aListTemp[0];
                }
                else
                {
                    return null;
                }
            }catch (Exception ex)
            {
                return null;
            }
        }
    }


}
