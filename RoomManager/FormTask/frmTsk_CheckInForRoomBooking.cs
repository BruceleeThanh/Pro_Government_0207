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
    public partial class frmTsk_CheckInForRoomBooking : DevExpress.XtraEditors.XtraForm
    {
        private List<RoomMemberEN> aListAvaiableRooms = new List<RoomMemberEN>();
        private List<Customers> aListAvailableCustomers = new List<Customers>();
        private CheckInEN aCheckInEN = new CheckInEN();
        private frmMain afrmMain = null;
        private frmTsk_ListBookingRs afrmTsk_ListBookingRs = null;
        private int IDBookingR = 0;
        private DateTime CheckoutPlan = DateTime.Now;
        private string aCurrent_CodeRoom = string.Empty;
        private int aCurrent_IDCustomer = 0;

        //List này dùng để chứa các bookingRoom bị xóa
        private List<BookingRooms> aListRemoveBookingRooms = new List<BookingRooms>();

        //Hiennv  26/11/2014
        public frmTsk_CheckInForRoomBooking(frmMain afrmMain, int IDBookingR,DateTime CheckoutPlan)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.IDBookingR = IDBookingR;
            this.CheckoutPlan = CheckoutPlan;
            this.aCheckInEN = this.InitData(this.IDBookingR);
        }

        //Hiennv  26/11/2014
        public frmTsk_CheckInForRoomBooking(frmTsk_ListBookingRs afrmTsk_ListBookingRs, int IDBookingR, DateTime CheckoutPlan)
        {
            InitializeComponent();
            this.afrmTsk_ListBookingRs = afrmTsk_ListBookingRs;
            this.IDBookingR = IDBookingR;
            this.CheckoutPlan = CheckoutPlan;
            this.aCheckInEN = this.InitData(this.IDBookingR);
        }


        //Hiennv     26/11/2014       ham dung de load toan bo du lieu theo IDBookingR
        public CheckInEN InitData(int IDBookingR)
        {
            try
            {
                CheckInEN aCheckInEN = new CheckInEN();
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = new BookingRs();
                aBookingRs = aBookingRsBO.Select_ByID(IDBookingR);
                if(aBookingRs != null)
                {
                    aCheckInEN.IDBookingR = aBookingRs.ID;
                    aCheckInEN.CustomerType = aBookingRs.CustomerType.GetValueOrDefault();
                    aCheckInEN.BookingType = aBookingRs.BookingType.GetValueOrDefault();
                    aCheckInEN.Note = aBookingRs.Note;
                    aCheckInEN.IDCustomerGroup = aBookingRs.IDCustomerGroup;
                    aCheckInEN.IDCustomer = aBookingRs.IDCustomer;
                    aCheckInEN.IDSystemUser = aBookingRs.IDSystemUser;
                    aCheckInEN.PayMenthod = aBookingRs.PayMenthod.GetValueOrDefault();
                    aCheckInEN.StatusPay = aBookingRs.StatusPay.GetValueOrDefault();
                    aCheckInEN.BookingMoney = aBookingRs.BookingMoney.GetValueOrDefault();
                    aCheckInEN.ExchangeRate = aBookingRs.ExchangeRate.GetValueOrDefault();
                    aCheckInEN.Status = aBookingRs.Status.GetValueOrDefault();
                    aCheckInEN.Type = aBookingRs.Type.GetValueOrDefault();
                    aCheckInEN.Disable = aBookingRs.Disable.GetValueOrDefault();
                    aCheckInEN.Level = aBookingRs.Level;
                    aCheckInEN.Subject = aBookingRs.Subject;
                    aCheckInEN.Description = aBookingRs.Description;
                    aCheckInEN.DatePay = aBookingRs.DatePay;
                    aCheckInEN.DateEdit = aBookingRs.DateEdit;
                    CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                    CustomerGroups aCustomerGroups = new CustomerGroups();
                    aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
                    if(aCustomerGroups !=null)
                    {
                        aCheckInEN.IDCompany = aCustomerGroups.IDCompany;
                    }


                }
                RoomsBO aRoomsBO = new RoomsBO();
                List<Rooms> aListRooms = new List<Rooms>();
                aListRooms = aRoomsBO.Select_All();

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                List<BookingRooms> aListBookingRooms = new List<BookingRooms>();
                aListBookingRooms = aBookingRoomsBO.Select_ByIDBookingRs(IDBookingR);
                for (int i = 0; i < aListBookingRooms.Count; i++ )
                {
                    RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                    aRoomMemberEN.IDBookingRooms = aListBookingRooms[i].ID;
                    aRoomMemberEN.RoomCode = aListBookingRooms[i].CodeRoom;
                    aRoomMemberEN.RoomSku = aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).Sku;
                    aRoomMemberEN.RoomType = aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).Type.GetValueOrDefault();
                    aRoomMemberEN.RoomTypeDisplay = CORE.CONSTANTS.SelectedRoomsType(aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).Type.GetValueOrDefault()).Name;
                    aRoomMemberEN.RoomBed1 = aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).Bed1.GetValueOrDefault();
                    aRoomMemberEN.RoomBed2 = aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).Bed2.GetValueOrDefault();
                    aRoomMemberEN.RoomCostRef = aCheckInEN.GetInfoRooms(aListRooms, aListBookingRooms[i].CodeRoom).CostRef.GetValueOrDefault();
                    aRoomMemberEN.RoomCost = aListBookingRooms[i].Cost.GetValueOrDefault();
                    aCheckInEN.InsertRoom(aRoomMemberEN);
                }
                return aCheckInEN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.InitData()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv  tạo mới   26/11/2014
        private void frmTsk_CheckInForRoomBooking_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.aCheckInEN.CustomerType == 1)
                {
                    chkCustomerType.Visible = true;
                    txtNameCompany.Visible = true;
                }
                else if (this.aCheckInEN.CustomerType == 2)
                {
                    chkCustomerType.Visible = false;
                    txtNameCompany.Visible = true;
                }
                else if(this.aCheckInEN.CustomerType == 5)
                {
                    chkCustomerType.Visible = true;
                    chkCustomerType.Checked = true;
                    txtNameCompany.Visible = true;
                }
                else
                {
                    chkCustomerType.Visible = false;
                    txtNameCompany.Visible = false;
                }

               
                dtpFrom.DateTime = DateTime.Now;
                dtpTo.DateTime = this.CheckoutPlan;


                dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                dgvAvailableRooms.DataSource = this.LoadListAvailableRooms(dtpFrom.DateTime, dtpTo.DateTime);
                dgvAvailableRooms.RefreshDataSource();


                this.LoadAllListCustomers();

                lueIDCompanies.Properties.DataSource = this.LoadListCompaniesByType(this.aCheckInEN.CustomerType);
                lueIDCompanies.Properties.ValueMember = "ID";
                lueIDCompanies.Properties.DisplayMember = "Name";
                lueIDCompanies.EditValue = this.aCheckInEN.IDCompany;
                if (this.aCheckInEN.CustomerType == 3) // khach le
                {
                    if (this.LoadListCompaniesByType(this.aCheckInEN.CustomerType).Count > 0)
                    {
                        lueIDCompanies.EditValue = this.LoadListCompaniesByType(this.aCheckInEN.CustomerType)[0].ID;
                    }
                }

                lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gioi tinh
                lueGender.Properties.DisplayMember = "Name";
                lueGender.Properties.ValueMember = "ID";
                lueGender.EditValue = CORE.CONSTANTS.SelectedGender(1).ID;

                lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
                lueNationality.Properties.DisplayMember = "Name";
                lueNationality.Properties.ValueMember = "Code";
                lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;

                if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {
                    RoomsBO aRoomsBO = new RoomsBO();
                    lblRoomSku.Text = "Phòng số :" + aRoomsBO.Select_ByCodeRoom(this.aCurrent_CodeRoom, 1).Sku;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.frmTsk_CheckInForRoomBooking_Group_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    tạo mới      26/11/2014   Load ra toàn bộ danh sách công ty theo loại công ty (Nhà nước, đoàn ,lẻ)
        private List<Companies> LoadListCompaniesByType(int type)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                return aCompaniesBO.Select_ByType(type);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.LoadListCompaniesByType()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    tạo mới     26/11/2014   Kiểm tra dữ liệu đầu vào khi tìm kiếm phòng còn trống
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
                MessageBox.Show("frmTsk_CheckInForRoomBooking.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv    Tạo mới     26/11/2014   Load ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
        public List<RoomMemberEN> LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (this.CheckData() == true)
                {
                    List<Rooms> aListRooms = aReceptionTaskBO.GetListAvailableRooms(fromDate, toDate, 1).OrderBy(r => r.Sku).ToList(); // 1=IDLang
                    RoomMemberEN aRoomMemberEN;
                    for (int i = 0; i < aListRooms.Count; i++)
                    {
                        aRoomMemberEN = new RoomMemberEN();
                        aRoomMemberEN.IDBookingRooms = aListRooms[i].ID;
                        aRoomMemberEN.RoomCode = aListRooms[i].Code;
                        aRoomMemberEN.RoomSku = aListRooms[i].Sku;
                        aRoomMemberEN.RoomBed1 = aListRooms[i].Bed1.GetValueOrDefault();
                        aRoomMemberEN.RoomBed2 = aListRooms[i].Bed2.GetValueOrDefault();
                        aRoomMemberEN.RoomCostRef = aListRooms[i].CostRef.GetValueOrDefault();
                        aRoomMemberEN.RoomTypeDisplay = CORE.CONSTANTS.SelectedRoomsType(Convert.ToInt32(aListRooms[i].Type)).Name;
                        this.aListAvaiableRooms.Add(aRoomMemberEN);
                    }
                }
                return this.aListAvaiableRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    Tạo mới     26/11/2014   Tim ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CheckData() == true)
                {
                    DateTime From = dtpFrom.DateTime;
                    DateTime To = dtpTo.DateTime;
                    this.aListAvaiableRooms.Clear();
                    dgvAvailableRooms.DataSource = this.LoadListAvailableRooms(From, To);
                    dgvAvailableRooms.RefreshDataSource();

                    foreach(RoomMemberEN aRoomMemberEN in this.aCheckInEN.aListRoomMembers)
                    {
                        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                        BookingRooms aBookingRooms = new BookingRooms();
                        aBookingRooms = aBookingRoomsBO.Select_ByIDBookingRsAndIDBookingRoom(this.IDBookingR,aRoomMemberEN.IDBookingRooms);
                        if (aBookingRooms != null)
                        {
                            if (this.aListRemoveBookingRooms.Where(r=>r.ID == aRoomMemberEN.IDBookingRooms).ToList().Count <= 0)
                            {
                                this.aListRemoveBookingRooms.Add(aBookingRooms);
                            }
                        }
                    }
                    


                    this.aCheckInEN.aListRoomMembers.Clear();
                    dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                    dgvSelectedRooms.RefreshDataSource();


                    this.aCurrent_CodeRoom = string.Empty;
                    lblRoomSku.Text = "Phòng số :000";
                    this.aCheckInEN.ClearAllListCustomer();
                    dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                    dgvSelectedCustomer.RefreshDataSource();
                    this.ResetValueAddNew();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     26/11/2014   
        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.IDBookingRooms = 0;
                aRoomMemberEN.RoomSku = viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomMemberEN.RoomCode = viewAvailableRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomMemberEN.RoomTypeDisplay = viewAvailableRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed1").ToString());
                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed2").ToString());
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("RoomCostRef").ToString());

                this.aCheckInEN.InsertRoom(aRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                List<RoomMemberEN> Temps = aListAvaiableRooms.Where(p => p.RoomSku == viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList();
                if (Temps.Count > 0)
                {
                    this.aListAvaiableRooms.Remove(Temps[0]);
                    dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                    dgvAvailableRooms.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     26/11/2014
        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.IDBookingRooms = 0;
                aRoomMemberEN.RoomCode = viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomMemberEN.RoomSku = viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomMemberEN.RoomTypeDisplay = viewSelectedRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed1"));
                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed2"));
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewSelectedRooms.GetFocusedRowCellValue("RoomCostRef"));

                this.aListAvaiableRooms.Insert(0, aRoomMemberEN);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = new BookingRooms();
                aBookingRooms = aBookingRoomsBO.Select_ByIDBookingRsAndIDBookingRoom(this.IDBookingR, Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("IDBookingRooms")));
                if (aBookingRooms != null)
                {
                    this.aListRemoveBookingRooms.Add(aBookingRooms);
                }

                RoomMemberEN Temps = aCheckInEN.IsCodeRoomExistInRoom(viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString());
                if(Temps !=null)
                {
                    this.aCheckInEN.RemoveRoom(Temps);
                    dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                    dgvSelectedRooms.RefreshDataSource();
                }

                if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {
                    if (this.aCheckInEN.GetListRoomMemberByCodeRoom(this.aCurrent_CodeRoom).Count <= 0)
                    {
                        this.aCurrent_CodeRoom = string.Empty;
                        lblRoomSku.Text = "Phòng số : 000";
                        dgvSelectedCustomer.DataSource = null;
                        dgvSelectedCustomer.RefreshDataSource();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     26/11/2014
        public void LoadAllListCustomers()
        {
            try
            {
                aListAvailableCustomers.Clear();
                CustomersBO aCustomersBO = new CustomersBO();
                aListAvailableCustomers = aCustomersBO.Select_All();
                dgvAvailableCustomer.DataSource = aListAvailableCustomers;
                dgvAvailableCustomer.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.LoadAllListCustomers()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     26/11/2014
        private void btnSelectPepoleToRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {
                    dgvSelectedRooms.Focus();
                    MessageBox.Show("Vui lòng chọn phòng cần thêm người vào trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DateTime? dateTime = null;
                    CustomerInfoEN aCustomerInfoEN = new CustomerInfoEN();
                    int IDCustomer = Convert.ToInt32(grvAvailableCustomer.GetFocusedRowCellValue("ID"));
                    aCustomerInfoEN.ID = IDCustomer;
                    aCustomerInfoEN.RoomCode = this.aCurrent_CodeRoom;
                    aCustomerInfoEN.Name = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Name"));
                    aCustomerInfoEN.Identifier1 = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Identifier1"));
                    aCustomerInfoEN.Birthday = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(grvAvailableCustomer.GetFocusedRowCellValue("Birthday"));
                    aCustomerInfoEN.Tel = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Tel"))) == true ? String.Empty : Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Tel"));
                    aCustomerInfoEN.Gender = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Gender"))) == true ? String.Empty : Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Gender"));
                    aCustomerInfoEN.Nationality = String.IsNullOrEmpty(Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Nationality"))) == true ? String.Empty : Convert.ToString(grvAvailableCustomer.GetFocusedRowCellValue("Nationality"));
                    aCustomerInfoEN.PepoleRepresentative = false;

                    if (this.aCheckInEN.IsCustomerExistInRoom(this.aCurrent_CodeRoom, IDCustomer) == true)
                    {
                        MessageBox.Show("Khách đã có ở trong phòng vui lòng chọn người khác.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                        {
                            this.aCheckInEN.AddCustomerToRoom(this.aCurrent_CodeRoom, aCustomerInfoEN);
                            dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                            dgvSelectedCustomer.RefreshDataSource();
                        }
                    }

                    List<Customers> aListTemps = aListAvailableCustomers.Where(c => c.ID == Convert.ToInt32(grvAvailableCustomer.GetFocusedRowCellValue("ID"))).ToList();
                    if (aListTemps.Count > 0)
                    {
                        this.aListAvailableCustomers.Remove(aListTemps[0]);
                    }
                    dgvAvailableCustomer.DataSource = this.aListAvailableCustomers;
                    dgvAvailableCustomer.RefreshDataSource();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnSelectPepoleToRoom_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới    26/11/2014
        private void btnDeletePepoleOutRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DateTime? dateTime = null;
                Customers aCustomers = new Customers();

                aCustomers.ID = Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID"));
                aCustomers.Name = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Name"));
                aCustomers.Identifier1 = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Identifier1"));
                aCustomers.Birthday = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(viewSelectedCustomer.GetFocusedRowCellValue("Birthday"));
                aCustomers.Tel = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Tel"))) == true ? String.Empty : Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Tel"));
                aCustomers.Gender = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Gender"))) == true ? String.Empty : Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Gender"));
                aCustomers.Nationality = String.IsNullOrEmpty(Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Nationality"))) == true ? String.Empty : Convert.ToString(viewSelectedCustomer.GetFocusedRowCellValue("Nationality"));


                this.aListAvailableCustomers.Insert(0, aCustomers);
                dgvSelectedCustomer.DataSource = aListAvailableCustomers;
                dgvSelectedCustomer.RefreshDataSource();

                this.aCheckInEN.RemoveCustomerToRoom(Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID").ToString()));
                dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                dgvSelectedCustomer.RefreshDataSource();

                if (this.aCheckInEN.IsCustomerExistInRoom(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer) == false)
                {
                    this.ResetValueAddNew();

                    this.aCurrent_IDCustomer = 0;
                }
                if (this.aCheckInEN.IsCustomerExistInRoom(this.aCurrent_CodeRoom, Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID"))) == false)
                {
                    this.aCheckInEN.SetValuePepoleRepresentative(Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnRemoveSelectCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới    26/11/2014
        private void viewSelectedRooms_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();
                this.aCurrent_CodeRoom = viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                lblRoomSku.Text = "Phòng số :" + aRoomsBO.Select_ByCodeRoom(this.aCurrent_CodeRoom, 1).Sku;

                dgvSelectedCustomer.DataSource = null;
                dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                dgvSelectedCustomer.RefreshDataSource();



            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.viewSelectedRooms_RowCellClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới    26/11/2014   Chọn người đại diện đặt phòng
        private void chkIDCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.aCheckInEN.IDCustomer = Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID"));
                this.aCheckInEN.SetValuePepoleRepresentative(Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID")));
                dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                dgvSelectedCustomer.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.chkIDCustomer_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014
        private void viewSelectedCustomer_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                txtNames.Focus();
                this.aCurrent_IDCustomer = Convert.ToInt32(viewSelectedCustomer.GetFocusedRowCellValue("ID"));
                if (this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer) != null)
                {
                    lblIDCustomer.Text = Convert.ToString(this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).ID);
                    txtNames.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Name;
                    txtIdentifier1.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Identifier1;
                    dtpBirthday.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Birthday;
                    lueGender.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Gender;
                    txtTel.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Tel;
                    lueNationality.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Nationality;

                    txtPurposeComeVietnam.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).PurposeComeVietnam;
                    dtpDateEnterCountry.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).DateEnterCountry;
                    txtEnterGate.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).EnterGate;
                    dtpTemporaryResidenceDate.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).TemporaryResidenceDate;
                    dtpLeaveDate.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).LeaveDate;
                    txtOrganization.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).Organization;
                    dtpLimitDateEnterCountry.EditValue = this.aCheckInEN.GetCustomerInfoByRoomCodeAndIDCustomer(this.aCurrent_CodeRoom, this.aCurrent_IDCustomer).LimitDateEnterCountry;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.viewSelectedCustomer_RowCellClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014  
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResetValueAddNew();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnAddNewCustomer_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014  xóa trắng các textbox
        private void ResetValueAddNew()
        {
            try
            {
                this.aCurrent_IDCustomer =0;
                lblIDCustomer.Text = "000";
                txtNames.EditValue = string.Empty;
                txtIdentifier1.EditValue = string.Empty;
                dtpBirthday.EditValue = null;
                lueGender.EditValue = CORE.CONSTANTS.SelectedGender(1).ID;
                txtTel.EditValue = string.Empty;
                lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;

                txtPurposeComeVietnam.EditValue = string.Empty;
                dtpDateEnterCountry.EditValue = null;
                txtEnterGate.EditValue = string.Empty;
                dtpTemporaryResidenceDate.EditValue = null;
                dtpLeaveDate.EditValue = null;
                txtOrganization.EditValue = string.Empty;
                dtpLimitDateEnterCountry.EditValue = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.ResetValueText()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014  luu tam thong tin khach hang
        public void SaveCustomer()
        {
            try
            {
                if (this.CheckDataBeforeSaveCustomer() == true)
                {

                    DateTime? dateTime = null;
                    int IDCustomer = 0;

                    if (this.aCurrent_IDCustomer != 0)
                    {
                        this.aCheckInEN.RemoveCustomerToRoom(this.aCurrent_IDCustomer);
                        List<Customers> aListTemps = aListAvailableCustomers.Where(c => c.ID == this.aCurrent_IDCustomer).ToList();
                        if (aListTemps.Count > 0)
                        {
                            this.aListAvailableCustomers.Remove(aListTemps[0]);
                        }
                    }

                    if (String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                    {
                        MessageBox.Show("Vui lòng chọn phòng trước khi thêm người vào phòng.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CustomerInfoEN aCustomerInfoEN = new CustomerInfoEN();

                        if (this.aCurrent_IDCustomer == 0)
                        {
                            IDCustomer = StringUtility.AutoCreateCode();
                        }
                        else
                        {
                            IDCustomer = this.aCurrent_IDCustomer;
                        }

                        aCustomerInfoEN.ID = IDCustomer;
                        aCustomerInfoEN.RoomCode = this.aCurrent_CodeRoom;
                        aCustomerInfoEN.Name = txtNames.Text;
                        aCustomerInfoEN.Identifier1 = txtIdentifier1.Text;
                        aCustomerInfoEN.Birthday = String.IsNullOrEmpty(dtpBirthday.Text) ? dateTime : dtpBirthday.DateTime;
                        aCustomerInfoEN.Gender = Convert.ToString(lueGender.EditValue);
                        aCustomerInfoEN.Tel = txtTel.Text;
                        aCustomerInfoEN.Nationality = Convert.ToString(lueNationality.EditValue);
                        aCustomerInfoEN.PurposeComeVietnam = txtPurposeComeVietnam.Text;
                        aCustomerInfoEN.DateEnterCountry = String.IsNullOrEmpty(dtpDateEnterCountry.Text) ? dateTime : dtpDateEnterCountry.DateTime;
                        aCustomerInfoEN.EnterGate = txtEnterGate.Text;
                        aCustomerInfoEN.TemporaryResidenceDate = String.IsNullOrEmpty(dtpTemporaryResidenceDate.Text) ? dateTime : dtpTemporaryResidenceDate.DateTime;
                        aCustomerInfoEN.LeaveDate = String.IsNullOrEmpty(dtpLeaveDate.Text) ? dateTime : dtpLeaveDate.DateTime;
                        aCustomerInfoEN.Organization = txtOrganization.Text;
                        aCustomerInfoEN.LimitDateEnterCountry = String.IsNullOrEmpty(dtpLimitDateEnterCountry.Text) ? dateTime : dtpLimitDateEnterCountry.DateTime;
                        aCustomerInfoEN.PepoleRepresentative = false;
                        this.aCheckInEN.AddCustomerToRoom(this.aCurrent_CodeRoom, aCustomerInfoEN);

                        dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                        dgvSelectedCustomer.RefreshDataSource();


                    }
                    this.ResetValueAddNew();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.SaveCustomer()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnSaveCustomer_Click()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   26/11/2014  kiểm tra dữ liệu đầu vào trước khi lưu thông tin khách hàng
        private bool CheckDataBeforeSaveCustomer()
        {
            try
            {
                if(String.IsNullOrEmpty(txtNames.Text))
                {
                    txtNames.Focus();
                    MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (dtpBirthday.EditValue != null)
                {
                    if (dtpBirthday.DateTime.Date > DateTime.Now.Date)
                    {
                        dtpBirthday.Focus();
                        MessageBox.Show("Vui lòng nhập ngày sinh phải nhỏ hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (dtpDateEnterCountry.EditValue != null)
                {
                    if (dtpDateEnterCountry.DateTime.Date > DateTime.Now.Date)
                    {
                        dtpDateEnterCountry.Focus();
                        MessageBox.Show("Vui lòng nhập ngày nhập cảnh phải nhỏ hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (dtpTemporaryResidenceDate.EditValue != null)
                {
                    if (dtpTemporaryResidenceDate.DateTime.Date < DateTime.Now.Date)
                    {
                        dtpTemporaryResidenceDate.Focus();
                        MessageBox.Show("Vui lòng nhập ngày đăng ký tạm trú phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (dtpLeaveDate.EditValue != null)
                {
                    if (dtpLeaveDate.DateTime.Date < DateTime.Now.Date)
                    {
                        dtpLeaveDate.Focus();
                        MessageBox.Show("Vui lòng nhập ngày dự kiến đi phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (dtpTemporaryResidenceDate.EditValue != null && dtpLeaveDate.EditValue != null)
                {
                    if (dtpTemporaryResidenceDate.DateTime.Date > dtpLeaveDate.DateTime.Date)
                    {
                        dtpTemporaryResidenceDate.Focus();
                        MessageBox.Show("Vui lòng nhập ngày đăng ký tạm trú phải nhỏ hơn hoặc bằng ngày đi dự kiến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (dtpLimitDateEnterCountry.EditValue != null)
                {
                    if (dtpLimitDateEnterCountry.DateTime.Date < DateTime.Now.Date)
                    {
                        dtpLimitDateEnterCountry.Focus();
                        MessageBox.Show("Vui lòng nhập ngày hết hạn cư trú phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.CheckDataBeforeSaveCustomer()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv    Tạo mới      26/11/2014  kiểm tra dữ liệu trước khi thực hiện checkIn phòng
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
                if (this.aCheckInEN.aListRoomMembers.Count <= 0)
                {
                    dgvAvailableRooms.Focus();
                    MessageBox.Show("Vui lòng chọn phòng cần checkIn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.CheckDataBeforeCheckIn()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv             Tạo mới          26/11/2014         
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
                MessageBox.Show("frmTsk_CheckInForRoomBooking.txtNameCompany_EditValueChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv             Tạo mới          26/11/2014    
        private void chkCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCustomerType.Checked == true)
                {
                    this.aCheckInEN.CustomerType = 5; // Khach thuoc bo ngoai giao
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.chkCustomerType_CheckedChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv  tạo mới   26/11/2014     checkIn phòng
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.CheckDataBeforeCheckIn() == true)
                {

                    if (!String.IsNullOrEmpty(txtNames.Text) || !String.IsNullOrEmpty(txtIdentifier1.Text) || !String.IsNullOrEmpty(dtpBirthday.Text)
                        || !String.IsNullOrEmpty(txtTel.Text) || !String.IsNullOrEmpty(txtPurposeComeVietnam.Text) || !String.IsNullOrEmpty(dtpDateEnterCountry.Text)
                    || !String.IsNullOrEmpty(txtEnterGate.Text) || !String.IsNullOrEmpty(dtpTemporaryResidenceDate.Text) || !String.IsNullOrEmpty(dtpLeaveDate.Text)
                    || !String.IsNullOrEmpty(txtOrganization.Text) || !String.IsNullOrEmpty(dtpLimitDateEnterCountry.Text))
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn lưu lại thông tin khách hàng không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult.Yes == result)
                        {
                            this.SaveCustomer();
                        }
                    }


                    if (String.IsNullOrEmpty(txtNameCompany.Text))
                    {
                        this.aCheckInEN.IDCompany = Convert.ToInt32(lueIDCompanies.EditValue);
                        this.aCheckInEN.NameCompany = lueIDCompanies.Text;
                    }
                    else
                    {
                        this.aCheckInEN.IDCompany = 0;
                        this.aCheckInEN.NameCompany = txtNameCompany.Text;
                    }

                    this.aCheckInEN.CheckInActual = dtpFrom.DateTime;
                    this.aCheckInEN.CheckOutActual = dtpTo.DateTime;
                    this.aCheckInEN.CheckOutPlan = dtpTo.DateTime;
                    this.aCheckInEN.BookingType = 3;   // 1: Dat onlie, 2: Dat qua dien thoai, 3: Truc tiep, 4: Cong van
                    this.aCheckInEN.IDSystemUser = CORE.CURRENTUSER.SystemUser.ID;
                    this.aCheckInEN.PayMenthod = 1;     //1:Tien mat
                    this.aCheckInEN.BookingMoney = Convert.ToDecimal(txtBookingMoney.EditValue);

                    if (this.aCheckInEN.BookingMoney > 0)
                    {
                        this.aCheckInEN.StatusPay = 2; //2:Tam ung
                    }
                    else
                    {
                        this.aCheckInEN.StatusPay = 1; //1:chua thanh toan
                    }

                    this.aCheckInEN.ExchangeRate = 0;
                    this.aCheckInEN.Status = 3; // 3 : da checkin
                    this.aCheckInEN.Type = -1;
                    this.aCheckInEN.Disable = false;

                    ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                    if (aReceptionTaskBO.NewCheckInForRoomBooking(this.aCheckInEN) == true)
                    {
                        #region  dung de huy cac bookingrom da dat truoc nhung khong dat nua
                        if (this.aListRemoveBookingRooms.Count > 0)
                        {
                            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                            aBookingRoomsBO.Remove(aListRemoveBookingRooms);
                        }
                        #endregion

                        if (this.afrmMain != null)
                        {
                            this.afrmMain.ReloadData();
                            this.Close();
                        }
                        if(this.afrmTsk_ListBookingRs !=null)
                        {
                            this.afrmTsk_ListBookingRs.Reload();
                            if(afrmTsk_ListBookingRs.afrmMain !=null)
                            {
                                this.afrmTsk_ListBookingRs.afrmMain.ReloadData();
                                this.Close();
                            }
                        }
                        MessageBox.Show("Thực hiện checkIn cho phòng đã đặt thành công .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CheckIn cho phòng đã đặt thất bại vui lòng thực hiện lại.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.btnCheckIn_Click()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}