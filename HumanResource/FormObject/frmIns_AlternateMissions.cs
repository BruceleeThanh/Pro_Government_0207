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
using CORESYSTEM;

namespace HumanResource
{
    public partial class frmIns_AlternateMissions : DevExpress.XtraEditors.XtraForm
    {
        frmLst_AlternateMissions afrmLst_AlternateMissions_Old = null;
        
        
        public frmIns_AlternateMissions()
        {
            InitializeComponent();
        }
        public frmIns_AlternateMissions(frmLst_AlternateMissions afrmLst_AlternateMissions)
        {
            InitializeComponent();
            afrmLst_AlternateMissions_Old = afrmLst_AlternateMissions;
        }

        private void frmIns_AlternateMissions_Load(object sender, EventArgs e)
        {
            try
            {
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                lueIDSystemUser.Properties.DataSource = aSystemUsersBO.Select_All();
                lueIDSystemUser.Properties.DisplayMember = "Name";
                lueIDSystemUser.Properties.ValueMember = "ID";


                lueCountry.Properties.DataSource = CORE.CONSTANTS.ListCountries;
                lueCountry.Properties.DisplayMember = "Name";
                lueCountry.Properties.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_AlternateMissions.frmIns_AlternateMissions_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool ValidateData()
        {
            try{
            if (lueIDSystemUser.EditValue == null)
            {
                lueIDSystemUser.Focus();
                MessageBox.Show("Vui lòng chọn tên nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtpCreatedDate.EditValue == null)
            {
                dtpCreatedDate.Focus();
                MessageBox.Show("Nhập ngày tạo trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtpDecisionDate.EditValue == null)
            {
                dtpDecisionDate.Focus();
                MessageBox.Show("Nhập ngày ra quyết định trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtpFromDate.EditValue == null)
            {
                dtpFromDate.Focus();
                MessageBox.Show("Nhập ngày bắt đầu trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtpToDate.EditValue == null)
            {
                dtpToDate.Focus();
                MessageBox.Show("Nhập ngày kết thúc trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtDecisionLevel.Text) == true)
            {
                txtDecisionLevel.Focus();
                MessageBox.Show("Nhập cấp quyết định trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtNumberDecision.Text) == true)
            {
                txtNumberDecision.Focus();
                MessageBox.Show("Nhập số quyết định trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (String.IsNullOrEmpty(txtSubject.Text) == true)
            {
                txtSubject.Focus();
                MessageBox.Show("Nhập tiêu đề trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtpFromDate.DateTime > dtpToDate.DateTime)
            {
                dtpToDate.Focus();
                MessageBox.Show("Nhập ngày bắt đầu nhỏ hơn ngày kết thúc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;

            }
            catch (Exception ex)
            {
                return false;
                MessageBox.Show("frmIns_AlternateMissions.ValidateData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    DateTime? NullDateTime = null;
                    AlternateMissionsBO aAlternateMissionsBO = new AlternateMissionsBO();
                    AlternateMissions aAlternateMissions = new AlternateMissions();

                    aAlternateMissions.IDSystemUser = lueIDSystemUser.EditValue == null ? 0 : Convert.ToInt32(lueIDSystemUser.EditValue);
                    aAlternateMissions.NumberDecision = String.IsNullOrEmpty(txtNumberDecision.Text) == true ? String.Empty : txtNumberDecision.Text;
                    aAlternateMissions.Subject = String.IsNullOrEmpty(txtSubject.Text) == true ? String.Empty : txtSubject.Text;
                    aAlternateMissions.DecisionLevel = String.IsNullOrEmpty(txtDecisionLevel.Text) == true ? String.Empty : txtDecisionLevel.Text;
                    aAlternateMissions.Description = String.IsNullOrEmpty(txtDescription.Text) == true ? String.Empty : txtDescription.Text;

                    aAlternateMissions.ToDate = dtpToDate.EditValue == null ? NullDateTime : dtpToDate.DateTime;
                    aAlternateMissions.FromDate = dtpFromDate.EditValue == null ? NullDateTime : dtpFromDate.DateTime;
                    aAlternateMissions.CreatedDate = dtpCreatedDate.EditValue == null ? NullDateTime : dtpCreatedDate.DateTime;
                    aAlternateMissions.DecisionDate = dtpDecisionDate.EditValue == null ? NullDateTime : dtpDecisionDate.DateTime;

                    aAlternateMissions.Country = lueCountry.EditValue == null ? String.Empty : Convert.ToString(lueCountry.EditValue);
                    aAlternateMissions.Type = 1;
                    aAlternateMissions.Status = 1;
                    aAlternateMissions.Disable = String.IsNullOrEmpty(cbbDisable.Text) == true ? false : Convert.ToBoolean(cbbDisable.Text);

                    int count = aAlternateMissionsBO.Insert(aAlternateMissions);

                    if (count > 0)
                    {
                        MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                    if (this.afrmLst_AlternateMissions_Old != null)
                    {
                        this.afrmLst_AlternateMissions_Old.Reload();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_AlternateMissions.btnAddNew_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}