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
    public partial class frmTsk_BookingHall_Group : DevExpress.XtraEditors.XtraForm
    {
        CompaniesBO aCompaniesBO = new CompaniesBO();
        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
        CustomersBO aCustomersBO = new CustomersBO();
        GuestsBO aGuestsBO = new GuestsBO();
        private List<HallExtStatusEN> aListAvailableHall = new List<HallExtStatusEN>();
        List<HallsEN> aListSelected = new List<HallsEN>();
        frmMain afrmMain = null;

        public frmTsk_BookingHall_Group(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }    

        public void ReloadData()
        {

            lueBookingStatus.Properties.DataSource = CORE.CONSTANTS.ListBookingHallStatus;
            lueBookingStatus.Properties.DisplayMember = "Name";
            lueBookingStatus.Properties.ValueMember = "ID";
            lueBookingStatus.EditValue = CORE.CONSTANTS.SelectedBookingHallStatus(2).ID;

            lueBookingType.Properties.DataSource = CORE.CONSTANTS.ListBookingTypes;
            lueBookingType.Properties.DisplayMember = "Name";
            lueBookingType.Properties.ValueMember = "ID";
            lueBookingType.EditValue = CORE.CONSTANTS.SelectedBookingType(3).ID;

            lueStatusPay.Properties.DataSource = CORE.CONSTANTS.ListStatusPays;
            lueStatusPay.Properties.DisplayMember = "Name";
            lueStatusPay.Properties.ValueMember = "ID";
            lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(1).ID;          

            lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(2);// [Company] Type = 1 : Nha nuoc, 1; 
            lueCompany.Properties.DisplayMember = "Name";
            lueCompany.Properties.ValueMember = "ID";

            lueCustomer.Properties.DataSource = aCustomersBO.Select_All();
            lueCustomer.Properties.DisplayMember = "Name";
            lueCustomer.Properties.ValueMember = "ID";

            lueCustomerGroup.Properties.DataSource = aCustomerGroupsBO.Select_All();
            lueCustomerGroup.Properties.DisplayMember = "Name";
            lueCustomerGroup.Properties.ValueMember = "ID";

            lueGuest.Properties.DataSource = aGuestsBO.Select_All();
            lueGuest.Properties.DisplayMember = "Name";
            lueGuest.Properties.ValueMember = "ID";

            LoadCompanies();

        }
        private void frmTsk_BookingHall_Group_Load(object sender, EventArgs e)
        {
            this.ReloadData();
            dtpFrom.DateTime = DateTime.Now;    
        
        }
        public void LoadCompanies()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                lueCompany.Properties.DataSource = aCompaniesBO.Select_ByType(2);// [Company] Type = 2  : Công ty ngoài; 
                lueCompany.Properties.DisplayMember = "Name";
                lueCompany.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.LoadCompanies\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_BookingHall_Group.LoadIDCustomerGroups\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
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
                MessageBox.Show("frmTsk_BookingHall_Group.LoadIDCustomers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_BookingHall_Group.CallBackCustomerGroup\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Call Back data IDCustomer
        public void CallBackIDCustomer(List<Customers> aList)
        {
            try
            {              
                lueCustomer.Properties.DataSource = aList;
                lueCustomer.Properties.DisplayMember = "Name";
                lueCustomer.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.CallBackCustomer\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_BookingHall_Group.CallBackCompany\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("frmTsk_BookingHall_Group.CallBackGuest\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddCompany_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmIns_Companies afrmIns_Companies = new frmIns_Companies(this);
                afrmIns_Companies.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnAddCompany_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCompany_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmLst_Companies afrmLst_Companies = new frmLst_Companies(this, 2);//2 : Công ty ngoài
                afrmLst_Companies.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnSearchCompany_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomerGroup_Click(object sender, System.EventArgs e)
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
                    afrmIns_CustomerGroups.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnAddCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchCustomerGroup_Click(object sender, System.EventArgs e)
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
                    afrmLst_CustomerGroups.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("frmTsk_BookingHall_Group.btnSearchCustomerGroup_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, System.EventArgs e)
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
                    afrmIns_CustomerGroups_Customers.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnAddCustomer_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGuest_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmIns_Guest afrmIns_Guest = new frmIns_Guest(this);
                afrmIns_Guest.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnAddGuest_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchGuest_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmLst_Guests afrmLst_Guests = new frmLst_Guests(this);
                afrmLst_Guests.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.btnSearchGuest_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchHalls_Click(object sender, System.EventArgs e)
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
                MessageBox.Show("frmTsk_BookingHall_Group.btnSearchHalls_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                aHallEN.Type = Convert.ToInt32(grvAvailableHalls.GetFocusedRowCellValue("Type"));
                aHallEN.TypeDisplay = CORE.CONSTANTS.SelectedHallType(Convert.ToInt32(aHallEN.Type)).Name;
                aHallEN.NumTableStandard = Convert.ToInt32(grvAvailableHalls.GetFocusedRowCellValue("NumTableStandard"));
                aHallEN.Status = Convert.ToInt32(grvAvailableHalls.GetFocusedRowCellValue("HallStatus"));
                aHallEN.TableOrPerson = Convert.ToInt32(grvAvailableHalls.GetFocusedRowCellValue("TableOrPerson"));

                if (aHallEN.TableOrPerson == 1)
                {
                    aHallEN.DisplayTableOrPerson = "Người";
                }
                if (aHallEN.TableOrPerson == 2)
                {
                    aHallEN.DisplayTableOrPerson = "Bàn";
                }

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
                MessageBox.Show("frmTsk_BookingHall_Group.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                HallExtStatusEN aHallExtStatusEN = new HallExtStatusEN();
                aHallExtStatusEN.Code = grvSelectedHalls.GetFocusedRowCellValue("Code").ToString();
                aHallExtStatusEN.Sku = grvSelectedHalls.GetFocusedRowCellValue("Sku").ToString();
                aHallExtStatusEN.CostRef = Convert.ToDecimal(grvSelectedHalls.GetFocusedRowCellValue("CostRef"));
                aHallExtStatusEN.Type = Convert.ToInt32(grvSelectedHalls.GetFocusedRowCellValue("Type"));
                aHallExtStatusEN.NumTableStandard = Convert.ToInt32(grvSelectedHalls.GetFocusedRowCellValue("NumTableStandard"));
                aHallExtStatusEN.HallStatus = Convert.ToInt32(grvSelectedHalls.GetFocusedRowCellValue("Status"));

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
                MessageBox.Show("frmTsk_BookingHall_Group.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCompany_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                LoadIDCustomerGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.lueCompany_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueCustomerGroup_EditValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.lueCustomerGroup_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        aListSelected[i].Unit = Convert.ToInt32(e.Value);
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

        private void btnCheckIn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    //Add du lieu cho BookingH
                    BookingHs aBookingHs = new BookingHs();
                    aBookingHs.Subject = txtSubject.Text;
                    aBookingHs.CreatedDate = DateTime.Now;
                    aBookingHs.CustomerType = 2;
                    aBookingHs.BookingType = Convert.ToInt32(lueBookingType.EditValue);
                    aBookingHs.Note = txtNote.Text;
                    aBookingHs.IDGuest = Convert.ToInt32(lueGuest.EditValue);
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
                    aBookingHs.StatusPay = Convert.ToInt32(lueStatusPay.EditValue);
                    aBookingHs.Status = Convert.ToInt32(lueBookingStatus.EditValue);
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
                    aBookingHs.Description = "";
                    aBookingHs.IDCustomer = Convert.ToInt32(lueCustomer.EditValue);
                    aBookingHs.IDCustomerGroup = Convert.ToInt32(lueCustomerGroup.EditValue);
                    aBookingHs.IDSystemUser = 1;

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
                        aTemp.Date = DateTime.Now;
                        IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                        DateTime Lunardate = DateTime.ParseExact(Convert.ToString(LunarDateExt.ToLunarDate(DateTime.Now, 7)),"d/M/yyyy",theCultureInfo);
                        aTemp.LunarDate = Lunardate;
                        aTemp.BookingStatus = null;
                        aTemp.Unit = aListSelected[i].Unit;
                        aTemp.TableOrPerson = aListSelected[i].TableOrPerson;
                        aTemp.Note = "";
                        aTemp.Status = Convert.ToInt32(lueBookingStatus.EditValue);
                        aTemp.StartTime = !string.IsNullOrEmpty(tedStart.Time.ToString()) ? tedStart.Time.TimeOfDay : TimeSpan.Zero;
                        aTemp.EndTime = !string.IsNullOrEmpty(tedEnd.Time.ToString()) ? tedEnd.Time.TimeOfDay : TimeSpan.Zero;

                        aListBookingHall.Add(aTemp);
                    }
                    aReceptionTaskBO.CheckIn(aBookingHs, aListBookingHall);
                    MessageBox.Show("Đặt hội trường thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (afrmMain != null)
                    {
                        this.afrmMain.Reload();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingHall_Group.CheckIn\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookingMoney_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookingMoney.Text) == true || txtBookingMoney.Text == "0")
            {
                lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(1).ID;
                lueStatusPay.SelectedText = CORE.CONSTANTS.SelectedStatusPay(1).Name;
            }
            else
            {
                lueStatusPay.EditValue = CORE.CONSTANTS.SelectedStatusPay(2).ID;
                lueStatusPay.SelectedText = CORE.CONSTANTS.SelectedStatusPay(2).Name;
            }
        }
    }
}