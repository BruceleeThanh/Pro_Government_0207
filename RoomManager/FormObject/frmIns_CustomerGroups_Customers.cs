using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;

namespace RoomManager
{
    public partial class frmIns_CustomerGroups_Customers : DevExpress.XtraEditors.XtraForm
    {
        #region Room
        

        private List<Customers> aListAvailableCustomers = new List<Customers>();
        private List<Customers> aListSelectCustomers = new List<Customers>();
        private List<Customers> aListAdd = new List<Customers>();
        private List<Customers> aListRemove = new List<Customers>();

        private frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2 = null;
        private frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2 = null;
        private frmTsk_CheckIn_Customer_Step2 afrm_Tsk_CheckIn_Customer_Step2 = null;

        private frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2 = null;
        private frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2 = null;

        private frmTsk_Booking_Step2 afrmTsk_Booking_Step2 = null;

        
        private int IDCustomerGroup = 0;
        private string NameCustomerGroup;
        private string NameCompany;

        public frmIns_CustomerGroups_Customers()
        {
            InitializeComponent();

        }

        public frmIns_CustomerGroups_Customers(frmTsk_CheckIn_Goverment_Step2 afrmTsk_CheckIn_Goverment_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Goverment_Step2 = afrmTsk_CheckIn_Goverment_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups_Customers(frmTsk_CheckIn_Group_Step2 afrmTsk_CheckIn_Group_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_CheckIn_Group_Step2 = afrmTsk_CheckIn_Group_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        //hiennv
        public frmIns_CustomerGroups_Customers(frmTsk_CheckInCustomer_ForRoomBooking_Step2 afrmTsk_CheckInCustomer_ForRoomBooking_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 = afrmTsk_CheckInCustomer_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        //hiennv
        public frmIns_CustomerGroups_Customers(frmTsk_CheckInGoverment_ForRoomBooking_Step2 afrmTsk_CheckInGoverment_ForRoomBooking_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 = afrmTsk_CheckInGoverment_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }
        //hiennv
        public frmIns_CustomerGroups_Customers(frmTsk_CheckInGroup_ForRoomBooking_Step2 afrmTsk_CheckInGroup_ForRoomBooking_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 = afrmTsk_CheckInGroup_ForRoomBooking_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }

        public frmIns_CustomerGroups_Customers(frmTsk_CheckIn_Customer_Step2 afrm_Tsk_CheckIn_Customer_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrm_Tsk_CheckIn_Customer_Step2 = afrm_Tsk_CheckIn_Customer_Step2;
            this.IDCustomerGroup = IDCustomerGroup;
            this.NameCustomerGroup = NameCustomerGroup;
            this.NameCompany = NameCompany;
        }



        public frmIns_CustomerGroups_Customers(frmTsk_Booking_Step2 afrmTsk_Booking_Step2, int IDCustomerGroup, string NameCustomerGroup, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_Booking_Step2 = afrmTsk_Booking_Step2;
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
                aListAvailableCustomers.Clear();
                CustomersBO aCustomersBO = new CustomersBO();
                aListAvailableCustomers = aCustomersBO.Select_All();
                dgvAvailableCustomers.DataSource = aListAvailableCustomers;
                dgvAvailableCustomers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.LoadDataAvailableCustomers\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        //hiennv
        private void frmAddListCustomerToCustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.afrmTsk_CheckIn_Goverment_Step2 != null || this.afrmTsk_CheckIn_Group_Step2 != null || this.afrm_Tsk_CheckIn_Customer_Step2 != null || this.afrmTsk_Booking_Step2 != null)
                {
                    this.LoadDataAvailableCustomers();
                    CustomersBO aCustomersBO = new CustomersBO();
                    this.aListSelectCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    this.LoadDataSelectCustomers();

                    lueCompany.Properties.NullText = NameCompany;
                    lueCustomerGroup.Properties.NullText = NameCustomerGroup;
                    lueCompany.Properties.ReadOnly = true;
                    lueCustomerGroup.Properties.ReadOnly = true;

                    btnAddCompanies.Visible = false;
                    btnSearchCompany.Visible = false;
                    btnAddCustomerGroup.Visible = false;
                    btnSearchCustomerGroup.Visible = false;
                }
                else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null || this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null || this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 != null)
                {
                    this.LoadDataAvailableCustomers();
                    CustomersBO aCustomersBO = new CustomersBO();
                    this.aListSelectCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                    this.LoadDataSelectCustomers();

                    lueCompany.Properties.NullText = NameCompany;
                    lueCustomerGroup.Properties.NullText = NameCustomerGroup;
                    lueCompany.Properties.ReadOnly = true;
                    lueCustomerGroup.Properties.ReadOnly = true;

                    btnAddCompanies.Visible = false;
                    btnSearchCompany.Visible = false;
                    btnAddCustomerGroup.Visible = false;
                    btnSearchCustomerGroup.Visible = false;
                }
                else
                {
                    this.LoadIDCompanies();
                    this.LoadDataAvailableCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.frmAddListCustomerToCustomerGroups_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //hiennv
        public void Reload()
        {
            this.LoadIDCompanies();
            this.LoadDataAvailableCustomers();
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
                DateTime? dateTime = null;

                Customers aCustomers = new Customers();
                int ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
                aCustomers.ID = ID;
                aCustomers.Name = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Name"));
                aCustomers.Identifier1 = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Identifier1"));
                aCustomers.Birthday = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(viewAvailableCustomers.GetFocusedRowCellValue("Birthday"));


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
                DateTime? dateTime = null;
                Customers aCustomers = new Customers();

                aCustomers.ID = Convert.ToInt32(viewSelectCustomers.GetFocusedRowCellValue("ID"));
                aCustomers.Name = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Name"));
                aCustomers.Identifier1 = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Identifier1"));
                aCustomers.Birthday = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(viewSelectCustomers.GetFocusedRowCellValue("Birthday"));

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
        //hiennv
        private bool CheckDataBeforeApply()
        {
            try
            {
                if (String.IsNullOrEmpty(lueCompany.Text) == true)
                {
                    lueCompany.Focus();
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if(String.IsNullOrEmpty(lueCustomerGroup.Text))
                {
                    lueCustomerGroup.Focus();
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.aListSelectCustomers.Count <= 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng vào nhóm .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.CheckDataBeforeApply\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //hiennv
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckDataBeforeApply() == true)
                {

                    CustomerGroups_CustomersBO aCustomerGroupsCustomersBO = new CustomerGroups_CustomersBO();

                    if (aListRemove.Count > 0)
                    {
                        foreach (Customers item in aListRemove)
                        {
                            CustomerGroups_Customers aCustomerGroups_Customers = aCustomerGroupsCustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(item.ID, IDCustomerGroup);
                            if (aCustomerGroups_Customers != null)
                            {
                                aCustomerGroupsCustomersBO.Delete(item.ID, IDCustomerGroup);
                            }
                        }
                        if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Goverment_Step2.LoadIDCustomers();
                        }
                        else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Group_Step2.LoadIDCustomers();
                        }
                        else if (this.afrm_Tsk_CheckIn_Customer_Step2 != null)
                        {
                            this.afrm_Tsk_CheckIn_Customer_Step2.LoadCustomers();
                        }
                        else if (this.afrmTsk_Booking_Step2 != null)
                        {
                            this.afrmTsk_Booking_Step2.LoadIDCustomers();
                        }
                        else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.LoadCustomers();
                            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                      
                    }
                    if (aListAdd.Count > 0)
                    {
                        CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
                        foreach (Customers item in aListAdd)
                        {
                            aCustomerGroups_Customers = aCustomerGroupsCustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(item.ID, IDCustomerGroup);
                            if (aCustomerGroups_Customers != null)
                            {
                                
                                string name = (NameCustomerGroup + "_" + item.Name).Length > 150 ? (NameCustomerGroup + "_" + item.Name).Substring(0, 150) : (NameCustomerGroup + "_" + item.Name);
                                aCustomerGroups_Customers.Name = name;
                                aCustomerGroups_Customers.IDCustomer = item.ID;
                                aCustomerGroups_Customers.IDCustomerGroup = IDCustomerGroup;
                                aCustomerGroupsCustomersBO.Insert(aCustomerGroups_Customers);
                            }
                        }
                        if (this.afrmTsk_CheckIn_Goverment_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Goverment_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckIn_Goverment_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckIn_Group_Step2 != null)
                        {
                            this.afrmTsk_CheckIn_Group_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckIn_Group_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrm_Tsk_CheckIn_Customer_Step2 != null)
                        {
                            this.afrm_Tsk_CheckIn_Customer_Step2.LoadCustomers();
                            this.afrm_Tsk_CheckIn_Customer_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_Booking_Step2 != null)
                        {
                            this.afrmTsk_Booking_Step2.LoadIDCustomers();
                            this.afrmTsk_Booking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckInGoverment_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckInGroup_ForRoomBooking_Step2 != null)
                        {
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.LoadIDCustomers();
                            this.afrmTsk_CheckInGroup_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2!= null)
                        {
                            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.LoadCustomers();
                            this.afrmTsk_CheckInCustomer_ForRoomBooking_Step2.CallBackIDCustomer(aListAdd[0].ID);
                        }
                        else if (afrmTsk_BookingHall_Goverment != null)
                        {
                            afrmTsk_BookingHall_Goverment.CallBackIDCustomer(aListSelectCustomers);
                        }
                        else if (afrmTsk_BookingHall_Group != null)
                        {
                            afrmTsk_BookingHall_Group.CallBackIDCustomer(aListSelectCustomers);
                        }
                        else if (afrmTsk_BookingHall_Customer != null)
                        {
                            afrmTsk_BookingHall_Customer.CallBackIDCustomer(aListSelectCustomers);
                        }

                        else if (afrmTsk_UpdBooking != null)
                        {
                            afrmTsk_UpdBooking.CallBackIDCustomer(aListSelectCustomers);
                        }
                    }
                    this.Close();
                    MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                lueCompany.Properties.DataSource = aCompaniesBO.Select_All();
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
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
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
                if (String.IsNullOrEmpty(lueCompany.Text)==true)
                {
                    lueCompany.Focus();
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
                if (String.IsNullOrEmpty(lueCompany.Text)== true)
                {
                    lueCompany.Focus();
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
                this.LoadIDCustomerGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups_Customers.lueIDCompanies_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCustomerGroup_EditValueChanged(object sender, EventArgs e)
        {
            IDCustomerGroup = Convert.ToInt32(lueCustomerGroup.EditValue);
            CustomersBO aCustomersBO = new CustomersBO();
            aListSelectCustomers = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
            this.LoadDataSelectCustomers();
        }
        #endregion
        #region Sale
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
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

        #endregion
    }
}