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
using Entity;
using BussinessLogic;
using Library;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_BookingForRoom : DevExpress.XtraEditors.XtraForm
    {
        private List<NewRoomMemberEN> aListAvaiableRooms = new List<NewRoomMemberEN>();
        private NewBookingEN aNewBookingEN = new NewBookingEN();
        private frmMain afrmMain = null;

        private string aCurrent_CodeRoom = string.Empty;
        private int customerType = 0;

        //Hiennv  18/11/2014
        public frmTsk_BookingForRoom(frmMain afrmMain, int customerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.customerType = customerType;
        }
        //Hiennv  25/11/2014
        public frmTsk_BookingForRoom(frmMain afrmMain, string codeRoom, int customerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.aCurrent_CodeRoom = codeRoom;
            this.customerType = customerType;
        }

       
        //Hiennv    tạo mới      25/11/2014   Load ra toàn bộ danh sách công ty theo loại công ty (Nhà nước, đoàn ,lẻ)
        private List<Companies> LoadListCompaniesByType(int type)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                return aCompaniesBO.Select_ByType(type);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.LoadListCompaniesByType()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    Tạo mới     25/11/2014  lay ra toan bo danh khach hang
        public List<Customers> LoadAllListCustomers()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                return aCustomersBO.Select_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.LoadAllListCustomers()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    tạo mới     25/11/2014   Kiểm tra dữ liệu đầu vào khi tìm kiếm phòng còn trống
        private bool CheckData()
        {
            try
            {
                if (dtpFrom.EditValue == null)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Vui lòng nhập ngày đặt phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (dtpTo.EditValue == null)
                {
                    dtpTo.Focus();
                    MessageBox.Show("Vui lòng nhập ngày trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (dtpFrom.DateTime > dtpTo.DateTime)
                    {
                        dtpTo.Focus();
                        MessageBox.Show("Vui lòng nhập đặt phòng phải nhỏ hơn hoặc bằng ngày trả phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv    Tạo mới     25/11/2014   Load ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
        public List<NewRoomMemberEN> LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (this.CheckData() == true)
                {
                    aNewBookingEN.aListNewRoomMembers.Clear();
                    List<Rooms> aListRooms = aReceptionTaskBO.GetListAvailableRooms(fromDate, toDate, 1).OrderBy(r => r.Sku).ToList(); // 1=IDLang
                    NewRoomMemberEN aNewRoomMemberEN;
                    for (int i = 0; i < aListRooms.Count; i++)
                    {
                        aNewRoomMemberEN = new NewRoomMemberEN();
                        aNewRoomMemberEN.IDBookingRooms = aListRooms[i].ID;
                        aNewRoomMemberEN.RoomCode = aListRooms[i].Code;
                        aNewRoomMemberEN.RoomSku = aListRooms[i].Sku;
                        aNewRoomMemberEN.RoomBed1 = aListRooms[i].Bed1.GetValueOrDefault();
                        aNewRoomMemberEN.RoomBed2 = aListRooms[i].Bed2.GetValueOrDefault();
                        aNewRoomMemberEN.RoomCostRef = aListRooms[i].CostRef.GetValueOrDefault();
                        aNewRoomMemberEN.RoomTypeDisplay = CORE.CONSTANTS.SelectedRoomsType(Convert.ToInt32(aListRooms[i].Type)).Name;
                        this.aListAvaiableRooms.Add(aNewRoomMemberEN);
                    }
                }
                return this.aListAvaiableRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv   25/11/2014   load ra danh sach cac phong da duoc chon
        public List<NewRoomMemberEN> LoadListSelectRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {

                    List<NewRoomMemberEN> aListNewRoomMemberEN = this.aListAvaiableRooms.Where(p => p.RoomCode == this.aCurrent_CodeRoom).ToList();
                    if (aListNewRoomMemberEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListNewRoomMemberEN[0]);

                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        NewRoomMemberEN aNewRoomMemberEN = new NewRoomMemberEN();
                        aNewRoomMemberEN.RoomSku = aListNewRoomMemberEN[0].RoomSku;
                        aNewRoomMemberEN.RoomCode = aListNewRoomMemberEN[0].RoomCode;
                        aNewRoomMemberEN.RoomTypeDisplay = aListNewRoomMemberEN[0].RoomTypeDisplay;
                        aNewRoomMemberEN.RoomBed1 = aListNewRoomMemberEN[0].RoomBed1;
                        aNewRoomMemberEN.RoomBed2 = aListNewRoomMemberEN[0].RoomBed2;
                        aNewRoomMemberEN.RoomCostRef = aListNewRoomMemberEN[0].RoomCostRef;
                        this.aNewBookingEN.InsertRoom(aNewRoomMemberEN);
                    }
                    return this.aNewBookingEN.aListNewRoomMembers;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.LoadListSelectRooms()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    Tạo mới     25/11/2014   Tim ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckData() == true)
                {
                    DateTime From = dtpFrom.DateTime;
                    DateTime To = dtpTo.DateTime;

                    this.aCurrent_CodeRoom = string.Empty;

                    this.aListAvaiableRooms.Clear();
                    dgvAvailableRooms.DataSource = this.LoadListAvailableRooms(From, To);
                    dgvAvailableRooms.RefreshDataSource();

                    this.aNewBookingEN.aListNewRoomMembers.Clear();
                    dgvSelectedRooms.DataSource = this.aNewBookingEN.aListNewRoomMembers;
                    dgvSelectedRooms.RefreshDataSource();

                    List<NewRoomMemberEN> aListNewRoomMemberEN = this.aListAvaiableRooms.Where(p => p.RoomCode == this.aCurrent_CodeRoom).ToList();
                    if (aListNewRoomMemberEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListNewRoomMemberEN[0]);
                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        NewRoomMemberEN aNewRoomMemberEN = new NewRoomMemberEN();
                        aNewRoomMemberEN.RoomSku = aListNewRoomMemberEN[0].RoomSku;
                        aNewRoomMemberEN.RoomCode = aListNewRoomMemberEN[0].RoomCode;
                        aNewRoomMemberEN.RoomTypeDisplay = aListNewRoomMemberEN[0].RoomTypeDisplay;
                        aNewRoomMemberEN.RoomBed1 = aListNewRoomMemberEN[0].RoomBed1;
                        aNewRoomMemberEN.RoomBed2 = aListNewRoomMemberEN[0].RoomBed2;
                        aNewRoomMemberEN.RoomCostRef = aListNewRoomMemberEN[0].RoomCostRef;

                        this.aNewBookingEN.InsertRoom(aNewRoomMemberEN);
                        dgvSelectedRooms.DataSource = this.aNewBookingEN.aListNewRoomMembers;
                        dgvSelectedRooms.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     25/11/2014         chon phong can dat
        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                NewRoomMemberEN aNewRoomMemberEN = new NewRoomMemberEN();
                aNewRoomMemberEN.RoomSku = viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aNewRoomMemberEN.RoomCode = viewAvailableRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aNewRoomMemberEN.RoomTypeDisplay = viewAvailableRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aNewRoomMemberEN.RoomBed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed1").ToString());
                aNewRoomMemberEN.RoomBed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed2").ToString());
                aNewRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("RoomCostRef").ToString());

                this.aNewBookingEN.InsertRoom(aNewRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aNewBookingEN.aListNewRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                NewRoomMemberEN Temps = aListAvaiableRooms.Where(p => p.RoomSku == viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                this.aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     25/11/2014   
        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                NewRoomMemberEN aNewRoomMemberEN = new NewRoomMemberEN();
                aNewRoomMemberEN.RoomCode = viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aNewRoomMemberEN.RoomSku = viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aNewRoomMemberEN.RoomTypeDisplay = viewSelectedRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aNewRoomMemberEN.RoomBed1 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed1"));
                aNewRoomMemberEN.RoomBed2 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed2"));
                aNewRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewSelectedRooms.GetFocusedRowCellValue("RoomCostRef"));

                this.aListAvaiableRooms.Insert(0, aNewRoomMemberEN);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                NewRoomMemberEN Temps = aNewBookingEN.aListNewRoomMembers.Where(p => p.RoomSku == viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                this.aNewBookingEN.RemoveRoom(Temps);
                dgvSelectedRooms.DataSource = this.aNewBookingEN.aListNewRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới      25/11/2014  kiểm tra dữ liệu trước khi thực hiện đặt phòng
        private bool CheckDataBeforeCheckIn()
        {
            try
            {
                if (lueIDCompanies.EditValue == null && String.IsNullOrEmpty(txtNameCompany.Text))
                {
                    lueIDCompanies.Focus();
                    MessageBox.Show("Vui lòng chọn tên công ty hoặc nhập tên công ty.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (lueIDCustomer.EditValue == null && String.IsNullOrEmpty(txtNameCustomer.Text))
                {
                    lueIDCustomer.Focus();
                    MessageBox.Show("Vui lòng chọn tên người đại diện hoặc thêm mới người đại diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (this.aNewBookingEN.aListNewRoomMembers.Count <= 0)
                {
                    dgvAvailableRooms.Focus();
                    MessageBox.Show("Vui lòng chọn phòng cần đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.CheckDataBeforeCheckIn()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv             Tạo mới          25/11/2014         
        private void txtNameCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNameCompany.Text))
                {
                    lueIDCompanies.Enabled = true;
                }
                else
                {
                    lueIDCompanies.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.txtNameCompany_EditValueChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv             Tạo mới          25/11/2014    
        private void chkCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCustomerType.Checked == true)
                {
                    this.customerType = 5; // Khach thuoc bo ngoai giao
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.chkCustomerType_CheckedChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv  tạo mới   25/11/2014
        private void txtNameCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNameCustomer.Text))
                {
                    lueIDCustomer.Enabled = true;
                }
                else
                {
                    lueIDCustomer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.txtNameCustomer_EditValueChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv         tạo mới         25/11/2014               dat phong
        private void btnBookingRoom_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CheckDataBeforeCheckIn() == true)
                {
                    if (String.IsNullOrEmpty(txtNameCompany.Text))
                    {
                        this.aNewBookingEN.IDCompany = Convert.ToInt32(lueIDCompanies.EditValue);
                        this.aNewBookingEN.NameCompany = lueIDCompanies.Text;
                    }
                    else
                    {
                        this.aNewBookingEN.IDCompany = 0;
                        this.aNewBookingEN.NameCompany = txtNameCompany.Text;
                    }

                    if (String.IsNullOrEmpty(txtNameCustomer.Text))
                    {
                        this.aNewBookingEN.IDCustomer = Convert.ToInt32(lueIDCustomer.EditValue);
                        this.aNewBookingEN.NameCustomer = lueIDCustomer.Text;
                    }
                    else
                    {
                        this.aNewBookingEN.IDCustomer = 0;
                        this.aNewBookingEN.NameCustomer = txtNameCustomer.Text;
                    }
                    // ====================Ngoc bo sung=========================
                    if (String.IsNullOrEmpty(txtCustomerGroup.Text))
                    {
                        this.aNewBookingEN.Subject = txtCustomerGroup.Text;
                        
                    }
                    // ====================Ngoc bo sung=========================

                    this.aNewBookingEN.CheckInActual = dtpFrom.DateTime;
                    this.aNewBookingEN.CheckOutActual = dtpTo.DateTime;
                    this.aNewBookingEN.CheckOutPlan = dtpTo.DateTime;
                    this.aNewBookingEN.CustomerType = this.customerType;  // 1: Khach nha nuoc, 2: Khach doan, 3: khach le, 4: Khach vang lai
                    this.aNewBookingEN.BookingType = 2;   // 1: Dat onlie, 2: Dat qua dien thoai, 3: Truc tiep, 4: Cong van
                    this.aNewBookingEN.IDSystemUser = CORE.CURRENTUSER.SystemUser.ID;
                    this.aNewBookingEN.PayMenthod = 1;     //1:Tien mat


                    this.aNewBookingEN.ExchangeRate = 0;
                    this.aNewBookingEN.Status = 2; // 2 : da bookingRoom
                    this.aNewBookingEN.Type = -1;
                    this.aNewBookingEN.Disable = false;

                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                    if (aReceptionTaskBO.NewBookingRoom(this.aNewBookingEN) == true)
                    {
                        if (this.afrmMain != null)
                        {
                            this.afrmMain.ReloadData();
                            this.Close();
                        }
                        MessageBox.Show("Thực hiện đặt phòng thành công .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đặt phòng thất bại vui lòng thực hiện lại.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.btnBookingRoom_Click()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv  tạo mới   25/11/2014
        private void frmTsk_BookingForRoom_Load(object sender, EventArgs e)
        {
            try
            {

                if (this.customerType == 1)
                {
                    chkCustomerType.Visible = true;
                    txtNameCompany.Visible = true;
                }
                else if (this.customerType == 2)
                {
                    chkCustomerType.Visible = false;
                    txtNameCompany.Visible = true;
                }
                else
                {
                    chkCustomerType.Visible = false;
                    txtNameCompany.Visible = false;
                }

                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

                dtpFrom.DateTime = DateTime.Now;
                dtpTo.DateTime = aReceptionTaskBO.SetDateValueDefault(DateTime.Now.AddDays(1));


                dgvAvailableRooms.DataSource = this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                dgvAvailableRooms.RefreshDataSource();

                dgvSelectedRooms.DataSource = this.LoadListSelectRooms(dtpFrom.DateTime, dtpTo.DateTime);
                dgvSelectedRooms.RefreshDataSource();

                lueIDCompanies.Properties.DataSource = this.LoadListCompaniesByType(this.customerType);
                lueIDCompanies.Properties.ValueMember = "ID";
                lueIDCompanies.Properties.DisplayMember = "Name";
                if (this.customerType == 3) // khach le
                {
                    if (this.LoadListCompaniesByType(this.customerType).Count > 0)
                    {
                        lueIDCompanies.EditValue = this.LoadListCompaniesByType(this.customerType)[0].ID;
                    }
                }

                lueIDCustomer.Properties.DataSource = this.LoadAllListCustomers();
                lueIDCustomer.Properties.ValueMember = "ID";
                lueIDCustomer.Properties.DisplayMember = "Name";


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.frmTsk_BookingForRoom_Group_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}