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
using Entity;

namespace HumanResource
{
    public partial class frmIns_CalculatorSalaries : DevExpress.XtraEditors.XtraForm
    {
        TableSalariesBO aTableSalariesBO = new TableSalariesBO();
        GroupTableSalariesBO aGroupTableSalariesBO = new GroupTableSalariesBO();
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        CalculatorSalariesBO aCalculatorSalariesBO = new CalculatorSalariesBO();
        private frmLst_CalculatorSalaries afrmLst_CalculatorSalaries_Old = null;
        frmMain afrmMain = null;
        int IDSystemUser = -1;

        public frmIns_CalculatorSalaries()
        {
            InitializeComponent();
        }
        public frmIns_CalculatorSalaries(int IDSystemUser, frmMain afrmMain)
        {
            InitializeComponent();
            this.IDSystemUser = IDSystemUser;
            this.afrmMain = afrmMain;
        }
        public frmIns_CalculatorSalaries(frmLst_CalculatorSalaries afrmLst_CalculatorSalaries)
        {
            InitializeComponent();
            afrmLst_CalculatorSalaries_Old = afrmLst_CalculatorSalaries;
        }

        private void frmIns_CalculatorSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                
               
                    List<SystemUsers> aListSystemUser = aSystemUsersBO.Select_All();
                    dgvSysUsers.DataSource = aListSystemUser;
                    dgvSysUsers.RefreshDataSource();

                    lueIDSystemUser.Properties.DataSource = aListSystemUser;
                    lueIDSystemUser.Properties.DisplayMember = "Name";
                    lueIDSystemUser.Properties.ValueMember = "ID";
                    if (afrmMain != null)
                    {
                        lueIDSystemUser.EditValue = IDSystemUser;

                    }                  
                
