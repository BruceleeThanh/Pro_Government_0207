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
namespace HumanResource
{
    public partial class frmIns_Divisions : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Divisions afrmLst_Divisions = null;
        public frmIns_Divisions()
        {
            InitializeComponent();
        }
        public frmIns_Divisions(frmLst_Divisions afrmLst_Divisions)
        {
            InitializeComponent();
            this.afrmLst_Divisions = afrmLst_Divisions;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên phòng ban trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    DivisionsBO aDivisionsBO = new DivisionsBO();
                    Divisions aDivisions = new Divisions();
                    aDivisions.Name = txtName.Text;
                    aDivisions.Type = cboType.SelectedIndex + 1;
                    aDivisions.Status = cboStatus.SelectedIndex + 1;
                    aDivisions.Disable = Convert.ToBoolean(cboDisable.Text);
                    aDivisionsBO.Insert(aDivisions);
                    if (this.afrmLst_Divisions != null)
                    {
                        this.afrmLst_Divisions.ReloadData();
                    }
                    MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Divisions.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

    }
}