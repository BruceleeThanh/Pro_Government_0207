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
using DataAccess;
using BussinessLogic;
using DevExpress.Utils;
using Entity;

namespace HumanResource
{
    public partial class frmLst_Contracts : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_Contracts()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            try
            {
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                ContractsBO aContractsBO = new ContractsBO();
                colContractDate.DisplayFormat.FormatType = FormatType.DateTime;
                colContractDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                colFrom.DisplayFormat.FormatType = FormatType.DateTime;
                colFrom.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                colTo.DisplayFormat.FormatType = FormatType.DateTime;
                colTo.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";

                colCoefficent.DisplayFormat.FormatType = FormatType.Numeric;
                colCoefficent.DisplayFormat.FormatString = "{0:0,0}";
                colSalaryNet.DisplayFormat.FormatType = FormatType.Numeric;
                colSalaryNet.DisplayFormat.FormatString = "{0:0,0}";
                colSalaryCross.DisplayFormat.FormatType = FormatType.Numeric;
                colSalaryCross.DisplayFormat.FormatString = "{0:0,0}";

                // Load data cho gridview
                List<ContractsEN> aListContractsEN = new List<ContractsEN>();
                List<Contracts> aListTemp = aContractsBO.Select_All();
                ContractsEN aContractsEN;
                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aContractsEN = new ContractsEN();
                    aContractsEN.SetValue(aListTemp[i]);
                    aContractsEN.Name = aSystemUsersBO.Select_ByID(aListTemp[i].IDSystemUser).Name;
                    aListContractsEN.Add(aContractsEN);
                }
                dgvContracts.DataSource = aListContractsEN;
                dgvContracts.RefreshDataSource();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLst_Contracts_Load(object sender, EventArgs e)
        {
            try
            {
                this.ReloadData();
                dtpTo.DateTime = DateTime.Now;
                dtpFrom.DateTime = DateTime.Now.AddDays(-30);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts.frmLst_Contracts_Load\n" + ex.ToString() ,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewContracts.GetFocusedRowCellValue("ID"));
                frmUpd_Contracts afrmUpd_Contracts = new frmUpd_Contracts(this,ID);
                afrmUpd_Contracts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts.btnEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = Convert.ToInt32(viewContracts.GetFocusedRowCellValue("ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    ContractsBO aContractsBO = new ContractsBO();
                    aContractsBO.Delete(ID);
                    MessageBox.Show("Bạn đã xóa dữ liệu thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_Contracts.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.ReloadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime From = dtpFrom.DateTime;
                DateTime To = dtpTo.DateTime;
                if (From >= To)
                {
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu tìm nhỏ hơn ngày kết thúc tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ContractsBO aContractsBO = new ContractsBO();
                    List<Contracts> aListContracts = aContractsBO.Select_ByFromDate_ByToDate(From,To);
                    if (aListContracts.Count > 0)
                    {
                        colContractDate.DisplayFormat.FormatType = FormatType.DateTime;
                        colContractDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                        colFrom.DisplayFormat.FormatType = FormatType.DateTime;
                        colFrom.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                        colTo.DisplayFormat.FormatType = FormatType.DateTime;
                        colTo.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";

                        colCoefficent.DisplayFormat.FormatType = FormatType.Numeric;
                        colCoefficent.DisplayFormat.FormatString = "{0:0,0}";
                        colSalaryNet.DisplayFormat.FormatType = FormatType.Numeric;
                        colSalaryNet.DisplayFormat.FormatString = "{0:0,0}";
                        colSalaryCross.DisplayFormat.FormatType = FormatType.Numeric;
                        colSalaryCross.DisplayFormat.FormatString = "{0:0,0}";

                        dgvContracts.DataSource = aListContracts;
                    }
                    else
                    {
                        this.ReloadData();
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Contracts afrmIns_Contracts = new frmIns_Contracts(this);
                afrmIns_Contracts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Contracts.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}