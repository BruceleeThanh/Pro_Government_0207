using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using CORESYSTEM;


namespace SaleManagement
{
    public partial class frmUpd_Companies : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Companies afrmLst_Companies_Old;
        private int IDCompany_Old;
        private CompaniesBO aCompanyBO = new CompaniesBO();
        public frmUpd_Companies(int ID,frmLst_Companies frmCom)
        {
            InitializeComponent();
            afrmLst_Companies_Old = frmCom;
            IDCompany_Old = ID;
        }


        private void frmEditCompany_Load(object sender, EventArgs e)
        {
            try
            {
                Companies aCompany = aCompanyBO.Select_ByID(IDCompany_Old);
                lueType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes; // Load Type
                lueType.Properties.DisplayMember = "Name";
                lueType.Properties.ValueMember = "ID";
                lueType.EditValue = aCompany.Type;

                
                lblIDCompany.Text = aCompany.ID.ToString();
                lueType.EditValue = aCompany.Type;
                txtName.Text = aCompany.Name.ToString();
                cboDisable.Text = aCompany.Disable.ToString();
                cboStatus.Text = aCompany.Status.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Companies.frmEditCompany_Load\n" + ex.ToString(),"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên công ty trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("Chọn trạng thái trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    Companies aCompany = new Companies();
                    aCompany.ID = IDCompany_Old;
                    aCompany.Name = txtName.Text;
                    aCompany.Status = int.Parse(cboStatus.Text);
                    aCompany.Type = Convert.ToInt32(lueType.EditValue);
                    aCompany.Disable = bool.Parse(cboDisable.Text);
                    aCompanyBO.Update(aCompany);
                    this.afrmLst_Companies_Old.ReloadData();
                    MessageBox.Show("Sửa tổ chức thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Companies.btnUpdate_Click\n " + ex.ToString(),"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



    }
}