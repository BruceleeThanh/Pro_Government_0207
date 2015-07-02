using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using DevExpress.XtraEditors.Controls;

namespace SaleManagement
{
    public partial class frmIns_Services : DevExpress.XtraEditors.XtraForm
    {

        private frmLst_Services afrmLst_Services = null;
        private frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = null;
        ServicesBO aServiceBO = new ServicesBO();
        ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();

        public frmIns_Services()
        {
            InitializeComponent();
        }
        public frmIns_Services(frmLst_Services afrmLst_Services)
        {
            InitializeComponent();
            this.afrmLst_Services = afrmLst_Services;
        }
        public frmIns_Services(frmIns_BookingHalls_Services afrmIns_BookingHalls_Services)
        {
            InitializeComponent();
            this.afrmIns_BookingHalls_Services = afrmIns_BookingHalls_Services;
        }

        private void frmAddServices_Load(object sender, EventArgs e)
        {
            try
            {
                this.Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.frmAddServices_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên dịch vụ trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtCost.Text == "")
            {
                MessageBox.Show("Nhập giá dịch vụ trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtUnit.Text == "")
            {
                MessageBox.Show("Nhập đơn vị tính trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }           
            return true;
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    Services aService = new Services();
                    aService.Name = txtName.Text;
                    aService.CostRef = string.IsNullOrEmpty(txtCost.Text) == true ? 0 : Convert.ToDecimal(txtCost.Text);
                    aService.Unit = txtUnit.Text;
                    aService.Status = cboStatus.SelectedIndex + 1;
                    if (cboType.Text == "Tiệc")
                    {
                        aService.Type = 1;
                    }
                    else
                    {
                        aService.Type = 2;
                    }
                    aService.Disable = bool.Parse(cboDisable.Text);
                    aService.IDServiceGroups = Convert.ToInt32(lueIDServiceGroup.EditValue);

                    aServiceBO.Insert(aService);

                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.afrmLst_Services != null)
                    {
                        this.afrmLst_Services.ReloadData();
                    }
                    else if (this.afrmIns_BookingHalls_Services != null)
                    {
                        this.afrmIns_BookingHalls_Services.Reload();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.bnAdd_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnAddSerGroup_Click(object sender, EventArgs e)
        {
            frmIns_ServiceGroups afrmIns_ServiceGroups = new frmIns_ServiceGroups();
            afrmIns_ServiceGroups.ShowDialog();
        }

        public void Reload()
        {
            try
            {

                List<ServiceGroups> aListServiceGroups = aServiceGroupsBO.Sel_all();
                lueIDServiceGroup.Properties.DataSource = aListServiceGroups;
                lueIDServiceGroup.Properties.DisplayMember = "Name";
                lueIDServiceGroup.Properties.ValueMember = "ID";
                lueIDServiceGroup.EditValue = aListServiceGroups[0].ID;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.Reload \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}