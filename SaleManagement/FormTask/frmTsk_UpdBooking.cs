using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using BussinessLogic;
using Entity;
using CORESYSTEM;
using Library;


namespace SaleManagement
{
    public partial class frmTsk_UpdBooking : DevExpress.XtraEditors.XtraForm
    {
        int IDBookingH;
        CompaniesBO aCompaniesBO = new CompaniesBO();
        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
        CustomersBO aCustomersBO = new CustomersBO();
        GuestsBO aGuestsBO = new GuestsBO();
        BookingHs aBookingHs = new BookingHs();
        private List<HallExtStatusEN> aListAvailableHall = new List<HallExtStatusEN>();
        List<HallsEN> aListSelected = new List<HallsEN>();
        frmTsk_ManageBookingHs afrmTsk_ManageBookingHs = null;

        public void ReloadData()
        {
            BookingHsBO aBookingHsBO = new BookingHsBO();
            BookingHs aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);

            if (aBookingHs.Type == 1)
            {
                cbbType.Text = "Tiệc không thuộc phạm trù nhà bếp";
            }
            else
            {
                cbbType.Text = "Tiệc thuộc phạm trù nhà bếp";
            }
            lueBookingStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHallStatus;
            lueBookingStatus.Properties.DisplayMember = "Name";
            lueBookingStatus.Properties.ValueMember = "ID";
            lueBookingStatus.EditValue = aBookingHs.Status;

            lueBookingType.Properties.DataSource = CORE.CONSTANTS.ListBookingTypes;
            lueBookingType.Properties.DisplayMember = "Name";
            lueBookingType.Properties.ValueMember = "ID";
            lueBookingType.EditValue = aBookingHs.BookingType;

            lueStatusPay.Properties.DataSource = CORE.CONSTANTS.ListStatusPays;
            lueStatusPay.Properties.DisplayMember = "Name";
            lueStatusPay.Properties.ValueMember = "ID";
            lueStatusPay.EditValue = aBookingHs.StatusPay;

