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
    public partial class frmTsk_ManageBookingHs : DevExpress.XtraEditors.XtraForm
    {
        
        public frmTsk_ManageBookingHs()
        {
            InitializeComponent();
        }
        public void ReloadData()
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                List<BookingHEN> aListBookedHs = new List<BookingHEN>();
                List<BookingHs> aListTemp = new List<BookingHs>();
                int Status = Convert.ToInt32(lueStatus.EditValue);
                aListTemp = aBookingHsBO.SelectBookingHs_ByTime_ByStatus(dtpFrom.DateTime, dtpTo.DateTime, Status);
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
                dgvBookingHs.DataSource = aListBookedHs;
                dgvBookingHs.RefreshDataSource();
                if (Status == 1)
                {
                    gridColumn7.Visible = true;
                    gridColumn8.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
                else if (Status == 2)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = true;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
                else if (Status == 3)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn12.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
                else if (Status == 4)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn14.Visible = true;
                    gridColumn15.Visible = false;
                }
                else if (Status == 5)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = true;
                }
                else if (Status == 6)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = true;
                    gridColumn11.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
                else if (Status == 7)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = true;
                    gridColumn12.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
                else if (Status == 8)
                {
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn11.Visible = false;
                    gridColumn12.Visible = true;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.ReloadData \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_ManageBookingHs_Load(object sender, EventArgs e)
        {
            lueStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHStatus;
            lueStatus.Properties.DisplayMember = "Name";
            lueStatus.Properties.ValueMember = "ID";
            lueStatus.EditValue = CORE.CONSTANTS.SelectedBookingHStatus(1).ID;
            dtpFrom.DateTime = DateTime.Now.AddDays(-10);
            dtpTo.DateTime = DateTime.Now;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnWaitingConfirm_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                aBookingHs.Status = 3;
                aBookingHsBO.Update(aBookingHs);
                MessageBox.Show("Đã chuyển sang trạng thái 'Chờ bếp accept' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnWaitingConfirm_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                aBookingHs.Status = 4;
                aBookingHsBO.Update(aBookingHs);
                MessageBox.Show("Đã chuyển sang trạng thái 'Bếp đã accept' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnConfirm_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                string Name = aBookingHsBO.Select_ByID(IDBookingH).Subject;
                DialogResult result = MessageBox.Show(" Bạn muốn xóa buổi tiệc " + Name + " này ??", "Xóa buổi tiệc ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    aBookingHsBO.Delete(IDBookingH);
                    MessageBox.Show("Xóa thành công");
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnCancel_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void btnChecked_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                aBookingHs.Status = 2;
                aBookingHsBO.Update(aBookingHs);
                MessageBox.Show("Đã chuyển sang trạng thái 'Đã xác thực' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnChecked_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDone_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                frmTsk_ListBookingHs afrmTsk_ListBookingHs = new frmTsk_ListBookingHs(this, IDBookingH);
                afrmTsk_ListBookingHs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnDone_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                //decimal BookingMoney = Convert.ToDecimal(grvBookingHs.GetFocusedRowCellValue("BookingMoney"));
                //frmTsk_PaymentHall afrmTsk_PaymentHall = new frmTsk_PaymentHall(IDBookingH);
                //afrmTsk_PaymentHall.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnPayment_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                frmTsk_UpdBooking afrmTsk_UpdBooking = new frmTsk_UpdBooking(this, IDBookingH);
                afrmTsk_UpdBooking.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnEdit_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelay_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                aBookingHs.Status = 5;
                aBookingHsBO.Update(aBookingHs);
                MessageBox.Show("Đã chuyển sang trạng thái 'Tạm hoãn' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnDelay_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinue_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int IDBookingH = Convert.ToInt32(grvBookingHs.GetFocusedRowCellValue("ID"));
                BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
                aBookingHs.Status = 4;
                aBookingHsBO.Update(aBookingHs);
                MessageBox.Show("Đã chuyển sang trạng thái 'Bếp đã xác thực' ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ManageBookingHs.btnContinue_ButtonClick \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}