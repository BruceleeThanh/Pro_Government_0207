using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmUpd_Companies : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Companies afrmLst_Companies_Old =null;
        private int IDCompany_Old =0;
        private CompaniesBO aCompanyBO = new CompaniesBO();
        public frmUpd_Companies(int ID, frmLst_Companies frmCom)
        {
            InitializeComponent();
            afrmLst_Companies_Old = frmCom;
            IDCompany_Old = ID;
        }

        //Hiennv
        private void frmEditCompany_Load(object sender, EventArgs e)
        {
            try
            {
                lueCustomerType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes; // Load Type
                lueCustomerType.Properties.DisplayMember = "Name";
                lueCustomerType.Properties.ValueMember = "ID";

                Companies aCompany = aCompanyBO.Select_ByID(IDCompany_Old);
                if (aCompany != null)
                {
                    lueCustomerType.EditValue = aCompany.Type;
                    txtName.Text = Convert.ToString(aCompany.Name);
                    txtTaxNumberCode.Text = Convert.ToString(aCompany.TaxNumberCode);
                    txtAddress.Text = Convert.ToString(aCompany.Address);
                    cboDisable.Text = Convert.ToString(aCompany.Disable);
                    cboStatus.Text = Convert.ToString(aCompany.Status);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Companies.frmEditCompany_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Companies aCompany = new Companies();
                aCompany.ID = this.IDCompany_Old;
                aCompany.Name = txtName.Text;
                aCompany.TaxNumberCode = txtTaxNumberCode.Text;
                aCompany.Address = txtAddress.Text;
                aCompany.Status =Convert.ToInt32(cboStatus.Text);
                aCompany.Type = Convert.ToInt32(lueCustomerType.EditValue);
                aCompany.Disable =Convert.ToBoolean(cboDisable.Text);
                aCompanyBO.Update(aCompany);
                if (this.afrmLst_Companies_Old !=null)
                {
                    this.afrmLst_Companies_Old.ReloadData();
                }
                MessageBox.Show("Sửa tổ chức thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Companies.btnUpdate_Click\n " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}