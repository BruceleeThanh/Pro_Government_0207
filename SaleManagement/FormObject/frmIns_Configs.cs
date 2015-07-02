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
using DataAccess;
using BussinessLogic;

namespace SaleManagement
{
    public partial class frmIns_Configs : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Configs afrmLst_Configs = null;
        private string AccessKey;
        public frmIns_Configs()
        {
            InitializeComponent();
        }

        public frmIns_Configs(frmLst_Configs afrmLst_Configs, string AccessKey)
        {
            InitializeComponent();
            this.afrmLst_Configs = afrmLst_Configs;
            this.AccessKey = AccessKey;
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string accessKey = txtAccessKey.Text;
                string value = txtValue.Text;
                if (accessKey.Length > 250)
                {
                    txtAccessKey.Focus();
                    MessageBox.Show("AccessKey chỉ được phép nhập tối đa 250 ký tự .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (value.Length > 250)
                {
                    txtValue.Focus();
                    MessageBox.Show("Giá trị chỉ được phép nhập tối đa 250 ký tự .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ConfigsBO aConfigBO = new ConfigsBO();
                    Configs aConfigs = new Configs();
                    aConfigs.AccessKey = accessKey;
                    aConfigs.Value = value;
                    aConfigs.Status = cboStatus.SelectedIndex + 1;
                    aConfigs.Type = cboType.SelectedIndex + 1;
                    aConfigs.Group = (cboGroup.SelectedIndex + 1).ToString();
                    aConfigBO.Insert(aConfigs);
                    MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    if(this.afrmLst_Configs !=null)
                    {
                        this.afrmLst_Configs.LoadDataConfigs(AccessKey);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Configs.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}