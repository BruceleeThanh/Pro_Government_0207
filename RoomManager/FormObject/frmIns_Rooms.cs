using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors.Controls;
using Library;
using CORESYSTEM;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace RoomManager
{
    public partial class frmIns_Rooms : DevExpress.XtraEditors.XtraForm
    {
        RoomsBO aRoomsBO = new RoomsBO();
        private frmLst_Rooms afrmLst_Rooms = null;
        private frmMain afrmMain = null;
        public frmIns_Rooms(frmLst_Rooms afrmLst_Rooms)
        {
            InitializeComponent();
            this.afrmLst_Rooms = afrmLst_Rooms;
        }
        public frmIns_Rooms(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }

       
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Chọn ảnh";
            op.Filter = "Png files|*.png|Jpg files|*.jpg|All files|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {

                Stream aStreamImage = op.OpenFile();
                pbxImage.Image = System.Drawing.Image.FromStream(aStreamImage);
                pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;

            }

        }

        private class LittleRoom
        {
            string Sku { set; get; }
            int IDLang { set; get; }
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
                List<Rooms> aListRoomTemp = aRoomsBO.Select_All();
                Rooms a = aListRoomTemp.Find(p => p.Sku == txtSku.Text & p.IDLang == 1);
                if (a != null)
                {
                    MessageBox.Show("Mã phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    List<Rooms> aListRoomTemp = aRoomsBO.Select_All();
                    Rooms aRoom = new Rooms();
                    aRoom.Sku = txtSku.Text;
                    aRoom.Bed1 = !String.IsNullOrEmpty(txtBed1.Text) ? Convert.ToInt32(txtBed1.Text) : 0;
                    aRoom.Bed2 = !String.IsNullOrEmpty(txtBed2.Text) ? Convert.ToInt32(txtBed2.Text) : 0;
                    aRoom.Disable = bool.Parse(cbbDisable.Text);
                    aRoom.Status = int.Parse(cbbStatus.Text);
                    aRoom.Type = Convert.ToInt32(lueRoomType.EditValue);
                    aRoom.Image = (Byte[])new ImageConverter().ConvertTo(pbxImage.Image, typeof(Byte[]));
                    
                    TimeSpan Codespan = new TimeSpan(DateTime.Now.Ticks);
                    string b = Math.Floor(Codespan.TotalSeconds).ToString();
                    
                    for (int i = 1; i <= 2; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                Rooms a1 = aListRoomTemp.Find(p => p.Sku == txtSku.Text & p.IDLang == 1);
                                if (a1 == null)
                                {
                                    aRoom.CostRef = String.IsNullOrEmpty(txtCostRef1.Text) == true ? 0 : Decimal.Parse(txtCostRef1.Text);
                                    
                                    aRoom.CostUnit = txtCostUnit1.Text;
                                    aRoom.IDLang = 1;
                                    aRoom.Info = txtInfo1.Text;
                                    aRoom.Intro = txtIntro1.Text;
                                    aRoom.Code = b;
                                    aRoomsBO.Insert(aRoom);
                                }
                                else
                                {
                                    MessageBox.Show("Mã phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case 2:
                                Rooms a2 = aListRoomTemp.Find(p => p.Sku == txtSku.Text & p.IDLang == 2);
                                if (a2 == null)
                                {
                                    aRoom.CostRef = String.IsNullOrEmpty(txtCostRef1.Text) == true ? 0 : Decimal.Parse(txtCostRef1.Text);
                                    aRoom.CostUnit = txtCostUnit2.Text;
                                    aRoom.IDLang = 2;
                                    aRoom.Info = txtInfo2.Text;
                                    aRoom.Intro = txtIntro2.Text;
                                    aRoom.Code = b;
                                    aRoomsBO.Insert(aRoom);
                                }
                                else
                                {
                                    MessageBox.Show("Mã phòng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                        }

                    }

                    MessageBox.Show("Thêm phòng thành công");
                    this.Close();
                    if (this.afrmLst_Rooms != null)
                    {
                        this.afrmLst_Rooms.ReloadData();
                        if(this.afrmLst_Rooms.afrmMain !=null)
                        {
                            this.afrmLst_Rooms.afrmMain.ReloadData();
                        }
                    }
                    if(this.afrmMain !=null)
                    {
                        this.afrmMain.ReloadData();
                    }
  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Rooms.btnAddRoom_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmIns_Rooms_Load(object sender, EventArgs e)
        {

            try
            {
                lueRoomType.Properties.DataSource = CORE.CONSTANTS.ListRoomsTypes;//Load RoomsType 
                lueRoomType.Properties.DisplayMember = "Name";
                lueRoomType.Properties.ValueMember = "ID";
                lueRoomType.EditValue = CORE.CONSTANTS.SelectedRoomsType(1).ID;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Rooms.frmIns_Rooms_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}