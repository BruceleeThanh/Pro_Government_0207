using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using System.IO;
using DataAccess;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_SelectMenus : DevExpress.XtraEditors.XtraForm
    {
        frmTsk_CheckMenus afrmTsk_CheckMenus = null;
        frmLst_DetailBookingHalls afrmLst_DetailBookingHalls = null;
        int IDBookingHall;
        List<Foods> aListFood1 = new List<Foods>();
        List<Foods> aListFood2 = new List<Foods>();

        public frmTsk_SelectMenus()
        {
            InitializeComponent();
        }
        public frmTsk_SelectMenus(frmTsk_CheckMenus afrmTsk_CheckMenus, int IDBookingHall)
        {
            InitializeComponent();
            this.afrmTsk_CheckMenus = afrmTsk_CheckMenus;
            this.IDBookingHall = IDBookingHall;
        }

        public frmTsk_SelectMenus(frmLst_DetailBookingHalls afrmLst_DetailBookingHalls, int IDBookingHall)
        {
            InitializeComponent();
            this.afrmLst_DetailBookingHalls = afrmLst_DetailBookingHalls;
            this.IDBookingHall = IDBookingHall;
        }
          //Hiennv
        public Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv
        public byte[] ConvertImageToByteArray(Image imageIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //hiennv

        private void frmTsk_SelectMenus_Load(object sender, EventArgs e)
        {
             try
            {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            BookingHallDetailEN aBookingHallDetailEN = aReceptionTaskBO.GetDetailBookingHalls_ByIDBookingHall(this.IDBookingHall);
            lblNameCustomer.Text = aBookingHallDetailEN.NameCustomer;
            lblCustomerGroup.Text = aBookingHallDetailEN.NameCustomerGroup;
            lblSku.Text = aBookingHallDetailEN.HallSku;
            lblLunarDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.LunarDate);
            lblDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.Date);

            lblStartTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallDetailEN.StartTime);
            lblEndTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallDetailEN.EndTime);

            lblNameMenu.Text = aBookingHallDetailEN.NameMenu;

            lblCustomerType.Text = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(aBookingHallDetailEN.CustomerType)).Name;
            lblLevel.Text = CORE.CONSTANTS.SelectedLevel(Convert.ToInt32(aBookingHallDetailEN.LevelBookingH)).Name;
            lblBookingType.Text = CORE.CONSTANTS.SelectedBookingType(Convert.ToInt32(aBookingHallDetailEN.BookingTypeBookingH)).Name;
            lblStatusBookingHall.Text = CORE.CONSTANTS.SelectedBookingHallStatus(Convert.ToInt32(aBookingHallDetailEN.Status)).Name;
            lblStatusPay.Text = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt32(aBookingHallDetailEN.StatusPayBookingH)).Name;

            LoadMenus();
            }
             catch (Exception ex)
             {
                 MessageBox.Show("frmTsk_SelectMenus.frmTsk_SelectMenus_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        public void LoadMenus()
        {
            try
            {
                MenusBO aMenusBO = new MenusBO();
                FoodsBO aFoodsBO = new FoodsBO();
                Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                List<Menus> aListMenus = aMenusBO.Select_ByIDBookingHall(IDBookingHall);
                dgvMenus.DataSource = aListMenus;
                dgvMenus.RefreshDataSource();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SelectedMenus.LoadMenus\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void grvMenus_RowClick(object sender, RowClickEventArgs e)
        {
            Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
            int IDMenu = Convert.ToInt32(grvMenus.GetFocusedRowCellValue("ID"));
            List<Foods> aListTemp1 = aMenus_FoodsBO.SelectListFoods_ByIDMenu(IDMenu);
            foreach (Foods item in aListTemp1)
            {
                if (item.Image1 != null)
                {
                    if (item.Image1.Length <= 0)
                    {
                        Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        item.Image1 = aImageByte;
                    }
                }
                else
                {
                    Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                    image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                    Byte[] aImageByte = this.ConvertImageToByteArray(image);
                    item.Image1 = aImageByte;
                }
                this.aListFood1.Add(item);
            }
            dgvFoods.DataSource = aListFood1;
            dgvFoods.RefreshDataSource();

        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MenusBO aMenusBO = new MenusBO();
            int IDMenu = Convert.ToInt32(grvMenus.GetFocusedRowCellValue("ID"));
            Menus aMenu = aMenusBO.Select_ByID(IDMenu);
            aMenu.Status = 0;
            aMenusBO.Update(aMenu);
            MessageBox.Show("Lựa chọn thực đơn chính thức thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (afrmTsk_CheckMenus != null)
            {
                afrmTsk_CheckMenus.Reload();
            }
            this.Close();
        }

       
    }
}