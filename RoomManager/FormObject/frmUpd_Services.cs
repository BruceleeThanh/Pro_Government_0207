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

namespace RoomManager
{
    public partial class frmUpd_Services : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Services afrmLst_Services =null;
        private int ID;

        public frmUpd_Services(frmLst_Services afrmLst_Services, int ID)
        {
            InitializeComponent();
            this.afrmLst_Services = afrmLst_Services;
            this.ID = ID;
        }

      

        private void frmUpd_Services_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                lueIDServiceGroup.Properties.DataSource = aServiceGroupsBO.Sel_all();
                lueIDServiceGroup.Properties.DisplayMember = "Name";
                lueIDServiceGroup.Properties.ValueMember = "ID";
                ServicesBO aServiceBO = new ServicesBO();
                Services aService = aServiceBO.Select_ByID(ID);
                lblIDService.Text = ID.ToString();
                txtName.Text = aService.Name;
                txtCost.Text = String.Format("{0:0,0}",aService.CostRef);
                cboDisable.Text = aService.Disable.ToString();
                cboStatus.SelectedIndex = Convert.ToInt32(aService.Status - 1);
                cboType.SelectedIndex = Convert.ToInt32(aService.Type - 1);
                txtUnit.Text = aService.Unit;
                lueIDServiceGroup.EditValue = aService.IDServiceGroups;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Services.frmUpd_Services_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSerGroup_Click(object sender, EventArgs e)
        {
            frmIns_ServiceGroups frmAddSG = new frmIns_ServiceGroups();
            frmAddSG.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ServicesBO aServiceBO = new ServicesBO();
                Services aService = aServiceBO.Select_ByID(ID);
                aService.Name = txtName.Text;
                aService.CostRef = decimal.Parse(txtCost.Text);
                aService.Unit = txtUnit.Text.ToString();
                aService.Status = cboStatus.SelectedIndex + 1;
                aService.Type = cboType.SelectedIndex + 1;
                aService.Disable = bool.Parse(cboDisable.Text);
                aService.IDServiceGroups = int.Parse(lueIDServiceGroup.EditValue.ToString());
                aServiceBO.Update(aService);
                MessageBox.Show("Cập nhật dữ liệu thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.afrmLst_Services.ReloadData();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Services.btnEdit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}