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
using System.IO;

namespace SaleManagement
{
    public partial class frmUpd_Menus : DevExpress.XtraEditors.XtraForm
    {
        private MenusEN aMenusEN = new MenusEN();
        private List<Foods> aListFoods = new List<Foods>();
        private int IDMenu;
        private frmLst_Menus afrmLst_Menus = null;
        public frmUpd_Menus(frmLst_Menus afrmLst_Menus, int IDMenu)
        {
            InitializeComponent();
            this.afrmLst_Menus = afrmLst_Menus;
            this.IDMenu = IDMenu;
        }
        public frmUpd_Menus()
        {
            InitializeComponent();
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
                MessageBox.Show("frmUpd_Menus.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmUpd_Menus.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //hiennv
        private void frmUpd_Menus_Load(object sender, EventArgs e)
        {
            try
            {
                MenusBO aMenusBO = new MenusBO();
                Menus aMenus = aMenusBO.Select_ByID(this.IDMenu);
                txtMenusName.Text = aMenus.Name;
                txtInfo.Text = aMenus.Info;

                this.LoadDataListAvaiableFoods();
                this.LoadDataListSelectFoods(this.IDMenu);

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.LoadDataFoods\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmUpd_Menus.btnSave_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    aMenusEN.ID = this.IDMenu;
                    aMenusEN.Name = txtMenusName.Text;
                    aMenusEN.Info =txtInfo.Text;
                    aMenusEN.IDBookingHall = 0; //thuc don thong dung
                    aMenusEN.IDSystemUser = 1;//de tam
                    aReceptionTaskBO.UpdateMenus(aMenusEN);
                    if (this.afrmLst_Menus != null)
                    {
                        this.afrmLst_Menus.LoadDataMenus();
                    }
                    
                    MessageBox.Show("Cập nhật thực đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.CheckDataBeforeAddNew\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmUpd_Menus.btnSelectFoods_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                Menus_Foods aMenus_Foods = aMenus_FoodsBO.Select_ByIDFoodAndIDMenu(Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID")),this.IDMenu);
                if (aMenus_Foods != null)
                {
                    aMenus_FoodsBO.Delete_ByIDMenuAndIDFood(this.IDMenu, Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID")));
                }
                Foods aFoodTemp = this.aMenusEN.aListFoods.Where(f => f.ID == Convert.ToInt32(viewSelectFoods.GetFocusedRowCellValue("ID"))).ToList()[0];
                this.aMenusEN.aListFoods.Remove(aFoodTemp);
                dgvSelectFoods.DataSource = this.aMenusEN.aListFoods;
                dgvSelectFoods.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.btnUnSelectFoods_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchFoods_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataListAvaiableFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.btnSearchFoods_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDataListAvaiableFoods()
        {
            try
            {
                this.aListFoods.Clear();
                FoodsBO aFoodsBO = new FoodsBO();
                List<Foods> aListTemp = aFoodsBO.Select_All();
                //aListTemp = aFoodsBO.Select_All();

                foreach (Foods item in aListTemp)
                {
                    Foods aFoods = aFoodsBO.Select_ByID(item.ID);
                    if (aFoods.Image1 != null)
                    {
                        if (aFoods.Image1.Length <= 0)
                        {
                           Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                            image = image.GetThumbnailImage(70,70, null, IntPtr.Zero);
                            Byte[] aImageByte = this.ConvertImageToByteArray(image);
                            aFoods.Image1 = aImageByte;
                        }
                    }
                    else
                    {
                        Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70,70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }

                    this.aListFoods.Add(aFoods);
                    dgvAvailableFoods.DataSource = this.aListFoods;
                    dgvAvailableFoods.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.LoadDataListAvaiableFoods\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDataListSelectFoods(int ID)
        {
            try
            {
                FoodsBO aFoodsBO = new FoodsBO();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                List<Foods> aListTemp = aReceptionTaskBO.GetListFoods_ByIDMenu(ID);
                foreach (Foods item in aListTemp)
                {
                    Foods aFoods = aFoodsBO.Select_ByID(item.ID);
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
                            Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                            image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                            Byte[] aImageByte = this.ConvertImageToByteArray(image);
                            aFoods.Image1 = aImageByte;
                        }
                    }
                    else
                    {
                        Image image = SaleManagement.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                    this.aMenusEN.aListFoods.Add(aFoods);
                }
                dgvSelectFoods.DataSource = this.aMenusEN.aListFoods;
                dgvSelectFoods.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Menus.LoadDataListSelectFoods\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}