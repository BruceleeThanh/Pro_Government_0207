using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using Entity;
using BussinessLogic;
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmTsk_SplitBillHalls_Step2 : DevExpress.XtraEditors.XtraForm
    {

        private frmTsk_SplitBillHalls_Step1 afrmTsk_SplitBillHalls_Step1 = null;
        private PaymentHallsEN aPaymentHallsEN = new PaymentHallsEN();
        private List<ServicesHallsEN> aListServices = new List<ServicesHallsEN>();
        private List<HallsEN> aListHalls = new List<HallsEN>();

        public frmTsk_SplitBillHalls_Step2(frmTsk_SplitBillHalls_Step1 afrmTsk_SplitBillHalls_Step1, PaymentHallsEN aPaymentHallsEN)
        {
            InitializeComponent();
            this.afrmTsk_SplitBillHalls_Step1 = afrmTsk_SplitBillHalls_Step1;
            this.aPaymentHallsEN = aPaymentHallsEN;
        }


        private void frmTsk_SplitBillHalls_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.aPaymentHallsEN.Status_BookingH == 8)
                {
                    btnPayment.Enabled = false;
                }
                lueIndexSub.Properties.DataSource = this.aPaymentHallsEN.aListIndexSubSplitBillH.Select(i => i.IndexSub).Distinct();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2_Load.frmTsk_SplitBillHalls_Step2_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        public void LoadListHall_ByIndexSubHall(PaymentHallsEN aPaymentHallsEN, int IndexSubHall)
        {
            try
            {
                this.aListHalls.Clear();
                this.aListHalls = aPaymentHallsEN.GetListHallsEN().Where(r => r.IndexSubHalls == IndexSubHall).OrderBy(r => r.Sku).ToList();
                dgvHalls.DataSource = this.aListHalls;
                dgvHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2.LoadListHall_ByIndexSubHall\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        public void LoadListServices_ByIndexSubServices(PaymentHallsEN aPaymentHallsEN, int IndexSubServices)
        {
            try
            {
                this.aListServices.Clear();
                this.aListServices = aPaymentHallsEN.GetListServicesHallsEN().Where(r => r.IndexSubServices == IndexSubServices).OrderBy(r => r.SkuHall).ToList();
                dgvServices.DataSource = this.aListServices;
                dgvServices.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2.LoadListServices_ByIndexSubServices\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void lueIndexSub_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int indexSub = Convert.ToInt32(lueIndexSub.Text);
                this.LoadListHall_ByIndexSubHall(this.aPaymentHallsEN, indexSub);
                this.LoadListServices_ByIndexSubServices(this.aPaymentHallsEN, indexSub);


                List<IndexSubSplitBillEN> aListIndexSubSplitBillEN = this.aPaymentHallsEN.aListIndexSubSplitBillH.Where(sub => sub.IndexSub == indexSub && sub.SubStatus > 0).ToList();
                if (aListIndexSubSplitBillEN.Count < 1)
                {
                    decimal? totalBill = this.aListServices.Sum(s => s.Total) + this.aListServices.Sum(r => r.Total);

                    decimal? totalBookingMoney = this.aPaymentHallsEN.GetBookingMoney();

                    if ((totalBill - totalBookingMoney) == 0)
                    {
                        this.aPaymentHallsEN.SetSubBookingMoney(indexSub, totalBookingMoney);
                        this.aPaymentHallsEN.SetSubStatus(indexSub, indexSub); //SubStatus dung de phan biet so tien ung truoc cho tung subBookingmoney

                        this.aPaymentHallsEN.SetBookingMoney(0); // set lai so tien ung truoc bang 0;
                    }
                    else if ((totalBill - totalBookingMoney) > 0)
                    {
                        this.aPaymentHallsEN.SetSubBookingMoney(indexSub, totalBookingMoney);
                        this.aPaymentHallsEN.SetSubStatus(indexSub, indexSub);//SubStatus dung de phan biet so tien ung truoc cho tung subBookingmoney

                        this.aPaymentHallsEN.SetBookingMoney(0); // set lai so tien ung truoc bang 0;
                    }
                    else if ((totalBill - totalBookingMoney) < 0)
                    {
                        BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                        List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookingH_ByStatus(this.aPaymentHallsEN.IDBookingH, 8);
                        if (aListBookingHalls.Count < 2)
                        {
                            this.aPaymentHallsEN.SetSubBookingMoney(indexSub, totalBookingMoney);
                            this.aPaymentHallsEN.SetSubStatus(indexSub, indexSub);//SubStatus dung de phan biet so tien ung truoc cho tung subBookingmoney

                            this.aPaymentHallsEN.SetBookingMoney(0); // set lai so tien ung truoc bang 0;
                        }
                        else
                        {
                            this.aPaymentHallsEN.SetSubBookingMoney(indexSub, totalBill);
                            this.aPaymentHallsEN.SetSubStatus(indexSub, indexSub);//SubStatus dung de phan biet so tien ung truoc cho tung subBookingmoney

                            this.aPaymentHallsEN.SetBookingMoney((totalBookingMoney - totalBill));
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2_Load.lueIndexSub_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnPrintSplitBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lueIndexSub.Text) == true)
                {
                    lueIndexSub.Focus();
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán cần in !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int indexSub = Convert.ToInt32(lueIndexSub.Text);
                    frmRpt_SplitPayment_BookingHs afrmRpt_SplitPayment_BookingHs = new frmRpt_SplitPayment_BookingHs(this.aPaymentHallsEN,indexSub);
                    ReportPrintTool tool = new ReportPrintTool(afrmRpt_SplitPayment_BookingHs);
                    tool.ShowPreview();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2_Load.btnPrintSplitBill_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lueIndexSub.Text) == true)
                {
                    lueIndexSub.Focus();
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                    foreach (ServicesHallsEN aServicesHallsEN in this.aListServices)
                    {
                        BookingHalls_Services aBookingHalls_Services = aBookingHalls_ServicesBO.Select_ByID(aServicesHallsEN.IDBookingHallService);
                        if (aBookingHalls_Services != null && aBookingHalls_Services.Status != 8)
                        {
                            aBookingHalls_Services.ID = aServicesHallsEN.IDBookingHallService;
                            aBookingHalls_Services.Quantity = aServicesHallsEN.Quantity;
                            aBookingHalls_Services.PercentTax = aServicesHallsEN.PercentTax;
                            aBookingHalls_Services.Cost = aServicesHallsEN.Cost;
                            aBookingHalls_Services.Status = 8;// da thanh toan
                            aBookingHalls_ServicesBO.Update(aBookingHalls_Services);
                        }
                    }

                    BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                    foreach (HallsEN aHallsEN in this.aListHalls)
                    {
                        BookingHalls aBookingHalls = aBookingHallsBO.Select_ByID(aHallsEN.IDBookingHall);
                        if (aBookingHalls != null && aBookingHalls.Status != 8)
                        {
                            aBookingHalls.ID = aHallsEN.IDBookingHall;
                            aBookingHalls.PercentTax = aHallsEN.PercentTax;
                            aBookingHalls.Cost = aHallsEN.Cost;
                            aBookingHalls.Status = 8;//da thanh toan
                            aBookingHallsBO.Update(aBookingHalls);
                        }
                    }
                    BookingHsBO aBookingHsBO = new BookingHsBO();
                    BookingHs aBookingHs = aBookingHsBO.Select_ByID(this.aPaymentHallsEN.IDBookingH);
                    List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookingH_ByStatus(this.aPaymentHallsEN.IDBookingH,8);
                    if (aListBookingHalls.Count < 1)
                    {
                        aBookingHs.ID = aPaymentHallsEN.IDBookingH;
                        aBookingHs.PayMenthod = this.aPaymentHallsEN.PayMenthod;
                        aBookingHs.StatusPay = 3;
                        aBookingHs.Status = 8;
                        btnPayment.Enabled = false;
                    }
                    aBookingHs.BookingMoney = this.aPaymentHallsEN.GetBookingMoney();
                    aBookingHsBO.Update(aBookingHs);


                    MessageBox.Show("Thanh toán thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBillHalls_Step2_Load.btnPayment_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}