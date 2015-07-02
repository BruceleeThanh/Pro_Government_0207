using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using CORESYSTEM;


namespace SaleManagement
{
    public partial class frmIns_Companies : DevExpress.XtraEditors.XtraForm
    {
        private CompaniesBO aCompaniesBO = new CompaniesBO();

        public frmIns_Companies()
        {
            InitializeComponent();
        }
        private frmLst_Companies afrmLst_Companies_Old = null;
        frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        private int Type = 0;
        int CusType;
        frmMain afrmMain = null;

        public frmIns_Companies(frmTsk_UpdBooking afrmTsk_UpdBooking,int CusType)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.CusType = CusType;
        }
        public frmIns_Companies(frmLst_Companies afrmLst_Companies)
        {
            InitializeComponent();
            afrmLst_Companies_Old = afrmLst_Companies;
        }
        public frmIns_Companies(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers)
        {
            InitializeComponent();
            afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
        }
        public frmIns_Companies(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        public frmIns_Companies(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
        }
        public frmIns_Companies(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên công ty trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("Chọn trạng thái trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    string name = txtName.Text;
                    if (name.Length <= 255)
                    {
                        Companies aCompanies = new Companies();
                        aCompanies.Type = Convert.ToInt32(lueCompanyType.EditValue);
                        aCompanies.Name = name;
                        aCompanies.Status = cboStatus.SelectedIndex + 1;
                        aCompanies.Disable = bool.Parse(cboDisable.Text);
                        aCompaniesBO.Insert(aCompanies);
                        int IDCompany = aCompanies.ID;
                        if (afrmLst_Companies_Old != null)
                        {
                            afrmLst_Companies_Old.ReloadData();
                        }
                        else if (afrmIns_CustomerGroups_Customers_Old != null)
                        {
                            afrmIns_CustomerGroups_Customers_Old.Reload();
                        }
                        else if (afrmTsk_BookingHall_Goverment != null)
                        {
                            afrmTsk_BookingHall_Goverment.ReloadData();
                        }
                        else if (afrmTsk_BookingHall_Group != null)
                        {
                            afrmTsk_BookingHall_Group.ReloadData();
                        }
                        this.Close();
                        MessageBox.Show("Thêm mới thành công .!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        txtName.Focus();
                        MessageBox.Show("Tên công ty chỉ được phép nhập tối đa 255 ký tự .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Companies.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmIns_Companies_Load(object sender, EventArgs e)
        {
            try
            {
                lueCompanyType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes; // Load Type
                lueCompanyType.Properties.DisplayMember = "Name";
                lueCompanyType.Properties.ValueMember = "ID";
                if (afrmTsk_BookingHall_Goverment != null)
                {
                    lueCompanyType.EditValue = CORE.CONSTANTS.SelectedCustomerType(1).ID;
                    lueCompanyType.Enabled = false;
                }
                if (afrmTsk_BookingHall_Group != null)
                {
                    lueCompanyType.EditValue = CORE.CONSTANTS.SelectedCustomerType(2).ID;
                    lueCompanyType.Enabled = false;
                }
                if (afrmTsk_UpdBooking != null)
                {
                    if (CusType == 1)
                    {
                        lueCompanyType.EditValue = CORE.CONSTANTS.SelectedCustomerType(1).ID;
                        lueCompanyType.Enabled = false;
                    }
                    else if (CusType == 2)
                    {
                        lueCompanyType.EditValue = CORE.CONSTANTS.SelectedCustomerType(2).ID;
                        lueCompanyType.Enabled = false;
                    }
                }
                else
                {
                    lueCompanyType.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Companies.frmIns_Companies_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}