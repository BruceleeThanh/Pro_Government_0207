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
using Entity;
using CORESYSTEM;
using System.IO;
using DevExpress.XtraEditors.Controls;
using Library;
using DevExpress.Utils;


namespace HumanResource
{
    public partial class frmTsk_UpdateSystemUser_Infromation : DevExpress.XtraEditors.XtraForm
    {
        private int IDSystemUsers;
        private frmLst_SystemUsers afrmLst_SystemUsers = null;
        private SystemUsersEN aSystemUsersEN = new SystemUsersEN();
        private Stream aStreamFile;
        private Byte[] fileData;
        private List<FamilyMembersExtEN> aListFamilyMembersExtEN = new List<FamilyMembersExtEN>();
        private List<SystemUsers_CertificatesEN> aListSystemUsers_CertificatesEN = new List<SystemUsers_CertificatesEN>();
        private List<AuditHistories> aListAuditHistories = new List<AuditHistories>();
        private List<RewardAndPunishments> aListRewardAndPunishments = new List<RewardAndPunishments>();
        private List<DocumentSystemUsers> aListDocumentSystemUsers = new List<DocumentSystemUsers>();

        private int SystemUserExtsID = 0;
        private int FamilyMembersID = 0;
        private int SystemUsers_CertificatesID = 0;
        private int AuditHistoriesID = 0;
        private int RewardAndPunishmentsID = 0;
        private int DocumentSystemUsersID = 0;

        private string SystemUsersPassword = "";

        private int Count = 0;

        public frmTsk_UpdateSystemUser_Infromation()
        {
            InitializeComponent();
        }
        public frmTsk_UpdateSystemUser_Infromation(frmLst_SystemUsers afrmLst_SystemUsers, int IDSystemUsers)
        {
            InitializeComponent();
            this.afrmLst_SystemUsers = afrmLst_SystemUsers;
            this.IDSystemUsers = IDSystemUsers;
        }