            if (aBookingHs.CustomerType == 1)
            {
                lueLevel.Properties.DataSource = CORE.CONSTANTS.ListLevels;
                lueLevel.Properties.DisplayMember = "Name";
                lueLevel.Properties.ValueMember = "ID";
                lueLevel.EditValue = aBookingHs.Level;

                lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(1);// [Company] Type = 1 : Nha nuoc, 1; 
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
                lueCompany.EditValue = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup).IDCompany;
            }
            else if (aBookingHs.CustomerType == 2)
            {
                lueLevel.Visible = false;
                lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(2);
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
                lueCompany.EditValue = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup).IDCompany;

            }
            else
            {
                lueLevel.Visible = false;
                lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(3);
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
                lueCompany.EditValue = aCustomerGroupsBO.Select_ByID(aBookingHs.IDCustomerGroup).IDCompany;

            }           
           
            lueCustomer.Properties.DataSource = aCustomersBO.Select_All();
            lueCustomer.Properties.DisplayMember = "Name";
            lueCustomer.Properties.ValueMember = "ID";
            lueCustomer.EditValue = aBookingHs.IDCustomer;

            lueCustomerGroup.Properties.DataSource = aCustomerGroupsBO.Select_All();
            lueCustomerGroup.Properties.DisplayMember = "Name";
            lueCustomerGroup.Properties.ValueMember = "ID";
            lueCustomerGroup.EditValue = aBookingHs.IDCustomerGroup;

            lueGuest.Properties.DataSource = aGuestsBO.Select_All();
            lueGuest.Properties.DisplayMember = "Name";
            lueGuest.Properties.ValueMember = "ID";
            lueGuest.EditValue = aBookingHs.IDGuest;
            LoadData();
            LoadCompanies();
        }

        public void LoadData()
        {
            BookingHsBO aBookingHsBO = new BookingHsBO();
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();            
            HallsEN aTemp;
            aBookingHs = aBookingHsBO.Select_ByID(IDBookingH);
            HallsBO aHallsBO = new HallsBO();
            List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookigH(IDBookingH);
            //Fill data for BookingH
            txtSubject.Text = aBookingHs.Subject;
            txtBookingMoney.Text = String.Format("{0:0,0}", aBookingHs.BookingMoney);
            txtNote.Text = aBookingHs.Note;
            //Fill data for BookingHall
            dtpFrom.DateTime = Convert.ToDateTime(aListBookingHalls[0].Date);
            tedEnd.Time = DateTime.Parse( aListBookingHalls[0].EndTime.ToString());
            tedStart.Time = DateTime.Parse(aListBookingHalls[0].StartTime.ToString());

            for (int i = 0; i < aListBookingHalls.Count; i++)
            {
                aTemp = new HallsEN();
                aTemp.IDBookingHall = aListBookingHalls[i].ID;
                aTemp.Code = aListBookingHalls[i].CodeHall;
                aTemp.Sku = aHallsBO.Select_ByCodeHall(aListBookingHalls[i].CodeHall, 1).Sku;
                aTemp.CostRef = aListBookingHalls[i].CostRef_Halls;
                aTemp.Type = aHallsBO.Select_ByCodeHall(aListBookingHalls[i].CodeHall, 1).Type;
                aTemp.TypeDisplay = CORE.CONSTANTS.SelectedHallType(Convert.ToInt32(aTemp.Type)).Name;
                aTemp.Cost = aListBookingHalls[i].Cost;
                aTemp.TableOrPerson = aListBookingHalls[i].TableOrPerson;
                aTemp.Unit = aListBookingHalls[i].Unit;
                aListSelected.Add(aTemp);
            }
            dgvSelectedHalls.DataSource = aListSelected;
            dgvSelectedHalls.RefreshDataSource();
        }
        public frmTsk_UpdBooking()
        {
            InitializeComponent();
        }
        public frmTsk_UpdBooking(frmTsk_ManageBookingHs afrmTsk_ManageBookingHs, int IDBookingH)
        {
            InitializeComponent();
            this.IDBookingH = IDBookingH;
            this.afrmTsk_ManageBookingHs = afrmTsk_ManageBookingHs;
        }

        public void LoadCompanies()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(1);// [Company] Type = 1 : Nha nuoc, 1; 
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.LoadCompanies\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
                MessageBox.Show("frmTsk_UpdBooking.LoadIDCustomerGroups\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Load IDCustomers 
        public void LoadCustomers()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                int IDCustomerGroup = Int32.Parse(lueCustomerGroup.EditValue.ToString());
                List<Customers> aListCustomer = aCustomersBO.SelectListCustomer_ByIDCustomerGroups(IDCustomerGroup);
                lueCustomer.Properties.DataSource = aListCustomer;
                lueCustomer.Properties.DisplayMember = "Name";
                lueCustomer.Properties.ValueMember = "ID";

                if (aListCustomer.Count > 0)
                {
                    lueCustomer.EditValue = aListCustomer.ToList()[0].ID;
                }
                else
                {
                    lueCustomer.EditValue = 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.LoadIDCustomers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CallBackIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                lueCustomerGroup.EditValue = IDCustomerGroup;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.CallBackCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Call Back data IDCustomer
        public void CallBackIDCustomer(List<Customers> aList)
        {
            try
            {
                //CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                lueCustomer.Properties.DataSource = aList;
                lueCustomer.Properties.DisplayMember = "Name";
                lueCustomer.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.CallBackCustomer\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_UpdBooking.CallBackCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CallBackGuest(int IDGuest)
        {
            try
            {
                lueGuest.EditValue = IDGuest;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.CallBackGuest\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateData()
        {
            if (txtSubject.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên buổi tiệc ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(lueCompany.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToInt32(lueCustomerGroup.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (Convert.ToInt32(lueCustomer.EditValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn tên người đại diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (aListSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hội trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                int CusType = Convert.ToInt32( aBookingHsBO.Select_ByID(IDBookingH).CustomerType);
                frmIns_Companies afrmIns_Companies = new frmIns_Companies(this, CusType);
                afrmIns_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnAddCompany_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCompany_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies(this, 1);//1:Nha nuoc
                afrmLst_Companies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnSearchCompany_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Vui lòng chọn công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("frmTsk_UpdBooking.btnAddCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Vui lòng chọn công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                MessageBox.Show("frmTsk_UpdBooking.btnSearchCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string NameCustomerGroup = lueCustomerGroup.Text;
                string NameCompany = lueCompany.Text;
                if (NameCompany.Equals("--- Chọn lựa ---") || NameCompany.Equals(""))
                {
                    lueCompany.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên công ty .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (NameCustomerGroup.Equals("--- Chọn lựa ---") || NameCustomerGroup.Equals(""))
                {
                    lueCustomerGroup.Text = "--- Chọn lựa ---";
                    MessageBox.Show("Vui lòng chọn tên nhóm .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int IDCustomerGroup = Convert.ToInt32(lueCustomerGroup.EditValue.ToString());
                    frmIns_CustomerGroups_Customers afrmIns_CustomerGroups_Customers = new frmIns_CustomerGroups_Customers(this, IDCustomerGroup, NameCustomerGroup, NameCompany);
                    afrmIns_CustomerGroups_Customers.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnAddCustomer_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_Guest afrmIns_Guest = new frmIns_Guest(this);
                afrmIns_Guest.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnAddGuest_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_Guests afrmLst_Guests = new frmLst_Guests(this);
                afrmLst_Guests.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnSearchGuest_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_UpdBooking_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                HallExtStatusEN aHallExtStatusEN = new HallExtStatusEN();
                aHallExtStatusEN.Code = grvSelectedHalls.GetFocusedRowCellValue("Code").ToString();
                aHallExtStatusEN.Sku = grvSelectedHalls.GetFocusedRowCellValue("Sku").ToString();
                aHallExtStatusEN.CostRef = Convert.ToDecimal(grvSelectedHalls.GetFocusedRowCellValue("CostRef"));
                aHallExtStatusEN.Type = Convert.ToInt16(grvSelectedHalls.GetFocusedRowCellValue("Type"));
                aListAvailableHall.Insert(0, aHallExtStatusEN);
                dgvAvailableHalls.DataSource = aListAvailableHall;
                dgvAvailableHalls.RefreshDataSource();
                HallsEN aTemp = aListSelected.Where(a => a.Code == grvSelectedHalls.GetFocusedRowCellValue("Code").ToString()).ToList()[0];
                aListSelected.Remove(aTemp);
                dgvSelectedHalls.DataSource = aListSelected;
                dgvSelectedHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            try
            {
                HallsEN aHallEN = new HallsEN();
                aHallEN.Code = grvAvailableHalls.GetFocusedRowCellValue("Code").ToString();
                aHallEN.Sku = grvAvailableHalls.GetFocusedRowCellValue("Sku").ToString();
                aHallEN.CostRef = Convert.ToDecimal(grvAvailableHalls.GetFocusedRowCellValue("CostRef"));
                aHallEN.Type = Convert.ToInt16(grvAvailableHalls.GetFocusedRowCellValue("Type"));
                aHallEN.TypeDisplay = CORE.CONSTANTS.SelectedHallType(Convert.ToInt32(aHallEN.Type)).Name;

                aListSelected.Add(aHallEN);
                dgvSelectedHalls.DataSource = aListSelected;
                dgvSelectedHalls.RefreshDataSource();

                HallExtStatusEN aTemp = aListAvailableHall.Where(a => a.Code == grvAvailableHalls.GetFocusedRowCellValue("Code").ToString()).ToList()[0];
                aListAvailableHall.Remove(aTemp);
                dgvAvailableHalls.DataSource = aListAvailableHall;
                dgvAvailableHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_UpdBooking.lueCompany_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCustomerGroup_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.lueCustomerGroup_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvSelectedHalls_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "gridColumn11")
            {
                string Sku = grvSelectedHalls.GetRowCellValue(e.RowHandle, "Sku").ToString();
                for (int i = 0; i < aListSelected.Count; i++)
                {
                    if (aListSelected[i].Sku == Sku)
                    {
                        aListSelected[i].Cost = Convert.ToDecimal(e.Value); ;
                    }
                }
            }
            else if (e.Column.Name == "gridColumn12")
            {
                string Sku = grvSelectedHalls.GetRowCellValue(e.RowHandle, "Sku").ToString();
                for (int i = 0; i < aListSelected.Count; i++)
                {
                    if (aListSelected[i].Sku == Sku)
                    {
                        aListSelected[i].Unit = Convert.ToInt16(e.Value);
                    }
                }
            }
            else if (e.Column.Name == "gridColumn13")
            {
                string Sku = grvSelectedHalls.GetRowCellValue(e.RowHandle, "Sku").ToString();
                for (int i = 0; i < aListSelected.Count; i++)
                {
                    if (aListSelected[i].Sku == Sku)
                    {
                        if (e.Value == "Người")
                        {
                            aListSelected[i].TableOrPerson = 1;
                        }
                        else
                        {
                            aListSelected[i].TableOrPerson = 2;
                        }
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    //Add du lieu cho BookingH
                    BookingHs aBookingHs = new BookingHs();
                    aBookingHs.ID = IDBookingH;
                    aBookingHs.Subject = txtSubject.Text;
                    aBookingHs.CreatedDate = this.aBookingHs.CreatedDate;
                    aBookingHs.CustomerType = this.aBookingHs.CustomerType;
                    aBookingHs.BookingType = Convert.ToInt16(lueBookingType.EditValue);
                    aBookingHs.Note = txtNote.Text;
                    aBookingHs.IDGuest = Convert.ToInt16(lueGuest.EditValue);
                    if (txtBookingMoney.Text == "")
                    {
                        aBookingHs.BookingMoney = 0;
                        lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(1).ID;
                    }
                    else
                    {
                        aBookingHs.BookingMoney = Convert.ToDecimal(txtBookingMoney.Text);
                        lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(2).ID;
                    }
                    aBookingHs.StatusPay = Convert.ToInt16(lueStatusPay.EditValue);
                    aBookingHs.Status = Convert.ToInt16(lueBookingStatus.EditValue);

                    aBookingHs.PayMenthod = 1;
                    if (cbbType.Text == "Tiệc không thuộc phạm trù nhà bếp")
                    {
                        aBookingHs.Type = 1;
                    }
                    else
                    {
                        aBookingHs.Type = 2;
                    }
                    aBookingHs.Disable = false;
                    aBookingHs.Level = Convert.ToInt16(lueLevel.EditValue);
                    aBookingHs.Description = "";
                    aBookingHs.IDCustomer = Convert.ToInt16(lueCustomer.EditValue);
                    aBookingHs.IDCustomerGroup = Convert.ToInt16(lueCustomerGroup.EditValue);
                    aBookingHs.IDSystemUser = 1;// Để tạm

                    //Add du lieu cho BookingHall
                    List<BookingHalls> aListBookingHall = new List<BookingHalls>();
                    BookingHalls aTemp;
                    for (int i = 0; i < aListSelected.Count; i++)
                    {
                        aTemp = new BookingHalls();                        
                        aTemp.CodeHall = aListSelected[i].Code;
                        aTemp.Cost = aListSelected[i].Cost;
                        aTemp.PercentTax = 10;
                        aTemp.CostRef_Halls = aListSelected[i].CostRef;
                        aTemp.Date = dtpFrom.DateTime;
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        DateTime Lunardate = DateTime.ParseExact(LunarDateExt.ToLunarDate(dtpFrom.DateTime, 7).ToString(), "dd/MM/yyyy", theCultureInfo);
                        aTemp.LunarDate = Lunardate;
                        aTemp.BookingStatus = null;
                        aTemp.Unit = aListSelected[i].Unit;
                        aTemp.TableOrPerson = aListSelected[i].TableOrPerson;
                        aTemp.Note = "";
                        aTemp.Status = Convert.ToInt16(lueBookingStatus.EditValue);
                        aTemp.StartTime = !string.IsNullOrEmpty(tedStart.Time.ToString()) ? tedStart.Time.TimeOfDay : TimeSpan.Zero;
                        aTemp.EndTime = !string.IsNullOrEmpty(tedEnd.Time.ToString()) ? tedEnd.Time.TimeOfDay : TimeSpan.Zero;

                        aListBookingHall.Add(aTemp);
                    }
                    aReceptionTaskBO.UpdateCheckIn(aBookingHs, aListBookingHall);
                    afrmTsk_ManageBookingHs.ReloadData();
                    MessageBox.Show("Đặt hội trường thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.CheckIn\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchHalls_Click(object sender, EventArgs e)
        {
            try
            {
                BookingHallsBO aBookingHallsBO = new BookingHallsBO();
                bool IsLunar;
                if (cbbLunarDate.Text == "Dương")
                {
                    IsLunar = false;
                }
                else
                {
                    IsLunar = true;
                }
                aListAvailableHall = aBookingHallsBO.GetListStatusHall(dtpFrom.DateTime, IsLunar).Where(p => p.HallStatus == 0).ToList();
                dgvAvailableHalls.DataSource = aListAvailableHall;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UpdBooking.btnSearchHalls_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}