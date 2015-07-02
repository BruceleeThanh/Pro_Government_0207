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
using BussinessLogic;
using DataAccess;
using Library;
using System.IO;
using DevExpress.XtraEditors.Controls;
using CORESYSTEM;
using System.Globalization;

namespace RoomManager
{
    public partial class frmUpd_Rooms : DevExpress.XtraEditors.XtraForm
    {
        RoomsBO aRoomsBO = new RoomsBO();
        private int IDRoom;
        private frmLst_Rooms afrmLst_Rooms = null;
        public frmUpd_Rooms(int IDRoom, frmLst_Rooms afrmLst_Rooms)
        {
            InitializeComponent();
            this.IDRoom = IDRoom;
            this.afrmLst_Rooms = afrmLst_Rooms;
        }



        private void frmUpd_Rooms_Load(object sender, EventArgs e)
        {
            ConstantsXML aConst = new ConstantsXML();
            lueRoomType.Properties.DataSource = CORE.CONSTANTS.ListRoomsTypes;//Load RoomsType 
            lueRoomType.Properties.DisplayMember = "Name";
            lueRoomType.Properties.ValueMember = "ID";

            Rooms aRoom = aRoomsBO.Select_ByID(IDRoom);
            lblIDRoom.Text = IDRoom.ToString();
            txtSku.Text = aRoom.Sku;
            lueRoomType.EditValue = aRoom.Type;
            txtBed1.Text = aRoom.Bed1.ToString();
            txtBed2.Text = aRoom.Bed2.ToString();

            txtCostRef1.Text = Convert.ToString(aRoom.CostRef);

            txtInfo1.Text = aRoom.Info;
            txtIntro1.Text = aRoom.Intro;
            cbbDisable.Text = aRoom.Disable.ToString();
            cbbStatus.Text = aRoom.Status.ToString();
            if (aRoom.Image.Length > 0)
            {
                MemoryStream ms = new MemoryStream(aRoom.Image);
                pbxImage.Image = Image.FromStream(ms);
                pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;
            }
            
        }



        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn ảnh";
            op.Filter = "Png files|*.png|Jpg files|*.jpg|All files|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {

                System.IO.Stream aStreamImage = op.OpenFile();
                pbxImage.Image = System.Drawing.Image.FromStream(aStreamImage);
                pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;

            }
        }

        private bool ValidateData()
        {
            if (txtSku.Text == "")
            {
                txtSku.Focus();
                MessageBox.Show("Vui lòng nhập mã phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (cbbStatus.Text == "---Chọn Lựa---")
                {
                    MessageBox.Show("Cần nhập trạng thái phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {                   
                    Rooms aRoom = aRoomsBO.Select_ByID(IDRoom);
                    aRoom.Sku = txtSku.Text;
                    aRoom.Bed1 = String.IsNullOrEmpty(txtBed1.Text) == true ? 0 : int.Parse(txtBed1.Text);
                    aRoom.Bed2 = String.IsNullOrEmpty(txtBed2.Text) == true ? 0 : int.Parse(txtBed2.Text);
                    aRoom.Disable = bool.Parse(cbbDisable.Text);
                    aRoom.Image = (Byte[])new ImageConverter().ConvertTo(pbxImage.Image, typeof(Byte[]));
                    aRoom.Status = int.Parse(cbbStatus.Text);
                    aRoom.Type = Convert.ToInt32(lueRoomType.EditValue);

                    if(txtCostRef1.Text.Contains(","))
                    {
                        aRoom.CostRef = String.IsNullOrEmpty(txtCostRef1.Text) == true ? 0 : Decimal.Parse(txtCostRef1.Text);
                    }
                    else if (txtCostRef1.Text.Contains("."))
                    {
                        aRoom.CostRef = String.IsNullOrEmpty(txtCostRef1.Text) == true ? 0 : Decimal.Parse(txtCostRef1.Text, CultureInfo.InvariantCulture);
                    }

                    aRoom.CostUnit = txtCostUnit1.Text;
                    aRoom.IDLang = 1;
                    aRoom.Info = txtInfo1.Text;
                    aRoom.Intro = txtIntro1.Text;

                    aRoomsBO.Update(aRoom);

                    MessageBox.Show("Sửa thông tin phòng thành công");
                    this.Close();
                    
                    if(this.afrmLst_Rooms != null)
                    {
                        this.afrmLst_Rooms.ReloadData();
                        if (this.afrmLst_Rooms.afrmMain != null)
                        {
                            this.afrmLst_Rooms.afrmMain.ReloadData();
                        }
                    }
                    
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin phòng thất bại \n" + ex.Message);
            }
        }
    }
}