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
    public partial class frmIns_TableSalaries : DevExpress.XtraEditors.XtraForm
    {
        
        
        private frmLst_TableSalaries afrmLst_TableSalaries_Old =null;

        public frmIns_TableSalaries()
        {
            InitializeComponent();
        }
        public frmIns_TableSalaries(frmLst_TableSalaries afrmLst_TableSalaries)
        {
            InitializeComponent();
            afrmLst_TableSalaries_Old = afrmLst_TableSalaries;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên bảng lương mới trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpEndDate.Text == "")
            {
                MessageBox.Show("Nhập ngày hết hiệu lực trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpStartDate.Text == "")
            {
                MessageBox.Show("Nhập ngày có hiệu lực trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                TableSalariesBO aTableSalariesBO = new TableSalariesBO();
                GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
                if (ValidateData() == true)
                {
                    DateTime? NullDatetime = null;
                    // Disable Nhóm bảng lương cũ
                     GroupTableSalaries aGroupTableSalaries_Old = aGroupTableSalariesBO.Select_ByDisable();
                    if( aGroupTableSalaries_Old != null)
                    {
                        aGroupTableSalaries_Old.Disable = true;
                        aGroupTableSalaries_Old.EndDate = DateTime.Now;
                        aGroupTableSalariesBO.Update(aGroupTableSalaries_Old);
                    }
                    // Thêm Nhóm bảng lương mới
                    GroupTableSalaries aGroupTableSalaries_New = new GroupTableSalaries();
                    aGroupTableSalaries_New.Name = txtName.Text;
                    aGroupTableSalaries_New.EndDate = dtpEndDate.EditValue == null ? NullDatetime : dtpEndDate.DateTime;
                    aGroupTableSalaries_New.StartDate = dtpStartDate.EditValue == null ? NullDatetime : dtpStartDate.DateTime;
                    aGroupTableSalaries_New.Type = 1;
                    aGroupTableSalaries_New.Status = 1;
                    aGroupTableSalaries_New.Disable = false;
                    aGroupTableSalariesBO.Insert(aGroupTableSalaries_New);                 

                       
                    // Thêm bảng lương vào nhóm bảng lương mới
                        TableSalaries aTableSalaries;
                        for (int i = 0; i < grvTableSalaries.RowCount; i++)
                        {
                            aTableSalaries = new TableSalaries();
                            aTableSalaries.IDGroupTableSalary = aGroupTableSalaries_New.ID;
                            aTableSalaries.Name = grvTableSalaries.GetRowCellValue(i, "Name").ToString();
                            aTableSalaries.NumCoefficents = Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "NumCoefficents"));
                            aTableSalaries.Sku = grvTableSalaries.GetRowCellValue(i, "Sku").ToString();

                            aTableSalaries.Coe1 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe1").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe1"));
                            aTableSalaries.Coe2 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe2").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe2"));
                            aTableSalaries.Coe3 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe3").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe3"));
                            aTableSalaries.Coe4 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe4").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe4"));
                            aTableSalaries.Coe5 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe5").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe5"));
                            aTableSalaries.Coe6 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe6").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe6"));
                            aTableSalaries.Coe7 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe7").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe7"));
                            aTableSalaries.Coe8 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe8").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe8"));
                            aTableSalaries.Coe9 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe9").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe9"));
                            aTableSalaries.Coe10 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe10").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe10"));
                            aTableSalaries.Coe11 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe11").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe11"));
                            aTableSalaries.Coe12 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe12").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe12"));
                            aTableSalaries.Coe13 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe13").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe13"));
                            aTableSalaries.Coe14 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe14").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe14"));
                            aTableSalaries.Coe15 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe15").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe15"));
                            aTableSalaries.Coe16 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Coe16").ToString()) ? 0 : Convert.ToDouble(grvTableSalaries.GetRowCellValue(i, "Coe16"));
                            aTableSalaries.Jump1 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump1").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump1"));
                            aTableSalaries.Jump2 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump2").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump2"));
                            aTableSalaries.Jump3 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump3").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump3"));
                            aTableSalaries.Jump4 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump4").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump4"));
                            aTableSalaries.Jump5 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump5").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump5"));
                            aTableSalaries.Jump6 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump6").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump6"));
                            aTableSalaries.Jump7 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump7").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump7"));
                            aTableSalaries.Jump8 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump8").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump8"));
                            aTableSalaries.Jump9 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump9").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump9"));
                            aTableSalaries.Jump10 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump10").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump10"));
                            aTableSalaries.Jump11 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump11").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump11"));
                            aTableSalaries.Jump12 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump12").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump12"));
                            aTableSalaries.Jump13 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump13").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump13"));
                            aTableSalaries.Jump14 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump14").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump14"));
                            aTableSalaries.Jump15 = string.IsNullOrEmpty(grvTableSalaries.GetRowCellValue(i, "Jump15").ToString()) ? 0 : Convert.ToInt32(grvTableSalaries.GetRowCellValue(i, "Jump15"));
                            aTableSalariesBO.Insert(aTableSalaries);
                        }
                        if (this.afrmLst_TableSalaries_Old != null)
                        {
                            this.afrmLst_TableSalaries_Old.Reload();
                        }
                        MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_TableSalaries.btnAdd_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmIns_TableSalaries_Load(object sender, EventArgs e)
        {
            TableSalariesBO aTableSalariesBO = new TableSalariesBO();
            GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
            GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByDisable();
            if (aGroupTableSalaries !=null)
            {
                List<TableSalaries> aList = aTableSalariesBO.Select_ByIDGroupTableSalaries(aGroupTableSalaries.ID);
                dgvTableSalaries.DataSource = aList;
                dgvTableSalaries.RefreshDataSource();
                dtpEndDate.DateTime = aGroupTableSalaries.EndDate.Value;

                //dtpEndDate.Text = Convert.ToDateTime(dtpEndDate.Text).AddYears(10).ToString();
            }
           
        }
    }

}