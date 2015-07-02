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
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace RoomManager
{
    public partial class frmIns_Halls : DevExpress.XtraEditors.XtraForm
    {
        frmLst_Halls afrmLst_Halls = null ;
        frmMain afrmMain = null;
        public frmIns_Halls()
        {
            InitializeComponent();
        }
        public frmIns_Halls(frmLst_Halls afrmLst_Halls)
        {
            InitializeComponent();
            this.afrmLst_Halls = afrmLst_Halls;
        }
        public frmIns_Halls(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        //private readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HallsBO aHallsBO = new HallsBO();
        private void CreateNewHall_Load(object sender, EventArgs e)
        {
            lueHallType.Properties.DataSource = CORE.CONSTANTS.ListHallTypes;
            lueHallType.Properties.DisplayMember = "Name";
            lueHallType.Properties.ValueMember = "ID";
            lueHallType.EditValue = CORE.CONSTANTS.SelectedHallType(1).ID;
        }

        private bool ValidateData()
        {
            if (txtSku.Text == "")
            {
                MessageBox.Show("Nhập mã hội trường trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNumTableStandard.Text == "")
            {
                MessageBox.Show("Nhập số bàn tiêu chuẩn trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNumTableMax.Text == "")
            {
                MessageBox.Show("Nhập số bàn tối đa trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtCostRef.Text == "")
            {
                MessageBox.Show("Nhập giá tham khảo trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cbbStatus.Text == "--- Chọn lựa ---")
            {
                MessageBox.Show("Chọn trạng thái hội trường !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Halls aHall = new Halls();
                if (ValidateData() == true)
                {
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
                    aHallsBO.Insert(aHall);

                    if (afrmLst_Halls != null)
                    {
                        this.afrmLst_Halls.ReloadData();
                    }
                    MessageBox.Show("Thêm mới hội trường thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Halls.btnAdd_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("frmIns_Halls.pbxImage_DoubleClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    

    }
}