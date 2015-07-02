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
    public partial class frmUpd_Divisions : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_Divisions afrmLst_Divisions = null;
        private int ID;
        public frmUpd_Divisions(frmLst_Divisions afrmLst_Divisions,int ID)
        {
            InitializeComponent();
            this.afrmLst_Divisions = afrmLst_Divisions;
            this.ID = ID;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên phòng ban trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    DivisionsBO aDivisionsBO = new DivisionsBO();
                    Divisions aDivisions = aDivisionsBO.Select_ByID(ID);
                    aDivisions.Name = txtName.Text;
                    aDivisions.Type = cboType.SelectedIndex + 1;
                    aDivisions.Status = cboStatus.SelectedIndex + 1;
                    aDivisions.Disable = Convert.ToBoolean(cboDisable.Text);
                    aDivisionsBO.Update(aDivisions);
                    this.afrmLst_Divisions.ReloadData();
                    MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Divisions.btnSave_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpd_Divisions_Load(object sender, EventArgs e)
        {
            try
            {
                DivisionsBO aDivisionsBO = new DivisionsBO();
                Divisions aDivisions = aDivisionsBO.Select_ByID(ID);
                lblID.Text = aDivisions.ID.ToString();
                txtName.Text = aDivisions.Name.ToString();
                cboType.SelectedIndex = Convert.ToInt32(aDivisions.Type -1);
                cboStatus.SelectedIndex = Convert.ToInt32(aDivisions.Type - 1);
                cboDisable.Text = aDivisions.Disable.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Divisions.frmUpd_Divisions_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}