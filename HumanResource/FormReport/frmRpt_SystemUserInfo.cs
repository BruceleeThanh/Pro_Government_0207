using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataAccess;
using BussinessLogic;
using Entity;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace HumanResource
{
    public partial class frmRpt_SystemUserInfo : DevExpress.XtraReports.UI.XtraReport
    {
        public frmRpt_SystemUserInfo(UserInfomationEN aUserInfomationEN)
        {
            InitializeComponent();
            if (aUserInfomationEN.Image != null)
            {
                MemoryStream ms = new MemoryStream(aUserInfomationEN.Image);               
                pbxImage.Image = Image.FromStream(ms);
                
            }
            lblName.Text = aUserInfomationEN.Name;
            lblNames.Text = aUserInfomationEN.Name;
            lblBirthday.Text = aUserInfomationEN.Birthday.Value.ToString("dd/MM/yyyy"); // chưa set đc format time "{0:dd/MM/yyyy}"
            if (aUserInfomationEN.Gender == 1)
            {
                lblGender.Text = "Nam";
            }
            else
            {
                lblGender.Text = "Nữ";
            }
            lblHomeTown.Text = aUserInfomationEN.aSystemUserExts.Hometown;
            lblIdentify1.Text = aUserInfomationEN.Identifier1;
            lblPlaceCreateIdentify1.Text = aUserInfomationEN.PlaceOfIssue1;
            DateTime tempt = new DateTime();
            DateTime.TryParse(aUserInfomationEN.Identifier1CreatedDate.ToString(),out tempt);

            lblHightestAppellation.Text = aUserInfomationEN.aSystemUserExts.HightestAppellation;
            lblCreateDateIdentify1.Text = aUserInfomationEN.Identifier1CreatedDate != null ? aUserInfomationEN.Identifier1CreatedDate.Value.ToString("dd/MM/yyyy") : null; // chưa set đc format time "{0:dd/MM/yyyy}"
            lblAddress.Text = aUserInfomationEN.aSystemUserExts.Address;
            lblPermanentResidence.Text = aUserInfomationEN.aSystemUserExts.PermanentResidence;

            lblYouthUnionDate.Text = aUserInfomationEN.aSystemUserExts.YouthUnionDate != null? aUserInfomationEN.aSystemUserExts.YouthUnionDate.Value.ToString("dd/MM/yyyy"): null ; // chưa set đc format time "{0:dd/MM/yyyy}"
            lblCommunistPartyDate.Text = aUserInfomationEN.aSystemUserExts.CommunistPartyDate != null? aUserInfomationEN.aSystemUserExts.CommunistPartyDate.Value.ToString("dd/MM/yyyy") : null; // chưa set đc format time "{0:dd/MM/yyyy}"
            lblYearJob.Text = aUserInfomationEN.aSystemUserExts.YearJob != null? aUserInfomationEN.aSystemUserExts.YearJob.Value.ToString("dd/MM/yyyy"): null;
            lblYearDepartment.Text = aUserInfomationEN.aSystemUserExts.YearDepartment != null ? aUserInfomationEN.aSystemUserExts.YearDepartment.Value.ToString("dd/MM/yyyy") : null;
            lblYearUnemploymentInsurance.Text = aUserInfomationEN.aSystemUserExts.YearUnemploymentInsurance != null ? aUserInfomationEN.aSystemUserExts.YearUnemploymentInsurance.Value.ToString("dd/MM/yyyy"): null;
            lblEnlistmentDate.Text = aUserInfomationEN.aSystemUserExts.EnlistmentDate != null ? aUserInfomationEN.aSystemUserExts.EnlistmentDate.Value.ToString("dd/MM/yyyy") : null;
            lblDemobilizedDate.Text = aUserInfomationEN.aSystemUserExts.DemobilizedDate != null ? aUserInfomationEN.aSystemUserExts.DemobilizedDate.Value.ToString("dd/MM/yyyy") : null;
            lblRecruitment.Text = aUserInfomationEN.aSystemUserExts.Recruitment;
            if (aUserInfomationEN.aSystemUserExts.LaborFamily == true)
            {
                lblLaborFamily.Text = "X";
            }
            if (aUserInfomationEN.aSystemUserExts.MartyrsFamily  == true)
            {
                lblMartyrsFamily.Text = "X";
            }
            if (aUserInfomationEN.aSystemUserExts.WoundedFamily == true)
            {
                lblWoundedFamily.Text = "X";
            }
            // Bằng chính quy
            this.DetailReport1.DataSource = aUserInfomationEN.aListCertificateExt_Regular;
            cellSchool1.DataBindings.Add("Text", this.DetailReport1.DataSource, "Certificates_Organization");
            cellBranch1.DataBindings.Add("Text", this.DetailReport1.DataSource, "Certificates_Certificates");
            cellCreatedDate1.DataBindings.Add("Text", this.DetailReport1.DataSource, "SystemUsers_Certificates_CreatedDate", "{0:dd/MM/yyyy}");
            cellExpirationDate1.DataBindings.Add("Text", this.DetailReport1.DataSource, "SystemUsers_Certificates_ExpirationDate", "{0:dd/MM/yyyy}");
            cellTrainingType1.DataBindings.Add("Text", this.DetailReport1.DataSource, "TrainingTypeDisplay");
            cellLevel1.DataBindings.Add("Text", this.DetailReport1.DataSource, "SystemUsers_Certificates_Level");
            // Chứng chỉ
            this.DetailReport2.DataSource = aUserInfomationEN.aListCertificateExt_Sub;
            cellSchool2.DataBindings.Add("Text", this.DetailReport2.DataSource, "Certificates_Organization");
            cellBranch2.DataBindings.Add("Text", this.DetailReport2.DataSource, "Certificates_Certificates");
            cellCreatedDate2.DataBindings.Add("Text", this.DetailReport2.DataSource, "SystemUsers_Certificates_CreatedDate", "{0:dd/MM/yyyy}");
            cellExpirationDate2.DataBindings.Add("Text", this.DetailReport2.DataSource, "SystemUsers_Certificates_ExpirationDate", "{0:dd/MM/yyyy}");
            cellTrainingType2.DataBindings.Add("Text", this.DetailReport2.DataSource, "TrainingTypeDisplay");
            cellLevel2.DataBindings.Add("Text", this.DetailReport2.DataSource, "SystemUsers_Certificates_Level");
            // Ly luan chinh tri + Quan ly nha nuoc
            this.DetailReport7.DataSource = aUserInfomationEN.aListCertificateExt_PoliticGorvenmentManager;
            cellSchool3.DataBindings.Add("Text", this.DetailReport7.DataSource, "Certificates_Organization");
            cellBranch3.DataBindings.Add("Text", this.DetailReport7.DataSource, "Certificates_Certificates");
            cellCreatedDate3.DataBindings.Add("Text", this.DetailReport7.DataSource, "SystemUsers_Certificates_CreatedDate", "{0:dd/MM/yyyy}");
            cellExpirationDate3.DataBindings.Add("Text", this.DetailReport7.DataSource, "SystemUsers_Certificates_ExpirationDate", "{0:dd/MM/yyyy}");
            cellTrainingType3.DataBindings.Add("Text", this.DetailReport7.DataSource, "TrainingTypeDisplay");
            cellLevel3.DataBindings.Add("Text", this.DetailReport7.DataSource, "SystemUsers_Certificates_Level");
            // Quá trình công tác
            this.DetailReport3.DataSource = aUserInfomationEN.aListAuditHistories;
            cellAuditHistories_From.DataBindings.Add("Text", this.DetailReport3.DataSource, "From", "{0:dd/MM/yyyy}");
            cellAuditHistories_To.DataBindings.Add("Text", this.DetailReport3.DataSource, "To", "{0:dd/MM/yyyy}");
            cellAuditHistories_Note.DataBindings.Add("Text", this.DetailReport3.DataSource, "Note");
            // Quan hệ gia đình
            this.DetailReport4.DataSource = aUserInfomationEN.aListFamilyMembers;
            cellRelationType.DataBindings.Add("Text", this.DetailReport4.DataSource, "RelationDisplay");
            cellNameFamily.DataBindings.Add("Text", this.DetailReport4.DataSource, "Name");
            cellBirthday_FamilyMember.DataBindings.Add("Text", this.DetailReport4.DataSource, "Birthday", "{0:dd/MM/yyyy}");
            cellInfo.DataBindings.Add("Text", this.DetailReport4.DataSource, "Info");
            // Khen thưởng 
            this.DetailReport.DataSource = aUserInfomationEN.aListReward;    
            cellSubjectReward.DataBindings.Add("Text", this.DetailReport.DataSource, "Subject");
            cellDecisionRewardDate.DataBindings.Add("Text", this.DetailReport.DataSource, "DecisionDate", "{0:dd/MM/yyyy}");
            cellNumberDecisionReward.DataBindings.Add("Text", this.DetailReport.DataSource, "NumberDecision");
            cellDecisionRewardLevel.DataBindings.Add("Text", this.DetailReport.DataSource, "DecisionLevel");
            // Kỷ luật
            this.DetailReport6.DataSource = aUserInfomationEN.aListPunishments;
            cellSubjectPunishment.DataBindings.Add("Text", this.DetailReport6.DataSource, "Subject");
            cellDecisionPunishDate.DataBindings.Add("Text", this.DetailReport6.DataSource, "DecisionDate", "{0:dd/MM/yyyy}");
            cellNumberDecisionPunish.DataBindings.Add("Text", this.DetailReport6.DataSource, "NumberDecision");
            cellDecisionPunishLevel.DataBindings.Add("Text", this.DetailReport6.DataSource, "DecisionLevel");
            // Giấy tờ khác
            this.DetailReport5.DataSource = aUserInfomationEN.aListDocumentSystemUsers;
            cellNameDocumentSystemUsers.DataBindings.Add("Text", this.DetailReport5.DataSource, "Note");

            lblDateNow.Text = DateTime.Now.Day.ToString();
            lblMonthNow.Text = DateTime.Now.Month.ToString();
            lblYearNow.Text = DateTime.Now.Year.ToString();
        }

    }
}
