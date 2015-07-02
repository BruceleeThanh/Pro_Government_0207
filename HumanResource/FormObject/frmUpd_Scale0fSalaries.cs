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

namespace HumanResource
{
    public partial class frmUpd_Scale0fSalaries : DevExpress.XtraEditors.XtraForm
    {
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
        TableSalariesBO aTableSalariesBO = new TableSalariesBO();
        frmLst_TableSalaries afrmLst_TableSalaries_Old=null;
        int ID_Old;

        public frmUpd_Scale0fSalaries(int ID, frmLst_TableSalaries afrmLst_TableSalaries)
        {
            InitializeComponent();
            ID_Old = ID;
          this.afrmLst_TableSalaries_Old = afrmLst_TableSalaries;
        }

        private void frmUpd_Scale0fSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByDisable();
                if (aGroupTableSalaries != null)
                {
                    lblIDGroup.Text = Convert.ToString(aGroupTableSalaries.ID);
                }



                TableSalaries aTableSalaries = aTableSalariesBO.Select_ByID(ID_Old);
                lblID.Text = ID_Old.ToString();
                txtName.Text = aTableSalaries.Name;
                txtNumCoefficents.Text = aTableSalaries.NumCoefficents.ToString();
                txtSku.Text = aTableSalaries.Sku;
                txtCoe1.Text = aTableSalaries.Coe1.ToString();
                txtCoe2.Text = aTableSalaries.Coe2.ToString();
                txtCoe3.Text = aTableSalaries.Coe3.ToString();
                txtCoe4.Text = aTableSalaries.Coe4.ToString();
                txtCoe5.Text = aTableSalaries.Coe5.ToString();
                txtCoe6.Text = aTableSalaries.Coe6.ToString();
                txtCoe7.Text = aTableSalaries.Coe7.ToString();
                txtCoe8.Text = aTableSalaries.Coe8.ToString();
                txtCoe9.Text = aTableSalaries.Coe9.ToString();
                txtCoe10.Text = aTableSalaries.Coe10.ToString();
                txtCoe11.Text = aTableSalaries.Coe11.ToString();
                txtCoe12.Text = aTableSalaries.Coe12.ToString();
                txtCoe13.Text = aTableSalaries.Coe13.ToString();
                txtCoe14.Text = aTableSalaries.Coe14.ToString();
                txtCoe15.Text = aTableSalaries.Coe15.ToString();
                txtCoe16.Text = aTableSalaries.Coe16.ToString();
                txtJump1.Text = aTableSalaries.Jump1.ToString();
                txtJump2.Text = aTableSalaries.Jump2.ToString();
                txtJump3.Text = aTableSalaries.Jump3.ToString();
                txtJump4.Text = aTableSalaries.Jump4.ToString();
                txtJump5.Text = aTableSalaries.Jump5.ToString();
                txtJump6.Text = aTableSalaries.Jump6.ToString();
                txtJump7.Text = aTableSalaries.Jump7.ToString();
                txtJump8.Text = aTableSalaries.Jump8.ToString();
                txtJump9.Text = aTableSalaries.Jump9.ToString();
                txtJump10.Text = aTableSalaries.Jump10.ToString();
                txtJump11.Text = aTableSalaries.Jump11.ToString();
                txtJump12.Text = aTableSalaries.Jump12.ToString();
                txtJump13.Text = aTableSalaries.Jump13.ToString();
                txtJump14.Text = aTableSalaries.Jump14.ToString();
                txtJump15.Text = aTableSalaries.Jump15.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Scale0fSalaries_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên ngạch lương trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtSku.Text == "")
            {
                MessageBox.Show("Nhập mã ngạch lương trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtNumCoefficents.Text == "")
            {
                MessageBox.Show("Nhập bậc cao nhất của ngạch lương trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    TableSalaries aTableSalaries = new TableSalaries();
                    aTableSalaries.ID = Convert.ToInt32(lblID.Text);
                    aTableSalaries.IDGroupTableSalary = Convert.ToInt32(lblIDGroup.Text);
                    aTableSalaries.Name = txtName.Text;
                    aTableSalaries.NumCoefficents = Convert.ToInt32(txtNumCoefficents.Text);
                    aTableSalaries.Sku = txtSku.Text;
                    aTableSalaries.Coe1 = string.IsNullOrEmpty(txtCoe1.Text) ? 0 : Convert.ToDouble(txtCoe1.Text);
                    aTableSalaries.Coe2 = string.IsNullOrEmpty(txtCoe2.Text) ? 0 : Convert.ToDouble(txtCoe2.Text);
                    aTableSalaries.Coe3 = string.IsNullOrEmpty(txtCoe3.Text) ? 0 : Convert.ToDouble(txtCoe3.Text);
                    aTableSalaries.Coe4 = string.IsNullOrEmpty(txtCoe4.Text) ? 0 : Convert.ToDouble(txtCoe4.Text);
                    aTableSalaries.Coe5 = string.IsNullOrEmpty(txtCoe5.Text) ? 0 : Convert.ToDouble(txtCoe5.Text);
                    aTableSalaries.Coe6 = string.IsNullOrEmpty(txtCoe6.Text) ? 0 : Convert.ToDouble(txtCoe6.Text);
                    aTableSalaries.Coe7 = string.IsNullOrEmpty(txtCoe7.Text) ? 0 : Convert.ToDouble(txtCoe7.Text);
                    aTableSalaries.Coe8 = string.IsNullOrEmpty(txtCoe8.Text) ? 0 : Convert.ToDouble(txtCoe8.Text);
                    aTableSalaries.Coe9 = string.IsNullOrEmpty(txtCoe9.Text) ? 0 : Convert.ToDouble(txtCoe9.Text);
                    aTableSalaries.Coe10 = string.IsNullOrEmpty(txtCoe10.Text) ? 0 : Convert.ToDouble(txtCoe10.Text);
                    aTableSalaries.Coe11 = string.IsNullOrEmpty(txtCoe11.Text) ? 0 : Convert.ToDouble(txtCoe11.Text);
                    aTableSalaries.Coe12 = string.IsNullOrEmpty(txtCoe12.Text) ? 0 : Convert.ToDouble(txtCoe12.Text);
                    aTableSalaries.Coe13 = string.IsNullOrEmpty(txtCoe13.Text) ? 0 : Convert.ToDouble(txtCoe13.Text);
                    aTableSalaries.Coe14 = string.IsNullOrEmpty(txtCoe14.Text) ? 0 : Convert.ToDouble(txtCoe14.Text);
                    aTableSalaries.Coe15 = string.IsNullOrEmpty(txtCoe15.Text) ? 0 : Convert.ToDouble(txtCoe15.Text);
                    aTableSalaries.Coe16 = string.IsNullOrEmpty(txtCoe16.Text) ? 0 : Convert.ToDouble(txtCoe16.Text);
                    aTableSalaries.Jump1 = string.IsNullOrEmpty(txtJump1.Text) ? 0 : Convert.ToInt32(txtJump1.Text);
                    aTableSalaries.Jump2 = string.IsNullOrEmpty(txtJump2.Text) ? 0 : Convert.ToInt32(txtJump2.Text);
                    aTableSalaries.Jump3 = string.IsNullOrEmpty(txtJump3.Text) ? 0 : Convert.ToInt32(txtJump3.Text);
                    aTableSalaries.Jump4 = string.IsNullOrEmpty(txtJump4.Text) ? 0 : Convert.ToInt32(txtJump4.Text);
                    aTableSalaries.Jump5 = string.IsNullOrEmpty(txtJump5.Text) ? 0 : Convert.ToInt32(txtJump5.Text);
                    aTableSalaries.Jump6 = string.IsNullOrEmpty(txtJump6.Text) ? 0 : Convert.ToInt32(txtJump6.Text);
                    aTableSalaries.Jump7 = string.IsNullOrEmpty(txtJump7.Text) ? 0 : Convert.ToInt32(txtJump7.Text);
                    aTableSalaries.Jump8 = string.IsNullOrEmpty(txtJump8.Text) ? 0 : Convert.ToInt32(txtJump8.Text);
                    aTableSalaries.Jump9 = string.IsNullOrEmpty(txtJump9.Text) ? 0 : Convert.ToInt32(txtJump9.Text);
                    aTableSalaries.Jump10 = string.IsNullOrEmpty(txtJump10.Text) ? 0 : Convert.ToInt32(txtJump10.Text);
                    aTableSalaries.Jump11 = string.IsNullOrEmpty(txtJump11.Text) ? 0 : Convert.ToInt32(txtJump11.Text);
                    aTableSalaries.Jump12 = string.IsNullOrEmpty(txtJump12.Text) ? 0 : Convert.ToInt32(txtJump12.Text);
                    aTableSalaries.Jump13 = string.IsNullOrEmpty(txtJump13.Text) ? 0 : Convert.ToInt32(txtJump13.Text);
                    aTableSalaries.Jump14 = string.IsNullOrEmpty(txtJump14.Text) ? 0 : Convert.ToInt32(txtJump14.Text);
                    aTableSalaries.Jump15 = string.IsNullOrEmpty(txtJump15.Text) ? 0 : Convert.ToInt32(txtJump15.Text);
                    aTableSalariesBO.Update(aTableSalaries);
                    if (this.afrmLst_TableSalaries_Old != null)
                    {
                        this.afrmLst_TableSalaries_Old.Reload();
                    }
                   
                    MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Scale0fSalaries.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    
    }
}