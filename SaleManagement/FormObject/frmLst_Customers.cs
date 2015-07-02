using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

using System.Collections.Generic;
using System.Linq;

namespace SaleManagement
{
    public partial class frmLst_Customers : DevExpress.XtraEditors.XtraForm
    {

        frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment = null;
        private frmMain afrmMain = null;
        private int IDCustomerGroup;

        public frmLst_Customers()
        {
            InitializeComponent();
            gridColumn20.Visible = false; // cot Fill (fill nguoc lai ve form goi fom nay- khoa trong truong hop khong co form cha)
            // AutoComplete(); // Hàm tự động tìm kiếm tên trên textbox tìm kiếm
        }

        public frmLst_Customers(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            gridColumn20.Visible = false;
        }
        public frmLst_Customers(frmTsk_BookingHall_Goverment afrmTsk_BookingHall_Goverment, int IDCustomerGroup)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Goverment = afrmTsk_BookingHall_Goverment;
            this.IDCustomerGroup = IDCustomerGroup;
        }
        private void btnSelectIDCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Int32.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
                //if (this.afrmTsk_BookingHall_Goverment != null)
                //{
                //    this.afrmTsk_BookingHall_Goverment.CallBackIDCustomer(ID);
                //}
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmBookingRs_Search_Customers.btnSelectIDCustomers_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLst_Customers_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Customers.frmLst_Customers_Load \n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReloadData()
        {
            try
            {
                dgvAvailableCustomers.DataSource = null;
                CustomersBO aCustomersBO = new CustomersBO();
                List<Customers> aListCustomers = new List<Customers>();
                aListCustomers = aCustomersBO.Select_All();
                btnAddCustomer.Visible = true;

                dgvAvailableCustomers.DataSource = aListCustomers;
                dgvAvailableCustomers.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Customers.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void AutoComplete()
        //{
        //    List<string> alist = aCustomersBO.Select_All().Select(p=>p.Name).ToList();
        //    AutoCompleteStringCollection list = new AutoCompleteStringCollection();
        //    if (alist != null)
        //    {
        //        for (int i = 0; i < alist.Count; i++)
        //        {
        //            list.Add(alist[i].ToString());
        //        }
        //    }
        //    txtName.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtName.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtName.MaskBox.AutoCompleteCustomSource = list;

        //}

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Customers afrmUpd_Customers = new frmUpd_Customers(this, ID);
            afrmUpd_Customers.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(viewAvailableCustomers.GetFocusedRowCellValue("ID").ToString());
            string Name = viewAvailableCustomers.GetFocusedRowCellValue("Name").ToString();
            CustomersBO aCustomersBO = new CustomersBO();
            DialogResult result = MessageBox.Show("Bạn có muốn xóa khách hàng " + Name + " này không?", "Xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCustomersBO.Delete(ID);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmIns_Customers afrmIns_Customers = new frmIns_Customers(this);
            afrmIns_Customers.Show();
        }
    }
}