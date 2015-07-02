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
using BussinessLogic;
using Entity;
using CORESYSTEM;
using System.Text.RegularExpressions;

namespace RoomManager
{

    public partial class frmIns_BookingHalls_Services : DevExpress.XtraEditors.XtraForm
    {
        private bool IsDataChange = false;

        frmTsk_ListBookingHs afrmTsk_ListBookingHs = null;
        frmTsk_PaymentHall afrmTsk_PaymentHall = null;
        private frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = null;
        NewPaymentEN aNewPayment = new NewPaymentEN();
        NewPaymentHEN aNewPaymentH = new NewPaymentHEN();
        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
        List<Services> aListAvailable;
        List<BookingHall_ServiceEN> aListSelected = new List<BookingHall_ServiceEN>();
        List<BookingHalls_Services> aListRemove = new List<BookingHalls_Services>();
        frmTsk_UpdBookingHall afrmTsk_UpdBookingHall = new frmTsk_UpdBookingHall();

             
        private int IDBookingHall = 0;
        HallsBO aHallsBO = new HallsBO();



        public frmIns_BookingHalls_Services()
        {
            InitializeComponent();
        }

        public frmIns_BookingHalls_Services(frmTsk_ListBookingHs afrmTsk_ListBookingHs, int IDBookingHall)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            this.afrmTsk_ListBookingHs = afrmTsk_ListBookingHs;
        }
        public frmIns_BookingHalls_Services(frmTsk_PaymentHall afrmTsk_PaymentHall, int IDBookingHall)
        {
            InitializeComponent();
            this.afrmTsk_PaymentHall = afrmTsk_PaymentHall;
            this.IDBookingHall = IDBookingHall;
        }

