using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Entity;
using System.Net.Mail;
using System.Net;
using TeamNet.Data.FileExport;
using System.Windows.Forms;
using System.Globalization;


namespace BussinessLogic
{
    public class ReceptionTaskBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();

        public bool CheckIn(CheckInEN aCheckInEN)
        {
            try
            {
                //========================================================

                BookingRs aBookingRs = new BookingRs();


                aBookingRs.CreatedDate = DateTime.Now;
                aBookingRs.CustomerType = aCheckInEN.CustomerType;
                aBookingRs.BookingType = aCheckInEN.BookingType;
                aBookingRs.Note = aCheckInEN.Note;
                aBookingRs.IDCustomerGroup = aCheckInEN.IDCustomerGroup;
                aBookingRs.IDCustomer = aCheckInEN.IDCustomer;
                aBookingRs.IDSystemUser = aCheckInEN.IDSystemUser;
                aBookingRs.PayMenthod = aCheckInEN.PayMenthod;
                aBookingRs.StatusPay = aCheckInEN.StatusPay;
                aBookingRs.BookingMoney = aCheckInEN.BookingMoney;
                aBookingRs.ExchangeRate = aCheckInEN.ExchangeRate;
                aBookingRs.Status = aCheckInEN.Status;
                aBookingRs.Type = aCheckInEN.Type;
                aBookingRs.Disable = aCheckInEN.Disable;
                aBookingRs.Level = aCheckInEN.Level;
                aBookingRs.Subject = aCheckInEN.Subject;
                aBookingRs.Description = aCheckInEN.Description;
                aBookingRs.DatePay = aCheckInEN.DatePay;
                aBookingRs.DateEdit = aCheckInEN.DateEdit;

                //add new bookingRs
                BookingRsBO aBookingRsBO = new BookingRsBO();
                aBookingRsBO.Insert(aBookingRs);

                int IDBookingR = aBookingRs.ID;
                //==========================================================
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms;
                BookingRoomsMembers aBookingRoomsMembers;

                for (int i = 0; i < aCheckInEN.aListRoomMembers.Count; i++)
                {
                    aBookingRooms = new BookingRooms();
                    aBookingRooms.IDBookingR = IDBookingR;
                    aBookingRooms.CodeRoom = aCheckInEN.aListRoomMembers[i].RoomCode;
                    aBookingRooms.PercentTax = 10;
                    aBookingRooms.CostRef_Rooms = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                    aBookingRooms.Cost = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                    aBookingRooms.CheckInPlan = aCheckInEN.CheckInActual;
                    aBookingRooms.CheckInActual = aCheckInEN.CheckInActual;
                    aBookingRooms.CheckOutPlan = aCheckInEN.CheckOutPlan;
                    aBookingRooms.CheckOutActual = aCheckInEN.CheckOutActual;
                    aBookingRooms.StartTime = aCheckInEN.CheckInActual;
                    aBookingRooms.EndTime = aCheckInEN.CheckOutPlan;
                    aBookingRooms.BookingStatus = 1;
                    aBookingRooms.Type = 3; //Tính CheckIn sớm và CheckOut muộn
                    aBookingRooms.Status = aCheckInEN.Status;
                    aBookingRooms.PriceType = "G1";


                    //add new bookingRoom
                    aBookingRoomsBO.Insert(aBookingRooms);

                    int IDBookingRooms = aBookingRooms.ID;

                    aCheckInEN.aListRoomMembers[i].IDBookingRooms = IDBookingRooms;
                    //-----------------------------------------------------------
                    aBookingRoomsMembers = new BookingRoomsMembers();
                    aBookingRoomsMembers.IDBookingRoom = aCheckInEN.aListRoomMembers[i].IDBookingRooms;

                    BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                    for (int ii = 0; ii < aCheckInEN.aListRoomMembers[i].ListCustomer.Count; ii++)
                    {
                        aBookingRoomsMembers.IDCustomer = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID;
                        aBookingRoomsMembers.PurposeComeVietnam = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].PurposeComeVietnam;
                        aBookingRoomsMembers.DateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].DateEnterCountry;
                        aBookingRoomsMembers.EnterGate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].EnterGate;
                        aBookingRoomsMembers.TemporaryResidenceDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].TemporaryResidenceDate;
                        aBookingRoomsMembers.LimitDateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LimitDateEnterCountry;
                        aBookingRoomsMembers.Organization = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Organization;
                        aBookingRoomsMembers.LeaveDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LeaveDate;
                        //add new bookingRoomMember
                        aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.CheckInGoverment\n" + ex.ToString());
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Booking()
        //======================================================= 
        public bool Booking(BookingEN aBookingEN)
        {
            try
            {
                //========================================================

                BookingRs aBookingRs = new BookingRs();


                aBookingRs.CreatedDate = DateTime.Now;
                aBookingRs.CustomerType = aBookingEN.CustomerType;
                aBookingRs.BookingType = aBookingEN.BookingType;
                aBookingRs.Note = aBookingEN.Note;
                aBookingRs.IDCustomerGroup = aBookingEN.IDCustomerGroup;
                aBookingRs.IDCustomer = aBookingEN.IDCustomer;
                aBookingRs.IDSystemUser = aBookingEN.IDSystemUser;
                aBookingRs.PayMenthod = aBookingEN.PayMenthod;
                aBookingRs.StatusPay = aBookingEN.StatusPay;
                aBookingRs.BookingMoney = aBookingEN.BookingMoney;
                aBookingRs.ExchangeRate = aBookingEN.ExchangeRate;
                aBookingRs.Status = aBookingEN.Status;
                aBookingRs.Type = aBookingEN.Type;
                aBookingRs.Disable = aBookingEN.Disable;
                aBookingRs.Level = aBookingEN.Level;
                aBookingRs.Subject = aBookingEN.Subject;
                aBookingRs.Description = aBookingEN.Description;
                aBookingRs.DatePay = aBookingEN.DatePay;
                aBookingRs.DateEdit = aBookingEN.DateEdit;

                //add new bookingRs
                BookingRsBO aBookingRsBO = new BookingRsBO();
                aBookingRsBO.Insert(aBookingRs);

                int IDBookingR = aBookingRs.ID;
                //==========================================================
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms;
                BookingRoomsMembers aBookingRoomsMembers;

                for (int i = 0; i < aBookingEN.aListRoomsEN.Count; i++)
                {
                    aBookingRooms = new BookingRooms();
                    aBookingRooms.IDBookingR = IDBookingR;
                    aBookingRooms.CodeRoom = aBookingEN.aListRoomsEN[i].Code;
                    aBookingRooms.PercentTax = 10;
                    aBookingRooms.CostRef_Rooms = aBookingEN.aListRoomsEN[i].CostRef;
                    aBookingRooms.Cost = aBookingEN.aListRoomsEN[i].CostRef;
                    aBookingRooms.CheckInPlan = aBookingEN.CheckInActual;
                    aBookingRooms.CheckInActual = aBookingEN.CheckInActual;
                    aBookingRooms.CheckOutPlan = aBookingEN.CheckOutPlan;
                    aBookingRooms.CheckOutActual = aBookingEN.CheckOutActual;
                    aBookingRooms.StartTime = aBookingEN.CheckInActual;
                    aBookingRooms.EndTime = aBookingEN.CheckOutPlan;
                    aBookingRooms.BookingStatus = 1;
                    aBookingRooms.Status = aBookingEN.Status;
                    aBookingRooms.Type = 1;//Tính CheckIn sớm và CheckOut muộn
                    //add new bookingRoom
                    aBookingRoomsBO.Insert(aBookingRooms);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.Booking\n" + ex.ToString());
            }
        }

        public List<Rooms> GetListAvailableRooms(DateTime From, DateTime To, int Lang)
        {
            try
            {

                List<sp_Rooms_GetAvailable_ByTime_ByLang_Result> aListTemp = new List<sp_Rooms_GetAvailable_ByTime_ByLang_Result>();
                aListTemp = aDatabaseDA.sp_Rooms_GetAvailable_ByTime_ByLang(From, To, Lang).ToList();


                List<Rooms> aListReturn = new List<Rooms>();
                Rooms aRooms;

                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aRooms = new Rooms();
                    aRooms.ID = aListTemp[i].ID;
                    aRooms.Sku = aListTemp[i].Sku;
                    aRooms.Image = aListTemp[i].Image;
                    aRooms.Bed1 = aListTemp[i].Bed1;
                    aRooms.Bed2 = aListTemp[i].Bed2;
                    aRooms.Intro = aListTemp[i].Intro;
                    aRooms.Info = aListTemp[i].Info;
                    aRooms.CostRef = aListTemp[i].CostRef;
                    aRooms.CostUnit = aListTemp[i].CostUnit;
                    aRooms.Type = aListTemp[i].Type;
                    aRooms.Status = aListTemp[i].Status;
                    aRooms.Disable = aListTemp[i].Disable;
                    aRooms.Code = aListTemp[i].Code;
                    aRooms.IDLang = aListTemp[i].IDLang;
                    aListReturn.Add(aRooms);
                }

                return aListReturn;
            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.CheckInGoverment\n" + ex.ToString());
            }
        }

        public List<BookingRStatusPayViewEN> GetListUnPayBookingR(DateTime From, DateTime To, int CustomerType, string StatusPay)
        {
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            try
            {
                List<sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay_Result> aListSP = new List<sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay_Result>();
                aListSP = aDatabaseDA.sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay(From, To, CustomerType, StatusPay).ToList();

                List<BookingRStatusPayViewEN> aListBookingR = new List<BookingRStatusPayViewEN>();
                BookingRStatusPayViewEN aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();

                for (int i = 0; i < aListSP.Count; i++)
                {
                    aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();

                    aBookingRStatusPayViewEN.IDBookingR = aListSP[i].BookingRs_ID;
                    aBookingRStatusPayViewEN.CreatedDate = aListSP[i].BookingRs_CreatedDate;
                    aBookingRStatusPayViewEN.Customer_Name = aListSP[i].Customers_Name;
                    aBookingRStatusPayViewEN.Subject = aListSP[i].BookingRs_Subject;
                    aBookingRStatusPayViewEN.IDCustomer = Convert.ToInt32(aListSP[i].Customers_ID.ToString());
                    aBookingRStatusPayViewEN.IDCustomerGroup = Convert.ToInt32(aListSP[i].CustomerGroups_ID.ToString());
                    aBookingRStatusPayViewEN.CustomerGroups_Name = aListSP[i].CustomerGroups_Name;
                    aBookingRStatusPayViewEN.StatusPay = aListSP[i].BookingRs_StatusPay;
                    aBookingRStatusPayViewEN.BookingMoney = aListSP[i].BookingRs_BookingMoney;

                    switch (aBookingRStatusPayViewEN.StatusPay)
                    {
                        case 0:
                            aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa thanh toán";
                            break;
                        case 1:
                            aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Tạm ứng";
                            break;
                        default:
                            aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa xác định";
                            break;
                    }

                    aListBookingR.Add(aBookingRStatusPayViewEN);
                }
                return aListBookingR;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.GetListUnPayBookingR \n" + ex.ToString());
            }
        }

        public double CaculateBooking(NewPaymentEN aNewPayment, int IDBookingRoom, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                if (aNewPayment.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
                {
                    TimeSpan dis = EndTime.Subtract(StartTime);
                    double a = (dis.TotalHours) / 24;
                    double a1 = 0;
                    if (a < 1)
                    {
                        a1 = Math.Floor(a);
                    }
                    else
                    {
                        a1 = Math.Round(a);
                    }

                    double addtimeStart = 0;
                    double addtimeEnd = 0;
                    DateTime CheckIn = DateTime.Parse(StartTime.ToString("HH:mm"));
                    DateTime CheckOut = DateTime.Parse(EndTime.ToString("HH:mm"));

                    if (aNewPayment.aListBookingRoomUsed.Where(b => b.ID == IDBookingRoom).ToList()[0].Type == 3)//Tính checkin sớm và Checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }

                            else if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }

                        double result = a1 + addtimeEnd + addtimeStart;
                        if (result < 1)
                        {
                            return 1;
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else if (aNewPayment.aListBookingRoomUsed.Where(b => b.ID == IDBookingRoom).ToList()[0].Type == 0) //Không tính checkIn sớm và checkout muộn.
                    {

                        return a1;
                    }
                    else if (aNewPayment.aListBookingRoomUsed.Where(b => b.ID == IDBookingRoom).ToList()[0].Type == 2) //Tính checkin sớm ,không tính checkout muộn.
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }
                        }
                        return a1 + addtimeStart;


                    }
                    else if (aNewPayment.aListBookingRoomUsed.Where(b => b.ID == IDBookingRoom).ToList()[0].Type == 1) //Không tính checkin sớm ,tính checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }

