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
    public partial class frmRpt_DetailMenus : DevExpress.XtraReports.UI.XtraReport
    {
        //hiennv
        private int IDMenu;
        int IDBookingHall;

        public frmRpt_DetailMenus(int IDMenu,int IDBookingHall)
        {
            InitializeComponent();
            this.IDMenu = IDMenu;
            this.IDBookingHall = IDBookingHall;
            FoodsBO aFoodsBO = new FoodsBO();
            MenusBO aMenusBO = new MenusBO();
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            List<Foods> aListTemp = aReceptionTaskBO.GetListFoods_ByIDMenu(this.IDMenu);
            List<Foods> aListFoods = new List<Foods>();

            foreach (Foods item in aListTemp)
            {
                Foods aFoods = aFoodsBO.Select_ByID(item.ID);
                if (aFoods.Image1 != null)
                {
                    if (aFoods.Image1.Length <= 0)
                    {
                        Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                        image = image.GetThumbnailImage(70,70, null, IntPtr.Zero);
                        Byte[] aImageByte = this.ConvertImageToByteArray(image);
                        aFoods.Image1 = aImageByte;
                    }
                }
                else
                {
                    Image image = RoomManager.Properties.Resources.logo_nkcp_small;
                    image = image.GetThumbnailImage(70,70, null, IntPtr.Zero);
                    Byte[] aImageByte = this.ConvertImageToByteArray(image);
                    aFoods.Image1 = aImageByte;
                }

                aListFoods.Add(aFoods);
            }

            Menus aMenus = aMenusBO.Select_ByID(this.IDMenu);
            lblNameMenu.Text = aMenus.Name;
            //danh sach cac mon an co trong thuc don
            this.DataSource = aListFoods;
            picImage1Food.DataBindings.Add("Image", this.DataSource, "Image1");
            colNameFood.DataBindings.Add("Text", this.DataSource, "Name");
            colName1Food.DataBindings.Add("Text", this.DataSource, "Name1");
            colName2Food.DataBindings.Add("Text", this.DataSource, "Name2");
            colName3Food.DataBindings.Add("Text", this.DataSource, "Name3");
            // Thông tin buổi tiệc
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            BookingHalls aTemp = aBookingHallsBO.Select_ByID(IDBookingHall);
            lblStartTime.Text = aTemp.Date.ToString();
            HallsBO aHallsBO = new HallsBO();
            lblHallSku.Text = aHallsBO.Select_ByCodeHall(aTemp.CodeHall,1).Sku;
            BookingHsBO aBookingHsBO = new BookingHsBO();
            lblSubject.Text = aBookingHsBO.Select_ByID(aTemp.IDBookingH).Subject;

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
                MessageBox.Show("frmRpt_DetailMenus.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmRpt_DetailMenus.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
