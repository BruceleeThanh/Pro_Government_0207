using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using CORESYSTEM;
using DataAccess;
namespace RoomManager
{
    public partial class frmUpd_Guests : DevExpress.XtraEditors.XtraForm
    {
        frmLst_Guests afrmLst_Guests = null;
        int IDGuest;
        public frmUpd_Guests()
        {
            InitializeComponent();
        }
        public frmUpd_Guests(frmLst_Guests afrmLst_Guests, int IDGuest)
        {
            InitializeComponent();
            this.afrmLst_Guests = afrmLst_Guests;
            this.IDGuest = IDGuest;
        }

        private void frmUpd_Guests_Load(object sender, EventArgs e)
        {

            lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
            GuestsBO aGuestsBO = new GuestsBO();
            Guests aGuests = aGuestsBO.Select_ByID(IDGuest);
            lueNationality.Properties.DisplayMember = "Name";
            lueNationality.Properties.ValueMember = "Code";
            lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(aGuests.Nationality).Code;
            txtGroupName.Text = aGuests.GroupName;
            txtInfo.Text = aGuests.Info;
            txtName.Text = aGuests.Name;
            cbbType.Text = aGuests.Type.ToString();
            lblID.Text = aGuests.ID.ToString();
        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                txtName.Focus();
                MessageBox.Show("Nhập tên khách mời trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtGroupName.Text == "")
            {
                txtGroupName.Focus();
                MessageBox.Show("Nhập tên nhóm khách trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtInfo.Text == "")
            {
                MessageBox.Show("Nhập thông tin khách mời trước khi sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    aGuests.GroupName = txtGroupName.Text;
                    aGuestsBO.Insert(aGuests);
                    if (afrmLst_Guests != null)
                    {
                        afrmLst_Guests.Reload();
                    }
                    
                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Guests.sbCreate_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
      
    }
}