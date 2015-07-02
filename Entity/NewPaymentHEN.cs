using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Migrations;

namespace Entity
{
    public class NewPaymentHEN
    {
        public int? IDBookingH { get; set; }
        public List<BookingHallUsedEN> aListBookingHallUsed = new List<BookingHallUsedEN>();
        public Nullable<DateTime> CreatedDate_BookingH { get; set; }
        public int? PayMenthodH { get; set; }
        public int? CustomerType { get; set; }
        public int? StatusPay { get; set; }
        public decimal? BookingHMoney { get; set; }
        public int? Status_BookingH { get; set; }
        public int? IDCustomer { get; set; }
        public string NameCustomer { get; set; }
        public int? IDSystemUser { get; set; }
        public string NameSystemUser { get; set; }
        public int? IDCustomerGroup { get; set; }
        public string NameCustomerGroup { get; set; }
        public int? IDCompany { get; set; }
        public string NameCompany { get; set; }
        public string TaxNumberCodeCompany { get; set; }
        public string AddressCompany { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string Subject { get; set; }

        public List<int> ListIndex = new List<int>();
        public Nullable<DateTime> InvoiceDate { get; set; } // ngay tren hoa don do, ngay chot doanh thu
        public decimal? GetMoneyHalls()
        {
            decimal? MoneyHalls = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                MoneyHalls = MoneyHalls + item.GetTotalMoneyHall();
            }
            return MoneyHalls;
        }      


        //Hiennv  03/11/2014
        public decimal? GetMoneyTax(decimal? TotalMoney, decimal? PercentTax)
        {
            return (TotalMoney * PercentTax) / 100;
        }


