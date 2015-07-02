using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DataAccess;
using Entity;
using CORESYSTEM;


namespace SaleManagement
{
    public partial class frmIns_Guest : DevExpress.XtraEditors.XtraForm
    {
        frmLst_Guests afrmLst_Guests = null;
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;

        public frmIns_Guest()
        {
            InitializeComponent();
        }
        public frmIns_Guest(frmLst_Guests afrmLst_Guests)
        {
            InitializeComponent();
            this.afrmLst_Guests = afrmLst_Guests;
        }
        public frmIns_Guest(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
        }
        public frmIns_Guest(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
        }
        public frmIns_Guest(frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer = afrmTsk_BookingHall_Customer;
        }
        public frmIns_Guest(frmTsk_UpdBooking afrmTsk_UpdBooking)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
        }

        private void frmIns_Guest_Load(object sender, EventArgs e)
        {
            lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
            lueNationality.Properties.DisplayMember = "Name";
            lueNationality.Properties.ValueMember = "Code";
            lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;
        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                txtName.Focus();
                MessageBox.Show("Nhập tên khách mời trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtInfo.Text == "")
            {
                txtInfo.Focus();
                MessageBox.Show("Nhập thông tin khách mời trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void sbCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    GuestsBO aGuestsBO = new GuestsBO();
                    Guests aGuests = new Guests();
                    aGuests.Name = txtName.Text;
                    aGuests.Nationality = lueNationality.EditValue.ToString();
                    aGuests.Type = int.Parse(cbbType.Text);
                    aGuests.Info = txtInfo.Text;
                    aGuests.GroupName = "Khách mời";
                    aGuestsBO.Insert(aGuests);
                    if (afrmLst_Guests != null)
                    {
                        afrmLst_Guests.Reload();
                    }
                    if (afrmTsk_BookingHall_Goverment != null)
                    {
                        this.afrmTsk_BookingHall_Goverment.ReloadData();
                    }
                    if (afrmTsk_BookingHall_Group != null)
                    {
                        this.afrmTsk_BookingHall_Group.ReloadData();
                    }
                    if (afrmTsk_BookingHall_Customer != null)
                    {
                        this.afrmTsk_BookingHall_Customer.ReloadData();
                    }
                    if (afrmTsk_UpdBooking != null)
                    {
                        this.afrmTsk_UpdBooking.ReloadData();
                    }
                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Guest.sbCreate_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}