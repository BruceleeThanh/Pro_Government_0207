using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using DevExpress.XtraRichEdit.API.Word;
using System.Collections.Generic;

namespace SaleManagement
{
    public partial class frmIns_CustomerGroups : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_CustomerGroups afrmLst_CustomerGroups_Old=null;
        frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment_Old = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        private int IDCompany;
        private string NameCompany;

        public frmIns_CustomerGroups()
        {
            InitializeComponent();
        }        
        public frmIns_CustomerGroups(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers, int IDCompany, string NameCompany)
        {
            InitializeComponent();
            afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
            this.IDCompany = IDCompany;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups(frmLst_CustomerGroups afrmLst_CustomerGroups)
        {
            InitializeComponent();
            afrmLst_CustomerGroups_Old = afrmLst_CustomerGroups;
        }
        public frmIns_CustomerGroups(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int IDCompany, string NameCompany)
        {
            InitializeComponent();
            afrmTsk_BookingHall_Goverment_Old = afrmTsk_BookingHall_Goverment;
            this.IDCompany = IDCompany;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group, int IDCompany, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
            this.IDCompany = IDCompany;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups(frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer, int IDCompany, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer = afrmTsk_BookingHall_Customer;
            this.IDCompany = IDCompany;
            this.NameCompany = NameCompany;
        }
        public frmIns_CustomerGroups(frmTsk_UpdBooking afrmTsk_UpdBooking, int IDCompany, string NameCompany)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.IDCompany = IDCompany;
            this.NameCompany = NameCompany;
        }

        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên nhóm trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboType.Text == "")
            {
                MessageBox.Show("Chọn loại nhóm trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cboStatus.Text == "")
            {
                MessageBox.Show("Chọn trạng thái nhóm trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                    CustomerGroups aCustomerGroups = new CustomerGroups();
                    aCustomerGroups.IDCompany = Convert.ToInt32(lueCompany.EditValue);
                    aCustomerGroups.Name = txtName.Text;
                    aCustomerGroups.Type = cboType.SelectedIndex + 1;
                    aCustomerGroups.Status = cboStatus.SelectedIndex + 1;
                    aCustomerGroups.Disable = bool.Parse(cboDisable.Text);
                    aCustomerGroupsBO.Insert(aCustomerGroups);

                    if (this.afrmLst_CustomerGroups_Old != null)
                    {
                        afrmLst_CustomerGroups_Old.ReloadData();
                    }
                    else if (afrmIns_CustomerGroups_Customers_Old != null)
                    {
                        afrmIns_CustomerGroups_Customers_Old.Reload();
                    }
                    else if (afrmTsk_BookingHall_Goverment_Old != null)
                    {
                        afrmTsk_BookingHall_Goverment_Old.ReloadData();
                    }
                    else if (afrmTsk_BookingHall_Group != null)
                    {
                        this.afrmTsk_BookingHall_Group.ReloadData();
                    }
                    else if (afrmTsk_BookingHall_Customer != null)
                    {
                        this.afrmTsk_BookingHall_Customer.ReloadData();
                    }
                    else if (afrmTsk_UpdBooking != null)
                    {
                        this.afrmTsk_UpdBooking.ReloadData();
                    }
                    this.Close();
                    MessageBox.Show("Thêm mới thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups.btnAddNew_Click\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmIns_CustomerGroups_Load(object sender, EventArgs e)
        {

            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                List<Companies> aListCompanies = aCompaniesBO.Select_All();
                lueCompany.Properties.DataSource = aListCompanies;
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";

                if (IDCompany == 0)
                {
                    if(aListCompanies.Count > 0)
                    {
                        lueCompany.EditValue = aListCompanies[0].ID;
                    }
                }
                else
                {
                    lueCompany.Enabled = false;
                    lueCompany.EditValue = IDCompany;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups.frmIns_CustomerGroups_Load\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}