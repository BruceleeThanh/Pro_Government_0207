using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;
using Entity;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Drawing;
using Library;
using CORESYSTEM;

namespace HumanResource
{
   
    public partial class frmLst_SystemUsers : DevExpress.XtraEditors.XtraForm
    {
       
        SystemUserExtsBO aSystemUserExtsBO = new SystemUserExtsBO();
        SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
        CertificatesBO aCertificatesBO = new CertificatesBO();
        FamilyMembersBO aFamilyMembersBO = new FamilyMembersBO();
        AuditHistoriesBO aAuditHistoriesBO = new AuditHistoriesBO();
        RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
        DocumentSystemUsersBO aDocumentSystemUsersBO = new DocumentSystemUsersBO();
        frmIns_CalculatorSalaries afrmIns_CalculatorSalaries = null;
        public frmLst_SystemUsers()
        {
            InitializeComponent();
          
        }      
       

        private void frmSystemUser_Load(object sender, EventArgs e)
        {
            Reload();
        }     

      
        //hiennv
        public void Reload()
        {
            
            try
            {
                SystemUsersBO aSysUserBO = new SystemUsersBO();
                List<SystemUsers> aListTemp = aSysUserBO.Select_ByDisable(false);
                List<SystemUsers> aListSystemUsers = new List<SystemUsers>();
              
                foreach (SystemUsers item in aListTemp)
                {
                    SystemUsers aSystemUsers = aSysUserBO.Select_ByID(item.ID);
                    if (aSystemUsers.Image !=null)
                    {
                        if (aSystemUsers.Image.Length > 0)
                        {
                            Image image = ConvertByteArrayToImage(aSystemUsers.Image);
                            //image = image.GetThumbnailImage(60, (60 * image.Height) / image.Width, null, IntPtr.Zero);
                            image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                            Byte[] aImageByte = ConvertImageToByteArray(image);
                            aSystemUsers.Image = aImageByte;
                        }
                        else
                        {
                            //Image image =Image.FromFile("D:\\14-04-2014-NhaKhachChinhPhu\\HumanResource\\Images\\IconUser0.jpg");
                            Image image = Properties.Resources.IconUser0;
                            image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                            Byte[] aImageByte = ConvertImageToByteArray(image);
                            aSystemUsers.Image = aImageByte;
                        }
                    }
                    else
                    {
                        
                            //Image image =Image.FromFile("D:\\14-04-2014-NhaKhachChinhPhu\\HumanResource\\Images\\IconUser0.jpg");
                            Image image = Properties.Resources.IconUser0;
                            image = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                            Byte[] aImageByte = ConvertImageToByteArray(image);
                            aSystemUsers.Image = aImageByte;
                      
                    }
                    aListSystemUsers.Add(aSystemUsers);
                }
                dgvSysUsers.DataSource = aListSystemUsers;
                dgvSysUsers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers.Reload\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        public Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers.ConvertByteArrayToImage\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Hiennv
        public byte[] ConvertImageToByteArray(Image imageIn)
        {
            try
            {
               MemoryStream ms = new MemoryStream();
               imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
               return ms.ToArray();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers.ConvertimageToByteArray\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvSystemUser.GetFocusedRowCellValue("ID").ToString());
                frmTsk_UpdateSystemUser_Infromation afrmTsk_UpdateSystemUser_Infromation = new frmTsk_UpdateSystemUser_Infromation(this, ID);
                afrmTsk_UpdateSystemUser_Infromation.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers.btnEdit_ButtonClick\n" +ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SystemUsersBO aSysUserBO = new SystemUsersBO();
            int ID = int.Parse(grvSystemUser.GetFocusedRowCellValue("ID").ToString());
            string Name = aSysUserBO.Select_ByID(ID).Name;
            if (ID == CORE.CURRENTUSER.SystemUser.ID)
            {
                DialogResult result = MessageBox.Show("Không thể xóa User hiện tại vì User này đang đăng nhập hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa " + Name + " này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SystemUsers aTemp = aSysUserBO.Select_ByID(ID);
                    aTemp.Disable = true;
                    aSysUserBO.Update(aTemp);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
        }

        private void btnPrint_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SystemUsersBO aSysUserBO = new SystemUsersBO();
            UserInfomationEN aUserInfomationEN = new UserInfomationEN();
             int IDSystemUser = int.Parse(grvSystemUser.GetFocusedRowCellValue("ID").ToString());
            // Thong tin cua SystemUser
            SystemUsers aSystemUsers = aSysUserBO.Select_ByID(IDSystemUser);
             aUserInfomationEN.ID = IDSystemUser;
             aUserInfomationEN.Name = aSystemUsers.Name;
             aUserInfomationEN.Gender = aSystemUsers.Gender;
             aUserInfomationEN.Birthday = aSystemUsers.Birthday;
             aUserInfomationEN.Identifier1 = aSystemUsers.Identifier1;
             aUserInfomationEN.Identifier1CreatedDate = aSystemUsers.Identifier1CreatedDate;
             aUserInfomationEN.PlaceOfIssue1 = aSystemUsers.PlaceOfIssue1;
             aUserInfomationEN.Image = aSystemUsers.Image;
            // Thong tin cua SystemUserExt
             SystemUserExts aSystemUserExts = aSystemUserExtsBO.Select_ByIDSystemUser(IDSystemUser);
             aUserInfomationEN.aSystemUserExts = aSystemUserExts;

             // Thong tin bang chinh quy
             List<CertificateExtInfoEN> aListCertificateExt_Regular = new List<CertificateExtInfoEN>();
             List<vw__CertificatesInfo__SystemUsers_Certificates> aTemp_Regular = aCertificatesBO.GetRegularCertificate(IDSystemUser);
             CertificateExtInfoEN aCertificateExtInfoEN_Regular;
             for (int i = 0; i < aTemp_Regular.Count; i++)
             { 
                 aCertificateExtInfoEN_Regular = new CertificateExtInfoEN();
                 aCertificateExtInfoEN_Regular.Certificates_Organization = aTemp_Regular[i].Certificates_Organization;
                 aCertificateExtInfoEN_Regular.Certificates_Certificates = aTemp_Regular[i].Certificates_Certificates;
                 if (aTemp_Regular[i].SystemUsers_Certificates_Level == "1")
                 {
                     aCertificateExtInfoEN_Regular.SystemUsers_Certificates_Level = "Giỏi";                 
                 }
                 else if (aTemp_Regular[i].SystemUsers_Certificates_Level == "2")
                 {
                     aCertificateExtInfoEN_Regular.SystemUsers_Certificates_Level = "Khá";
                 }
                 else
                 {
                     aCertificateExtInfoEN_Regular.SystemUsers_Certificates_Level = "Trung bình";
                 }
                 aCertificateExtInfoEN_Regular.SystemUsers_Certificates_CreatedDate = aTemp_Regular[i].SystemUsers_Certificates_CreatedDate;
                 aCertificateExtInfoEN_Regular.SystemUsers_Certificates_ExpirationDate = aTemp_Regular[i].SystemUsers_Certificates_ExpirationDate;
                
                 if (aTemp_Regular[i].SystemUsers_Certificates_TrainingType == "1")
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Chính Quy";
                 }
                 else if (aTemp_Regular[i].SystemUsers_Certificates_TrainingType == "2")
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Tại chức";
                 }
                 else if (aTemp_Regular[i].SystemUsers_Certificates_TrainingType == "3")
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Văn bằng 2";
                 }
                 else if (aTemp_Regular[i].SystemUsers_Certificates_TrainingType == "4")
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Liên thông";
                 }
                 else if (aTemp_Regular[i].SystemUsers_Certificates_TrainingType == "5")
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Chứng chỉ";
                 }
                 else
                 {
                     aCertificateExtInfoEN_Regular.TrainingTypeDisplay = "Từ xa";
                 }
                 
