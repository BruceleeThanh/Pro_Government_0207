using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
   public class ItemChangeRoomEN
    {
       public ItemChangeRoomEN()
       {
           this._aBookingRooms = new BookingRooms();
           this._alistCustomer = new List<CustomerInfoEN>();
           this.IsRootRoom = false;
       }
       private BookingRooms _aBookingRooms { set; get; }
       public bool IsRootRoom { set; get; }
       private List<CustomerInfoEN> _alistCustomer { set; get; }
       public bool IsRoomInBookingR { set; get; }
       

       public int GetStatusBookingRooms()
       {
           return this._aBookingRooms.Status.GetValueOrDefault(0);
       }
       public string GetPriceType()
       {
           return this._aBookingRooms.PriceType;
       }
        public List<CustomerInfoEN> GetAllCustomers()
        {
            return this._alistCustomer;
        }
        public CustomerInfoEN GetCustomers(int IDCustomer)
        {
            List < CustomerInfoEN > aList = this._alistCustomer.Where(p => p.ID == IDCustomer).ToList();
            if (aList.Count == 1)
            {
                return aList[0];
            }
            else
            {
                return null;
            }

        }
        public void SetBookingRooms(BookingRooms aBookingRooms)
        {
            BookingRooms aItem = new BookingRooms();
            aItem = aBookingRooms;

            this._aBookingRooms.AcceptDate = aItem.AcceptDate;
            this._aBookingRooms.AdditionalColumn1 = aItem.AdditionalColumn1;
            this._aBookingRooms.AddTimeEnd = aItem.AddTimeEnd;
            this._aBookingRooms.AddTimeStart = aItem.AddTimeStart;
            this._aBookingRooms.BookingStatus = aItem.BookingStatus;
            this._aBookingRooms.CheckInActual = aItem.CheckInActual;

            this._aBookingRooms.CheckInPlan = aItem.CheckInPlan;
            this._aBookingRooms.CheckOutActual = aItem.CheckOutActual;
            this._aBookingRooms.CheckOutPlan = aItem.CheckOutPlan;
            this._aBookingRooms.CodeRoom = aItem.CodeRoom;
            this._aBookingRooms.Color = aItem.Color;

            this._aBookingRooms.Cost = null;
            this._aBookingRooms.CostPendingRoom = aItem.CostPendingRoom;
            this._aBookingRooms.CostRef_Rooms = aItem.CostRef_Rooms;
            this._aBookingRooms.Disable = aItem.Disable;
            this._aBookingRooms.EndTime = aItem.EndTime;
            this._aBookingRooms.ID = aItem.ID;

            this._aBookingRooms.IDBookingR = aItem.IDBookingR;
            this._aBookingRooms.IndexSubPayment = aItem.IndexSubPayment;

            this._aBookingRooms.InvoiceDate = aItem.InvoiceDate;
            this._aBookingRooms.InvoiceNumber = aItem.InvoiceNumber;
            this._aBookingRooms.IsAllDayEvent = aItem.IsAllDayEvent;
            this._aBookingRooms.IsEditable = aItem.IsEditable;
            this._aBookingRooms.IsRecurring = aItem.IsRecurring;

            this._aBookingRooms.Note = aItem.Note;
            this._aBookingRooms.PercentTax = aItem.PercentTax;
            this._aBookingRooms.PriceType = aItem.PriceType;
            this._aBookingRooms.StartTime = aItem.StartTime;

            this._aBookingRooms.Status = aItem.Status;
            this._aBookingRooms.TimeInUse = aItem.TimeInUse;
            this._aBookingRooms.Type = aItem.Type;

        }
        public BookingRooms GetBookingRooms()
        {
            return  this._aBookingRooms;
        }
        public string GetCodeRoom()
        {
            return this._aBookingRooms.CodeRoom;
        }
        public void SetCodeRoom(string CodeRoom) 
        {
            this._aBookingRooms.CodeRoom = CodeRoom;
        }
        //  chuyen nguoi ra khoi phong
        public CustomerInfoEN RemoveCustomer(int IDCustomer)
        {
            try
            {
                List<CustomerInfoEN> aListCustomers = this._alistCustomer.Where(p => p.ID == IDCustomer).ToList();
                if (aListCustomers.Count > 0)
                {
                    return aListCustomers[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ItemChangeRoomEn_RemoveCustomer " + ex.ToString());
            }
        }
        // chuyen nguoi vao phong
        public List<CustomerInfoEN> AddCustomer(CustomerInfoEN cust)
        {
            try
            {
                CustomerInfoEN temp = new CustomerInfoEN();
                temp.Address = cust.Address;
                temp.Birthday = cust.Birthday;
                temp.Citizen = cust.Citizen;

                temp.Description = cust.Description;
                temp.Disable = cust.Disable;
                temp.Email = cust.Email;
                temp.Gender = cust.Gender;

                temp.ID = cust.ID;
                temp.Identifier1 = cust.Identifier1;
                temp.Identifier1CreatedDate = cust.Identifier1CreatedDate;
                temp.Identifier2 = cust.Identifier2;
                temp.Identifier2CreatedDate = cust.Identifier2CreatedDate;

                temp.Identifier3 = cust.Identifier3;
                temp.Identifier3CreatedDate = cust.Identifier3CreatedDate;
                temp.Info = cust.Info;
                temp.Name = cust.Name;
                temp.Nationality = cust.Nationality;

                temp.Note = cust.Note;
                temp.PlaceOfIssue1 = cust.PlaceOfIssue1;
                temp.PlaceOfIssue2 = cust.PlaceOfIssue2;
                temp.PlaceOfIssue3 = cust.PlaceOfIssue3;
                temp.Status = cust.Status;

                temp.Tel = cust.Tel;
                temp.Type = cust.Type;

                temp.EnterGate = cust.EnterGate;
                temp.PepoleRepresentative = cust.PepoleRepresentative;
                temp.PurposeComeVietnam = cust.PurposeComeVietnam;
                temp.DateEnterCountry = cust.DateEnterCountry;
                temp.EnterGate = cust.EnterGate;
                temp.TemporaryResidenceDate = cust.TemporaryResidenceDate;
                temp.LeaveDate = cust.LeaveDate;
                temp.Organization = cust.Organization;
                temp.LimitDateEnterCountry = cust.LimitDateEnterCountry;


                _alistCustomer.Add(temp);
                return _alistCustomer;
            }
            catch(Exception p)
            {
                throw new Exception("ItemChangeRoomEn_AddCustomer "+ p.ToString());
            }
        }
        public List<CustomerInfoEN> AddCustomer(List<CustomerInfoEN> aListCustomers)
        {
            try
            {
                List<CustomerInfoEN> aList = new List<CustomerInfoEN>();
                CustomerInfoEN temp = new CustomerInfoEN();
                for (int i = 0; i < aListCustomers.Count; i++)
                {
                    temp = new CustomerInfoEN ();
                    temp.Address = aListCustomers[i].Address;
                    temp.Birthday = aListCustomers[i].Birthday;
                    temp.Citizen = aListCustomers[i].Citizen;

                    temp.Description = aListCustomers[i].Description;
                    temp.Disable = aListCustomers[i].Disable;
                    temp.Email = aListCustomers[i].Email;
                    temp.Gender = aListCustomers[i].Gender;

                    temp.ID = aListCustomers[i].ID;
                    temp.Identifier1 = aListCustomers[i].Identifier1;
                    temp.Identifier1CreatedDate = aListCustomers[i].Identifier1CreatedDate;
                    temp.Identifier2 = aListCustomers[i].Identifier2;
                    temp.Identifier2CreatedDate = aListCustomers[i].Identifier2CreatedDate;

                    temp.Identifier3 = aListCustomers[i].Identifier3;
                    temp.Identifier3CreatedDate = aListCustomers[i].Identifier3CreatedDate;
                    temp.Info = aListCustomers[i].Info;
                    temp.Name = aListCustomers[i].Name;
                    temp.Nationality = aListCustomers[i].Nationality;

                    temp.Note = aListCustomers[i].Note;
                    temp.PlaceOfIssue1 = aListCustomers[i].PlaceOfIssue1;
                    temp.PlaceOfIssue2 = aListCustomers[i].PlaceOfIssue2;
                    temp.PlaceOfIssue3 = aListCustomers[i].PlaceOfIssue3;
                    temp.Status = aListCustomers[i].Status;

                    temp.Tel = aListCustomers[i].Tel;
                    temp.Type = aListCustomers[i].Type;

                    temp.EnterGate = aListCustomers[i].EnterGate;
                    temp.PepoleRepresentative = aListCustomers[i].PepoleRepresentative;
                    temp.PurposeComeVietnam = aListCustomers[i].PurposeComeVietnam;
                    temp.DateEnterCountry = aListCustomers[i].DateEnterCountry;
                    temp.EnterGate = aListCustomers[i].EnterGate;
                    temp.TemporaryResidenceDate = aListCustomers[i].TemporaryResidenceDate;
                    temp.LeaveDate = aListCustomers[i].LeaveDate;
                    temp.Organization = aListCustomers[i].Organization;
                    temp.LimitDateEnterCountry = aListCustomers[i].LimitDateEnterCountry;

                    aList.Add(temp);

                }
                _alistCustomer.AddRange(aList);
                return _alistCustomer;
            }
            catch (Exception p)
            {
                throw new Exception("ItemChangeRoomEn_AddCustomer " + p.ToString());
            }
        }

        // this function overwrite list customer in this._alistCustomer.
       public List<CustomerInfoEN> UpdateCustomer(List<CustomerInfoEN> aListCustomers)
        {
            try
            {
                this._alistCustomer = new List<CustomerInfoEN>();
                List<CustomerInfoEN> aList = new List<CustomerInfoEN>();
                CustomerInfoEN temp = new CustomerInfoEN();
                for (int i = 0; i < aListCustomers.Count; i++)
                {

                        temp = new CustomerInfoEN();
                        temp.Address = aListCustomers[i].Address;
                        temp.Birthday = aListCustomers[i].Birthday;
                        temp.Citizen = aListCustomers[i].Citizen;

                        temp.Description = aListCustomers[i].Description;
                        temp.Disable = aListCustomers[i].Disable;
                        temp.Email = aListCustomers[i].Email;
                        temp.Gender = aListCustomers[i].Gender;

                        temp.ID = aListCustomers[i].ID;
                        temp.Identifier1 = aListCustomers[i].Identifier1;
                        temp.Identifier1CreatedDate = aListCustomers[i].Identifier1CreatedDate;
                        temp.Identifier2 = aListCustomers[i].Identifier2;
                        temp.Identifier2CreatedDate = aListCustomers[i].Identifier2CreatedDate;

                        temp.Identifier3 = aListCustomers[i].Identifier3;
                        temp.Identifier3CreatedDate = aListCustomers[i].Identifier3CreatedDate;
                        temp.Info = aListCustomers[i].Info;
                        temp.Name = aListCustomers[i].Name;
                        temp.Nationality = aListCustomers[i].Nationality;

                        temp.Note = aListCustomers[i].Note;
                        temp.PlaceOfIssue1 = aListCustomers[i].PlaceOfIssue1;
                        temp.PlaceOfIssue2 = aListCustomers[i].PlaceOfIssue2;
                        temp.PlaceOfIssue3 = aListCustomers[i].PlaceOfIssue3;
                        temp.Status = aListCustomers[i].Status;

                        temp.Tel = aListCustomers[i].Tel;
                        temp.Type = aListCustomers[i].Type;

                        temp.EnterGate = aListCustomers[i].EnterGate;
                        temp.PepoleRepresentative = aListCustomers[i].PepoleRepresentative;
                        temp.PurposeComeVietnam = aListCustomers[i].PurposeComeVietnam;
                        temp.DateEnterCountry = aListCustomers[i].DateEnterCountry;
                        temp.EnterGate = aListCustomers[i].EnterGate;
                        temp.TemporaryResidenceDate = aListCustomers[i].TemporaryResidenceDate;
                        temp.LeaveDate = aListCustomers[i].LeaveDate;
                        temp.Organization = aListCustomers[i].Organization;
                        temp.LimitDateEnterCountry = aListCustomers[i].LimitDateEnterCountry;

                        aList.Add(temp);
          

                }
                _alistCustomer.AddRange(aList);
                return _alistCustomer;
            }
            catch (Exception p)
            {
                throw new Exception("ItemChangeRoomEn_UpdateCustomer " + p.ToString());
            }
        }
       public List<CustomerInfoEN> UpdateCustomer(CustomerInfoEN aCustomers)
       {

           try
           {

                for (int i = 0; i < this._alistCustomer.Count; i++)
                {
                    if (this._alistCustomer[i].ID == aCustomers.ID)
                    {
            
                        this._alistCustomer[i].Address = aCustomers.Address;
                        this._alistCustomer[i].Birthday = aCustomers.Birthday;
                        this._alistCustomer[i].Citizen = aCustomers.Citizen;

                        this._alistCustomer[i].Description = aCustomers.Description;
                        this._alistCustomer[i].Disable = aCustomers.Disable;
                        this._alistCustomer[i].Email = aCustomers.Email;
                        this._alistCustomer[i].Gender = aCustomers.Gender;

                        this._alistCustomer[i].ID = aCustomers.ID;
                        this._alistCustomer[i].Identifier1 = aCustomers.Identifier1;
                        this._alistCustomer[i].Identifier1CreatedDate = aCustomers.Identifier1CreatedDate;
                        this._alistCustomer[i].Identifier2 = aCustomers.Identifier2;
                        this._alistCustomer[i].Identifier2CreatedDate = aCustomers.Identifier2CreatedDate;

                        this._alistCustomer[i].Identifier3 = aCustomers.Identifier3;
                        this._alistCustomer[i].Identifier3CreatedDate = aCustomers.Identifier3CreatedDate;
                        this._alistCustomer[i].Info = aCustomers.Info;
                        this._alistCustomer[i].Name = aCustomers.Name;
                        this._alistCustomer[i].Nationality = aCustomers.Nationality;

                        this._alistCustomer[i].Note = aCustomers.Note;
                        this._alistCustomer[i].PlaceOfIssue1 = aCustomers.PlaceOfIssue1;
                        this._alistCustomer[i].PlaceOfIssue2 = aCustomers.PlaceOfIssue2;
                        this._alistCustomer[i].PlaceOfIssue3 = aCustomers.PlaceOfIssue3;
                        this._alistCustomer[i].Status = aCustomers.Status;

                        this._alistCustomer[i].Tel = aCustomers.Tel;
                        this._alistCustomer[i].Type = aCustomers.Type;

                        this._alistCustomer[i].EnterGate = aCustomers.EnterGate;
                        this._alistCustomer[i].PepoleRepresentative = aCustomers.PepoleRepresentative;
                        this._alistCustomer[i].PurposeComeVietnam = aCustomers.PurposeComeVietnam;
                        this._alistCustomer[i].DateEnterCountry = aCustomers.DateEnterCountry;
                        this._alistCustomer[i].EnterGate = aCustomers.EnterGate;
                        this._alistCustomer[i].TemporaryResidenceDate = aCustomers.TemporaryResidenceDate;
                        this._alistCustomer[i].LeaveDate = aCustomers.LeaveDate;
                        this._alistCustomer[i].Organization = aCustomers.Organization;
                        this._alistCustomer[i].LimitDateEnterCountry = aCustomers.LimitDateEnterCountry;
                    }
                }
            
               return this._alistCustomer;
           }
           catch (Exception p)
           {
               throw new Exception("ItemChangeRoomEn_UpdateCustomer " + p.ToString());
           }
       }
       public void SetCost(decimal?  Cost)
       {
           if (Cost != null)
           {
               this._aBookingRooms.Cost = Cost;
           }
           else
           {
               this._aBookingRooms.Cost = null;
           }
       }
       public void SetCostRef(decimal Cost)
       {
           this._aBookingRooms.CostRef_Rooms = Cost;
       }
       public void SetNote(string note)
       {
           this._aBookingRooms.Note = note;
       }
       // set Type cho bookingRoom
       public void SetTypeBookingRoom(int Type)
       {
           this._aBookingRooms.Type = Type;
       }
        // ham SetCheckInPlan
        public void SetCheckInPlan(DateTime aCheckInPlan) 
        {
            this._aBookingRooms.CheckInPlan = aCheckInPlan;
        }
        // ham SetCheckOutPlan 
        public void SetCheckOutPlan(DateTime aCheckOutPlan) 
        {
            this._aBookingRooms.CheckOutPlan = aCheckOutPlan;
        }
        // ham SetCheckInActual
        public void SetCheckInActual(DateTime aCheckInActual) 
        {
            this._aBookingRooms.CheckInActual = aCheckInActual;
        }
        // ham SetCheckOutActual 
        public void SetCheckOutActual(DateTime aCheckOutActual) 
        {
            this._aBookingRooms.CheckOutActual = aCheckOutActual;
        }
        // ham get CheckInPlan
        public DateTime GetCheckInPlan()
        {
            return this._aBookingRooms.CheckInPlan;
        }
        // ham get CheckOutPlan   
        public DateTime GetCheckOutPlan() 
        {
            return this._aBookingRooms.CheckOutPlan;
        }
        // ham get CheckInActual 
        public DateTime GetCheckInActual() 
        {
            return this._aBookingRooms.CheckInActual;
        }
        public DateTime GetCheckOutActual() 
        {
            return this._aBookingRooms.CheckOutActual;                     
        }

        public int GetTypeBookingRoom()
        {
            return this._aBookingRooms.Type.GetValueOrDefault(3);
        }
        public decimal? GetTimeInUsed()
        {
            return this._aBookingRooms.TimeInUse;
        }
        public void SetTimeInUsed(decimal? TimeInUsed)
        {
            this._aBookingRooms.TimeInUse = TimeInUsed;
        }

        public double? GetAddTimeStart()
        {
            return this._aBookingRooms.AddTimeStart;
        }
        public void SetAddTimeStart(double? AddTimeStart)
        {
            this._aBookingRooms.AddTimeStart = AddTimeStart;
        }

        public double? GetAddTimeEnd()
        {
            return this._aBookingRooms.AddTimeEnd;
        }
        public void SetAddTimeEnd(double? AddTimeEnd)
        {
            this._aBookingRooms.AddTimeEnd = AddTimeEnd;
        }
        // ham kiem tra ID BookingRoom > 0 
       public void SetValue(ItemChangeRoomEN Item)
       {
           this.SetBookingRooms(Item.GetBookingRooms());
           this.AddCustomer(Item._alistCustomer);
           this.IsRoomInBookingR = Item.IsRoomInBookingR;
           this.IsRootRoom = Item.IsRootRoom;
       }
    }
}
