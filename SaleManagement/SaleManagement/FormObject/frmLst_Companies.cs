using System;
using System.Windows.Forms;
using BussinessLogic;

using DataAccess;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;


namespace SaleManagement
{
    public partial class frmLst_Companies : DevExpress.XtraEditors.XtraForm
    {
        private frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers_Old = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        private int Type = 0;
        public frmLst_Companies()
        {
            InitializeComponent();
            this.gridColumn14.Visible = false;
        }
        public frmLst_Companies(frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers)
        {
            InitializeComponent();
            afrmIns_CustomerGroups_Customers_Old = afrmIns_CustomerGroups_Customers;
        }

        public frmLst_Companies(frmTsk_UpdBooking afrmTsk_UpdBooking, int Type)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
            this.Type = Type;
        }

        public frmLst_Companies(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group, int Type)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
            this.Type = Type;
        }
        public frmLst_Companies(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int Type)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
            this.Type = Type;
        }
        private void frmLst_Companies_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.frmLst_Companies_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadData()
        {
            try
            {
                dgvAvailableCompanies.DataSource = null;

                List<Companies> aListCompanies = new List<Companies>();
                CompaniesBO aCompaniesBO = new CompaniesBO();
                if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    aListCompanies = aCompaniesBO.Select_All();
                    btnAdd.Visible = false;
                }
                else if(this.afrmTsk_BookingHall_Goverment != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else if (this.afrmTsk_BookingHall_Group != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else if (this.afrmTsk_UpdBooking != null)
                {
                    aListCompanies = aCompaniesBO.Select_ByType(Type);
                    btnAdd.Visible = false;
                }
                else
                {
                    aListCompanies = aCompaniesBO.Select_All();
                    btnAdd.Visible = true;
                }
                dgvAvailableCompanies.DataSource = aListCompanies;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.ReloadData\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CompaniesBO aCompaniesBO = new CompaniesBO();
            int ID = int.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
            string Name = aCompaniesBO.Select_ByID(ID).Name;
            DialogResult result = MessageBox.Show("Bạn có muốn xóa công ty" + Name + "này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCompaniesBO.Delete(ID);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }

        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Companies afrmUpd_Companies = new frmUpd_Companies(ID, this);
            afrmUpd_Companies.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Companies afrmIns_Companies = new frmIns_Companies(this);
            afrmIns_Companies.ShowDialog();
        }

        private void btnSelectIDCompanies_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Int32.Parse(viewAvailableCompanies.GetFocusedRowCellValue("ID").ToString());
                if (this.afrmTsk_BookingHall_Goverment != null)
                {
                    this.afrmTsk_BookingHall_Goverment.CallBackIDCompany(ID);
                }
                if (this.afrmTsk_BookingHall_Group != null)
                {
                    this.afrmTsk_BookingHall_Group.CallBackIDCompany(ID);
                }
                if (this.afrmTsk_UpdBooking != null)
                {
                    this.afrmTsk_UpdBooking.CallBackIDCompany(ID);
                }
                if (afrmIns_CustomerGroups_Customers_Old != null)
                {
                    afrmIns_CustomerGroups_Customers_Old.CallBackIDCompany(ID);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Companies.btnSelectIDCompanies_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}