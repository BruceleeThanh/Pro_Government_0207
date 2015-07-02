using System;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_CheckIn_Goverment_Step2 : DevExpress.XtraEditors.XtraForm
    {

        public frmTsk_CheckIn_Goverment_Step1 afrmTsk_CheckIn_Goverment_Step1 = null;
        private CheckInEN aCheckInEN = new CheckInEN();
        public List<BookingRooms> aList_IDBookingRooms = new List<BookingRooms>();

        public frmTsk_CheckIn_Goverment_Step2(frmTsk_CheckIn_Goverment_Step1 afrmTsk_CheckIn_Goverment_Step1, CheckInEN aCheckInEn)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step1 = afrmTsk_CheckIn_Goverment_Step1;
            this.aCheckInEN = aCheckInEn;
        }
        //Call Back Id Company
        public void CallBackIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                lueIDCustomerGroups.EditValue = IDCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.CallBackIDCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Call Back data IDCustomer
        public void CallBackIDCustomer(int IDCustomer)
        {
            try
            {
                lueIDCustomers.EditValue = IDCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.CallBackIDCustomer\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Load IDCompany
        public void LoadIDCompanies()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                List<Companies> aListCompanies = aCompaniesBO.Select_ByType(1);// [Company] Type = 1 : Nha nuoc, 1; 
                lueIDCompanies.Properties.DataSource = aListCompanies;
                lueIDCompanies.Properties.DisplayMember = "Name";
                lueIDCompanies.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.LoadIDCompanies\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CallBackIDCompany
        public void CallBackIDCompany(int IDCompany)
        {
            try
            {
                lueIDCompanies.EditValue = IDCompany;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.CallBackIDCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //LoadData IDCustomerGroup
        public void LoadIDCustomerGroups()
        {
            try
            {
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                int IDCompany = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                lueIDCustomerGroups.Properties.DataSource = aListCustomerGroups;
                lueIDCustomerGroups.Properties.DisplayMember = "Name";
                lueIDCustomerGroups.Properties.ValueMember = "ID";
                if (aListCustomerGroups.Count > 0)
                {
                    lueIDCustomerGroups.EditValue = aListCustomerGroups.ToList()[0].ID;
                }
                else
                {
                    lueIDCustomerGroups.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.LoadIDCustomerGroups\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Load IDCustomers 
        public void LoadIDCustomers()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                int IDCustomerGroup = Int32.Parse(lueIDCustomerGroups.EditValue.ToString());
                List<Customers> aListCustomer = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                lueIDCustomers.Properties.DataSource = aListCustomer;
                lueIDCustomers.Properties.DisplayMember = "Name";
                lueIDCustomers.Properties.ValueMember = "ID";

                if (aListCustomer.Count > 0)
                {
                    lueIDCustomers.EditValue = aListCustomer.ToList()[0].ID;
                }
                else
                {
                    lueIDCustomers.EditValue = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.LoadIDCustomers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueIDCompanies_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIDCustomerGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.lueIDCompanies_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueIDCustomerGroups_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIDCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.lueIDCustomerGroups_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies(this, 1);//1:Nha nuoc
                afrmLst_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.bt_BookingRs_Search_Company_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomerGroups_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompanies.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompnay = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                    frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups(this, IDCompnay, NameCompany);
                    afrmIns_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btnAddCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Companies afrmIns_Companies = new frmIns_Companies(this);//1:Nha nuoc
                afrmIns_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btnCompanies_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomerGroups_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompanies.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompnay = Convert.ToInt32(lueIDCompanies.EditValue.ToString());
                    frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups(this, IDCompnay);
                    afrmLst_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btnSearchCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroups.Text;
                string NameCompnay = lueIDCompanies.Text;
                if (NameCompnay.Equals("--- Chọn lựa ---") || NameCompnay.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers(this, IDCustomerGroup, NameCustomerGroup, NameCompnay);
                    afrmIns_CustomerGroups_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btnAddCustomers_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroups.Text;
                string NameCompnay = lueIDCompanies.Text;
                if (NameCompnay.Equals("--- Chọn lựa ---") || NameCompnay.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompanies.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    frmLst_Customers afrmLst_Customers = new frmLst_Customers(this, IDCustomerGroup);
                    afrmLst_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btnSearchCustomers_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            try
            {
                if (txaDescription.Text.Length > 250)
                {
                    txaDescription.Focus();
                    MessageBox.Show("Mô tả chỉ được phép nhập tối đa là 250 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (txaNote.Text.Length > 250)
                {
                    txaNote.Focus();
                    MessageBox.Show("Ghi chú chỉ được phép nhập tối đa là 250 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Convert.ToInt32(lueIDCompanies.EditValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn tên công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Convert.ToInt32(lueIDCustomerGroups.EditValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn tên nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Convert.ToInt32(lueIDCustomers.EditValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn tên người đại diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.ValidateData\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void btNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    aCheckInEN.Subject = txtSubject.Text;
                    aCheckInEN.Level = Convert.ToInt32(lueLevel.EditValue);
                    aCheckInEN.Description = txaDescription.Text;
                    aCheckInEN.Note = txaNote.Text;
                    aCheckInEN.BookingMoney = String.IsNullOrEmpty(txtBookingMoney.Text) == true ? 0 : Convert.ToDecimal(txtBookingMoney.Text);
                    aCheckInEN.IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroups.EditValue.ToString());
                    aCheckInEN.IDCustomer = Convert.ToInt32(lueIDCustomers.EditValue.ToString());
                    frmTsk_CheckIn_Goverment_Step3 afrmTsk_CheckIn_Goverment_Step3 = new frmTsk_CheckIn_Goverment_Step3(this, aCheckInEN);
                    afrmTsk_CheckIn_Goverment_Step3.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.btNext_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_CheckIn_Goverment_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                lueLevel.Properties.DataSource = CORE.CONSTANTS.ListLevels.Where(l=>l.ID <13).ToList();
                lueLevel.Properties.DisplayMember = "Name";
                lueLevel.Properties.ValueMember = "ID";
                lueLevel.EditValue = CORE.CONSTANTS.SelectedLevel(11).ID;

                this.LoadIDCompanies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn_Goverment_Step2.frmTsk_CheckIn_Goverment_Step2_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}