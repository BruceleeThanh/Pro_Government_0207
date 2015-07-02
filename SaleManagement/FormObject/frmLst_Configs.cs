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
namespace SaleManagement
{
    public partial class frmLst_Configs : DevExpress.XtraEditors.XtraForm
    {
        private string AccessKey = "";
        public frmLst_Configs()
        {
            InitializeComponent();
        }

        public void LoadDataConfigs(string AccessKey)
        {
            try
            {
                ConfigsBO aConfigBO = new ConfigsBO();
                List<Configs> aListConfigs = new List<Configs>();

                if (AccessKey == null)
                {
                    aListConfigs = aConfigBO.Select_All();
                }
                else
                {
                    aListConfigs = aConfigBO.SearchListConfigs_ByAccessKey(AccessKey);
                }
                dgvConfigs.DataSource = aListConfigs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Configs.LoadDataConfigs\n" + ex.ToString());
            }
        }

        private void frmLst_Configs_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataConfigs(AccessKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Configs.frmLst_Configs_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string AccessKey = txtAccesskey.Text;
                LoadDataConfigs(AccessKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Configs.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            int ID = Convert.ToInt32(viewConfigs.GetFocusedRowCellValue("ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    ConfigsBO aConfigsBO = new ConfigsBO();
                    aConfigsBO.Delete(ID);
                    MessageBox.Show("Bạn đã xóa dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_Configs.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadDataConfigs(AccessKey);

        }
        private void btnUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewConfigs.GetFocusedRowCellValue("ID"));
                frmUpd_Configs afrmUpd_Configs = new frmUpd_Configs(this, ID, AccessKey);
                afrmUpd_Configs.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Configs.btnUpdate_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Configs afrmIns_Configs = new frmIns_Configs(this,AccessKey);
                afrmIns_Configs.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Configs.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}