using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DataAccess;
using CORESYSTEM;
using System.IO;
using DevExpress.XtraEditors.Controls;


namespace SaleManagement
{
    public partial class frmUpd_Halls : DevExpress.XtraEditors.XtraForm
    {
        int IDHall;
        frmLst_Halls afrmLst_Halls;
        private HallsBO aHallsBO = new HallsBO();

        public frmUpd_Halls()
        {
            InitializeComponent();
        }
        public frmUpd_Halls(frmLst_Halls afrmLst_Halls, int IDHall)
        {
            InitializeComponent();
            this.IDHall = IDHall;
            this.afrmLst_Halls = afrmLst_Halls;
        }

        private void frmUpd_Halls_Load(object sender, EventArgs e)
        {
            try
            {
                Halls aHalls = aHallsBO.Select_ByID(this.IDHall);
                lueHallType.Properties.DataSource = CORE.CONSTANTS.ListHallTypes;
                lueHallType.Properties.DisplayMember = "Name";
                lueHallType.Properties.ValueMember = "ID";
                lueHallType.EditValue = aHalls.Type;
                lblID.Text = IDHall.ToString();
                txtCostRef.Text = aHalls.CostRef.ToString();
                txtInfo.Text = aHalls.Info;
                txtIntro.Text = aHalls.Intro;
                txtNumTableMax.Text = Convert.ToString(aHalls.NumTableMax);
                txtNumTableStandard.Text = Convert.ToString(aHalls.NumTableStandard);
                txtSku.Text = aHalls.Sku;
                cbbCostUnit.Text = aHalls.CostUnit;
                cbbDisable.Text = Convert.ToString(aHalls.Disable);
                cbbStatus.Text = Convert.ToString(aHalls.Status);
                if (aHalls.Image != null)
                {
                    if (aHalls.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(aHalls.Image);
                        Image returnImage = Image.FromStream(ms);
                        pbxImage.Image = returnImage;
                        pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Halls.frmUpd_Halls_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pbxImage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Chọn ảnh";
                op.Filter = "All files|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Stream aStreamImage = op.OpenFile();
                    pbxImage.Image = System.Drawing.Image.FromStream(aStreamImage);
                    pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Halls.pbxImage_DoubleClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateData()
        {
            if (txtSku.Text == "")
            {
                MessageBox.Show("Nhập mã hội trường trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNumTableStandard.Text == "")
            {
                MessageBox.Show("Nhập số bàn tiêu chuẩn trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNumTableMax.Text == "")
            {
                MessageBox.Show("Nhập số bàn tối đa trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtCostRef.Text == "")
            {
                MessageBox.Show("Nhập giá tham khảo trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cbbStatus.Text == "--- Chọn lựa ---")
            {
                MessageBox.Show("Chọn trạng thái hội trường !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Halls aHall = new Halls();
                if (ValidateData() == true)
                {
                    aHall.ID = this.IDHall;
                    aHall.Sku = txtSku.Text;
                    TimeSpan Codespan = new TimeSpan(DateTime.Now.Ticks);
                    aHall.Code = Math.Floor(Codespan.TotalSeconds).ToString();
                    aHall.CostRef = decimal.Parse(txtCostRef.Text);
                    aHall.CostUnit = cbbCostUnit.Text;
                    aHall.Disable = bool.Parse(cbbDisable.Text);
                    aHall.IDLang = 1;
                    aHall.Info = txtInfo.Text;
                    aHall.Intro = txtIntro.Text;
                    aHall.NumTableMax = int.Parse(txtNumTableMax.Text);
                    aHall.NumTableStandard = int.Parse(txtNumTableStandard.Text);
                    aHall.Image = (Byte[])new ImageConverter().ConvertTo(pbxImage.Image, typeof(Byte[]));
                    aHall.Type = Convert.ToInt32(lueHallType.EditValue);
                    aHall.Status = int.Parse(cbbStatus.Text);
                    aHallsBO.Update(aHall);
                    this.afrmLst_Halls.ReloadData();

                    MessageBox.Show("Sửa thông tin hội trường thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Halls.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


    }
}