                    GroupTableSalaries aGroupTableSalaries = aGroupTableSalariesBO.Select_ByDisable();
                    if (aGroupTableSalaries != null)
                    {
                        List<TableSalaries> aListTableSalaries = aTableSalariesBO.Select_ByIDGroupTableSalaries(aGroupTableSalaries.ID);
                        lueSku.Properties.DataSource = aListTableSalaries;
                        lueSku.Properties.DisplayMember = "Name";
                        lueSku.Properties.ValueMember = "Sku";
                        if (aListTableSalaries.Count > 0)
                        {
                            lueSku.EditValue = aListTableSalaries[0].Sku;
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CalculatorSalaries.frmIns_CalculatorSalaries_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            if (lueCoefficent.EditValue == null)
            {
                MessageBox.Show("Chọn Hệ số lương trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpEndDate.Text == "")
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    DateTime? NullDatetime = null;
                    IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
                    //Disable tính lương cũ
                    CalculatorSalaries aCalculatorSalaries_Old = new CalculatorSalaries();
                    List<CalculatorSalaries> aLisTemp = aCalculatorSalariesBO.Select_ByIDSystemUser(Convert.ToInt16(lueIDSystemUser.EditValue));

                    if (aLisTemp!= null)
                    {
                        aCalculatorSalaries_Old = aLisTemp.Where(a => a.Disable == false).ToList()[0];
                        aCalculatorSalaries_Old.Disable = true;
                        aCalculatorSalariesBO.Update(aCalculatorSalaries_Old);
                    }
                    // Tạo tính lương mới
                    CalculatorSalaries aCalculatorSalaries = new CalculatorSalaries();
                    aCalculatorSalaries.IDSystemUser = Convert.ToInt16(lueIDSystemUser.EditValue);
                    aCalculatorSalaries.SkuTableSalary = Convert.ToString(lueSku.EditValue);
                    aCalculatorSalaries.Coefficent = Convert.ToDouble(lueCoefficent.EditValue);

                    aCalculatorSalaries.StartDate = dtpStartDate.EditValue == null ? NullDatetime : dtpStartDate.DateTime;
                    aCalculatorSalaries.EndDate = dtpEndDate.EditValue == null ? NullDatetime : dtpEndDate.DateTime;
                    aCalculatorSalaries.Type = cbbType.SelectedIndex;
                    aCalculatorSalaries.Status = cbbStatus.SelectedIndex;
                    aCalculatorSalaries.Disable = false;
                    aCalculatorSalariesBO.Insert(aCalculatorSalaries);


                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.afrmLst_CalculatorSalaries_Old != null)
                    {
                        this.afrmLst_CalculatorSalaries_Old.Reload();
                        this.Close();
                    }
                    else if (this.afrmMain != null)
                    {
                        this.afrmMain.ReloadGridView();
                        this.Close();
                    }
                    else
                    {
                        int IDSystemUser = Convert.ToInt32(lueIDSystemUser.EditValue);
                        ReloadGridView(IDSystemUser);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CalculatorSalaries.btnAdd_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lueSku_EditValueChanged(object sender, EventArgs e)
        {
            string Sku = Convert.ToString(lueSku.EditValue);
            TableSalaries aTableSalaries = aTableSalariesBO.Select_BySku(Sku);
            List<SalaryEN> aListSalary = new List<SalaryEN>();
            SalaryEN aSalary;
            List<string> aListCoe = ConvertCoe(aTableSalaries);
            for (int i = 1; i < aListCoe.Count; i++)
            {
                aSalary = new SalaryEN();
                aSalary.Coe = aListCoe[i];
                aSalary.NumberOfCoe = i;
                aListSalary.Add(aSalary);
            }


            lueCoefficent.Properties.DataSource = aListSalary;
            lueCoefficent.Properties.DisplayMember = "Coe";
            lueCoefficent.Properties.ValueMember = "Coe";


        }
        private List<string> ConvertCoe(TableSalaries aTableSalaries)
        {
            try
            {
                List<string> ret = new List<string>();
                ret.Insert(0, aTableSalaries.Coe1.GetValueOrDefault(0).ToString());
                ret.Insert(1, aTableSalaries.Coe2.GetValueOrDefault(0).ToString());
                ret.Insert(2, aTableSalaries.Coe3.GetValueOrDefault(0).ToString());
                ret.Insert(3, aTableSalaries.Coe4.GetValueOrDefault(0).ToString());
                ret.Insert(4, aTableSalaries.Coe5.GetValueOrDefault(0).ToString());
                ret.Insert(5, aTableSalaries.Coe6.GetValueOrDefault(0).ToString());
                ret.Insert(6, aTableSalaries.Coe7.GetValueOrDefault(0).ToString());
                ret.Insert(7, aTableSalaries.Coe8.GetValueOrDefault(0).ToString());
                ret.Insert(8, aTableSalaries.Coe9.GetValueOrDefault(0).ToString());
                ret.Insert(9, aTableSalaries.Coe10.GetValueOrDefault(0).ToString());
                ret.Insert(10, aTableSalaries.Coe11.GetValueOrDefault(0).ToString());
                ret.Insert(11, aTableSalaries.Coe12.GetValueOrDefault(0).ToString());
                ret.Insert(12, aTableSalaries.Coe13.GetValueOrDefault(0).ToString());
                ret.Insert(13, aTableSalaries.Coe14.GetValueOrDefault(0).ToString());
                ret.Insert(14, aTableSalaries.Coe15.GetValueOrDefault(0).ToString());
                ret.Insert(15, aTableSalaries.Coe16.GetValueOrDefault(0).ToString());
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CalculatorSalaries.ConvertCoe\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }    
      

        private void lueIDSystemUser_EditValueChanged(object sender, EventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(lueIDSystemUser.EditValue);
            ReloadGridView(IDSystemUser);
           
        }
        private void ReloadGridView(int IDSystemUser)
        {
            List<CalculatorSalaryEN> aListCalculatorSalary = new List<CalculatorSalaryEN>();
            List<CalculatorSalaries> aListTemp = aCalculatorSalariesBO.Select_ByIDSystemUser(IDSystemUser);
            CalculatorSalaryEN aCalculatorSalary;
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aCalculatorSalary = new CalculatorSalaryEN();
                aCalculatorSalary.SetValue(aListTemp[i]);
                aCalculatorSalary.SystemUser = aSystemUsersBO.Select_ByID(aListTemp[i].IDSystemUser).Name;
                aListCalculatorSalary.Add(aCalculatorSalary);
            }
            dgvCaculatorSalaries.DataSource = aListCalculatorSalary.OrderBy(a => a.ID);
            dgvCaculatorSalaries.RefreshDataSource();
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(grvSystemUser.GetFocusedRowCellValue("ID"));
            lueIDSystemUser.EditValue = IDSystemUser;
        }
    }
}