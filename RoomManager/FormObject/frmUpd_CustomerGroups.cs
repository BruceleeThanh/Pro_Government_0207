using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

namespace RoomManager
{
    public partial class frmUpd_CustomerGroups : DevExpress.XtraEditors.XtraForm
    {
        private CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
        private frmLst_CustomerGroups afrmLst_CustomerGroups;
        private int IDCompany_Old;
        private int IDCustomerGroups_Old;

        public frmUpd_CustomerGroups(int IDCustomerGoup, int IDCompany, frmLst_CustomerGroups afrmLst_CustomerGroups)
        {
            InitializeComponent();
            this.afrmLst_CustomerGroups = afrmLst_CustomerGroups;
            this.IDCompany_Old = IDCompany;
            this.IDCustomerGroups_Old = IDCustomerGoup;
        }    

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtName.Text) == true)
                {
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CustomerGroups aCustomerGroups = new CustomerGroups();
                    aCustomerGroups.ID = IDCustomerGroups_Old;
                    aCustomerGroups.IDCompany = Convert.ToInt32(lueCompany.EditValue);
                    aCustomerGroups.Name = txtName.Text;
                    aCustomerGroups.Status = cboStatus.SelectedIndex + 1;
                    aCustomerGroups.Type = cboType.SelectedIndex + 1;
                    aCustomerGroups.Disable = bool.Parse(cboDisable.Text);
                    aCustomerGroupsBO.Update(aCustomerGroups);
                    this.afrmLst_CustomerGroups.ReloadData();
                    MessageBox.Show("Cập nhật dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEditCustomerGroup.btnUpdate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmUpd_CustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                lueCompany.Properties.DataSource = aCompaniesBO.Select_All();
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";

                CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(IDCustomerGroups_Old);
                lblIDCustomerGroup.Text = aCustomerGroups.ID.ToString();
                lueCompany.EditValue = aCustomerGroups.IDCompany;
                txtName.Text = aCustomerGroups.Name.ToString();
                cboType.SelectedIndex = Convert.ToInt32(aCustomerGroups.Type -1);
                cboStatus.SelectedIndex = Convert.ToInt32(aCustomerGroups.Status -1);
                cboDisable.Text = aCustomerGroups.Disable.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmEditCustomerGroup.frmEditCustomerGroup_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}