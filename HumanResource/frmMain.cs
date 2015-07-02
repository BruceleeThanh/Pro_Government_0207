using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.XtraBars.Helpers;
using DataAccess;
using BussinessLogic;
using Entity;

using System.Threading;
using DevExpress.XtraBars.Docking;
using System.IO;
using System.Globalization;
using CORESYSTEM;


namespace HumanResource
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        // comment 

        public string a = "";
        SystemUsers aSystemUser = new SystemUsers();
        SystemUsersBO aSystemUserBO = new SystemUsersBO();
        RoomsBO aRoomsBO = new RoomsBO();
        frmLogin afrmLogin;
        uc_CurrentUser auc_CurrentUser = new uc_CurrentUser();


        public frmMain(frmLogin afrmLogin)
        {
            InitializeComponent();
            InitSkinGallery();
            this.afrmLogin = afrmLogin;



        }

        void InitSkinGallery()
        {
            //SkinHelper.InitSkinGallery(rgbiSkins, true);

        }

        #region Tabcontrol


        public void LoadUserControl()
        {


            auc_CurrentUser.DataSource = CORE.CURRENTUSER.SystemUser;
            auc_CurrentUser.DataSourceExtend = CORE.CURRENTUSER.SystemUserExts;
            auc_CurrentUser.Dock = DockStyle.Fill;

            dockCurrentUser.Text = dockCurrentUser.Text + " " + CORE.CURRENTUSER.SystemUser.Username;
            panCurrentUser.Controls.Add(auc_CurrentUser);



        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {// dong tab
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }

        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {// Khi add vào thì Focus tới ngay Tab vừa Add
        }

        private void btnView_Click(object sender, EventArgs e)
        {


        }


        #endregion



        private void frmMain_Load(object sender, EventArgs e)
        {
            dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Fill);
            a = DateTime.Today.DayOfWeek + ", ngày " + DateTime.Today.Day + " tháng " + DateTime.Today.Month + " Năm " + DateTime.Today.Year;
            LoadUserControl();

            dtpDate.DateTime = DateTime.Now;

            if (dtpDate.EditValue != null)
            {
                dgvContractsExpiring.DataSource = this.LoadListContractsExpiring(dtpDate.DateTime);
                dgvContractsExpiring.RefreshDataSource();
            }

            dtpEndDate.DateTime = DateTime.Now;
            if(dtpEndDate.EditValue !=null)
            {
                dgvSystemUserLiftSalary.DataSource = this.LoadListInfoSystemUserLiftSalatry(dtpEndDate.DateTime);
                dgvSystemUserLiftSalary.RefreshDataSource();
            }


        }

        //Hiennv
        public List<InfoSystemUserLiftSalaryEN> LoadListInfoSystemUserLiftSalatry(DateTime dateChoose)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                List<InfoSystemUserLiftSalaryEN> aListTemp = aReceptionTaskBO.GetListSystemUserLiftSalary(dateChoose);

                List<InfoSystemUserLiftSalaryEN> aListInfoSystemUserLiftSalaryEN = new List<InfoSystemUserLiftSalaryEN>();
                
                InfoSystemUserLiftSalaryEN aInfoSystemUserLiftSalaryEN;

                foreach (InfoSystemUserLiftSalaryEN item in aListTemp)
                {
                    aInfoSystemUserLiftSalaryEN = new InfoSystemUserLiftSalaryEN();
                    aInfoSystemUserLiftSalaryEN.ID = item.ID;
                    
                    aInfoSystemUserLiftSalaryEN.UserGroup = item.UserGroup;
                    aInfoSystemUserLiftSalaryEN.Email = item.Email;
                    aInfoSystemUserLiftSalaryEN.Username = item.Username;
                    aInfoSystemUserLiftSalaryEN.Name = item.Name;
                    aInfoSystemUserLiftSalaryEN.Password = item.Password;
                    aInfoSystemUserLiftSalaryEN.Birthday = item.Birthday;
                    aInfoSystemUserLiftSalaryEN.Identifier1 = item.Identifier1;
                    aInfoSystemUserLiftSalaryEN.Identifier2 = item.Identifier2;
                    aInfoSystemUserLiftSalaryEN.Identifier3 = item.Identifier3;
                    aInfoSystemUserLiftSalaryEN.Image = item.Image;
                    aInfoSystemUserLiftSalaryEN.Gender = item.Gender;
                    if (item.Gender > 0)
                    {
                        aInfoSystemUserLiftSalaryEN.DisplayGender = CORE.CONSTANTS.SelectedGender(Convert.ToInt32(item.Gender)).Name;
                    }

                    aInfoSystemUserLiftSalaryEN.IDRefAnotherSystem = item.IDRefAnotherSystem;
                    aInfoSystemUserLiftSalaryEN.IDRefMailSystem = item.IDRefMailSystem;
                    aInfoSystemUserLiftSalaryEN.Type = item.Type;
                    aInfoSystemUserLiftSalaryEN.Status = item.Status;
                    aInfoSystemUserLiftSalaryEN.Disable = item.Disable;
                    aInfoSystemUserLiftSalaryEN.Identifier1CreatedDate = item.Identifier1CreatedDate;
                    aInfoSystemUserLiftSalaryEN.Identifier2CreatedDate = item.Identifier2CreatedDate;
                    aInfoSystemUserLiftSalaryEN.Identifier3CreatedDate = item.Identifier3CreatedDate;
                    aInfoSystemUserLiftSalaryEN.PlaceOfIssue1 = item.PlaceOfIssue1;
                    aInfoSystemUserLiftSalaryEN.PlaceOfIssue2 = item.PlaceOfIssue2;
                    aInfoSystemUserLiftSalaryEN.PlaceOfIssue3 = item.PlaceOfIssue3;

                    aInfoSystemUserLiftSalaryEN.SkuTableSalary = item.SkuTableSalary;
                    aInfoSystemUserLiftSalaryEN.Coefficent = item.Coefficent;
                    aInfoSystemUserLiftSalaryEN.SalaryNet = item.SalaryNet;
                    aInfoSystemUserLiftSalaryEN.SalaryCross = item.SalaryCross;
                    aInfoSystemUserLiftSalaryEN.StartDate = item.StartDate;
                    aInfoSystemUserLiftSalaryEN.EndDate = item.EndDate;
                    aListInfoSystemUserLiftSalaryEN.Add(aInfoSystemUserLiftSalaryEN);
                    
                }
                return aListInfoSystemUserLiftSalaryEN;
            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show("frmMain.LoadListContractExpiring\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Hiennv
        public List<ContractsEN> LoadListContractsExpiring(DateTime dateChoose)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                List<ContractsEN> aListTemp = aReceptionTaskBO.GetListContractsExpiring(dateChoose);

                List<ContractsEN> aListContractsEN = new List<ContractsEN>();
                ContractsEN aContractsEN;
                foreach (ContractsEN item in aListTemp)
                {
                    aContractsEN = new ContractsEN();

                    aContractsEN.ID = item.ID;
                    aContractsEN.CreatedDate = item.CreatedDate;
                    aContractsEN.ContractDate = item.ContractDate;
                    aContractsEN.NumberContract = item.NumberContract;
                    aContractsEN.NumberTemplateContract = item.NumberTemplateContract;
                    aContractsEN.IDSystemUser = item.IDSystemUser;
                    aContractsEN.Company = item.Company;
                    aContractsEN.StatutoryRepresent = item.StatutoryRepresent;
                    aContractsEN.StatutoryRepresentGender = item.StatutoryRepresentGender;
                    aContractsEN.StatutoryRepresentIdentifier = item.StatutoryRepresentIdentifier;
                    aContractsEN.ContractType = item.ContractType;
                    if (item.ContractType > 0)
                    {
                        aContractsEN.DisplayContractType = CORE.CONSTANTS.SelectedContractType(Convert.ToInt32(item.ContractType)).Name;
                    }
                   
                    aContractsEN.FromDate = item.FromDate;
                    aContractsEN.ToDate = item.ToDate;
                    aContractsEN.SkuTableSalary = item.SkuTableSalary;
                    aContractsEN.Coefficent = item.Coefficent;
                    aContractsEN.SalaryNet = item.SalaryNet;
                    aContractsEN.SalaryCross = item.SalaryCross;
                    aContractsEN.Type = item.Type;
                    aContractsEN.Status = item.Status;
                    aContractsEN.Disable = item.Disable;

                    aContractsEN.Name = item.Name;
                    aContractsEN.Birthday = item.Birthday;
                    aContractsEN.Identifier1 = item.Identifier1;
                    aContractsEN.Phone = item.Phone;
                    aContractsEN.Gender = item.Gender;
                    if (item.Gender > 0)
                    {
                        aContractsEN.DisplayGender = CORE.CONSTANTS.SelectedGender(Convert.ToInt32(item.Gender)).Name;
                    }

                    aListContractsEN.Add(aContractsEN);
                }
                return aListContractsEN;
            }
            catch (Exception ex)
            {
                return null;
                MessageBox.Show("frmMain.LoadListContractExpiring\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        #region Nhân viên
        private void bnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.ShowDialog();
            this.Close();

        }




        #endregion


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //BookingCaculation.Form1 aCaculation = new BookingCaculation.Form1();
            //aCaculation.Show();
        }

        private void bnCheckIn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void dockPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckIn_Type2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnListCompanies_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnLstAllowance_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLst_Allowances afrm = new frmLst_Allowances();
            afrm.Show();
        }

        private void btnLstSystemUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_SystemUsers afrmLst_SystemUsers = new frmLst_SystemUsers();
                afrmLst_SystemUsers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstSystemUsers_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation = new frmTsk_InsertSystemUser_Infromation();
                afrmTsk_SystemUser_Infromation.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUsers_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnInsSystemUserExts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUserExts_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLstRewardAndPunishments_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_RewardAndPunishments afrmLst_RewardAndPunishments = new frmLst_RewardAndPunishments();
                afrmLst_RewardAndPunishments.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstRewardAndPunishments_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsRewardAndPunishments_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_RewardAndPunishments afrmIns_RewardAndPunishments = new frmIns_RewardAndPunishments();
                afrmIns_RewardAndPunishments.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsRewardAndPunishments_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstAlternateMissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_AlternateMissions afrmLst_AlternateMissions = new frmLst_AlternateMissions();
                afrmLst_AlternateMissions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstAlternateMissions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsAlternateMissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_AlternateMissions afrmIns_AlternateMissions = new frmIns_AlternateMissions();
                afrmIns_AlternateMissions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsAlternateMissions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstCertificates_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Certificates afrmLst_Certificates = new frmLst_Certificates();
                afrmLst_Certificates.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstCertificates_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsCertificates_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Certificates afrmIns_Certificates = new frmIns_Certificates();
                afrmIns_Certificates.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsCertificates_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstTableSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_TableSalaries afrmLst_TableSalaries = new frmLst_TableSalaries();
                afrmLst_TableSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstTableSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsTableSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_TableSalaries afrmIns_TableSalaries = new frmIns_TableSalaries();
                afrmIns_TableSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsTableSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstGroupTableSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_GroupTableSalaries afrmLst_GroupTableSalaries = new frmLst_GroupTableSalaries();
                afrmLst_GroupTableSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstGroupTableSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsGroupTableSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_GroupTableSalaries afrmIns_GroupTableSalaries = new frmIns_GroupTableSalaries();
                afrmIns_GroupTableSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsGroupTableSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstCalculatorSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_CalculatorSalaries afrmLst_CalculatorSalaries = new frmLst_CalculatorSalaries();
                afrmLst_CalculatorSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstCalculatorSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsCalculatorSalaries_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_CalculatorSalaries afrmIns_CalculatorSalaries = new frmIns_CalculatorSalaries();
                afrmIns_CalculatorSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsCalculatorSalaries_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Contracts afrmLst_Contracts = new frmLst_Contracts();
                afrmLst_Contracts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstContracts_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Contracts afrmIns_Contracts = new frmIns_Contracts();
                afrmIns_Contracts.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsContracts_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstAllowances_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Allowances afrmLst_Allowances = new frmLst_Allowances();
                afrmLst_Allowances.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstAllowances_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsAllowances_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Allowance afrmIns_Allowance = new frmIns_Allowance();
                afrmIns_Allowance.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsAllowances_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstDivisions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Divisions afrmLst_Divisions = new frmLst_Divisions();
                afrmLst_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstDivisions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsDivisions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Divisions afrmIns_Divisions = new frmIns_Divisions();
                afrmIns_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsDivisions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstSystemUsers_Divisions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_SystemUsers_Divisions afrmLst_SystemUsers_Divisions = new frmLst_SystemUsers_Divisions();
                afrmLst_SystemUsers_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstSystemUsers_Divisions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUsers_Divisions_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_ChooseSystemUsersToDivisions afrmIns_SystemUsers_Divisions = new frmTsk_ChooseSystemUsersToDivisions();
                afrmIns_SystemUsers_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUsers_Divisions_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation = new frmTsk_InsertSystemUser_Infromation();
                afrmTsk_SystemUser_Infromation.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUser_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstSystemUserPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Permits afrmLst_Permits = new frmLst_Permits();
                afrmLst_Permits.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstSystemUserPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsSystemUserPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Permits afrmIns_Permits = new frmIns_Permits();
                afrmIns_Permits.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUserPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstDetailPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_PermitDetails afrmLst_PermitDetails = new frmLst_PermitDetails();
                afrmLst_PermitDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsSystemUserPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsDetailPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_PermitDetail afrmIns_PermitDetail = new frmIns_PermitDetail();
                afrmIns_PermitDetail.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsDetailPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Permits afrmLst_Permits = new frmLst_Permits();
                afrmLst_Permits.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsPermit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Permits afrmIns_Permits = new frmIns_Permits();
                afrmIns_Permits.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsPermit_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLstConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmLst_Configs afrmLst_Configs = new frmLst_Configs();
                afrmLst_Configs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnLstConfig_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_Configs afrmIns_Configs = new frmIns_Configs();
                afrmIns_Configs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsConfig_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertScaleOfSalary_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmIns_ScaleOfSalaries afrmIns_ScaleOfSalaries = new frmIns_ScaleOfSalaries();
                afrmIns_ScaleOfSalaries.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnInsertScaleOfSalary_ItemClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDate.EditValue != null)
                {

                    dgvContractsExpiring.DataSource = this.LoadListContractsExpiring(dtpDate.DateTime);
                    dgvContractsExpiring.RefreshDataSource();


                    if (grvContractsExpiring.RowCount < 1)
                    {
                        MessageBox.Show("Không có hợp đồng nào sắp hết hạn trong thời gian này .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmMain.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearchSystemUserLiftSalary_Click(object sender, EventArgs e)
        {
            if (dtpEndDate.EditValue != null)
            {
                dgvSystemUserLiftSalary.DataSource = this.LoadListInfoSystemUserLiftSalatry(dtpEndDate.DateTime);
                dgvSystemUserLiftSalary.RefreshDataSource();
                if (grvSystemUserLiftSalary.RowCount < 1)
                {
                    MessageBox.Show("Không có nhân viên nào sắp nâng bậc lương trong thời giàn này .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnContinue_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(grvContractsExpiring.GetFocusedRowCellValue("IDSystemUser"));
            frmIns_Contracts afrmIns_Contracts = new frmIns_Contracts(IDSystemUser,this);
            afrmIns_Contracts.ShowDialog();
        }
        public void ReloadGridView()
        {
            dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Fill);
            a = DateTime.Today.DayOfWeek + ", ngày " + DateTime.Today.Day + " tháng " + DateTime.Today.Month + " Năm " + DateTime.Today.Year;
            LoadUserControl();

            dtpDate.DateTime = DateTime.Now;

            if (dtpDate.EditValue != null)
            {
                dgvContractsExpiring.DataSource = this.LoadListContractsExpiring(dtpDate.DateTime);
                dgvContractsExpiring.RefreshDataSource();
            }

            dtpEndDate.DateTime = DateTime.Now;
            if (dtpEndDate.EditValue != null)
            {
                dgvSystemUserLiftSalary.DataSource = this.LoadListInfoSystemUserLiftSalatry(dtpEndDate.DateTime);
                dgvSystemUserLiftSalary.RefreshDataSource();
            }
        }

        private void btnUpCoe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDSystemUser = Convert.ToInt32(grvSystemUserLiftSalary.GetFocusedRowCellValue("ID"));

            frmIns_CalculatorSalaries afrmIns_CalculatorSalaries = new frmIns_CalculatorSalaries(IDSystemUser, this);
            afrmIns_CalculatorSalaries.ShowDialog();
        }

    }
}