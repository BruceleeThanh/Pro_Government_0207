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


namespace RoomManager
{
    public partial class frmTsk_ListBookingHs : DevExpress.XtraEditors.XtraForm
    {
        frmTsk_ManageBookingHs afrmTsk_ManageBookingHs = null;
        int IDBookingH = 0;
        List<BookingHalls> aListBookingHalls = new List<BookingHalls>();

        public frmTsk_ListBookingHs()
        {
            InitializeComponent();
        }
        public frmTsk_ListBookingHs(frmTsk_ManageBookingHs afrmTsk_ManageBookingHs, int IDBookingH)
        {
            InitializeComponent();
            this.afrmTsk_ManageBookingHs = afrmTsk_ManageBookingHs;
            this.IDBookingH = IDBookingH;
        }

        //Hiennv
        public List<BookingHEN> LoadData()
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                List<BookingHEN> aListBookedHs = new List<BookingHEN>();
                List<BookingHs> aListTemp = new List<BookingHs>();
                aListTemp = aBookingHsBO.Select_ByDate_byStatus(dtpFrom.DateTime, dtpTo.DateTime);
                BookingHEN aBookingHEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingHEN = new BookingHEN();
                    aBookingHEN.SetValue(aListTemp[i]);
                    aBookingHEN.StatusPayDisplay = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt16(aBookingHEN.StatusPay)).Name;
                    aBookingHEN.CustomerTypeDisplay = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt16(aBookingHEN.CustomerType)).Name;
                    if (aBookingHEN.Type == 1)
                    {
                        aBookingHEN.TypeDisplay = "Tiệc không thuộc phạm trù nhà bếp";
                    }
                    else
                    {
                        aBookingHEN.TypeDisplay = "Tiệc thuộc phạm trù nhà bếp";
                    }
                    aListBookedHs.Add(aBookingHEN);
                }
                return aListBookedHs;
            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show("frmTsk_ListBookingHs.LoadData\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.LoadData().Count > 0)
                {
                    dgvBookingRs.DataSource = this.LoadData();
                    dgvBookingRs.RefreshDataSource();
                }
                else
                {
                    dgvBookingRs.DataSource = null;
                    dgvBookingRs.RefreshDataSource();
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ListBookingHs.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvBookingRs_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            List<BookingHall_ServiceEN> aListBookingHall_ServiceEN = new List<BookingHall_ServiceEN>();
            HallsBO aHallsBO = new HallsBO();
            int IDBookingH = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("ID"));
            List<BookingHallsEN> aListBookingHalls = new List<BookingHallsEN>();
            List<BookingHalls> aListTemp = new List<BookingHalls>();
            aListTemp = aBookingHallsBO.Select_ByIDBookigH(IDBookingH);
            BookingHallsEN aBookingHallsEN;
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aBookingHallsEN = new BookingHallsEN();
                aBookingHallsEN.HallSku = aHallsBO.Select_ByCodeHall(aListTemp[i].CodeHall, 1).Sku;
                aBookingHallsEN.ID = aListTemp[i].ID;
                aBookingHallsEN.Cost = aListTemp[i].Cost;
                aBookingHallsEN.StartTime = aListTemp[i].StartTime;
                aBookingHallsEN.EndTime = aListTemp[i].EndTime;
                aListBookingHalls.Add(aBookingHallsEN);
            }
            dgvListBookingHalls.DataSource = aListBookingHalls;
            dgvListBookingHalls.RefreshDataSource();
            dgvServiceInBookingHall.DataSource = aListBookingHall_ServiceEN;
            dgvServiceInBookingHall.RefreshDataSource();
        }



        private void btnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvListBookingHalls.GetFocusedRowCellValue("ID"));
            frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = new frmIns_BookingHalls_Services(this, IDBookingHall);
            afrmIns_BookingHalls_Services.ShowDialog();

        }


        private void grvListBookingHalls_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvListBookingHalls.GetFocusedRowCellValue("ID"));
            ServicesBO aServicesBO = new ServicesBO();
            BookingHalls_ServicesBO aBookingHalls_ServicesBO = new BookingHalls_ServicesBO();
            List<BookingHall_ServiceEN> aListBookingHall_ServiceEN = new List<BookingHall_ServiceEN>();
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
                aBookingHall_ServiceEN.Cost = aListTemp[i].CostRef_Services;
                aBookingHall_ServiceEN.CostRef_Services = aListTemp[i].CostRef_Services;
                aBookingHall_ServiceEN.Date = aListTemp[i].Date;
                aBookingHall_ServiceEN.PercentTax = aListTemp[i].PercentTax;
                aBookingHall_ServiceEN.Quantity = aListTemp[i].Quantity;
                aListBookingHall_ServiceEN.Add(aBookingHall_ServiceEN);
            }
            dgvServiceInBookingHall.DataSource = aListBookingHall_ServiceEN;
            dgvServiceInBookingHall.RefreshDataSource();
        }

        private void btnDone_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BookingHsBO aBookingHsBO = new BookingHsBO();
            int IDBookingH = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("ID"));
            BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
            aBookingHs.Status = 7;
            aBookingHsBO.Update(aBookingHs);
            MessageBox.Show("Đã chuyển sang trạng thái 'Hoàn thành' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmTsk_ListBookingHs_Load(object sender, EventArgs e)
        {

            dtpFrom.DateTime = DateTime.Now.Date;
            dtpTo.DateTime = DateTime.Now.AddDays(7);
            dgvBookingRs.DataSource = this.LoadData();
            dgvBookingRs.RefreshDataSource();


            if (afrmTsk_ManageBookingHs != null)
            {
                tableLayoutPanel3.Visible = false;
                BookingHsBO aBookingHsBO = new BookingHsBO();
                List<BookingHEN> aListBookedHs = new List<BookingHEN>();
                BookingHs aTemp = aBookingHsBO.Select_ByID(this.IDBookingH);
                List<BookingHs> aListTemp = new List<BookingHs>();
                aListTemp.Add(aTemp);
                BookingHEN aBookingHEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingHEN = new BookingHEN();
                    aBookingHEN.SetValue(aListTemp[i]);
                    aBookingHEN.StatusPayDisplay = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt16(aBookingHEN.StatusPay)).Name;
                    aBookingHEN.CustomerTypeDisplay = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt16(aBookingHEN.CustomerType)).Name;
                    if (aBookingHEN.Type == 1)
                    {
                        aBookingHEN.TypeDisplay = "Tiệc không thuộc phạm trù nhà bếp";
                    }
                    else
                    {
                        aBookingHEN.TypeDisplay = "Tiệc thuộc phạm trù nhà bếp";
                    }
                    aListBookedHs.Add(aBookingHEN);
                }
                dgvBookingRs.DataSource = aListBookedHs;
                dgvBookingRs.RefreshDataSource();
            }
        }








    }
}