                 aListCertificateExt_Regular.Add(aCertificateExtInfoEN_Regular);
             }
             aUserInfomationEN.aListCertificateExt_Regular = aListCertificateExt_Regular;
             // Thong tin chung chi phu
             List<CertificateExtInfoEN> aListCertificateExt_Sub = new List<CertificateExtInfoEN>();
             List<vw__CertificatesInfo__SystemUsers_Certificates> aTemp_Sub = aCertificatesBO.GetSubCertificate(IDSystemUser);
             CertificateExtInfoEN aCertificateExtInfoEN_Sub;
             for (int i = 0; i < aTemp_Sub.Count; i++)
             {
                 aCertificateExtInfoEN_Sub = new CertificateExtInfoEN();
                 aCertificateExtInfoEN_Sub.Certificates_Organization = aTemp_Sub[i].Certificates_Organization;
                 aCertificateExtInfoEN_Sub.Certificates_Certificates = aTemp_Sub[i].Certificates_Certificates;
                 if (aTemp_Sub[i].SystemUsers_Certificates_Level == "1")
                 {
                     aCertificateExtInfoEN_Sub.SystemUsers_Certificates_Level = "Giỏi";
                 }
                 else if (aTemp_Sub[i].SystemUsers_Certificates_Level == "2")
                 {
                     aCertificateExtInfoEN_Sub.SystemUsers_Certificates_Level = "Khá";
                 }
                 else
                 {
                     aCertificateExtInfoEN_Sub.SystemUsers_Certificates_Level = "Trung bình";
                 }
                 aCertificateExtInfoEN_Sub.SystemUsers_Certificates_CreatedDate = aTemp_Sub[i].SystemUsers_Certificates_CreatedDate;
                 aCertificateExtInfoEN_Sub.SystemUsers_Certificates_ExpirationDate = aTemp_Sub[i].SystemUsers_Certificates_ExpirationDate;
                 aCertificateExtInfoEN_Sub.SystemUsers_Certificates_TrainingType = aTemp_Sub[i].SystemUsers_Certificates_TrainingType;
                 if (aTemp_Sub[i].SystemUsers_Certificates_TrainingType == "1")
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Chính Quy";
                 }
                 else if (aTemp_Sub[i].SystemUsers_Certificates_TrainingType == "2")
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Tại chức";
                 }
                 else if (aTemp_Sub[i].SystemUsers_Certificates_TrainingType == "3")
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Văn bằng 2";
                 }
                 else if (aTemp_Sub[i].SystemUsers_Certificates_TrainingType == "4")
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Liên thông";
                 }
                 else if (aTemp_Sub[i].SystemUsers_Certificates_TrainingType == "5")
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Chứng chỉ";
                 }
                 else
                 {
                     aCertificateExtInfoEN_Sub.TrainingTypeDisplay = "Từ xa";
                 }                 
                 aListCertificateExt_Sub.Add(aCertificateExtInfoEN_Sub);
             }
             aUserInfomationEN.aListCertificateExt_Sub = aListCertificateExt_Sub;
             // Thong tin chung chi Ly luan chinh tri + Quan ly nha nuoc
             List<CertificateExtInfoEN> aListCertificateExt_PoliticGorvenmentManager = new List<CertificateExtInfoEN>();
             List<vw__CertificatesInfo__SystemUsers_Certificates> aTemp_PoliticGorvenmentManager = aCertificatesBO.GetPoliticalGorvenmentManagerCertificate(IDSystemUser);
             CertificateExtInfoEN aCertificateExtInfoEN_PoliticGorvenmentManager;
             for (int i = 0; i < aTemp_PoliticGorvenmentManager.Count; i++)
             {
                 aCertificateExtInfoEN_PoliticGorvenmentManager = new CertificateExtInfoEN();
                 aCertificateExtInfoEN_PoliticGorvenmentManager.Certificates_Organization = aTemp_PoliticGorvenmentManager[i].Certificates_Organization;
                 aCertificateExtInfoEN_PoliticGorvenmentManager.Certificates_Certificates = aTemp_PoliticGorvenmentManager[i].Certificates_Certificates;
                 if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_Level == "1")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_Level = "Giỏi";
                 }
                 else if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_Level == "2")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_Level = "Khá";
                 }
                 else
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_Level = "Trung bình";
                 }
                 aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_CreatedDate = aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_CreatedDate;
                 aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_ExpirationDate = aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_ExpirationDate;
                 aCertificateExtInfoEN_PoliticGorvenmentManager.SystemUsers_Certificates_TrainingType = aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType;
                 if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType == "1")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Chính Quy";
                 }
                 else if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType == "2")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Tại chức";
                 }
                 else if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType == "3")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Văn bằng 2";
                 }
                 else if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType == "4")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Liên thông";
                 }
                 else if (aTemp_PoliticGorvenmentManager[i].SystemUsers_Certificates_TrainingType == "5")
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Chứng chỉ";
                 }
                 else
                 {
                     aCertificateExtInfoEN_PoliticGorvenmentManager.TrainingTypeDisplay = "Từ xa";
                 }                
                 aListCertificateExt_PoliticGorvenmentManager.Add(aCertificateExtInfoEN_PoliticGorvenmentManager);
             }
             aUserInfomationEN.aListCertificateExt_PoliticGorvenmentManager = aListCertificateExt_PoliticGorvenmentManager;
            // Thong tin gia dinh
             List<FamilyMembersExtEN> aListFamilyMembersExtEN = new List<FamilyMembersExtEN>();
             List<FamilyMembers> aTemp_FamilyMembers = aFamilyMembersBO.Select_ByIDSystemUser(IDSystemUser);
             FamilyMembersExtEN aFamilyMembersExtEN;
             for (int i = 0; i < aTemp_FamilyMembers.Count; i++)
             {
                 aFamilyMembersExtEN = new FamilyMembersExtEN();
                 aFamilyMembersExtEN.Name = aTemp_FamilyMembers[i].Name;
                 aFamilyMembersExtEN.Birthday = aTemp_FamilyMembers[i].Birthday;
                 aFamilyMembersExtEN.Info = aTemp_FamilyMembers[i].Info;
                 if (aTemp_FamilyMembers[i].RelationType == 1)
                 {
                     aFamilyMembersExtEN.RelationDisplay = "Bố";
                 }
                 else if (aTemp_FamilyMembers[i].RelationType == 2)
                 {
                     aFamilyMembersExtEN.RelationDisplay = "Mẹ";
                 }
                 else if (aTemp_FamilyMembers[i].RelationType == 3)
                 {
                     aFamilyMembersExtEN.RelationDisplay = "Anh/Chị/Em";
                 }
                 else if (aTemp_FamilyMembers[i].RelationType == 4)
                 {
                     aFamilyMembersExtEN.RelationDisplay = "Con cái";
                 }
                 aListFamilyMembersExtEN.Add(aFamilyMembersExtEN);
             }
             aUserInfomationEN.aListFamilyMembers = aListFamilyMembersExtEN;
            // Thong tin qua trinh cong tac
             aUserInfomationEN.aListAuditHistories = aAuditHistoriesBO.Select_ByIDSystemUser(IDSystemUser);
            // Thong tin khen thuong
             aUserInfomationEN.aListReward = aRewardAndPunishmentsBO.Select_ByIDSystemUser_ByType(IDSystemUser,1);
             // Thong tin khen thuong
             aUserInfomationEN.aListPunishments = aRewardAndPunishmentsBO.Select_ByIDSystemUser_ByType(IDSystemUser, 2);
            // Thong tin giay to #
             aUserInfomationEN.aListDocumentSystemUsers = aDocumentSystemUsersBO.Select_ByIDSystemUser(IDSystemUser);
             frmRpt_SystemUserInfo aReport = new frmRpt_SystemUserInfo(aUserInfomationEN);
             ReportPrintTool tool = new ReportPrintTool(aReport);
             tool.ShowPreview();
        }

      

        

    }


}