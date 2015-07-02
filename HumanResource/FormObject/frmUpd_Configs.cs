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

namespace HumanResource
{
    public partial class frmUpd_Configs : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Configs afrmLst_Configs;
        private int ID;
        private string AccessKey;
        public frmUpd_Configs(frmLst_Configs afrmLst_Configs, int ID,string AccessKey)
        {
            InitializeComponent();
            this.afrmLst_Configs = afrmLst_Configs;
            this.ID = ID;
            this.AccessKey = AccessKey;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigsBO aConfigsBO = new ConfigsBO();
                Configs aConfigs = new Configs();
                aConfigs.ID = ID;
                aConfigs.AccessKey = txtAccessKey.Text;
                aConfigs.Value = txtValue.Text;
                aConfigs.Status = cboStatus.SelectedIndex + 1;
                aConfigs.Type = cboType.SelectedIndex + 1;
                aConfigs.Group =  (cboGroup.SelectedIndex + 1).ToString();
                aConfigsBO.Update(aConfigs);
                MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.afrmLst_Configs.LoadDataConfigs(AccessKey);
            }
            catch(Exception ex)
            {
                MessageBox.Show("frmUpd_Configs.btnSave_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUpd_Configs_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigsBO aConfigsBO = new ConfigsBO();
                Configs aConfigs = aConfigsBO.Select_ByID(ID);
                txtAccessKey.Text = aConfigs.AccessKey;
                txtValue.Text = aConfigs.Value;
                cboStatus.Text = aConfigs.Status.ToString();
                cboType.Text = aConfigs.Type.ToString();
                cboGroup.Text = aConfigs.Group.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Configs_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}