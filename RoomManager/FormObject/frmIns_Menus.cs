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

namespace RoomManager
{
    public partial class frmIns_Menus : DevExpress.XtraEditors.XtraForm
    {
        private MenusEN aMenusEN = new MenusEN();
        private List<Foods> aListFoods = new List<Foods>();
        private frmTsk_SearchBookingHalls afrmTsk_SearchBookingHalls = null;
        frmLst_DetailBookingHalls afrmLst_DetailBookingHalls = null;
        private frmTsk_UpdBookingHall afrmTsk_UpdBookingHall = null;
        frmTsk_CheckMenus afrmTsk_CheckMenus = null;
        frmLst_Menus afrmLst_Menus = null;
        private int Type;
        private int IDBookingHall = 0;

        public frmIns_Menus(int Type)
        {
            InitializeComponent();
            this.Type = Type;
            labelControl3.Visible = false;
            lueAvailableMenus.Visible = false;
        }
        public frmIns_Menus(frmLst_Menus afrmLst_Menus, int Type)
        {
            InitializeComponent();
            this.afrmLst_Menus = afrmLst_Menus;
            this.Type = Type;

            labelControl3.Visible = false;
            lueAvailableMenus.Visible = false;

        }
        public frmIns_Menus(frmTsk_SearchBookingHalls afrmTsk_SearchBookingHalls, int IDBookingHall, int Type)
        {
            InitializeComponent();
            this.afrmTsk_SearchBookingHalls = afrmTsk_SearchBookingHalls;
            this.IDBookingHall = IDBookingHall;
            this.Type = Type;
        }
        public frmIns_Menus(frmTsk_CheckMenus afrmTsk_CheckMenus, int IDBookingHall, int Type)
        {
            InitializeComponent();
            this.afrmTsk_CheckMenus = afrmTsk_CheckMenus;
            this.IDBookingHall = IDBookingHall;
            this.Type = Type;
        }
        public frmIns_Menus(frmTsk_UpdBookingHall afrmTsk_UpdBookingHall, int IDBookingHall, int Type)
        {
            InitializeComponent();
            this.afrmTsk_UpdBookingHall = afrmTsk_UpdBookingHall;
            this.IDBookingHall = IDBookingHall;
            this.Type = Type;
        }

