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
    public partial class frmTsk_UnpayBookingHs : DevExpress.XtraEditors.XtraForm
    {
        List<BookingHalls> aListBookingHalls = new List<BookingHalls>();

        public frmTsk_UnpayBookingHs()
        {
            InitializeComponent();
        }
        private bool ValidateData()
        {
            try
            {
                if (dtpFrom.EditValue == null)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    if (dtpFrom.DateTime > dtpTo.DateTime)
                    {
                        MessageBox.Show("Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UnpayBookingHs.ValidateData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<BookingHEN> Reload()
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    BookingHsBO aBookingHsBO = new BookingHsBO();
                    List<BookingHEN> aListBookedHs = new List<BookingHEN>();
                    List<BookingHs> aListTemp = new List<BookingHs>();
                    aListTemp = aBookingHsBO.SelectBookingHs_ByTime_ByStatus(dtpFrom.DateTime, dtpTo.DateTime, 7);

                    BookingHEN aBookingHEN;
                    for (int i = 0; i < aListTemp.Count; i++)
                    {
                        aBookingHEN = new BookingHEN();
                        aBookingHEN.SetValue(aListTemp[i]);
                        aBookingHEN.StatusDisplay = CORE.CONSTANTS.SelectedBookingHStatus(Convert.ToInt16(aBookingHEN.Status)).Name;
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
                return null;
            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show("frmTsk_UnpayBookingHs.Reload\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Reload().Count > 0)
            {
                dgvBookingRs.DataSource = this.Reload();
                dgvBookingRs.RefreshDataSource();
            }
            else
            {
                dgvBookingRs.DataSource =null;
                dgvBookingRs.RefreshDataSource();
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void grvBookingRs_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UnpayBookingHs.grvBookingRs_RowClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void grvListBookingHalls_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UnpayBookingHs.grvListBookingHalls_RowClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //int IDBookingH = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("ID"));
            //frmTsk_PaymentHall afrmTsk_PaymentHall = new frmTsk_PaymentHall(IDBookingH);
            //afrmTsk_PaymentHall.ShowDialog();
        }

        private void btnCancelBooking_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingRs.GetFocusedRowCellValue("ID"));
                string Name = aBookingHsBO.Select_ByID(IDBookingH).Subject;
                DialogResult result = MessageBox.Show(" Bạn muốn xóa buổi tiệc " + Name + " này ??", "Xóa buổi tiệc ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aBookingHsBO.Delete(IDBookingH);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UnpayBookingHs.btnCancelBooking_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_UnpayBookingHs_Load(object sender, EventArgs e)
        {
            dtpFrom.DateTime = DateTime.Now.AddDays(-7);
            dtpTo.DateTime = DateTime.Now;
            dgvBookingRs.DataSource = this.Reload();
            dgvBookingRs.RefreshDataSource();
        }
    }
}