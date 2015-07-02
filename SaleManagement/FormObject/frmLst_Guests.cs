using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using SaleManagement;

namespace SaleManagement
{
    public partial class frmLst_Guests : DevExpress.XtraEditors.XtraForm
    {
        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        frmTsk_BookingHall_Group afrmTsk_BookingHall_Group = null;
        frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer = null;
        frmTsk_UpdBooking afrmTsk_UpdBooking = null;
        frmMain afrmMain = null;
        public frmLst_Guests()
        {
            InitializeComponent();
            gridColumn6.Visible = false;
        }
    
        public frmLst_Guests(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            gridColumn6.Visible = false;
        }
        public frmLst_Guests(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
        }
        public frmLst_Guests(frmTsk_BookingHall_Group afrmTsk_BookingHall_Group)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Group = afrmTsk_BookingHall_Group;
        }
        public frmLst_Guests(frmTsk_BookingHall_Customer afrmTsk_BookingHall_Customer)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer = afrmTsk_BookingHall_Customer;
        }
        public frmLst_Guests(frmTsk_UpdBooking afrmTsk_UpdBooking)
        {
            InitializeComponent();
            this.afrmTsk_UpdBooking = afrmTsk_UpdBooking;
        }

       // private ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly GuestsBO _GuestsBO = new GuestsBO();

        private void frmLst_Guests_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = _GuestsBO.SelectAll();
                dgvGuest.DataSource = dt;
            }
            catch (Exception ex)
            {
                
                //Logger.Error(ex);
            }
        }

        private void rebeEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDGuest = Convert.ToInt32( grvGuest.GetFocusedRowCellValue("ID"));
                frmUpd_Guests afrmUpd_Guests = new frmUpd_Guests(this,IDGuest);
                afrmUpd_Guests.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Guests.rebeEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rebeDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                GuestsBO aGuestsBO = new GuestsBO();
                int IDGuest = Convert.ToInt32(grvGuest.GetFocusedRowCellValue("ID"));
                string Name = grvGuest.GetFocusedRowCellValue("Name").ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa khách mời " + Name + " này không?", "Xóa công ty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aGuestsBO.Delete(IDGuest);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }    
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmLst_Guests.rebeDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reload()
        {
            try
            { 
                GuestsBO aGuestsBO = new GuestsBO();
                dgvGuest.DataSource = aGuestsBO.Select_All();
                dgvGuest.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Guests.Reload\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Guest afrmIns_Guest = new frmIns_Guest(this);
            afrmIns_Guest.ShowDialog();
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
             try
            {
                int ID = Int32.Parse(grvGuest.GetFocusedRowCellValue("ID").ToString());
                 if(this.afrmTsk_BookingHall_Goverment != null)
                 {
                 this.afrmTsk_BookingHall_Goverment.CallBackGuest(ID);
                 }
                 if (this.afrmTsk_BookingHall_Group != null)
                 {
                     this.afrmTsk_BookingHall_Group.CallBackGuest(ID);
                 }
                 if (this.afrmTsk_BookingHall_Customer != null)
                 {
                     this.afrmTsk_BookingHall_Customer.CallBackGuest(ID);
                 }
                 if (this.afrmTsk_UpdBooking != null)
                 {
                     this.afrmTsk_UpdBooking.CallBackGuest(ID);
                 }
                 this.Close();
            }
             catch (Exception ex)
             {
                 MessageBox.Show("frmLst_Guest.btnSelect_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

    }
}