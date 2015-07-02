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
using DevExpress.XtraReports.UI;
using System.IO;

namespace SaleManagement
{
    public partial class frmLst_DetailBookingHalls : DevExpress.XtraEditors.XtraForm
    {

        private int IDBookingHall;
        frmMain afrmMain = null;
        frmTsk_CheckMenus afrmTsk_CheckMenus = null;
       
        List<Foods> aListFood2 = new List<Foods>();
        public frmLst_DetailBookingHalls()
        {
            InitializeComponent();
        }
        public frmLst_DetailBookingHalls(frmMain afrmMain,int IDBookingHall)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            this.afrmMain = afrmMain;
        }
        public frmLst_DetailBookingHalls(frmTsk_CheckMenus afrmTsk_CheckMenus, int IDBookingHall)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            this.afrmTsk_CheckMenus = afrmTsk_CheckMenus;
        }

        private void frmLst_DetailBookingHalls_Load(object sender, EventArgs e)
        {
            try
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
                dgvServices.DataSource = aBookingHallDetailEN.aListServicesHallsEN;
                dgvServices.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_DetailBookingHalls.frmLst_DetailBookingHalls_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmRpt_DetailBookingHalls.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmLst_DetailBookingHalls.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try {
                frmRpt_DetailBookingHalls afrmRpt_DetailBookingHalls = new frmRpt_DetailBookingHalls(this.IDBookingHall);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_DetailBookingHalls);
                tool.ShowPreview();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_DetailBookingHalls.btnPrint_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (aListMenus.Count > 0)
                {
                    btnCreateMenu.Visible = false;                
                                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SelectedMenus.LoadMenus\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnCreateMenu_Click(object sender, EventArgs e)
        {
            frmIns_Menus afrmIns_Menus = new frmIns_Menus(this, 2, this.IDBookingHall);
            afrmIns_Menus.ShowDialog();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmRpt_UnSelectMenus afrmRpt_UnSelectMenus = new frmRpt_UnSelectMenus(this.IDBookingHall);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_UnSelectMenus);
                tool.ShowPreview();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_DetailBookingHalls.btnPrint_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShow_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
            List<Foods> aListFood1 = new List<Foods>();

            int IDMenu = Convert.ToInt32(grvMenus.GetFocusedRowCellValue("ID"));
            List<Foods> aListTemp1 = new List<Foods>();
            aListTemp1 = aMenus_FoodsBO.SelectListFoods_ByIDMenu(IDMenu);
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
                aListFood1.Add(item);
            }
            dgvFoods.DataSource = aListFood1;
            dgvFoods.RefreshDataSource();
        }

        private void btnPrintMenu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDMenu = Convert.ToInt32(grvMenus.GetFocusedRowCellValue("ID"));
            frmRpt_UnSelectMenus afrmRpt_UnSelectMenus = new frmRpt_UnSelectMenus(this.IDBookingHall,IDMenu);
            ReportPrintTool tool = new ReportPrintTool(afrmRpt_UnSelectMenus);
            tool.ShowPreview();
        }
    }
}