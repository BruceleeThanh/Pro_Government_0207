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
using CORESYSTEM;
using DevExpress.XtraEditors.Controls;
using System.IO;
using Library;
using Entity;

namespace HumanResource
{
    public partial class frmTsk_InsertSystemUser_Infromation : DevExpress.XtraEditors.XtraForm
    {

        private SystemUsersEN aSystemUsersEN = new SystemUsersEN();
        private Stream aStreamFile;

        private int FamilyMemberID;
        private int AuditHistoriesID;
        private int SystemUsers_CertificatesID;
        private int RewardAndPunishmentsID;
        private int DocumentSystemUsersID;

        private int Count = 0;

        public frmTsk_InsertSystemUser_Infromation()
        {
            InitializeComponent();
        }

        private void frmTsk_SystemUser_Infromation_Load(object sender, EventArgs e)
        {

            try
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

                if (Properties.Resources.IsEmailSync == "1")
                {
                    ckbIsEmailSync.CheckState = CheckState.Unchecked;
                }
                else
                {
                    ckbIsEmailSync.CheckState = CheckState.Unchecked;
                }
                ReloadCertificate();


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.frmTsk_SystemUser_Infromation_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CallBackCertificate(int ID)
        {
            try
            {
                lueCertificates.EditValue = ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.CallBackCertificate\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ReloadCertificate()
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.ReloadCertificate\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.pbxImage_MouseClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("frmTsk_SystemUser_Infromation.CheckDataBeforeAddFamilyMembers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.CheckDataBeforeAddFamilyMembers() == true)
                {
                    List<FamilyMembersExtEN> aListTemp = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == FamilyMemberID).ToList();
                    if (aListTemp.Count > 0)
                    {
                        FamilyMembersExtEN aItem = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == FamilyMemberID).ToList()[0];
                        aSystemUsersEN.aListFamilyMembersExtEN.Remove(aItem);
                    }

                    FamilyMembersExtEN aFamilyMembersExtEN = new FamilyMembersExtEN();

                    Count = Count + 1;
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
                    dgvFamilyMembers.DataSource = aSystemUsersEN.aListFamilyMembersExtEN;
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddMember_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.CheckDataBeforeAddAuditHistories\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void btnAddAudit_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.CheckDataBeforeAddAuditHistories() == true)
                {
                    List<AuditHistories> aListTemps = aSystemUsersEN.aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList();
                    if (aListTemps.Count > 0)
                    {
                        AuditHistories aTemps = aSystemUsersEN.aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList()[0];
                        aSystemUsersEN.aListAuditHistories.Remove(aTemps);
                    }

                    AuditHistories aAuditHistories = new AuditHistories();

                    Count = Count + 1;
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
                    dgvAuditHistories.DataSource = aSystemUsersEN.aListAuditHistories;
                    dgvAuditHistories.RefreshDataSource();

                    dtpAuditHistoriesFrom.EditValue = null;
                    dtpAuditHistoriesTo.EditValue = null;
                    txaAuditHistoriesNote.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddAudit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnAddRewardAndPunishments_Click(object sender, EventArgs e)
        {
            try
            {
                List<RewardAndPunishments> aListTemps = aSystemUsersEN.aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList();
                if (aListTemps.Count > 0)
                {
                    RewardAndPunishments aTemps = aSystemUsersEN.aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList()[0];
                    aSystemUsersEN.aListRewardAndPunishments.Remove(aTemps);
                }

                RewardAndPunishments aRewardAndPunishments = new RewardAndPunishments();
                Count = Count + 1;

                aRewardAndPunishments.ID = Count;

                aRewardAndPunishments.Subject = String.IsNullOrEmpty(txtRewardAndPunishmentsSubject.Text) == true ? String.Empty : txtRewardAndPunishmentsSubject.Text;

                aRewardAndPunishments.Type = cboRewardAndPunishmentsType.EditValue == null ? 0 : cboRewardAndPunishmentsType.SelectedIndex + 1;

                if (dtpRewardAndPunishments_CreateDate.EditValue != null)
                {
                    aRewardAndPunishments.CreatedDate = dtpRewardAndPunishments_CreateDate.DateTime;
                }

                if (dtpRewardAndPunishments_DecisionDate.EditValue != null)
                {
                    aRewardAndPunishments.DecisionDate = dtpRewardAndPunishments_DecisionDate.DateTime;
                }

                aRewardAndPunishments.NumberDecision = String.IsNullOrEmpty(txtRewardAndPunishmentsNumberDecision.Text) == true ? String.Empty : txtRewardAndPunishmentsNumberDecision.Text;
                aRewardAndPunishments.DecisionLevel = String.IsNullOrEmpty(txtRewardAndPunishmentsDecisionLevel.Text) == true ? String.Empty : txtRewardAndPunishmentsDecisionLevel.Text;
                aRewardAndPunishments.Description = String.IsNullOrEmpty(txaRewardAndPunishmentsDesctiption.Text) == true ? String.Empty : txaRewardAndPunishmentsDesctiption.Text;


                aRewardAndPunishments.Status = cboRewardAndPunishmentsStatus.EditValue == null ? 0 : cboRewardAndPunishmentsStatus.SelectedIndex + 1;
                aRewardAndPunishments.Disable = cboRewardAndPunishmentsDisable.EditValue == null ? false : Convert.ToBoolean(cboRewardAndPunishmentsDisable.Text);



                aSystemUsersEN.aListRewardAndPunishments.Add(aRewardAndPunishments);



                dgvRewardAndPunishments.DataSource = aSystemUsersEN.aListRewardAndPunishments;
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddRewardAndPunishments_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnAddDocumentSystemUsers_Click(object sender, EventArgs e)
        {
            try
            {

                List<DocumentSystemUsers> aListTemps = aSystemUsersEN.aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList();
                if (aListTemps.Count > 0)
                {
                    DocumentSystemUsers aTemps = aSystemUsersEN.aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList()[0];
                    aSystemUsersEN.aListDocumentSystemUsers.Remove(aTemps);
                }

                DocumentSystemUsers aDocumentSystemUsers = new DocumentSystemUsers();
                Count = Count + 1;
                aDocumentSystemUsers.ID = Count;
                string DocumentSystemUsers_Name = txtDocumentSystemUsers_Name.Text.Length > 50 ? txtDocumentSystemUsers_Name.Text.Substring(0, 50) : txtDocumentSystemUsers_Name.Text;
               
                aDocumentSystemUsers.Name = DocumentSystemUsers_Name;
                if (aStreamFile != null)
                {
                    Byte[] file = new Byte[aStreamFile.Length];
                    aDocumentSystemUsers.FileData = file;
                }
                aDocumentSystemUsers.Type = lueDocumentSystemUsersType.EditValue == null ? 0 : Convert.ToInt32(lueDocumentSystemUsersType.EditValue); 

                aDocumentSystemUsers.Note =String.IsNullOrEmpty(txaDocumentSystemUsers_Note.Text) == true ? String.Empty : txaDocumentSystemUsers_Note.Text;

                aDocumentSystemUsers.Status = cboDocumentSystemUsers_Status.SelectedIndex + 1;
                aDocumentSystemUsers.Disable = Convert.ToBoolean(cboDocumentSystemUsers_Disable.Text);


                aSystemUsersEN.aListDocumentSystemUsers.Add(aDocumentSystemUsers);


                dgvDocumentSystemUsers.DataSource = aSystemUsersEN.aListDocumentSystemUsers;
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddDocumentSystemUsers_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.CheckDataBeforeAddSystemUsers_Certificates\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnAddSystemUsers_Certificates_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeAddSystemUsers_Certificates() == true)
                {
                    List<SystemUsers_CertificatesEN> aListTemp = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList();
                    if (aListTemp.Count > 0)
                    {
                        SystemUsers_CertificatesEN aItem = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList()[0];
                        aSystemUsersEN.aListSystemUsers_CertificatesEN.Remove(aItem);
                    }

                    SystemUsers_CertificatesEN aSystemUsers_CertificatesEN = new SystemUsers_CertificatesEN();
                    CertificatesBO aCertificatesBO = new CertificatesBO();
                    Count = Count + 1;
                    aSystemUsers_CertificatesEN.ID = Count;

                    aSystemUsers_CertificatesEN.IDCertificate = Convert.ToInt32(lueCertificates.EditValue);
                    if (Convert.ToInt32(lueCertificates.EditValue) > 0)
                    {
                        aSystemUsers_CertificatesEN.Certificate = aCertificatesBO.Select_ByID(Convert.ToInt32(lueCertificates.EditValue)).Organization;
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
                    
                    aSystemUsers_CertificatesEN.Level = Convert.ToString(lueSystemUsers_CertificatesLevel.EditValue);
                    
                    if (Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue) > 0)
                    {
                        aSystemUsers_CertificatesEN.LevelDisplay = CORE.CONSTANTS.SelectedSystemUsers_Certificates_Level(Convert.ToInt32(lueSystemUsers_CertificatesLevel.EditValue)).Name;
                    }
                    
                    
                    aSystemUsersEN.aListSystemUsers_CertificatesEN.Add(aSystemUsers_CertificatesEN);


                    dgvSystemUsers_Certificates.DataSource = aSystemUsersEN.aListSystemUsers_CertificatesEN;
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddSystemUsers_Certificates_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddNewCertificate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnSearchCertificate_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnChooseFileData_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFamilyMemberEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {

                FamilyMemberID = Convert.ToInt32(viewFamilyMembers.GetFocusedRowCellValue("ID"));
                FamilyMembers aFamilyMembers = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == FamilyMemberID).ToList()[0];

                txtFamilyMembersName.Text = aFamilyMembers.Name;
                if (aFamilyMembers.Birthday != null)
                {
                    dtpFamilyMembersBirthday.DateTime = aFamilyMembers.Birthday.GetValueOrDefault();
                }
                lueFamilyMembersRelationType.EditValue = aFamilyMembers.RelationType;
                txaFamilyMembersInfo.Text = aFamilyMembers.Info;



            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnFamilyMemberEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSystemUsers_CertificatesEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                SystemUsers_CertificatesID = Convert.ToInt32(viewSystemUsers_Certificates.GetFocusedRowCellValue("ID"));
                List<SystemUsers_CertificatesEN> aListSystemUsers_CertificatesEN = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(s => s.ID == SystemUsers_CertificatesID).ToList();

                if (aListSystemUsers_CertificatesEN.Count > 0)
                {
                    lueCertificates.EditValue = aListSystemUsers_CertificatesEN[0].IDCertificate;
                    lueSystemUsers_CertificatesTrainningType.EditValue =String.IsNullOrEmpty(aListSystemUsers_CertificatesEN[0].TrainingType) == true ? 0 : Convert.ToInt32(aListSystemUsers_CertificatesEN[0].TrainingType);
                    
                    if (aListSystemUsers_CertificatesEN[0].CreatedDate != null)
                    {
                        dtpSystemUsers_CertificatesCreatedDate.DateTime = aListSystemUsers_CertificatesEN[0].CreatedDate.GetValueOrDefault();
                    }
                    if (aListSystemUsers_CertificatesEN[0].ExpirationDate != null)
                    {
                        dtpSystemUsers_CertificatesExpirationDate.DateTime = aListSystemUsers_CertificatesEN[0].ExpirationDate.GetValueOrDefault();
                    }

                    lueSystemUsers_CertificatesLevel.EditValue =String.IsNullOrEmpty(aListSystemUsers_CertificatesEN[0].Level) == true ? 0 : Convert.ToInt32(aListSystemUsers_CertificatesEN[0].Level);
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnSystemUsers_CertificatesEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAuditHistoriesEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {


                AuditHistoriesID = Convert.ToInt32(viewAuditHistories.GetFocusedRowCellValue("ID"));

                AuditHistories aAuditHistories = aSystemUsersEN.aListAuditHistories.Where(a => a.ID == AuditHistoriesID).ToList()[0];
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAuditHistoriesEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnRewardAndPunishmentsEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                RewardAndPunishmentsID = Convert.ToInt32(viewRewardAndPunishments.GetFocusedRowCellValue("ID"));

                List<RewardAndPunishments> aListRewardAndPunishments = aSystemUsersEN.aListRewardAndPunishments.Where(r => r.ID == RewardAndPunishmentsID).ToList();

                if (aListRewardAndPunishments.Count > 0)
                {
                    txtRewardAndPunishmentsSubject.Text = aListRewardAndPunishments[0].Subject;

                    cboRewardAndPunishmentsType.SelectedIndex = Convert.ToInt32(aListRewardAndPunishments[0].Type - 1);

                    if (aListRewardAndPunishments[0].CreatedDate != null)
                    {
                        dtpRewardAndPunishments_CreateDate.DateTime = aListRewardAndPunishments[0].CreatedDate.GetValueOrDefault();
                    }

                    if (aListRewardAndPunishments[0].DecisionDate != null)
                    {
                        dtpRewardAndPunishments_DecisionDate.DateTime = aListRewardAndPunishments[0].DecisionDate.GetValueOrDefault();
                    }

                    txtRewardAndPunishmentsNumberDecision.Text = aListRewardAndPunishments[0].NumberDecision;

                    txtRewardAndPunishmentsDecisionLevel.Text = aListRewardAndPunishments[0].DecisionLevel;

                    txaRewardAndPunishmentsDesctiption.Text = aListRewardAndPunishments[0].Description;

                    cboRewardAndPunishmentsStatus.SelectedIndex = Convert.ToInt32(aListRewardAndPunishments[0].Status - 1);

                    cboRewardAndPunishmentsDisable.Text = Convert.ToString(aListRewardAndPunishments[0].Disable);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnRewardAndPunishmentsEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnDocumentSystemUsersEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                DocumentSystemUsersID = Convert.ToInt32(viewDocumentSystemUsers.GetFocusedRowCellValue("ID"));
                List<DocumentSystemUsers> aListDocumentSystemUsers = aSystemUsersEN.aListDocumentSystemUsers.Where(d => d.ID == DocumentSystemUsersID).ToList();
                if (aListDocumentSystemUsers.Count > 0)
                {
                    txtDocumentSystemUsers_Name.Text = aListDocumentSystemUsers[0].Name;
                    lueDocumentSystemUsersType.EditValue = aListDocumentSystemUsers[0].Type;
                    txaDocumentSystemUsers_Note.Text = aListDocumentSystemUsers[0].Note;
                    cboDocumentSystemUsers_Status.SelectedIndex = Convert.ToInt32(aListDocumentSystemUsers[0].Status - 1);
                    cboDocumentSystemUsers_Disable.Text = Convert.ToString(aListDocumentSystemUsers[0].Disable);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnDocumentSystemUsersEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckDataBeforeInsert()
        {
            try
            {
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
                                    MessageBox.Show("Ngày xuất ngũ phải sau ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    MessageBox.Show("Ngày xuất ngũ phải sau ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("Ngày vào Đảng phải sau ngày vào Đoàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                        MessageBox.Show("Ngày xuất ngũ phải sau ngày nhập ngũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("frmTsk_SystemUser_Infromation.CheckDataBeforeInsert\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeInsert() == true)
                {
                    DateTime? NullDatetime = null;

                    //thong tin SystemUsers
                    aSystemUsersEN.UserGroup = cboUserGroup.SelectedIndex + 1;
                    aSystemUsersEN.Email = txtEmail.Text;
                    aSystemUsersEN.Username = txtUsername.Text;
                    aSystemUsersEN.Name = txtName.Text;
                    aSystemUsersEN.Phone = txtMobile.Text;
                    aSystemUsersEN.Password = StringUtility.md5(txtUsername.Text + "12345678");
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
                    aReceptionTaskBO.AddSystemUserInformation(aSystemUsersEN);

                    if (ckbIsEmailSync.Checked == true)
                    {
                        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                        int ret = aSystemUsersBO.InsertEmailToDatabase(txtUsername.Text, txtPassword.Text, Properties.Resources.Domain1);
                        if (ret <= 0)
                        {
                            MessageBox.Show("Chưa tạo đồng bộ được email");
                        }

                    }
                    MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_SystemUser_Infromation.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string domain = Properties.Resources.Domain1;
                    txtUsername.Text = aSystemUsersBO.GetAvaiableUsername(txtName.Text, domain);
                    txtPassword.Text = txtUsername.Text + "12345678";

                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("frmTsk_SystemUser_Infromation.txtName_Leave\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
              DialogResult a= MessageBox.Show("Email của người dùng không tồn tại! Bạn có muốn nhập lại","Thông báo",MessageBoxButtons.YesNo);
              if (a == DialogResult.Yes)
              {
                  txtName.Focus();
                  
              }
              else if (a == DialogResult.No)
              {
                  this.Close();
              }
            }
        }

        private void btnFamilyMembersDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    int ID = Convert.ToInt32(viewFamilyMembers.GetFocusedRowCellValue("ID"));
                    List<FamilyMembersExtEN> aListTemp1 = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        FamilyMembersExtEN aItem = aSystemUsersEN.aListFamilyMembersExtEN.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListFamilyMembersExtEN.Remove(aItem);
                    }
                    dgvFamilyMembers.DataSource = aSystemUsersEN.aListFamilyMembersExtEN;
                    dgvFamilyMembers.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_SystemUser_Infromation.btnFamilyMembersDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int ID = Convert.ToInt32(viewSystemUsers_Certificates.GetFocusedRowCellValue("ID"));
                    List<SystemUsers_CertificatesEN> aListTemp1 = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        SystemUsers_CertificatesEN aItem = aSystemUsersEN.aListSystemUsers_CertificatesEN.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListSystemUsers_CertificatesEN.Remove(aItem);
                    }
                    dgvSystemUsers_Certificates.DataSource = aSystemUsersEN.aListSystemUsers_CertificatesEN;
                    dgvSystemUsers_Certificates.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_SystemUser_Infromation.btnSystemUsers_CertificatesDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int ID = Convert.ToInt32(viewAuditHistories.GetFocusedRowCellValue("ID"));
                    List<AuditHistories> aListTemp1 = aSystemUsersEN.aListAuditHistories.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        AuditHistories aItem = aSystemUsersEN.aListAuditHistories.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListAuditHistories.Remove(aItem);
                    }
                    dgvAuditHistories.DataSource = aSystemUsersEN.aListAuditHistories;
                    dgvAuditHistories.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_SystemUser_Infromation.btnAuditHistoriesDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int ID = Convert.ToInt32(viewRewardAndPunishments.GetFocusedRowCellValue("ID"));
                    List<RewardAndPunishments> aListTemp1 = aSystemUsersEN.aListRewardAndPunishments.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        RewardAndPunishments aItem = aSystemUsersEN.aListRewardAndPunishments.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListRewardAndPunishments.Remove(aItem);
                    }
                    dgvRewardAndPunishments.DataSource = aSystemUsersEN.aListRewardAndPunishments;
                    dgvRewardAndPunishments.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_SystemUser_Infromation.btnRewardAndPunishmentsDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int ID = Convert.ToInt32(viewDocumentSystemUsers.GetFocusedRowCellValue("ID"));
                    List<DocumentSystemUsers> aListTemp1 = aSystemUsersEN.aListDocumentSystemUsers.Where(f => f.ID == ID).ToList();
                    if (aListTemp1.Count > 0)
                    {
                        DocumentSystemUsers aItem = aSystemUsersEN.aListDocumentSystemUsers.Where(f => f.ID == ID).ToList()[0];
                        aSystemUsersEN.aListDocumentSystemUsers.Remove(aItem);
                    }
                    dgvDocumentSystemUsers.DataSource = aSystemUsersEN.aListDocumentSystemUsers;
                    dgvDocumentSystemUsers.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmTsk_SystemUser_Infromation.btnDocumentSystemUsersDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}