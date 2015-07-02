using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Entity;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
namespace SaleManagement
{
    public partial class frmRpt_SplitPayment_BookingHs : DevExpress.XtraReports.UI.XtraReport
    {
        private PaymentHallsEN aPaymentHallsEN;

        private decimal? totalMoneyService = 0;
        private decimal? totalMoneyHall = 0;
        private decimal? totalMoneyMenu = 0;
        private int indexSub = 0;

        public frmRpt_SplitPayment_BookingHs(PaymentHallsEN aPaymentHallsEN, int indexSub)
        {
            InitializeComponent();
            this.aPaymentHallsEN = aPaymentHallsEN;
            this.indexSub = indexSub;
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                HallsBO aHallsBO = new HallsBO();
                ServicesBO aServicesBO = new ServicesBO();
                List<HallsEN> aListHallsEN = new List<HallsEN>();
                aListHallsEN=this.aPaymentHallsEN.GetListHallsEN().Where(r => r.IndexSubHalls == this.indexSub).OrderBy(r => r.Sku).ToList();
                totalMoneyHall = aListHallsEN.Sum(s => s.TotalCost);

                List<ServicesHallsEN> aListServicesHallsEN = new List<ServicesHallsEN>();
                aListServicesHallsEN=this.aPaymentHallsEN.GetListServicesHallsEN().Where(r => r.IndexSubServices == this.indexSub).OrderBy(r => r.SkuHall).ToList();
                totalMoneyService = aListServicesHallsEN.Sum(s => s.Total);

              

                lblCompany.Text = this.aPaymentHallsEN.NameCompany;
                lblGroup.Text =this.aPaymentHallsEN.NameCustomerGroup;
                lblNameCustomer.Text =this.aPaymentHallsEN.NameCustomer;
                lblIDBookingH.Text = Convert.ToString(this.aPaymentHallsEN.IDBookingH);

                //danh sach hoi truong
                this.DetailReportHall.DataSource = aListHallsEN;
                colSkuHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Sku");
                colCreateDate.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Date", "{0:dd/MM/yyyy}");
                colBookingHallCost.DataBindings.Add("Text", this.DetailReportHall.DataSource, "Cost", "{0:0,0}");
                colPercentTax.DataBindings.Add("Text", this.DetailReportHall.DataSource, "PercentTax");
                colPaymentMoneyHall.DataBindings.Add("Text", this.DetailReportHall.DataSource, "TotalMoney", "{0:0,0}");


                //danh sach dich vu su dung
                this.DetailReportService.DataSource = aListServicesHallsEN;
                colService_Sku.DataBindings.Add("Text", this.DetailReportService.DataSource, "SkuHall");
                colService_Name.DataBindings.Add("Text", this.DetailReportService.DataSource, "NameService");
                colService_Date.DataBindings.Add("Text", this.DetailReportService.DataSource, "Date", "{0:dd/MM/yyyy}");
                colService_Quantity.DataBindings.Add("Text", this.DetailReportService.DataSource, "Quantity", "{0:0,0}");
                colService_Cost.DataBindings.Add("Text", this.DetailReportService.DataSource, "Cost", "{0:0,0}");
                colService_PercentTax.DataBindings.Add("Text", this.DetailReportService.DataSource, "PercentTax");
                colService_Money.DataBindings.Add("Text", this.DetailReportService.DataSource, "Total", "{0:0,0}");

                //tong tien dich vu
                lblTotalMoneyServices.Text = String.Format("{0:0,0} (VND)",this.totalMoneyService);
                //tong tien hoi truong
                lblTotalMoneyHall.Text = String.Format("{0:0,0} (VND)",this.totalMoneyHall);
               


                //tong tien 
                lblTotalMoney.Text = String.Format("{0:0,0}",aPaymentHallsEN.GetTotalMoneyBookingHBehindTax());
                lblBookingMoney.Text = String.Format("{0:0,0}",this.aPaymentHallsEN.GetBookingMoney());
                lblMoney.Text = String.Format("{0:0,0}", (aPaymentHallsEN.GetTotalMoneyBookingHBehindTax() - this.aPaymentHallsEN.GetBookingMoney()));

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRpt_PaymentBookingHs.frmRpt_PaymentBookingHs\n" + ex.ToString());
            }

        }
    }
}

