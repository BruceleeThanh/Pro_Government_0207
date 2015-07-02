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
    public class AccountancyBO
    {
        public void PaymentRoom(NewPaymentEN aNewPaymentEN)
        {
            if (aNewPaymentEN.IDBookingH != null)
            {
                foreach (BookingRoomUsedEN item in aNewPaymentEN.aListBookingRoomUsed)
                {
                    if (item.Status == 7)
                    {
                        item.Status = 8;
                    }
                    else
                    {
                        item.Status = 8;
                        item.CheckOutActual = DateTime.Now;
                    }
                    foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                    {
                        item1.StatusPay = 8;
                    }                    
                    this.SaveBookingRoom(item);
                }
            }
            else
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList().Count > 0)
                {
                    BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList()[0];
                    aTemp.DatePay = DateTime.Now;
                    aTemp.Status = 8;
                    aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate;
                    aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                    aTemp.BookingMoney = aNewPaymentEN.BookingRMoney;
                    aTemp.AcceptDate = aNewPaymentEN.AcceptDate;

                    aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                    aDatabaseDA.SaveChanges();
                    foreach (BookingRoomUsedEN item in aNewPaymentEN.aListBookingRoomUsed)
                    {

                        if (item.Status == 7)
                        {
                            item.Status = 8;
                        }
                        else
                        {
                            item.Status = 8;
                            item.CheckOutActual = DateTime.Now;
                        }
                        foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                        {
                            item1.StatusPay = 8;
                        }
                        this.SaveBookingRoom(item);
                    }
                }

            }


        }
        public void PaymentHall(NewPaymentEN aNewPaymentEN)
        {
            DatabaseDA aDatabaseDA = new DatabaseDA();
            if (aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentEN.IDBookingH).ToList().Count > 0)
            {
                BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentEN.IDBookingH).ToList()[0];
                aTemp.CreatedDate = aNewPaymentEN.CreatedDate_BookingH;
                aTemp.Status = 8;
                aTemp.BookingMoney = aNewPaymentEN.BookingHMoney;
                aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate;
                aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                aTemp.DatePay = DateTime.Now;
                aTemp.AcceptDate = aNewPaymentEN.AcceptDate;

                aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                aDatabaseDA.SaveChanges();
                foreach (BookingHallUsedEN item in aNewPaymentEN.aListBookingHallUsed)
                {

                    foreach (ServiceUsedEN item1 in item.aListServiceUsed)
                    {
                        item1.StatusPay = 8;
                    }
                    item.Status = 8;
                    this.SaveBookingHall(item);
                }
            }

        }
        public void PaymentHall(NewPaymentHEN aNewPaymentHEN)
        {
            DatabaseDA aDatabaseDA = new DatabaseDA();
            if (aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentHEN.IDBookingH).ToList().Count > 0)
            {
                BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentHEN.IDBookingH).ToList()[0];
                aTemp.CreatedDate = aNewPaymentHEN.CreatedDate_BookingH;
                aTemp.Status = 8;
                aTemp.BookingMoney = aNewPaymentHEN.BookingHMoney;
                aTemp.InvoiceDate = aNewPaymentHEN.InvoiceDate;
                aTemp.InvoiceNumber = aNewPaymentHEN.InvoiceNumber;
                aTemp.DatePay = DateTime.Now;
                aTemp.AcceptDate = aNewPaymentHEN.AcceptDate;


                aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                aDatabaseDA.SaveChanges();
                foreach (BookingHallUsedEN item in aNewPaymentHEN.aListBookingHallUsed)
                {

                    foreach (ServiceUsedEN item1 in item.aListServiceUsed)
                    {
                        item1.StatusPay = 8;
                    }
                    item.Status = 8;
                    this.SaveBookingHall(item);
                }
            }
        }
        public void PaymentTotal(NewPaymentEN aNewPaymentEN)
        {
            if (aNewPaymentEN.aListBookingHallUsed.Count > 0)
            {
                this.PaymentHall(aNewPaymentEN);
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList().Count > 0)
                {
                    BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList()[0];
                    aTemp.DatePay = DateTime.Now;
                    aTemp.Status = 8;
                    aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate;
                    aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                    aTemp.BookingMoney = aNewPaymentEN.BookingRMoney;
                    aTemp.AcceptDate = aNewPaymentEN.AcceptDate;

                    aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                    aDatabaseDA.SaveChanges();
                    foreach (BookingRoomUsedEN item in aNewPaymentEN.aListBookingRoomUsed)
                    {

                        foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                        {
                            item1.StatusPay = 8;
                        }
                        item.Status = 8;
                        item.CheckOutActual = DateTime.Now;
                        this.SaveBookingRoom(item);
                    }
                }
            }
            else
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList().Count > 0)
                {
                    BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList()[0];
                    aTemp.DatePay = DateTime.Now;
                    aTemp.Status = 8;
                    aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate;
                    aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                    aTemp.BookingMoney = aNewPaymentEN.BookingRMoney;
                    aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                    aDatabaseDA.SaveChanges();
                    foreach (BookingRoomUsedEN item in aNewPaymentEN.aListBookingRoomUsed)
                    {

                        foreach (ServiceUsedEN item1 in item.ListServiceUsed)
                        {
                            item1.StatusPay = 8;
                        }
                        item.Status = 8;
                        item.CheckOutActual = DateTime.Now;
                        this.SaveBookingRoom(item);
                    }
                }
            }
        }
        public void SaveBookingHall(BookingHallUsedEN aBookingHallUsedEN)
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                BookingHalls aTemp = aDatabaseDA.BookingHalls.Where(a => a.ID == aBookingHallUsedEN.ID).ToList()[0];
                if (aTemp != null)
                {
                    aTemp.ID = aBookingHallUsedEN.ID;
                    aTemp.CodeHall = aBookingHallUsedEN.CodeHall;
                    aTemp.Cost = aBookingHallUsedEN.Cost;
                    aTemp.PercentTax = aBookingHallUsedEN.PercentTax;
                    aTemp.CostRef_Halls = aBookingHallUsedEN.CostRef_Halls;
                    aTemp.Date = aBookingHallUsedEN.Date;
                    aTemp.LunarDate = aBookingHallUsedEN.LunarDate;
                    aTemp.BookingStatus = aBookingHallUsedEN.BookingStatus;
                    aTemp.Unit = aBookingHallUsedEN.Unit;
                    aTemp.TableOrPerson = aBookingHallUsedEN.TableOrPerson;
                    aTemp.Note = aBookingHallUsedEN.Note;
                    aTemp.Status = aBookingHallUsedEN.Status;
                    aTemp.Location = aBookingHallUsedEN.Location;
                    aTemp.StartTime = aBookingHallUsedEN.StartTime;
                    aTemp.EndTime = aBookingHallUsedEN.EndTime;
                    aTemp.IsAllDayEvent = aBookingHallUsedEN.IsAllDayEvent;
                    aTemp.Color = aBookingHallUsedEN.Color;
                    aTemp.IsRecurring = aBookingHallUsedEN.IsRecurring;
                    aTemp.IsEditable = aBookingHallUsedEN.IsEditable;
                    aTemp.AdditionalColumn1 = aBookingHallUsedEN.AdditionalColumn1;
                    aTemp.IDBookingH = aBookingHallUsedEN.IDBookingH;
                    aTemp.IndexSubPayment = aBookingHallUsedEN.IndexSubPayment;
                    aTemp.AcceptDate = aBookingHallUsedEN.AcceptDate;
                    aTemp.InvoiceDate = aBookingHallUsedEN.InvoiceDate;
                    aTemp.InvoiceNumber = aBookingHallUsedEN.InvoiceNumber;

                    foreach (ServiceUsedEN item in aBookingHallUsedEN.aListServiceUsed)
                    {
                        this.SaveServiceUsed(item, 2);
                    }
                    aDatabaseDA.BookingHalls.AddOrUpdate(aTemp);
                    aDatabaseDA.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BookingHallUsedEN.Save :" + ex.Message.ToString()));
            }
        }
        public int SaveBookingRoom(BookingRoomUsedEN aBookingRoomUsedEN)
        {

            DatabaseDA aDatabaseDA = new DatabaseDA();
            BookingRooms aTemp = aDatabaseDA.BookingRooms.Where(a => a.ID == aBookingRoomUsedEN.ID).ToList()[0];
            aTemp.ID = aBookingRoomUsedEN.ID;
            aTemp.IDBookingR = aBookingRoomUsedEN.IDBookingR;
            aTemp.CodeRoom = aBookingRoomUsedEN.CodeRoom;
            aTemp.Cost = aBookingRoomUsedEN.Cost;
            aTemp.PercentTax = aBookingRoomUsedEN.PercentTax;
            aTemp.CostRef_Rooms = aBookingRoomUsedEN.CostRef_Rooms;
            aTemp.Note = aBookingRoomUsedEN.Note;
            aTemp.CheckInPlan = aBookingRoomUsedEN.CheckInPlan;
            aTemp.CheckInActual = aBookingRoomUsedEN.CheckInActual;
            aTemp.CheckOutPlan = aBookingRoomUsedEN.CheckOutPlan;
            aTemp.CheckOutActual = aBookingRoomUsedEN.CheckOutActual;
            aTemp.BookingStatus = aBookingRoomUsedEN.BookingStatus;
            aTemp.Status = aBookingRoomUsedEN.Status;

            aTemp.StartTime = aBookingRoomUsedEN.StartTime;
            aTemp.EndTime = aBookingRoomUsedEN.EndTime;
            
            aTemp.IsAllDayEvent = aBookingRoomUsedEN.IsAllDayEvent;
            aTemp.Color = aBookingRoomUsedEN.Color;
            aTemp.IsRecurring = aBookingRoomUsedEN.IsRecurring;
            aTemp.IsEditable = aBookingRoomUsedEN.IsEditable;
            aTemp.AdditionalColumn1 = aBookingRoomUsedEN.AdditionalColumn1;
            aTemp.CostPendingRoom = aBookingRoomUsedEN.CostPendingRoom;
            aTemp.TimeInUse = aBookingRoomUsedEN.TimeInUse;
            aTemp.AddTimeStart = aBookingRoomUsedEN.AddTimeStart;
            aTemp.AddTimeEnd = aBookingRoomUsedEN.AddTimeEnd;

            aTemp.Type = aBookingRoomUsedEN.Type;

            aTemp.Disable = aBookingRoomUsedEN.Disable;
            aTemp.IndexSubPayment = aBookingRoomUsedEN.IndexSubPayment;
            aTemp.AcceptDate = aBookingRoomUsedEN.AcceptDate;
            aTemp.InvoiceDate = aBookingRoomUsedEN.InvoiceDate;
            aTemp.InvoiceNumber = aBookingRoomUsedEN.InvoiceNumber;

            foreach (ServiceUsedEN item in aBookingRoomUsedEN.ListServiceUsed)
            {
                this.SaveServiceUsed(item, 1);
            }
            aTemp.PriceType = aBookingRoomUsedEN.PriceType;
            aDatabaseDA.BookingRooms.AddOrUpdate(aTemp);
            return aDatabaseDA.SaveChanges();


        }
        public void SaveServiceUsed(ServiceUsedEN aServiceUsedEN, int ServiceType)
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (ServiceType == 1)
                {


                    if (aDatabaseDA.BookingRooms_Services.Where(b => b.ID == aServiceUsedEN.IDBookingService).ToList().Count > 0)
                    {
                        BookingRooms_Services aTemp = aDatabaseDA.BookingRooms_Services.Where(b => b.ID == aServiceUsedEN.IDBookingService).ToList()[0];
                        aTemp.Cost = aServiceUsedEN.Cost;
                        aTemp.CostRef_Services = aServiceUsedEN.CostRef_Service;
                        aTemp.Date = aServiceUsedEN.DateUsed;
                        aTemp.PercentTax = aServiceUsedEN.Tax;
                        aTemp.Quantity = aServiceUsedEN.Quantity;
                        aTemp.Status = aServiceUsedEN.StatusPay;
                        aTemp.ID = aServiceUsedEN.IDBookingService;
                        aTemp.IndexSubPayment = aServiceUsedEN.IndexSubPayment;
                        aTemp.AcceptDate = aServiceUsedEN.AcceptDate;
                        aTemp.InvoiceDate = aServiceUsedEN.InvoiceDate;
                        aTemp.InvoiceNumber = aServiceUsedEN.InvoiceNumber;
                        aDatabaseDA.BookingRooms_Services.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                }
                else if (ServiceType == 2)
                {
                    if (aDatabaseDA.BookingHalls_Services.Where(b => b.ID == aServiceUsedEN.IDBookingService).ToList().Count > 0)
                    {
                        BookingHalls_Services aTemp = aDatabaseDA.BookingHalls_Services.Where(b => b.ID == aServiceUsedEN.IDBookingService).ToList()[0];
                        aTemp.Cost = aServiceUsedEN.Cost;
                        aTemp.CostRef_Services = aServiceUsedEN.CostRef_Service;
                        aTemp.Date = aServiceUsedEN.DateUsed;
                        aTemp.PercentTax = aServiceUsedEN.Tax;
                        aTemp.Quantity = aServiceUsedEN.Quantity;
                        aTemp.Status = aServiceUsedEN.StatusPay;
                        aTemp.ID = aServiceUsedEN.IDBookingService;
                        aTemp.IndexSubPayment = aServiceUsedEN.IndexSubPayment;
                        aTemp.AcceptDate = aServiceUsedEN.AcceptDate;
                        aTemp.InvoiceDate = aServiceUsedEN.InvoiceDate;
                        aTemp.InvoiceNumber = aServiceUsedEN.InvoiceNumber;
                        aDatabaseDA.BookingHalls_Services.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ServiceUsedEN.Save :" + ex.Message.ToString()));
            }
        }
        public void Save(NewPaymentEN aNewPaymentEN)
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (aNewPaymentEN.IDBookingR != null)
                {
                    BookingRs aTemp = aDatabaseDA.BookingRs.Where(a => a.ID == aNewPaymentEN.IDBookingR).ToList()[0];
                    if (aTemp != null)
                    {
                        aTemp.CreatedDate = aNewPaymentEN.CreatedDate_BookingR;
                        aTemp.ID = Convert.ToInt32(aNewPaymentEN.IDBookingR);
                        aTemp.Status = aNewPaymentEN.Status_BookingR;
                        aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                        aTemp.AcceptDate = aNewPaymentEN.AcceptDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));
                        aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate.GetValueOrDefault(Convert.ToDateTime("01/01/1900"));
                        aTemp.BookingMoney = aNewPaymentEN.BookingRMoney;
                        aTemp.PayMenthod = aNewPaymentEN.PayMenthodR;

                        aDatabaseDA.BookingRs.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                    foreach (BookingRoomUsedEN item in aNewPaymentEN.aListBookingRoomUsed)
                    {
                        int a = this.SaveBookingRoom(item);
                    }
                }
                if (aNewPaymentEN.IDBookingH >0)
                {

                    BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentEN.IDBookingH).ToList()[0];
                    if (aTemp != null)
                    {
                        aTemp.CreatedDate = aNewPaymentEN.CreatedDate_BookingH;
                        aTemp.ID = Convert.ToInt32(aNewPaymentEN.IDBookingH);
                        aTemp.Status = aNewPaymentEN.Status_BookingH;
                        aTemp.BookingMoney = aNewPaymentEN.BookingHMoney;
                        aTemp.InvoiceNumber = aNewPaymentEN.InvoiceNumber;
                        aTemp.AcceptDate = aNewPaymentEN.AcceptDate;
                        aTemp.InvoiceDate = aNewPaymentEN.InvoiceDate;
                        aTemp.PayMenthod = aNewPaymentEN.PayMenthodH;
                        aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                    foreach (BookingHallUsedEN item in aNewPaymentEN.aListBookingHallUsed)
                    {
                        this.SaveBookingHall(item);
                    }
                }
                // Luu thong tin cong ty
                Companies aCompany = aDatabaseDA.Companies.Where(a => a.ID == aNewPaymentEN.IDCompany).ToList()[0];
                aCompany.TaxNumberCode = aNewPaymentEN.TaxNumberCodeCompany;
                aCompany.Address = aNewPaymentEN.AddressCompany;
                aCompany.ID = Convert.ToInt32(aNewPaymentEN.IDCompany);
                aDatabaseDA.Companies.AddOrUpdate(aCompany);
                aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AccountancyBO.Save :" + ex.Message.ToString()));
            }
        }
        public void Save(NewPaymentHEN aNewPaymentHEN)
        {
            try
            {
                DatabaseDA aDatabaseDA = new DatabaseDA();
                if (aNewPaymentHEN.IDBookingH != null)
                {

                    BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == aNewPaymentHEN.IDBookingH).ToList()[0];
                    if (aTemp != null)
                    {
                        aTemp.CreatedDate = aNewPaymentHEN.CreatedDate_BookingH;
                        aTemp.ID = Convert.ToInt32(aNewPaymentHEN.IDBookingH);
                        aTemp.Status = aNewPaymentHEN.Status_BookingH;
                        aTemp.BookingMoney = aNewPaymentHEN.BookingHMoney;
                        aTemp.InvoiceNumber = aNewPaymentHEN.InvoiceNumber;
                        aTemp.AcceptDate = aNewPaymentHEN.AcceptDate;
                        aTemp.InvoiceDate = aNewPaymentHEN.InvoiceDate;
                        aTemp.PayMenthod = aNewPaymentHEN.PayMenthodH;
                        aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                        aDatabaseDA.SaveChanges();
                    }
                    foreach (BookingHallUsedEN item in aNewPaymentHEN.aListBookingHallUsed)
                    {
                        this.SaveBookingHall(item);
                    }
                }
                // Luu thong tin cong ty
                Companies aCompany = aDatabaseDA.Companies.Where(a => a.ID == aNewPaymentHEN.IDCompany).ToList()[0];
                aCompany.TaxNumberCode = aNewPaymentHEN.TaxNumberCodeCompany;
                aCompany.Address = aNewPaymentHEN.AddressCompany;
                aCompany.ID = Convert.ToInt32(aNewPaymentHEN.IDCompany);
                aDatabaseDA.Companies.AddOrUpdate(aCompany);
                aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("AccountancyBO.Save :" + ex.Message.ToString()));
            }
        }

        //public decimal? CalculateCostRoom(NewPaymentEN aNewPaymentEN, int IDBookingRoom, string PriceType)
        //{
        //    if (aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList().Count > 0)
        //    {
        //        CustomersBO aCustomersBO = new CustomersBO();
        //        ExtraCostBO aExtraCostBO = new ExtraCostBO();
        //        RoomsBO aRoomsBO = new RoomsBO();
        //        BookingRoomUsedEN aTemp = aNewPaymentEN.aListBookingRoomUsed.Where(a => a.ID == IDBookingRoom).ToList()[0];
        //        List<Customers> aListCustomers = aCustomersBO.SelectListCustomer_ByIDBookingRoom(IDBookingRoom);
        //        if (aListCustomers.Count >0 )
        //        {
        //        int CustomerType = Convert.ToInt32(aNewPaymentEN.CustomerType);
        //        decimal? CostRoom = 0;
        //        //if (aTemp.Cost != 0)
        //        //{
        //        //    CostRoom = aTemp.Cost - Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(aTemp.RoomSku, aTemp.PriceType, aTemp.ListCustomer.Count).ExtraValue);

        //        //}
        //        //else
        //        //{
        //        CostRoom = aRoomsBO.Select_ByIDBookingRoom(IDBookingRoom).CostRef;
        //        //}
        //        string RoomSku = aTemp.RoomSku;

        //        decimal ExtraMoneyRoom = Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(RoomSku, PriceType, aListCustomers.Count).ExtraValue);

        //        return (CostRoom + ExtraMoneyRoom);
        //        }
        //        else  // Neu phong k co ai thi tien  =0 
        //        {
        //            return 0;
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public decimal? CalculateCostRoom( int IDBookingRoom, string PriceType , int CustomerType, int NumCustomer )
        {
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();

            if (aBookingRoomsBO.Select_ByID(IDBookingRoom) != null)
            {
                CustomersBO aCustomersBO = new CustomersBO();
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                RoomsBO aRoomsBO = new RoomsBO();
                //List<Customers> aListCustomers = aCustomersBO.SelectListCustomer_ByIDBookingRoom(IDBookingRoom);
               
                decimal? CostRoom = 0;
                
                CostRoom = aRoomsBO.Select_ByIDBookingRoom(IDBookingRoom).CostRef;

                string RoomSku = aRoomsBO.Select_ByIDBookingRoom(IDBookingRoom).Sku;

                try
                {
                    decimal? ExtraMoneyRoom = aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(RoomSku, PriceType, NumCustomer).ExtraValue;
                    return (CostRoom + ExtraMoneyRoom);
                }
                catch(Exception w)
                {
                    MessageBox.Show("Trong dữ liệu giá bảng giá " + PriceType + " của phòng " + RoomSku + " chưa có giá dành cho " + NumCustomer + " người ");
                    return 0;
                }
               
            }
            else
            {
                return 0;
            }
        }

        public decimal? CalculateCostRoom(string CodeRoom, string PriceType, int CustomerType, int NumCustomer)
        {
            if (NumCustomer > 0)
            {
                CustomersBO aCustomersBO = new CustomersBO();
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                RoomsBO aRoomsBO = new RoomsBO();
                //List<Customers> aListCustomers = aCustomersBO.SelectListCustomer_ByIDBookingRoom(IDBookingRoom);

                decimal? CostRoom = 0;

                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(CodeRoom, 1);
                CostRoom = aRooms.CostRef;
                string RoomSku = aRooms.Sku;

                decimal ExtraMoneyRoom = Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(RoomSku, PriceType, NumCustomer).ExtraValue);

                return (CostRoom + ExtraMoneyRoom);
            }
            else
            {
                return 0;
            }
        }

        public void CheckOut(int IDBookingRoom, DateTime TimeCheckOut)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();

                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);
                List<BookingRoomsMembers> aListCus = aBookingRoomsMembersBO.Select_ByIDBookingRoom(IDBookingRoom);
                aBookingRooms.CheckOutActual = TimeCheckOut;
                aBookingRooms.Status = 7;
                aBookingRooms.AddTimeStart = Convert.ToDouble(aReceptionTaskBO.GetAddTimeStart(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckInActual));
                aBookingRooms.AddTimeEnd = Convert.ToDouble(aReceptionTaskBO.GetAddTimeEnd(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckOutActual));
                aBookingRooms.TimeInUse = Convert.ToDecimal(aReceptionTaskBO.GetTimeInUsed( aBookingRooms.CheckInActual, aBookingRooms.CheckOutActual) * 24 * 60);
                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom, 1);
                if (aRooms != null)
                {
                    if (aBookingRooms.Cost == null)
                    {
                        decimal? cost = 0;
                        cost = aBookingRooms.CostRef_Rooms;
                        aBookingRooms.Cost = cost + Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(aRooms.Sku, aBookingRooms.PriceType, aListCus.Count).ExtraValue);
                    }
                }

                aBookingRoomsBO.Update(aBookingRooms);
            }
            catch (Exception ex)
            {

                throw new Exception("AccountancyBO.CheckOut\n" + ex.ToString());
            }
        }
        public void CheckOut(int IDBookingRoom)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();

                BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);
                List<BookingRoomsMembers> aListCus = aBookingRoomsMembersBO.Select_ByIDBookingRoom(IDBookingRoom);
                aBookingRooms.CheckOutActual = DateTime.Now;
                aBookingRooms.Status = 7;
                aBookingRooms.AddTimeStart = Convert.ToDouble(aReceptionTaskBO.GetAddTimeStart(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckInActual));
                aBookingRooms.AddTimeEnd = Convert.ToDouble(aReceptionTaskBO.GetAddTimeEnd(aBookingRooms.Type.GetValueOrDefault(0), aBookingRooms.CheckOutActual));
                aBookingRooms.TimeInUse = Convert.ToDecimal(aReceptionTaskBO.GetTimeInUsed(aBookingRooms.CheckInActual, aBookingRooms.CheckOutActual) * 24 * 60);
                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom, 1);
                if (aRooms != null)
                {
                    if (aBookingRooms.Cost == null)
                    {
                        decimal? cost = 0;
                        cost = aBookingRooms.CostRef_Rooms;
                        aBookingRooms.Cost = cost + Convert.ToDecimal(aExtraCostBO.Select_BySku_ByPriceType_ByNumberPeople(aRooms.Sku, aBookingRooms.PriceType, aListCus.Count).ExtraValue);
                    }
                }

                aBookingRoomsBO.Update(aBookingRooms);
            }
            catch (Exception ex)
            {

                throw new Exception("AccountancyBO.CheckOut\n" + ex.ToString());
            }
        }


    }
}
