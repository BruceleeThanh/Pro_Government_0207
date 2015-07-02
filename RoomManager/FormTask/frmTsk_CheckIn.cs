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
    public partial class frmTsk_CheckIn : DevExpress.XtraEditors.XtraForm
    {
        private List<RoomMemberEN> aListAvaiableRooms = new List<RoomMemberEN>();
        private List<Customers> aListAvailableCustomers = new List<Customers>();
        private CheckInEN aCheckInEN = new CheckInEN();
        private frmMain afrmMain = null;

        private string aCurrent_CodeRoom = string.Empty;
        private int aCurrent_IDCustomer = 0;

        private int customerType = 0;

        //Hiennv  18/11/2014
        public frmTsk_CheckIn(frmMain afrmMain, int customerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.customerType = customerType;
        }
        //Hiennv  25/11/2014
        public frmTsk_CheckIn(frmMain afrmMain, string codeRoom, int customerType)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.aCurrent_CodeRoom = codeRoom;
            this.customerType = customerType;
        }


        //Hiennv  tạo mới   18/11/2014
        private void frmTsk_CheckIn_Load(object sender, EventArgs e)
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


                this.LoadAllListCustomers();

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


                lueGender.Properties.DataSource = CORE.CONSTANTS.ListGenders;//Load Gioi tinh
                lueGender.Properties.DisplayMember = "Name";
                lueGender.Properties.ValueMember = "ID";
                lueGender.EditValue = CORE.CONSTANTS.SelectedGender(1).ID;

                lueNationality.Properties.DataSource = CORE.CONSTANTS.ListCountries;//Load Country 
                lueNationality.Properties.DisplayMember = "Name";
                lueNationality.Properties.ValueMember = "Code";
                lueNationality.EditValue = CORE.CONSTANTS.SelectedCountry(704).Code;


                lueCitizen.Properties.DataSource = CORE.CONSTANTS.ListCitizens;//Load Citizen 
                lueCitizen.Properties.DisplayMember = "Name";
                lueCitizen.Properties.ValueMember = "ID";
                lueCitizen.EditValue = CORE.CONSTANTS.SelectedCitizen(2).ID;

                if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {
                    RoomsBO aRoomsBO = new RoomsBO();
                    lblRoomSku.Text = "Phòng số :" + aRoomsBO.Select_ByCodeRoom(this.aCurrent_CodeRoom, 1).Sku;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.frmTsk_CheckIn_Group_Step1_Load\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    tạo mới      18/11/2014   Load ra toàn bộ danh sách công ty theo loại công ty (Nhà nước, đoàn ,lẻ)
        private List<Companies> LoadListCompaniesByType(int type)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                return aCompaniesBO.Select_ByType(type);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.LoadListCompaniesByType()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv    tạo mới     18/11/2014   Kiểm tra dữ liệu đầu vào khi tìm kiếm phòng còn trống
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
                MessageBox.Show("frmTsk_CheckIn.CheckData\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv    Tạo mới     18/11/2014   Load ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
        public List<RoomMemberEN> LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                if (this.CheckData() == true)
                {
                    aCheckInEN.aListRoomMembers.Clear();
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
                MessageBox.Show("frmTsk_CheckIn.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //Hiennv   25/11/2014   load ra danh sach cac phong da duoc chon
        public List<RoomMemberEN> LoadListSelectRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.aCurrent_CodeRoom))
                {

                    List<RoomMemberEN> aListRoomMemberEN = this.aListAvaiableRooms.Where(p => p.RoomCode == this.aCurrent_CodeRoom).ToList();
                    if (aListRoomMemberEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListRoomMemberEN[0]);

                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                        aRoomMemberEN.RoomSku = aListRoomMemberEN[0].RoomSku;
                        aRoomMemberEN.RoomCode = aListRoomMemberEN[0].RoomCode;
                        aRoomMemberEN.RoomTypeDisplay = aListRoomMemberEN[0].RoomTypeDisplay;
                        aRoomMemberEN.RoomBed1 = aListRoomMemberEN[0].RoomBed1;
                        aRoomMemberEN.RoomBed2 = aListRoomMemberEN[0].RoomBed2;
                        aRoomMemberEN.RoomCostRef = aListRoomMemberEN[0].RoomCostRef;
                        this.aCheckInEN.InsertRoom(aRoomMemberEN);
                    }
                    return this.aCheckInEN.aListRoomMembers;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.LoadListSelectRooms()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Hiennv    Tạo mới     18/11/2014   Tim ra toàn bộ danh sách phòng còn trống trong khoảng thời gian tìm kiếm
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

                    this.aCheckInEN.aListRoomMembers.Clear();
                    dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                    dgvSelectedRooms.RefreshDataSource();

                    this.aCurrent_CodeRoom = string.Empty;
                    lblRoomSku.Text = "Phòng số :000";
                    this.aCheckInEN.ClearAllListCustomer();
                    dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                    dgvSelectedCustomer.RefreshDataSource();
                    this.ResetValueAddNew();

                    List<RoomMemberEN> aListRoomMemberEN = this.aListAvaiableRooms.Where(p => p.RoomCode == this.aCurrent_CodeRoom).ToList();
                    if (aListRoomMemberEN.Count > 0)
                    {
                        this.aListAvaiableRooms.Remove(aListRoomMemberEN[0]);
                        dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                        dgvAvailableRooms.RefreshDataSource();

                        RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                        aRoomMemberEN.RoomSku = aListRoomMemberEN[0].RoomSku;
                        aRoomMemberEN.RoomCode = aListRoomMemberEN[0].RoomCode;
                        aRoomMemberEN.RoomTypeDisplay = aListRoomMemberEN[0].RoomTypeDisplay;
                        aRoomMemberEN.RoomBed1 = aListRoomMemberEN[0].RoomBed1;
                        aRoomMemberEN.RoomBed2 = aListRoomMemberEN[0].RoomBed2;
                        aRoomMemberEN.RoomCostRef = aListRoomMemberEN[0].RoomCostRef;

                        this.aCheckInEN.InsertRoom(aRoomMemberEN);
                        dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                        dgvSelectedRooms.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.btnSearch_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     18/11/2014   
        private void btnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.RoomSku = viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomMemberEN.RoomCode = viewAvailableRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomMemberEN.RoomTypeDisplay = viewAvailableRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed1").ToString());
                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewAvailableRooms.GetFocusedRowCellValue("RoomBed2").ToString());
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewAvailableRooms.GetFocusedRowCellValue("RoomCostRef").ToString());

                this.aCheckInEN.InsertRoom(aRoomMemberEN);
                dgvSelectedRooms.DataSource = this.aCheckInEN.aListRoomMembers;
                dgvSelectedRooms.RefreshDataSource();

                RoomMemberEN Temps = aListAvaiableRooms.Where(p => p.RoomSku == viewAvailableRooms.GetFocusedRowCellValue("RoomSku").ToString()).ToList()[0];
                this.aListAvaiableRooms.Remove(Temps);
                dgvAvailableRooms.DataSource = this.aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.btnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     18/11/2014
        private void btnUnSelect_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomMemberEN aRoomMemberEN = new RoomMemberEN();
                aRoomMemberEN.RoomCode = viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString();
                aRoomMemberEN.RoomSku = viewSelectedRooms.GetFocusedRowCellValue("RoomSku").ToString();
                aRoomMemberEN.RoomTypeDisplay = viewSelectedRooms.GetFocusedRowCellValue("RoomTypeDisplay").ToString();
                aRoomMemberEN.RoomBed1 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed1"));
                aRoomMemberEN.RoomBed2 = Convert.ToInt32(viewSelectedRooms.GetFocusedRowCellValue("RoomBed2"));
                aRoomMemberEN.RoomCostRef = Convert.ToDecimal(viewSelectedRooms.GetFocusedRowCellValue("RoomCostRef"));

                this.aListAvaiableRooms.Insert(0, aRoomMemberEN);
                dgvAvailableRooms.DataSource = aListAvaiableRooms;
                dgvAvailableRooms.RefreshDataSource();

                RoomMemberEN Temps = aCheckInEN.IsCodeRoomExistInRoom(viewSelectedRooms.GetFocusedRowCellValue("RoomCode").ToString());
                if (Temps != null)
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
                MessageBox.Show("frmTsk_CheckIn.btnUnSelect_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv    Tạo mới     18/11/2014
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
                MessageBox.Show("frmTsk_CheckIn.LoadAllListCustomers()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv    Tạo mới     18/11/2014
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
                MessageBox.Show("frmTsk_CheckIn.btnSelectPepoleToRoom_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới    18/11/2014
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
                MessageBox.Show("frmTsk_CheckIn.btnRemoveSelectCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv     Tạo mới    18/11/2014
        private void viewSelectedRooms_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();
                this.aCurrent_CodeRoom = Convert.ToString(viewSelectedRooms.GetFocusedRowCellValue("RoomCode"));
                lblRoomSku.Text = "Phòng số :" + aRoomsBO.Select_ByCodeRoom(this.aCurrent_CodeRoom, 1).Sku;

                dgvSelectedCustomer.DataSource = null;
                dgvSelectedCustomer.DataSource = this.aCheckInEN.GetListCustomerByRoomCode(this.aCurrent_CodeRoom);
                dgvSelectedCustomer.RefreshDataSource();



            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.viewSelectedRooms_RowCellClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv     Tạo mới    18/11/2014   Chọn người đại diện đặt phòng
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
                MessageBox.Show("frmTsk_CheckIn.chkIDCustomer_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv     Tạo mới   19/11/2014
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
                MessageBox.Show("frmTsk_CheckIn.viewSelectedCustomer_RowCellClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv     Tạo mới   19/11/2014  
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResetValueAddNew();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.btnAddNewCustomer_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   19/11/2014  xóa trắng các textbox
        private void ResetValueAddNew()
        {
            try
            {
                this.aCurrent_IDCustomer = 0;
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
                MessageBox.Show("frmTsk_CheckIn.ResetValueText()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   21/11/2014  luu tam thong tin khach hang
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
                        aCustomerInfoEN.Citizen = Convert.ToInt32(lueCitizen.EditValue);
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


                        //Customers aCustomers = new Customers();

                        //aCustomers.ID = IDCustomer;
                        //aCustomers.Name = txtNames.Text;
                        //aCustomers.Identifier1 = txtIdentifier1.Text;
                        //aCustomers.Birthday = String.IsNullOrEmpty(dtpBirthday.Text) ? dateTime : dtpBirthday.DateTime;
                        //aCustomers.Gender = Convert.ToString(lueGender.EditValue);
                        //aCustomers.Tel = txtTel.Text;
                        //aCustomers.Nationality = Convert.ToString(lueNationality.EditValue);
                        //this.aListAvailableCustomers.Insert(0, aCustomers);

                        //dgvAvailableCustomer.DataSource = this.aListAvailableCustomers;
                        //dgvAvailableCustomer.RefreshDataSource();

                    }
                    this.ResetValueAddNew();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.SaveCustomer()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hiennv     Tạo mới   19/11/2014
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.btnSaveCustomer_Click()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv     Tạo mới   19/11/2014  kiểm tra dữ liệu đầu vào trước khi lưu thông tin khách hàng
        private bool CheckDataBeforeSaveCustomer()
        {
            try
            {
                if (String.IsNullOrEmpty(txtNames.Text))
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
                MessageBox.Show("frmTsk_CheckIn.CheckDataBeforeSaveCustomer()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv    Tạo mới      20/11/2014  kiểm tra dữ liệu trước khi thực hiện checkIn phòng
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

                // Thanh sua loi - 01/07/2015
                // Bat dau

                // Phong ko co nguoi van checkin thanh cong
                string notiRoomEmpty = "Vui lòng thêm khách vào phòng ";
                bool checkRoomEmpty = false;
                foreach (RoomMemberEN checkListCus in aCheckInEN.aListRoomMembers) {
                    if (checkListCus.ListCustomer.Count == 0) {
                        notiRoomEmpty += checkListCus.RoomSku + " ";
                        checkRoomEmpty = true;
                    }
                }
                if (checkRoomEmpty) {
                    MessageBox.Show(notiRoomEmpty, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Check du lieu cua khach moi truoc khi checkin
                if (!this.CheckDataBeforeSaveCustomer()) {
                    return false;
                }

                // Ket thuc

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.CheckDataBeforeCheckIn()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Hiennv             Tạo mới          20/11/2014         
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
                MessageBox.Show("frmTsk_CheckIn.txtNameCompany_EditValueChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv             Tạo mới          20/11/2014    
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
                MessageBox.Show("frmTsk_CheckIn.chkCustomerType_CheckedChanged()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv  tạo mới   20/11/2014     checkIn phòng
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
                    this.aCheckInEN.CustomerType = this.customerType;  // 1: Khach nha nuoc, 2: Khach doan, 3: khach le, 4: Khach vang lai
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

                    

                    if (aReceptionTaskBO.NewCheckIn(this.aCheckInEN) == true)
                    {
                        if (this.afrmMain != null)
                        {
                            this.afrmMain.ReloadData();
                            this.Close();
                        }
                        MessageBox.Show("Thực hiện checkIn phòng thành công .", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CheckIn phòng thất bại vui lòng thực hiện lại.", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.btnCheckIn_Click()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}