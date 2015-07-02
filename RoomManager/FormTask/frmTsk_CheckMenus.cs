using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using CORESYSTEM;
using Entity;
using DataAccess;

namespace RoomManager
{
    public partial class frmTsk_CheckMenus : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_CheckMenus()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            try
            {
                dtpFrom.DateTime = DateTime.Now;
                dtpTo.DateTime = DateTime.Now.AddDays(14);
                LoadListBookingHallHaveNotMenus();
                this.LoadListBookingHallHaveMenus();
                this.LoadListBookingHallSelectedMenu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckMenus.frmTsk_SearchBookingHalls_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadListBookingHallHaveNotMenus()
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                List<BookingHallsEN> aListTemp = new List<BookingHallsEN>();
                //danh sach tiec chưa có thực đơn 
                aListTemp.Clear();
                aListTemp = aReceptionTaskBO.GetListBookingHallsNotMenus_ByBookingHallsDate(dtpFrom.DateTime.Date, dtpTo.DateTime.Date); // tiec da co thuc don
                dgvHaveNotMenus.DataSource = this.GetListBookingHalls(aListTemp);
                dgvHaveNotMenus.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckMenus.LoadListBookingHallHaveNotMenus\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadListBookingHallHaveMenus()
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                List<BookingHallsEN> aListTemp = new List<BookingHallsEN>();
                //danh sach tiec da lên thực đơn nhưng chưa chốt
                aListTemp.Clear();
                aListTemp = aReceptionTaskBO.GetListBookingHallsHaveMenus(dtpFrom.DateTime.Date, dtpTo.DateTime.Date); // Chưa có thực đơn
                dgvBookingHalls_HaveMenus.DataSource = this.GetListBookingHalls(aListTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckMenus.LoadListBookingHallHaveMenus\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadListBookingHallSelectedMenu()
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                List<BookingHallsEN> aListTemp = new List<BookingHallsEN>();
                //danh sach tiec đã chọn thực đơn
                aListTemp.Clear();
                aListTemp = aReceptionTaskBO.GetListBookingHallsSelectedMenus(dtpFrom.DateTime.Date, dtpTo.DateTime.Date); // Đã chốt thực đơn
                dgvBookingHalls_Selected.DataSource = this.GetListBookingHalls(aListTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckMenus.LoadListBookingHallAlreadyComplete\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<BookingHallsEN> GetListBookingHalls(List<BookingHallsEN> aListBookingHallTemp)
        {
            try
            {
                List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();
                BookingHallsEN aBookingHallsEN;
                MenusBO aMenusBO = new MenusBO();

                foreach (BookingHallsEN item in aListBookingHallTemp)
                {
                    aBookingHallsEN = new BookingHallsEN();
                    aBookingHallsEN.IDBookingH = item.IDBookingH;
                    aBookingHallsEN.DisplayCustomerType = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(item.CustomerType)).Name;
                    aBookingHallsEN.ID = item.ID;
                    aBookingHallsEN.BookingStatus = item.BookingStatus;
                    
                    aBookingHallsEN.NameGuest = item.NameGuest;
                   
                    aBookingHallsEN.Date = item.Date;
                    aBookingHallsEN.LunarDate= item.LunarDate;
                    aBookingHallsEN.StartTime = item.StartTime;
                    aBookingHallsEN.EndTime = item.EndTime;
                    aBookingHallsEN.BookingTypeBookingH = item.BookingTypeBookingH;

                    aBookingHallsEN.StatusPayBookingH = item.StatusPayBookingH;
                    aBookingHallsEN.DisplayBookingType = CORE.CONSTANTS.SelectedBookingType(Convert.ToInt32(item.BookingTypeBookingH)).Name;

                    aBookingHallsEN.DisplayLevel = CORE.CONSTANTS.SelectedLevel(Convert.ToInt32(item.LevelBookingH)).Name;
                    aBookingHallsEN.HallSku = item.HallSku;
                    List<Menus> aListMenus = aMenusBO.Select_ByIDBookingHall(item.ID);
                    if (aListMenus.Count > 0)
                    {
                        aBookingHallsEN.HasMenu = " Có";
                    }
                    else
                    {
                        aBookingHallsEN.HasMenu = " Chưa có";
                    }
                    aListBookingHallsEN.Add(aBookingHallsEN);
                }
                return aListBookingHallsEN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckMenus.GetListBookingHalls\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void frmTsk_CheckMenus_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void dtpFrom_EditValueChanged(object sender, EventArgs e)
        {
            LoadListBookingHallHaveNotMenus();
            this.LoadListBookingHallHaveMenus();
            this.LoadListBookingHallSelectedMenu();
        }

        private void btnCreateMenu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvHaveNotMenus.GetFocusedRowCellValue("IDBookingHall"));
            frmIns_Menus afrmIns_Menus = new frmIns_Menus(this, IDBookingHall, 2);
            afrmIns_Menus.ShowDialog();
        }

        private void btnDetailBookingHaveNotMenus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvHaveNotMenus.GetFocusedRowCellValue("IDBookingHall"));
            frmLst_DetailBookingHalls afrmLst_DetailBookingHalls = new frmLst_DetailBookingHalls(this, IDBookingHall);
            afrmLst_DetailBookingHalls.ShowDialog();
        }

        private void btnSelectMenu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvBookingHalls_HaveMenus.GetFocusedRowCellValue("IDBookingHall"));
            frmTsk_SelectMenus afrmTsk_SelectMenus = new frmTsk_SelectMenus(this, IDBookingHall);
            afrmTsk_SelectMenus.ShowDialog();

        }

        private void btnDetail_HaveMenus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvBookingHalls_HaveMenus.GetFocusedRowCellValue("ID"));
            frmLst_DetailBookingHalls afrmLst_DetailBookingHalls = new frmLst_DetailBookingHalls(this, IDBookingHall);
            afrmLst_DetailBookingHalls.ShowDialog();
        }

        private void btnDetail_Selected_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(grvBookingHalls_Selected.GetFocusedRowCellValue("IDBookingHall"));
            frmLst_DetailBookingHalls afrmLst_DetailBookingHalls = new frmLst_DetailBookingHalls(this, IDBookingHall);
            afrmLst_DetailBookingHalls.ShowDialog();
        }

    }
}