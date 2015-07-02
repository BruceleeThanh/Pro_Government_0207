using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DataAccess;
using BussinessLogic;
using Entity;
using CORESYSTEM;

namespace SaleManagement
{
    public partial class frmTsk_SearchBookingHalls : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_SearchBookingHalls()
        {
            InitializeComponent();
        }

        //hiennv
        public bool LoadDataBookingHalls()
        {
            try
            {
                if (dtpFrom.DateTime.Date > dtpTo.DateTime.Date)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng nhập ngày bắt đầu tìm kiếm phải nhỏ hơn hoặc bằng ngày kết thúc tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                    List<BookingHallsEN> aListTemp = new List<BookingHallsEN>();
                    List<BookingHallsEN> aListBookingHallsEN = new List<BookingHallsEN>();

                    int choose = cboChoose.SelectedIndex;
                    int level = Convert.ToInt32(lueBookingHs_Level.EditValue);

                    if (choose == 0) // Tất cả hội trường
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = false;
                        colNameGuest.Visible = false;
                        gridColumn1.Visible = false;

                        aListTemp = aReceptionTaskBO.GetListBookingHallsIsUse_ByBookingHallsDate(dtpFrom.DateTime.Date, dtpTo.DateTime.Date);
                    }                   
                    else if (choose == 1) // Tiệc VIP
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = false;
                        colNameGuest.Visible = false;
                        gridColumn1.Visible = false;
                        aListTemp = aReceptionTaskBO.GetListBookingHalls_ByBookingHallsDate_ByBookingHsLevel(dtpFrom.DateTime, dtpTo.DateTime, level);
                    }                   
                    else if (choose == 2) // Tiệc chưa accept
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = true;
                        colNameGuest.Visible = false;
                        gridColumn1.Visible = false;
                        aListTemp = aReceptionTaskBO.GetListBookingHalls_ByBookingHallDate_ByBookingHallStatus(dtpFrom.DateTime, dtpTo.DateTime, 1); // bep chua accept
                    }
                    //else if (choose == 3) // Tiệc đã accept nhưng chưa có thực đơn
                    //{
                    //    colDetail.Visible = true;
                    //    colCreateMenu.Visible = true;
                    //    colNameGuest.Visible = false;
                    //    gridColumn1.Visible = false;
                    //    aListTemp = aReceptionTaskBO.GetListBookingHallsAcceptedButHaveNotMenus(dtpFrom.DateTime, dtpTo.DateTime); // bep da accept
                    //}
                    else if (choose == 4)// Bếp đã lên thực đơn
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = false;
                        colNameGuest.Visible = false;
                        gridColumn1.Visible = true;
                        aListTemp = aReceptionTaskBO.GetListBookingHallsHaveMenus(dtpFrom.DateTime, dtpTo.DateTime);
                    }
                    else if (choose == 5) //Đã lựa chọn thực đơn
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = false;
                        colNameGuest.Visible = false;
                        gridColumn1.Visible = false;
                        aListTemp = aReceptionTaskBO.GetListBookingHallsSelectedMenus(dtpFrom.DateTime, dtpTo.DateTime);
                    }                  
                   
                    else if (choose == 6) // tim kiem tiec theo khach moi
                    {
                        colDetail.Visible = true;
                        colCreateMenu.Visible = false;
                        colNameGuest.VisibleIndex = 1;
                        colNameGuest.Visible = true;
                        gridColumn1.Visible = false;

                        aListTemp = aReceptionTaskBO.GetListBookingHalls_ByBookingHallsDate_ByNameGuest(dtpFrom.DateTime, dtpTo.DateTime,txtNameGuest.Text);
                    }
                    BookingHallsEN aBookingHallsEN;
                    foreach (BookingHallsEN item in aListTemp)
                    {
                        aBookingHallsEN = new BookingHallsEN();
                        aBookingHallsEN.IDBookingH = item.IDBookingH;
                        aBookingHallsEN.DisplayCustomerType = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(item.CustomerTypeBookingH)).Name;
                        aBookingHallsEN.IDBookingHall = item.IDBookingHall;
                        aBookingHallsEN.BookingStatusBookingHall = item.BookingStatusBookingHall;
                        aBookingHallsEN.NameCustomer = item.NameCustomer;
                        aBookingHallsEN.NameCustomerGroup = item.NameCustomerGroup;
                        aBookingHallsEN.DateBookingHall = item.DateBookingHall;
                        aBookingHallsEN.LunarDateBookingHall = item.LunarDateBookingHall;
                        aBookingHallsEN.StartTimeBookingHall = item.StartTimeBookingHall;
                        aBookingHallsEN.EndTimeBookingHall = item.EndTimeBookingHall;
                        aBookingHallsEN.BookingTypeBookingH = item.BookingTypeBookingH;

                        aBookingHallsEN.StatusPayBookingH = item.StatusPayBookingH;
                        aBookingHallsEN.NoteBookingH = item.NoteBookingH;
                        aBookingHallsEN.DisplayBookingType = CORE.CONSTANTS.SelectedBookingType(Convert.ToInt32(item.BookingTypeBookingH)).Name;
                        aBookingHallsEN.DisplayLevel = CORE.CONSTANTS.SelectedLevel(Convert.ToInt32(item.LevelBookingH)).Name;
                        aBookingHallsEN.SkuHall = item.SkuHall;
                        aBookingHallsEN.NameGuest = item.NameGuest;
                        aListBookingHallsEN.Add(aBookingHallsEN);
                    }
                    dgvBookingHalls.DataSource = aListBookingHallsEN;
                    dgvBookingHalls.RefreshDataSource();
                    if (aListBookingHallsEN.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.LoadDataBookingHalls\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        //hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = this.LoadDataBookingHalls();
                if (status == false)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //hiennv
        private void cboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.LoadDatalueBookingHs_Level();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.cboChoose_SelectedIndexChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDatalueBookingHs_Level()
        {
            try
            {
                lueBookingHs_Level.Properties.DataSource = CORE.CONSTANTS.ListLevels;
                lueBookingHs_Level.Properties.DisplayMember = "Name";
                lueBookingHs_Level.Properties.ValueMember = "ID";

                int choose = cboChoose.SelectedIndex;

                if (choose == 0) //danh sach tat ca cac buoi tiec 
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = false;
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                }              
                else if (choose == 1) // tiec Vip
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = true;
                    lueBookingHs_Level.Properties.DataSource = CORE.CONSTANTS.LoadLevel_ByID(12);
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(12).ID;
                }
                else if (choose == 2) // tiec chua Accept
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = false;
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                }
                else if (choose == 3) // Tiệc đã accept nhưng chưa có thực đơn
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = false;
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                }
                else if (choose == 4)// Bếp đã lên thực đơn
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = false;
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                }
                else if (choose == 5) //Đã lựa chọn thực đơn
                {
                    lueBookingHs_Level.Visible = true;
                    txtNameGuest.Visible = false;
                    lueBookingHs_Level.Enabled = false;
                    lueBookingHs_Level.EditValue = CORE.CONSTANTS.SelectedLevel(15).ID;
                }
                else if (choose == 6) // tim kiem tiec theo khach moi
                {
                    lueBookingHs_Level.Visible = false;
                    txtNameGuest.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.LoadDatalueBookingHs_Level\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hiennv
        private void frmTsk_SearchBookingHalls_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFrom.EditValue = DateTime.Now.Date;
                dtpTo.EditValue = DateTime.Now.AddDays(15).Date;

                this.LoadDataBookingHalls();
                this.LoadDatalueBookingHs_Level();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.frmTsk_SearchBookingHalls_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnCreateMenu_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingHall = Convert.ToInt32(viewBookingHalls.GetFocusedRowCellValue("IDBookingHall"));
                frmIns_Menus afrmIns_Menus = new frmIns_Menus(this, IDBookingHall,2);//type=2 :thuc don moi
                afrmIns_Menus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.btnCreateMenu_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnDetail_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                int IDBookingHall = Convert.ToInt32(viewBookingHalls.GetFocusedRowCellValue("IDBookingHall"));
                frmTsk_DetailMenus afrmTsk_DetailMenus = new frmTsk_DetailMenus(this,IDBookingHall);
                afrmTsk_DetailMenus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchBookingHalls.btnDetail_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectMenus_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int IDBookingHall = Convert.ToInt32(viewBookingHalls.GetFocusedRowCellValue("IDBookingHall"));
            //frmTsk_SelectMenus afrmTsk_SelectMenus = new frmTsk_SelectMenus(this, IDBookingHall);
            //afrmTsk_SelectMenus.ShowDialog();
        }

    }
}