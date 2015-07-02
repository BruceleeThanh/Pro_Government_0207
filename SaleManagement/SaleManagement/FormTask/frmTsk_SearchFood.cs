using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DataAccess;
using System.IO;
using DevExpress.XtraReports.UI;
namespace SaleManagement
{
    public partial class frmTsk_SearchFood : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_SearchFood()
        {
            InitializeComponent();
        }
       
        //hiennv
        private void frmTsk_SearchFood_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataListFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchFood.frmTsk_SearchFood_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnSearchFoods_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataListFoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchFood.btnSearchFoods_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDataListFoods()
        {
            try
            {
               
                FoodsBO aFoodsBO = new FoodsBO();
                List<Foods> aListFoods = new List<Foods>();
                List<Foods> aListTemp = aFoodsBO.Select_All();
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
                MessageBox.Show("frmTsk_SearchFood.LoadDataListFoods\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SearchFood.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SearchFood.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
       
        //hiennv
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                List<Foods> aListFoods = new List<Foods>();
                int count = viewFoods.RowCount;
                for (int i = 0; i < count; i++)
                {
                    Foods aFoods = (Foods)viewFoods.GetRow(i);
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
                frmRpt_ListFoods afrmRpt_ListFoods = new frmRpt_ListFoods(aListFoods);
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_ListFoods);
                tool.ShowPreview();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SearchFood.btnPrint_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}