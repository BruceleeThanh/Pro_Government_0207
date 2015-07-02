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
using System.IO;
using DataAccess;
using BussinessLogic;
using DevExpress.XtraReports.UI;

namespace SaleManagement
{
    public partial class frmLst_DetailMenus : DevExpress.XtraEditors.XtraForm
    {
        private int IDMenu;

        public frmLst_DetailMenus()
        {
            InitializeComponent();
        }

        public frmLst_DetailMenus(int IDMenu)
        {
            InitializeComponent();
            this.IDMenu = IDMenu;
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
                MessageBox.Show("frmLst_DetailMenus.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmLst_DetailMenus.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void frmLst_DetailMenus_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                MenusBO aMenusBO = new MenusBO();
                Menus aMenus = aMenusBO.Select_ByID(this.IDMenu);
                lblNameMenu.Text = aMenus.Name;

                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                FoodsBO aFoodsBO = new FoodsBO();
                List<Foods> aListTemp = aReceptionTaskBO.GetListFoods_ByIDMenu(this.IDMenu);
                List<Foods> aListFoods = new List<Foods>();

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
                    aListFoods.Add(aFoods);
                   
                }
                dgvFoods.DataSource = aListFoods;
                dgvFoods.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_DetailMenus.frmLst_DetailMenus_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                frmRpt_DetailMenus afrmRpt_DetailMenus = new frmRpt_DetailMenus(this.IDMenu,0);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_DetailMenus);
                tool.ShowPreview();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_DetailMenus.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}