                        return a1 + addtimeEnd;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }

        public double CaculateBooking(int IDBookingRoom, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);

                if (aBookingRooms != null)
                {
                    TimeSpan dis = EndTime.Subtract(StartTime);
                    double a = (dis.TotalHours) / 24;
                    double a1 = 0;
                    if (a < 1)
                    {
                        a1 = Math.Floor(a);
                    }
                    else
                    {
                        a1 = Math.Round(a);
                    }

                    double addtimeStart = 0;
                    double addtimeEnd = 0;
                    DateTime CheckIn = DateTime.Parse(StartTime.ToString("HH:mm"));
                    DateTime CheckOut = DateTime.Parse(EndTime.ToString("HH:mm"));

                    if (aBookingRooms.Type == 3)//Tính checkin sớm và Checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }

                            else if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }

                        double result = a1 + addtimeEnd + addtimeStart;
                        if (result < 1)
                        {
                            return 1;
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else if (aBookingRooms.Type == 0) //Không tính checkIn sớm và checkout muộn.
                    {
                        return a1;
                    }
                    else if (aBookingRooms.Type == 2) //Tính checkin sớm ,không tính checkout muộn.
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }
                        }

                        return a1 + addtimeStart;


                    }
                    else if (aBookingRooms.Type == 1) //Không tính checkin sớm ,tính checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }

                        return a1 + addtimeEnd;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }

        // Tính addtime CheckIn sớm, CheckOut Muộn, Thời gian ở
        public double GetAddTimeStart(int Type, DateTime StartTime)
        {
            try
            {
                double addtimeStart = 0;

                    DateTime CheckIn = DateTime.Parse(StartTime.ToString("HH:mm"));

                    if (Type == 3)//Tính checkin sớm và Checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }

                        }
                    }
                    else if (Type == 0) //Không tính checkIn sớm và checkout muộn.
                    {
                        return addtimeStart;
                    }
                    else if (Type == 1) //Không tính checkIn sớm và có tính checkout muộn.
                    {
                        return addtimeStart;
                    }
                    else if (Type == 2) //Tính checkin sớm ,không tính checkout muộn.
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 1) // checkIn som
                            {
                                if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeStart = aListCheckPoint[i].AddTime;
                                }
                            }
                        }

                        return addtimeStart;
                    }
                
                return addtimeStart;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }
        public double GetAddTimeStart(DateTime StartTime)
        {
            try
            {
                double addtimeStart = 0;

                DateTime CheckIn = DateTime.Parse(StartTime.ToString("HH:mm"));
                CheckPointBO aCheckPointBO = new CheckPointBO();
                List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                for (int i = 0; i < aListCheckPoint.Count; i++)
                {
                    if (aListCheckPoint[i].Type == 1) // checkIn som
                    {
                        if (aListCheckPoint[i].From <= CheckIn.TimeOfDay && CheckIn.TimeOfDay <= aListCheckPoint[i].To)
                        {
                            addtimeStart = aListCheckPoint[i].AddTime;
                        }
                    }

                }
                return addtimeStart;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }

        public double GetAddTimeEnd(int Type, DateTime EndTime)
        {
            try
            {

                double addtimeEnd = 0;

                    DateTime CheckOut = DateTime.Parse(EndTime.ToString("HH:mm"));

                    if (Type == 3)//Tính checkin sớm và Checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }


                        return addtimeEnd;

                    }
                    else if (Type == 0) //Không tính checkIn sớm và checkout muộn.
                    {
                        return addtimeEnd;
                    }
                    else if (Type == 1) //Không tính checkin sớm ,tính checkout muộn
                    {
                        CheckPointBO aCheckPointBO = new CheckPointBO();
                        List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                        for (int i = 0; i < aListCheckPoint.Count; i++)
                        {
                            if (aListCheckPoint[i].Type == 2) // CheckOut muon
                            {
                                if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                                {
                                    addtimeEnd = aListCheckPoint[i].AddTime;
                                }
                            }

                        }

                        return addtimeEnd;
                    }
                    else if (Type == 2) //Không tính checkIn sớm và checkout muộn.
                    {
                        return addtimeEnd;
                    }
               
                return addtimeEnd;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }
        public double GetAddTimeEnd(DateTime EndTime)
        {
            try
            {

                double addtimeEnd = 0;

                DateTime CheckOut = DateTime.Parse(EndTime.ToString("HH:mm"));

                CheckPointBO aCheckPointBO = new CheckPointBO();
                List<CheckPoints> aListCheckPoint = aCheckPointBO.Select_All();
                for (int i = 0; i < aListCheckPoint.Count; i++)
                {
                    if (aListCheckPoint[i].Type == 2) // CheckOut muon
                    {
                        if (aListCheckPoint[i].From <= CheckOut.TimeOfDay && CheckOut.TimeOfDay <= aListCheckPoint[i].To)
                        {
                            addtimeEnd = aListCheckPoint[i].AddTime;
                        }
                    }

                }

                return addtimeEnd;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }
        public double GetTimeInUsed(DateTime StartTime, DateTime EndTime)
        {
            try
            {
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                double a1 = 0;

                    TimeSpan dis = EndTime.Subtract(StartTime);
                    double a = (dis.TotalHours) / 24;

                    if (a < 1)
                    {
                        a1 = 1;
                    }
                    else
                    {
                        a1 = Math.Round(a);
                    }
                return a1;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CaculateBooking \n" + ex.ToString());
            }
        }

        public List<ServicesEN> GetListService_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups> aListTemp = new List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups>();
                aListTemp = aDatabaseDA.vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups.Where(v => v.BookingRooms_Services_IDBookingRoom == IDBookingRoom).ToList();
                List<ServicesEN> aListReturn = new List<ServicesEN>();
                ServicesEN aServicesEN;
                RoomsBO aRoomsBO = new RoomsBO();

                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aServicesEN = new ServicesEN();
                    aServicesEN.BookingRooms_Services_ID = aListTemp[i].BookingRooms_Services_ID;
                    aServicesEN.IDBookingRoomService = aListTemp[i].BookingRooms_Services_ID;
                    aServicesEN.IDBookingRoom = aListTemp[i].BookingRooms_Services_IDBookingRoom;
                    aServicesEN.CodeRoom = aListTemp[i].BookingRooms_CodeRoom;
                    Rooms aRooms = aRoomsBO.Select_ByCodeRoom(aListTemp[i].BookingRooms_CodeRoom, 1);
                    if (aRooms != null)
                    {
                        aServicesEN.Sku = aRooms.Sku;
                    }
                    aServicesEN.IDServiceGroup = aListTemp[i].ServiceGroups_ID;
                    aServicesEN.ServiceGroupName = aListTemp[i].ServiceGroups_Name;
                    aServicesEN.IDService = aListTemp[i].Services_ID;
                    aServicesEN.Date = aListTemp[i].BookingRooms_Services_Date;
                    aServicesEN.Name = aListTemp[i].Services_Name;
                    aServicesEN.Quantity = aListTemp[i].BookingRooms_Services_Quantity;
                    aServicesEN.Cost = aListTemp[i].BookingRooms_Services_Cost;
                    aServicesEN.CostRef_Service = aListTemp[i].Services_CostRef;
                    aServicesEN.PercentTax = aListTemp[i].BookingRooms_Services_PercentTax;
                    aListReturn.Insert(i, aServicesEN);
                }

                return aListReturn;

            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.GetListService_ByIDBookingRoom\n" + ex.ToString());
            }
        }


        //Hiennv
        public List<ServicesEN> GetListService_ByIDBookingRoom_ByStatus(int IDBookingRoom, int Status)
        {
            try
            {
                List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups> aListTemp = new List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups>();
                aListTemp = aDatabaseDA.vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups.Where(v => v.BookingRooms_Services_IDBookingRoom == IDBookingRoom && v.BookingRooms_Services_Status != Status).ToList();
                List<ServicesEN> aListReturn = new List<ServicesEN>();
                ServicesEN aServicesEN;
                RoomsBO aRoomsBO = new RoomsBO();

                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aServicesEN = new ServicesEN();
                    aServicesEN.BookingRooms_Services_ID = aListTemp[i].BookingRooms_Services_ID;

                    aServicesEN.IDBookingRoomService = aListTemp[i].BookingRooms_Services_ID;

                    aServicesEN.IDBookingRoom = aListTemp[i].BookingRooms_Services_IDBookingRoom;
                    aServicesEN.CodeRoom = aListTemp[i].BookingRooms_CodeRoom;
                    Rooms aRooms = aRoomsBO.Select_ByCodeRoom(aListTemp[i].BookingRooms_CodeRoom, 1);
                    if (aRooms != null)
                    {
                        aServicesEN.Sku = aRooms.Sku;
                    }
                    aServicesEN.ServiceGroupName = aListTemp[i].ServiceGroups_Name;
                    aServicesEN.IDServiceGroup = aListTemp[i].ServiceGroups_ID;
                    aServicesEN.IDService = aListTemp[i].Services_ID;
                    aServicesEN.Date = aListTemp[i].BookingRooms_Services_Date;
                    aServicesEN.Name = aListTemp[i].Services_Name;
                    aServicesEN.Quantity = aListTemp[i].BookingRooms_Services_Quantity;
                    aServicesEN.Cost = aListTemp[i].BookingRooms_Services_Cost;
                    aServicesEN.CostRef_Service = aListTemp[i].Services_CostRef;
                    aServicesEN.PercentTax = aListTemp[i].BookingRooms_Services_PercentTax;
                    aListReturn.Insert(i, aServicesEN);
                }

                return aListReturn;

            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.GetListService_ByIDBookingRoom_ByStatus\n" + ex.ToString());
            }
        }

        //Ngoc da sua lai ten ham 26/12/2014
        public List<BookingRStatusPayViewEN> GetListBookingRByStatus(DateTime? From, DateTime? To, int? CustomerType, string StatusPay)
        {
            List<sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay_Result> aListTemp = new List<sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay_Result>();
            aListTemp = aDatabaseDA.sp_BookingRsExt_GetInfo_ByTime_ByCustomerType_ByStatusPay(From, To, CustomerType, StatusPay).ToList();

            List<BookingRStatusPayViewEN> aListReturn = new List<BookingRStatusPayViewEN>();
            BookingRStatusPayViewEN aBookingRStatusPayViewEN;
            CompaniesBO aCompaniesBO = new CompaniesBO();
            List<Companies> aListCompaniesTemp = aCompaniesBO.Select_All();

            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            List<BookingRooms> aListBookingRoomTemp = aBookingRoomsBO.Select_All();


            for (int i = 0; i < aListTemp.Count; i++)
            {
                aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();
                aBookingRStatusPayViewEN.IDBookingR = aListTemp[i].BookingRs_ID;
                aBookingRStatusPayViewEN.CreatedDate = aListTemp[i].BookingRs_CreatedDate;
                aBookingRStatusPayViewEN.Customer_Name = aListTemp[i].Customers_Name;
                aBookingRStatusPayViewEN.Subject = aListTemp[i].BookingRs_Subject;
                aBookingRStatusPayViewEN.IDCustomer = aListTemp[i].Customers_ID;
                aBookingRStatusPayViewEN.IDCustomerGroup = aListTemp[i].CustomerGroups_ID;
                aBookingRStatusPayViewEN.BookingRs_Status = aListTemp[i].BookingRs_Status;
                aBookingRStatusPayViewEN.CustomerGroups_Name = aListTemp[i].CustomerGroups_Name;
                int IDCompany = !String.IsNullOrEmpty(aListTemp[i].Companies_ID.ToString()) ? Convert.ToInt32(aListTemp[i].Companies_ID) : 0;
                if (aListCompaniesTemp.Where(c => c.ID == IDCompany).ToList().Count > 0)
                {
                    aBookingRStatusPayViewEN.NameCompany = aListCompaniesTemp.Where(c => c.ID == IDCompany).ToList()[0].Name;
                }
                else
                {
                    aBookingRStatusPayViewEN.NameCompany = string.Empty;
                }
                aBookingRStatusPayViewEN.StatusPay = aListTemp[i].BookingRs_StatusPay;
                aBookingRStatusPayViewEN.BookingMoney = aListTemp[i].BookingRs_BookingMoney;
                aBookingRStatusPayViewEN.Sku = aListTemp[i].Rooms_Sku;
                aBookingRStatusPayViewEN.IDBookingH = aListTemp[i].BookingRs_BookingHs_IDBookingH;
                aBookingRStatusPayViewEN.BookingHs_Status = aListTemp[i].BookingHs_Status;
                aBookingRStatusPayViewEN.BookingHs_StatusPay = aListTemp[i].BookingHs_StatusPay;
                aBookingRStatusPayViewEN.BookingHs_Type = aListTemp[i].BookingHs_Type;
                aBookingRStatusPayViewEN.BookingHs_Disable = aListTemp[i].BookingHs_Disable;
                aBookingRStatusPayViewEN.BookingHs_Subject = aListTemp[i].BookingHs_Subject;


                List<BookingRooms> aListBookingRooms = aListBookingRoomTemp.Where(br => br.IDBookingR == aListTemp[i].BookingRs_ID && br.CodeRoom == aListTemp[i].Rooms_Code).ToList();
                if (aListBookingRooms.Count > 0)
                {
                    switch (aListBookingRooms[0].Status)
                    {
                        case 3:
                            aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check in";
                            break;
                        case 5:
                            aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Pending";
                            break;
                        case 7:
                            aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check out nhưng chưa thanh toán";
                            break;
                        case 8:
                            aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã thanh toán";
                            break;
                        default:
                            aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Chưa xác định";
                            break;
                    }
                    aBookingRStatusPayViewEN.IDBookingRoom = aListBookingRooms[0].ID;
                    aBookingRStatusPayViewEN.BookingRooms_CodeRoom = aListBookingRooms[0].CodeRoom;
                    aBookingRStatusPayViewEN.CheckInActual = aListBookingRooms[0].CheckInActual;
                    aBookingRStatusPayViewEN.CheckOut = aListBookingRooms[0].CheckOutPlan;
                }

                switch (aBookingRStatusPayViewEN.StatusPay)
                {
                    case 1:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa thanh toán";
                        break;
                    case 2:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Tạm ứng";
                        break;
                    case 3:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Đã thanh toán";
                        break;
                    default:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa xác định";
                        break;
                }
                switch (aListTemp[i].BookingRs_CustomerType)
                {
                    case 1:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Nhà nước";
                        break;
                    case 2:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Khách đoàn";
                        break;
                    case 3:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Khách lẻ";
                        break;
                    case 4:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Khách vãng lai";
                        break;
                    case 5:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Khách bộ ngoại giao";
                        break;
                    default:
                        aBookingRStatusPayViewEN.CustomerTypeDisplay = "Chưa xác định";
                        break;
                }
                aListReturn.Add(aBookingRStatusPayViewEN);

            }
            return aListReturn;
        }

        //=======================================================
        //Author: LinhTing
        //Function : Tìm danh sách hóa đơn ( BookingR) và phòng (BookingRoom) chưa thanh toán
        //=======================================================  
        public List<BookingRStatusPayViewEN> GetListUnPayBookingR_BookingRoom(DateTime From, DateTime To, int CustomerType, int StatusPay)
        {
            List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> aListTemp = new List<vw__PaymentInfo__BookingRs_BookingRooms_Customers>();
            int?[] BookingRoomStatus = new int?[] { 3, 5, 7 };

            if (StatusPay == 1) // chua thanh toan
            {
                aListTemp = aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(a => a.BookingRs_CreatedDate > From).Where(b => b.BookingRs_CreatedDate < To).Where(c => c.BookingRs_StatusPay == 1).Where(d => d.BookingRs_CustomerType == CustomerType).Where(e => BookingRoomStatus.Contains(e.BookingRooms_Status)).ToList();
            }
            else if (StatusPay == 2) // tam ung
            {
                aListTemp = aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(a => a.BookingRs_CreatedDate > From).Where(b => b.BookingRs_CreatedDate < To).Where(c => c.BookingRs_StatusPay == 2).Where(d => d.BookingRs_CustomerType == CustomerType).Where(e => BookingRoomStatus.Contains(e.BookingRooms_Status)).ToList();
            }
            else if (StatusPay == 3)//da thanh toan
            {
                aListTemp = aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(a => a.BookingRs_CreatedDate > From).Where(b => b.BookingRs_CreatedDate < To).Where(c => c.BookingRs_StatusPay == 3).Where(d => d.BookingRs_CustomerType == CustomerType).Where(d => d.BookingRooms_Status == 8).ToList();
            }
            List<BookingRStatusPayViewEN> aListReturn = new List<BookingRStatusPayViewEN>();
            BookingRStatusPayViewEN aBookingRStatusPayViewEN;
            CompaniesBO aCompaniesBO = new CompaniesBO();
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();

                aBookingRStatusPayViewEN.IDBookingR = aListTemp[i].BookingRs_ID;
                aBookingRStatusPayViewEN.CreatedDate = aListTemp[i].BookingRs_CreatedDate;
                aBookingRStatusPayViewEN.Customer_Name = aListTemp[i].Customers_Name;
                aBookingRStatusPayViewEN.Subject = aListTemp[i].BookingRs_Subject;
                aBookingRStatusPayViewEN.IDCustomer = aListTemp[i].Customers_ID;
                aBookingRStatusPayViewEN.IDCustomerGroup = aListTemp[i].CustomerGroups_ID;
                aBookingRStatusPayViewEN.BookingRs_Status = aListTemp[i].BookingRs_Status;

                int IDCompany = !String.IsNullOrEmpty(aListTemp[i].CustomerGroups_IDCompany.ToString()) ? Convert.ToInt32(aListTemp[i].CustomerGroups_IDCompany) : 0;

                Companies aCompanies = aCompaniesBO.Select_ByID(IDCompany);
                aBookingRStatusPayViewEN.NameCompany = aCompanies.Name;
                aBookingRStatusPayViewEN.CustomerGroups_Name = aListTemp[i].CustomerGroups_Name;
                aBookingRStatusPayViewEN.StatusPay = aListTemp[i].BookingRs_StatusPay;
                aBookingRStatusPayViewEN.BookingMoney = aListTemp[i].BookingRs_BookingMonye;
                aBookingRStatusPayViewEN.IDBookingRoom = aListTemp[i].BookingRooms_ID;
                aBookingRStatusPayViewEN.Sku = aListTemp[i].Rooms_Sku;
                aBookingRStatusPayViewEN.BookingStatus = aListTemp[i].BookingRooms_Status;
                aBookingRStatusPayViewEN.BookingRooms_CodeRoom = aListTemp[i].BookingRooms_CodeRoom;

                switch (aBookingRStatusPayViewEN.StatusPay)
                {
                    case 1:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa thanh toán";
                        break;
                    case 2:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Tạm ứng";
                        break;
                    case 3:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Đã thanh toán";
                        break;
                    default:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa xác định";
                        break;
                }
                switch (aBookingRStatusPayViewEN.BookingStatus)
                {
                    case 3:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check in";
                        break;
                    case 5:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Pending";
                        break;
                    case 7:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check out nhưng chưa thanh toán";
                        break;
                    case 8:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã thanh toán";
                        break;
                    default:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Chưa xác định";
                        break;
                }
                aListReturn.Add(aBookingRStatusPayViewEN);

            }
            return aListReturn;
        }
        //Hiennv
        public List<BookingRStatusPayViewEN> GetListUnPayBookingR_ByIDBookingR(int IDBookingR)
        {
            List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> aListTemp = new List<vw__PaymentInfo__BookingRs_BookingRooms_Customers>();
            int?[] BookingRoomStatus = new int?[] { 3, 5, 7 };

            aListTemp = aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.Where(c => c.BookingRs_ID == IDBookingR).Where(e => BookingRoomStatus.Contains(e.BookingRooms_Status)).ToList();

            List<BookingRStatusPayViewEN> aListReturn = new List<BookingRStatusPayViewEN>();
            BookingRStatusPayViewEN aBookingRStatusPayViewEN;
            CompaniesBO aCompaniesBO = new CompaniesBO();
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();

                aBookingRStatusPayViewEN.IDBookingR = aListTemp[i].BookingRs_ID;
                aBookingRStatusPayViewEN.CreatedDate = aListTemp[i].BookingRs_CreatedDate;
                aBookingRStatusPayViewEN.Customer_Name = aListTemp[i].Customers_Name;
                aBookingRStatusPayViewEN.Subject = aListTemp[i].BookingRs_Subject;
                aBookingRStatusPayViewEN.IDCustomer = aListTemp[i].Customers_ID;
                aBookingRStatusPayViewEN.IDCustomerGroup = aListTemp[i].CustomerGroups_ID;
                aBookingRStatusPayViewEN.BookingRs_Status = aListTemp[i].BookingRs_Status;

                int IDCompany = !String.IsNullOrEmpty(aListTemp[i].CustomerGroups_IDCompany.ToString()) ? Convert.ToInt32(aListTemp[i].CustomerGroups_IDCompany) : 0;

                Companies aCompanies = aCompaniesBO.Select_ByID(IDCompany);
                aBookingRStatusPayViewEN.NameCompany = aCompanies.Name;
                aBookingRStatusPayViewEN.CustomerGroups_Name = aListTemp[i].CustomerGroups_Name;
                aBookingRStatusPayViewEN.StatusPay = aListTemp[i].BookingRs_StatusPay;
                aBookingRStatusPayViewEN.BookingMoney = aListTemp[i].BookingRs_BookingMonye;
                aBookingRStatusPayViewEN.IDBookingRoom = aListTemp[i].BookingRooms_ID;
                aBookingRStatusPayViewEN.Sku = aListTemp[i].Rooms_Sku;
                aBookingRStatusPayViewEN.BookingStatus = aListTemp[i].BookingRooms_Status;
                aBookingRStatusPayViewEN.BookingRooms_CodeRoom = aListTemp[i].BookingRooms_CodeRoom;

                switch (aBookingRStatusPayViewEN.StatusPay)
                {
                    case 1:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa thanh toán";
                        break;
                    case 2:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Tạm ứng";
                        break;
                    case 3:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Đã thanh toán";
                        break;
                    default:
                        aBookingRStatusPayViewEN.BookingRStatusPayDisplay = "Chưa xác định";
                        break;
                }
                switch (aBookingRStatusPayViewEN.BookingStatus)
                {
                    case 3:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check in";
                        break;
                    case 5:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Pending";
                        break;
                    case 7:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã check out nhưng chưa thanh toán";
                        break;
                    case 8:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Đã thanh toán";
                        break;
                    default:
                        aBookingRStatusPayViewEN.BookingRoomStatusPayDisplay = "Chưa xác định";
                        break;
                }
                aListReturn.Add(aBookingRStatusPayViewEN);

            }
            return aListReturn;
        }

        //=======================================================
        //Author: LinhTing
        //Function : Tìm danh sách phòng + hóa đơn đã đặt
        //======================================================= 
        public List<BookingRStatusPayViewEN> GetListBookedBookingR_BookingRoom(DateTime From, DateTime To, int CustomerType, int BookingStatus)
        {
            List<vw__PaymentInfo__BookingRs_BookingRooms_Customers> aListTemp = new List<vw__PaymentInfo__BookingRs_BookingRooms_Customers>();
            aListTemp = aDatabaseDA.vw__PaymentInfo__BookingRs_BookingRooms_Customers.ToList().Where(a => a.BookingRs_CreatedDate > From).Where(b => b.BookingRs_CreatedDate < To).Where(c => c.BookingRooms_Status == BookingStatus).Where(d => d.BookingRs_CustomerType == CustomerType).ToList();
            List<BookingRStatusPayViewEN> aListReturn = new List<BookingRStatusPayViewEN>();
            BookingRStatusPayViewEN aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();
            CompaniesBO aCompaniesBO = new CompaniesBO();
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aBookingRStatusPayViewEN = new BookingRStatusPayViewEN();

                aBookingRStatusPayViewEN.IDBookingR = aListTemp[i].BookingRs_ID;
                aBookingRStatusPayViewEN.CreatedDate = aListTemp[i].BookingRs_CreatedDate;
                aBookingRStatusPayViewEN.Customer_Name = aListTemp[i].Customers_Name;
                aBookingRStatusPayViewEN.Subject = aListTemp[i].BookingRs_Subject;
                aBookingRStatusPayViewEN.IDCustomer = aListTemp[i].Customers_ID;
                aBookingRStatusPayViewEN.IDCustomerGroup = aListTemp[i].CustomerGroups_ID;


                int IDCompany = !String.IsNullOrEmpty(aListTemp[i].CustomerGroups_IDCompany.ToString()) ? Convert.ToInt32(aListTemp[i].CustomerGroups_IDCompany) : 0;

                Companies aCompanies = aCompaniesBO.Select_ByID(IDCompany);
                aBookingRStatusPayViewEN.NameCompany = aCompanies.Name;
                aBookingRStatusPayViewEN.CustomerGroups_Name = aListTemp[i].CustomerGroups_Name;
                aBookingRStatusPayViewEN.StatusPay = aListTemp[i].BookingRs_StatusPay;
                aBookingRStatusPayViewEN.BookingMoney = aListTemp[i].BookingRs_BookingMonye;
                aBookingRStatusPayViewEN.IDBookingRoom = aListTemp[i].BookingRooms_ID;
                aBookingRStatusPayViewEN.Sku = aListTemp[i].Rooms_Sku;
                aBookingRStatusPayViewEN.BookingStatus = aListTemp[i].BookingRooms_Status;
                aListReturn.Add(aBookingRStatusPayViewEN);
            }
            return aListReturn;
        }

        //Author : Hiennv
        public void InsertSystemUsersToDivisions(SystemUsers_DivisionsEN aSystemUsers_DivisionsEN)
        {
            try
            {
                SystemUsers_DivisionsBO aSystemUsers_DivisionsBO;
                List<SystemUsers_Divisions> aListTemp;
                SystemUsers_Divisions aSystemUsers_Divisions = new SystemUsers_Divisions();
                aSystemUsers_Divisions.CreatedDate = DateTime.Now;
                aSystemUsers_Divisions.AvaiableDate = aSystemUsers_DivisionsEN.AvaiableDate;
                aSystemUsers_Divisions.Type = aSystemUsers_DivisionsEN.Type;
                aSystemUsers_Divisions.Status = aSystemUsers_DivisionsEN.Status;
                aSystemUsers_Divisions.Disable = aSystemUsers_DivisionsEN.Disable;
                aSystemUsers_Divisions.ExpireDate = aSystemUsers_DivisionsEN.ExpireDate;

                for (int i = 0; i < aSystemUsers_DivisionsEN.aListDivisionsEN.Count; i++)
                {
                    aSystemUsers_Divisions.IDDivision = aSystemUsers_DivisionsEN.aListDivisionsEN[i].ID;


                    for (int j = 0; j < aSystemUsers_DivisionsEN.aListDivisionsEN[i].aListSystemUsers.Count; j++)
                    {
                        aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                        aSystemUsers_Divisions.IDSystemUser = aSystemUsers_DivisionsEN.aListDivisionsEN[i].aListSystemUsers[j].ID;
                        aListTemp = new List<SystemUsers_Divisions>();
                        aListTemp = aSystemUsers_DivisionsBO.Select_ByIDSystemUsersAndIDDivisionAndDisable(aSystemUsers_DivisionsEN.aListDivisionsEN[i].ID, aSystemUsers_DivisionsEN.aListDivisionsEN[i].aListSystemUsers[j].ID, false);
                        if (aListTemp.Count > 0)
                        {
                            foreach (SystemUsers_Divisions item in aListTemp)
                            {

                                SystemUsers_Divisions aTemp = aSystemUsers_DivisionsBO.Select_ByID(item.ID);
                                aTemp.Disable = true;
                                aSystemUsers_DivisionsBO.Update(aTemp);
                            }
                        }
                        aDatabaseDA.SystemUsers_Divisions.Add(aSystemUsers_Divisions);
                        aDatabaseDA.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.InsertSystemUsersToDivisions :" + ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public void AddSystemUserInformation(SystemUsersEN aSystemUsersEN)
        {
            try
            {
                SystemUsers aSystemUsers = new SystemUsers();
                aSystemUsers.UserGroup = aSystemUsersEN.UserGroup;
                aSystemUsers.Email = aSystemUsersEN.Email;
                aSystemUsers.Username = aSystemUsersEN.Username;
                aSystemUsers.Name = aSystemUsersEN.Name;
                aSystemUsers.Password = aSystemUsersEN.Password;
                aSystemUsers.Birthday = aSystemUsersEN.Birthday;
                aSystemUsers.Identifier1 = aSystemUsersEN.Identifier1;
                aSystemUsers.Identifier2 = aSystemUsersEN.Identifier2;
                aSystemUsers.Identifier3 = aSystemUsersEN.Identifier3;
                aSystemUsers.Image = aSystemUsersEN.Image;
                aSystemUsers.Gender = aSystemUsersEN.Gender;
                aSystemUsers.IDRefAnotherSystem = aSystemUsersEN.IDRefAnotherSystem;
                aSystemUsers.IDRefMailSystem = aSystemUsersEN.IDRefMailSystem;
                aSystemUsers.Type = aSystemUsersEN.Type;
                aSystemUsers.Status = aSystemUsersEN.Status;
                aSystemUsers.Disable = aSystemUsersEN.Disable;
                aSystemUsers.Identifier1CreatedDate = aSystemUsersEN.Identifier1CreatedDate;
                aSystemUsers.Identifier2CreatedDate = aSystemUsersEN.Identifier2CreatedDate;
                aSystemUsers.Identifier3CreatedDate = aSystemUsersEN.Identifier3CreatedDate;
                aSystemUsers.PlaceOfIssue1 = aSystemUsersEN.PlaceOfIssue1;
                aSystemUsers.PlaceOfIssue2 = aSystemUsersEN.PlaceOfIssue2;
                aSystemUsers.PlaceOfIssue3 = aSystemUsersEN.PlaceOfIssue3;
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                //lay ID cua systemUser vua tao

                int ID = aSystemUsersBO.Insert(aSystemUsers);


                SystemUserExts aSystemUserExts = new SystemUserExts();
                aSystemUserExts.BirthPlace = aSystemUsersEN.aSystemUserExts.BirthPlace;
                aSystemUserExts.Hometown = aSystemUsersEN.aSystemUserExts.Hometown;
                aSystemUserExts.Address = aSystemUsersEN.aSystemUserExts.Address;
                aSystemUserExts.InsuranceNumber = aSystemUsersEN.aSystemUserExts.InsuranceNumber;
                aSystemUserExts.YearJob = aSystemUsersEN.aSystemUserExts.YearJob;
                aSystemUserExts.YearDepartment = aSystemUsersEN.aSystemUserExts.YearDepartment;
                aSystemUserExts.YearPayroll = aSystemUsersEN.aSystemUserExts.YearPayroll;
                aSystemUserExts.YearUnemploymentInsurance = aSystemUsersEN.aSystemUserExts.YearUnemploymentInsurance;
                aSystemUserExts.DifferenceContact = aSystemUsersEN.aSystemUserExts.DifferenceContact;
                aSystemUserExts.Type = aSystemUsersEN.aSystemUserExts.Type;
                aSystemUserExts.Status = aSystemUsersEN.aSystemUserExts.Status;
                aSystemUserExts.Disable = aSystemUsersEN.aSystemUserExts.Disable;
                aSystemUserExts.IDSystemUser = ID;
                aSystemUserExts.Recruitment = aSystemUsersEN.aSystemUserExts.Recruitment;
                aSystemUserExts.PermanentResidence = aSystemUsersEN.aSystemUserExts.PermanentResidence;
                aSystemUserExts.CommunistPartyDate = aSystemUsersEN.aSystemUserExts.CommunistPartyDate;
                aSystemUserExts.YouthUnionDate = aSystemUsersEN.aSystemUserExts.YouthUnionDate;
                aSystemUserExts.EnlistmentDate = aSystemUsersEN.aSystemUserExts.EnlistmentDate;
                aSystemUserExts.DemobilizedDate = aSystemUsersEN.aSystemUserExts.DemobilizedDate;
                aSystemUserExts.MartyrsFamily = aSystemUsersEN.aSystemUserExts.MartyrsFamily;
                aSystemUserExts.WoundedFamily = aSystemUsersEN.aSystemUserExts.WoundedFamily;
                aSystemUserExts.LaborFamily = aSystemUsersEN.aSystemUserExts.LaborFamily;
                aSystemUserExts.HightestAppellation = aSystemUsersEN.aSystemUserExts.HightestAppellation;


                SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
                aSystemUserExtsBO.Insert(aSystemUserExts);

                FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
                FamilyMembers aFamilyMembers;
                foreach (FamilyMembers familyMembers in aSystemUsersEN.aListFamilyMembersExtEN)
                {
                    aFamilyMembers = new FamilyMembers();
                    aFamilyMembers.Name = familyMembers.Name;
                    aFamilyMembers.Birthday = familyMembers.Birthday;
                    aFamilyMembers.RelationType = familyMembers.RelationType;
                    aFamilyMembers.Info = familyMembers.Info;
                    aFamilyMembers.IDSystemUser = ID;

                    aFamilyMembersBO.Insert(aFamilyMembers);


                }
                SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
                SystemUsers_Certificates aSystemUsers_Certificates;
                foreach (SystemUsers_Certificates systemUsers_Certificates in aSystemUsersEN.aListSystemUsers_CertificatesEN)
                {
                    aSystemUsers_Certificates = new SystemUsers_Certificates();

                    aSystemUsers_Certificates.Level = systemUsers_Certificates.Level;
                    aSystemUsers_Certificates.CreatedDate = systemUsers_Certificates.CreatedDate;
                    aSystemUsers_Certificates.ExpirationDate = systemUsers_Certificates.ExpirationDate;
                    aSystemUsers_Certificates.Organization = systemUsers_Certificates.Organization;
                    aSystemUsers_Certificates.TrainingType = systemUsers_Certificates.TrainingType;
                    aSystemUsers_Certificates.IDCertificate = systemUsers_Certificates.IDCertificate;
                    aSystemUsers_Certificates.IDSystemUser = ID;

                    aSystemUsers_CertificatesBO.Insert(aSystemUsers_Certificates);
                }
                AuditHistoriesBO aAuditHistoriesBO = new AuditHistoriesBO();
                AuditHistories aAuditHistories;
                foreach (AuditHistories auditHistories in aSystemUsersEN.aListAuditHistories)
                {
                    aAuditHistories = new AuditHistories();
                    aAuditHistories.From = auditHistories.From;
                    aAuditHistories.To = auditHistories.To;
                    aAuditHistories.Note = auditHistories.Note;
                    aAuditHistories.Type = auditHistories.Type;
                    aAuditHistories.IDSystemUser = ID;

                    aAuditHistoriesBO.Insert(aAuditHistories);

                }

                RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
                RewardAndPunishments aRewardAndPunishments;
                foreach (RewardAndPunishments rewardAndPunishments in aSystemUsersEN.aListRewardAndPunishments)
                {
                    aRewardAndPunishments = new RewardAndPunishments();
                    aRewardAndPunishments.Type = rewardAndPunishments.Type;
                    aRewardAndPunishments.Subject = rewardAndPunishments.Subject;
                    aRewardAndPunishments.Description = rewardAndPunishments.Description;
                    aRewardAndPunishments.CreatedDate = rewardAndPunishments.CreatedDate;
                    aRewardAndPunishments.DecisionDate = rewardAndPunishments.DecisionDate;
                    aRewardAndPunishments.NumberDecision = rewardAndPunishments.NumberDecision;
                    aRewardAndPunishments.DecisionLevel = rewardAndPunishments.DecisionLevel;
                    aRewardAndPunishments.Status = rewardAndPunishments.Status;
                    aRewardAndPunishments.Disable = rewardAndPunishments.Disable;
                    aRewardAndPunishments.IDSystemUser = ID;

                    aRewardAndPunishmentsBO.Insert(aRewardAndPunishments);
                }

                DocumentSystemUsersBO aDocumentSystemUsersBO = new DocumentSystemUsersBO();
                DocumentSystemUsers aDocumentSystemUsers;
                foreach (DocumentSystemUsers documentSystemUsers in aSystemUsersEN.aListDocumentSystemUsers)
                {
                    aDocumentSystemUsers = new DocumentSystemUsers();
                    aDocumentSystemUsers.Name = documentSystemUsers.Name;
                    aDocumentSystemUsers.FileData = documentSystemUsers.FileData;
                    aDocumentSystemUsers.Note = documentSystemUsers.Note;
                    aDocumentSystemUsers.Type = documentSystemUsers.Type;
                    aDocumentSystemUsers.Status = documentSystemUsers.Status;
                    aDocumentSystemUsers.Disable = documentSystemUsers.Disable;
                    aDocumentSystemUsers.IDSystemUser = ID;

                    aDocumentSystemUsersBO.Insert(aDocumentSystemUsers);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.AddSystemUserInformation :" + ex.Message.ToString()));
            }
        }


        //Author : Hiennv
        public void UpdateSystemUserInformation(SystemUsersEN aSystemUsersEN)
        {
            int status = -1;
            SystemUsersBO aSystemUsersBO = new SystemUsersBO();
            SystemUsers aSystemUsers_Old = new SystemUsers();
            SystemUsers aSystemUsers = new SystemUsers();

            SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
            //SystemUserExts aSystemUserExts = new SystemUserExts();
            SystemUserExts aSystemUserExts_Old = new SystemUserExts();
            try
            {


                aSystemUsers = aSystemUsersBO.Select_ByID(aSystemUsersEN.ID);
                aSystemUsers_Old = aSystemUsers;

                aSystemUsers.UserGroup = aSystemUsersEN.UserGroup;
                aSystemUsers.Email = aSystemUsersEN.Email;
                aSystemUsers.Username = aSystemUsersEN.Username;
                aSystemUsers.Name = aSystemUsersEN.Name;
                aSystemUsers.Password = aSystemUsersEN.Password;
                aSystemUsers.Birthday = aSystemUsersEN.Birthday;
                aSystemUsers.Identifier1 = aSystemUsersEN.Identifier1;
                aSystemUsers.Identifier2 = aSystemUsersEN.Identifier2;
                aSystemUsers.Identifier3 = aSystemUsersEN.Identifier3;
                aSystemUsers.Image = aSystemUsersEN.Image;
                aSystemUsers.Gender = aSystemUsersEN.Gender;
                aSystemUsers.IDRefAnotherSystem = aSystemUsersEN.IDRefAnotherSystem;
                aSystemUsers.IDRefMailSystem = aSystemUsersEN.IDRefMailSystem;
                aSystemUsers.Type = aSystemUsersEN.Type;
                aSystemUsers.Status = aSystemUsersEN.Status;
                aSystemUsers.Disable = aSystemUsersEN.Disable;
                aSystemUsers.Identifier1CreatedDate = aSystemUsersEN.Identifier1CreatedDate;
                aSystemUsers.Identifier2CreatedDate = aSystemUsersEN.Identifier2CreatedDate;
                aSystemUsers.Identifier3CreatedDate = aSystemUsersEN.Identifier3CreatedDate;
                aSystemUsers.PlaceOfIssue1 = aSystemUsersEN.PlaceOfIssue1;
                aSystemUsers.PlaceOfIssue2 = aSystemUsersEN.PlaceOfIssue2;
                aSystemUsers.PlaceOfIssue3 = aSystemUsersEN.PlaceOfIssue3;

                status = aSystemUsersBO.Update(aSystemUsers);


                if (status > 0)
                {

                    SystemUserExts aSystemUserExts = aSystemUserExtsBO.Select_ByID(aSystemUsersEN.aSystemUserExts.ID);
                    //aSystemUserExts_Old = aSystemUserExts;

                    if (aSystemUserExts != null)
                    {
                        aSystemUserExts.BirthPlace = aSystemUsersEN.aSystemUserExts.BirthPlace;
                        aSystemUserExts.Hometown = aSystemUsersEN.aSystemUserExts.Hometown;
                        aSystemUserExts.Address = aSystemUsersEN.aSystemUserExts.Address;
                        aSystemUserExts.InsuranceNumber = aSystemUsersEN.aSystemUserExts.InsuranceNumber;
                        aSystemUserExts.YearJob = aSystemUsersEN.aSystemUserExts.YearJob;
                        aSystemUserExts.YearDepartment = aSystemUsersEN.aSystemUserExts.YearDepartment;
                        aSystemUserExts.YearPayroll = aSystemUsersEN.aSystemUserExts.YearPayroll;
                        aSystemUserExts.YearUnemploymentInsurance = aSystemUsersEN.aSystemUserExts.YearUnemploymentInsurance;
                        aSystemUserExts.DifferenceContact = aSystemUsersEN.aSystemUserExts.DifferenceContact;
                        aSystemUserExts.Type = aSystemUsersEN.aSystemUserExts.Type;
                        aSystemUserExts.Status = aSystemUsersEN.aSystemUserExts.Status;
                        aSystemUserExts.Disable = aSystemUsersEN.aSystemUserExts.Disable;
                        aSystemUserExts.IDSystemUser = aSystemUsers.ID;
                        aSystemUserExts.Recruitment = aSystemUsersEN.aSystemUserExts.Recruitment;
                        aSystemUserExts.PermanentResidence = aSystemUsersEN.aSystemUserExts.PermanentResidence;
                        aSystemUserExts.CommunistPartyDate = aSystemUsersEN.aSystemUserExts.CommunistPartyDate;
                        aSystemUserExts.YouthUnionDate = aSystemUsersEN.aSystemUserExts.YouthUnionDate;
                        aSystemUserExts.EnlistmentDate = aSystemUsersEN.aSystemUserExts.EnlistmentDate;
                        aSystemUserExts.DemobilizedDate = aSystemUsersEN.aSystemUserExts.DemobilizedDate;
                        aSystemUserExts.MartyrsFamily = aSystemUsersEN.aSystemUserExts.MartyrsFamily;
                        aSystemUserExts.WoundedFamily = aSystemUsersEN.aSystemUserExts.WoundedFamily;
                        aSystemUserExts.LaborFamily = aSystemUsersEN.aSystemUserExts.LaborFamily;
                        aSystemUserExts.HightestAppellation = aSystemUsersEN.aSystemUserExts.HightestAppellation;
                        status = aSystemUserExtsBO.Update(aSystemUserExts);

                    }
                    else
                    {
                        aSystemUserExts = new SystemUserExts();
                        aSystemUserExts.BirthPlace = aSystemUsersEN.aSystemUserExts.BirthPlace;
                        aSystemUserExts.Hometown = aSystemUsersEN.aSystemUserExts.Hometown;
                        aSystemUserExts.Address = aSystemUsersEN.aSystemUserExts.Address;
                        aSystemUserExts.InsuranceNumber = aSystemUsersEN.aSystemUserExts.InsuranceNumber;
                        aSystemUserExts.YearJob = aSystemUsersEN.aSystemUserExts.YearJob;
                        aSystemUserExts.YearDepartment = aSystemUsersEN.aSystemUserExts.YearDepartment;
                        aSystemUserExts.YearPayroll = aSystemUsersEN.aSystemUserExts.YearPayroll;
                        aSystemUserExts.YearUnemploymentInsurance = aSystemUsersEN.aSystemUserExts.YearUnemploymentInsurance;
                        aSystemUserExts.DifferenceContact = aSystemUsersEN.aSystemUserExts.DifferenceContact;
                        aSystemUserExts.Type = aSystemUsersEN.aSystemUserExts.Type;
                        aSystemUserExts.Status = aSystemUsersEN.aSystemUserExts.Status;
                        aSystemUserExts.Disable = aSystemUsersEN.aSystemUserExts.Disable;
                        aSystemUserExts.IDSystemUser = aSystemUsers.ID;
                        aSystemUserExts.Recruitment = aSystemUsersEN.aSystemUserExts.Recruitment;
                        aSystemUserExts.PermanentResidence = aSystemUsersEN.aSystemUserExts.PermanentResidence;
                        aSystemUserExts.CommunistPartyDate = aSystemUsersEN.aSystemUserExts.CommunistPartyDate;
                        aSystemUserExts.YouthUnionDate = aSystemUsersEN.aSystemUserExts.YouthUnionDate;
                        aSystemUserExts.EnlistmentDate = aSystemUsersEN.aSystemUserExts.EnlistmentDate;
                        aSystemUserExts.DemobilizedDate = aSystemUsersEN.aSystemUserExts.DemobilizedDate;
                        aSystemUserExts.MartyrsFamily = aSystemUsersEN.aSystemUserExts.MartyrsFamily;
                        aSystemUserExts.WoundedFamily = aSystemUsersEN.aSystemUserExts.WoundedFamily;
                        aSystemUserExts.LaborFamily = aSystemUsersEN.aSystemUserExts.LaborFamily;
                        aSystemUserExts.HightestAppellation = aSystemUsersEN.aSystemUserExts.HightestAppellation;
                        status = aSystemUserExtsBO.Insert(aSystemUserExts);
                    }


                    FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
                    foreach (FamilyMembers familyMembers in aSystemUsersEN.aListFamilyMembersExtEN)
                    {
                        FamilyMembers aFamilyMembers = aFamilyMembersBO.Select_ByID(familyMembers.ID);
                        if (aFamilyMembers == null)
                        {
                            aFamilyMembers = new FamilyMembers();
                            aFamilyMembers.Name = familyMembers.Name;
                            aFamilyMembers.Birthday = familyMembers.Birthday;
                            aFamilyMembers.RelationType = familyMembers.RelationType;
                            aFamilyMembers.Info = familyMembers.Info;
                            aFamilyMembers.IDSystemUser = aSystemUsers.ID;

                            int a = aFamilyMembersBO.Insert(aFamilyMembers);
                            if (a <= 0)
                            {
                                throw new Exception("Lỗi khi thêm dữ liệu thành viên gia đình");
                            }
                        }
                        else
                        {
                            aFamilyMembers.Name = familyMembers.Name;
                            aFamilyMembers.Birthday = familyMembers.Birthday;
                            aFamilyMembers.RelationType = familyMembers.RelationType;
                            aFamilyMembers.Info = familyMembers.Info;
                            aFamilyMembers.IDSystemUser = familyMembers.IDSystemUser;
                            aFamilyMembersBO.Update(aFamilyMembers);
                        }
                    }
                    SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
                    foreach (SystemUsers_Certificates systemUsers_Certificates in aSystemUsersEN.aListSystemUsers_CertificatesEN)
                    {
                        SystemUsers_Certificates aSystemUsers_Certificates = aSystemUsers_CertificatesBO.Select_ByID(systemUsers_Certificates.ID);
                        if (aSystemUsers_Certificates == null)
                        {
                            aSystemUsers_Certificates = new SystemUsers_Certificates();
                            aSystemUsers_Certificates.Level = systemUsers_Certificates.Level;
                            aSystemUsers_Certificates.CreatedDate = systemUsers_Certificates.CreatedDate;
                            aSystemUsers_Certificates.ExpirationDate = systemUsers_Certificates.ExpirationDate;
                            aSystemUsers_Certificates.Organization = systemUsers_Certificates.Organization;
                            aSystemUsers_Certificates.TrainingType = systemUsers_Certificates.TrainingType;
                            aSystemUsers_Certificates.IDCertificate = systemUsers_Certificates.IDCertificate;
                            aSystemUsers_Certificates.IDSystemUser = aSystemUsers.ID;
                            aSystemUsers_CertificatesBO.Insert(aSystemUsers_Certificates);
                        }
                        else
                        {
                            aSystemUsers_Certificates.Level = systemUsers_Certificates.Level;
                            aSystemUsers_Certificates.CreatedDate = systemUsers_Certificates.CreatedDate;
                            aSystemUsers_Certificates.ExpirationDate = systemUsers_Certificates.ExpirationDate;
                            aSystemUsers_Certificates.Organization = systemUsers_Certificates.Organization;
                            aSystemUsers_Certificates.TrainingType = systemUsers_Certificates.TrainingType;
                            aSystemUsers_Certificates.IDCertificate = systemUsers_Certificates.IDCertificate;
                            aSystemUsers_Certificates.IDSystemUser = systemUsers_Certificates.IDSystemUser;
                            aSystemUsers_CertificatesBO.Update(aSystemUsers_Certificates);
                        }
                    }

                    AuditHistoriesBO aAuditHistoriesBO = new AuditHistoriesBO();

                    foreach (AuditHistories auditHistories in aSystemUsersEN.aListAuditHistories)
                    {
                        AuditHistories aAuditHistories = aAuditHistoriesBO.Select_ByID(auditHistories.ID);
                        if (aAuditHistories == null)
                        {
                            aAuditHistories = new AuditHistories();
                            aAuditHistories.From = auditHistories.From;
                            aAuditHistories.To = auditHistories.To;
                            aAuditHistories.Note = auditHistories.Note;
                            aAuditHistories.Type = auditHistories.Type;
                            aAuditHistories.IDSystemUser = aSystemUsers.ID;
                            aAuditHistoriesBO.Insert(aAuditHistories);
                        }
                        else
                        {
                            aAuditHistories.From = auditHistories.From;
                            aAuditHistories.To = auditHistories.To;
                            aAuditHistories.Note = auditHistories.Note;
                            aAuditHistories.Type = auditHistories.Type;
                            aAuditHistories.IDSystemUser = auditHistories.IDSystemUser;
                            aAuditHistoriesBO.Update(aAuditHistories);
                        }

                    }

                    RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();

                    foreach (RewardAndPunishments rewardAndPunishments in aSystemUsersEN.aListRewardAndPunishments)
                    {
                        RewardAndPunishments aRewardAndPunishments = aRewardAndPunishmentsBO.Select_ByID(rewardAndPunishments.ID);
                        if (aRewardAndPunishments == null)
                        {
                            aRewardAndPunishments = new RewardAndPunishments();
                            aRewardAndPunishments.Type = rewardAndPunishments.Type;
                            aRewardAndPunishments.Subject = rewardAndPunishments.Subject;
                            aRewardAndPunishments.Description = rewardAndPunishments.Description;
                            aRewardAndPunishments.CreatedDate = rewardAndPunishments.CreatedDate;
                            aRewardAndPunishments.DecisionDate = rewardAndPunishments.DecisionDate;
                            aRewardAndPunishments.NumberDecision = rewardAndPunishments.NumberDecision;
                            aRewardAndPunishments.DecisionLevel = rewardAndPunishments.DecisionLevel;
                            aRewardAndPunishments.Status = rewardAndPunishments.Status;
                            aRewardAndPunishments.Disable = rewardAndPunishments.Disable;
                            aRewardAndPunishments.IDSystemUser = aSystemUsers.ID;
                            aRewardAndPunishmentsBO.Insert(aRewardAndPunishments);
                        }
                        else
                        {
                            aRewardAndPunishments.Type = rewardAndPunishments.Type;
                            aRewardAndPunishments.Subject = rewardAndPunishments.Subject;
                            aRewardAndPunishments.Description = rewardAndPunishments.Description;
                            aRewardAndPunishments.CreatedDate = rewardAndPunishments.CreatedDate;
                            aRewardAndPunishments.DecisionDate = rewardAndPunishments.DecisionDate;
                            aRewardAndPunishments.NumberDecision = rewardAndPunishments.NumberDecision;
                            aRewardAndPunishments.DecisionLevel = rewardAndPunishments.DecisionLevel;
                            aRewardAndPunishments.Status = rewardAndPunishments.Status;
                            aRewardAndPunishments.Disable = rewardAndPunishments.Disable;
                            aRewardAndPunishments.IDSystemUser = rewardAndPunishments.IDSystemUser;
                            aRewardAndPunishmentsBO.Update(aRewardAndPunishments);
                        }
                    }

                    DocumentSystemUsersBO aDocumentSystemUsersBO = new DocumentSystemUsersBO();
                    foreach (DocumentSystemUsers documentSystemUsers in aSystemUsersEN.aListDocumentSystemUsers)
                    {
                        DocumentSystemUsers aDocumentSystemUsers = aDocumentSystemUsersBO.Select_ByID(documentSystemUsers.ID);
                        if (aDocumentSystemUsers == null)
                        {
                            aDocumentSystemUsers = new DocumentSystemUsers();
                            aDocumentSystemUsers.Name = documentSystemUsers.Name;
                            aDocumentSystemUsers.FileData = documentSystemUsers.FileData;
                            aDocumentSystemUsers.Note = documentSystemUsers.Note;
                            aDocumentSystemUsers.Type = documentSystemUsers.Type;
                            aDocumentSystemUsers.Status = documentSystemUsers.Status;
                            aDocumentSystemUsers.Disable = documentSystemUsers.Disable;
                            aDocumentSystemUsers.IDSystemUser = aSystemUsers.ID;
                            aDocumentSystemUsersBO.Insert(aDocumentSystemUsers);
                        }
                        else
                        {
                            aDocumentSystemUsers.Name = documentSystemUsers.Name;
                            aDocumentSystemUsers.FileData = documentSystemUsers.FileData;
                            aDocumentSystemUsers.Note = documentSystemUsers.Note;
                            aDocumentSystemUsers.Type = documentSystemUsers.Type;
                            aDocumentSystemUsers.Status = documentSystemUsers.Status;
                            aDocumentSystemUsers.Disable = documentSystemUsers.Disable;
                            aDocumentSystemUsers.IDSystemUser = documentSystemUsers.IDSystemUser;
                            aDocumentSystemUsersBO.Update(aDocumentSystemUsers);
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                aSystemUsersBO.Update(aSystemUsers_Old);
                aSystemUserExtsBO.Update(aSystemUserExts_Old);

                throw new Exception(string.Format("ReceptionTaskBO.UpdateSystemUserInformation :" + ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public List<RoomExtStatusEN> GetInformationRoom_ByCodeRoomAndIDBookingRoom(int idBookingRoom, string codeRoom)
        {
            try
            {
                List<RoomExtStatusEN> aListRoomExtStatusEN = (from aBookingRs in aDatabaseDA.BookingRs
                                                              join aBookingRooms in aDatabaseDA.BookingRooms on aBookingRs.ID equals aBookingRooms.IDBookingR
                                                              join aRooms in aDatabaseDA.Rooms on aBookingRooms.CodeRoom equals aRooms.Code
                                                              join aCustomers in aDatabaseDA.Customers on aBookingRs.IDCustomer equals aCustomers.ID
                                                              join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingRs.IDCustomerGroup equals aCustomerGroups.ID
                                                              join aCompanies in aDatabaseDA.Companies on aCustomerGroups.IDCompany equals aCompanies.ID
                                                              where aBookingRooms.ID == idBookingRoom && aBookingRooms.CodeRoom == codeRoom
                                                              select new RoomExtStatusEN()
                                                              {
                                                                  BookingRooms_ID = aBookingRooms.ID,
                                                                  Sku = aRooms.Sku,
                                                                  Code = aRooms.Code,
                                                                  Customers_Name = aCustomers.Name,
                                                                  Companies_Name = aCompanies.Name,
                                                              }).Distinct().ToList();
                return aListRoomExtStatusEN;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("ReceptionTaskBO.GetInformationRoom_ByCodeRoomAndIDBookingRoom\n" + ex.ToString());
            }
        }
        //Author: Hiennv
        public List<RoomsEN> GetListRooms_ByIDBookingR(int IDBookingR)
        {
            try
            {
                List<RoomsEN> aListRoomEN = new List<RoomsEN>();

                aListRoomEN = (from aBookingRs in aDatabaseDA.BookingRs
                               join aBookingRooms in aDatabaseDA.BookingRooms on aBookingRs.ID equals aBookingRooms.IDBookingR
                               join aRooms in aDatabaseDA.Rooms on aBookingRooms.CodeRoom equals aRooms.Code
                               where aBookingRs.ID == IDBookingR && aRooms.IDLang == 1
                               select new RoomsEN()
                               {
                                   ID = aRooms.ID,
                                   Sku = aRooms.Sku,
                                   Image = aRooms.Image,
                                   Bed1 = aRooms.Bed1,
                                   Bed2 = aRooms.Bed2,
                                   Intro = aRooms.Intro,
                                   Info = aRooms.Info,
                                   CostRef = aRooms.CostRef,
                                   CostUnit = aRooms.CostUnit,
                                   Type = aRooms.Type,
                                   Disable = aRooms.Disable,
                                   Status = aRooms.Status,
                                   Code = aRooms.Code,
                                   IDLang = aRooms.IDLang,
                                   IDBookingRooms = aBookingRooms.ID,

                               }).ToList();
                return aListRoomEN;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("ReceptionTaskBO.GetListRooms_ByIDBookingR\n" + ex.ToString());
            }

        }
        //Author :Hiennv
        public bool CheckInForRoomAlreadyBooking(CheckInRoomBookingEN aCheckInRoomBookingEN)
        {
            try
            {
                //========================================================

                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(aCheckInRoomBookingEN.IDBookingR);
                if (aBookingRs != null)
                {
                    aBookingRs.Subject = aCheckInRoomBookingEN.Subject;
                    aBookingRs.Level = aCheckInRoomBookingEN.Level;
                    aBookingRs.Description = aCheckInRoomBookingEN.Description;
                    aBookingRs.Note = aCheckInRoomBookingEN.Note;
                    aBookingRs.IDCustomerGroup = aCheckInRoomBookingEN.IDCustomerGroup;
                    aBookingRs.IDCustomer = aCheckInRoomBookingEN.IDCustomer;
                    aBookingRs.BookingMoney = aCheckInRoomBookingEN.BookingMoney;
                    aBookingRs.IDSystemUser = aCheckInRoomBookingEN.IDSystemUser;
                    aBookingRs.BookingType = aCheckInRoomBookingEN.BookingType;
                    aBookingRs.Status = aCheckInRoomBookingEN.Status;
                    aBookingRs.StatusPay = aCheckInRoomBookingEN.StatusPay;
                    aBookingRs.DateEdit = DateTime.Now;

                    //cap nhat lai bang BookingRs
                    aBookingRsBO.Update(aBookingRs);

                    BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                    BookingRooms aBookingRooms;
                    BookingRoomsMembers aBookingRoomsMembers;
                    foreach (RoomMemberEN aRoomMemberEN in aCheckInRoomBookingEN.aListRoomMembers)
                    {
                        aBookingRooms = new BookingRooms();
                        aBookingRooms = aBookingRoomsBO.Select_ByID(aRoomMemberEN.IDBookingRooms);
                        if (aBookingRooms != null)
                        {
                            aBookingRooms.CheckInActual = aCheckInRoomBookingEN.CheckInActual;
                            aBookingRooms.CheckOutActual = aCheckInRoomBookingEN.CheckOutActual;
                            aBookingRooms.CheckOutPlan = aCheckInRoomBookingEN.CheckOutPlan;
                            aBookingRooms.Status = aCheckInRoomBookingEN.Status;
                            aBookingRoomsBO.Update(aBookingRooms);
                        }
                        else
                        {
                            aBookingRooms = new BookingRooms();
                            aBookingRooms.IDBookingR = aCheckInRoomBookingEN.IDBookingR;
                            aBookingRooms.CodeRoom = aRoomMemberEN.RoomCode;
                            aBookingRooms.PercentTax = 10;
                            aBookingRooms.CostRef_Rooms = aRoomMemberEN.RoomCostRef;
                            aBookingRooms.Cost = aRoomMemberEN.RoomCostRef;
                            aBookingRooms.CheckInPlan = aCheckInRoomBookingEN.CheckInActual;
                            aBookingRooms.CheckInActual = aCheckInRoomBookingEN.CheckInActual;
                            aBookingRooms.CheckOutPlan = aCheckInRoomBookingEN.CheckOutPlan;
                            aBookingRooms.CheckOutActual = aCheckInRoomBookingEN.CheckOutActual;
                            aBookingRooms.StartTime = aCheckInRoomBookingEN.CheckInActual;
                            aBookingRooms.EndTime = aCheckInRoomBookingEN.CheckOutPlan;
                            aBookingRooms.BookingStatus = 1;
                            aBookingRooms.Status = aCheckInRoomBookingEN.Status;
                            aBookingRooms.Status = 1;//Tính CheckIn sớm và CheckOut muộn
                            //add new bookingRoom
                            aBookingRoomsBO.Insert(aBookingRooms);
                            aRoomMemberEN.IDBookingRooms = aBookingRooms.ID;
                        }

                        //-----------------------------------------------------------
                        aBookingRoomsMembers = new BookingRoomsMembers();
                        aBookingRoomsMembers.IDBookingRoom = aRoomMemberEN.IDBookingRooms;

                        BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                        foreach (CustomerInfoEN aCustomerInfoEN in aRoomMemberEN.ListCustomer)
                        {
                            aBookingRoomsMembers.IDCustomer = aCustomerInfoEN.ID;
                            aBookingRoomsMembers.PurposeComeVietnam = aCustomerInfoEN.PurposeComeVietnam;
                            aBookingRoomsMembers.DateEnterCountry = aCustomerInfoEN.DateEnterCountry;
                            aBookingRoomsMembers.EnterGate = aCustomerInfoEN.EnterGate;
                            aBookingRoomsMembers.TemporaryResidenceDate = aCustomerInfoEN.TemporaryResidenceDate;
                            aBookingRoomsMembers.LimitDateEnterCountry = aCustomerInfoEN.LimitDateEnterCountry;
                            aBookingRoomsMembers.Organization = aCustomerInfoEN.Organization;
                            aBookingRoomsMembers.LeaveDate = aCustomerInfoEN.LeaveDate;
                            //add new bookingRoomMember
                            aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.CheckInForRoomAlreadyBooking\n" + ex.ToString());
            }
        }

        //Hiennv
        public List<ContractsEN> GetListContractsExpiring(DateTime dateChoose)
        {
            try
            {
                DateTime dateChoose1 = dateChoose.AddDays(-30);

                List<ContractsEN> aListContractsEN = new List<ContractsEN>();
                aListContractsEN = (from aSystemUsers in aDatabaseDA.SystemUsers
                                    join aContracts in aDatabaseDA.Contracts
                                        on aSystemUsers.ID equals aContracts.IDSystemUser
                                    where dateChoose1 < aContracts.ToDate && dateChoose > aContracts.ToDate
                                    select new ContractsEN()
                                    {
                                        ID = aContracts.ID,
                                        CreatedDate = aContracts.CreatedDate,
                                        ContractDate = aContracts.ContractDate,
                                        NumberContract = aContracts.NumberContract,
                                        NumberTemplateContract = aContracts.NumberTemplateContract,
                                        IDSystemUser = aContracts.IDSystemUser,
                                        Company = aContracts.Company,
                                        StatutoryRepresent = aContracts.StatutoryRepresent,
                                        StatutoryRepresentGender = aContracts.StatutoryRepresentGender,
                                        StatutoryRepresentIdentifier = aContracts.StatutoryRepresentIdentifier,
                                        ContractType = aContracts.ContractType,
                                        FromDate = aContracts.FromDate,
                                        ToDate = aContracts.ToDate,
                                        SkuTableSalary = aContracts.SkuTableSalary,
                                        Coefficent = aContracts.Coefficent,
                                        SalaryNet = aContracts.SalaryNet,
                                        SalaryCross = aContracts.SalaryCross,
                                        Type = aContracts.Type,
                                        Status = aContracts.Status,
                                        Disable = aContracts.Disable,

                                        Name = aSystemUsers.Name,
                                        Birthday = aSystemUsers.Birthday,
                                        Identifier1 = aSystemUsers.Identifier1,
                                        Phone = aSystemUsers.Phone,
                                        Gender = aSystemUsers.Gender,

                                    }).ToList();


                return aListContractsEN;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("ReceptionTaskBO.GetListContractsExpiring\n" + ex.ToString());
            }
        }

        //Hiennv
        public List<InfoSystemUserLiftSalaryEN> GetListSystemUserLiftSalary(DateTime dateChoose)
        {
            try
            {
                DateTime dateChoose1 = dateChoose.AddDays(-30);
                List<InfoSystemUserLiftSalaryEN> aListInfoSystemUserLiftSalaryEN = new List<InfoSystemUserLiftSalaryEN>();

                aListInfoSystemUserLiftSalaryEN = (from aSystemUsers in aDatabaseDA.SystemUsers
                                                   join aCalculatorSalaries in aDatabaseDA.CalculatorSalaries on aSystemUsers.ID equals aCalculatorSalaries.IDSystemUser
                                                   where aCalculatorSalaries.Disable == false && aCalculatorSalaries.EndDate > dateChoose1 && aCalculatorSalaries.EndDate < dateChoose
                                                   select new InfoSystemUserLiftSalaryEN()
                                                   {
                                                       ID = aSystemUsers.ID,
                                                       UserGroup = aSystemUsers.UserGroup,
                                                       Email = aSystemUsers.Email,
                                                       Username = aSystemUsers.Username,
                                                       Name = aSystemUsers.Name,
                                                       Password = aSystemUsers.Password,
                                                       Birthday = aSystemUsers.Birthday,
                                                       Identifier1 = aSystemUsers.Identifier1,
                                                       Identifier2 = aSystemUsers.Identifier2,
                                                       Identifier3 = aSystemUsers.Identifier3,
                                                       Image = aSystemUsers.Image,
                                                       Gender = aSystemUsers.Gender,
                                                       IDRefAnotherSystem = aSystemUsers.IDRefAnotherSystem,
                                                       IDRefMailSystem = aSystemUsers.IDRefMailSystem,
                                                       Type = aSystemUsers.Type,
                                                       Status = aSystemUsers.Status,
                                                       Disable = aSystemUsers.Disable,
                                                       Identifier1CreatedDate = aSystemUsers.Identifier1CreatedDate,
                                                       Identifier2CreatedDate = aSystemUsers.Identifier2CreatedDate,
                                                       Identifier3CreatedDate = aSystemUsers.Identifier3CreatedDate,
                                                       PlaceOfIssue1 = aSystemUsers.PlaceOfIssue1,
                                                       PlaceOfIssue2 = aSystemUsers.PlaceOfIssue2,
                                                       PlaceOfIssue3 = aSystemUsers.PlaceOfIssue3,

                                                       SkuTableSalary = aCalculatorSalaries.SkuTableSalary,
                                                       Coefficent = aCalculatorSalaries.Coefficent,
                                                       SalaryNet = aCalculatorSalaries.SalaryNet,
                                                       SalaryCross = aCalculatorSalaries.SalaryCross,
                                                       StartDate = aCalculatorSalaries.StartDate,
                                                       EndDate = aCalculatorSalaries.EndDate,



                                                   }).ToList();



                return aListInfoSystemUserLiftSalaryEN;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("ReceptionTaskBO.GetListSystemUserLiftSalary\n" + ex.ToString());
            }
        }

        //Linhting
        // Gửi mail cho công an
        public string SendMail(string SendEmail, string Pass, string ReceiveEmail, string subject, string filename)
        {
            string result = "Message Sent Successfully..!!";
            MailAddress mailfrom = new MailAddress(SendEmail);
            MailAddress mailto = new MailAddress(ReceiveEmail);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);


            newmsg.Subject = subject;
            newmsg.Body = "";

            //For File Attachment, more file can also be attached
            Attachment att = new Attachment(filename);
            newmsg.Attachments.Add(att);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SendEmail, Pass);
            smtp.EnableSsl = true;
            smtp.Send(newmsg);
            return result;
        }
        //Linhting
        // Xuất file DBF
        public string ExportDBF(List<OverNightCustomerEN> aListForeign)
        {
            try
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "dBase file (*.dbf)|*.dbf|CSV (Comma delimited) (*.csv)|*.csv";
                saveFileDialog.FileName = "2LETHACH_NN_" + String.Format("{0:yyyyddMMHHmm}", DateTime.Now);

                //DialogResult result = saveFileDialog.ShowDialog();

                //if (result == DialogResult.OK)
                //{
                DataFileExport dataFileExport;
                dataFileExport = DataFileExport.CreateDbf(aListForeign);
                //    switch (saveFileDialog.FilterIndex)
                //    {
                //        case 1:
                //            dataFileExport = DataFileExport.CreateDbf(aListForeign);
                //            break;
                //        case 2:
                //            dataFileExport = DataFileExport.CreateCsv(aListForeign);
                //            break;

                //        default:
                //            throw new NotImplementedException("Filter index " + saveFileDialog.FilterIndex);
                //    }

                dataFileExport
                    .AddTextField("SO_PHONG", 10, "Sku")
                    .AddTextField("HTEN", 10, "Name")
                     .AddTextField("GTINH", 10, "Gender")
                     .AddTextField("NGTHNSINH", 10, "Birthday")
                       .AddTextField("VIETNAM", 10, "IsVietNam")
                     .AddTextField("QTICH_HNAY", 10, "Nationality")
                          .AddTextField("SO_HC_TT", 20, "Identifier2")
                          .AddTextField("MDICH", 10, "PurposeComeVietnam")
                    .AddDateField("NGAY_NHAP", "DateEnterCountry")
                     .AddTextField("CKHAU_NHAP", 10, "EnterGate")
                     .AddDateField("HAN_XUAT", "LimitDateEnterCountry")
                      .AddDateField("NGAY_DEN", "TemporaryResidenceDate")
                       .AddDateField("NGAY_DI", "LeaveDate")
                        .AddTextField("DEN_CQTC", 10, "Organization")
                         .AddTextField("DIACHI_TT", 10, "DIACHI_TT")
                         .AddTextField("QUAN_HUYEN", 10, "Quan")
                         .AddTextField("TU_DAU_DEN", 10, "Nationality")
                         .AddTextField("CAN_BO_NM", 10, "CAN_BO_NM")
                         .AddTextField("NGAY_NMAY", 10, "NgayTruyen")
                        .AddTextField("NGAYTRUYEN", 10, "NgayTruyen")
                    .Write(saveFileDialog.FileName);

                return saveFileDialog.FileName;
            }
            catch (Exception ex)
            {
                throw new Exception("frmTsk_ListForeignCustomer.btnShowForeign_Click \n" + ex.ToString());
            }
        }

        //Author :Hiennv
        public List<CustomerEN> GetListCustomersCurrentInRooms_ByCreateDateBookingR(DateTime createDateBookingR)
        {
            try
            {
                List<CustomerEN> aListCustomerEN = (from aBookingRs in aDatabaseDA.BookingRs
                                                    join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingRs.IDCustomerGroup equals aCustomerGroups.ID
                                                    join aCompanies in aDatabaseDA.Companies on aCustomerGroups.IDCompany equals aCompanies.ID
                                                    join aBookingRooms in aDatabaseDA.BookingRooms on aBookingRs.ID equals aBookingRooms.IDBookingR
                                                    join aRooms in aDatabaseDA.Rooms on aBookingRooms.CodeRoom equals aRooms.Code
                                                    join aBookingRoomsMembers in aDatabaseDA.BookingRoomsMembers on aBookingRooms.ID equals aBookingRoomsMembers.IDBookingRoom
                                                    join aCustomers in aDatabaseDA.Customers on aBookingRoomsMembers.IDCustomer equals aCustomers.ID

                                                    where aBookingRooms.Status == 3 && aBookingRs.CreatedDate >= createDateBookingR

                                                    select new CustomerEN
                                                    {
                                                        IDCompany = aCompanies.ID,
                                                        NameCompany = aCompanies.Name,
                                                        IDGroup = aCustomerGroups.ID,
                                                        NameGroup = aCustomerGroups.Name,
                                                        CodeRoom = aRooms.Code,
                                                        SkuRoom = aRooms.Sku,
                                                        ID = aCustomers.ID,
                                                        Name = aCustomers.Name,
                                                        Identifier1 = aCustomers.Identifier1,
                                                        Identifier2 = aCustomers.Identifier2,
                                                        Identifier3 = aCustomers.Identifier3,
                                                        Nationality = aCustomers.Nationality,
                                                        Birthday = aCustomers.Birthday,
                                                        Tel = aCustomers.Tel,
                                                        Address = aCustomers.Address,
                                                        Email = aCustomers.Email,
                                                        Info = aCustomers.Info,
                                                        Note = aCustomers.Note,
                                                        Description = aCustomers.Description,
                                                        Status = aCustomers.Status,
                                                        Type = aCustomers.Type,
                                                        Disable = aCustomers.Disable,
                                                        Gender = aCustomers.Gender,
                                                        Citizen = aCustomers.Citizen,
                                                        Identifier1CreatedDate = aCustomers.Identifier1CreatedDate,
                                                        Identifier2CreatedDate = aCustomers.Identifier2CreatedDate,
                                                        Identifier3CreatedDate = aCustomers.Identifier3CreatedDate,
                                                        PlaceOfIssue1 = aCustomers.PlaceOfIssue1,
                                                        PlaceOfIssue2 = aCustomers.PlaceOfIssue2,
                                                        PlaceOfIssue3 = aCustomers.PlaceOfIssue3,

                                                    }).Distinct().ToList();

                return aListCustomerEN;
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("ReceptionTaskBO.GetInformationRoom_ByCodeRoomAndIDBookingRoom\n" + ex.ToString());
            }
        }
        //Hiennv
        public DateTime SetDateValueDefault(DateTime dateTime)
        {
            DateTime date = new DateTime();
            string aa = dateTime.ToString("dd/MM/yyyy") + " 12:00";
            date = DateTime.ParseExact(aa, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            return date;
        }

        #region ReceptionTask Halls
        //hiennv
        public List<Foods> GetListFoods_ByIDMenu(int IDMenu)
        {
            try
            {
                List<Foods> aListFoods = (from aFood in aDatabaseDA.Foods
                                          join aMenuFood in aDatabaseDA.Menus_Foods on aFood.ID equals aMenuFood.IDFood
                                          join aMenu in aDatabaseDA.Menus on aMenuFood.IDMenu equals aMenu.ID
                                          where aMenu.ID == IDMenu
                                          select aFood).ToList();
                return aListFoods;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListFoods_ByIDMenu:" + ex.Message));
            }
        }

        //hiennv
        public void CreateMenus(MenusEN aMenusEN)
        {
            try
            {
                MenusBO aMenusBO = new MenusBO();
                Menus aMenus = new Menus();
                aMenus.Name = aMenusEN.Name;
                aMenus.Issue = aMenusEN.Issue;
                aMenus.Info = aMenusEN.Info;
                aMenus.Type = aMenusEN.Type;
                aMenus.Status = aMenusEN.Status;
                aMenus.Disable = aMenusEN.Disable;
                aMenus.IDBookingHall = aMenusEN.IDBookingHall;
                aMenus.IDSystemUser = aMenusEN.IDSystemUser;
                int IDMenu = aMenusBO.Insert(aMenus);
                if (IDMenu > 0)
                {
                    foreach (Foods item in aMenusEN.aListFoods)
                    {
                        Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                        Menus_Foods aMenus_Foods = new Menus_Foods();
                        aMenus_Foods.IDMenu = IDMenu;
                        aMenus_Foods.IDFood = item.ID;
                        aMenus_FoodsBO.Insert(aMenus_Foods);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.CreateMenus:" + ex.Message));
            }

        }

        //hiennv
        public void UpdateMenus(MenusEN aMenusEN)
        {
            try
            {
                Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                MenusBO aMenusBO = new MenusBO();
                Menus aMenus = aMenusBO.Select_ByID(aMenusEN.ID);
                aMenus.Name = aMenusEN.Name;
                aMenus.Info = aMenusEN.Info;

                aMenus.IDBookingHall = aMenusEN.IDBookingHall;
                aMenus.IDSystemUser = aMenusEN.IDSystemUser;

                aMenusBO.Update(aMenus);
                aMenus_FoodsBO.Delete_ByIDMenu(aMenusEN.ID);
                foreach (Foods item in aMenusEN.aListFoods)
                {


                    Menus_Foods aMenus_Foods = new Menus_Foods();
                    aMenus_Foods.IDMenu = aMenusEN.ID;
                    aMenus_Foods.IDFood = item.ID;
                    aMenus_FoodsBO.Insert(aMenus_Foods);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.UpdateMenus:" + ex.Message));
            }

        }

        /*
         * Hiennv
         * hien thi chi tiet buoi tiec
         */
        public BookingHallDetailEN GetDetailBookingHalls_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                BookingHallDetailEN aBookingHallDetailEN;

                aBookingHallDetailEN = (from aBookingHs in aDatabaseDA.BookingHs
                                        join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                        join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                        join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                        join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                        join aMenus in aDatabaseDA.Menus on aBookingHalls.ID equals aMenus.IDBookingHall into aBookingHalls_aMenus

                                        from aMenus in aBookingHalls_aMenus.DefaultIfEmpty()

                                        where aBookingHalls.ID == IDBookingHall

                                        select new BookingHallDetailEN()
                                        {

                                            IDBookingH = aBookingHs.ID,
                                            CustomerType = aBookingHs.CustomerType,
                                            ID = aBookingHalls.ID,
                                            NameCustomerGroup = aCustomerGroups.Name,
                                            NameCustomer = aCustomers.Name,
                                            BookingTypeBookingH = aBookingHs.BookingType,
                                            StatusPayBookingH = aBookingHs.StatusPay,
                                            LevelBookingH = aBookingHs.Level,
                                            HallSku = aHalls.Sku,
                                            IDMenu = aMenus.ID == null ? 0 : aMenus.ID,
                                            NameMenu = String.IsNullOrEmpty(aMenus.Name) == true ? null : aMenus.Name,

                                        }).ToList()[0];

                aBookingHallDetailEN.aListFoods = (from aFood in aDatabaseDA.Foods
                                                   join aMenuFood in aDatabaseDA.Menus_Foods on aFood.ID equals aMenuFood.IDFood
                                                   join aMenu in aDatabaseDA.Menus on aMenuFood.IDMenu equals aMenu.ID
                                                   where aMenu.ID == aBookingHallDetailEN.IDMenu
                                                   select aFood).ToList();

                aBookingHallDetailEN.aListServicesHallsEN = (from aBookingHalls in aDatabaseDA.BookingHalls
                                                             join aBookingHalls_Services in aDatabaseDA.BookingHalls_Services on aBookingHalls.ID equals aBookingHalls_Services.IDBookingHall
                                                             join aServices in aDatabaseDA.Services on aBookingHalls_Services.IDService equals aServices.ID
                                                             where aBookingHalls.ID == aBookingHallDetailEN.ID
                                                             select new ServicesHallsEN()
                                                             {
                                                                 NameService = aServices.Name,
                                                                 ID = aBookingHalls_Services.ID,
                                                                 Info = aBookingHalls_Services.Info,
                                                                 Type = aBookingHalls_Services.Type,
                                                                 Status = aBookingHalls_Services.Status,
                                                                 Disable = aBookingHalls_Services.Disable,
                                                                 IDBookingHall = aBookingHalls_Services.IDBookingHall,
                                                                 IDService = aBookingHalls_Services.IDService,
                                                                 Cost = aBookingHalls_Services.Cost,
                                                                 Date = aBookingHalls_Services.Date,
                                                                 PercentTax = aBookingHalls_Services.PercentTax,
                                                                 CostRef_Services = aBookingHalls_Services.CostRef_Services,
                                                                 Quantity = aBookingHalls_Services.Quantity,
                                                             }
                                                       ).ToList();



                return aBookingHallDetailEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetDetailBookingHalls_ByIDBookingH\n" + ex.Message));
            }
        }

        /*
         * Hiennv
         * Lấy ra danh sách hoi truong theo NameGuest tu ngay den ngay
         */
        public List<BookingHallsEN> GetListBookingHalls_ByBookingHallsDate_ByNameGuest(DateTime FromDate, DateTime ToDate, string nameGuest)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                                            join aGuests in aDatabaseDA.Guests on aBookingHs.IDGuest equals aGuests.ID
                                                            join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                                            join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                                            join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                                            join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                                            where aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate && aGuests.Name.Contains(nameGuest)
                                                            select new BookingHallsEN()
                                                            {
                                                                IDBookingH = aBookingHs.ID,
                                                                CustomerType = aBookingHs.CustomerType,
                                                                ID = aBookingHalls.ID,
                                                                BookingTypeBookingH = aBookingHs.BookingType,
                                                                StatusPayBookingH = aBookingHs.StatusPay,
                                                                LevelBookingH = aBookingHs.Level,
                                                                HallSku = aHalls.Sku,
                                                                NameGuest = aGuests.Name,
                                                            }).ToList();
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHalls_ByBookingHallsDate_ByNameGuest\n" + ex.Message));
            }
        }

        /*
         * Hiennv
         * Lấy ra danh sách hoi truong theo BookingHsLevel tu ngay den ngay
         */
        public List<BookingHallsEN> GetListBookingHalls_ByBookingHallsDate_ByBookingHsLevel(DateTime FromDate, DateTime ToDate, int level)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();
                if (level >= 1 && level <= 12) // tiec thuoc hoi truong vip
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHs.Level >= level && aBookingHs.Level <= level && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (level >= 13 && level <= 14) // tiec thuoc hoi truong binh thuong
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHs.Level >= level && aBookingHs.Level <= level && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (level >= 1 && level <= 13) //Tiec thuoc pham tru cua bep
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHs.Level >= level && aBookingHs.Level <= level && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (level == 14)//Tiec khong thuoc pham tru cua bep
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHs.Level == level && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }

                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHalls_ByBookingHallsDate_ByBookingHsLevel\n" + ex.Message));
            }
        }

        /*
         * Hiennv
         * Lấy ra danh sách hoi truong theo Status tu ngay den ngay
         */
        public List<BookingHallsEN> GetListBookingHalls_ByBookingHallDate_ByBookingHallStatus(DateTime FromDate, DateTime ToDate, int status)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();
                if (status == 1) // chua xac thuc
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 2) // da xac thuc
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 3) // Bep chua Accept
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 4)//Bep da Accept
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 5) //pending
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 6) // moi thu da san sang
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 7) // Tiec da dien ra nhung chua thanh toan
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                else if (status == 8) // tiec da thanh toan xong
                {
                    aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                           join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                           join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                           join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                           join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                           where aBookingHalls.Status == status && aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate
                                           select new BookingHallsEN()
                                           {
                                               IDBookingH = aBookingHs.ID,
                                               CustomerType = aBookingHs.CustomerType,
                                               ID = aBookingHalls.ID,
                                               BookingTypeBookingH = aBookingHs.BookingType,
                                               StatusPayBookingH = aBookingHs.StatusPay,
                                               LevelBookingH = aBookingHs.Level,
                                               HallSku = aHalls.Sku,
                                           }).ToList();
                }
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHalls_ByBookingHallDate_ByBookingHallStatus\n" + ex.Message));
            }
        }
        /*
         * Hiennv
         * Lấy ra danh sách hoi truong tu ngay den ngay da co thuc don
         */
        public List<BookingHallsEN> GetListBookingHallsHaveMenus_ByBookingHallsDate(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                                            join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                                            join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                                            join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                                            join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                                            where aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate &&
                                                            (from aMenus in aDatabaseDA.Menus select aMenus.IDBookingHall).Contains(aBookingHalls.ID)
                                                            select new BookingHallsEN()
                                                            {
                                                                IDBookingH = aBookingHs.ID,
                                                                CustomerType = aBookingHs.CustomerType,
                                                                ID = aBookingHalls.ID,
                                                                BookingTypeBookingH = aBookingHs.BookingType,
                                                                StatusPayBookingH = aBookingHs.StatusPay,
                                                                LevelBookingH = aBookingHs.Level,
                                                                HallSku = aHalls.Sku,
                                                            }).Distinct().ToList();
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHallsHaveMenus_ByBookingHallsDate\n" + ex.Message));
            }
        }
        /*
         * Hiennv
         * Lấy ra danh sách hoi truong tu ngay den ngay chua co thuc don
         */
        public List<BookingHallsEN> GetListBookingHallsNotMenus_ByBookingHallsDate(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                                            join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                                            join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                                            join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                                            join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                                            where aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate &&
                                                            !(from aMenus in aDatabaseDA.Menus select aMenus.IDBookingHall).Contains(aBookingHalls.ID)
                                                            select new BookingHallsEN()
                                                            {
                                                                IDBookingH = aBookingHs.ID,
                                                                CustomerType = aBookingHs.CustomerType,
                                                                ID = aBookingHalls.ID,
                                                                BookingTypeBookingH = aBookingHs.BookingType,
                                                                StatusPayBookingH = aBookingHs.StatusPay,
                                                                LevelBookingH = aBookingHs.Level,
                                                                HallSku = aHalls.Sku,
                                                            }).Distinct().ToList();
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHallsNotMenus_ByBookingHallsDate\n" + ex.Message));
            }
        }

        /*
         * Hiennv
         * Lấy ra danh sách tat  ca hoi truong tu ngay den ngay da co nguoi dat
         */
        public List<BookingHallsEN> GetListBookingHallsIsUse_ByBookingHallsDate(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = (from aBookingHs in aDatabaseDA.BookingHs
                                                            join aCustomers in aDatabaseDA.Customers on aBookingHs.IDCustomer equals aCustomers.ID
                                                            join aCustomerGroups in aDatabaseDA.CustomerGroups on aBookingHs.IDCustomerGroup equals aCustomerGroups.ID
                                                            join aBookingHalls in aDatabaseDA.BookingHalls on aBookingHs.ID equals aBookingHalls.IDBookingH
                                                            join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                                            where aBookingHalls.Date >= FromDate && aBookingHalls.Date <= ToDate && aBookingHalls.Status != 7 && aBookingHalls.Status != 8
                                                            select new BookingHallsEN()
                                                            {
                                                                IDBookingH = aBookingHs.ID,
                                                                CustomerType = aBookingHs.CustomerType,
                                                                ID = aBookingHalls.ID,
                                                                BookingTypeBookingH = aBookingHs.BookingType,
                                                                StatusPayBookingH = aBookingHs.StatusPay,
                                                                LevelBookingH = aBookingHs.Level,
                                                                HallSku = aHalls.Sku,
                                                            }).ToList();
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListBookingHallsIsUse_ByBookingHallsDate\n" + ex.Message));
            }
        }
        //Author: Linhting
        public int CheckIn(BookingHs BookingHs, List<BookingHalls> ListBookingHalls)
        {
            try
            {
                BookingHs aBookingHs = new BookingHs();

                aBookingHs.CreatedDate = BookingHs.CreatedDate;
                aBookingHs.CustomerType = BookingHs.CustomerType;
                aBookingHs.BookingType = BookingHs.BookingType;
                aBookingHs.Note = BookingHs.Note;
                aBookingHs.IDGuest = BookingHs.IDGuest;
                aBookingHs.StatusPay = BookingHs.StatusPay;
                aBookingHs.BookingMoney = BookingHs.BookingMoney;
                aBookingHs.Status = BookingHs.Status;
                aBookingHs.Type = BookingHs.Type;
                aBookingHs.Disable = BookingHs.Disable;
                aBookingHs.Level = BookingHs.Level;
                aBookingHs.Subject = BookingHs.Subject;
                aBookingHs.IDCustomerGroup = BookingHs.IDCustomerGroup;
                aBookingHs.IDCustomer = BookingHs.IDCustomer;
                aBookingHs.IDSystemUser = BookingHs.IDSystemUser;
                aBookingHs.Description = BookingHs.Description;

                //add new bookingRs
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = aBookingHsBO.InsertUnSync(aBookingHs);



                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                BookingHalls aBookingHall;
                for (int i = 0; i < ListBookingHalls.Count; i++)
                {
                    aBookingHall = new BookingHalls();
                    aBookingHall.IDBookingH = IDBookingH;
                    aBookingHall.CodeHall = ListBookingHalls[i].CodeHall;
                    aBookingHall.Cost = ListBookingHalls[i].Cost;
                    aBookingHall.PercentTax = ListBookingHalls[i].PercentTax;
                    aBookingHall.CostRef_Halls = ListBookingHalls[i].CostRef_Halls;
                    aBookingHall.Date = ListBookingHalls[i].Date;
                    aBookingHall.LunarDate = ListBookingHalls[i].LunarDate;
                    aBookingHall.BookingStatus = ListBookingHalls[i].BookingStatus;
                    aBookingHall.Unit = ListBookingHalls[i].Unit;
                    aBookingHall.TableOrPerson = ListBookingHalls[i].TableOrPerson;
                    aBookingHall.Note = ListBookingHalls[i].Note;
                    aBookingHall.Status = ListBookingHalls[i].Status;
                    aBookingHall.StartTime = ListBookingHalls[i].StartTime;
                    aBookingHall.EndTime = ListBookingHalls[i].EndTime;
                    aBookingHall.Location = ListBookingHalls[i].Location;
                    aBookingHall.Color = ListBookingHalls[i].Color;

                    aBookingHallsBO.InsertUnSync(aBookingHall);
                }

                return IDBookingH;

            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.CheckIn\n" + ex.ToString());
            }

        }
        //Author : Linhting
        public void UpdateCheckIn(BookingHs BookingHs, List<BookingHalls> ListBookingHalls)
        {
            try
            {
                BookingHs aBookingHs = new BookingHs();
                aBookingHs.ID = BookingHs.ID;
                aBookingHs.CreatedDate = BookingHs.CreatedDate;
                aBookingHs.CustomerType = BookingHs.CustomerType;
                aBookingHs.BookingType = BookingHs.BookingType;
                aBookingHs.Note = BookingHs.Note;
                aBookingHs.IDGuest = BookingHs.IDGuest;
                aBookingHs.StatusPay = BookingHs.StatusPay;
                aBookingHs.BookingMoney = BookingHs.BookingMoney;
                aBookingHs.Status = BookingHs.Status;
                aBookingHs.Type = BookingHs.Type;
                aBookingHs.Disable = BookingHs.Disable;
                aBookingHs.Level = BookingHs.Level;
                aBookingHs.Subject = BookingHs.Subject;
                aBookingHs.IDCustomerGroup = BookingHs.IDCustomerGroup;
                aBookingHs.IDCustomer = BookingHs.IDCustomer;
                aBookingHs.IDSystemUser = BookingHs.IDSystemUser;
                aBookingHs.Description = BookingHs.Description;

                //add new bookingRs
                BookingHsBO aBookingHsBO = new BookingHsBO();
                aBookingHsBO.UpdateUnSync(aBookingHs);
                int IDBookingH = aBookingHs.ID;
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                aBookingHallsBO.DeleteListBookingHalls(IDBookingH);
                BookingHalls aBookingHall;
                for (int i = 0; i < ListBookingHalls.Count; i++)
                {
                    aBookingHall = new BookingHalls();
                    aBookingHall.IDBookingH = IDBookingH;
                    aBookingHall.CodeHall = ListBookingHalls[i].CodeHall;
                    aBookingHall.Cost = ListBookingHalls[i].Cost;
                    aBookingHall.PercentTax = ListBookingHalls[i].PercentTax;
                    aBookingHall.CostRef_Halls = ListBookingHalls[i].CostRef_Halls;
                    aBookingHall.Date = ListBookingHalls[i].Date;
                    aBookingHall.LunarDate = ListBookingHalls[i].LunarDate;
                    aBookingHall.BookingStatus = ListBookingHalls[i].BookingStatus;
                    aBookingHall.Unit = ListBookingHalls[i].Unit;
                    aBookingHall.TableOrPerson = ListBookingHalls[i].TableOrPerson;
                    aBookingHall.Note = ListBookingHalls[i].Note;
                    aBookingHall.Status = ListBookingHalls[i].Status;
                    aBookingHall.StartTime = ListBookingHalls[i].StartTime;
                    aBookingHall.EndTime = ListBookingHalls[i].EndTime;
                    aBookingHall.Location = ListBookingHalls[i].Location;
                    aBookingHall.Color = ListBookingHalls[i].Color;
                    aBookingHallsBO.InsertUnSync(aBookingHall);

                }
            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.UpdateCheckIn\n" + ex.ToString());
            }
        }
        //11/05
        //hiennv
        public MenusEN GetDetailMenu_ByIDBookingHall(int IDBookingHall)
        {
            try
            {

                MenusEN aMenusEN = new MenusEN();
                List<Menus> aListMenus = (from aMenus in aDatabaseDA.Menus where aMenus.IDBookingHall == IDBookingHall select aMenus).ToList();
                if (aListMenus.Count > 0)
                {
                    aMenusEN.ID = aListMenus[0].ID;
                    aMenusEN.Name = aListMenus[0].Name;
                    aMenusEN.aListFoods = (this.GetListFoods_ByIDMenu(aMenusEN.ID)).ToList();
                }
                return aMenusEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetDetailMenu_ByIDBookingHall\n" + ex.Message));
            }
        }
        //hiennv
        //public List<MenusEN> GetListMenus_ByIDBookingHall(int IDBookingHall)
        //{
        //    try
        //    {
        //        List<MenusEN> aListMenusEN = (from aBookingHalls in aDatabaseDA.BookingHalls
        //                                      join aMenus in aDatabaseDA.Menus on aBookingHalls.ID equals aMenus.IDBookingHall
        //                                      join aMenus_Foods in aDatabaseDA.Menus_Foods on aMenus.ID equals aMenus_Foods.IDMenu
        //                                      join aFoods in aDatabaseDA.Foods on aMenus_Foods.IDFood equals aFoods.ID
        //                                      where aBookingHalls.ID == IDBookingHall
        //                                      select new MenusEN
        //                                      {
        //                                          CodeHall = aBookingHalls.CodeHall,
        //                                          Name = aMenus.Name,
        //                                          NameFood = aFoods.Name,

        //                                      }).ToList();
        //        return aListMenusEN;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("ReceptionTaskBO.GetListMenus_ByIDBookingHall\n" + ex.Message));
        //    }
        //}

        //hiennv
        public List<ServicesHallsEN> GetListServicesHallsEN_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
                aListServicesHallsEN = (from aBookingHalls in aDatabaseDA.BookingHalls
                                        join aBookingHalls_Services in aDatabaseDA.BookingHalls_Services on aBookingHalls.ID equals aBookingHalls_Services.IDBookingHall
                                        join aServices in aDatabaseDA.Services on aBookingHalls_Services.IDService equals aServices.ID
                                        join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                        where aBookingHalls.ID == IDBookingHall
                                        select new ServicesHallsEN()
                                        {
                                            IDBookingHallService = aBookingHalls_Services.ID,
                                            IDBookingHall = aBookingHalls.ID,
                                            CodeHall = aBookingHalls.CodeHall,
                                            SkuHall = aHalls.Sku,
                                            IDService = aServices.ID,
                                            NameService = aServices.Name,
                                            Date = aBookingHalls_Services.Date,
                                            Quantity = aBookingHalls_Services.Quantity,
                                            Cost = aBookingHalls_Services.Cost,
                                            CostRef_Services = aBookingHalls_Services.CostRef_Services,
                                            PercentTax = aBookingHalls_Services.PercentTax,
                                        }

                    ).Distinct().ToList();


                return aListServicesHallsEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListServicesHallsEN_ByIDBookingHall\n" + ex.Message));
            }
        }
        //hiennv
        public bool PaymentHall(PaymentHallsEN aPaymentHallsEN)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(aPaymentHallsEN.IDBookingH);
                aBookingHs.PayMenthod = aPaymentHallsEN.PayMenthod;
                aBookingHs.DatePay = DateTime.Now;
                aBookingHs.StatusPay = 3;//da thanh toan
                aBookingHs.Status = 8;//da thanh toan toan bo
                aBookingHs.BookingMoney = 0;

                aBookingHsBO.Update(aBookingHs);
                foreach (InfoDetailPaymentHallsEN aInfoDetailPaymentHallsEN in aPaymentHallsEN.aListInfoDetailPaymentHallsEN)
                {
                    if (aInfoDetailPaymentHallsEN.aBookingHalls.IDBookingH == aPaymentHallsEN.IDBookingH)
                    {
                        BookingHalls aBookingHalls = aBookingHallsBO.Select_ByID(aInfoDetailPaymentHallsEN.aBookingHalls.ID);
                        aBookingHalls.Cost = aInfoDetailPaymentHallsEN.aBookingHalls.Cost;
                        aBookingHalls.PercentTax = aInfoDetailPaymentHallsEN.aBookingHalls.PercentTax;
                        aBookingHalls.Status = 8;// da thanh toan

                        aBookingHallsBO.Update(aBookingHalls);
                        foreach (ServicesHallsEN aServicesHallsEN in aInfoDetailPaymentHallsEN.aListServicesHallsEN)
                        {
                            if (aServicesHallsEN.IDBookingHall == aInfoDetailPaymentHallsEN.aBookingHalls.ID)
                            {
                                BookingHalls_Services aBookingHalls_Services = aBookingHalls_ServicesBO.Select_ByIDService_ByIDBookingHall(aServicesHallsEN.IDService, aInfoDetailPaymentHallsEN.aBookingHalls.ID);
                                aBookingHalls_Services.Cost = aServicesHallsEN.Cost;
                                aBookingHalls_Services.Quantity = aServicesHallsEN.Quantity;
                                aBookingHalls_Services.PercentTax = aServicesHallsEN.PercentTax;
                                aBookingHalls_Services.Status = 8;//da thanh toan
                                aBookingHalls_ServicesBO.Update(aBookingHalls_Services);
                            }

                        }

                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(string.Format("ReceptionTaskBO.PaymentHall\n" + ex.Message));
            }
        }
        //hiennv
        public bool PaymentRoom(PaymentEN aPaymentEN)
        {
            try
            {
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(aPaymentEN.IDBookingR);
                if (aBookingRs != null)
                {
                    aBookingRs.ID = aPaymentEN.IDBookingR;
                    aBookingRs.PayMenthod = aPaymentEN.PayMenthod;
                    aBookingRs.StatusPay = 3;
                    aBookingRs.Status = 8;
                    aBookingRs.DatePay = DateTime.Now;
                    aBookingRs.BookingMoney = 0;

                    aBookingRsBO.Update(aBookingRs);
                }

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                for (int i = 0; i < aPaymentEN.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.IDBookingR == aPaymentEN.IDBookingR)
                    {

                        BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.ID);
                        if (aBookingRooms != null)
                        {
                            aBookingRooms.ID = aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.ID;
                            aBookingRooms.PercentTax = aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax;
                            decimal? cost = aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == null ? aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.CostRef_Rooms : aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.Cost;
                            aBookingRooms.Cost = cost;
                            aBookingRooms.Status = 8;
                            aBookingRooms.CheckOutActual = aPaymentEN.aListInfoDetailPaymentEN[i].CheckOut;
                            aBookingRooms.TimeInUse = Convert.ToDecimal(aPaymentEN.aListInfoDetailPaymentEN[i].DateInUse * 24 * 60);

                            aBookingRoomsBO.Update(aBookingRooms);
                        }

                        for (int j = 0; j < aPaymentEN.aListInfoDetailPaymentEN[i].aListService.Count; j++)
                        {
                            if (aPaymentEN.aListInfoDetailPaymentEN[i].aBookingRooms.ID == aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].IDBookingRoom)
                            {
                                BookingRooms_Services aBookingRooms_Services = aBookingRooms_ServicesBO.Select_ByID(aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].IDBookingRoomService);
                                if (aBookingRooms_Services != null)
                                {
                                    aBookingRooms_Services.ID = aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].IDBookingRoomService;
                                    aBookingRooms_Services.Quantity = aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].Quantity;
                                    aBookingRooms_Services.PercentTax = aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].PercentTax;
                                    aBookingRooms_Services.Cost = aPaymentEN.aListInfoDetailPaymentEN[i].aListService[j].Cost;
                                    aBookingRooms_Services.Status = 8;

                                    aBookingRooms_ServicesBO.Update(aBookingRooms_Services);
                                }
                            }

                        }

                    }

                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(string.Format("ReceptionTaskBO.PaymentRoom\n" + ex.Message));
            }
        }


        // Linhting
        public List<BookingHallsEN> GetListBookingHallsHaveMenus(DateTime FromDate, DateTime ToDate)
        {
            List<BookingHallsEN> aListTemp = GetListBookingHallsHaveMenus_ByBookingHallsDate(FromDate, ToDate);
            List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();
            List<int> aListStatus = new List<int>();
            foreach (BookingHallsEN aBookingHallsEN in aListTemp)
            {
                MenusBO aMenusBO = new MenusBO();
                List<Menus> aListMenu = aMenusBO.Select_ByIDBookingHall(aBookingHallsEN.ID);

                foreach (Menus aMenu in aListMenu)
                {
                    aListStatus.Add(Convert.ToInt32(aMenu.Status));
                }
                if (aListStatus.Contains(0) == false)
                {
                    aListBookingHallsEN.Add(aBookingHallsEN);
                }
                aListStatus.Clear();
            }
            return aListBookingHallsEN;
        }
        // Linhting
        public List<BookingHallsEN> GetListBookingHallsSelectedMenus(DateTime FromDate, DateTime ToDate)
        {
            List<BookingHallsEN> aListTemp = GetListBookingHallsHaveMenus_ByBookingHallsDate(FromDate, ToDate);
            List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();
            List<int> aListStatus = new List<int>();
            foreach (BookingHallsEN aBookingHallsEN in aListTemp)
            {
                MenusBO aMenusBO = new MenusBO();
                List<Menus> aListMenu = aMenusBO.Select_ByIDBookingHall(aBookingHallsEN.ID);
                foreach (Menus aMenu in aListMenu)
                {
                    aListStatus.Add(Convert.ToInt32(aMenu.Status));
                }
                if (aListStatus.Contains(0) == true)
                {
                    aListBookingHallsEN.Add(aBookingHallsEN);
                }
                aListStatus.Clear();
            }
            return aListBookingHallsEN;
        }

        #endregion

        //Linhting
        public List<AllBookingEN> GetAllRevenues(DateTime From, DateTime To)
        {
            try
            {
                List<sp_BookingExt_GetAllBooking_Result> aListSP = new List<sp_BookingExt_GetAllBooking_Result>();
                aListSP = aDatabaseDA.sp_BookingExt_GetAllBooking(From, To).ToList();

                List<AllBookingEN> aListAllBookingEN = new List<AllBookingEN>();
                AllBookingEN aTemp;
                foreach (sp_BookingExt_GetAllBooking_Result item in aListSP)
                {
                    aTemp = new AllBookingEN();
                    aTemp.SetValue(item);

                    switch (aTemp.StatusPay)
                    {
                        case 1:
                            aTemp.StatusPayDisplay = "Tiền mặt";
                            break;
                        case 2:
                            aTemp.StatusPayDisplay = "Séc";
                            break;
                        case 3:
                            aTemp.StatusPayDisplay = "Chuyển khoản";
                            break;
                        case 4:
                            aTemp.StatusPayDisplay = "Bao cấp";
                            break;
                        default:
                            aTemp.StatusPayDisplay = "Tiền mặt";
                            break;
                    }
                    aTemp.TotalMoneyBeforeTax = aTemp.RoomsInvoiceNotTax.GetValueOrDefault(0) + aTemp.ServiceRooms1_NotTax.GetValueOrDefault(0) + aTemp.ServiceRooms2_NotTax.GetValueOrDefault(0)
                        + aTemp.ServiceRooms3_NotTax.GetValueOrDefault(0) + aTemp.HallsInvoiceNotTax.GetValueOrDefault(0) + aTemp.ServiceHalls1_NotTax.GetValueOrDefault(0)
                        + aTemp.ServiceHalls2_NotTax.GetValueOrDefault(0) + aTemp.ServiceHalls3_NotTax.GetValueOrDefault(0);
                    
                    aTemp.Tax = aTemp.RoomsInvoiceTax.GetValueOrDefault(0) + aTemp.ServiceRooms1_Tax.GetValueOrDefault(0) + aTemp.ServiceRooms2_Tax.GetValueOrDefault(0)
                            + aTemp.ServiceRooms3_Tax.GetValueOrDefault(0) + aTemp.HallsInvoiceTax.GetValueOrDefault(0) + aTemp.ServiceHalls1_Tax.GetValueOrDefault(0)
                            + aTemp.ServiceHalls2_Tax.GetValueOrDefault(0) + aTemp.ServiceHalls3_Tax.GetValueOrDefault(0);
                    
                    aTemp.TotalMoney = aTemp.TotalMoneyBeforeTax + aTemp.Tax;
                    
                    aListAllBookingEN.Add(aTemp);
                }
                return aListAllBookingEN;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.GetAllRevenues \n" + ex.ToString());
            }
        }

        //Linhting : Thanh toán lẻ phòng + tiệc + dịch vụ
        public void SplitPaymentRoom(NewPaymentEN aNewPaymentEN, List<BookingRoomUsedEN> aListRooms)
        {
            try
            {
                foreach (BookingRoomUsedEN aBookingRoomUsedEN in aListRooms)
                {

                    aBookingRoomUsedEN.Status = 8;//da thanh toan
                    aBookingRoomUsedEN.CheckOutActual = DateTime.Now;
                    aBookingRoomUsedEN.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.SplitPaymentRoom \n" + ex.ToString());
            }
        }

        public void SplitPaymentHall(NewPaymentEN aNewPaymentEN, List<BookingHallUsedEN> aListHalls)
        {
            try
            {
                foreach (BookingHallUsedEN aBookingHallUsedEN in aListHalls)
                {

                    aBookingHallUsedEN.Status = 8;//da thanh toan                
                    aBookingHallUsedEN.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.SplitPaymentHall \n" + ex.ToString());
            }
        }

        public void SplitPaymentService(NewPaymentEN aNewPaymentEN, List<ServiceUsedEN> aListServices, int Status)
        {
            try
            {
                if (Status == 1)
                {
                    foreach (ServiceUsedEN aServicesEN in aListServices)
                    {

                        aServicesEN.StatusPay = 8;
                        aServicesEN.Save(1);
                    }
                }
                else if (Status == 2)
                {
                    foreach (ServiceUsedEN aServicesEN in aListServices)
                    {

                        aServicesEN.StatusPay = 8;
                        aServicesEN.Save(2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.SplitPaymentService \n" + ex.ToString());
            }
        }

        //Hiennv        31/08/2014           Thanh toan le cho phong
        public void SplitPaymentForBookingR(NewPaymentEN aNewPaymentEN, List<BookingRoomUsedEN> aListRooms, List<ServiceUsedEN> aListServicesR)
        {
            try
            {

                foreach (ServiceUsedEN aServicesEN in aListServicesR)
                {

                    aServicesEN.StatusPay = 8;
                    aServicesEN.Save(1);
                }
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                foreach (BookingRoomUsedEN aBookingRoomUsedEN in aListRooms)
                {

                    aBookingRoomUsedEN.Status = 8;//da thanh toan
                    aBookingRoomUsedEN.CheckOutActual = DateTime.Now;
                    aBookingRoomUsedEN.Save();
                }
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(Convert.ToInt32(aNewPaymentEN.IDBookingR));
                List<BookingRooms> aListBookingRooms = aBookingRoomsBO.Select_ByIDBookingR_ByStatus(Convert.ToInt32(aNewPaymentEN.IDBookingR), 8);
                if (aListBookingRooms.Count < 1)
                {
                    aBookingRs.ID = Convert.ToInt32(aNewPaymentEN.IDBookingR);
                    aBookingRs.PayMenthod = aNewPaymentEN.PayMenthodR;
                    aBookingRs.StatusPay = 3;
                    aBookingRs.Status = 8;
                    aBookingRs.DatePay = DateTime.Now;
                }
                aBookingRs.BookingMoney = aNewPaymentEN.BookingRMoney;
                aBookingRsBO.Update(aBookingRs);
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.SplitPaymentForBookingR \n" + ex.ToString());
            }
        }

        //Hiennv        31/08/2014           Thanh toan le cho hoi truong
        public void SplitPaymentForBookingH(NewPaymentEN aNewPaymentEN, List<BookingHallUsedEN> aListHalls, List<ServiceUsedEN> aListServicesH)
        {
            try
            {
                foreach (ServiceUsedEN aServicesEN in aListServicesH)
                {

                    aServicesEN.StatusPay = 8;
                    aServicesEN.Save(2);
                }

                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                foreach (BookingHallUsedEN aHallsEN in aListHalls)
                {
                    aHallsEN.Status = 8;
                    aHallsEN.Save();
                }
                BookingHsBO aBookingHsBO = new BookingHsBO();
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(Convert.ToInt32(aNewPaymentEN.IDBookingH));
                List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookingH_ByStatus(Convert.ToInt32(aNewPaymentEN.IDBookingH), 8);
                if (aListBookingHalls.Count < 1)
                {
                    aBookingHs.ID = Convert.ToInt32(aNewPaymentEN.IDBookingH);
                    aBookingHs.PayMenthod = aNewPaymentEN.PayMenthodH;
                    aBookingHs.StatusPay = 3;
                    aBookingHs.Status = 8;
                    aBookingHs.DatePay = DateTime.Now;
                }
                aBookingHs.BookingMoney = aNewPaymentEN.BookingHMoney;
                aBookingHsBO.Update(aBookingHs);
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.SplitPaymentForBookingH \n" + ex.ToString());
            }
        }

        // Linhting - Lay du lieu cho NewPayment
        public List<ServiceUsedEN> GetListServiceUsedInRoom_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups> aListTemp = new List<vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups>();
                aListTemp = aDatabaseDA.vw__BookingRooms_ServicesInfo__BookingRooms_BookingRoomsServices_Services_ServiceGroups.Where(v => v.BookingRooms_Services_IDBookingRoom == IDBookingRoom).ToList();
                List<ServiceUsedEN> aListReturn = new List<ServiceUsedEN>();
                ServiceUsedEN aServiceUsedEN;
                RoomsBO aRoomsBO = new RoomsBO();

                List<Rooms> aListRoomTemp = aRoomsBO.Select_ByIDLang(1);


                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aServiceUsedEN = new ServiceUsedEN();
                    aServiceUsedEN.IDBookingService = aListTemp[i].BookingRooms_Services_ID;
                    aServiceUsedEN.IDServiceGroup = aListTemp[i].ServiceGroups_ID;
                    aServiceUsedEN.ServiceGroupName = aListTemp[i].ServiceGroups_Name;
                    aServiceUsedEN.IDService = aListTemp[i].Services_ID;
                    aServiceUsedEN.DateUsed = aListTemp[i].BookingRooms_Services_Date;
                    if (aListRoomTemp.Where(r => r.Code == aListTemp[i].BookingRooms_CodeRoom).ToList().Count > 0)
                    {
                        aServiceUsedEN.Sku = aListRoomTemp.Where(r => r.Code == aListTemp[i].BookingRooms_CodeRoom).ToList()[0].Sku;
                    }
                    aServiceUsedEN.IndexSubPayment = aListTemp[i].BookingRooms_Services_IndexSubPayment;
                    aServiceUsedEN.StatusPay = aListTemp[i].BookingRooms_Services_Status;
                    aServiceUsedEN.NameService = aListTemp[i].Services_Name;
                    aServiceUsedEN.Quantity = aListTemp[i].BookingRooms_Services_Quantity;
                    aServiceUsedEN.Cost = aListTemp[i].BookingRooms_Services_Cost;
                    aServiceUsedEN.CostRef_Service = aListTemp[i].Services_CostRef;
                    aServiceUsedEN.Tax = aListTemp[i].BookingRooms_Services_PercentTax;
   
                    aListReturn.Insert(i, aServiceUsedEN);
                }

                return aListReturn;

            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.GetListServiceUsed_ByIDBookingRoom\n" + ex.ToString());
            }
        }
        public List<ServiceUsedEN> GetListServiceUsedInHall_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                List<ServiceUsedEN> aListServiceUsedEN = new List<ServiceUsedEN>();
                aListServiceUsedEN = (from aBookingHalls in aDatabaseDA.BookingHalls
                                      join aBookingHalls_Services in aDatabaseDA.BookingHalls_Services on aBookingHalls.ID equals aBookingHalls_Services.IDBookingHall
                                      join aServices in aDatabaseDA.Services on aBookingHalls_Services.IDService equals aServices.ID
                                      join aServicesGroup in aDatabaseDA.ServiceGroups on aServices.IDServiceGroups equals aServicesGroup.ID
                                      join aHalls in aDatabaseDA.Halls on aBookingHalls.CodeHall equals aHalls.Code
                                      where aBookingHalls.ID == IDBookingHall
                                      select new ServiceUsedEN()
                                      {
                                          IDBookingService = aBookingHalls_Services.ID,
                                          Sku = aHalls.Sku,
                                          IDService = aServices.ID,
                                          NameService = aServices.Name,
                                          IDServiceGroup = aServicesGroup.ID,
                                          ServiceGroupName = aServicesGroup.Name,
                                          DateUsed = aBookingHalls_Services.Date,
                                          Quantity = aBookingHalls_Services.Quantity,
                                          Cost = aBookingHalls_Services.Cost,
                                          CostRef_Service = aBookingHalls_Services.CostRef_Services,
                                          Tax = aBookingHalls_Services.PercentTax,
                                          StatusPay = aBookingHalls_Services.Status,
                                          IndexSubPayment = aBookingHalls_Services.IndexSubPayment,

                                      }

                    ).Distinct().ToList();
                //foreach (ServiceUsedEN aServiceUsedEN in aListServiceUsedEN)
                //{
                //    aServiceUsedEN.TotalMoney = aServiceUsedEN.GetMoneyService();
                //    aServiceUsedEN.TotalMoneyBeforeTax = aServiceUsedEN.GetMoneyServiceBeforeTax();
                //    aServiceUsedEN.IsPaid = aServiceUsedEN.IsPaidService();
                //}
                return aListServiceUsedEN;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ReceptionTaskBO.GetListServiceUsedEN_ByIDBookingHall\n" + ex.Message));
            }
        }

        public List<MenusEN> GetListMenus_ByIDBookingHall(int IDBookingHall)
        {
            MenusBO aMenusBO = new MenusBO();
            List<MenusEN> aListMenus = new List<MenusEN>();
            MenusEN aMenu;
            List<Menus> aListTemp = aMenusBO.Select_ByIDBookingHall(IDBookingHall);
            foreach (Menus item in aListTemp)
            {
                aMenu = new MenusEN();
                aMenu.ID = item.ID;
                aMenu.Name = item.Name;
                aMenu.aListFoods = (this.GetListFoods_ByIDMenu(item.ID)).ToList();
                aListMenus.Add(aMenu);
            }
            return aListMenus;
        }

        //Linhting - Book hội trường mới
        public int NewBookHall(NewBookingHEN aNewBookingHEN)
        {
            try
            {
                BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();


                //Tạo BookingH mới
                BookingHs aBookingHs = new BookingHs();

                aBookingHs.CreatedDate = aNewBookingHEN.CreatedDate;
                aBookingHs.CustomerType = aNewBookingHEN.CustomerType;
                aBookingHs.BookingType = aNewBookingHEN.BookingType;
                aBookingHs.Note = aNewBookingHEN.Note;
                aBookingHs.IDGuest = 0;
                aBookingHs.StatusPay = aNewBookingHEN.StatusPay;
                aBookingHs.BookingMoney = aNewBookingHEN.BookingMoney;
                aBookingHs.Status = aNewBookingHEN.Status;
                aBookingHs.Type = aNewBookingHEN.Type;
                aBookingHs.Disable = aNewBookingHEN.Disable;
                aBookingHs.Level = aNewBookingHEN.Level;
                aBookingHs.Subject = aNewBookingHEN.Subject;
                aBookingHs.IDCustomerGroup = aNewBookingHEN.IDCustomerGroup;
                aBookingHs.IDCustomer = aNewBookingHEN.IDCustomer;
                aBookingHs.IDSystemUser = aNewBookingHEN.IDSystemUser;
                aBookingHs.Description = aNewBookingHEN.Description;

                //Tạo BookingHall mới
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = aBookingHsBO.InsertUnSync(aBookingHs);



                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                BookingHalls aBookingHall;
                for (int i = 0; i < aNewBookingHEN.aListBookingHallUsed.Count; i++)
                {
                    aBookingHall = new BookingHalls();
                    aBookingHall.IDBookingH = IDBookingH;
                    aBookingHall.CodeHall = aNewBookingHEN.aListBookingHallUsed[i].CodeHall;
                    aBookingHall.Cost = aNewBookingHEN.aListBookingHallUsed[i].Cost;
                    aBookingHall.PercentTax = 10; //Để tạm thuế = 10%
                    aBookingHall.CostRef_Halls = aNewBookingHEN.aListBookingHallUsed[i].CostRef_Halls;
                    aBookingHall.Date = aNewBookingHEN.aListBookingHallUsed[i].Date;
                    aBookingHall.LunarDate = aNewBookingHEN.aListBookingHallUsed[i].LunarDate;
                    aBookingHall.BookingStatus = aNewBookingHEN.aListBookingHallUsed[i].BookingStatus;
                    aBookingHall.Unit = aNewBookingHEN.aListBookingHallUsed[i].Unit;
                    aBookingHall.TableOrPerson = aNewBookingHEN.aListBookingHallUsed[i].TableOrPerson;
                    aBookingHall.Note = aNewBookingHEN.aListBookingHallUsed[i].Note;
                    aBookingHall.Status = aNewBookingHEN.aListBookingHallUsed[i].Status;
                    aBookingHall.StartTime = aNewBookingHEN.aListBookingHallUsed[i].StartTime;
                    aBookingHall.EndTime = aNewBookingHEN.aListBookingHallUsed[i].EndTime;
                    aBookingHall.Location = aNewBookingHEN.aListBookingHallUsed[i].Location;
                    aBookingHall.Color = aNewBookingHEN.aListBookingHallUsed[i].Color;

                    aBookingHallsBO.InsertUnSync(aBookingHall);
                    int IDBookingHall = aBookingHall.ID;
                    // Thêm dịch vụ đã chọn vào hội trường
                    foreach (ServiceUsedEN aTemp in aNewBookingHEN.aListBookingHallUsed[i].aListServiceUsed)
                    {
                        BookingHalls_Services aBookingHalls_Services = new BookingHalls_Services();
                        aBookingHalls_Services.Info = "";
                        aBookingHalls_Services.Type = 1;
                        aBookingHalls_Services.Status = 1;
                        aBookingHalls_Services.Disable = false;
                        aBookingHalls_Services.IDBookingHall = aBookingHall.ID;
                        aBookingHalls_Services.IDService = aTemp.IDService;
                        aBookingHalls_Services.Cost = aTemp.Cost;
                        aBookingHalls_Services.Date = aTemp.DateUsed;
                        aBookingHalls_Services.CostRef_Services = aTemp.CostRef_Service;
                        aBookingHalls_Services.PercentTax = 10;// de mac dinh
                        aBookingHalls_Services.Quantity = aTemp.Quantity;
                        aBookingHalls_ServicesBO.Insert(aBookingHalls_Services);

                    }
                    // Thêm thực đơn vào hội trường
                    foreach (MenusEN aMenuEN in aNewBookingHEN.aListBookingHallUsed[i].aListMenuEN)
                    {
                        aMenuEN.IDBookingHall = IDBookingHall;
                        aMenuEN.Type = 1; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenuEN.Status = 1; // de tam
                        aMenuEN.Disable = false; // de tam                        
                        aMenuEN.IDSystemUser = 1;//Khi kinh doanh thêm thực đơn mặc định trạng thái là 0 - đã xác nhận thực đơn
                        this.CreateMenus(aMenuEN);
                    }


                }

                return IDBookingH;

            }
            catch (Exception ex)
            {

                throw new Exception("ReceptionTaskBO.NewBookHall\n" + ex.ToString());
            }
        }

        //Hiennv     20/11/2014     Viet lai phuong thuc checkIn
        public bool NewCheckIn(CheckInEN aCheckInEN)
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                List<Customers> aListCustomersTemp = aCustomersBO.Select_All();

                int IDBookingR = 0;
                int IDCompany = 0;
                int IDCustomerGroup = 0;
                int IDCustomer = 0;
                int Result = 0;

                string customerType = string.Empty;


                if (aCheckInEN.CustomerType == 0)
                {
                    customerType = "Tất cả loại khác";
                }
                else if (aCheckInEN.CustomerType == 1)
                {
                    customerType = "Khách nhà nước";
                }
                else if (aCheckInEN.CustomerType == 2)
                {
                    customerType = "Khách đoàn";
                }
                else if (aCheckInEN.CustomerType == 3)
                {
                    customerType = "Khách lẻ";
                }
                else if (aCheckInEN.CustomerType == 4)
                {
                    customerType = "Khách vãng lai";
                }
                else if (aCheckInEN.CustomerType == 5)
                {
                    customerType = "Khách bộ ngoại giao";
                }
                else
                {
                    customerType = string.Empty;
                }


                #region Them moi cong ty khi cong ty chua co
                if (aCheckInEN.IDCompany > 0)
                {
                    IDCompany = aCheckInEN.IDCompany;
                }
                else
                {
                    CompaniesBO aCompaniesBO = new CompaniesBO();
                    Companies aCompanies = new Companies();
                    if (aCheckInEN.NameCompany.Length > 250)
                    {
                        aCompanies.Name = aCheckInEN.NameCompany.Substring(0, 250);
                    }
                    else
                    {
                        aCompanies.Name = aCheckInEN.NameCompany;
                    }

                    aCompanies.TaxNumberCode = string.Empty;
                    aCompanies.Address = string.Empty;
                    aCompanies.Type = aCheckInEN.CustomerType;
                    aCompanies.Status = 1;
                    aCompanies.Disable = false;
                    IDCompany = aCompaniesBO.Insert(aCompanies);
                }
                #endregion
                #region Them moi nhom vao trong cong ty
                if (IDCompany > 0)
                {
                    CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                    CustomerGroups aCustomerGroups = new CustomerGroups();

                    string nameGroup = "[" + customerType + "][" + aCheckInEN.NameCompany + "][" + DateTime.Now.ToString() + "]";
                    aCustomerGroups.IDCompany = IDCompany;
                    if (nameGroup.Length > 250)
                    {
                        aCustomerGroups.Name = nameGroup.Substring(0, 250);
                    }
                    else
                    {
                        aCustomerGroups.Name = nameGroup;
                    }

                    aCustomerGroups.Type = 1;
                    aCustomerGroups.Status = 1;
                    aCustomerGroups.Disable = false;
                    IDCustomerGroup = aCustomerGroupsBO.Insert(aCustomerGroups);
                }
                #endregion


                string subject = "[" + customerType + "][" + aCheckInEN.NameCompany + "][" + DateTime.Now.ToString() + "]";

                BookingRs aBookingRs = new BookingRs();

                aBookingRs.CreatedDate = DateTime.Now;
                aBookingRs.CustomerType = aCheckInEN.CustomerType;
                aBookingRs.BookingType = aCheckInEN.BookingType;
                if (subject.Length > 250)
                {
                    aBookingRs.Subject = subject.Substring(0, 250);
                }
                else
                {
                    aBookingRs.Subject = subject;
                }

                aBookingRs.IDCustomerGroup = IDCustomerGroup;
                aBookingRs.IDCustomer = aCheckInEN.IDCustomer;
                aBookingRs.IDSystemUser = aCheckInEN.IDSystemUser;
                aBookingRs.PayMenthod = aCheckInEN.PayMenthod;
                aBookingRs.StatusPay = aCheckInEN.StatusPay;
                aBookingRs.BookingMoney = aCheckInEN.BookingMoney;
                aBookingRs.ExchangeRate = aCheckInEN.ExchangeRate;
                aBookingRs.Level = 0;// de mac dinh hien tai chua dung den
                aBookingRs.Note = string.Empty;
                aBookingRs.Description = string.Empty;
                aBookingRs.DatePay = aCheckInEN.CheckOutPlan;
                aBookingRs.DateEdit = aCheckInEN.CheckInActual;
                aBookingRs.Status = aCheckInEN.Status;
                aBookingRs.Type = aCheckInEN.Type;
                aBookingRs.Disable = aCheckInEN.Disable;

                //add new bookingRs
                BookingRsBO aBookingRsBO = new BookingRsBO();
                IDBookingR = aBookingRsBO.Insert(aBookingRs);


                //==========================================================
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms;
                BookingRoomsMembers aBookingRoomsMembers;

                for (int i = 0; i < aCheckInEN.aListRoomMembers.Count; i++)
                {
                    aBookingRooms = new BookingRooms();
                    aBookingRooms.IDBookingR = IDBookingR;
                    aBookingRooms.CodeRoom = aCheckInEN.aListRoomMembers[i].RoomCode;
                    aBookingRooms.PercentTax = 10;
                    aBookingRooms.CostRef_Rooms = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                    aBookingRooms.Cost = null;
                    aBookingRooms.CheckInPlan = aCheckInEN.CheckInActual;
                    aBookingRooms.CheckInActual = aCheckInEN.CheckInActual;
                    aBookingRooms.CheckOutPlan = aCheckInEN.CheckOutPlan;
                    aBookingRooms.CheckOutActual = aCheckInEN.CheckOutActual;
                    aBookingRooms.StartTime = aCheckInEN.CheckInActual;
                    aBookingRooms.EndTime = aCheckInEN.CheckOutPlan;
                    aBookingRooms.BookingStatus = 1;
                    aBookingRooms.Type = 3; //Tính CheckIn sớm và CheckOut muộn
                    aBookingRooms.Status = aCheckInEN.Status;
                    aBookingRooms.PriceType = "G1";

                    //add new bookingRoom
                    int IDBookingRooms = aBookingRoomsBO.Insert(aBookingRooms);

                    //-----------------------------------------------------------
                    aBookingRoomsMembers = new BookingRoomsMembers();
                    aBookingRoomsMembers.IDBookingRoom = IDBookingRooms;

                    BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                    for (int ii = 0; ii < aCheckInEN.aListRoomMembers[i].ListCustomer.Count; ii++)
                    {
                        Customers aCustomers;
                        List<Customers> aListCustomers = aListCustomersTemp.Where(c => c.ID == aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID).ToList();
                        if (aListCustomers.Count > 0)
                        {
                            IDCustomer = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID;

                            aCustomers = aListCustomers[0];
                            aCustomers.Name = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name;
                            aCustomers.Identifier1 = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Identifier1;
                            aCustomers.Birthday = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Birthday;
                            aCustomers.Gender = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Gender;
                            aCustomers.Tel = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Tel;
                            aCustomers.Nationality = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Nationality;
                            aCustomersBO.Update(aCustomers);

                        }
                        else
                        {
                            aCustomers = new Customers();
                            aCustomers.Name = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name;
                            aCustomers.Identifier1 = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Identifier1;
                            aCustomers.Birthday = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Birthday;
                            aCustomers.Gender = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Gender;
                            aCustomers.Tel = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Tel;
                            aCustomers.Nationality = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Nationality;

                            //Them moi khach hang
                            IDCustomer = aCustomersBO.Insert(aCustomers);
                        }
                        aBookingRoomsMembers.IDCustomer = IDCustomer;
                        aBookingRoomsMembers.PurposeComeVietnam = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].PurposeComeVietnam;
                        aBookingRoomsMembers.DateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].DateEnterCountry;
                        aBookingRoomsMembers.EnterGate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].EnterGate;
                        aBookingRoomsMembers.TemporaryResidenceDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].TemporaryResidenceDate;
                        aBookingRoomsMembers.LimitDateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LimitDateEnterCountry;
                        aBookingRoomsMembers.Organization = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Organization;
                        aBookingRoomsMembers.LeaveDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LeaveDate;

                        //add new bookingRoomMember
                        aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);

                        #region  them nguoi vao trong customergroup_customer

                        string nameCustomerGroup_customer = "[" + customerType + "][" + aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name + "]";

                        CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                        CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
                        if (nameCustomerGroup_customer.Length > 150)
                        {
                            aCustomerGroups_Customers.Name = nameCustomerGroup_customer.Substring(0, 150);
                        }
                        else
                        {
                            aCustomerGroups_Customers.Name = nameCustomerGroup_customer;
                        }

                        aCustomerGroups_Customers.Type = 1;
                        aCustomerGroups_Customers.Status = 1;
                        aCustomerGroups_Customers.Disable = false;
                        aCustomerGroups_Customers.FromDate = DateTime.Now;
                        aCustomerGroups_Customers.ToDate = DateTime.Now;
                        aCustomerGroups_Customers.IDCustomer = IDCustomer;
                        aCustomerGroups_Customers.IDCustomerGroup = IDCustomerGroup;
                        aCustomerGroups_CustomersBO.Insert(aCustomerGroups_Customers);
                        #endregion


                        // dung de cap nhap lai nguoi dai dien khi dat phong
                        if (aCheckInEN.aListRoomMembers[i].ListCustomer[ii].PepoleRepresentative == true)
                        {
                            aBookingRsBO = new BookingRsBO();
                            aBookingRs = new BookingRs();
                            aBookingRs = aBookingRsBO.Select_ByID(IDBookingR);
                            if (aBookingRs != null)
                            {
                                aBookingRs.IDCustomer = IDCustomer;
                                Result = aBookingRsBO.Update(aBookingRs);
                            }

                        }
                        else
                        {
                            if (ii == (aCheckInEN.aListRoomMembers[i].ListCustomer.Count - 1))
                            {
                                if (Result == 0)
                                {
                                    aBookingRsBO = new BookingRsBO();
                                    aBookingRs = new BookingRs();
                                    aBookingRs = aBookingRsBO.Select_ByID(IDBookingR);
                                    if (aBookingRs != null)
                                    {
                                        aBookingRs.IDCustomer = IDCustomer;
                                        aBookingRsBO.Update(aBookingRs);
                                    }
                                }
                            }
                        }

                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Hiennv     25/11/2014     Viet lai phuong thuc BookingRoom
        public bool NewBookingRoom(NewBookingEN aNewBookingEN)
        {
            try
            {
                int IDBookingR = 0;
                int IDCompany = 0;
                int IDCustomerGroup = 0;
                int IDCustomer = 0;


                string customerType = string.Empty;
                if (aNewBookingEN.CustomerType == 0)
                {
                    customerType = "Tất cả loại khác";
                }
                else if (aNewBookingEN.CustomerType == 1)
                {
                    customerType = "Khách nhà nước";
                }
                else if (aNewBookingEN.CustomerType == 2)
                {
                    customerType = "Khách đoàn";
                }
                else if (aNewBookingEN.CustomerType == 3)
                {
                    customerType = "Khách lẻ";
                }
                else if (aNewBookingEN.CustomerType == 4)
                {
                    customerType = "Khách vãng lai";
                }
                else if (aNewBookingEN.CustomerType == 5)
                {
                    customerType = "Khách bộ ngoại giao";
                }
                else
                {
                    customerType = string.Empty;
                }

                #region Them moi khach hang khi khach hang chua co
                if (aNewBookingEN.IDCustomer > 0)
                {
                    IDCustomer = aNewBookingEN.IDCustomer;
                }
                else
                {
                    CustomersBO aCustomersBO = new CustomersBO();
                    Customers aCustomers = new Customers();
                    if (aNewBookingEN.NameCustomer.Length > 50)
                    {
                        aCustomers.Name = aNewBookingEN.NameCustomer.Substring(0, 50);
                    }
                    else
                    {
                        aCustomers.Name = aNewBookingEN.NameCustomer;
                    }
                    IDCustomer = aCustomersBO.Insert(aCustomers);
                }
                #endregion

                #region Them moi cong ty khi cong ty chua co
                if (aNewBookingEN.IDCompany > 0)
                {
                    IDCompany = aNewBookingEN.IDCompany;
                }
                else
                {
                    CompaniesBO aCompaniesBO = new CompaniesBO();
                    Companies aCompanies = new Companies();
                    if (aNewBookingEN.NameCompany.Length > 250)
                    {
                        aCompanies.Name = aNewBookingEN.NameCompany.Substring(0, 250);
                    }
                    else
                    {
                        aCompanies.Name = aNewBookingEN.NameCompany;
                    }

                    aCompanies.TaxNumberCode = string.Empty;
                    aCompanies.Address = string.Empty;
                    aCompanies.Type = aNewBookingEN.CustomerType;
                    aCompanies.Status = 1;
                    aCompanies.Disable = false;
                    IDCompany = aCompaniesBO.Insert(aCompanies);
                }
                #endregion

                #region Them moi nhom vao trong cong ty
                if (IDCompany > 0)
                {
                    CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                    CustomerGroups aCustomerGroups = new CustomerGroups();
                    string nameGroup;
                    if (string.IsNullOrEmpty(aNewBookingEN.Subject))
                    {
                        nameGroup = "[" + customerType + "][" + aNewBookingEN.NameCompany + "][" + DateTime.Now.ToString() + "]";
                    }
                    else
                    {
                        nameGroup = aNewBookingEN.Subject;
                    }
                    aCustomerGroups.IDCompany = IDCompany;
                    if (nameGroup.Length > 250)
                    {
                        aCustomerGroups.Name = nameGroup.Substring(0, 250);
                    }
                    else
                    {
                        aCustomerGroups.Name = nameGroup;
                    }

                    aCustomerGroups.Type = 1;
                    aCustomerGroups.Status = 1;
                    aCustomerGroups.Disable = false;
                    IDCustomerGroup = aCustomerGroupsBO.Insert(aCustomerGroups);
                }
                #endregion

                #region Them moi bookingRs
                if (IDCustomer > 0 && IDCustomerGroup > 0)
                {
                    string subject = "[" + customerType + "][" + aNewBookingEN.NameCompany + "][" + DateTime.Now.ToString() + "]";

                    BookingRs aBookingRs = new BookingRs();

                    aBookingRs.CreatedDate = DateTime.Now;
                    aBookingRs.CustomerType = aNewBookingEN.CustomerType;
                    aBookingRs.BookingType = aNewBookingEN.BookingType;
                    if (subject.Length > 250)
                    {
                        aBookingRs.Subject = subject.Substring(0, 250);
                    }
                    else
                    {
                        aBookingRs.Subject = subject;
                    }
                    aBookingRs.IDCustomerGroup = IDCustomerGroup;
                    aBookingRs.IDCustomer = IDCustomer;
                    aBookingRs.IDSystemUser = aNewBookingEN.IDSystemUser;
                    aBookingRs.PayMenthod = aNewBookingEN.PayMenthod;
                    aBookingRs.StatusPay = aNewBookingEN.StatusPay;
                    aBookingRs.BookingMoney = aNewBookingEN.BookingMoney;
                    aBookingRs.ExchangeRate = aNewBookingEN.ExchangeRate;
                    aBookingRs.Level = 0;// de mac dinh hien tai chua dung den
                    aBookingRs.Note = string.Empty;
                    aBookingRs.Description = string.Empty;
                    aBookingRs.DatePay = aNewBookingEN.CheckOutPlan;
                    aBookingRs.DateEdit = aNewBookingEN.CheckInActual;
                    aBookingRs.Status = aNewBookingEN.Status;
                    aBookingRs.Type = aNewBookingEN.Type;
                    aBookingRs.Disable = aNewBookingEN.Disable;

                    //add new bookingRs
                    BookingRsBO aBookingRsBO = new BookingRsBO();
                    IDBookingR = aBookingRsBO.Insert(aBookingRs);
                }
                #endregion

                #region them moi bookingRoom
                if (IDBookingR > 0)
                {
                    BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                    BookingRooms aBookingRooms;
                    for (int i = 0; i < aNewBookingEN.aListNewRoomMembers.Count; i++)
                    {
                        aBookingRooms = new BookingRooms();
                        aBookingRooms.IDBookingR = IDBookingR;
                        aBookingRooms.CodeRoom = aNewBookingEN.aListNewRoomMembers[i].RoomCode;
                        aBookingRooms.PercentTax = 10;
                        aBookingRooms.CostRef_Rooms = aNewBookingEN.aListNewRoomMembers[i].RoomCostRef;
                        aBookingRooms.Cost = aNewBookingEN.aListNewRoomMembers[i].RoomCostRef;
                        aBookingRooms.CheckInPlan = aNewBookingEN.CheckInActual;
                        aBookingRooms.CheckInActual = aNewBookingEN.CheckInActual;
                        aBookingRooms.CheckOutPlan = aNewBookingEN.CheckOutPlan;
                        aBookingRooms.CheckOutActual = aNewBookingEN.CheckOutActual;
                        aBookingRooms.StartTime = aNewBookingEN.CheckInActual;
                        aBookingRooms.EndTime = aNewBookingEN.CheckOutPlan;
                        aBookingRooms.BookingStatus = 1;
                        aBookingRooms.Type = 3; //Tính CheckIn sớm và CheckOut muộn
                        aBookingRooms.Status = aNewBookingEN.Status;
                        aBookingRooms.PriceType = "G1";
                        //add new bookingRoom
                        aBookingRoomsBO.Insert(aBookingRooms);

                    }
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Hiennv     26/11/2014     Viet lai phuong thuc checkInForRoomBooking
        public bool NewCheckInForRoomBooking(CheckInEN aCheckInEN)
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                List<Customers> aListCustomersTemp = aCustomersBO.Select_All();

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                List<BookingRooms> aListBookingRoomTemp = aBookingRoomsBO.Select_All();

                int IDBookingRooms = 0;
                int IDCompany = 0;
                int IDCustomerGroup = 0;
                int IDCustomer = 0;
                int Result = 0;

                string customerType = string.Empty;


                if (aCheckInEN.CustomerType == 0)
                {
                    customerType = "Tất cả loại khác";
                }
                else if (aCheckInEN.CustomerType == 1)
                {
                    customerType = "Khách nhà nước";
                }
                else if (aCheckInEN.CustomerType == 2)
                {
                    customerType = "Khách đoàn";
                }
                else if (aCheckInEN.CustomerType == 3)
                {
                    customerType = "Khách lẻ";
                }
                else if (aCheckInEN.CustomerType == 4)
                {
                    customerType = "Khách vãng lai";
                }
                else if (aCheckInEN.CustomerType == 5)
                {
                    customerType = "Khách bộ ngoại giao";
                }
                else
                {
                    customerType = string.Empty;
                }


                #region Them moi cong ty khi cong ty chua co
                if (aCheckInEN.IDCompany > 0)
                {
                    IDCompany = aCheckInEN.IDCompany;
                }
                else
                {
                    CompaniesBO aCompaniesBO = new CompaniesBO();
                    Companies aCompanies = new Companies();
                    if (aCheckInEN.NameCompany.Length > 250)
                    {
                        aCompanies.Name = aCheckInEN.NameCompany.Substring(0, 250);
                    }
                    else
                    {
                        aCompanies.Name = aCheckInEN.NameCompany;
                    }

                    aCompanies.TaxNumberCode = string.Empty;
                    aCompanies.Address = string.Empty;
                    aCompanies.Type = aCheckInEN.CustomerType;
                    aCompanies.Status = 1;
                    aCompanies.Disable = false;
                    IDCompany = aCompaniesBO.Insert(aCompanies);
                }
                #endregion

                #region Them moi nhom vao trong cong ty
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                CustomerGroups aCustomerGroups;
                aCustomerGroups = aCustomerGroupsBO.Select_ByIDCompanyAndIDCustomerGroup(IDCompany, aCheckInEN.IDCustomerGroup);

                if (aCustomerGroups == null)
                {

                    aCustomerGroups = new CustomerGroups();

                    string nameGroup = "[" + customerType + "][" + aCheckInEN.NameCompany + "][" + DateTime.Now.ToString() + "]";
                    aCustomerGroups.IDCompany = IDCompany;
                    if (nameGroup.Length > 250)
                    {
                        aCustomerGroups.Name = nameGroup.Substring(0, 250);
                    }
                    else
                    {
                        aCustomerGroups.Name = nameGroup;
                    }

                    aCustomerGroups.Type = 1;
                    aCustomerGroups.Status = 1;
                    aCustomerGroups.Disable = false;
                    IDCustomerGroup = aCustomerGroupsBO.Insert(aCustomerGroups);
                }
                else
                {
                    IDCustomerGroup = aCheckInEN.IDCustomerGroup;
                }
                #endregion



                string subject = "[" + customerType + "][" + aCheckInEN.NameCompany + "][" + DateTime.Now.ToString() + "]";

                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(aCheckInEN.IDBookingR);
                if (aBookingRs != null)
                {
                    aBookingRs.CreatedDate = DateTime.Now;
                    aBookingRs.CustomerType = aCheckInEN.CustomerType;
                    aBookingRs.BookingType = aCheckInEN.BookingType;
                    if (subject.Length > 250)
                    {
                        aBookingRs.Subject = subject.Substring(0, 250);
                    }
                    else
                    {
                        aBookingRs.Subject = subject;
                    }

                    aBookingRs.IDCustomerGroup = IDCustomerGroup;
                    aBookingRs.IDCustomer = aCheckInEN.IDCustomer;
                    aBookingRs.IDSystemUser = aCheckInEN.IDSystemUser;
                    aBookingRs.PayMenthod = aCheckInEN.PayMenthod;
                    aBookingRs.StatusPay = aCheckInEN.StatusPay;
                    aBookingRs.BookingMoney = aCheckInEN.BookingMoney;
                    aBookingRs.ExchangeRate = aCheckInEN.ExchangeRate;
                    aBookingRs.Level = 0;// de mac dinh hien tai chua dung den
                    aBookingRs.Note = string.Empty;
                    aBookingRs.Description = string.Empty;
                    aBookingRs.DatePay = aCheckInEN.CheckOutPlan;
                    aBookingRs.DateEdit = aCheckInEN.CheckInActual;
                    aBookingRs.Status = aCheckInEN.Status;
                    aBookingRs.Type = aCheckInEN.Type;
                    aBookingRs.Disable = aCheckInEN.Disable;
                    aBookingRsBO.Update(aBookingRs);
                }

                //==========================================================
                BookingRooms aBookingRooms;
                BookingRoomsMembers aBookingRoomsMembers;

                for (int i = 0; i < aCheckInEN.aListRoomMembers.Count; i++)
                {

                    List<BookingRooms> aListBookingRoom = aListBookingRoomTemp.Where(r => r.ID == aCheckInEN.aListRoomMembers[i].IDBookingRooms).ToList();
                    if (aListBookingRoom.Count > 0)
                    {
                        aBookingRooms = new BookingRooms();
                        aBookingRooms = aListBookingRoom[0];
                        aBookingRooms.IDBookingR = aCheckInEN.IDBookingR;
                        aBookingRooms.CodeRoom = aCheckInEN.aListRoomMembers[i].RoomCode;
                        aBookingRooms.PercentTax = 10;
                        aBookingRooms.CostRef_Rooms = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                        aBookingRooms.Cost = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                        aBookingRooms.CheckInPlan = aCheckInEN.CheckInActual;
                        aBookingRooms.CheckInActual = aCheckInEN.CheckInActual;
                        aBookingRooms.CheckOutPlan = aCheckInEN.CheckOutPlan;
                        aBookingRooms.CheckOutActual = aCheckInEN.CheckOutActual;
                        aBookingRooms.StartTime = aCheckInEN.CheckInActual;
                        aBookingRooms.EndTime = aCheckInEN.CheckOutPlan;
                        aBookingRooms.BookingStatus = 1;
                        aBookingRooms.Type = 3; //Tính CheckIn sớm và CheckOut muộn
                        aBookingRooms.Status = aCheckInEN.Status;
                        aBookingRooms.PriceType = "G1";
                        aBookingRoomsBO.Update(aBookingRooms);

                        IDBookingRooms = aCheckInEN.aListRoomMembers[i].IDBookingRooms;
                    }
                    else
                    {
                        aBookingRooms = new BookingRooms();
                        aBookingRooms.IDBookingR = aCheckInEN.IDBookingR;
                        aBookingRooms.CodeRoom = aCheckInEN.aListRoomMembers[i].RoomCode;
                        aBookingRooms.PercentTax = 10;
                        aBookingRooms.CostRef_Rooms = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                        aBookingRooms.Cost = aCheckInEN.aListRoomMembers[i].RoomCostRef;
                        aBookingRooms.CheckInPlan = aCheckInEN.CheckInActual;
                        aBookingRooms.CheckInActual = aCheckInEN.CheckInActual;
                        aBookingRooms.CheckOutPlan = aCheckInEN.CheckOutPlan;
                        aBookingRooms.CheckOutActual = aCheckInEN.CheckOutActual;
                        aBookingRooms.StartTime = aCheckInEN.CheckInActual;
                        aBookingRooms.EndTime = aCheckInEN.CheckOutPlan;
                        aBookingRooms.BookingStatus = 1;
                        aBookingRooms.Type = 3; //Tính CheckIn sớm và CheckOut muộn
                        aBookingRooms.Status = aCheckInEN.Status;
                        aBookingRooms.PriceType = "G1";
                        //add new bookingRoom
                        IDBookingRooms = aBookingRoomsBO.Insert(aBookingRooms);
                    }

                    //-----------------------------------------------------------
                    aBookingRoomsMembers = new BookingRoomsMembers();
                    aBookingRoomsMembers.IDBookingRoom = IDBookingRooms;

                    BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                    for (int ii = 0; ii < aCheckInEN.aListRoomMembers[i].ListCustomer.Count; ii++)
                    {
                        Customers aCustomers;
                        List<Customers> aListCustomers = aListCustomersTemp.Where(c => c.ID == aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID).ToList();
                        if (aListCustomers.Count > 0)
                        {
                            IDCustomer = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].ID;
                            aCustomers = aListCustomers[0];
                            aCustomers.Name = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name;
                            aCustomers.Identifier1 = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Identifier1;
                            aCustomers.Birthday = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Birthday;
                            aCustomers.Gender = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Gender;
                            aCustomers.Tel = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Tel;
                            aCustomers.Nationality = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Nationality;
                            aCustomersBO.Update(aCustomers);
                        }
                        else
                        {
                            aCustomers = new Customers();
                            aCustomers.Name = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name;
                            aCustomers.Identifier1 = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Identifier1;
                            aCustomers.Birthday = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Birthday;
                            aCustomers.Gender = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Gender;
                            aCustomers.Tel = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Tel;
                            aCustomers.Nationality = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Nationality;

                            //Them moi khach hang
                            IDCustomer = aCustomersBO.Insert(aCustomers);
                        }
                        aBookingRoomsMembers.IDCustomer = IDCustomer;
                        aBookingRoomsMembers.PurposeComeVietnam = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].PurposeComeVietnam;
                        aBookingRoomsMembers.DateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].DateEnterCountry;
                        aBookingRoomsMembers.EnterGate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].EnterGate;
                        aBookingRoomsMembers.TemporaryResidenceDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].TemporaryResidenceDate;
                        aBookingRoomsMembers.LimitDateEnterCountry = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LimitDateEnterCountry;
                        aBookingRoomsMembers.Organization = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Organization;
                        aBookingRoomsMembers.LeaveDate = aCheckInEN.aListRoomMembers[i].ListCustomer[ii].LeaveDate;

                        //add new bookingRoomMember
                        aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);

                        #region  them nguoi vao trong customergroup_customer

                        string nameCustomerGroup_customer = "[" + customerType + "][" + aCheckInEN.aListRoomMembers[i].ListCustomer[ii].Name + "]";

                        CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                        CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
                        if (nameCustomerGroup_customer.Length > 150)
                        {
                            aCustomerGroups_Customers.Name = nameCustomerGroup_customer.Substring(0, 150);
                        }
                        else
                        {
                            aCustomerGroups_Customers.Name = nameCustomerGroup_customer;
                        }

                        aCustomerGroups_Customers.Type = 1;
                        aCustomerGroups_Customers.Status = 1;
                        aCustomerGroups_Customers.Disable = false;
                        aCustomerGroups_Customers.FromDate = DateTime.Now;
                        aCustomerGroups_Customers.ToDate = DateTime.Now;
                        aCustomerGroups_Customers.IDCustomer = IDCustomer;
                        aCustomerGroups_Customers.IDCustomerGroup = IDCustomerGroup;
                        aCustomerGroups_CustomersBO.Insert(aCustomerGroups_Customers);
                        #endregion


                        // dung de cap nhap lai nguoi dai dien khi dat phong
                        if (aCheckInEN.aListRoomMembers[i].ListCustomer[ii].PepoleRepresentative == true)
                        {
                            aBookingRsBO = new BookingRsBO();
                            aBookingRs = new BookingRs();
                            aBookingRs = aBookingRsBO.Select_ByID(aCheckInEN.IDBookingR);
                            if (aBookingRs != null)
                            {
                                aBookingRs.IDCustomer = IDCustomer;
                                Result = aBookingRsBO.Update(aBookingRs);
                            }

                        }
                        else
                        {
                            if (ii == (aCheckInEN.aListRoomMembers[i].ListCustomer.Count - 1))
                            {
                                if (Result == 0)
                                {
                                    aBookingRsBO = new BookingRsBO();
                                    aBookingRs = new BookingRs();
                                    aBookingRs = aBookingRsBO.Select_ByID(aCheckInEN.IDBookingR);
                                    if (aBookingRs != null)
                                    {
                                        aBookingRs.IDCustomer = IDCustomer;
                                        aBookingRsBO.Update(aBookingRs);
                                    }
                                }
                            }
                        }

                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Ngoc
        public int CheckOutFirstRoom(int IDBookingRoom, DateTime CheckOut)
        {
            try
            {
                /*Ghi chu TypeBookingRooms
                * 
                * Type = 2: //Tính checkin sớm , không tính checkout muộn.
                * Type = 0: //Không tính checkIn sớm và checkout muộn.
                * Type = 3: //Tính checkin sớm và Checkout muộn
                * Type = 1: //Không tính checkin sớm , tính checkout muộn
                */
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);

                if (aBookingRooms != null)
                {
                    aBookingRooms.CheckOutActual = CheckOut;
                    int updateType = -1;
                    if (aBookingRooms.Type == 2)
                    {
                        updateType = 2;
                    }
                    else if (aBookingRooms.Type == 0)
                    {
                        updateType = 0;
                    }
                    else if (aBookingRooms.Type == 3)
                    {
                        updateType = 2;
                    }
                    else if (aBookingRooms.Type == 1)
                    {
                        updateType = 0;
                    }
                    else
                    {
                        updateType = 3;
                    }
                    aBookingRooms.Type = updateType;
                    aBookingRooms.Status = 7;//da checkout nhung chua thanh toan
                    aBookingRooms.TimeInUse = decimal.Parse(aReceptionTaskBO.GetTimeInUsed(aBookingRooms.CheckInActual, CheckOut).ToString());
                    aBookingRooms.AddTimeStart = aReceptionTaskBO.GetAddTimeStart(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckInActual);
                    aBookingRooms.AddTimeEnd =  aReceptionTaskBO.GetAddTimeEnd(aBookingRooms.Type.GetValueOrDefault(0), CheckOut);
                    
                    return aBookingRoomsBO.Update(aBookingRooms);



                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int CheckOut(int IDBookingRoom, DateTime CheckOut)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);
                if (aBookingRooms != null)
                {
                    aBookingRooms.CheckOutActual = CheckOut;
                    aBookingRooms.Status = 7;//da checkout nhung chua thanh toan
                    aBookingRooms.TimeInUse = decimal.Parse(aReceptionTaskBO.GetTimeInUsed(aBookingRooms.CheckInActual, CheckOut).ToString());
                    aBookingRooms.AddTimeStart = aReceptionTaskBO.GetAddTimeStart(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckInActual);
                    aBookingRooms.AddTimeEnd = aReceptionTaskBO.GetAddTimeEnd(aBookingRooms.Type.GetValueOrDefault(0), CheckOut);
                    return aBookingRoomsBO.Update(aBookingRooms);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //NgocBM 24/12/2014
        public bool CheckInNewRoom(ItemChangeRoomEN aItem)
        {
            try
            {
                BookingRooms aBookingRooms = new BookingRooms();
                aBookingRooms = aItem.GetBookingRooms();

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();

                int IDBookingRoom = aBookingRoomsBO.Insert(aBookingRooms);

                //-----------------------------------------------------------
                // Cao nhatj danh sach nguoi trong phong
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();

                List<CustomerInfoEN> aList = new List<CustomerInfoEN>();
                aList = aItem.GetAllCustomers();
                for (int i = 0; i < aList.Count; i++)
                {
                    BookingRoomsMembers aBookingRoomsMembers = new BookingRoomsMembers();
                    aBookingRoomsMembers.DateEnterCountry = aList[i].DateEnterCountry;
                    aBookingRoomsMembers.EnterGate = aList[i].EnterGate;
                    aBookingRoomsMembers.LeaveDate = aList[i].LeaveDate;
                    aBookingRoomsMembers.LimitDateEnterCountry = aList[i].LimitDateEnterCountry;
                    aBookingRoomsMembers.Organization = aList[i].Organization;

                    aBookingRoomsMembers.PurposeComeVietnam = aList[i].PurposeComeVietnam;
                    aBookingRoomsMembers.TemporaryResidenceDate = aList[i].TemporaryResidenceDate;

                    aBookingRoomsMembers.IDBookingRoom = IDBookingRoom;

                    aBookingRoomsMembers.IDCustomer = aList[i].ID;

                    aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);
                }
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }

        }
        

        public List<vw__BookingRInfo__BookingRooms_Rooms_SystemUsers_Customers_CustomerGroups> GetListRoomInUse()
        {
            List<vw__BookingRInfo__BookingRooms_Rooms_SystemUsers_Customers_CustomerGroups> aList = aDatabaseDA.vw__BookingRInfo__BookingRooms_Rooms_SystemUsers_Customers_CustomerGroups.Where(p => p.BookingRooms_Status < 7).Where(p => p.BookingRooms_Status >= 3).Where(p=>p.Rooms_IDLang ==1).Distinct().ToList();

            return aList;
            
            
        }


        public List<int> CheckAvaiableRoom(int IDBookingRoom, string CodeRoom, DateTime From, DateTime To)
        {
            List<BookingRooms> aList = aDatabaseDA.BookingRooms.Where(p => p.CodeRoom == CodeRoom).Where(e => e.CheckInActual <= From && e.CheckOutPlan >= From || e.CheckInActual <= To && e.CheckOutPlan >= To).Where(p => p.ID != IDBookingRoom).ToList();
            if (aList.Count > 0)
            {
                return aList.Select(p => p.ID).ToList();
            }
            else
            {
                return new List<int>();
            }
        }

    }
}