        private void frmTsk_UpdateSystemUser_Infromation_Load(object sender, EventArgs e)
        {
            try
            {
                LoadConstants();

                LoadSystemUser(this.IDSystemUsers);
                LoadSystemUserExt(this.IDSystemUsers);

                LoadCertificate();


                //---------------------------------------




                if (Properties.Resources.IsLockEmailSync == "1")
                {ckbIsLockEmailSync.CheckState = CheckState.Unchecked;}
                else
                {ckbIsLockEmailSync.CheckState = CheckState.Unchecked;}


                dgvFamilyMembers.DataSource = aListFamilyMembersExtEN;
                dgvFamilyMembers.RefreshDataSource();

                //-------------------------
                this.LoadDataFamilyMembers();
                this.LoadDataSystemUsers_Certificates();
                this.LoadDataAuditHistories();
                this.LoadDataRewardAndPunishments();
                this.LoadDataDocumentSystemUsers();
                //----------------------------


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.frmTsk_UpdateSystemUser_Infromation_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnFamilyMemberEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {

                FamilyMembersID = Convert.ToInt32(viewFamilyMembers.GetFocusedRowCellValue("ID"));
                FamilyMembersExtEN aFamilyMembersExtEN = aListFamilyMembersExtEN.Where(f => f.ID == FamilyMembersID).ToList()[0];
                txtFamilyMembersName.Text = aFamilyMembersExtEN.Name;
                if (aFamilyMembersExtEN.Birthday != null)
                {
                    dtpFamilyMembersBirthday.DateTime = aFamilyMembersExtEN.Birthday.GetValueOrDefault();
                }
                lueFamilyMembersRelationType.EditValue = aFamilyMembersExtEN.RelationType;
                txaFamilyMembersInfo.Text = aFamilyMembersExtEN.Info;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnFamilyMemberEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSystemUsers_CertificatesEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {


                SystemUsers_CertificatesID = Convert.ToInt32(viewSystemUsers_Certificates.GetFocusedRowCellValue("ID"));
                SystemUsers_CertificatesEN aSystemUsers_CertificatesEN = aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList()[0];
                lueCertificates.EditValue = aSystemUsers_CertificatesEN.IDCertificate;
                lueSystemUsers_CertificatesTrainningType.EditValue = String.IsNullOrEmpty(aSystemUsers_CertificatesEN.TrainingType) == true ? 0 : Convert.ToInt32(aSystemUsers_CertificatesEN.TrainingType);
                lueSystemUsers_CertificatesLevel.EditValue =String.IsNullOrEmpty(aSystemUsers_CertificatesEN.Level) == true ? 0 : Convert.ToInt32(aSystemUsers_CertificatesEN.Level);
                
                if (aSystemUsers_CertificatesEN.CreatedDate != null)
                {
                    dtpSystemUsers_CertificatesCreatedDate.DateTime = aSystemUsers_CertificatesEN.CreatedDate.GetValueOrDefault();
                }
                if (aSystemUsers_CertificatesEN.ExpirationDate != null)
                {
                    dtpSystemUsers_CertificatesExpirationDate.DateTime = aSystemUsers_CertificatesEN.ExpirationDate.GetValueOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.frmTsk_UpdateSystemUser_Infromation\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAuditHistoriesEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                AuditHistoriesID = Convert.ToInt32(viewAuditHistories.GetFocusedRowCellValue("ID"));
                AuditHistories aAuditHistories = aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList()[0];
                if (aAuditHistories.From != null)
                {
                    dtpAuditHistoriesFrom.DateTime = aAuditHistories.From.GetValueOrDefault();
                }
                if (aAuditHistories.To != null)
                {
                    dtpAuditHistoriesTo.DateTime = aAuditHistories.To.GetValueOrDefault();
                }
                txaAuditHistoriesNote.Text = aAuditHistories.Note;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAuditHistoriesEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRewardAndPunishmentsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RewardAndPunishmentsID = Convert.ToInt32(viewRewardAndPunishments.GetFocusedRowCellValue("ID"));
                RewardAndPunishments aRewardAndPunishments = aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList()[0];
                txtRewardAndPunishmentsSubject.Text = aRewardAndPunishments.Subject;
                txaRewardAndPunishmentsDesctiption.Text = aRewardAndPunishments.Description;
                if (aRewardAndPunishments.CreatedDate != null)
                {
                    dtpRewardAndPunishments_CreateDate.DateTime = aRewardAndPunishments.CreatedDate.GetValueOrDefault();
                }
                if (aRewardAndPunishments.DecisionDate != null)
                {
                    dtpRewardAndPunishments_DecisionDate.DateTime = aRewardAndPunishments.DecisionDate.GetValueOrDefault();
                }
                txtRewardAndPunishmentsNumberDecision.Text = aRewardAndPunishments.NumberDecision;
                txtRewardAndPunishmentsDecisionLevel.Text = aRewardAndPunishments.DecisionLevel;
                cboRewardAndPunishmentsType.SelectedIndex = Convert.ToInt32(aRewardAndPunishments.Type - 1);
                cboRewardAndPunishmentsStatus.SelectedIndex = Convert.ToInt32(aRewardAndPunishments.Status - 1);
                cboRewardAndPunishmentsDisable.Text = Convert.ToString(aRewardAndPunishments.Disable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnRewardAndPunishmentsEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDocumentSystemUsersEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DocumentSystemUsersID = Convert.ToInt32(viewDocumentSystemUsers.GetFocusedRowCellValue("ID"));
                List<DocumentSystemUsers> aListTemp = aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList();
                if (aListTemp.Count > 0)
                {
                    fileData = aListTemp[0].FileData;
                    txtDocumentSystemUsers_Name.Text = aListTemp[0].Name;
                    lueDocumentSystemUsersType.EditValue = aListTemp[0].Type;
                    txaDocumentSystemUsers_Note.Text = aListTemp[0].Note;
                    cboDocumentSystemUsers_Status.SelectedIndex = Convert.ToInt32(aListTemp[0].Status - 1);
                    cboDocumentSystemUsers_Disable.Text = Convert.ToString(aListTemp[0].Disable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnDocumentSystemUsersEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------
        private bool CheckDataBeforeAddFamilyMembers()
        {
            try
            {
                if (dtpFamilyMembersBirthday.EditValue == null)
                {
                    return true;
                }
                else
                {
                    if (dtpFamilyMembersBirthday.DateTime <= DateTime.Now.Date)
                    {
                        return true;
                    }
                    else
                    {
                        dtpFamilyMembersBirthday.Focus();
                        MessageBox.Show("Vui lòng chọn ngày sinh phải nhỏ hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.CheckDataBeforeAddFamilyMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeAddFamilyMembers() == true)
                {
                    FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
                    List<FamilyMembersExtEN> aListTemp = aListFamilyMembersExtEN.Where(f => f.ID == FamilyMembersID).ToList();
                    if (aListTemp.Count > 0)
                    {
                        List<FamilyMembersExtEN> aListTemp1 = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == FamilyMembersID).ToList();
                        if (aListTemp1.Count > 0)
                        {
                            FamilyMembersExtEN aItem = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == FamilyMembersID).ToList()[0];
                            aSystemUsersEN.aListFamilyMembersExtEN.Remove(aItem);
                        }
                        FamilyMembersExtEN aFamilyMembersExtEN = aListFamilyMembersExtEN.Where(f => f.ID == FamilyMembersID).ToList()[0];
                        aFamilyMembersExtEN.Name = txtFamilyMembersName.Text;
                        if (dtpFamilyMembersBirthday.EditValue != null)
                        {
                            aFamilyMembersExtEN.Birthday = dtpFamilyMembersBirthday.DateTime;
                        }
                        aFamilyMembersExtEN.RelationType = Convert.ToInt32(lueFamilyMembersRelationType.EditValue);
                        if (Convert.ToInt32(lueFamilyMembersRelationType.EditValue) > 0)
                        {
                            aFamilyMembersExtEN.RelationDisplay = CORE.CONSTANTS.SelectedRelationType(Convert.ToInt32(lueFamilyMembersRelationType.EditValue)).Name;
                        }
                        aFamilyMembersExtEN.Info = txaFamilyMembersInfo.Text;
                        aSystemUsersEN.aListFamilyMembersExtEN.Add(aFamilyMembersExtEN);
                        aListFamilyMembersExtEN.Remove(aFamilyMembersExtEN);
                        aListFamilyMembersExtEN.Insert(0, aFamilyMembersExtEN);
                        FamilyMembersID = 0;
                    }
                    else
                    {
                        FamilyMembersExtEN aFamilyMembersExtEN = new FamilyMembersExtEN();

                        Count = Count - 1;
                        aFamilyMembersExtEN.ID = Count;
                        aFamilyMembersExtEN.Name = txtFamilyMembersName.Text;
                        aFamilyMembersExtEN.RelationType = Convert.ToInt32(lueFamilyMembersRelationType.EditValue);
                        if (Convert.ToInt32(lueFamilyMembersRelationType.EditValue) > 0)
                        {
                            aFamilyMembersExtEN.RelationDisplay = CORE.CONSTANTS.SelectedRelationType(Convert.ToInt32(lueFamilyMembersRelationType.EditValue)).Name;
                        }
                        if (dtpFamilyMembersBirthday.EditValue != null)
                        {
                            aFamilyMembersExtEN.Birthday = dtpFamilyMembersBirthday.DateTime;
                        }
                        aFamilyMembersExtEN.Info = txaFamilyMembersInfo.Text;
                        aSystemUsersEN.aListFamilyMembersExtEN.Add(aFamilyMembersExtEN);
                        aListFamilyMembersExtEN.Insert(0, aFamilyMembersExtEN);
                    }

                    dgvFamilyMembers.DataSource = aListFamilyMembersExtEN;
                    dgvFamilyMembers.RefreshDataSource();

                    txtFamilyMembersName.Text = "";
                    lueFamilyMembersRelationType.EditValue = 0;
                    lueFamilyMembersRelationType.Properties.NullText = " Chọn lựa ";
                    dtpFamilyMembersBirthday.EditValue = null;
                    txaFamilyMembersInfo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddMember_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckDataBeforeAddSystemUsers_Certificates()
        {
            try
            {
                if (Convert.ToInt32(lueCertificates.EditValue) > 0)
                {
                    if (dtpSystemUsers_CertificatesCreatedDate.EditValue == null)
                    {
                        return true;
                    }
                    else if (dtpSystemUsers_CertificatesExpirationDate.EditValue == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (dtpSystemUsers_CertificatesCreatedDate.DateTime < dtpSystemUsers_CertificatesExpirationDate.DateTime)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn ngày cấp bằng phải nhỏ hơn ngày hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bằng cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.CheckDataBeforeAddSystemUsers_Certificates\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddSystemUsers_Certificates_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeAddSystemUsers_Certificates() == true)
                {
                    CertificatesBO aCertificatesBO = new CertificatesBO();
                    List<SystemUsers_CertificatesEN> aListTemp = aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList();
                    if (aListTemp.Count > 0)
                    {
                        List<SystemUsers_CertificatesEN> aListTemp1 = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList();
                        if (aListTemp1.Count > 0)
                        {
                            SystemUsers_CertificatesEN aItem = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList()[0];
                            aSystemUsersEN.aListSystemUsers_CertificatesEN.Remove(aItem);
                        }
                        SystemUsers_CertificatesEN aSystemUsers_CertificatesEN = aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList()[0];
                        aSystemUsers_CertificatesEN.Level = lueSystemUsers_CertificatesLevel.EditValue.ToString();
                        if (Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue) > 0)
                        {
                            aSystemUsers_CertificatesEN.LevelDisplay = CORE.CONSTANTS.SelectedSystemUsers_Certificates_Level(Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue)).Name;
                        }
                        if (dtpSystemUsers_CertificatesCreatedDate.EditValue != null)
                        {
                            aSystemUsers_CertificatesEN.CreatedDate = dtpSystemUsers_CertificatesCreatedDate.DateTime;
                        }
                        if (dtpSystemUsers_CertificatesExpirationDate.EditValue != null)
                        {
                            aSystemUsers_CertificatesEN.ExpirationDate = dtpSystemUsers_CertificatesExpirationDate.DateTime;
                        }
                        aSystemUsers_CertificatesEN.IDCertificate = Convert.ToInt32(lueCertificates.EditValue);
                        if (Convert.ToInt32(lueCertificates.EditValue) > 0)
                        {
                            aSystemUsers_CertificatesEN.Certificate = aCertificatesBO.Select_ByID(Convert.ToInt32(lueCertificates.EditValue)).Certificate;
                        }

                        aSystemUsers_CertificatesEN.TrainingType = Convert.ToString(lueSystemUsers_CertificatesTrainningType.EditValue);
                        aSystemUsersEN.aListSystemUsers_CertificatesEN.Add(aSystemUsers_CertificatesEN);
                        aListSystemUsers_CertificatesEN.Remove(aSystemUsers_CertificatesEN);
                        aListSystemUsers_CertificatesEN.Insert(0, aSystemUsers_CertificatesEN);
                        SystemUsers_CertificatesID = 0;
                    }
                    else
                    {

                        SystemUsers_CertificatesEN aSystemUsers_CertificatesEN = new SystemUsers_CertificatesEN();
                        Count = Count - 1;
                        aSystemUsers_CertificatesEN.ID = Count;
                        aSystemUsers_CertificatesEN.Level = Convert.ToString(lueSystemUsers_CertificatesLevel.EditValue);
                        if (Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue) > 0)
                        {
                            aSystemUsers_CertificatesEN.LevelDisplay = CORE.CONSTANTS.SelectedSystemUsers_Certificates_Level(Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue)).Name;
                        }
                        aSystemUsers_CertificatesEN.IDCertificate = Convert.ToInt32(lueCertificates.EditValue);
                        if (Convert.ToInt32(lueCertificates.EditValue) > 0)
                        {
                            aSystemUsers_CertificatesEN.Certificate = aCertificatesBO.Select_ByID(Convert.ToInt32(lueCertificates.EditValue)).Certificate;
                        }
                        aSystemUsers_CertificatesEN.TrainingType = Convert.ToString(lueSystemUsers_CertificatesTrainningType.EditValue);
                        if (dtpSystemUsers_CertificatesCreatedDate.EditValue != null)
                        {
                            aSystemUsers_CertificatesEN.CreatedDate = dtpSystemUsers_CertificatesCreatedDate.DateTime;
                        }
                        if (dtpSystemUsers_CertificatesExpirationDate.EditValue != null)
                        {
                            aSystemUsers_CertificatesEN.ExpirationDate = dtpSystemUsers_CertificatesExpirationDate.DateTime;
                        }
                        aSystemUsersEN.aListSystemUsers_CertificatesEN.Add(aSystemUsers_CertificatesEN);
                        aListSystemUsers_CertificatesEN.Insert(0, aSystemUsers_CertificatesEN);

                    }
                    dgvSystemUsers_Certificates.DataSource = aListSystemUsers_CertificatesEN;
                    dgvSystemUsers_Certificates.RefreshDataSource();

                    lueCertificates.EditValue = 0;
                    lueCertificates.Properties.NullText = "  Chọn lựa ";
                    lueSystemUsers_CertificatesLevel.EditValue = 0;
                    lueSystemUsers_CertificatesLevel.Properties.NullText = " Chọn lựa ";
                    dtpSystemUsers_CertificatesCreatedDate.EditValue = null;
                    dtpSystemUsers_CertificatesExpirationDate.EditValue = null;
                    lueSystemUsers_CertificatesTrainningType.EditValue = 0;
                    lueSystemUsers_CertificatesTrainningType.Properties.NullText = " Chọn lựa ";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddSystemUsers_Certificates_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckDataBeforeAddAuditHistories()
        {
            try
            {
                if (dtpAuditHistoriesFrom.EditValue == null)
                {
                    dtpAuditHistoriesFrom.Focus();
                    MessageBox.Show("Vui lòng chọn ngày bắt đầu luân chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (dtpAuditHistoriesTo.EditValue == null)
                {
                    dtpAuditHistoriesTo.Focus();
                    MessageBox.Show("Vui lòng chọn ngày kết thúc luân chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (dtpAuditHistoriesFrom.DateTime < dtpAuditHistoriesTo.DateTime)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn ngày bắt đầu luân chuyển phải nhỏ hơn kết thúc luân chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.CheckDataBeforeAddAuditHistories\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void btnAddAudit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeAddAuditHistories() == true)
                {
                    List<AuditHistories> aListTemps = aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList();
                    if (aListTemps.Count > 0)
                    {
                        List<AuditHistories> aListTemps1 = aSystemUsersEN.aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList();
                        if (aListTemps1.Count > 0)
                        {
                            AuditHistories aTemps = aSystemUsersEN.aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList()[0];
                            aSystemUsersEN.aListAuditHistories.Remove(aTemps);
                        }
                        AuditHistories aAuditHistories = aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList()[0];
                        if (dtpAuditHistoriesFrom.EditValue != null)
                        {
                            aAuditHistories.From = dtpAuditHistoriesFrom.DateTime;
                        }
                        if (dtpAuditHistoriesTo.EditValue != null)
                        {
                            aAuditHistories.To = dtpAuditHistoriesTo.DateTime;
                        }
                        aAuditHistories.Note = txaAuditHistoriesNote.Text;
                        aSystemUsersEN.aListAuditHistories.Add(aAuditHistories);

                        aListAuditHistories.Remove(aAuditHistories);
                        aListAuditHistories.Insert(0, aAuditHistories);
                        AuditHistoriesID = 0;
                    }
                    else
                    {
                        AuditHistories aAuditHistories = new AuditHistories();
                        Count = Count - 1;
                        aAuditHistories.ID = Count;
                        if (dtpAuditHistoriesFrom.EditValue != null)
                        {
                            aAuditHistories.From = dtpAuditHistoriesFrom.DateTime;
                        }
                        if (dtpAuditHistoriesTo.EditValue != null)
                        {
                            aAuditHistories.To = dtpAuditHistoriesTo.DateTime;
                        }

                        aAuditHistories.Note = txaAuditHistoriesNote.Text;
                        aSystemUsersEN.aListAuditHistories.Add(aAuditHistories);
                        aListAuditHistories.Insert(0, aAuditHistories);

                    }
                    dgvAuditHistories.DataSource = aListAuditHistories;
                    dgvAuditHistories.RefreshDataSource();

                    dtpAuditHistoriesFrom.EditValue = null;
                    dtpAuditHistoriesTo.EditValue = null;
                    txaAuditHistoriesNote.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddAudit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRewardAndPunishments_Click(object sender, EventArgs e)
        {
            try
            {
                List<RewardAndPunishments> aListTemps = aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList();
                if (aListTemps.Count > 0)
                {
                    List<RewardAndPunishments> aListTemps1 = aSystemUsersEN.aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList();
                    if (aListTemps1.Count > 0)
                    {
                        RewardAndPunishments aTemps = aSystemUsersEN.aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList()[0];
                        aSystemUsersEN.aListRewardAndPunishments.Remove(aTemps);
                    }
                    RewardAndPunishments aRewardAndPunishments = aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList()[0];

                    aRewardAndPunishments.Type = cboRewardAndPunishmentsType.SelectedIndex + 1;
                    aRewardAndPunishments.Subject = txtRewardAndPunishmentsSubject.Text;
                    aRewardAndPunishments.Description = txaRewardAndPunishmentsDesctiption.Text;
                    if (dtpRewardAndPunishments_CreateDate.EditValue != null)
                    {
                        aRewardAndPunishments.CreatedDate = dtpRewardAndPunishments_CreateDate.DateTime;
                    }
                    if (dtpRewardAndPunishments_DecisionDate.EditValue != null)
                    {
                        aRewardAndPunishments.DecisionDate = dtpRewardAndPunishments_DecisionDate.DateTime;
                    }
                    aRewardAndPunishments.NumberDecision = txtRewardAndPunishmentsNumberDecision.Text;
                    aRewardAndPunishments.DecisionLevel = txtRewardAndPunishmentsDecisionLevel.Text;
                    aRewardAndPunishments.Status = cboRewardAndPunishmentsStatus.SelectedIndex + 1;
                    aRewardAndPunishments.Disable = Convert.ToBoolean(cboRewardAndPunishmentsDisable.Text);
                    aSystemUsersEN.aListRewardAndPunishments.Add(aRewardAndPunishments);
                    aListRewardAndPunishments.Remove(aRewardAndPunishments);
                    aListRewardAndPunishments.Insert(0, aRewardAndPunishments);
                    RewardAndPunishmentsID = 0;
                }
                else
                {
                    RewardAndPunishments aRewardAndPunishments = new RewardAndPunishments();
                    Count = Count - 1;
                    aRewardAndPunishments.ID = Count;
                    aRewardAndPunishments.Type = cboRewardAndPunishmentsType.SelectedIndex + 1;
                    aRewardAndPunishments.Subject = txtRewardAndPunishmentsSubject.Text;
                    aRewardAndPunishments.Description = txaRewardAndPunishmentsDesctiption.Text;
                    if (dtpRewardAndPunishments_CreateDate.EditValue != null)
                    {
                        aRewardAndPunishments.CreatedDate = dtpRewardAndPunishments_CreateDate.DateTime;
                    }
                    if (dtpRewardAndPunishments_DecisionDate.EditValue != null)
                    {
                        aRewardAndPunishments.DecisionDate = dtpRewardAndPunishments_DecisionDate.DateTime;
                    }
                    aRewardAndPunishments.NumberDecision = txtRewardAndPunishmentsNumberDecision.Text;
                    aRewardAndPunishments.DecisionLevel = txtRewardAndPunishmentsDecisionLevel.Text;
                    aRewardAndPunishments.Status = cboRewardAndPunishmentsStatus.SelectedIndex + 1;
                    aRewardAndPunishments.Disable = Convert.ToBoolean(cboRewardAndPunishmentsDisable.Text);
                    aSystemUsersEN.aListRewardAndPunishments.Add(aRewardAndPunishments);
                    aListRewardAndPunishments.Insert(0, aRewardAndPunishments);

                }
                dgvRewardAndPunishments.DataSource = aListRewardAndPunishments;
                dgvRewardAndPunishments.RefreshDataSource();

                txtRewardAndPunishmentsSubject.Text = "";
                txaRewardAndPunishmentsDesctiption.Text = "";
                dtpRewardAndPunishments_CreateDate.EditValue = null;
                dtpRewardAndPunishments_DecisionDate.EditValue = null;
                txtRewardAndPunishmentsNumberDecision.Text = "";
                txtRewardAndPunishmentsDecisionLevel.Text = "";
                cboRewardAndPunishmentsType.SelectedIndex = 0;
                cboRewardAndPunishmentsStatus.SelectedIndex = 0;
                cboRewardAndPunishmentsDisable.SelectedIndex = 0;
                cboRewardAndPunishmentsType.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddRewardAndPunishments_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDocumentSystemUsers_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<DocumentSystemUsers> aListTemps = aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList();
                if (aListTemps.Count > 0)
                {
                    List<DocumentSystemUsers> aListTemps1 = aSystemUsersEN.aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList();
                    if (aListTemps1.Count > 0)
                    {
                        DocumentSystemUsers aTemps = aSystemUsersEN.aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList()[0];
                        aSystemUsersEN.aListDocumentSystemUsers.Remove(aTemps);
                    }
                    DocumentSystemUsers aDocumentSystemUsers = aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList()[0];

                    string DocumentSystemUsers_Name = txtDocumentSystemUsers_Name.Text.Length > 50 ? txtDocumentSystemUsers_Name.Text.Substring(0, 50) : txtDocumentSystemUsers_Name.Text;
                    aDocumentSystemUsers.Name = DocumentSystemUsers_Name;

                    if (aStreamFile != null)
                    {
                        Byte[] file = new Byte[aStreamFile.Length];
                        aDocumentSystemUsers.FileData = file;
                    }
                    else
                    {
                        aDocumentSystemUsers.FileData = fileData;
                    }
                    aDocumentSystemUsers.Type = Convert.ToInt32(lueDocumentSystemUsersType.EditValue);
                    aDocumentSystemUsers.Note = txaDocumentSystemUsers_Note.Text;
                    aDocumentSystemUsers.Status = cboDocumentSystemUsers_Status.SelectedIndex + 1;
                    aDocumentSystemUsers.Disable = Convert.ToBoolean(cboDocumentSystemUsers_Disable.Text);
                    aSystemUsersEN.aListDocumentSystemUsers.Add(aDocumentSystemUsers);

                    aListDocumentSystemUsers.Remove(aDocumentSystemUsers);
                    aListDocumentSystemUsers.Insert(0, aDocumentSystemUsers);
                    DocumentSystemUsersID = 0;
                }
                else
                {

                    DocumentSystemUsers aDocumentSystemUsers = new DocumentSystemUsers();
                    Count = Count - 1;
                    aDocumentSystemUsers.ID = Count;
                    string DocumentSystemUsers_Name = txtDocumentSystemUsers_Name.Text.Length > 50 ? txtDocumentSystemUsers_Name.Text.Substring(0, 50) : txtDocumentSystemUsers_Name.Text;
                    aDocumentSystemUsers.Name = DocumentSystemUsers_Name;

                    if (aStreamFile != null)
                    {
                        Byte[] file = new Byte[aStreamFile.Length];
                        aDocumentSystemUsers.FileData = file;
                    }
                    aDocumentSystemUsers.Type = Convert.ToInt32(lueDocumentSystemUsersType.EditValue);
                    aDocumentSystemUsers.Note = txaDocumentSystemUsers_Note.Text;
                    aDocumentSystemUsers.Status = cboDocumentSystemUsers_Status.SelectedIndex + 1;
                    aDocumentSystemUsers.Disable = Convert.ToBoolean(cboDocumentSystemUsers_Disable.Text);
                    aSystemUsersEN.aListDocumentSystemUsers.Add(aDocumentSystemUsers);
                    
                    aListDocumentSystemUsers.Insert(0, aDocumentSystemUsers);


                }
                dgvDocumentSystemUsers.DataSource = aListDocumentSystemUsers;
                dgvDocumentSystemUsers.RefreshDataSource();

                txtDocumentSystemUsers_Name.Text = "";
                txaDocumentSystemUsers_Note.Text = "";
                lueDocumentSystemUsersType.EditValue = 0;
                lueDocumentSystemUsersType.Properties.NullText = " Chọn lựa ";
                cboDocumentSystemUsers_Status.SelectedIndex = 0;
                cboDocumentSystemUsers_Disable.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddDocumentSystemUsers_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pbxImage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Chọn ảnh";
                op.Filter = "All files|*.*";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    Stream aStreamImage = op.OpenFile();
                    pbxImage.Image = System.Drawing.Image.FromStream(aStreamImage);
                    pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.pbxImage_MouseClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseFileData_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Chọn file";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    aStreamFile = op.OpenFile();
                    txtDocumentSystemUsers_Name.Text = op.SafeFileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnChooseFileData_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckDataBeforeUpdate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) == true)
                {
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập họ tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dtpBirthday.EditValue == null)
                {
                    dtpBirthday.Focus();
                    MessageBox.Show("Vui lòng nhập ngày tháng năm sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    if (dtpBirthday.DateTime <= DateTime.Now.Date)
                    {
                        if (dtpCommunistPartyDate.EditValue == null)
                        {
                            if (dtpEnlistmentDate.EditValue == null)
                            {
                                return true;
                            }
                            else if (dtpDemobilizedDate.EditValue == null)
                            {
                                return true;
                            }
                            else
                            {
                                if (dtpEnlistmentDate.DateTime > dtpDemobilizedDate.DateTime)
                                {
                                    MessageBox.Show("Ngày xuất ngũ phải sau Ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        else if (dtpYouthUnionDate.EditValue == null)
                        {
                            if (dtpEnlistmentDate.EditValue == null)
                            {
                                return true;
                            }
                            else if (dtpDemobilizedDate.EditValue == null)
                            {
                                return true;
                            }
                            else
                            {
                                if (dtpEnlistmentDate.DateTime > dtpDemobilizedDate.DateTime)
                                {
                                    MessageBox.Show("Ngày xuất ngũ phải sau Ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (dtpYouthUnionDate.DateTime > dtpCommunistPartyDate.DateTime)
                            {
                                MessageBox.Show("Ngày vào Đảng phải sau Ngày vào Đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                if (dtpEnlistmentDate.EditValue == null)
                                {
                                    return true;
                                }
                                else if (dtpDemobilizedDate.EditValue == null)
                                {
                                    return true;
                                }
                                else
                                {
                                    if (dtpEnlistmentDate.DateTime > dtpDemobilizedDate.DateTime)
                                    {
                                        MessageBox.Show("Ngày xuất ngũ phải sau Ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        dtpBirthday.Focus();
                        MessageBox.Show("Vui lòng nhập năm sinh phải nhỏ hơn hoặc bằng ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.CheckDataBeforeInsert\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddNewCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Certificates afrmIns_Certificates = new frmIns_Certificates(this);
                afrmIns_Certificates.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAddNewCertificate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Certificates afrmLst_Certificates = new frmLst_Certificates(this);
                afrmLst_Certificates.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnSearchCertificate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) == true)
                {
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                    
                    string domain = "nhakhachchinhphu.com.vn";
                
                    txtUsername.Text = aSystemUsersBO.GetAvaiableUsername(txtName.Text, domain);
                    txtPassword.Text = txtUsername.Text + "12345678";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.txtName_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFamilyMemberDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
                    int ID = Convert.ToInt32(viewFamilyMembers.GetFocusedRowCellValue("ID"));
                    FamilyMembers aFamilyMembers = aFamilyMembersBO.Select_ByID(ID);
                    if (aFamilyMembers != null)
                    {
                        aFamilyMembersBO.Delete(ID);
                    }
                    List<FamilyMembersExtEN> aListTemp1 = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        FamilyMembersExtEN aItem = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListFamilyMembersExtEN.Remove(aItem);
                    }

                    List<FamilyMembersExtEN> aListTemp2 = aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp2.Count > 0)
                    {
                        FamilyMembersExtEN aItem = aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList()[0];
                        aListFamilyMembersExtEN.Remove(aItem);
                    }

                    dgvFamilyMembers.DataSource = aListFamilyMembersExtEN;
                    dgvFamilyMembers.RefreshDataSource();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnFamilyMemberDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSystemUsers_CertificatesDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
                    int ID = Convert.ToInt32(viewSystemUsers_Certificates.GetFocusedRowCellValue("ID"));
                    SystemUsers_Certificates aSystemUsers_Certificates = aSystemUsers_CertificatesBO.Select_ByID(ID);
                    if (aSystemUsers_Certificates != null)
                    {
                        aSystemUsers_CertificatesBO.Delete(ID);
                    }
                    List<SystemUsers_CertificatesEN> aListTemp1 = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        SystemUsers_CertificatesEN aItem = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListSystemUsers_CertificatesEN.Remove(aItem);
                    }
                    List<SystemUsers_CertificatesEN> aListTemp2 = aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp2.Count > 0)
                    {
                        SystemUsers_CertificatesEN aItem = aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList()[0];
                        aListSystemUsers_CertificatesEN.Remove(aItem);
                    }
                    dgvSystemUsers_Certificates.DataSource = aListSystemUsers_CertificatesEN;
                    dgvSystemUsers_Certificates.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnSystemUsers_CertificatesDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAuditHistoriesDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    AuditHistoriesBO aAuditHistoriesBO = new AuditHistoriesBO();
                    int ID = Convert.ToInt32(viewAuditHistories.GetFocusedRowCellValue("ID"));
                    AuditHistories aAuditHistories = aAuditHistoriesBO.Select_ByID(ID);
                    if (aAuditHistories != null)
                    {
                        aAuditHistoriesBO.Delete(ID);
                    }
                    List<AuditHistories> aListTemp1 = aSystemUsersEN.aListAuditHistories.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        AuditHistories aItem = aSystemUsersEN.aListAuditHistories.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListAuditHistories.Remove(aItem);
                    }
                    List<AuditHistories> aListTemp2 = aListAuditHistories.Where(f => f.ID == ID).ToList();
                    if (aListTemp2.Count > 0)
                    {
                        AuditHistories aItem = aListAuditHistories.Where(f => f.ID == ID).ToList()[0];
                        aListAuditHistories.Remove(aItem);
                    }
                    dgvAuditHistories.DataSource = aListAuditHistories;
                    dgvAuditHistories.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnAuditHistoriesDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRewardAndPunishmentsDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
                    int ID = Convert.ToInt32(viewRewardAndPunishments.GetFocusedRowCellValue("ID"));
                    RewardAndPunishments aRewardAndPunishments = aRewardAndPunishmentsBO.Select_ByID(ID);
                    if (aRewardAndPunishments != null)
                    {
                        aRewardAndPunishmentsBO.Delete(ID);
                    }
                    List<RewardAndPunishments> aListTemp1 = aSystemUsersEN.aListRewardAndPunishments.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        RewardAndPunishments aItem = aSystemUsersEN.aListRewardAndPunishments.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListRewardAndPunishments.Remove(aItem);
                    }
                    List<RewardAndPunishments> aListTemp2 = aListRewardAndPunishments.Where(f => f.ID == ID).ToList();
                    if (aListTemp2.Count > 0)
                    {
                        RewardAndPunishments aItem = aListRewardAndPunishments.Where(f => f.ID == ID).ToList()[0];
                        aListRewardAndPunishments.Remove(aItem);
                    }
                    dgvRewardAndPunishments.DataSource = aListRewardAndPunishments;
                    dgvRewardAndPunishments.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnRewardAndPunishmentsDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDocumentSystemUsersDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    DocumentSystemUsersBO aDocumentSystemUsersBO = new DocumentSystemUsersBO();
                    int ID = Convert.ToInt32(viewDocumentSystemUsers.GetFocusedRowCellValue("ID"));
                    DocumentSystemUsers aDocumentSystemUsers = aDocumentSystemUsersBO.Select_ByID(ID);
                    if (aDocumentSystemUsers != null)
                    {
                        aDocumentSystemUsersBO.Delete(ID);
                    }
                    List<DocumentSystemUsers> aListTemp1 = aSystemUsersEN.aListDocumentSystemUsers.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        DocumentSystemUsers aItem = aSystemUsersEN.aListDocumentSystemUsers.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListDocumentSystemUsers.Remove(aItem);
                    }
                    List<DocumentSystemUsers> aListTemp2 = aListDocumentSystemUsers.Where(f => f.ID == ID).ToList();
                    if (aListTemp2.Count > 0)
                    {
                        DocumentSystemUsers aItem = aListDocumentSystemUsers.Where(f => f.ID == ID).ToList()[0];
                        aListDocumentSystemUsers.Remove(aItem);
                    }
                    dgvDocumentSystemUsers.DataSource = aListDocumentSystemUsers;
                    dgvDocumentSystemUsers.RefreshDataSource();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnDocumentSystemUsersDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeUpdate() == true)
                {

                    DateTime? NullDatetime = null;
                    //thong tin SystemUsers
                    aSystemUsersEN.ID = IDSystemUsers;
                    aSystemUsersEN.UserGroup = cboUserGroup.SelectedIndex + 1;
                    aSystemUsersEN.Email = txtEmail.Text;
                    aSystemUsersEN.Username = txtUsername.Text;
                    aSystemUsersEN.Name = txtName.Text;

                    string Password = txtPassword.Text.Equals(SystemUsersPassword) ? SystemUsersPassword : StringUtility.md5(txtPassword.Text);
                    aSystemUsersEN.Password = Password;

                    aSystemUsersEN.Birthday = dtpBirthday.EditValue == null ? NullDatetime : dtpBirthday.DateTime;

                    aSystemUsersEN.Identifier1 = txtIdentifier1.Text;
                    aSystemUsersEN.Identifier2 = txtIdentifier2.Text;
                    aSystemUsersEN.Identifier3 = txtIdentifier3.Text;
                    aSystemUsersEN.Image = (Byte[])new ImageConverter().ConvertTo(pbxImage.Image, typeof(Byte[]));
                    aSystemUsersEN.Gender = Convert.ToInt32(lueGender.EditValue);
                    aSystemUsersEN.IDRefAnotherSystem = 1;// de tam
                    aSystemUsersEN.IDRefMailSystem = 1; //de tam
                    aSystemUsersEN.Type = cboType.SelectedIndex + 1;
                    aSystemUsersEN.Status = cboStatus.SelectedIndex + 1;
                    aSystemUsersEN.Disable = Convert.ToBoolean(cboDisable.Text);
                    aSystemUsersEN.Identifier1CreatedDate = dtpIdentifier1.EditValue == null ? NullDatetime : dtpIdentifier1.DateTime;
                    aSystemUsersEN.Identifier2CreatedDate = dtpIdentifier2.EditValue == null ? NullDatetime : dtpIdentifier2.DateTime;
                    aSystemUsersEN.Identifier3CreatedDate = dtpIdentifier3.EditValue == null ? NullDatetime : dtpIdentifier3.DateTime;
                    aSystemUsersEN.PlaceOfIssue1 = txtPlaceOfIssue1.Text;
                    aSystemUsersEN.PlaceOfIssue2 = txtPlaceOfIssue2.Text;
                    aSystemUsersEN.PlaceOfIssue3 = txtPlaceOfIssue3.Text;

                    //thong tin SystemUserExts
                    aSystemUsersEN.aSystemUserExts.ID = SystemUserExtsID;
                    aSystemUsersEN.aSystemUserExts.BirthPlace = txtBirthPlace.Text;
                    aSystemUsersEN.aSystemUserExts.Hometown = txtHometown.Text;
                    aSystemUsersEN.aSystemUserExts.Address = txtAddress.Text;
                    aSystemUsersEN.aSystemUserExts.InsuranceNumber = txtInsuranceNumber.Text;
                    aSystemUsersEN.aSystemUserExts.YearJob = dtpYearJob.EditValue == null ? NullDatetime : dtpYearJob.DateTime;
                    aSystemUsersEN.aSystemUserExts.YearPayroll = dtpYearPayroll.EditValue == null ? NullDatetime : dtpYearPayroll.DateTime;
                    aSystemUsersEN.aSystemUserExts.YearUnemploymentInsurance = dtpYearUnemploymentInsuarance.EditValue == null ? NullDatetime : dtpYearUnemploymentInsuarance.DateTime;
                    aSystemUsersEN.aSystemUserExts.DifferenceContact = "";
                    aSystemUsersEN.aSystemUserExts.Type = cboSystemUserExtsType.SelectedIndex + 1;
                    aSystemUsersEN.aSystemUserExts.Status = cboSystemUserExtsStatus.SelectedIndex + 1;
                    aSystemUsersEN.aSystemUserExts.Disable = Convert.ToBoolean(cboSystemUserExtsDisable.Text);
                    aSystemUsersEN.aSystemUserExts.Recruitment = txtRecruitment.Text;
                    aSystemUsersEN.aSystemUserExts.PermanentResidence = txaPermanentResidence.Text;
                    aSystemUsersEN.aSystemUserExts.CommunistPartyDate = dtpCommunistPartyDate.EditValue == null ? NullDatetime : dtpCommunistPartyDate.DateTime;
                    aSystemUsersEN.aSystemUserExts.YouthUnionDate = dtpYouthUnionDate.EditValue == null ? NullDatetime : dtpYouthUnionDate.DateTime;
                    aSystemUsersEN.aSystemUserExts.EnlistmentDate = dtpEnlistmentDate.EditValue == null ? NullDatetime : dtpEnlistmentDate.DateTime;
                    aSystemUsersEN.aSystemUserExts.DemobilizedDate = dtpDemobilizedDate.EditValue == null ? NullDatetime : dtpDemobilizedDate.DateTime;
                    aSystemUsersEN.aSystemUserExts.YearDepartment = dtpYearDepartment.EditValue == null ? NullDatetime : dtpYearDepartment.DateTime;
                    bool martyrsFamily = chkMartysFamily.Checked == true ? true : false;
                    bool woundedFamily = chkWoundedFamily.Checked == true ? true : false;
                    bool laborFamily = chkLaborFamily.Checked == true ? true : false;

                    aSystemUsersEN.aSystemUserExts.MartyrsFamily = martyrsFamily;
                    aSystemUsersEN.aSystemUserExts.WoundedFamily = woundedFamily;
                    aSystemUsersEN.aSystemUserExts.LaborFamily = laborFamily;
                    aSystemUsersEN.aSystemUserExts.HightestAppellation = txtHightestAppellation.Text;


                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                    aReceptionTaskBO.UpdateSystemUserInformation(aSystemUsersEN);
                    if (ckbIsLockEmailSync.Checked == true)
                    {
                        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                        int ret = aSystemUsersBO.InsertEmailToDatabase(txtUsername.Text, txtPassword.Text, Properties.Resources.Domain1);
                        if (ret <= 0)
                        {
                            MessageBox.Show("Chưa tạo đồng bộ được email");
                        }

                    }
                    // 
                    if (this.afrmLst_SystemUsers != null)
                    {
                        this.afrmLst_SystemUsers.Reload();
                    }
                    MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.btnSave_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //====================================================================================
        private void LoadDataFamilyMembers()
        {
            try
            {
               
                FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
                List<FamilyMembers> aListFamilyMembers = aFamilyMembersBO.Select_ByIDSystemUser(this.IDSystemUsers);
                FamilyMembersExtEN aFamilyMembersExtEN;
                foreach (FamilyMembers item in aListFamilyMembers)
                {
                    aFamilyMembersExtEN = new FamilyMembersExtEN();
                    aFamilyMembersExtEN.ID = item.ID;
                    aFamilyMembersExtEN.IDSystemUser = item.IDSystemUser;
                    aFamilyMembersExtEN.Name = item.Name;
                    aFamilyMembersExtEN.Birthday = item.Birthday;
                    aFamilyMembersExtEN.Info = item.Info;
                    aFamilyMembersExtEN.RelationType = item.RelationType;
                    if (item.RelationType > 0)
                    {
                        aFamilyMembersExtEN.RelationDisplay = CORE.CONSTANTS.SelectedRelationType(item.RelationType.GetValueOrDefault()).Name;
                    }
                    aListFamilyMembersExtEN.Add(aFamilyMembersExtEN);
                }
                dgvFamilyMembers.DataSource = aListFamilyMembersExtEN;
                dgvFamilyMembers.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.LoadDataFamilyMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataSystemUsers_Certificates()
        {
            try
            {
              
                CertificatesBO aCertificatesBO = new CertificatesBO();
                SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
                List<SystemUsers_Certificates> aListSystemUsers_Certificates = aSystemUsers_CertificatesBO.Select_ByIDSystemUser(this.IDSystemUsers);
                SystemUsers_CertificatesEN aSystemUsers_CertificatesEN;
                foreach (SystemUsers_Certificates item in aListSystemUsers_Certificates)
                {
                    aSystemUsers_CertificatesEN = new SystemUsers_CertificatesEN();
                    aSystemUsers_CertificatesEN.ID = item.ID;
                    aSystemUsers_CertificatesEN.IDCertificate = item.IDCertificate;
                    aSystemUsers_CertificatesEN.IDSystemUser = item.IDSystemUser;
                    aSystemUsers_CertificatesEN.CreatedDate = item.CreatedDate;
                    aSystemUsers_CertificatesEN.ExpirationDate = item.ExpirationDate;
                    aSystemUsers_CertificatesEN.Organization = item.Organization;
                    aSystemUsers_CertificatesEN.TrainingType = item.TrainingType;
                    aSystemUsers_CertificatesEN.Level = item.Level;
                    if (string.IsNullOrEmpty(item.Level) == false)
                    {
                        aSystemUsers_CertificatesEN.LevelDisplay = CORE.CONSTANTS.SelectedSystemUsers_Certificates_Level(Convert.ToInt32(item.Level)).Name;
                    }
                    if (aCertificatesBO.Select_ByID(item.IDCertificate) != null)
                    {
                        aSystemUsers_CertificatesEN.Certificate = aCertificatesBO.Select_ByID(item.IDCertificate).Certificate;
                    }

                    aListSystemUsers_CertificatesEN.Add(aSystemUsers_CertificatesEN);
                }

                dgvSystemUsers_Certificates.DataSource = aListSystemUsers_CertificatesEN;
                dgvSystemUsers_Certificates.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.LoadDataSystemUsers_Certificates\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataAuditHistories()
        {
            try
            {
               
                AuditHistoriesBO aAuditHistoriesBO = new AuditHistoriesBO();
                aListAuditHistories = aAuditHistoriesBO.Select_ByIDSystemUser(this.IDSystemUsers);
                dgvAuditHistories.DataSource = aListAuditHistories;
                dgvAuditHistories.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.LoadDataAuditHistories\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataRewardAndPunishments()
        {
            try
            {
                
                RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
                aListRewardAndPunishments = aRewardAndPunishmentsBO.Select_ByIDSystemUser(this.IDSystemUsers);
                dgvRewardAndPunishments.DataSource = aListRewardAndPunishments;
                dgvRewardAndPunishments.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.LoadDataRewardAndPunishments\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataDocumentSystemUsers()
        {
            try
            {
                DocumentSystemUsersBO aDocumentSystemUsersBO = new DocumentSystemUsersBO();
                aListDocumentSystemUsers = aDocumentSystemUsersBO.Select_ByIDSystemUser(this.IDSystemUsers);
                dgvDocumentSystemUsers.DataSource = aListDocumentSystemUsers;
                dgvDocumentSystemUsers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.LoadDataDocumentSystemUsers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetFocusCertificate(int ID)
        {
            try
            {
                lueCertificates.EditValue = ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.CallBackCertificate\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadCertificate()
        {
            try
            {
                CertificatesBO aCertificatesBO = new CertificatesBO();
                List<Certificates> aListCertificates = new List<Certificates>();
                aListCertificates = aCertificatesBO.Select_All();
                lueCertificates.Properties.DataSource = aListCertificates;
                lueCertificates.Properties.DisplayMember = "Organization";
                lueCertificates.Properties.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdateSystemUser_Infromation.ReloadCertificate\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConstants()
        {
            lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gender 
            lueGender.Properties.DisplayMember = "Name";
            lueGender.Properties.ValueMember = "ID";


            lueFamilyMembersRelationType.Properties.DataSource = CORE.CONSTANTS.ListRelationTypes;//Load relation type
            lueFamilyMembersRelationType.Properties.DisplayMember = "Name";
            lueFamilyMembersRelationType.Properties.ValueMember = "ID";


            lueDocumentSystemUsersType.Properties.DataSource = CORE.CONSTANTS.ListDocumentSystemUsersTypes; // load DocumentSystemUsers type
            lueDocumentSystemUsersType.Properties.DisplayMember = "Name";
            lueDocumentSystemUsersType.Properties.ValueMember = "ID";

            lueSystemUsers_CertificatesTrainningType.Properties.DataSource = CORE.CONSTANTS.ListTrainingTypes;
            lueSystemUsers_CertificatesTrainningType.Properties.DisplayMember = "Name";
            lueSystemUsers_CertificatesTrainningType.Properties.ValueMember = "ID";


            lueSystemUsers_CertificatesLevel.Properties.DataSource = CORE.CONSTANTS.ListSystemUsers_Certificates_Levels;
            lueSystemUsers_CertificatesLevel.Properties.DisplayMember = "Name";
            lueSystemUsers_CertificatesLevel.Properties.ValueMember = "ID";
        }
        private void LoadSystemUser(int IDSystemUser)
        {
            SystemUsersBO aSystemUsersBO = new SystemUsersBO();
            SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(IDSystemUser);

            txtName.Text = aSystemUsers.Name;
            if (aSystemUsers.Birthday != null)
            {
                dtpBirthday.DateTime = aSystemUsers.Birthday.GetValueOrDefault();
            }

            lueGender.EditValue = aSystemUsers.Gender;
            txtUsername.Text = aSystemUsers.Username;
            txtPassword.Text = aSystemUsers.Password;
            SystemUsersPassword = aSystemUsers.Password;
            txtEmail.Text = aSystemUsers.Email;

            if (aSystemUsers.Image != null)
            {
                if (aSystemUsers.Image.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(aSystemUsers.Image);
                    Image returnImage = Image.FromStream(ms);
                    pbxImage.Image = returnImage;
                    pbxImage.Properties.SizeMode = PictureSizeMode.Stretch;
                }
            }

            cboUserGroup.SelectedIndex = Convert.ToInt32(aSystemUsers.UserGroup - 1);
            txtIdentifier1.EditValue = aSystemUsers.Identifier1;
            if (aSystemUsers.Identifier1CreatedDate != null)
            {
                dtpIdentifier1.DateTime = aSystemUsers.Identifier1CreatedDate.GetValueOrDefault();
            }

            txtPlaceOfIssue1.Text = aSystemUsers.PlaceOfIssue1;
            txtIdentifier2.Text = aSystemUsers.Identifier2;
            if (aSystemUsers.Identifier2CreatedDate != null)
            {
                dtpIdentifier2.DateTime = aSystemUsers.Identifier2CreatedDate.GetValueOrDefault();
            }

            txtPlaceOfIssue2.Text = aSystemUsers.PlaceOfIssue2;
            txtIdentifier3.Text = aSystemUsers.Identifier3;
            if (aSystemUsers.Identifier1CreatedDate != null)
            {
                dtpIdentifier3.DateTime = aSystemUsers.Identifier3CreatedDate.GetValueOrDefault();
            }

            txtPlaceOfIssue3.Text = aSystemUsers.PlaceOfIssue3;
            cboType.SelectedIndex = Convert.ToInt32(aSystemUsers.Type - 1);
            cboStatus.SelectedIndex = Convert.ToInt32(aSystemUsers.Status - 1);
            cboDisable.Text = Convert.ToString(aSystemUsers.Disable);

        }
        private void LoadSystemUserExt(int IDSystemUser)
        {
            SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
            SystemUserExts aSystemUserExts = aSystemUserExtsBO.Select_ByIDSystemUser(IDSystemUser);
            if (aSystemUserExts != null)
            {
                SystemUserExtsID = aSystemUserExts.ID;
                txtBirthPlace.Text = aSystemUserExts.BirthPlace;
                txtHometown.Text = aSystemUserExts.Hometown;
                txtAddress.Text = aSystemUserExts.Address;
                if (aSystemUserExts.YearJob != null)
                {
                    dtpYearJob.DateTime = aSystemUserExts.YearJob.GetValueOrDefault();
                }

                chkMartysFamily.Checked = Convert.ToBoolean(aSystemUserExts.MartyrsFamily);
                chkWoundedFamily.Checked = Convert.ToBoolean(aSystemUserExts.WoundedFamily);
                chkLaborFamily.Checked = Convert.ToBoolean(aSystemUserExts.LaborFamily);
                txtInsuranceNumber.Text = aSystemUserExts.InsuranceNumber;
                if (aSystemUserExts.YearPayroll != null)
                {
                    dtpYearPayroll.DateTime = aSystemUserExts.YearPayroll.GetValueOrDefault();
                }
                if (aSystemUserExts.YearUnemploymentInsurance != null)
                {
                    dtpYearUnemploymentInsuarance.DateTime = aSystemUserExts.YearUnemploymentInsurance.GetValueOrDefault();
                }
                txtRecruitment.Text = aSystemUserExts.Recruitment;
                txaPermanentResidence.Text = aSystemUserExts.PermanentResidence;
                cboSystemUserExtsType.SelectedIndex = Convert.ToInt32(aSystemUserExts.Type - 1);
                cboSystemUserExtsStatus.SelectedIndex = Convert.ToInt32(aSystemUserExts.Status - 1);
                cboSystemUserExtsDisable.Text = Convert.ToString(aSystemUserExts.Disable);

                if (aSystemUserExts.YouthUnionDate != null)
                {
                    dtpYouthUnionDate.DateTime = aSystemUserExts.YouthUnionDate.GetValueOrDefault();
                }
                if (aSystemUserExts.CommunistPartyDate != null)
                {
                    dtpCommunistPartyDate.DateTime = aSystemUserExts.CommunistPartyDate.GetValueOrDefault();
                }
                if (aSystemUserExts.YearDepartment != null)
                {
                    dtpYearDepartment.DateTime = aSystemUserExts.YearDepartment.GetValueOrDefault();
                }
                if (aSystemUserExts.EnlistmentDate != null)
                {
                    dtpEnlistmentDate.DateTime = aSystemUserExts.EnlistmentDate.GetValueOrDefault();
                }
                if (aSystemUserExts.DemobilizedDate != null)
                {
                    dtpDemobilizedDate.DateTime = aSystemUserExts.DemobilizedDate.GetValueOrDefault();
                }
                txtHightestAppellation.Text = aSystemUserExts.HightestAppellation;
            }
        }
        //====================================================================================

    }
}