        public frmIns_Menus(frmLst_DetailBookingHalls afrmLst_DetailBookingHalls, int IDBookingHall, int Type)
        {
            InitializeComponent();
            this.afrmLst_DetailBookingHalls = afrmLst_DetailBookingHalls;
            this.IDBookingHall = IDBookingHall;
            this.Type = Type;
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
        private void frmIns_Menus_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataListFoods();
                MenusBO aMenusBO = new MenusBO();
                List<Menus> aListMenus = aMenusBO.Select_ByType(1);//thuc don co san
                lueAvailableMenus.Properties.DataSource = aListMenus;
                lueAvailableMenus.Properties.DisplayMember = "Name";
                lueAvailableMenus.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.frmIns_Menus_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckDataBeforeAddNew()
        {
            try
            {
                if (String.IsNullOrEmpty(txtMenusName.Text) == true)
                {
                    txtMenusName.Focus();
                    MessageBox.Show("Vui lòng nhập tên thực đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.btnSave_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //hiennv
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeAddNew() == true)
                {
                    if (this.afrmTsk_SearchBookingHalls != null)
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aMenusEN.Name = txtMenusName.Text;
                        aMenusEN.Issue = "";
                        aMenusEN.Info = txtInfo.Text;
                        aMenusEN.Type = this.Type; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenusEN.Status = 1; // de tam
                        aMenusEN.Disable = false; // de tam
                        aMenusEN.IDBookingHall = this.IDBookingHall;
                        aMenusEN.IDSystemUser = 0;//Khi kinh doanh thêm thực đơn mặc định trạng thái là 0 - đã xác nhận thực đơn
                        aReceptionTaskBO.CreateMenus(aMenusEN);
                        if (this.afrmTsk_SearchBookingHalls !=null)
                        {
                            this.afrmTsk_SearchBookingHalls.LoadDataBookingHalls();
                        }
                    }
                    else if (this.afrmLst_Menus != null)
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aMenusEN.Name = txtMenusName.Text;
                        aMenusEN.Issue = "";
                        aMenusEN.Info = txtInfo.Text;
                        aMenusEN.Type = this.Type; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenusEN.Status = 1; // de tam
                        aMenusEN.Disable = false; // de tam
                        aMenusEN.IDBookingHall = this.IDBookingHall;
                        aMenusEN.IDSystemUser = 1;//de tam
                        aReceptionTaskBO.CreateMenus(aMenusEN);
                        if (this.afrmLst_Menus !=null)
                        {
                            this.afrmLst_Menus.LoadDataMenus();
                        }
                    }
                    else if (afrmTsk_CheckMenus != null)
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aMenusEN.Name = txtMenusName.Text;
                        aMenusEN.Issue = "";
                        aMenusEN.Info = txtInfo.Text;
                        aMenusEN.Type = this.Type; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenusEN.Status = 0; // do kinh doanh đặt
                        aMenusEN.Disable = false; // de tam
                        aMenusEN.IDBookingHall = this.IDBookingHall;
                        aMenusEN.IDSystemUser = 1;//de tam
                        aReceptionTaskBO.CreateMenus(aMenusEN);
                        if (this.afrmTsk_CheckMenus !=null)
                        {
                            this.afrmTsk_CheckMenus.Reload();
                        }
                    }
                    else if (afrmLst_DetailBookingHalls != null)
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aMenusEN.Name = txtMenusName.Text;
                        aMenusEN.Issue = "";
                        aMenusEN.Info = txtInfo.Text;
                        aMenusEN.Type = this.Type; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenusEN.Status = 0; // do kinh doanh đặt
                        aMenusEN.Disable = false; // de tam
                        aMenusEN.IDBookingHall = this.IDBookingHall;
                        aMenusEN.IDSystemUser = 1;//de tam
                        aReceptionTaskBO.CreateMenus(aMenusEN);
                        if (this.afrmLst_DetailBookingHalls !=null)
                        {
                            this.afrmLst_DetailBookingHalls.LoadMenus();
                        }
                    }
                    else
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aMenusEN.Name = txtMenusName.Text;
                        aMenusEN.Issue = "";
                        aMenusEN.Info = txtInfo.Text;
                        aMenusEN.Type = this.Type; // type =1 ; thuc don mau ; Type 2: thuc don moi
                        aMenusEN.Status = 1; // de tam
                        aMenusEN.Disable = false; // de tam
                        aMenusEN.IDBookingHall = this.IDBookingHall;
                        aMenusEN.IDSystemUser = 1;//de tam
                        aReceptionTaskBO.CreateMenus(aMenusEN);
                    }
                    if (this.afrmTsk_UpdBookingHall != null)
                    {
                        this.afrmTsk_UpdBookingHall.Reload();
                    }
                    MessageBox.Show("Tạo thực đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.CheckDataBeforeAddNew\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectFoods_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.aMenusEN.aListFoods.Where(f => f.ID == Convert.ToInt32(viewAvailableFoods.GetFocusedRowCellValue("ID"))).ToList().Count() > 0)
                {
                    MessageBox.Show("Món ăn này đã có trong thực đơn vui lòng chọn món ăn khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Foods aFoods = new Foods();
                    aFoods.ID = Convert.ToInt32(viewAvailableFoods.GetFocusedRowCellValue("ID"));
                    aFoods.Name = Convert.ToString(viewAvailableFoods.GetFocusedRowCellValue("Name"));
                    aFoods.Name1 = Convert.ToString(viewAvailableFoods.GetFocusedRowCellValue("Name1"));
                    aFoods.Name2 = Convert.ToString(viewAvailableFoods.GetFocusedRowCellValue("Name2"));
                    aFoods.Name3 = Convert.ToString(viewAvailableFoods.GetFocusedRowCellValue("Name3"));
                    aFoods.Image1 = (byte[])viewAvailableFoods.GetFocusedRowCellValue("Image1");

                    this.aMenusEN.aListFoods.Add(aFoods);
                    dgvSelectFoods.DataSource = this.aMenusEN.aListFoods;
                    dgvSelectFoods.RefreshDataSource();

                    Foods aFoodsTemp = this.aListFoods.Where(f => f.ID == Convert.ToInt32(viewAvailableFoods.GetFocusedRowCellValue("ID"))).ToList()[0];
                    this.aListFoods.Remove(aFoodsTemp);
                    dgvAvailableFoods.DataSource = this.aListFoods;
                    dgvAvailableFoods.RefreshDataSource();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.btnSelectFoods_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnSelectFoods_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.aListFoods.Where(f => f.ID == Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID"))).ToList().Count() == 0)
                {
                    Foods aFoods = new Foods();
                    aFoods.ID = Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID"));
                    aFoods.Name = Convert.ToString(viewSelectFoods.GetFocusedRowCellValue("Name"));
                    aFoods.Name1 = Convert.ToString(viewSelectFoods.GetFocusedRowCellValue("Name1"));
                    aFoods.Name2 = Convert.ToString(viewSelectFoods.GetFocusedRowCellValue("Name2"));
                    aFoods.Name3 = Convert.ToString(viewSelectFoods.GetFocusedRowCellValue("Name3"));
                    aFoods.Image1 = (byte[])viewSelectFoods.GetFocusedRowCellValue("Image1");

                    this.aListFoods.Insert(0, aFoods);
                    dgvAvailableFoods.DataSource = this.aListFoods;
                    dgvAvailableFoods.RefreshDataSource();

                }
                Foods aFoodTemp = this.aMenusEN.aListFoods.Where(f => f.ID == Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID"))).ToList()[0];
                this.aMenusEN.aListFoods.Remove(aFoodTemp);
                dgvSelectFoods.DataSource = this.aMenusEN.aListFoods;
                dgvSelectFoods.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.btnUnSelectFoods_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchFoods_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataListFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.btnSearchFoods_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDataListFoods()
        {
            try
            {
                this.aListFoods.Clear();
                FoodsBO aFoodsBO = new FoodsBO();
                MenusBO aMenusBO = new MenusBO();
                List<Foods> aListFoods = aFoodsBO.Select_All();
                List<int> ListID = new List<int>();
                for (int i = 0; i < aListFoods.Count; i++)
                {
                    ListID.Add(aListFoods[i].ID);
                }
                List<Foods> aListTemp = aFoodsBO.Select_ByListID(ListID);
                foreach (Foods item in aListFoods)
                {
                    Foods aFoods = aListTemp.Where(p => p.ID == item.ID).ToList()[0];
                    if (aFoods.Image1 != null)
                    {
                        if (aFoods.Image1.Length <= 0)
                        {
                            Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                            image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                            Byte[] aImageByte = this.ConvertImageToByteArray(image);
                            aFoods.Image1 = aImageByte;
                        }
                    }
                    else
                    {
                        Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }

                    this.aListFoods.Add(aFoods);
                }
                dgvAvailableFoods.DataSource = this.aListFoods;
                dgvAvailableFoods.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Menus.LoadDataListFoods\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueAvailableMenus_EditValueChanged(object sender, EventArgs e)
        {
            this.aMenusEN.aListFoods.Clear();

            Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
            FoodsBO aFoodsBO = new FoodsBO();
            int IDMenu = Convert.ToInt32(lueAvailableMenus.EditValue);
            List<Foods> aListFoods = aMenus_FoodsBO.SelectListFoods_ByIDMenu(IDMenu);
            List<int> ListID = new List<int>();
            for (int i = 0; i < aListFoods.Count; i++)
            {
                ListID.Add(aListFoods[i].ID);
            }
            List<Foods> aListTemp = aFoodsBO.Select_ByListID(ListID);
            foreach (Foods item in aListFoods)
            {
                Foods aFoods = aListTemp.Where(p => p.ID == item.ID).ToList()[0];
                if (aFoods.Image1 != null)
                {
                    if (aFoods.Image1.Length > 0)
                    {
                        Image image = this.ConvertByteArrayToImage(aFoods.Image1);
                        image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                    else
                    {
                        Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                }
                else
                {
                    Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                    image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                    Byte[] aImageByte = this.ConvertImageToByteArray(image);
                    aFoods.Image1 = aImageByte;
                }

                this.aMenusEN.aListFoods.Add(aFoods);
            }
            dgvSelectFoods.DataSource = this.aMenusEN.aListFoods;
            dgvSelectFoods.RefreshDataSource();
        }


    }
}