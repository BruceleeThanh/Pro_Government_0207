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
using System.Globalization;

namespace SaleManagement
{
    public partial class frmTsk_SplitBill_Step1 : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_PaymentHall afrmTsk_PaymentHall = null;
        private PaymentHallsEN aPaymentHallsEN = new PaymentHallsEN();


        public frmTsk_SplitBill_Step1(frmTsk_PaymentHall afrmTsk_PaymentHall, PaymentHallsEN aPaymentHallsEN)
        {
            InitializeComponent();
            this.afrmTsk_PaymentHall = afrmTsk_PaymentHall;
            this.aPaymentHallsEN = aPaymentHallsEN;
        }
        //Hiennv
        private void frmTsk_SplitBill_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadListHalls();
                this.LoadListServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.frmTsk_SplitBill_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void LoadListHalls()
        {
            try
            {
                dgvHalls.DataSource = this.aPaymentHallsEN.GetListHallsEN();
                dgvHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.LoadListHalls\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void LoadListServices()
        {
            try
            {
                dgvServices.DataSource =this.aPaymentHallsEN.GetListServicesHallsEN();
                dgvServices.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.LoadListServices\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                frmTsk_SplitBill_Step2 afrmTsk_SplitBill_Step2 = new frmTsk_SplitBill_Step2(this, this.aPaymentHallsEN);
                afrmTsk_SplitBill_Step2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.btnSplit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtChooseHalls_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseHall = (TextEdit)sender;

                int IDBookingHall = Convert.ToInt32(viewHalls.GetFocusedRowCellValue("IDBookingHall"));
                this.aPaymentHallsEN.SetIndexSubHalls(IDBookingHall, Convert.ToInt32(txtChooseHall.EditValue));

                List<IndexSubSplitBillEN> aListTemp = this.aPaymentHallsEN.aListIndexSubSplitBillH.Where(r => r.ID == IDBookingHall).ToList();
                if (aListTemp.Count > 0)
                {
                    this.aPaymentHallsEN.aListIndexSubSplitBillH.Remove(aListTemp[0]);
                }
                IndexSubSplitBillEN aIndexSubSplitBillEN = new IndexSubSplitBillEN();
                aIndexSubSplitBillEN.ID = IDBookingHall;
                aIndexSubSplitBillEN.IndexSub = Convert.ToInt32(txtChooseHall.EditValue);
                aIndexSubSplitBillEN.SubBookingMoney = 0;
                aIndexSubSplitBillEN.SubStatus = 0;

                this.aPaymentHallsEN.aListIndexSubSplitBillH.Add(aIndexSubSplitBillEN);

                this.LoadListHalls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtChooseHalls_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void txtChooseService_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtChooseService = (TextEdit)sender;
                int IDBookingHallService = Convert.ToInt32(viewServices.GetFocusedRowCellValue("IDBookingHallService"));
                this.aPaymentHallsEN.SetIndexSubServices(IDBookingHallService, Convert.ToInt32(txtChooseService.EditValue));
                List<IndexSubSplitBillEN> aListTemp = this.aPaymentHallsEN.aListIndexSubSplitBillH.Where(r => r.ID == IDBookingHallService).ToList();
                if (aListTemp.Count > 0)
                {
                    this.aPaymentHallsEN.aListIndexSubSplitBillH.Remove(aListTemp[0]);
                }
                IndexSubSplitBillEN aIndexSubSplitBillEN = new IndexSubSplitBillEN();
                aIndexSubSplitBillEN.ID = IDBookingHallService;
                aIndexSubSplitBillEN.IndexSub = Convert.ToInt32(txtChooseService.EditValue);
                aIndexSubSplitBillEN.SubBookingMoney = 0;
                aIndexSubSplitBillEN.SubStatus = 0;

                this.aPaymentHallsEN.aListIndexSubSplitBillH.Add(aIndexSubSplitBillEN);

                this.LoadListServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SplitBill_Step1.txtChooseService_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}