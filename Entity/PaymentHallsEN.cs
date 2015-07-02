using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    //hiennv
    public class PaymentHallsEN
    {
        public int IDBookingH = 0;
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

        public Nullable<System.DateTime> CreatedDate_BookingH { get; set; }
        public Nullable<int> CustomerType { get; set; }
        public Nullable<int> BookingType { get; set; }
        public Nullable<int> PayMenthod { get; set; }
        public Nullable<int> StatusPay { get; set; }
        public Nullable<decimal> BookingMoney { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> Status_BookingH { get; set; }
        public Nullable<int> Level { get; set; }



        public List<InfoDetailPaymentHallsEN> aListInfoDetailPaymentHallsEN = new List<InfoDetailPaymentHallsEN>();
        public List<IndexSubSplitBillEN> aListIndexSubSplitBillH = new List<IndexSubSplitBillEN>();

        //hiennv
        public decimal? GetTotalMoneyServiceHallBeforeTax()
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    ServicesHallsEN aServicesHallsEN;
                    for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                    {
                        aServicesHallsEN = new ServicesHallsEN();
                        aServicesHallsEN = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii];

                        if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == null || this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].CostRef_Services;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost;
                        }

                        ret = ret + cost * Convert.ToDecimal(aServicesHallsEN.Quantity);
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyServiceHallBeforeTax\n" + ex.ToString());
            }


        }
        //hiennv
        public decimal? GetTotalMoneyServiceHallAfterTax()
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    ServicesHallsEN aServicesHallsEN;
                    for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                    {
                        aServicesHallsEN = new ServicesHallsEN();
                        aServicesHallsEN = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii];

                        if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == null || this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].CostRef_Services;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost;
                        }

                        decimal? NotTax = cost * Convert.ToDecimal(aServicesHallsEN.Quantity);
                        decimal? Tax = NotTax * Convert.ToDecimal(aServicesHallsEN.PercentTax) / 100;
                        ret = ret + NotTax + Tax;
                    }



                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyServiceHallAfterTax\n" + ex.ToString());
            }


        }

        //hiennv
        public decimal? GetTotalMoneyServiceHallBeforeTax_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        ServicesHallsEN aServicesHallsEN;
                        for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                        {
                            aServicesHallsEN = new ServicesHallsEN();
                            aServicesHallsEN = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii];

                            if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == null || this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == 0)
                            {
                                cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].CostRef_Services;
                            }
                            else
                            {
                                cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost;
                            }

                            ret = ret + cost * Convert.ToDecimal(aServicesHallsEN.Quantity);
                        }

                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyServiceHallBeforeTax_ByIDBookingHall\n" + ex.ToString());
            }


        }
        //hiennv
        public decimal? GetTotalMoneyServiceHallAfterTax_ByIDBookingHall(int IDBookingHall)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        ServicesHallsEN aServicesHallsEN;
                        for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                        {
                            aServicesHallsEN = new ServicesHallsEN();
                            aServicesHallsEN = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii];

                            if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == null || this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost == 0)
                            {
                                cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].CostRef_Services;
                            }
                            else
                            {
                                cost = this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost;
                            }

                            decimal? NotTax = cost * Convert.ToDecimal(aServicesHallsEN.Quantity);
                            decimal? Tax = NotTax * Convert.ToDecimal(aServicesHallsEN.PercentTax) / 100;
                            ret = ret + NotTax + Tax;
                        }

                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyServiceHallAfterTax_ByIDBookingHall\n" + ex.ToString());
            }


        }
        //hiennv
        public decimal? GetTotalMoneyHallBeforeTax()
        {
            try
            {
                decimal? SumHall = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == null || this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == 0)
                    {
                        cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.CostRef_Halls;
                    }
                    else
                    {
                        cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost;
                    }
                    SumHall = SumHall + cost;
                }
                return SumHall;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyHallBeforeTax\n" + ex.ToString());
            }

        }
        //hiennv
        public decimal? GetTotalMoneyHallAfterTax()
        {
            try
            {
                decimal? sumHall = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == null || this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == 0)
                    {
                        cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.CostRef_Halls;
                    }
                    else
                    {
                        cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost;
                    }
                    sumHall = sumHall + (cost + (cost * Convert.ToDecimal(aListInfoDetailPaymentHallsEN[i].aBookingHalls.PercentTax) / 100));
                }
                return sumHall;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMoneyHallAfterTax\n" + ex.ToString());
            }

        }

        //hiennv
        public decimal? GetMoneyHall(int IDBookingHall)
        {
            try
            {
                decimal? ret = 0;
                decimal? cost = 0;
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {

                        if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == null || this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost == 0)
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.CostRef_Halls;
                        }
                        else
                        {
                            cost = this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost;
                        }

                        ret = ret + (cost + (cost * Convert.ToDecimal(aListInfoDetailPaymentHallsEN[i].aBookingHalls.PercentTax) / 100));
                        


                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetMoneyHall\n" + ex.ToString());
            }

        }
        //hiennv
        public decimal? GetMoneyHallAndService(int IDBookingHall)
        {
            try
            {
                decimal? ret = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        ret = ret + this.GetMoneyHall(this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID);
                        ret = ret + this.GetTotalMoneyServiceHallAfterTax_ByIDBookingHall(this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID);
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetMoneyHallAndService\n" + ex.ToString());
            }
        }

        //hiennv
        public decimal? GetTotalMoneyBookingHBeforeTax()
        {
            try
            {
                decimal? moneyServices = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    moneyServices = moneyServices + GetTotalMoneyServiceHallBeforeTax_ByIDBookingHall(aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID);
                }
                decimal? sum =Convert.ToDecimal(this.GetTotalMoneyHallBeforeTax()) + moneyServices;
                return sum;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMonyeBookingHBeforeTax\n" + ex.ToString());
            }

        }

        //hiennv
        public decimal? GetTotalMoneyBookingHAfterTax()
        {
            try
            {
                decimal? ret = 0;

                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    ret = ret + this.GetMoneyHallAndService(this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID);
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetTotalMonyeBookingHAfterTax\n" + ex.ToString());
            }

        }
        //hiennv
        public List<BookingHalls> GetListBookingHalls()
        {
            try
            {
                List<BookingHalls> aListRet = new List<BookingHalls>();
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    aListRet.Add(this.aListInfoDetailPaymentHallsEN[i].aBookingHalls);
                }
                return aListRet;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetListBookingHalls\n" + ex.ToString());
            }
        }
        //hiennv
        public BookingHalls GetDetailBookingHall_ByID(int IDBookingHall)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        return this.aListInfoDetailPaymentHallsEN[i].aBookingHalls;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetDetailBookingHall_ByID\n" + ex.ToString());
            }

        }
        //hiennv
        public MenusEN GetDetailMenus(int IDBookingHall)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        return this.aListInfoDetailPaymentHallsEN[i].aMenusEN;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetDetailMenus\n" + ex.ToString());
            }

        }

        //hiennv
        public List<ServicesHallsEN> GetListServicesHallsEN(int IDBookingHall)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        return this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetListServices\n" + ex.ToString());
            }
        }

        //Hiennv
        public void SetCostBookingHall(int IDBookingHall, decimal? Cost)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.Cost = Cost;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetCostBookingHall\n" + ex.ToString());
            }
        }

        //hiennv
        public void SetPercentTaxHall(int IDBookingHall, double? PercentTax)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {
                    if (this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.ID == IDBookingHall)
                    {
                        this.aListInfoDetailPaymentHallsEN[i].aBookingHalls.PercentTax = PercentTax;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetPercentTaxHall\n" + ex.ToString());
            }
        }
        //hiennv
        public void SetQuantityServiceInUse(int IDBookingHallSertvice, double Quantity)
        {

            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].IDBookingHallService == IDBookingHallSertvice)
                        {
                            this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Quantity = Quantity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetQuantityServiceInUse\n" + ex.ToString());
            }
        }
        //hiennv
        public void SetServiceCost(int IDBookingHallSertvice, decimal Cost)
        {

            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].IDBookingHallService == IDBookingHallSertvice)
                        {
                            this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].Cost = Cost;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetServiceCost\n" + ex.ToString());
            }
        }
        //hiennv
        public void SetPercentTaxServices(int IDBookingHallSertvice, double PercentTaxService)
        {
            try
            {
                for (int i = 0; i < this.aListInfoDetailPaymentHallsEN.Count; i++)
                {

                    for (int ii = 0; ii < this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN.Count; ii++)
                    {
                        if (this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].IDBookingHallService == IDBookingHallSertvice)
                        {
                            this.aListInfoDetailPaymentHallsEN[i].aListServicesHallsEN[ii].PercentTax = PercentTaxService;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetQuantityServiceInUse\n" + ex.ToString());
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
                throw new Exception("PaymentHallsEN:SetBookingMoney\n" + ex.ToString());
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
                throw new Exception("PaymentHallsEN:GetBookingMoney\n" + ex.ToString());
            }
        }

        //Hiennv
        public int? GetIndexSubHalls(int IDBookingHall)
        {
            try
            {
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    if (item1.aBookingHalls.ID == IDBookingHall)
                    {
                        return item1.IndexSubHalls;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetIndexSubRooms\n" + ex.ToString());
            }
        }
        //Hiennv
        public int? SetIndexSubHalls(int IDBookingHall, int IndexSubHalls)
        {
            try
            {
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    if (item1.aBookingHalls.ID == IDBookingHall)
                    {
                        return item1.IndexSubHalls = IndexSubHalls;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetIndexSubRooms\n" + ex.ToString());
            }
        }
        //Hiennv
        public int? SetIndexSubServices(int IDBookingHallService, int IndexSubServices)
        {
            try
            {
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    foreach (ServicesHallsEN item2 in item1.aListServicesHallsEN)
                    {
                        int id = item2.IDBookingHallService;
                        if (item2.IDBookingHallService == IDBookingHallService)
                        {
                            return item2.IndexSubServices = IndexSubServices;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:SetIndexSubServices\n" + ex.ToString());
            }
        }
        //Hiennv
        public int? GetIndexSubServices(int IDBookingHallService)
        {
            try
            {
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    foreach (ServicesHallsEN item2 in item1.aListServicesHallsEN)
                    {
                        int id = item2.IDBookingHallService;
                        if (item2.IDBookingHallService == IDBookingHallService)
                        {
                            return item2.IndexSubServices;
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetIndexSubServices\n" + ex.ToString());
            }
        }



        //Hiennv
        public List<HallsEN> GetListHallsEN()
        {
            try
            {
                List<HallsEN> aListHalls = new List<HallsEN>();
                HallsEN aHallsEN;
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    aHallsEN = new HallsEN();
                    aHallsEN.IDBookingHall = item1.aBookingHalls.ID;
                    aHallsEN.IDBookingH = item1.aBookingHalls.IDBookingH;
                    aHallsEN.Cost = item1.aBookingHalls.Cost == null ? item1.aBookingHalls.CostRef_Halls : item1.aBookingHalls.Cost;
                    aHallsEN.PercentTax = item1.aBookingHalls.PercentTax;
                    aHallsEN.Date = item1.aBookingHalls.Date;
                    aHallsEN.Status = item1.aBookingHalls.Status;
                    aHallsEN.Code = item1.aBookingHalls.CodeHall;
                    aHallsEN.Sku = item1.Sku;
                    aHallsEN.IndexSubHalls = this.GetIndexSubHalls(item1.aBookingHalls.ID);
                    aListHalls.Add(aHallsEN);
                }

                return aListHalls;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetListRoomsEN\n" + ex.ToString());
            }
        }
        //Hiennv
        public List<ServicesHallsEN> GetListServicesHallsEN()
        {
            try
            {
                List<ServicesHallsEN> aListServices = new List<ServicesHallsEN>();
                ServicesHallsEN aServicesHallsEN;
                foreach (InfoDetailPaymentHallsEN item1 in this.aListInfoDetailPaymentHallsEN)
                {
                    foreach (ServicesHallsEN item2 in item1.aListServicesHallsEN)
                    {
                        aServicesHallsEN = new ServicesHallsEN();
                        aServicesHallsEN.IDBookingHallService = item2.IDBookingHallService;
                        aServicesHallsEN.CodeHall = item2.CodeHall;
                        aServicesHallsEN.SkuHall = item2.SkuHall;
                        aServicesHallsEN.NameService = item2.NameService;
                        aServicesHallsEN.Date = item2.Date;
                        aServicesHallsEN.Quantity = item2.Quantity;
                        aServicesHallsEN.Cost = item2.Cost;
                        aServicesHallsEN.PercentTax = item2.PercentTax;

                        aServicesHallsEN.IndexSubServices = this.GetIndexSubServices(item2.IDBookingHallService);

                        aListServices.Add(aServicesHallsEN);
                    }
                }

                return aListServices;
            }
            catch (Exception ex)
            {
                throw new Exception("PaymentHallsEN:GetListServicesHallsEN\n" + ex.ToString());
            }
        }

        //Hiennv
        public decimal? GetSubBookingMoney(int IndexSub)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillH)
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
                throw new Exception("PaymentHallsEN:GetSubBookingMoney\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? SetSubBookingMoney(int IndexSub, decimal? SubBookingMoney)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillH)
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
                throw new Exception("PaymentHallsEN:SetSubBookingMoney\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? GetSubStatus(int IndexSub)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillH)
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
                throw new Exception("PaymentHallsEN:GetSubStatus\n" + ex.ToString());
            }
        }
        //Hiennv
        public decimal? SetSubStatus(int IndexSub, int? SubStatus)
        {
            try
            {
                foreach (IndexSubSplitBillEN aIndexSubSplitBillEN in this.aListIndexSubSplitBillH)
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
                throw new Exception("PaymentHallsEN:SetSubStatus\n" + ex.ToString());
            }
        }
    }
}
