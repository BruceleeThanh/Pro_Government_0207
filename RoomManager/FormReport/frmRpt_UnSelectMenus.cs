using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Windows.Forms;
using DataAccess;
using Entity;
using BussinessLogic;
using CORESYSTEM;
using System.Collections.Generic;

namespace RoomManager
{
    public partial class frmRpt_UnSelectMenus : DevExpress.XtraReports.UI.XtraReport
    {
        int IDBookingHall;
        int IDMenu = 0;
        List<Foods> aListFood1 = new List<Foods>();
        List<Foods> aListFood2 = new List<Foods>();

        public frmRpt_UnSelectMenus(int IDBookingHall)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            FoodsBO aFoodsBO = new FoodsBO();
            MenusBO aMenusBO = new MenusBO();
           
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
           
            // Thông tin buổi tiệc
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            BookingHalls aTemp = aBookingHallsBO.Select_ByID(IDBookingHall);
            lblStartTime.Text = aTemp.StartTime.ToString();
            lblEndTime.Text = aTemp.EndTime.ToString();
            HallsBO aHallsBO = new HallsBO();
            lblHallSku.Text = aHallsBO.Select_ByCodeHall(aTemp.CodeHall, 1).Sku;
            BookingHsBO aBookingHsBO = new BookingHsBO();
            lblSubject.Text = aBookingHsBO.Select_ByID(aTemp.IDBookingH).Subject;
            this.LoadMenus();
            //danh sach cac mon an co trong thuc don 1 
            DetailReport.DataSource = aListFood1;
            picImage1Food.DataBindings.Add("Image", this.DataSource, "Image1");
            colNameFood.DataBindings.Add("Text", this.DataSource, "Name");
            colName1Food.DataBindings.Add("Text", this.DataSource, "Name1");
            colName2Food.DataBindings.Add("Text", this.DataSource, "Name2");
            colName3Food.DataBindings.Add("Text", this.DataSource, "Name3");
           
        }
        public frmRpt_UnSelectMenus(int IDBookingHall,int IDMenu)
        {
            InitializeComponent();
            this.IDBookingHall = IDBookingHall;
            FoodsBO aFoodsBO = new FoodsBO();
            MenusBO aMenusBO = new MenusBO();

            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

            // Thông tin buổi tiệc
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            BookingHalls aTemp = aBookingHallsBO.Select_ByID(IDBookingHall);
            lblStartTime.Text = aTemp.StartTime.ToString();
            lblEndTime.Text = aTemp.EndTime.ToString();
            HallsBO aHallsBO = new HallsBO();
            lblHallSku.Text = aHallsBO.Select_ByCodeHall(aTemp.CodeHall, 1).Sku;
            BookingHsBO aBookingHsBO = new BookingHsBO();
            lblSubject.Text = aBookingHsBO.Select_ByID(aTemp.IDBookingH).Subject;
            // Load Menu
            Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();               
                Menus aMenus = aMenusBO.Select_ByID(IDMenu);
                if (aMenus  != null)
                {
                    List<Foods> aListTemp1 = aMenus_FoodsBO.SelectListFoods_ByIDMenu(aMenus.ID);
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
                        aListFood1.Add(item);
                    }
                }
           
            //danh sach cac mon an co trong thuc don 1 
            DetailReport.DataSource = aListFood1;
            picImage1Food.DataBindings.Add("Image", this.DataSource, "Image1");
            colNameFood.DataBindings.Add("Text", this.DataSource, "Name");
            colName1Food.DataBindings.Add("Text", this.DataSource, "Name1");
            colName2Food.DataBindings.Add("Text", this.DataSource, "Name2");
            colName3Food.DataBindings.Add("Text", this.DataSource, "Name3");
           
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
                MessageBox.Show("frmRpt_UnSelectMenus.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmRpt_UnSelectMenus.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
                if (aListMenus.Count > 0)
                {                  
                    List<Foods> aListTemp1 = aMenus_FoodsBO.SelectListFoods_ByIDMenu(aListMenus[0].ID);
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
                        aListFood1.Add(item);
                    }                

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SelectedMenus.LoadMenus\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