        public decimal? GetMoneyHallsBeforeTax()
        {
            decimal? MoneyHallsBeforeTax = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                MoneyHallsBeforeTax = MoneyHallsBeforeTax + item.GetMoneyHallBeforeTax();
            }
            return MoneyHallsBeforeTax;
        }
        public decimal? GetOnlyMoneyHalls()
        {
            decimal? MoneyHalls = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                MoneyHalls = MoneyHalls + item.GetOnlyMoneyHall();
            }
            return MoneyHalls;
        }
        public decimal? GetOnlyMoneyHallsBeforeTax()
        {
            decimal? MoneyHalls = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                MoneyHalls = MoneyHalls + item.GetOnlyMoneyHallBeforeTax();
            }
            return MoneyHalls;
        }
        public decimal? GetTotalMoney()
        {
            if (this.GetMoneyHalls() != 0)
            {
                decimal? TotalMoney = this.GetMoneyHalls() + this.GetMoneyHalls();
                return TotalMoney;
            }
            else
            {
                return this.GetMoneyHalls();
            }
        }
        public decimal? GetTotalMoneyBeforeTax()
        {
            if (this.GetMoneyHallsBeforeTax() != 0)
            {
                decimal? TotalMoneyBeforeTax = this.GetMoneyHallsBeforeTax() + this.GetMoneyHallsBeforeTax();
                return TotalMoneyBeforeTax;
            }
            else
            {
                return this.GetMoneyHallsBeforeTax();
            }
        }
        public decimal? GetMoneyAHall(int IDBookingHall)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                return this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].GetOnlyMoneyHall();
            }
            return 0;
        }

        public void PaymentHall()
        {
            DatabaseDA aDatabaseDA = new DatabaseDA();
            if (aDatabaseDA.BookingHs.Where(a => a.ID == IDBookingH).ToList().Count > 0)
            {
                BookingHs aTemp = aDatabaseDA.BookingHs.Where(a => a.ID == IDBookingH).ToList()[0];
                aTemp.CreatedDate = this.CreatedDate_BookingH;
                aTemp.Status = 8;
                aTemp.BookingMoney = this.BookingHMoney;
                aTemp.InvoiceDate = this.InvoiceDate;
                aTemp.InvoiceNumber = this.InvoiceNumber;
                aTemp.DatePay = DateTime.Now;
                aDatabaseDA.BookingHs.AddOrUpdate(aTemp);
                aDatabaseDA.SaveChanges();
                foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
                {

                    foreach (ServiceUsedEN item1 in item.aListServiceUsed)
                    {
                        item1.StatusPay = 8;
                    }
                    item.Status = 8;
                    item.Save();
                }
            }

        }
        public void ChangeCostHall(int IDBookingHall, decimal Cost)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].Cost = Cost;
            }
        }
        public void ChangePercentTaxHall(int IDBookingHall, double Tax)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].PercentTax = Tax;
            }
        }
        public void ChangeTaxServiceInHall(int IDBookingHall, int IDBookingHallService, double Tax)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].ChangeTaxService(IDBookingHallService, Tax);
            }
        }
        public void ChangeCostServiceUsedInHall(int IDBookingHall, int IDBookingHallService, decimal Cost)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].SetCostServiceUsed(IDBookingHallService, Cost);
            }
        }
        public void ChangeQuantityServiceUsedInHall(int IDBookingHall, int IDBookingHallService, double Quantity)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].SetQuantityServiceUsed(IDBookingHallService, Quantity);

            }
        }
        public List<ServiceUsedEN> GetListServiceUsedPaidInHall(int IDBookingHall)
        {
            BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
            return aTemp.aListServiceUsed.Where(a => a.IsPaidService() == true).ToList();
        }
        public List<ServiceUsedEN> GetListServiceUsedUnPaidInHall(int IDBookingHall)
        {
            BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
            return aTemp.aListServiceUsed.Where(a => a.IsPaidService() == false).ToList();
        }
        public decimal? GetTotalMoneyServiceUsedInHalls()
        {
            decimal? TotalMoneyService = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsed();
            }
            return TotalMoneyService;
        }
        public decimal? GetTotalMoneyServiceUsedInHallsBeforeTax()
        {
            decimal? TotalMoneyService = 0;
            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                TotalMoneyService = TotalMoneyService + item.GetMoneyListServiceUsedBeforeTax();
            }
            return TotalMoneyService;
        }
        public decimal? GetMoneyListServiceUsedInAHall(int IDBookingHall)
        {
            BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
            return aTemp.GetMoneyListServiceUsed();
        }
        public decimal? GetMoneyListServiceUsedInAHallBeforeTax(int IDBookingHall)
        {
            BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
            return aTemp.GetMoneyListServiceUsedBeforeTax();
        }
        public List<ServiceUsedEN> GetListServiceUsedInHall(int IDBookingHall)
        {
            BookingHallUsedEN aTemp = this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0];
            return aTemp.aListServiceUsed;
        }

        public List<ServiceUsedEN> GetAllServiceUsedInHall()
        {
            List<ServiceUsedEN> aListServiceUsed = new List<ServiceUsedEN>();

            foreach (BookingHallUsedEN item in this.aListBookingHallUsed)
            {
                foreach (ServiceUsedEN item1 in item.aListServiceUsed)
                {
                    aListServiceUsed.Add(item1);
                }
            }
            return aListServiceUsed;
        }
        public void ChangeIndexSubPaymentServiceHall(int IDBookingHall, int IDBookingHallService, int Index)
        {
            if (this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
            {
                this.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].ChangeIndexSubPaymentService(IDBookingHallService, Index);

            }
        }
        public void ChangeInvoiceDate(DateTime InvoiceDate)
        {
            this.InvoiceDate = InvoiceDate;
            if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.InvoiceDate = InvoiceDate;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.InvoiceDate = InvoiceDate;
                            }
                        }
                    }

                }
            }
            else if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.InvoiceDate = InvoiceDate;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.InvoiceDate = InvoiceDate;
                            }
                        }
                    }
                }
            }
        }
        public void ChangeInvoiceNumber(string InvoiNumber)
        {
            this.InvoiceNumber = InvoiNumber;
            if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.InvoiceNumber = InvoiNumber;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.InvoiceNumber = InvoiNumber;
                            }
                        }
                    }
                }
            }
            else if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.InvoiceNumber = InvoiNumber;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.InvoiceDate = InvoiceDate;
                            }
                        }
                    }
                }
            }
        }
        public void ChangeAcceptDate(DateTime AcceptDate)
        {
            this.AcceptDate = AcceptDate;
            if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.AcceptDate = AcceptDate;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.AcceptDate = AcceptDate;
                            }
                        }
                    }

                }
            }
            else if (this.aListBookingHallUsed.Count > 0)
            {
                foreach (BookingHallUsedEN aBookingHall in this.aListBookingHallUsed)
                {
                    if (aBookingHall.IndexSubPayment == null)
                    {
                        aBookingHall.AcceptDate = AcceptDate;
                    }
                    if (aBookingHall.aListServiceUsed.Count > 0)
                    {
                        foreach (ServiceUsedEN aTemp in aBookingHall.aListServiceUsed)
                        {
                            if (aTemp.IndexSubPayment == null)
                            {
                                aTemp.AcceptDate = AcceptDate;
                            }
                        }
                    }
                }
            }
        }

    }
}
