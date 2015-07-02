 using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;

namespace SaleManagement
{
    public partial class frmIns_CustomerGroups_Customers : DevExpress.XtraEditors.XtraForm
    {
        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();

        private List<Customers> aListAvailableCustomers = new List<Customers>();
        private List<Customers> aListSelectCustomers = new List<Customers>();
        private List<Customers> aListAdd = new List<Customers>();
        private List<Customers> aListRemove = new List<Customers>();      

        CustomersBO aCustomersBO = new CustomersBO();
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        private int IDCustomerGroup = 0;
        private string NameCustomerGroup;
        private string NameCompany;

        public frmIns_CustomerGroups_Customers()
        {
            InitializeComponent();

        }
        public frmIns_CustomerGroups_Customers(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups_Customers(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups_Customers(frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer = afrmTsk_BookingHall_Customer;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups_Customers(frmTsk_UpdBooking afrmTsk_UpdBooking, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        //function LoadDataSelectCustomers
        public void LoadDataSelectCustomers()
        {
            try
            {
                dgvSelectCustomers.DataSource = aListSelectCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.LoadDataSelectCustomers\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //LoadDataAvailableCustomers
        public void LoadDataAvailableCustomers()
        {
            try
            {

                aListAvailableCustomers = aCustomersBO.Select_All();
                dgvAvailableCustomers.DataSource = aListAvailableCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.LoadDataAvailableCustomers\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void frmAddListCustomerToCustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {               
                if (IDCustomerGroup == 0)
                {
                    LoadIDCompanies();
                    LoadDataAvailableCustomers();
                }
                else
                {
                    LoadDataAvailableCustomers();
                    aListSelectCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    LoadDataSelectCustomers();

                    lueCompany.Properties.NullText = NameCompany;
                    lueCustomerGroup.Properties.NullText = NameCustomerGroup;
                    lueCompany.Properties.ReadOnly = true;
                    lueCustomerGroup.Properties.ReadOnly = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.frmAddListCustomerToCustomerGroups_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void Reload()
        {
            LoadIDCompanies();
            LoadDataAvailableCustomers();
            dgvAvailableCustomers.RefreshDataSource();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Customers afrmIns_Customers = new frmIns_Customers(this);
                afrmIns_Customers.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnAddCustomer_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Customers aCustomers = new Customers();
                int ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
                aCustomers.ID = ID;
                aCustomers.Name = viewAvailableCustomers.GetFocusedRowCellValue("Name").ToString();
                aCustomers.Identifier1 = viewAvailableCustomers.GetFocusedRowCellValue("Identifier1").ToString();
                aCustomers.Birthday = Convert.ToDateTime(viewAvailableCustomers.GetFocusedRowCellValue("Birthday"));


                List<Customers> aList = aListSelectCustomers.Where(c => c.ID == ID).ToList();
                if (aList.Count > 0)
                {
                    MessageBox.Show("Khách đã có ở trong phòng vui lòng chọn người khác.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    aListSelectCustomers.Insert(0, aCustomers);
                    aListAdd.Add(aCustomers);
                    dgvSelectCustomers.DataSource = aListSelectCustomers;
                    dgvSelectCustomers.RefreshDataSource();
                }
                List<Customers> aListTemps = aListAvailableCustomers.Where(c => c.ID == Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"))).ToList();
                if (aListTemps.Count > 0)
                {
                    Customers Temps = aListAvailableCustomers.Where(c => c.ID == Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"))).ToList()[0];
                    aListAvailableCustomers.Remove(Temps);
                }
                dgvAvailableCustomers.DataSource = aListAvailableCustomers;
                dgvAvailableCustomers.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnSelectCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSelectCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Customers aCustomers = new Customers();

                aCustomers.ID = Convert.ToInt32(viewSelectCustomers.GetFocusedRowCellValue("ID"));
                aCustomers.Name = viewSelectCustomers.GetFocusedRowCellValue("Name").ToString();
                aCustomers.Identifier1 = viewSelectCustomers.GetFocusedRowCellValue("Identifier1").ToString();
                aCustomers.Birthday = Convert.ToDateTime(viewSelectCustomers.GetFocusedRowCellValue("Birthday"));

                aListAvailableCustomers.Insert(0, aCustomers);
                aListRemove.Add(aCustomers);
                dgvAvailableCustomers.DataSource = aListAvailableCustomers;
                dgvAvailableCustomers.RefreshDataSource();



                Customers Temps = aListSelectCustomers.Where(c => c.ID == Convert.ToInt32(viewSelectCustomers.GetFocusedRowCellValue("ID").ToString())).ToList()[0];
                aListSelectCustomers.Remove(Temps);
                dgvSelectCustomers.DataSource = aListSelectCustomers;
                dgvSelectCustomers.RefreshDataSource();


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnRemoveSelectCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
                frmUpd_Customers afrmUpd_Customers = new frmUpd_Customers(this, ID);
                afrmUpd_Customers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnEditCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerGroups_CustomersBO aCustomerGroupsCustomersBO = new CustomerGroups_CustomersBO();

                if (aListRemove.Count > 0)
                {
                    foreach (Customers item in aListRemove)
                    {
                        List<CustomerGroups_Customers> count = aCustomerGroupsCustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(item.ID, IDCustomerGroup);
                        if (count.Count > 0)
                        {
                            aCustomerGroupsCustomersBO.Delete(item.ID, IDCustomerGroup);
                        }
                    }                

                }
                if (aListAdd.Count > 0)
                {
                    foreach (Customers item in aListAdd)
                    {
                        List<CustomerGroups_Customers> list = aCustomerGroupsCustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(item.ID, IDCustomerGroup);
                        if (list.Count < 1)
                        {
                            CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
                            string name = (NameCustomerGroup + "_" + item.Name).Length > 150 ? (NameCustomerGroup + "_" + item.Name).Substring(0, 250) : (NameCustomerGroup + "_" + item.Name);
                            aCustomerGroups_Customers.Name = name;
                            aCustomerGroups_Customers.IDCustomer = item.ID;
                            aCustomerGroups_Customers.IDCustomerGroup = IDCustomerGroup;
                            aCustomerGroupsCustomersBO.Insert(aCustomerGroups_Customers);
                        }
                    }                 
                }
                if (afrmTsk_BookingHall_Goverment != null)
                {
                    afrmTsk_BookingHall_Goverment.CallBackIDCustomer(aListSelectCustomers);
                }
                if (afrmTsk_BookingHall_Group != null)
                {
                    afrmTsk_BookingHall_Group.CallBackIDCustomer(aListSelectCustomers);
                }
                if (afrmTsk_BookingHall_Customer != null)
                {
                    afrmTsk_BookingHall_Customer.CallBackIDCustomer(aListSelectCustomers);
                }
                  
                if (afrmTsk_UpdBooking != null)
                {
                    afrmTsk_UpdBooking.CallBackIDCustomer(aListSelectCustomers);
                }
                MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnApply_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void LoadIDCompanies()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                lueCompany.Properties.DataSource = aCompaniesBO.Select_All();// [Company] Type = 2 : Công ty ngoài, 2; 
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.LoadIDCompanies\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //LoadData IDCustomerGroup
        public void LoadIDCustomerGroups()
        {
            try
            {

                int IDCompany = Convert.ToInt32(lueCompany.EditValue.ToString());
                List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                lueCustomerGroup.Properties.DataSource = aListCustomerGroups;
                lueCustomerGroup.Properties.DisplayMember = "Name";
                lueCustomerGroup.Properties.ValueMember = "ID";
                if (aListCustomerGroups.Count > 0)
                {
                    lueCustomerGroup.EditValue = aListCustomerGroups.ToList()[0].ID;
                }
                else
                {
                    lueCustomerGroup.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.LoadIDCustomerGroups\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //CallBackIDCompany
        public void CallBackIDCompany(int IDCompany)
        {
            try
            {
                lueCompany.EditValue = IDCompany;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.CallBackIDCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Call Back data IDCustomerGroup
        public void CallBackIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                lueCustomerGroup.EditValue = IDCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.CallBackIDCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Reload


        private void btnAddCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Companies afrmIns_Company = new frmIns_Companies(this);
                afrmIns_Company.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.btnAddCompanies_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies(this);
                afrmLst_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.btnSearchCompanies_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomerGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueCompany.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompany = Convert.ToInt32(lueCompany.EditValue.ToString());
                    frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups(this, IDCompany, NameCompany);
                    afrmIns_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.btnAddCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomerGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCompany = lueCompany.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCompany = Convert.ToInt32(lueCompany.EditValue.ToString());
                    frmLst_CustomerGroups afrmLst_CustomerGroups = new frmLst_CustomerGroups(this, IDCompany);
                    afrmLst_CustomerGroups.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmIns_CustomerGroups_Customers.btnSearchCustomerGroups_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadIDCustomerGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.lueIDCompanies_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCustomerGroup_EditValueChanged(object sender, EventArgs e)
        {
            IDCustomerGroup = Convert.ToInt32(lueCustomerGroup.EditValue);
            aListSelectCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
            LoadDataSelectCustomers();
        }
    }
}