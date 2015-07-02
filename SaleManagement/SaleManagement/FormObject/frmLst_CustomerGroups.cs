using System;
using System.Windows.Forms;
using BussinessLogic;
using System.Collections.Generic;
using DataAccess;

namespace SaleManagement
{
    public partial class frmLst_CustomerGroups : DevExpress.XtraEditors.XtraForm
    { 
        private int IDCompany;
        frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment_Old = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        public frmLst_CustomerGroups()
        {
            InitializeComponent();
        }
        public frmLst_CustomerGroups(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers, int IDCompany)
        {
            InitializeComponent();
            afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
            this.IDCompany = IDCompany;
        }
        public frmLst_CustomerGroups(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int IDCompany)
        {
            InitializeComponent();
            afrmTsk_BookingHall_Goverment_Old = afrmTsk_BookingHall_Goverment;
            this.IDCompany = IDCompany;
        }
        public frmLst_CustomerGroups(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group, int IDCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
            this.IDCompany = IDCompany;
        }
        public frmLst_CustomerGroups(frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer, int IDCompany)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer = afrmTsk_BookingHall_Customer;
            this.IDCompany = IDCompany;
        }
        public frmLst_CustomerGroups(frmTsk_UpdBooking afrmTsk_UpdBooking, int IDCompany)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.IDCompany = IDCompany;
        }

        private void btnSelectIDCustomerGroups_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(viewAvailableCustomerGroups.GetFocusedRowCellValue("ID").ToString());
             
                if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    afrmIns_CustomerGroups_Customers_Old.CallBackIDCustomerGroup(id);
                }
                else if (afrmTsk_BookingHall_Goverment_Old != null)
                {
                    afrmTsk_BookingHall_Goverment_Old.CallBackIDCustomerGroup(id);
                }
                else if (this.afrmTsk_BookingHall_Group != null)
                {
                    this.afrmTsk_BookingHall_Group.CallBackIDCustomerGroup(id);
                }
                else if (this.afrmTsk_BookingHall_Customer != null)
                {
                    this.afrmTsk_BookingHall_Customer.CallBackIDCustomerGroup(id);
                }
                else if (this.afrmTsk_UpdBooking != null)
                {
                    this.afrmTsk_UpdBooking.CallBackIDCustomerGroup(id);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_CustomerGroups.btnSelectIDCustomerGroups_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLst_CustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_CustomerGroups.frmLst_CustomerGroups_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReloadData()
        {
            try
            {
                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                List<CustomerGroups> aListCustomerGroup = new List<CustomerGroups>();
                dgvAvailableCustomerGroups.DataSource = null;

             if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    aListCustomerGroup = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                    btnAdd.Visible = false;
                }
             else if (afrmTsk_BookingHall_Goverment_Old != null)
                {
                 aListCustomerGroup = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                 btnAdd.Visible = false;
                }
             else if (this.afrmTsk_BookingHall_Group != null)
             {
                 aListCustomerGroup = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                 btnAdd.Visible = false;
             }
             else if (this.afrmTsk_UpdBooking != null)
             {
                 aListCustomerGroup = aCustomerGroupsBO.Select_ByIDCompany(IDCompany);
                 btnAdd.Visible = false;
             }
                else
                {
                    aListCustomerGroup = aCustomerGroupsBO.Select_All();
                    btnAdd.Visible = true;
                    colFill.Visible = false;
                }
                dgvAvailableCustomerGroups.DataSource = aListCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_CustomerGroups.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDCustomerGroup = int.Parse(viewAvailableCustomerGroups.GetFocusedRowCellValue("ID").ToString());
            int IDCompany = int.Parse(viewAvailableCustomerGroups.GetFocusedRowCellValue("IDCompany").ToString());
            frmUpd_CustomerGroups afrmUpd_CustomerGroups = new frmUpd_CustomerGroups(IDCustomerGroup, IDCompany, this);
            afrmUpd_CustomerGroups.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            int ID = int.Parse(viewAvailableCustomerGroups.GetFocusedRowCellValue("ID").ToString());
            string Name = aCustomerGroupsBO.Select_ByID(ID).Name;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhóm khách hàng " + Name + " này không?", "Xóa nhóm khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCustomerGroupsBO.Delete_ByID(ID);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_CustomerGroups afrmIns_CustomerGroups = new frmIns_CustomerGroups(this);
            afrmIns_CustomerGroups.ShowDialog();
        }

        
    }
}