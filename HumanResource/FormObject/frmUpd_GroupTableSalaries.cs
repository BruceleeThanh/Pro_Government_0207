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
    public partial class frmUpd_GroupTableSalaries : DevExpress.XtraEditors.XtraForm
    {

        int ID_Old;
       
        frmLst_GroupTableSalaries afrmLst_GroupTableSalaries_Old=null;
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
        public frmUpd_GroupTableSalaries(int ID, frmLst_GroupTableSalaries afrmLst_GroupTableSalaries)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_GroupTableSalaries_Old = afrmLst_GroupTableSalaries;
        }

        private void frmUpd_GroupTableSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByID(ID_Old);
                lblIDGroupTableSalaries.Text = ID_Old.ToString();
                if (aGroupTableSalaries.EndDate != null)
                {
                    dtpEndDate.DateTime = aGroupTableSalaries.EndDate.GetValueOrDefault();
                }

                if (aGroupTableSalaries.StartDate != null)
                {
                    dtpStartDate.DateTime = aGroupTableSalaries.StartDate.GetValueOrDefault();
                }
                txtName.Text = aGroupTableSalaries.Name;
                cbbType.Text = aGroupTableSalaries.Type.ToString();
                cbbStatus.Text = aGroupTableSalaries.Status.ToString();
                cbbDisable.Text = aGroupTableSalaries.Disable.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_GroupTableSalaries_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên bảng lương trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpEndDate.Text == "")
            {
                MessageBox.Show("Nhập ngày hết hiệu lực trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpStartDate.Text == "")
            {
                MessageBox.Show("Nhập ngày có hiệu lực trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (dtpStartDate.DateTime > dtpEndDate.DateTime)
                {
                    MessageBox.Show("Nhập ngày có hiệu lực phải nhỏ hơn ngày hết hiệu lực !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    DateTime? NullDateTime = null;
                    GroupTableSalaries aGroupTableSalaries = new GroupTableSalaries();
                    aGroupTableSalaries.ID = ID_Old;
                    aGroupTableSalaries.Name = txtName.Text;
                    aGroupTableSalaries.StartDate = dtpStartDate.EditValue == null ? NullDateTime : dtpStartDate.DateTime;
                    aGroupTableSalaries.EndDate = dtpEndDate.EditValue == null ? NullDateTime : dtpEndDate.DateTime;
                    aGroupTableSalaries.Type = int.Parse(cbbType.Text);
                    aGroupTableSalaries.Status = int.Parse(cbbStatus.Text);
                    aGroupTableSalaries.Disable = bool.Parse(cbbDisable.Text);
                    aGroupTableSalariesBO.Update(aGroupTableSalaries);
                    if (this.afrmLst_GroupTableSalaries_Old != null)
                    {
                        this.afrmLst_GroupTableSalaries_Old.Reload();
                    }
                  
                      

                    MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_GroupTableSalaries.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}