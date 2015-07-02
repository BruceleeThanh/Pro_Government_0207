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
    public partial class frmLst_CalculatorSalaries : DevExpress.XtraEditors.XtraForm
    {
      

        public frmLst_CalculatorSalaries()
        {
            InitializeComponent();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvCalculatorSalaries.GetFocusedRowCellValue("ID").ToString());
            frmUpd_CalculatorSalaries afrmUpd_CalculatorSalaries = new frmUpd_CalculatorSalaries(ID, this);
            afrmUpd_CalculatorSalaries.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                CalculatorSalariesBO aCalculatorSalariesBO = new CalculatorSalariesBO();
                int ID = int.Parse(grvCalculatorSalaries.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa CalculatorSalaries " + ID + " này không?", "Xóa CalculatorSalaries", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aCalculatorSalariesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_CalculatorSalaries.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_CalculatorSalaries afrmIns_CalculatorSalaries = new frmIns_CalculatorSalaries(this);
            afrmIns_CalculatorSalaries.ShowDialog();
        }

        private void frmLst_CalculatorSalaries_Load(object sender, EventArgs e)
        {
           this.Reload();
        }
        public void Reload()
        {
            try
            {
                CalculatorSalariesBO aCalculatorSalariesBO = new CalculatorSalariesBO();
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                List<CalculatorSalaryEN> aListCalculatorSalary = new List<CalculatorSalaryEN>();
                List<CalculatorSalaries> aListTemp = aCalculatorSalariesBO.Select_All();

                CalculatorSalaryEN aCalculatorSalary;
               

                for( int i =1; i<aListTemp.Count;i++)
                {
                    aCalculatorSalary = new CalculatorSalaryEN();
                    aCalculatorSalary.SetValue(aListTemp[i]);
                    aCalculatorSalary.SystemUser = aSystemUsersBO.Select_ByID(aListTemp[i].IDSystemUser).Name;
                    aListCalculatorSalary.Add(aCalculatorSalary);
                }
                dgvCalculatorSalaries.DataSource = aListCalculatorSalary.Where(a=>a.Disable == false).ToList();
                dgvCalculatorSalaries.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_CalculatorSalaries.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}