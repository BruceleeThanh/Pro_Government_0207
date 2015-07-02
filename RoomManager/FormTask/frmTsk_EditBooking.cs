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
using DevExpress.XtraGrid.Views.Grid;
using Entity;
using DevExpress.XtraGrid.Columns;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_EditBooking : DevExpress.XtraEditors.XtraForm
    {
        private frmMain afrmMain = null;
        private ChangeRoomEN aChangeRoomEn = new ChangeRoomEN();
        private BookingRooms aBookingRoom = new BookingRooms();
        private BookingRs aBookingRs = new BookingRs();
        
        private ItemChangeRoomEN aCurrentRoomInfo = new ItemChangeRoomEN();
        private CustomerInfoEN aCurrentCustomerClick = new CustomerInfoEN();
        private bool IsReadyInitData = false;
        public frmTsk_EditBooking()
        {
            InitializeComponent();
            IsReadyInitData = false;
        }
        public frmTsk_EditBooking(int IDBookingRoom, frmMain afrmMain)
        {
            InitializeComponent();

            BookingRoomsBO aBookingRoomBO = new BookingRoomsBO();
            this.aBookingRoom = aBookingRoomBO.Select_ByID(IDBookingRoom);

            BookingRsBO aBookingRsBO = new BookingRsBO();
            this.aBookingRs = aBookingRsBO.Select_ByID(this.aBookingRoom.IDBookingR);

            this.afrmMain = afrmMain;
            this.IsReadyInitData = false;
            this.aCurrentCustomerClick = new CustomerInfoEN();
        }

        private List<Rooms> GetAvaiableRoom()
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            BookingRsBO aBookingRsBO = new BookingRsBO();

            List<Rooms> aListAvaiableRooms = aReceptionTaskBO.GetListAvailableRooms(DateTime.Parse(dtpCheckIn.Text.ToString()), DateTime.Parse(dtpCheckOut.Text.ToString()), 1);
            List<Rooms> aListRoomInBookingR = aBookingRsBO.SelectListRooms_ByIDBookingR(this.aBookingRoom.IDBookingR, 1);

            return aListRoomInBookingR.Union(aListAvaiableRooms).ToList(); // Nối và loại trừ trùng lặp
        }

        private void frmTsk_EditBooking_Load(object sender, EventArgs e)
        {
            InitForm();
            InitData();
            this.IsReadyInitData = true;
        }

        private void ResetFormWhenTimeChange()
        {
            
            if (aBookingRs.CustomerType == 1)
            {
                lblCustomerType.Text = "Khách nhà nước";
            }
            else if (aBookingRs.CustomerType == 2)
            {
                lblCustomerType.Text = "Cty ngoài";
            }
            else if (aBookingRs.CustomerType == 3)
            {
                lblCustomerType.Text = "Khách lẻ";
            }
            else if (aBookingRs.CustomerType == 4)
            {
                lblCustomerType.Text = "Khách vãng lai";
            }

            CustomersBO aCustomersBO = new CustomersBO();
            CustomerInfoEN aCustomers = new CustomerInfoEN();
            aCustomers = new CustomerInfoEN (aCustomersBO.Select_ByID(aBookingRs.IDCustomer));

            lblCustomer.Text = aCustomers.Name;
            lblTel.Text = aCustomers.Tel;

            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
            lblGroup.Text = aCustomerGroups.Name;

            CompaniesBO aCompaniesBO = new CompaniesBO();
            lblCompany.Text = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany).Name;

            // Fill All Customer

            dgvAvailableCustomers.DataSource = ConvertListCustomer ((new CustomersBO()).Select_All());


            lueRooms.Properties.DataSource = this.GetAvaiableRoom();
            lueRooms.Properties.ValueMember = "Code";
            lueRooms.Properties.DisplayMember = "Sku";    
        

            RoomsBO aRoomsBO = new RoomsBO();
            Rooms aRooms = new Rooms();
            aRooms = aRoomsBO.Select_ByCodeRoom(this.aBookingRoom.CodeRoom, 1);

            lueRooms.Properties.NullText = aRooms.Sku;
            lueRooms.SelectedText = aRooms.Sku;
            lueRooms.EditValue = aRooms.Code; 

            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
            List<BookingRoomsMembers> aListBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom (this.aBookingRoom.ID);

            dgvSelectCustomers.DataSource = GetCustomers(aListBookingRoomsMembers);
            
        }
        private void InitForm()
        {

            // Kiem tra xem phong dang o che do checkIn hay book phong
            if (this.aBookingRoom.Status < 3)
            {
                dtpCheckIn.Text = aBookingRoom.CheckInPlan.ToString();
                
                dtpCheckOut.Text = aBookingRoom.CheckOutPlan.ToString();
            }
            else if (this.aBookingRoom.Status == 3)  // Phong da checkIn
            {
                dtpCheckIn.Text = DateTime.Now.ToString();
                dtpCheckOut.Text = aBookingRoom.CheckOutPlan.ToString();
            }
            
            if (aBookingRs.CustomerType == 1)
            {
                lblCustomerType.Text = "Khách nhà nước";
            }
            else if (aBookingRs.CustomerType == 2)
            {
                lblCustomerType.Text = "Cty ngoài";
            }
            else if (aBookingRs.CustomerType == 3)
            {
                lblCustomerType.Text = "Khách lẻ";
            }
            else if (aBookingRs.CustomerType == 4)
            {
                lblCustomerType.Text = "Khách vãng lai";
            }

            CustomersBO aCustomersBO = new CustomersBO();
            CustomerInfoEN aCustomers = new CustomerInfoEN();
            aCustomers = new CustomerInfoEN (aCustomersBO.Select_ByID(aBookingRs.IDCustomer));

            lblCustomer.Text = aCustomers.Name;
            lblTel.Text = aCustomers.Tel;

            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
            lblGroup.Text = aCustomerGroups.Name;

            CompaniesBO aCompaniesBO = new CompaniesBO();
            lblCompany.Text = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany).Name;

            // Fill All Customer

            dgvAvailableCustomers.DataSource = ConvertListCustomer ((new CustomersBO()).Select_All());


            lueRooms.Properties.DataSource = this.GetAvaiableRoom();
            lueRooms.Properties.ValueMember = "Code";
            lueRooms.Properties.DisplayMember = "Sku";    
        

            RoomsBO aRoomsBO = new RoomsBO();
            Rooms aRooms = new Rooms();
            aRooms = aRoomsBO.Select_ByCodeRoom(this.aBookingRoom.CodeRoom, 1);

            lueRooms.Properties.NullText = aRooms.Sku;
            lueRooms.SelectedText = aRooms.Sku;
            lueRooms.EditValue = aRooms.Code; 

            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
            List<BookingRoomsMembers> aListBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom (this.aBookingRoom.ID);

            dgvSelectCustomers.DataSource = GetCustomers(aListBookingRoomsMembers);
            
            //this.aChangeRoomEn.InsertItemChangeRooms()
        }
        private void InitData()
        {
            ItemChangeRoomEN aItemChangeRoomEN = new ItemChangeRoomEN();
            aItemChangeRoomEN.SetBookingRooms(this.aBookingRoom);

            if (aItemChangeRoomEN.GetStatusBookingRooms() < 3)
            {
                // Phong trang thai dat
            }
            else if (aItemChangeRoomEN.GetStatusBookingRooms() == 3) // Phong dang co nguoi o
            {
                // Thay doi thoi gian de check in
                //aItemChangeRoomEN.SetCheckInActual(dtpCheckIn.DateTime);
            }
            aItemChangeRoomEN.IsRootRoom = true;

            List<CustomerInfoEN> aListCustomer = (List<CustomerInfoEN>)this.dgvSelectCustomers.DataSource;
            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
            BookingRoomsMembers aBookingRoomsMembers = new BookingRoomsMembers();
            for (int i = 0; i < aListCustomer.Count; i++)
            {
                aBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom_ByIDCustomer(this.aBookingRoom.ID, aListCustomer[i].ID);
                aListCustomer[i].LeaveDate = aBookingRoomsMembers.LeaveDate;
                aListCustomer[i].LimitDateEnterCountry = aBookingRoomsMembers.LimitDateEnterCountry;

                aListCustomer[i].PurposeComeVietnam = aBookingRoomsMembers.PurposeComeVietnam;
                aListCustomer[i].TemporaryResidenceDate = aBookingRoomsMembers.TemporaryResidenceDate;
                aListCustomer[i].DateEnterCountry = aBookingRoomsMembers.DateEnterCountry;
                aListCustomer[i].EnterGate = aBookingRoomsMembers.EnterGate;

            }
            aItemChangeRoomEN.AddCustomer(aListCustomer);

            AccountancyBO aAccountancyBO = new AccountancyBO();

            //aItemChangeRoomEN.SetCost(aAccountancyBO.CalculateCostRoom(lueRooms.EditValue.ToString(), this.aBookingRoom.PriceType, aBookingRs.CustomerType.GetValueOrDefault(0), aItemChangeRoomEN.GetAllCustomers().Count).GetValueOrDefault(0));

            this.aCurrentRoomInfo.SetAddTimeStart(null);
            this.aCurrentRoomInfo.SetAddTimeEnd(null);
            this.aCurrentRoomInfo.SetTimeInUsed(null);

            this.aCurrentRoomInfo.SetCheckInActual(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckInPlan(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckOutActual(dtpCheckOut.DateTime);
            this.aCurrentRoomInfo.SetCheckOutPlan(dtpCheckOut.DateTime);

            this.aChangeRoomEn.InsertItemChangeRooms(aItemChangeRoomEN);
            this.aCurrentRoomInfo = aItemChangeRoomEN;
        }

        public void ReloadCustomers()
        { }

        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
            frmUpd_Customers afrmUpd_Customers = new frmUpd_Customers(this, ID);
            afrmUpd_Customers.ShowDialog();
        }

        private void btnRemoveAvaiableCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (lueRooms.EditValue != null)
                {
                    // Check Tinh huong phong moi chua co user, vi phong moi chua co user se gay loi o dong lenh iewAvailableCustomers.GetFocusedRowCellValue("ID") ben duoi
                    if (dgvSelectCustomers.DataSource != null)
                    {
                        if (this.IsExitCustomerInCurrentSelectRoom(Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"))) == true)
                        {
                            MessageBox.Show("Người này đã có trong phòng vui lòng chọn người khác .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MoveCustomerRightToLeft();

                        }
                    }
                    else
                    {
                        dgvSelectCustomers.DataSource = new List<CustomerInfoEN>();
                        MoveCustomerRightToLeft();
                    }


                }
                else
                {
                    lueRooms.Focus();
                    MessageBox.Show("Vui lòng chọn phòng cần chuyển vào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnSelectCustomers_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveSelectCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                MoveCustomerLeftToRight();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmAddListCustomerToCustomerGroups.btnRemoveSelectCustomers_ButtonClick()\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            AccountancyBO aAccountancyBO = new AccountancyBO();
            if (aCurrentRoomInfo.GetAllCustomers().Count <= 5)
            {
                ProcessChangeRoom();
            }
            else
            {
                MessageBox.Show("Phòng không được vượt quá 5 người");
            }


        }
        //#####################################################################
        private List<CustomerInfoEN> GetCustomers(List<BookingRoomsMembers> aList)
        {
            List<CustomerInfoEN> ret = new List<CustomerInfoEN>();
            CustomersBO aCustomersBO = new CustomersBO();
            for (int i = 0; i < aList.Count(); i++)
            {
                CustomerInfoEN aTemp = new CustomerInfoEN(aCustomersBO.Select_ByID(aList[i].IDCustomer));
                aTemp.DateEnterCountry = aList[i].DateEnterCountry;
                aTemp.EnterGate = aList[i].EnterGate;
                aTemp.LimitDateEnterCountry = aList[i].LimitDateEnterCountry;
                aTemp.Organization = aList[i].Organization;

                aTemp.PurposeComeVietnam = aList[i].PurposeComeVietnam;
                aTemp.TemporaryResidenceDate = aList[i].TemporaryResidenceDate;
                ret.Add(aTemp);
            }
            return ret;
        }

        private List<CustomerInfoEN> ConvertListCustomer(List<Customers> aList)
        {
            List<CustomerInfoEN> ret = new List<CustomerInfoEN>();
            for (int i = 0; i < aList.Count; i++)
            {
                CustomerInfoEN aTemp = new CustomerInfoEN(aList[i]);
                ret.Add(aTemp);
                
            }
            return ret ;

        }

        private bool IsExitCustomerInCurrentSelectRoom(int IDCustomer)
        {
            List<CustomerInfoEN> aList = (List<CustomerInfoEN>)this.dgvSelectCustomers.DataSource;
            if (aList.Where(p => p.ID == IDCustomer).ToList().Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void lueRooms_EditValueChanged(object sender, EventArgs e)
        {
            if (this.IsReadyInitData == true)
            {
                // Luu lai thong tin cua chuyen phong cu truoc khi select phong moi
                this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);

                // Chuyen sang select phong moi bang thong tin trong aChangeRoomsEN
                this.aCurrentRoomInfo = this.aChangeRoomEn.GetItemChangeRooms(lueRooms.EditValue.ToString());
                
                // Get list customer for current room
                dgvSelectCustomers.DataSource = this.GetDataForSelectCustomerGridview(lueRooms.EditValue.ToString());

                if (this.aCurrentRoomInfo == null)
                {
                    //add them mot ItemChangeRooms moi 
                    ItemChangeRoomEN aItemChangeRoomEN = new ItemChangeRoomEN();
                    //Kiem tra va danh dau xem phong vua chon co nam trong BookingR ban dau k?
                    //Viec nay lien quan den truong hop chuyen nguoi tu phong A -> B, (A,B cung thuoc BookingR)
                   List<BookingRooms> aList  = (new BookingRoomsBO()).Select_ByIDBookingRs(this.aBookingRs.ID).Where(p => p.CodeRoom == lueRooms.EditValue.ToString()).ToList();
                   int IsSelectRoomInBookingR = aList.Count;
                   int IDBookingRoom = 0;
                    if (IsSelectRoomInBookingR > 0)
                    {
                        aItemChangeRoomEN.IsRoomInBookingR = true;
                        IDBookingRoom = aList.Max(p => p.ID);
                        aItemChangeRoomEN.SetBookingRooms((new BookingRoomsBO()).Select_ByID(IDBookingRoom));
                    }
                    else
                    {
                        aItemChangeRoomEN.IsRoomInBookingR = false;
                        aItemChangeRoomEN.SetBookingRooms(this.aBookingRoom);
                    }
                    //-----------------------------------------------------------

                    

                    aItemChangeRoomEN.SetAddTimeStart(null);
                    aItemChangeRoomEN.SetAddTimeEnd(null);
                    aItemChangeRoomEN.SetTimeInUsed(null);

                    aItemChangeRoomEN.SetCheckInActual(dtpCheckIn.DateTime);
                    aItemChangeRoomEN.SetCheckInPlan(dtpCheckIn.DateTime);
                    aItemChangeRoomEN.SetCheckOutActual(dtpCheckOut.DateTime);
                    aItemChangeRoomEN.SetCheckOutPlan(dtpCheckOut.DateTime);

                    aItemChangeRoomEN.SetTypeBookingRoom(1); // Khong tin chechIn som voi phong chuyen sang sau

                    aItemChangeRoomEN.SetCodeRoom(lueRooms.EditValue.ToString());

                    aItemChangeRoomEN.AddCustomer(this.GetDataForSelectCustomerGridview(lueRooms.EditValue.ToString()));

                    if (aItemChangeRoomEN.GetAllCustomers().Count > 0)
                    {
                        AccountancyBO aAccountancyBO = new AccountancyBO();
                        aItemChangeRoomEN.SetCost(aAccountancyBO.CalculateCostRoom(lueRooms.EditValue.ToString(), this.aBookingRoom.PriceType, aBookingRs.CustomerType.GetValueOrDefault(0), aItemChangeRoomEN.GetAllCustomers().Count).GetValueOrDefault(0));
                    }
                    else
                    {
                        aItemChangeRoomEN.SetCost(0);
                    }

                    this.aChangeRoomEn.InsertItemChangeRooms(aItemChangeRoomEN);
                    this.aCurrentRoomInfo = aItemChangeRoomEN;
                }
            }

        }

        private void MoveCustomerRightToLeft()
        {
            DateTime? dateTime = null;
            CustomerInfoEN aCustomers = new CustomerInfoEN();
            aCustomers.ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
            aCustomers.Name = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Name"));
            aCustomers.Identifier1 = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Identifier1"));
            aCustomers.Birthday = String.IsNullOrEmpty(Convert.ToString(viewAvailableCustomers.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(viewAvailableCustomers.GetFocusedRowCellValue("Birthday"));

            List<CustomerInfoEN> ListAvailableCustomers = (List<CustomerInfoEN>)dgvAvailableCustomers.DataSource;
            CustomerInfoEN aRemoveCustomer = ListAvailableCustomers.Where(p => p.ID == aCustomers.ID).ToList()[0];
            ListAvailableCustomers.Remove(aRemoveCustomer);

            dgvAvailableCustomers.DataSource = null;
            dgvAvailableCustomers.DataSource = ListAvailableCustomers;
            dgvAvailableCustomers.RefreshDataSource();

            List<CustomerInfoEN> ListSelectCustomers = (List<CustomerInfoEN>)dgvSelectCustomers.DataSource;

          
            ListSelectCustomers.Insert(0, aRemoveCustomer);

            dgvSelectCustomers.DataSource = null;
            dgvSelectCustomers.DataSource = ListSelectCustomers;
            dgvSelectCustomers.RefreshDataSource();

            this.aCurrentRoomInfo.SetAddTimeStart(null);
            this.aCurrentRoomInfo.SetAddTimeEnd(null);
            this.aCurrentRoomInfo.SetTimeInUsed(null);

            this.aCurrentRoomInfo.SetCheckInActual(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckInPlan(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckOutActual(dtpCheckOut.DateTime);
            this.aCurrentRoomInfo.SetCheckOutPlan(dtpCheckOut.DateTime);

            this.aCurrentRoomInfo.UpdateCustomer(ListSelectCustomers);
            this.aCurrentRoomInfo.SetCost((new AccountancyBO()).CalculateCostRoom(this.aCurrentRoomInfo.GetCodeRoom(), this.aCurrentRoomInfo.GetPriceType(), this.aBookingRs.CustomerType.GetValueOrDefault(0), this.aCurrentRoomInfo.GetAllCustomers().Count));

            this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);

            this.ClearControl();
        }

        private void MoveCustomerLeftToRight ()
        {
            DateTime? dateTime = null;
            CustomerInfoEN aCustomers = new CustomerInfoEN();
            aCustomers.ID = Convert.ToInt32(viewSelectCustomers.GetFocusedRowCellValue("ID"));
            aCustomers.Name = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Name"))) == true ? String.Empty : Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Name"));
            aCustomers.Identifier1 = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Identifier1"))) == true ? String.Empty : Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Identifier1"));
            aCustomers.Birthday = String.IsNullOrEmpty(Convert.ToString(viewSelectCustomers.GetFocusedRowCellValue("Birthday"))) == true ? dateTime : Convert.ToDateTime(viewSelectCustomers.GetFocusedRowCellValue("Birthday"));

            // Xoa customer khoi danh sach khach trong phong, 
            List<CustomerInfoEN> ListSelectCustomers = (List<CustomerInfoEN>)dgvSelectCustomers.DataSource;
            CustomerInfoEN aRemoveCustomer = ListSelectCustomers.Where(p => p.ID == aCustomers.ID).ToList()[0];
            ListSelectCustomers.Remove(aRemoveCustomer);

            dgvSelectCustomers.DataSource = null;
            dgvSelectCustomers.DataSource = ListSelectCustomers;
            dgvSelectCustomers.RefreshDataSource();
            // Add customer khoi danh sach toan bo khach
            List<CustomerInfoEN> ListAvailableCustomers = (List<CustomerInfoEN>)dgvAvailableCustomers.DataSource;
            ListAvailableCustomers.Insert(0, aCustomers);

            dgvAvailableCustomers.DataSource = null;
            dgvAvailableCustomers.DataSource = ListAvailableCustomers;
            dgvAvailableCustomers.RefreshDataSource();
            // Update lai list customer

            this.aCurrentRoomInfo.SetAddTimeStart(null);
            this.aCurrentRoomInfo.SetAddTimeEnd(null);
            this.aCurrentRoomInfo.SetTimeInUsed(null);

            this.aCurrentRoomInfo.SetCheckInActual(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckInPlan(dtpCheckIn.DateTime);
            this.aCurrentRoomInfo.SetCheckOutActual(dtpCheckOut.DateTime);
            this.aCurrentRoomInfo.SetCheckOutPlan(dtpCheckOut.DateTime);

            this.aCurrentRoomInfo.UpdateCustomer(ListSelectCustomers);
            this.aCurrentRoomInfo.SetCost((new AccountancyBO()).CalculateCostRoom(this.aCurrentRoomInfo.GetCodeRoom(), this.aCurrentRoomInfo.GetPriceType(), this.aBookingRs.CustomerType.GetValueOrDefault(0), this.aCurrentRoomInfo.GetAllCustomers().Count));
            
            this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);

            this.ClearControl();
        }

        private List<CustomerInfoEN> GetDataForSelectCustomerGridview(string CodeRoom)
        {
            BookingRsBO aBookingRsBO = new BookingRsBO();
            List<Rooms> aListRoom = aBookingRsBO.SelectListRooms_ByIDBookingR(this.aBookingRoom.IDBookingR, 1);

            bool IsRoomInBookingR = false;
            if (aListRoom.Where(p=>p.Code == CodeRoom).Where(p=>p.Status <7).ToList().Count == 1)
            {
                IsRoomInBookingR = true;
            }
            // Kiem tra xem phong co phai cung hoa don tong khong (cung BookingR)
            if (IsRoomInBookingR == true)
            {
                // Kiem tra xem da co thong tin cap nhat trong aChangeRoom chua, neu chua thi lay danh sachs khach trong database
                if (this.aChangeRoomEn.IsExitRoom(CodeRoom) == false)
                {
                    BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                    int CurrentIDBookingRooms = aBookingRoomsBO.Select_ByIDBookingRsAndCodeRoom(this.aBookingRoom.IDBookingR, CodeRoom).Max(p=>p.ID);
                    CustomersBO aCustomersBO = new CustomersBO();
                    List<Customers> aList = aCustomersBO.SelectListCustomer_ByIDBookingRoom(CurrentIDBookingRooms);
                    List<CustomerInfoEN> aListRet = new List<CustomerInfoEN>();
                    for (int i = 0; i < aList.Count; i++)
                    {
                        CustomerInfoEN aItem = new CustomerInfoEN(aList[i]);

                        aListRet.Add(aItem);
                    }
                    return aListRet;
                }
                // nếu thông tin phong đã có trong khối aChangeRoom thì lấy danh sách người ở trong khối đó ra
                else 
                {
                    return this.aChangeRoomEn.GetItemChangeRooms(CodeRoom).GetAllCustomers();
                }
            }
            else
            {
                if (this.aChangeRoomEn.IsExitRoom(CodeRoom) == false)
                {
                    return new List<CustomerInfoEN>();
                }
                // nếu thông tin phong đã có trong khối aChangeRoom thì lấy danh sách người ở trong khối đó ra
                else 
                {
                    return this.aChangeRoomEn.GetItemChangeRooms(CodeRoom).GetAllCustomers();
                }
            }
        }


        public void ProcessChangeRoom()
        {
            // Vi moi khi check In luon bi tinh mac dinh 1 ngay
            bool IsRootRoomChangeInDay = false;
            
            ItemChangeRoomEN RootRoom = this.aChangeRoomEn.GetRootItemChangeRoom();
            // Tinh 2 tham so can thiet cho qua trinh chuyen phong
            //===================================================
           
                if (RootRoom.GetStatusBookingRooms() == 3)
                {
                    if (RootRoom.GetCheckInActual().Date == this.aBookingRoom.CheckInActual.Date)
                    {
                        IsRootRoomChangeInDay = true;
                    }
                    else
                    {
                        IsRootRoomChangeInDay = false;
                    }
                }
                else if (RootRoom.GetStatusBookingRooms() < 3)
                {
                    // phòng ở trạng thái đặt
                    MessageBox.Show("Phòng này đang ở trạng thái đặt. Bạn muốn cho người vào phòng hãy sử dụng chức năng checkin");
                    return;
                }
            
            ClearRoomHasNotCustomer();
            List<ItemChangeRoomEN> aaa= this.aChangeRoomEn.GetAllItemChangeRoom();
            List<ItemChangeRoomEN> aListItemChangeRooms = new List<ItemChangeRoomEN>();
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            // Doi phong khac ngay
            if (IsRootRoomChangeInDay == false)
            {
                if (ckbCheckOutNow.Checked == true)
                {
                    (new ReceptionTaskBO()).CheckOutFirstRoom(this.aBookingRoom.ID, DateTime.Now);
                }
                else if (ckbCheckOutNow.Checked == false)
                {
                    (new ReceptionTaskBO()).CheckOutFirstRoom(this.aBookingRoom.ID, dtpCheckIn.DateTime);
                }
                aListItemChangeRooms = this.aChangeRoomEn.GetAllItemChangeRoom();
                // Đổi type cua nhung bookingroom sau bookingroom dau tien
                for (int i = 0; i < aListItemChangeRooms.Count; i++)
                {
                  
                    if (aListItemChangeRooms[i].GetTypeBookingRoom() == 2)
                    {
                      aListItemChangeRooms[i].SetTypeBookingRoom(0);
                    }
                    else if (aListItemChangeRooms[i].GetTypeBookingRoom() == 0)
                    {
                        aListItemChangeRooms[i].SetTypeBookingRoom(0);
                    }
                    else if (aListItemChangeRooms[i].GetTypeBookingRoom() == 3)
                    {
                        aListItemChangeRooms[i].SetTypeBookingRoom(1);
                    }
                    else if (aListItemChangeRooms[i].GetTypeBookingRoom() == 1)
                    {
                        aListItemChangeRooms[i].SetTypeBookingRoom(1);
                    }
                    else
                    {
                        aListItemChangeRooms[i].SetTypeBookingRoom(3);
                    }

                    (new ReceptionTaskBO()).CheckInNewRoom(aListItemChangeRooms[i]);
                }

            }
                // Doi phong trong cung 1 ngay, phong cu khong tinh tien
            else
            {
                

                BookingRooms aItem =  aBookingRoomsBO.Select_ByID(this.aBookingRoom.ID);
                aItem.Cost = 0;
                aItem.CheckOutActual = dtpCheckOut.DateTime;
                aItem.Status = 7;
                aBookingRoomsBO.Update(aItem);

                //va checkIn lai loat moi voi time tu lan checkIn dau tien

                aListItemChangeRooms = this.aChangeRoomEn.GetAllItemChangeRoom();

                for (int i = 0; i < aListItemChangeRooms.Count; i++)
                {

                    aListItemChangeRooms[i].SetCheckInPlan(this.aBookingRoom.CheckInPlan);
                    aListItemChangeRooms[i].SetCheckInActual(this.aBookingRoom.CheckInActual);

                    aListItemChangeRooms[i].SetCheckOutActual(dtpCheckOut.DateTime);
                    aListItemChangeRooms[i].SetCheckOutPlan(dtpCheckOut.DateTime);

                    //Truong hop doi phong trong ngay, thi k tinh tien phong dau ma don het sang phong sau. Vi vay Type cung chuyen sang phong sau
                    aListItemChangeRooms[i].SetTypeBookingRoom(aItem.Type.GetValueOrDefault(3));

                    (new ReceptionTaskBO()).CheckInNewRoom(aListItemChangeRooms[i]);

                }
            }
            //-----------------------------------------------
            aListItemChangeRooms = new List<ItemChangeRoomEN>();
            aListItemChangeRooms = this.aChangeRoomEn.GetAllItemChangeRoom();
            BookingRooms aItem1 = new BookingRooms();
            for (int i = 0; i < aListItemChangeRooms.Count; i++)
            {

                ////---------------------------------------------------
                if (aListItemChangeRooms[i].IsRoomInBookingR == true)
                {
                    aItem1 = new BookingRooms();
                    aItem1 = aBookingRoomsBO.Select_ByID(aListItemChangeRooms[i].GetBookingRooms().ID);
                    if (IsRootRoomChangeInDay == true)
                    {
                        aItem1.Cost = 0;
                    }
                    aItem1.CheckOutActual = dtpCheckIn.DateTime;
                    aItem1.Status = 7;
                    aBookingRoomsBO.Update(aItem1);
                }
            }
            //-----------------------------------------------
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            // Show message box
            DialogResult result = MessageBox.Show("Chuyển phòng thành công","Nhà khách chính phủ", buttons);
            if (result == System.Windows.Forms.DialogResult.OK) 
            {
                this.afrmMain.RefreshData_auc_StatusRooms(DateTime.Now);
                this.Close();

            }
            
            //========================================================
        }

        private void ClearRoomHasNotCustomer()
        {
            //ItemChangeRoomEN RootRoom = new ItemChangeRoomEN();
            //RootRoom = this.aChangeRoomEn.GetRootItemChangeRoom();

            //List<ItemChangeRoomEN> NormalChangeRooms = new List<ItemChangeRoomEN>();
            //NormalChangeRooms = this.aChangeRoomEn.GetListItemChangeRoomNotIncludeRootRoom();
            //for (int i = 0; i < NormalChangeRooms.Count; i++)
            //{
            //    if (NormalChangeRooms[i].GetAllCustomers().Count == 0)
            //    {
            //        this.aChangeRoomEn.RemoveItemChangeRooms(NormalChangeRooms[i].GetCodeRoom());
            //    }
            //}
            List<ItemChangeRoomEN> ChangeRooms = new List<ItemChangeRoomEN>();
            ChangeRooms = this.aChangeRoomEn.GetAllItemChangeRoom();
            for (int i = 0; i < ChangeRooms.Count; i++)
            {
                if (ChangeRooms[i].GetAllCustomers().Count == 0)
                {
                    this.aChangeRoomEn.RemoveItemChangeRooms(ChangeRooms[i].GetCodeRoom());
                }
            }
        }

        private void viewSelectCustomers_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            int aCurrent_IDCustomer;
            try
            {
                this.ClearControl();

                aCurrent_IDCustomer = Convert.ToInt32(viewSelectCustomers.GetFocusedRowCellValue("ID"));
                List<CustomerInfoEN> aList = this.aCurrentRoomInfo.GetAllCustomers().Where(p => p.ID == aCurrent_IDCustomer).ToList();

                if (aList.Count == 1)
                {
                    CustomerInfoEN aCurrentCustomer = aList[0];

                    this.aCurrentCustomerClick = aCurrentCustomer;
                    lblSelectedCustomer.Text = aCurrentCustomer.Name;
                    txtPurposeComeVietnam.EditValue = aCurrentCustomer.PurposeComeVietnam;
                    dtpDateEnterCountry.EditValue = aCurrentCustomer.DateEnterCountry;
                    txtEnterGate.EditValue = aCurrentCustomer.EnterGate;
                    dtpTemporaryResidenceDate.EditValue = aCurrentCustomer.TemporaryResidenceDate;
                    dtpLeaveDate.EditValue = aCurrentCustomer.LeaveDate;
                    txtOrganization.EditValue = aCurrentCustomer.Organization;
                    dtpLimitDateEnterCountry.EditValue = aCurrentCustomer.LimitDateEnterCountry;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckInForRoomBooking.viewSelectedCustomer_RowCellClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearControl()
        {
            txtPurposeComeVietnam.EditValue = null;
            dtpDateEnterCountry.EditValue = null;
            txtEnterGate.EditValue = null;
            dtpTemporaryResidenceDate.EditValue = null;
            dtpLeaveDate.EditValue = null;
            txtOrganization.EditValue = null;
            dtpLimitDateEnterCountry.EditValue = null;
        }

        private void btnApplyBookingRoomMember_Click(object sender, EventArgs e)
        {
            if (this.aCurrentCustomerClick != null)
            {
                this.aCurrentCustomerClick.PurposeComeVietnam = txtPurposeComeVietnam.Text.ToString();

                if (dtpDateEnterCountry.EditValue != null)
                {
                    this.aCurrentCustomerClick.DateEnterCountry = (DateTime)dtpDateEnterCountry.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.TemporaryResidenceDate = DateTime.Parse("01/01/1900");
                }

                this.aCurrentCustomerClick.EnterGate = txtEnterGate.Text;
                if (dtpTemporaryResidenceDate.EditValue != null)
                {
                    this.aCurrentCustomerClick.TemporaryResidenceDate = (DateTime)dtpTemporaryResidenceDate.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.TemporaryResidenceDate = DateTime.Parse("01/01/1900");
                }


                if (dtpLeaveDate.EditValue != null)
                {
                    this.aCurrentCustomerClick.LeaveDate = (DateTime)dtpLeaveDate.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.LeaveDate = DateTime.Parse("01/01/1900");
                }


                this.aCurrentCustomerClick.Organization = txtOrganization.Text;

                if (dtpLimitDateEnterCountry.EditValue != null)
                {
                    this.aCurrentCustomerClick.LimitDateEnterCountry = (DateTime)dtpLimitDateEnterCountry.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.LimitDateEnterCountry = DateTime.Parse("01/01/1900");
                }

                this.aCurrentRoomInfo.UpdateCustomer(this.aCurrentCustomerClick);
            }
            else
            {
                this.aCurrentCustomerClick = new CustomerInfoEN();
                this.aCurrentCustomerClick.PurposeComeVietnam = txtPurposeComeVietnam.Text.ToString();

                if (dtpDateEnterCountry.EditValue != null)
                {this.aCurrentCustomerClick.DateEnterCountry = (DateTime)dtpDateEnterCountry.EditValue;}
                else{this.aCurrentCustomerClick.TemporaryResidenceDate = DateTime.Parse("01/01/1900");}

                this.aCurrentCustomerClick.EnterGate = txtEnterGate.Text;
                if (dtpTemporaryResidenceDate.EditValue != null)
                {
                    this.aCurrentCustomerClick.TemporaryResidenceDate = (DateTime)dtpTemporaryResidenceDate.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.TemporaryResidenceDate = DateTime.Parse("01/01/1900");
                }


                if (dtpLeaveDate.EditValue != null)
                {
                    this.aCurrentCustomerClick.LeaveDate = (DateTime)dtpLeaveDate.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.LeaveDate = DateTime.Parse("01/01/1900");
                }
                

                this.aCurrentCustomerClick.Organization = txtOrganization.Text;

                if (dtpLimitDateEnterCountry.EditValue != null)
                {
                    this.aCurrentCustomerClick.LimitDateEnterCountry = (DateTime)dtpLimitDateEnterCountry.EditValue;
                }
                else
                {
                    this.aCurrentCustomerClick.LimitDateEnterCountry = DateTime.Parse("01/01/1900");
                }


                this.aCurrentRoomInfo.AddCustomer(this.aCurrentCustomerClick);

                this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);
            }

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmIns_Customers afrmIns_Customers = new frmIns_Customers(this);
            afrmIns_Customers.ShowDialog();
        }

        private void dtpCheckIn_EditValueChanged(object sender, EventArgs e)
        {
            //this.aChangeRoomEn = new ChangeRoomEN();
            //ResetFormWhenTimeChange();
            //InitData();
            //this.IsReadyInitData = true;
        }

        private void dtpCheckOut_EditValueChanged(object sender, EventArgs e)
        {
            //this.aChangeRoomEn = new ChangeRoomEN();
            //ResetFormWhenTimeChange();
            //InitData();
            //this.IsReadyInitData = true;
        }





    }
}