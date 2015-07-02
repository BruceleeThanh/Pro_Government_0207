using System;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.Utils;

namespace RoomManager
{
    public partial class frmLst_Services : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_Services()
        {
            InitializeComponent();
        }
      

        public void ReloadData()
        {
            try
            {
                ServicesBO aServicesBO = new ServicesBO();
                this.colPrice.DisplayFormat.FormatType = FormatType.Numeric;
                this.colPrice.DisplayFormat.FormatString = "{0:0,0}";
                dgvServices.DataSource = aServicesBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Services.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void frmServices_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Services.frmServices_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Services afrmAddService = new frmIns_Services(this);
                afrmAddService.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Services.bnAdd_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvService.GetFocusedRowCellValue("ID").ToString());
                frmUpd_Services afrmUpd_Services = new frmUpd_Services(this, ID);
                afrmUpd_Services.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Services.btnEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
            try
            {
                ServicesBO aServicesBO = new ServicesBO();
                int ID = int.Parse(grvService.GetFocusedRowCellValue("ID").ToString());
                string Name = aServicesBO.Select_ByID(ID).Name;
                DialogResult result = MessageBox.Show("Bạn có muốn xóa dịch vụ " + Name + " này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aServicesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ReloadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Services.btnDel_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}