        public frmIns_BookingHalls_Services(frmTsk_Payment_Step2 afrmTsk_Payment_Step2 ,int IDBookingHall,NewPaymentEN aNewPayment)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.IDBookingHall = IDBookingHall;
            this.aNewPayment = aNewPayment;
        }
        public frmIns_BookingHalls_Services(frmTsk_UpdBookingHall afrmTsk_UpdBookingHall, int IDBookingHall, NewPaymentHEN aNewPaymentH)
        {
            InitializeComponent();
            this.afrmTsk_UpdBookingHall = afrmTsk_UpdBookingHall;
            this.IDBookingHall = IDBookingHall;
            this.aNewPaymentH = aNewPaymentH;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmIns_Services afrmIns_Services = new frmIns_Services(this);
            afrmIns_Services.ShowDialog();
        }

        private void frmIns_BookingHalls_Services_Load(object sender, EventArgs e)
        {
            this.Reload();
            this.LoadServiceInBookingHall(this.IDBookingHall);
        }

        public void Reload()
        {
            try
            {
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                List<BookingHallsEN> aListBookingHall = new List<BookingHallsEN>();
                BookingHallsEN aBookingHallsEN = new BookingHallsEN();
                BookingHalls aBookingHalls = aBookingHallsBO.Select_ByID(IDBookingHall);
                aBookingHallsEN.ID = aBookingHalls.ID;
                aBookingHallsEN.HallSku = aHallsBO.Select_ByCodeHall(aBookingHalls.CodeHall, 1).Sku;
                aListBookingHall.Add(aBookingHallsEN);

                dtpDate.DateTime = aBookingHalls.Date.GetValueOrDefault();
                dgvHalls.DataSource = aListBookingHall;
                dgvHalls.RefreshDataSource();

                ServicesBO aServicesBO = new ServicesBO();
                aListAvailable = aServicesBO.Select_ByType(1);
                dgvService.DataSource = aListAvailable;
                dgvService.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_BookingHalls_Services.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHall_ServiceEN aBookingHall_ServiceEN = new BookingHall_ServiceEN();
                int IDService = Convert.ToInt32(grvService.GetFocusedRowCellValue("ID"));
                aBookingHall_ServiceEN.IDService = IDService;
                aBookingHall_ServiceEN.IDBookingHall = this.IDBookingHall;
                aBookingHall_ServiceEN.Service_Name = grvService.GetFocusedRowCellValue("Name").ToString();
                aBookingHall_ServiceEN.Cost = Convert.ToDecimal(grvService.GetFocusedRowCellValue("CostRef"));
                aBookingHall_ServiceEN.CostRef_Services = Convert.ToDecimal(grvService.GetFocusedRowCellValue("CostRef"));
                aBookingHall_ServiceEN.Service_Unit = grvService.GetFocusedRowCellValue("Unit").ToString();
                aBookingHall_ServiceEN.Date = dtpDate.DateTime;
                aBookingHall_ServiceEN.Quantity = 1;
                aBookingHall_ServiceEN.PercentTax = 10;

                this.aListSelected.Insert(0, aBookingHall_ServiceEN);
                dgvServiceInHall.DataSource = aListSelected;
                dgvServiceInHall.RefreshDataSource();

                this.IsDataChange = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_BookingHalls_Services.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //Hiennv
        private void btnCancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDService = Convert.ToInt32(grvServiceInHall.GetFocusedRowCellValue("IDService"));
                List<BookingHall_ServiceEN> aListTemp = aListSelected.Where(a => a.IDService == IDService).ToList();
                if (aListTemp.Count > 0)
                {
                    aListSelected.Remove(aListTemp[0]);
                }

                BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                BookingHalls_Services aTemp = aBookingHalls_ServicesBO.Select_ByIDService_ByIDBookingHall(IDService, this.IDBookingHall);
                if (aTemp != null)
                {
                    BookingHalls_Services aBookingHalls_Services = new BookingHalls_Services();
                    aBookingHalls_Services.IDBookingHall = this.IDBookingHall;
                    aBookingHalls_Services.IDService = IDService;
                    this.aListRemove.Add(aBookingHalls_Services);
                }

                dgvServiceInHall.DataSource = aListSelected;
                dgvServiceInHall.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_BookingHalls_Services.btnCancel_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsDataChange = false;
            Save();
        }

        private void Save()
        {

            BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
            BookingHalls_Services aBookingHalls_Services;
            for (int i = 0; i < aListSelected.Count; i++)
            {
                aBookingHalls_Services = aBookingHalls_ServicesBO.Select_ByID(aListSelected[i].ID);
                if (aBookingHalls_Services != null)
                {
                    aBookingHalls_Services.Cost = aListSelected[i].Cost;
                    aBookingHalls_Services.Quantity = aListSelected[i].Quantity;
                    aBookingHalls_Services.PercentTax = aListSelected[i].PercentTax;
                    aBookingHalls_Services.Date = aListSelected[i].Date;

                    aBookingHalls_ServicesBO.Update(aBookingHalls_Services);
                }
                else
                {
                    aBookingHalls_Services = new BookingHalls_Services();
                    aBookingHalls_Services.Info = "";
                    aBookingHalls_Services.Type = 1;
                    aBookingHalls_Services.Status = 1;
                    aBookingHalls_Services.Disable = false;
                    aBookingHalls_Services.IDBookingHall = this.IDBookingHall;
                    aBookingHalls_Services.IDService = aListSelected[i].IDService;
                    aBookingHalls_Services.Cost = aListSelected[i].Cost;
                    aBookingHalls_Services.Date = dtpDate.DateTime;
                    aBookingHalls_Services.CostRef_Services = aListSelected[i].CostRef_Services;
                    aBookingHalls_Services.PercentTax = 10;// de mac dinh
                    aBookingHalls_Services.Quantity = aListSelected[i].Quantity;
                    aBookingHalls_ServicesBO.Insert(aBookingHalls_Services);
                }
            }
            foreach (BookingHalls_Services items in this.aListRemove)
            {
                aBookingHalls_ServicesBO.Delete(items.ID);
            }

            if (this.afrmTsk_Payment_Step2 != null)
            {
                if (aNewPayment.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
                {
                    aNewPayment.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].aListServiceUsed.Clear();
                    aNewPayment.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].aListServiceUsed = aReceptionTaskBO.GetListServiceUsedInHall_ByIDBookingHall(IDBookingHall);

                }
                this.afrmTsk_Payment_Step2.Reload();
            }
            if (this.afrmTsk_UpdBookingHall != null)
            {
                if (aNewPaymentH.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList().Count > 0)
                {
                    aNewPaymentH.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].aListServiceUsed.Clear();
                    aNewPaymentH.aListBookingHallUsed.Where(a => a.ID == IDBookingHall).ToList()[0].aListServiceUsed = aReceptionTaskBO.GetListServiceUsedInHall_ByIDBookingHall(IDBookingHall);

                }
                this.afrmTsk_UpdBookingHall.Reload(this.aNewPaymentH);
            }

            MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        public void LoadServiceInBookingHall(int IDBookingHall)
        {
            try
            {
                ServicesBO aServicesBO = new ServicesBO();
                BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
                List<BookingHalls_Services> aListTemp = aBookingHalls_ServicesBO.Select_ByIDBookingHall(IDBookingHall);
                BookingHall_ServiceEN aBookingHall_ServiceEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingHall_ServiceEN = new BookingHall_ServiceEN();
                    aBookingHall_ServiceEN.ID = aListTemp[i].ID;
                    aBookingHall_ServiceEN.Info = aListTemp[i].Info;
                    aBookingHall_ServiceEN.Type = aListTemp[i].Type;
                    aBookingHall_ServiceEN.Status = aListTemp[i].Status;
                    aBookingHall_ServiceEN.Disable = aListTemp[i].Disable;
                    aBookingHall_ServiceEN.IDBookingHall = aListTemp[i].IDBookingHall;
                    aBookingHall_ServiceEN.IDService = aListTemp[i].IDService;
                    aBookingHall_ServiceEN.Service_Name = aServicesBO.Select_ByID(aListTemp[i].IDService).Name;
                    aBookingHall_ServiceEN.Service_Unit = aServicesBO.Select_ByID(aListTemp[i].IDService).Unit;

                    aBookingHall_ServiceEN.Cost = aListTemp[i].Cost == null ? aListTemp[i].CostRef_Services : aListTemp[i].Cost;
                    aBookingHall_ServiceEN.CostRef_Services = aListTemp[i].CostRef_Services;
                    aBookingHall_ServiceEN.Date = aListTemp[i].Date;
                    aBookingHall_ServiceEN.PercentTax = aListTemp[i].PercentTax;
                    aBookingHall_ServiceEN.Quantity = aListTemp[i].Quantity;
                    
                    aListSelected.Add(aBookingHall_ServiceEN);
                }
                dgvServiceInHall.DataSource = aListSelected;
                dgvServiceInHall.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_BookingHalls_Services.grvHalls_RowClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        // Lỗi số lượng nhập được số âm

        // Tạo thêm MessageBox
        // Bắt đầu
        private void grvServiceInHall_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (Convert.ToDouble(e.Value) < 1) {
                MessageBox.Show("Đơn vị số lượng nhỏ nhất là 1.\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                this.IsDataChange = true;
                int ID = Convert.ToInt32(grvServiceInHall.GetFocusedRowCellValue("ID"));
                if (e.Column.Name == "grcQuantity") {

                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Quantity = Convert.ToDouble(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcCost") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Cost = Convert.ToDecimal(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcPercentTax") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].PercentTax = Convert.ToDouble(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcDateUseService") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Date = Convert.ToDateTime(e.Value);
                        }
                    }
                }
            }
        }
        // Kết thúc

        private void frmIns_BookingHalls_Services_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsDataChange == true)
            {
           
                DialogResult result1 = MessageBox.Show("Bạn có muốn lưu lại thông tin không ?","Save ?",MessageBoxButtons.YesNo);
                if (result1 == System.Windows.Forms.DialogResult.Yes)
                {
                    this.IsDataChange = false;
                    this.Save();
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

        }





    }
}