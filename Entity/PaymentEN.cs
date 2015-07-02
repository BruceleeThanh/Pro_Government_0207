using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{

    public class PaymentEN
    {
        public int IDBookingR { get; set; }
        public int IDCustomer { get; set; }
        public string NameCustomer { get; set; }
        public int IDSystemUser { get; set; }
        public string NameSystemUser { get; set; }
        public int IDCustomerGroup { get; set; }
        public string NameCustomerGroup { get; set; }
        public int IDCompany { get; set; }
        public string NameCompany { get; set; }
        public string TaxNumberCodeCompany { get; set; }
        public string AddressCompany { get; set; }

        public Nullable<System.DateTime> CreatedDate_BookingR { get; set; }
        public Nullable<int> CustomerType { get; set; }
        public Nullable<int> BookingType { get; set; }
        public Nullable<int> PayMenthod { get; set; }
        public Nullable<int> StatusPay { get; set; }
        public Nullable<decimal> BookingMoney { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> Status_BookingR { get; set; }

        public int Level { get; set; }



        public List<InfoDetailPaymentEN> aListInfoDetailPaymentEN = new List<InfoDetailPaymentEN>();

        public List<IndexSubSplitBillEN> aListIndexSubSplitBillR = new List<IndexSubSplitBillEN>();
        //Hiennv
        public decimal? GetTotalMoneyServicesRoomsBeforeTax()
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    ServicesEN aServicesEn;
                    for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                    {
                        aServicesEn = new ServicesEN();
                        aServicesEn = this.aListInfoDetailPaymentEN[i].aListService[ii];

                        if (this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == null || this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aListService[ii].CostRef_Service;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aListService[ii].Cost;
                        }
                        ret = ret + (cost * Convert.ToDecimal(aServicesEn.Quantity));
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMoneyServicesRoomsBeforeTax\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? GetTotalMoneyServicesRoomsAfterTax()
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    ServicesEN aServicesEn;
                    for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                    {
                        aServicesEn = new ServicesEN();
                        aServicesEn = this.aListInfoDetailPaymentEN[i].aListService[ii];

                        if (this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == null || this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aListService[ii].CostRef_Service;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aListService[ii].Cost;
                        }

                        decimal? NotTax = cost * Convert.ToDecimal(aServicesEn.Quantity);
                        decimal? Tax = NotTax * Convert.ToDecimal(aServicesEn.PercentTax) / 100;
                        ret = ret + NotTax + Tax;
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMoneyServicesRoomsAfterTax\n" + ex.ToString());
            }


        }
        //Hiennv
        public decimal? GetTotalMoneyServicesRoomsBeforeTax_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        ServicesEN aServicesEn;
                        for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                        {
                            aServicesEn = new ServicesEN();
                            aServicesEn = this.aListInfoDetailPaymentEN[i].aListService[ii];

                            if (this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == null || this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == 0)
                            {
                                cost = this.aListInfoDetailPaymentEN[i].aListService[ii].CostRef_Service;
                            }
                            else
                            {
                                cost = this.aListInfoDetailPaymentEN[i].aListService[ii].Cost;
                            }
                            ret = ret + (cost * Convert.ToDecimal(aServicesEn.Quantity));
                        }

                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMoneyServicesRoomsBeforeTax\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? GetTotalMoneyServicesRoomsAfterTax_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        ServicesEN aServicesEn;
                        for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                        {
                            aServicesEn = new ServicesEN();
                            aServicesEn = this.aListInfoDetailPaymentEN[i].aListService[ii];

                            if (this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == null || this.aListInfoDetailPaymentEN[i].aListService[ii].Cost == 0)
                            {
                                cost = this.aListInfoDetailPaymentEN[i].aListService[ii].CostRef_Service;
                            }
                            else
                            {
                                cost = this.aListInfoDetailPaymentEN[i].aListService[ii].Cost;
                            }

                            decimal? NotTax = cost * Convert.ToDecimal(aServicesEn.Quantity);
                            decimal? Tax = NotTax * Convert.ToDecimal(aServicesEn.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }

                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMoneyServicesRoomsAfterTax\n" + ex.ToString());
            }


        }
        //Hiennv
        public decimal? GetTotalMoneyRoomsBeforeTax()
        {
            try
            {
                decimal? sumMoneyRooms = 0;
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {

                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == null || this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == 0)
                    {
                        cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.CostRef_Rooms;
                    }
                    else
                    {
                        cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost;
                    }

                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 3) //3:da checkIn
                    {
                        ret =cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 5) //5: pending
                    {
                        ret =cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.CostPendingRoom) / 100;
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 7) //7: da checkOut nhung chua thanh toan
                    {
                        ret =cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 8) //7: da thanh toan
                    {
                        ret =cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                    }
                    sumMoneyRooms = sumMoneyRooms + ret;
                }
                return sumMoneyRooms;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMonyeRoomsBeforeTax\n" + ex.ToString());
            }

        }
        //Hiennv
        public decimal? GetTotalMoneyRoomsAfterTax()
        {
            try
            {
                decimal? sumMoneyRooms = 0;
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {

                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == null || this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == 0)
                    {
                        cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.CostRef_Rooms;
                    }
                    else
                    {
                        cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost;
                    }

                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 3) //3:da checkIn
                    {
                        decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                        decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                        ret =NotTax + Tax;
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 5) //5: pending
                    {
                        decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.CostPendingRoom) / 100;
                        decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.CostPendingRoom) / 100 * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                        ret =NotTax + Tax;
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 7) //7: da checkOut nhung chua thanh toan
                    {
                        decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                        decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                        ret =NotTax + Tax;
                    }
                    else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 8) //7: da thanh toan
                    {
                        decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                        decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                        ret =NotTax + Tax;
                    }
                    sumMoneyRooms = sumMoneyRooms + ret;
                }
                return sumMoneyRooms;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMonyeRoomsAfterTax\n" + ex.ToString());
            }

        }

        public decimal? GetMoneyRoom(int IDBookingRoom)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {

                        if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == null || this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.CostRef_Rooms;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost;
                        }

                        if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 3) //3:da checkIn
                        {
                            decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                            decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }
                        else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 5) //5: pending
                        {
                            decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.CostPendingRoom) / 100;
                            decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.CostPendingRoom) / 100 * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }
                        else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 7) //7: da checkOut nhung chua thanh toan
                        {
                            decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                            decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }
                        else if (this.aListInfoDetailPaymentEN[i].aBookingRooms.Status == 8) //7: da thanh toan
                        {
                            decimal? NotTax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse);
                            decimal? Tax = cost * Convert.ToDecimal(this.aListInfoDetailPaymentEN[i].DateInUse) * Convert.ToDecimal(aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }

                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetMonyeRoom\n" + ex.ToString());
            }

        }

        public decimal? GetMoneyRoomAndService(int IDBookingRoom)
        {
            try
            {
                decimal? ret = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        ret = ret + this.GetMoneyRoom(this.aListInfoDetailPaymentEN[i].aBookingRooms.ID);
                        ret = ret + this.GetTotalMoneyServicesRoomsAfterTax_ByIDBookingRoom(this.aListInfoDetailPaymentEN[i].aBookingRooms.ID);
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetMonyeRoomAndService\n" + ex.ToString());
            }


        }

        //Hiennv
        public decimal? GetTotalMoneyBookingRAfterTax()
        {
            try
            {
                decimal? ret = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    ret = ret + this.GetMoneyRoomAndService(this.aListInfoDetailPaymentEN[i].aBookingRooms.ID);
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMonyeBookingRAfterTax\n" + ex.ToString());
            }

        }
        //Hiennv
        public decimal? GetTotalMoneyBookingRBeforeTax()
        {
            try
            {
                decimal? moneyServices = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    moneyServices = moneyServices + this.GetTotalMoneyServicesRoomsBeforeTax_ByIDBookingRoom(this.aListInfoDetailPaymentEN[i].aBookingRooms.ID);
                }
                decimal? sum = Convert.ToDecimal(this.GetTotalMoneyRoomsBeforeTax()) + moneyServices;
                return sum;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetTotalMonyeBookingRBeforeTax\n" + ex.ToString());
            }

        }

        public List<BookingRooms> GetListBookingRoom()
        {
            try
            {
                List<BookingRooms> aListRet = new List<BookingRooms>();
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    aListRet.Add(this.aListInfoDetailPaymentEN[i].aBookingRooms);
                }
                return aListRet;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetListBookingRoom\n" + ex.ToString());
            }


        }

        public BookingRooms GetDetailBookingRoom_ByID(int IDBookingRoom)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].aBookingRooms;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetDetailBookingRoom_ByID\n" + ex.ToString());
            }

        }

        public List<Customers> GetListCustomers(int IDBookingRoom)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].aListCustomer;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetListCustomers\n" + ex.ToString());
            }

        }

        public List<ServicesEN> GetListServices(int IDBookingRoom)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].aListService;

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetListServices\n" + ex.ToString());
            }

        }
        public double? GetDateInUse(int IDBookingRoom)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].DateInUse;

                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetDateInUse\n" + ex.ToString());
            }
        }
        public void SetDateInUse(int IDBookingRoom, double? NumberDate)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        this.aListInfoDetailPaymentEN[i].DateInUse = NumberDate;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetDateInUse\n" + ex.ToString());
            }
        }
        //Hiennv
        public DateTime SetCheckOutActualBookingRooms(int IDBookingRoom, DateTime CheckOutActual)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].CheckOut = CheckOutActual;
                    }
                }
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetCheckOutActualBookingRooms\n" + ex.ToString());
            }
        }

        //Hiennv
        public DateTime GetCheckOutActualBookingRooms(int IDBookingRoom)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        return this.aListInfoDetailPaymentEN[i].CheckOut;
                    }
                }
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetCheckOutActualBookingRooms\n" + ex.ToString());
            }
        }

        //Hiennv
        public void SetCostBookingRooms(int IDBookingRoom, decimal? Cost)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        this.aListInfoDetailPaymentEN[i].aBookingRooms.Cost = Cost;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetCostBookingRooms\n" + ex.ToString());
            }
        }

        public void SetPercentTaxRoom(int IDBookingRoom, double? PercentTax)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        this.aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax = PercentTax;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetPercentTaxRoom\n" + ex.ToString());
            }
        }


        public void SetQuantityServiceInUse(int IDBookingRoomSertvice, double Quantity)
        {

            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentEN[i].aListService[ii].IDBookingRoomService == IDBookingRoomSertvice)
                        {
                            this.aListInfoDetailPaymentEN[i].aListService[ii].Quantity = Quantity;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetQuantityServiceInUse\n" + ex.ToString());
            }
        }

        public void SetServiceCost(int IDBookingRoomSertvice, decimal Cost)
        {

            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentEN[i].aListService[ii].IDBookingRoomService == IDBookingRoomSertvice)
                        {
                            this.aListInfoDetailPaymentEN[i].aListService[ii].Cost = Cost;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetServiceCost\n" + ex.ToString());
            }
        }

        public void SetPercentTaxServiceInUse(int IDBookingRoomSertvice, double PercentTaxService)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentEN[i].aListService.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentEN[i].aListService[ii].IDBookingRoomService == IDBookingRoomSertvice)
                        {
                            this.aListInfoDetailPaymentEN[i].aListService[ii].PercentTax = PercentTaxService;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetQuantityServiceInUse\n" + ex.ToString());
            }
        }

        //
        public double? GetNumberDateActualUse(int IDBookingRoom)
        {
            try
            {
                double? ret = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentEN[i].aBookingRooms.ID == IDBookingRoom)
                    {
                        ret = (100 * Convert.ToDouble(aListInfoDetailPaymentEN[i].aBookingRooms.Cost)) / ((100 + aListInfoDetailPaymentEN[i].aBookingRooms.PercentTax) * Convert.ToDouble(aListInfoDetailPaymentEN[i].aBookingRooms.CostRef_Rooms));
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetNumberDateActualUse\n" + ex.ToString());
            }
        }

        //Hiennv
        public int? GetIndexSubRooms(int IDBookingRoom)
        {
            try
            {
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    if (item1.aBookingRooms.ID == IDBookingRoom)
                    {
                        return item1.IndexSubRooms;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetIndexSubRooms\n" + ex.ToString());
            }
        }
        //Hiennv
        public int? SetIndexSubRooms(int IDBookingRoom, int IndexSubRooms)
        {
            try
            {
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    if (item1.aBookingRooms.ID == IDBookingRoom)
                    {
                        return item1.IndexSubRooms = IndexSubRooms;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetIndexSubRooms\n" + ex.ToString());
            }
        }

        //Hiennv
        public int? SetIndexSubServices(int IDBookingRoomService, int IndexSubServices)
        {
            try
            {
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    foreach (ServicesEN item2 in item1.aListService)
                    {
                        int id = item2.IDBookingRoomService;
                        if (item2.IDBookingRoomService == IDBookingRoomService)
                        {
                            return item2.IndexSubPayment = IndexSubServices;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetIndexSubServices\n" + ex.ToString());
            }
        }
        //Hiennv
        public int? GetIndexSubServices(int IDBookingRoomService)
        {
            try
            {
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    foreach (ServicesEN item2 in item1.aListService)
                    {
                        int id = item2.IDBookingRoomService;
                        if (item2.IDBookingRoomService == IDBookingRoomService)
                        {
                            return item2.IndexSubPayment;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetIndexSubServices\n" + ex.ToString());
            }
        }

        //Hiennv
        public List<RoomsEN> GetListRoomsEN()
        {
            try
            {
                List<RoomsEN> aListRooms = new List<RoomsEN>();
                RoomsEN aRoomsEN;
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    aRoomsEN = new RoomsEN();

                    aRoomsEN.IDBookingRooms = item1.aBookingRooms.ID;
                    aRoomsEN.IDBookingR = item1.aBookingRooms.IDBookingR;
                    aRoomsEN.Cost = item1.aBookingRooms.Cost == null ? item1.aBookingRooms.CostRef_Rooms : item1.aBookingRooms.Cost;
                    aRoomsEN.PercentTax = item1.aBookingRooms.PercentTax;
                    aRoomsEN.CheckInActual = item1.aBookingRooms.CheckInActual;
                    aRoomsEN.CheckOutActual = item1.aBookingRooms.CheckOutActual;
                    aRoomsEN.TimeInUse = Convert.ToDecimal(item1.DateInUse);
                    aRoomsEN.CostPendingRoom = item1.aBookingRooms.CostPendingRoom;
                    aRoomsEN.BookingRooms_Status = item1.aBookingRooms.Status;
                    aRoomsEN.Code = item1.aBookingRooms.CodeRoom;
                    aRoomsEN.Sku = item1.Sku;
                    aRoomsEN.IndexSubPayment = this.GetIndexSubRooms(item1.aBookingRooms.ID);


                    aListRooms.Add(aRoomsEN);
                }

                return aListRooms;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetListRoomsEN\n" + ex.ToString());
            }
        }

        //Hiennv
        public List<ServicesEN> GetListServicesEN()
        {
            try
            {
                List<ServicesEN> aListServices = new List<ServicesEN>();
                ServicesEN aServicesEN;
                foreach (InfoDetailPaymentEN item1 in this.aListInfoDetailPaymentEN)
                {
                    foreach (ServicesEN item2 in item1.aListService)
                    {
                        aServicesEN = new ServicesEN();
                        aServicesEN.IDBookingRoomService = item2.IDBookingRoomService;
                        aServicesEN.CodeRoom = item2.CodeRoom;
                        aServicesEN.Sku = item2.Sku;
                        aServicesEN.Name = item2.Name;
                        aServicesEN.Date = item2.Date;
                        aServicesEN.Quantity = item2.Quantity;
                        aServicesEN.Cost = item2.Cost;
                        aServicesEN.PercentTax = item2.PercentTax;
                        aServicesEN.IndexSubPayment = this.GetIndexSubServices(item2.IDBookingRoomService);

                        aListServices.Add(aServicesEN);
                    }
                }

                return aListServices;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetListServicesEN\n" + ex.ToString());
            }
        }

        //Hiennv
        public decimal? SetBookingMoney(decimal? bookingMoney)
        {
            try
            {
                return this.BookingMoney = bookingMoney;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetBookingMoney\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? GetBookingMoney()
        {
            try
            {
                return this.BookingMoney;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetBookingMoney\n" + ex.ToString());
            }
        }



        //Hiennv
        public decimal? GetSubBookingMoney(int IndexSub)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillR)
                {
                    if (aIndexSubSplitBillEN.IndexSub == IndexSub)
                    {
                        return aIndexSubSplitBillEN.SubBookingMoney;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetSubBookingMoney\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? SetSubBookingMoney(int IndexSub, decimal? SubBookingMoney)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillR)
                {
                    if (aIndexSubSplitBillEN.IndexSub == IndexSub)
                    {
                        return aIndexSubSplitBillEN.SubBookingMoney = SubBookingMoney;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetSubBookingMoney\n" + ex.ToString());
            }
        }


        //Hiennv
        public decimal? GetSubStatus(int IndexSub)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillR)
                {
                    if (aIndexSubSplitBillEN.IndexSub == IndexSub)
                    {
                        return aIndexSubSplitBillEN.SubStatus;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetSubStatus\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? SetSubStatus(int IndexSub, int? SubStatus)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillR)
                {
                    if (aIndexSubSplitBillEN.IndexSub == IndexSub)
                    {
                        return aIndexSubSplitBillEN.SubStatus = SubStatus;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:SetSubStatus\n" + ex.ToString());
            }
        }


        //Hiennv
        public decimal? GetCostBookingRooms(int IDBookingRoom)
        {
            try
            {
                foreach (InfoDetailPaymentEN aInfoDetailPaymentEN in this.aListInfoDetailPaymentEN)
                {
                    if (aInfoDetailPaymentEN.aBookingRooms.ID == IDBookingRoom)
                    {
                        decimal? Cost = aInfoDetailPaymentEN.aBookingRooms.Cost == null ? aInfoDetailPaymentEN.aBookingRooms.CostRef_Rooms : aInfoDetailPaymentEN.aBookingRooms.Cost;
                        return Cost;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetCostBookingRooms\n" + ex.ToString());
            }
        }
        //Linhting
        public decimal? GetCostRefBookingRooms(int IDBookingRoom)
        {
            try
            {
                foreach (InfoDetailPaymentEN aInfoDetailPaymentEN in this.aListInfoDetailPaymentEN)
                {
                    if (aInfoDetailPaymentEN.aBookingRooms.ID == IDBookingRoom)
                    {
                        decimal? CostRef = aInfoDetailPaymentEN.aBookingRooms.CostRef_Rooms == null ? 0 : aInfoDetailPaymentEN.aBookingRooms.CostRef_Rooms;
                        return CostRef;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentEN:GetCostRefBookingRooms\n" + ex.ToString());
            }
        }
    }

    //========================================================================================================
    //========================================================================================================
    // NGOC CODE LAI - TAM THOI DONG LAI - KHONG XOA
    //========================================================================================================
    //========================================================================================================
    //public class ItemBookingServicesInUse
    //{

    //    public int BookingRooms_Services_ID { get; set; }
    //    public int IDBookingRoomService { get; set; }
    //    public int Type { get; set; }
    //    public int IDService { get; set; }
    //    public string Name { get; set; }
    //    public DateTime? Date { get; set; }
    //    public double? Quantity { get; set; }
    //    public decimal? Cost { get; set; }
    //    public decimal? CostRef_Service { get; set; }
    //    public double? PercentTax { get; set; }
    //    public Nullable<int> IndexSubPayment { get; set; }
        
    //    //public string Sku { get; set; }

    //    public decimal? TotalServicesCostWithTax
    //    {

    //        get
    //        {
    //            double? Quantity;
    //            if (this.Quantity == null)
    //            {
    //                Quantity = 0;
    //            }
    //            else
    //            {
    //                Quantity = this.Quantity;
    //            }
    //            double? PercentTax;
    //            if (this.PercentTax == null)
    //            {
    //                PercentTax = 0;
    //            }
    //            else
    //            {
    //                PercentTax = this.PercentTax;
    //            }
    //            decimal? ServiceCost;
    //            if (this.Cost == null)
    //            {
    //                ServiceCost = this.CostRef_Service;
    //            }
    //            else
    //            {
    //                ServiceCost = this.Cost;
    //            }

    //            decimal? NotTax = ServiceCost * Convert.ToDecimal(Quantity);
    //            decimal? Tax = NotTax * Convert.ToDecimal(PercentTax) / 100;
    //            decimal? Sum = NotTax + Tax;
    //            return Sum;

    //        }
    //    }

    //    public decimal? TotalServicesNotTax
    //    {
    //        get
    //        {
    //            double? Quantity;
    //            if (this.Quantity == null)
    //            {
    //                Quantity = 0;
    //            }
    //            else
    //            {
    //                Quantity = this.Quantity;
    //            }
    //            double? PercentTax;
    //            if (this.PercentTax == null)
    //            {
    //                PercentTax = 0;
    //            }
    //            else
    //            {
    //                PercentTax = this.PercentTax;
    //            }
    //            decimal? ServiceCost;
    //            if (this.Cost == null)
    //            {
    //                ServiceCost = this.CostRef_Service;
    //            }
    //            else
    //            {
    //                ServiceCost = this.Cost;
    //            }

    //            decimal? Sum = ServiceCost * Convert.ToDecimal(Quantity);
    //            return Sum;
    //        }
    //    }

    //}

    //public class ItemBookingRoomsInUse : BookingRoomsEN
    //{
    //    public List<ItemBookingServicesInUse> aList_ItemBookingServicesInUse = new List<ItemBookingServicesInUse>();

    //    public int IDBookingRooms { get; set; }

    //    private int IDBookingR { get; set; }
        
    //    public decimal? TotalMoney { get; set; }

    //    public string TypeDisplay { get; set; }

    //    public Nullable<decimal> Cost { get; set; }

    //    public Nullable<double> PercentTax { get; set; }

    //    public System.DateTime CheckInActual { get; set; }

    //    public System.DateTime CheckOutActual { get; set; }

    //    public Nullable<double> CostPendingRoom { get; set; }

    //    public Nullable<decimal> TimeInUse { get; set; }

    //    public Nullable<int> IndexSubPayment { get; set; }

    //    public Nullable<int> BookingRooms_Status { get; set; }

    //    public decimal? TotalRoomsCostWithTax
    //    {
    //        get
    //        {
    //            decimal? ret = 0;
    //            decimal? cost = 0;

    //            if (this.Cost == null)
    //            {
    //                cost = this.CostRef_Rooms;
    //            }
    //            else
    //            {
    //                cost = this.Cost;
    //            }

    //            if (this.BookingRooms_Status == 3) //3:da checkIn
    //            {
    //                decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
    //                decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
    //                ret = ret + NotTax + Tax;
    //            }
    //            else if (this.BookingRooms_Status == 5) //5: pending
    //            {
    //                decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.CostPendingRoom) / 100;
    //                decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.CostPendingRoom) / 100 * Convert.ToDecimal(this.PercentTax) / 100;
    //                ret = ret + NotTax + Tax;
    //            }
    //            else if (this.BookingRooms_Status == 7) //7: da checkOut nhung chua thanh toan
    //            {
    //                decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
    //                decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
    //                ret = ret + NotTax + Tax;
    //            }
    //            else if (this.BookingRooms_Status == 8) //7: da thanh toan
    //            {
    //                decimal? NotTax = cost * Convert.ToDecimal(this.TimeInUse);
    //                decimal? Tax = cost * Convert.ToDecimal(this.TimeInUse) * Convert.ToDecimal(this.PercentTax) / 100;
    //                ret = ret + NotTax + Tax;
    //            }


    //            return ret;

    //        }
    //    }
    //    public string Note
    //    {
    //        get
    //        {
    //            if (this.BookingRooms_Status == 3) //3:da checkIn
    //            {
    //                return "Đang checkIn";
    //            }
    //            else if (this.BookingRooms_Status == 5) //5: pending
    //            {
    //                return "Giữ phòng";
    //            }
    //            else if (this.BookingRooms_Status == 7) //7: da checkOut nhung chua thanh toan
    //            {
    //                return "Chưa thanh toán";
    //            }
    //            else if (this.BookingRooms_Status == 8) //7: da thanh toan
    //            {
    //                return "Đã thanh toán";
    //            }
    //            else
    //            {
    //                return "Không xác định";
    //            }

    //        }
    //    }

    //    public decimal? TotalServicesCostWithTax
    //    {
    //        get
    //        {
    //            decimal? Cost = 0;
    //            for (int i = 0; i < this.aList_ItemBookingServicesInUse.Count(); i++)
    //            {
    //                Cost = Cost + this.aList_ItemBookingServicesInUse[i].TotalServicesCost;
    //            }
    //            return Cost;
    //        }

    //    }
    //    public decimal? TotalServicesCostNotTax
    //    {
    //        get
    //        {
    //            decimal? Cost = 0;
    //            for (int i = 0; i < this.aList_ItemBookingServicesInUse.Count(); i++)
    //            {
    //                Cost = Cost + this.aList_ItemBookingServicesInUse[i].TotalServicesNotTax;
    //            }
    //            return Cost;
    //        }

    //    }
    //    public decimal? TotalRoomsCostNotTax
    //    {
    //        get
    //        {
    //            decimal? Cost = 0;
    //            for (int i = 0; i < this.aList_ItemBookingServicesInUse.Count(); i++)
    //            {
    //                Cost = Cost + this.aList_ItemBookingServicesInUse[i].TotalServicesNotTax;
    //            }
    //            return Cost;
    //        }

    //    }

    //    public int Get_IDBookingR()
    //    {
    //        return this.IDBookingR;
    //    }

    //}
    //public class ItemBookingHallsInUse : BookingHallsEN
    //{
    //    public List<ItemBookingServicesInUse> aList_ItemBookingServicesInUse = new List<ItemBookingServicesInUse>();

    //    public int IDBookingHalls { get; set; }

    //    private int IDBookingH { get; set; }
        
    //    private int IDBookingR { get; set; }

    //    public decimal? TotalMoney { get; set; }

    //    public string TypeDisplay { get; set; }

    //    public Nullable<decimal> Cost { get; set; }

    //    public Nullable<double> PercentTax { get; set; }


    //    public Nullable<int> IndexSubPayment { get; set; }

    //    public Nullable<int> BookingHalls_Status { get; set; }

    //    public decimal? TotalHallsCostWithTax
    //    {
    //        get
    //        {
    //            decimal? ret = 0;
    //            decimal? cost = 0;

    //            if (this.Cost == null)
    //            {
    //                cost = this.CostRef_Halls;
    //            }
    //            else
    //            {
    //                cost = this.Cost;
    //            }


    //            decimal? NotTax = cost ;
    //            decimal? Tax = cost * Convert.ToDecimal(this.PercentTax) / 100;
    //            ret = ret + NotTax + Tax;
    //            return ret;

    //        }
    //    }

    //    public decimal? TotalHallsCostNotTax
    //    {
    //        get
    //        {
    //            decimal? cost = 0;

    //            if (this.Cost == null)
    //            {
    //                cost = this.CostRef_Halls;
    //            }
    //            else
    //            {
    //                cost = this.Cost;
    //            }
    //            return cost;

    //        }
    //    }

    //    public decimal? TotalServicesCostWithTax
    //    {
    //        get
    //        {
    //            decimal? Cost = 0;
    //            for (int i = 0; i < this.aList_ItemBookingServicesInUse.Count(); i++)
    //            {
    //                Cost = Cost + this.aList_ItemBookingServicesInUse[i].TotalServicesCost;
    //            }
    //            return Cost;
    //        }

    //    }

    //    public decimal? TotalServicesCostNotTax
    //    {
    //        get
    //        {
    //            decimal? Cost = 0;
    //            for (int i = 0; i < this.aList_ItemBookingServicesInUse.Count(); i++)
    //            {
    //                Cost = Cost + this.aList_ItemBookingServicesInUse[i].TotalServicesNotTax;
    //            }
    //            return Cost;
    //        }

    //    }

    //    public int Get_IDBookingR()
    //    {
    //        return this.IDBookingR;
    //    }
    //}

    //public class NewPaymentEN
    //{
    //    public int IDBookingR { get; set; }
    //    public int IDCustomer { get; set; }
    //    public string NameCustomer { get; set; }
    //    public int IDSystemUser { get; set; }
    //    public string NameSystemUser { get; set; }
    //    public int IDCustomerGroup { get; set; }
    //    public string NameCustomerGroup { get; set; }
    //    public int IDCompany { get; set; }
    //    public string NameCompany { get; set; }
    //    public string TaxNumberCodeCompany { get; set; }
    //    public string AddressCompany { get; set; }

    //    public Nullable<System.DateTime> CreatedDate_BookingR { get; set; }
    //    public Nullable<int> CustomerType { get; set; }
    //    public Nullable<int> BookingType { get; set; }
    //    public Nullable<int> PayMenthod { get; set; }
    //    public Nullable<int> StatusPay { get; set; }
    //    public Nullable<decimal> BookingMoney { get; set; }
    //    public Nullable<decimal> ExchangeRate { get; set; }
    //    public Nullable<int> Status_BookingR { get; set; }

    //    public int Level { get; set; }

    //    public List<ItemBookingRoomsInUse> aList_ItemBookingRoomsInUse = new List<ItemBookingRoomsInUse>();
    //    public List<ItemBookingHallsInUse> aList_ItemBookingHallsInUse = new List<ItemBookingHallsInUse>();

    //    public decimal? GetAll_BookingHalls_CostWithTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0 ; i < this.aList_ItemBookingHallsInUse.Count ; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingHallsInUse[i].TotalHallsCostWithTax;
    //        }
    //        return cost;
    //    }
    //    public decimal? GetAll_BookingHalls_CostNotTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingHallsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingHallsInUse[i].TotalHallsCostNotTax;
    //        }
    //        return cost;
    //    }
        
    //    public decimal? GetAll_BookingRooms_CostWithTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingRoomsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingRoomsInUse[i].TotalRoomsCostWithTax;
    //        }
    //        return cost;
    //    }
    //    public decimal? GetAll_BookingRooms_CostNotTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingRoomsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingRoomsInUse[i].TotalRoomsCostNotTax;
    //        }
    //        return cost;
    //    }

    //    public decimal? GetAll_BookingServicesR_CostNotTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingRoomsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingRoomsInUse[i].TotalServicesCostNotTax;
    //        }
    //        return cost;
    //    }
    //    public decimal? GetAll_BookingServicesH_CostNotTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingHallsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingHallsInUse[i].TotalServicesCostNotTax;
    //        }
    //        return cost;
    //    }

    //    public decimal? GetAll_BookingServicesH_CostWithTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingHallsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingHallsInUse[i].TotalServicesCostWithTax;
    //        }
    //        return cost;
    //    }
    //    public decimal? GetAll_BookingServicesR_CostWithTax()
    //    {
    //        decimal? cost = 0;
    //        for (int i = 0; i < this.aList_ItemBookingRoomsInUse.Count; i++)
    //        {
    //            cost = cost + this.aList_ItemBookingRoomsInUse[i].TotalServicesCostWithTax;
    //        }
    //        return cost;
    //    }

    //    public ItemBookingRoomsInUse Get_ItemBookingRoomsInUse(int IDBookingRoom)
    //    {
    //        List<ItemBookingRoomsInUse> aList = this.aList_ItemBookingRoomsInUse.Where(p => p.IDBookingRooms == IDBookingRoom).ToList();
    //        if (aList.Count > 0)
    //        {
    //            return aList[0];
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //}

    //========================================================================================================
    //========================================================================================================
    //========================================================================================================
    //========================================================================================================

}



