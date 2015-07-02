using System;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using System.Collections.Generic;
using Entity;



namespace RoomManager
{
    public partial class frmTsk_CheckIn_Customer_Step2 : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_CheckIn_Customer_Step1 afrm_Tsk_CheckIn_Customer_Step1_Old;
        private CheckInEN aCheckInEN_Old;

        public frmTsk_CheckIn_Customer_Step2(frmTsk_CheckIn_Customer_Step1 afrm_Tsk_CheckIn_Customer_Step1)
        {
            InitializeComponent();
        }
        public frmTsk_CheckIn_Customer_Step2(frmTsk_CheckIn_Customer_Step1 afrm_Tsk_CheckIn_Customer_Step1, CheckInEN aCheckInEN)
        {
            InitializeComponent();
            afrm_Tsk_CheckIn_Customer_Step1_Old = afrm_Tsk_CheckIn_Customer_Step1;
            aCheckInEN_Old = aCheckInEN;
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void CallBackIDCompany(int IDCompany)
        {
            try
            {
                lueIDCompany.EditValue = IDCompany;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewBookingRs_Goverment.CallBackIDCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCompany()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                List<Companies> aListCompanies = aCompaniesBO.Select_ByType(3);// [Company] Type = 3;
                lueIDCompany.Properties.DataSource = aListCompanies;
                lueIDCompany.Properties.DisplayMember = "Name";
                lueIDCompany.Properties.ValueMember = "ID";
                if(aListCompanies.Count > 0)
                {
                    lueIDCompany.EditValue = aListCompanies[0].ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewBookingRs_Goverment.LoadCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadCustomerGroup()
        {
            try
            {
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();

                int IDCompany = Convert.ToInt32(lueIDCompany.EditValue.ToString());
                List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                lueIDCustomerGroup.Properties.DataSource = aListCustomerGroups;
                lueIDCustomerGroup.Properties.DisplayMember = "Name";
                lueIDCustomerGroup.Properties.ValueMember = "ID";               

                if (aListCustomerGroups.Count > 0)
                {
                    lueIDCustomerGroup.EditValue = aListCustomerGroups.ToList()[0].ID;
                    //if (aListCustomerGroups.Where(a => a.Name == lueIDCompany.Text + " " + DateTime.Now.ToShortDateString() + "" + txtSubject.Text).ToList().Count > 0)
                    //{
                    //    lueIDCustomerGroup.EditValue = aListCustomerGroups.Where(a => a.Name == lueIDCompany.Text + "" + DateTime.Now.ToShortDateString() + "" + txtSubject.Text).ToList()[0].ID;
                    //}
                    //else
                    //{
                    //    CustomerGroups aTemp = new CustomerGroups();
                    //    aTemp.IDCompany = IDCompany;
                    //    aTemp.Name = lueIDCompany.Text + "" + DateTime.Now.ToShortDateString() + "" + txtSubject.Text;
                    //    aTemp.Status = 1;
                    //    aTemp.Type = 1;
                    //    aTemp.Disable = false;                        
                    //    int IDaTemp= aCustomerGroupsBO.Insert(aTemp);
                    //    lueIDCustomerGroup.EditValue = IDaTemp;
                    //}
                }
                else
                {
                    lueIDCustomerGroup.EditValue = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddNewBookingRs_Goverment.LoadCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadCustomers()
        {
            try
            {
                CustomersBO aCustomerBO = new CustomersBO();
                int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroup.EditValue);
                List<Customers> aListCustomer = aCustomerBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                lueIDCustomer.Properties.DataSource = aListCustomer;
                lueIDCustomer.Properties.DisplayMember = "Name";
                lueIDCustomer.Properties.ValueMember = "ID";

                if (aListCustomer.Count > 0)
                {
                    lueIDCustomer.EditValue = aListCustomer.ToList()[0].ID;
                }
                else
                {
                    lueIDCustomer.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.LoadCustomers\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CallBackIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                lueIDCustomerGroup.EditValue = IDCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.CallBackIDCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CallBackIDCustomer(int IDCustomer)
        {
            try
            {
                lueIDCustomer.EditValue = IDCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.CallBackIDCustomer\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frm_Tsk_CheckIn_Customer_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.frm_Tsk_CheckIn_Customer_Step2_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                else if (Convert.ToInt32(lueIDCompany.EditValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn tên công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Convert.ToInt32(lueIDCustomerGroup.EditValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn tên nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (Convert.ToInt32(lueIDCustomer.EditValue) == 0)
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


        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    aCheckInEN_Old.Subject = txtSubject.Text;
                    aCheckInEN_Old.Description = txaDescription.Text;
                    aCheckInEN_Old.Note = txaNote.Text;
                    aCheckInEN_Old.BookingMoney = String.IsNullOrEmpty(txtBookingMoney.Text) == true ? 0 : Convert.ToDecimal(txtBookingMoney.Text);
                    aCheckInEN_Old.IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroup.EditValue.ToString());
                    aCheckInEN_Old.IDCustomer = Convert.ToInt32(lueIDCustomer.EditValue.ToString());
                    frmTsk_CheckIn_Customer_Step3 afrm_Tsk_CheckIn_Customer_Step3 = new frmTsk_CheckIn_Customer_Step3(this, aCheckInEN_Old);
                    afrm_Tsk_CheckIn_Customer_Step3.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.btnNext_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void lueIDCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCustomerGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.lueCompany_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomerGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompany.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompany = Convert.ToInt32(lueIDCompany.EditValue);
                    frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups(this, IDCompany, NameCompany);
                    afrmIns_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.btnAddCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomerGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueIDCompany.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueIDCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompany = Convert.ToInt32(lueIDCompany.EditValue.ToString());
                    frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups(this, IDCompany);
                    afrmLst_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.btnSearchCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroup.Text;
                string NameCompany = lueIDCompany.Text;
                if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroup.EditValue);
                    frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers(this, IDCustomerGroup, NameCustomerGroup, NameCompany);
                    afrmIns_CustomerGroups_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.btnAddCustomer_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueIDCustomerGroup.Text;
                string NameCompnay = lueIDCompany.Text;

                if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueIDCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueIDCustomerGroup.EditValue.ToString());
                    frmLst_Customers afrmLst_Customers = new frmLst_Customers(this, IDCustomerGroup);
                    afrmLst_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.btnSearchCustomer_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lueIDCustomerGroup_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frm_Tsk_CheckIn_Customer_Step2.lueIDCustomerGroup_EditValueChanged\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}