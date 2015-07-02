using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataAccess;
using Entity;
using BussinessLogic;
using System.Windows.Forms;
using System.IO;
using CORESYSTEM;
using System.Collections.Generic;

namespace SaleManagement
{
    public partial class frmRpt_DetailBookingHalls : DevExpress.XtraReports.UI.XtraReport
    {
        private int IDBookingHall;
        //hiennv
        public frmRpt_DetailBookingHalls(int IDBookingHall)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                BookingHallDetailEN aBookingHallDetailEN = aReceptionTaskBO.GetDetailBookingHalls_ByIDBookingHall(this.IDBookingHall);
                celNameCustomer.Text = aBookingHallDetailEN.NameCustomer;
                celNameCustomerGoup.Text = aBookingHallDetailEN.NameCustomerGroup;
                celSkuHall.Text = aBookingHallDetailEN.SkuHall;
                celLunarDateBookingHall.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.LunarDateBookingHall);
                celDateBookingHall.Text = String.Format("{0:dd/MM/yyyy}", aBookingHallDetailEN.DateBookingHall);

                lblStartTime.Text = String.Format(@"{0:hh\:mm}",aBookingHallDetailEN.StartTimeBookingHall);
                lblEndTime.Text = String.Format(@"{0:hh\:mm}", aBookingHallDetailEN.EndTimeBookingHall);

                lblNameMenu.Text = aBookingHallDetailEN.NameMenu;

                celCustomerTypeBookingH.Text = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(aBookingHallDetailEN.CustomerTypeBookingH)).Name;
                celLevelBookingH.Text = CORE.CONSTANTS.SelectedLevel(Convert.ToInt32(aBookingHallDetailEN.LevelBookingH)).Name;
                celBookingTypeBookingH.Text = CORE.CONSTANTS.SelectedBookingType(Convert.ToInt32(aBookingHallDetailEN.BookingTypeBookingH)).Name;
                celStatusBookingHall.Text = CORE.CONSTANTS.SelectedBookingHallStatus(Convert.ToInt32(aBookingHallDetailEN.StatusBookingHall)).Name;
                celStatusPayBookingH.Text = CORE.CONSTANTS.SelectedStatusPay(Convert.ToInt32(aBookingHallDetailEN.StatusPayBookingH)).Name;


                FoodsBO aFoodsBO = new FoodsBO();
                List<Foods> aListFoods = new List<Foods>();
                foreach (Foods item in aBookingHallDetailEN.aListFoods)
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


                //danh sach cac mon an co trong thuc don
                this.DetailReportMenu.DataSource =aListFoods;
                picImage1Food.DataBindings.Add("Image", this.DetailReportMenu.DataSource, "Image1");
                colNameFood.DataBindings.Add("Text", this.DetailReportMenu.DataSource, "Name");
                colName1Food.DataBindings.Add("Text", this.DetailReportMenu.DataSource, "Name1");
                colName2Food.DataBindings.Add("Text", this.DetailReportMenu.DataSource, "Name2");
                colName3Food.DataBindings.Add("Text", this.DetailReportMenu.DataSource, "Name3");

                //danh dach cac dich vu su dung
                this.DetailReportServiceInUse.DataSource = aBookingHallDetailEN.aListServicesHallsEN;
                colNameServices.DataBindings.Add("Text", this.DetailReportServiceInUse.DataSource,"NameService");
                colDate.DataBindings.Add("Text", this.DetailReportServiceInUse.DataSource, "Date","{0:dd/MM/yyyy}");
                colCostRef_Services.DataBindings.Add("Text", this.DetailReportServiceInUse.DataSource, "CostRef_Services","{0:0,0}");
                colPercentTax.DataBindings.Add("Text", this.DetailReportServiceInUse.DataSource, "PercentTax");
                colQuantity.DataBindings.Add("Text", this.DetailReportServiceInUse.DataSource, "Quantity","{0:0,0}");
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRpt_DetailBookingHalls.frmRpt_DetailBookingHalls\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmRpt_DetailBookingHalls.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
