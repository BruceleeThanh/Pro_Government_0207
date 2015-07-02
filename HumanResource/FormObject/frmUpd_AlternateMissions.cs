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
    public partial class frmUpd_AlternateMissions : DevExpress.XtraEditors.XtraForm
    {
        frmLst_AlternateMissions afrmLst_AlternateMissions_Old = null;
        int ID_Old = 0;
        
        public frmUpd_AlternateMissions(int ID, frmLst_AlternateMissions afrmLst_AlternateMissions)
        {
            InitializeComponent();
            ID_Old = ID;
            this.afrmLst_AlternateMissions_Old = afrmLst_AlternateMissions;
        }

        private void frmUpd_AlternateMissions_Load(object sender, EventArgs e)
        {
            try
            {
                AlternateMissionsBO aAlternateMissionsBO = new AlternateMissionsBO();
                AlternateMissions aAlternateMissions = aAlternateMissionsBO.Select_ByID(ID_Old);
                if(aAlternateMissions !=null)
                {
                    SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                    lueIDSystemUser.Properties.DataSource = aSystemUsersBO.Select_All();
                    lueIDSystemUser.Properties.DisplayMember = "Name";
                    lueIDSystemUser.Properties.ValueMember = "ID";

                    lueIDSystemUser.EditValue = aAlternateMissions.IDSystemUser;

                    lueCountry.Properties.DataSource = CORE.CONSTANTS.ListCountries;
                    lueCountry.Properties.DisplayMember = "Name";
                    lueCountry.Properties.ValueMember = "Code";

                    lueCountry.EditValue = CORE.CONSTANTS.SelectedCountry(aAlternateMissions.Country).Code;

                    if (aAlternateMissions.CreatedDate != null)
                    {
                        dtpCreatedDate.DateTime = aAlternateMissions.CreatedDate.GetValueOrDefault();
                    }
                    if (aAlternateMissions.DecisionDate != null)
                    {
                        dtpDecisionDate.DateTime = aAlternateMissions.DecisionDate.GetValueOrDefault();
                    }
                    if (aAlternateMissions.FromDate != null)
                    {
                        dtpFromDate.DateTime = aAlternateMissions.FromDate.GetValueOrDefault();
                    }
                    if (aAlternateMissions.ToDate != null)
                    {
                        dtpToDate.DateTime = aAlternateMissions.ToDate.GetValueOrDefault();
                    }

                    txtDecisionLevel.Text = aAlternateMissions.DecisionLevel;
                    txtDescription.Text = aAlternateMissions.Description;
                    txtNumberDecision.Text = aAlternateMissions.NumberDecision;
                    txtSubject.Text = aAlternateMissions.Subject;

                    cbbDisable.Text = Convert.ToString(aAlternateMissions.Disable);
                    cbbStatus.Text = Convert.ToString(aAlternateMissions.Status);
                    cbbType.Text = Convert.ToString(aAlternateMissions.Type);
                    lblID.Text = Convert.ToString(this.ID_Old);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_AlternateMissions_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool ValidateData()
        {
            try
            {
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
                MessageBox.Show("frmUpd_AlternateMissions.ValidateData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    aAlternateMissions.ID = ID_Old;

                    aAlternateMissions.IDSystemUser = lueIDSystemUser.EditValue ==null ? 0 : Convert.ToInt32(lueIDSystemUser.EditValue);
                    aAlternateMissions.NumberDecision = String.IsNullOrEmpty(txtNumberDecision.Text) == true ? String.Empty : txtNumberDecision.Text;
                    aAlternateMissions.Subject = String.IsNullOrEmpty(txtSubject.Text) == true ? String.Empty : txtSubject.Text;
                    aAlternateMissions.DecisionLevel = String.IsNullOrEmpty(txtDecisionLevel.Text) == true ? String.Empty : txtDecisionLevel.Text;
                    aAlternateMissions.Description = String.IsNullOrEmpty(txtDescription.Text) == true ? String.Empty : txtDescription.Text;

                    aAlternateMissions.ToDate = dtpToDate.EditValue == null ? NullDateTime : dtpToDate.DateTime;
                    aAlternateMissions.FromDate = dtpFromDate.EditValue == null ? NullDateTime : dtpFromDate.DateTime;
                    aAlternateMissions.CreatedDate = dtpCreatedDate.EditValue == null ? NullDateTime : dtpCreatedDate.DateTime;
                    aAlternateMissions.DecisionDate = dtpDecisionDate.EditValue == null ? NullDateTime : dtpDecisionDate.DateTime;

                    aAlternateMissions.Country = lueCountry.EditValue == null ? String.Empty : Convert.ToString(lueCountry.EditValue);
                    aAlternateMissions.Disable =String.IsNullOrEmpty(cbbDisable.Text) == true ? false : Convert.ToBoolean(cbbDisable.Text);
                    aAlternateMissions.Type =String.IsNullOrEmpty(cbbType.Text) == true ? 0: Convert.ToInt32(cbbType.Text);
                    aAlternateMissions.Status =String.IsNullOrEmpty(cbbStatus.Text) == true ? 0: Convert.ToInt32(cbbStatus.Text);


                    int count = aAlternateMissionsBO.Update(aAlternateMissions);
                    if(count > 0)
                    {
                        MessageBox.Show("Sửa thành công !", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();

                    if(this.afrmLst_AlternateMissions_Old !=null)
                    {
                        this.afrmLst_AlternateMissions_Old.Reload();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_AlternateMissions.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}