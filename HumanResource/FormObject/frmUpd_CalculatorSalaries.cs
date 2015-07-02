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
    public partial class frmUpd_CalculatorSalaries : DevExpress.XtraEditors.XtraForm
    {
        TableSalariesBO aTableSalariesBO = new TableSalariesBO();
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        CalculatorSalariesBO aCalculatorSalariesBO = new CalculatorSalariesBO();
        frmLst_CalculatorSalaries afrmLst_CalculatorSalaries_Old = null;
        int ID_Old;
        public frmUpd_CalculatorSalaries(int ID, frmLst_CalculatorSalaries afrmLst_CalculatorSalaries)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_CalculatorSalaries_Old = afrmLst_CalculatorSalaries;
        }

        private void frmUpd_CalculatorSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                CalculatorSalaries aCalculatorSalaries = aCalculatorSalariesBO.Select_ByID(ID_Old);
                lueIDSystemUser.Properties.DataSource = aSystemUsersBO.Select_All();
                lueIDSystemUser.Properties.DisplayMember = "Name";
                lueIDSystemUser.Properties.ValueMember = "ID";

                if (aCalculatorSalaries !=null)
                {
                    lueIDSystemUser.EditValue = aCalculatorSalaries.IDSystemUser;
                    lueSku.EditValue = aCalculatorSalaries.SkuTableSalary;
                    lueCoefficent.EditValue = aCalculatorSalaries.Coefficent;
                    if (aCalculatorSalaries.StartDate != null)
                    {
                        dtpStartDate.DateTime = aCalculatorSalaries.StartDate.GetValueOrDefault();
                    }
                    if (aCalculatorSalaries.EndDate != null)
                    {
                        dtpEndDate.DateTime = aCalculatorSalaries.EndDate.GetValueOrDefault();
                    }
                }

                lblID.Text = Convert.ToString(ID_Old);
                GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByDisable();
                if (aGroupTableSalaries != null)
                {
                    List<TableSalaries> aList = aTableSalariesBO.Select_ByIDGroupTableSalaries(aGroupTableSalaries.ID);
                    lueSku.Properties.DataSource = aList;
                    lueSku.Properties.DisplayMember = "Name";
                    lueSku.Properties.ValueMember = "Sku";
                }

                

                cbbType.SelectedIndex = Convert.ToInt32(aCalculatorSalaries.Type);
                cbbStatus.SelectedIndex = Convert.ToInt32(aCalculatorSalaries.Status);
                cbbDisable.Text = Convert.ToString(aCalculatorSalaries.Disable);

                string Sku = Convert.ToString(lueSku.EditValue);
                TableSalaries aTableSalaries = aTableSalariesBO.Select_BySku(Sku);
                if (aTableSalaries !=null)
                {
                    List<double> aListCoe = ConvertCoe(aTableSalaries);
                    lueCoefficent.Properties.DataSource = aListCoe;
                }
  
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_CalculatorSalaries_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private bool ValidateData()
        {
            if (lueCoefficent.EditValue == null)
            {
                MessageBox.Show("Chọn Hệ số lương trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpEndDate.Text == "")
            {
                MessageBox.Show("Nhập ngày kết thúc trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpStartDate.Text == "")
            {
                MessageBox.Show("Nhập ngày bắt đầu trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    CalculatorSalaries aCalculatorSalaries = new CalculatorSalaries();
                    DateTime? NullDatetime = null;

                    aCalculatorSalaries.ID = ID_Old;
                    aCalculatorSalaries.IDSystemUser = Convert.ToInt32(lueIDSystemUser.EditValue);
                    aCalculatorSalaries.SkuTableSalary = Convert.ToString(lueSku.EditValue);

                    aCalculatorSalaries.Coefficent = Convert.ToDouble(lueCoefficent.EditValue);
                    aCalculatorSalaries.StartDate = dtpStartDate.EditValue == null ? NullDatetime : dtpStartDate.DateTime;
                    aCalculatorSalaries.EndDate = dtpEndDate.EditValue == null ? NullDatetime : dtpEndDate.DateTime;
                    

                    aCalculatorSalaries.Type =cbbType.SelectedIndex;
                    aCalculatorSalaries.Status =cbbStatus.SelectedIndex;
                    aCalculatorSalaries.Disable = bool.Parse(cbbDisable.Text);


                    aCalculatorSalariesBO.Update(aCalculatorSalaries);

                    if (this.afrmLst_CalculatorSalaries_Old != null)
                    {
                        this.afrmLst_CalculatorSalaries_Old.Reload();
                    }

                    MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_CalculatorSalaries.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private List<double> ConvertCoe(TableSalaries aTableSalaries)
        {
            try
            {
                List<double> ret = new List<double>();
                ret.Insert(0, aTableSalaries.Coe1.GetValueOrDefault(0));
                ret.Insert(1, aTableSalaries.Coe2.GetValueOrDefault(0));
                ret.Insert(2, aTableSalaries.Coe3.GetValueOrDefault(0));
                ret.Insert(3, aTableSalaries.Coe4.GetValueOrDefault(0));
                ret.Insert(4, aTableSalaries.Coe5.GetValueOrDefault(0));
                ret.Insert(5, aTableSalaries.Coe6.GetValueOrDefault(0));
                ret.Insert(6, aTableSalaries.Coe7.GetValueOrDefault(0));
                ret.Insert(7, aTableSalaries.Coe8.GetValueOrDefault(0));
                ret.Insert(8, aTableSalaries.Coe9.GetValueOrDefault(0));
                ret.Insert(9, aTableSalaries.Coe10.GetValueOrDefault(0));
                ret.Insert(10, aTableSalaries.Coe11.GetValueOrDefault(0));
                ret.Insert(11, aTableSalaries.Coe12.GetValueOrDefault(0));
                ret.Insert(12, aTableSalaries.Coe13.GetValueOrDefault(0));
                ret.Insert(13, aTableSalaries.Coe14.GetValueOrDefault(0));
                ret.Insert(14, aTableSalaries.Coe15.GetValueOrDefault(0));
                ret.Insert(15, aTableSalaries.Coe16.GetValueOrDefault(0));
                return ret;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_CalculatorSalaries.ConvertCoe\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

}