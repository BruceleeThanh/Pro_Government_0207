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

namespace SaleManagement
{
    public partial class frmTsk_DetailMenus : DevExpress.XtraEditors.XtraForm
    {
        frmTsk_SearchBookingHalls afrmTsk_SearchBookingHalls = null;
        int IDBookingHall;
        List<Foods> aListFood1 = new List<Foods>();

        public frmTsk_DetailMenus()
        {
            InitializeComponent();
        }
        public frmTsk_DetailMenus(frmTsk_SearchBookingHalls afrmTsk_SearchBookingHalls, int IDBookingHall)
        {
            InitializeComponent();
            this.afrmTsk_SearchBookingHalls = afrmTsk_SearchBookingHalls;
            this.IDBookingHall = IDBookingHall;
        }


        public void LoadMenus()
        {
            try
            {
                MenusBO aMenusBO = new MenusBO();
                FoodsBO aFoodsBO = new FoodsBO();
                Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                List<Menus> aListMenus = aMenusBO.Select_ByIDBookingHall(IDBookingHall);
                if (aListMenus.Count > 0)
                {
                    Menus aSelectedMenus = aListMenus.Where(a => a.Status == 0).ToList()[0];
                    List<Foods> aListTemp1 = aMenus_FoodsBO.SelectListFoods_ByIDMenu(aSelectedMenus.ID);
                    foreach (Foods item in aListTemp1)
                    {
                        if (item.Image1 != null)
                        {
                            if (item.Image1.Length <= 0)
                            {
                                Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                                image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                                Byte[] aImageByte = this.ConvertImageToByteArray(image);
                                item.Image1 = aImageByte;
                            }
                        }
                        else
                        {
                            Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                            image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                            Byte[] aImageByte = this.ConvertImageToByteArray(image);
                            item.Image1 = aImageByte;
                        }
                        this.aListFood1.Add(item);
                    }
                    dgvMenu1.DataSource = aListFood1;
                    dgvMenu1.RefreshDataSource();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SelectMenus.LoadMenus\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void frmTsk_DetailMenus_Load(object sender, EventArgs e)
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            BookingHallDetailEN aBookingHallDetailEN = aReceptionTaskBO.GetDetailBookingHalls_ByIDBookingHall(this.IDBookingHall);
            lblNameCustomer.Text = aBookingHallDetailEN.NameCustomer;
            lblCustomerGroup.Text = aBookingHallDetailEN.NameCustomerGroup;
            lblSku.Text = aBookingHallDetailEN.SkuHall;
            lblLunarDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.LunarDateBookingHall);
            lblDate.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.DateBookingHall);

            lblStartTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallDetailEN.StartTimeBookingHall);
            lblEndTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallDetailEN.EndTimeBookingHall);

            lblNameMenu.Text = aBookingHallDetailEN.NameMenu;

            lblCustomerType.Text = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(aBookingHallDetailEN.CustomerTypeBookingH)).Name;
            lblLevel.Text = CORE.CONSTANTS.SelectedLevel(Convert.ToInt32(aBookingHallDetailEN.LevelBookingH)).Name;
            lblBookingType.Text = CORE.CONSTANTS.SelectedBookingType(Convert.ToInt32(aBookingHallDetailEN.BookingTypeBookingH)).Name;
            lblStatusBookingHall.Text = CORE.CONSTANTS.SelectedBookingHallStatus(Convert.ToInt32(aBookingHallDetailEN.StatusBookingHall)).Name;
            lblStatusPay.Text = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt32(aBookingHallDetailEN.StatusPayBookingH)).Name;

            LoadMenus();
        }
    }
}