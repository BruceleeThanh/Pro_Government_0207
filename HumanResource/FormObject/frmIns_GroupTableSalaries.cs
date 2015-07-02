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
    public partial class frmIns_GroupTableSalaries : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_GroupTableSalaries afrmLst_GroupTableSalaries_Old=null;
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();

        public frmIns_GroupTableSalaries()
        {
            InitializeComponent();
        }
        public frmIns_GroupTableSalaries(frmLst_GroupTableSalaries afrmLst_GroupTableSalaries)
        {
            InitializeComponent();
            afrmLst_GroupTableSalaries_Old = afrmLst_GroupTableSalaries;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên bảng lương trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpEndDate.Text == "")
            {
                MessageBox.Show("Nhập ngày kết thúc trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpStartDate.Text == "")
            {
                MessageBox.Show("Nhập ngày bắt đầu trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (dtpStartDate.DateTime > dtpEndDate.DateTime)
                {
                    MessageBox.Show("Nhập ngày bắt đầu phải nhỏ hơn ngày kết thúc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateData() == true)
                {
                    DateTime? NullDateTime = null;
                    // Disable bảng lương cũ
                    GroupTableSalaries aGroupTableSalaries_Old = new GroupTableSalaries();
                    aGroupTableSalaries_Old = aGroupTableSalariesBO.Select_ByDisable();
                    aGroupTableSalaries_Old.Disable = true;
                    aGroupTableSalariesBO.Update(aGroupTableSalaries_Old);
                    // Tạo bảng lương mới
                    GroupTableSalaries aGroupTableSalaries = new GroupTableSalaries();
                    aGroupTableSalaries.Name = txtName.Text;
                    aGroupTableSalaries.StartDate = dtpStartDate.EditValue == null ? NullDateTime : dtpStartDate.DateTime;
                    aGroupTableSalaries.EndDate = dtpEndDate.EditValue == null ? NullDateTime : dtpEndDate.DateTime;

                    aGroupTableSalaries.Disable = bool.Parse(cbbDisable.Text);
                    if (cbbStatus.Text == null)
                    {
                        MessageBox.Show("Vui lòng chọn Trạng thái", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        aGroupTableSalaries.Status = int.Parse(cbbStatus.Text);
                    }
                    if (cbbType.Text == null)
                    {
                        MessageBox.Show("Vui lòng chọn Loại", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        aGroupTableSalaries.Type = int.Parse(cbbType.Text);
                    }
                    aGroupTableSalariesBO.Insert(aGroupTableSalaries);
                    if (this.afrmLst_GroupTableSalaries_Old != null)
                    {
                        this.afrmLst_GroupTableSalaries_Old.Reload();
                    }
                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_GroupTableSalaries.btnAddNew_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}