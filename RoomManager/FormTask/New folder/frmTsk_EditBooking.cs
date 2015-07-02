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
        private Boolean IsFixTimeAction = false;
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
        private void frmTsk_EditBooking_Load(object sender, EventArgs e)
        {
            this.dtpAction.DateTime = DateTime.Now;
            InitForm();
            InitData();
            this.IsReadyInitData = true;
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

                dtpCheckIn.Text = dtpAction.DateTime.ToString();
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
            aCustomers = new CustomerInfoEN(aCustomersBO.Select_ByID(aBookingRs.IDCustomer));

            lblCustomer.Text = aCustomers.Name;
            lblTel.Text = aCustomers.Tel;

            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
            lblGroup.Text = aCustomerGroups.Name;

            CompaniesBO aCompaniesBO = new CompaniesBO();
            lblCompany.Text = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany).Name;

            // Fill All Customer

            dgvAvailableCustomers.DataSource = ConvertListCustomer((new CustomersBO()).Select_All());


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
            List<BookingRoomsMembers> aListBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom(this.aBookingRoom.ID);

            dgvSelectCustomers.DataSource = GetCustomers(aListBookingRoomsMembers);

            //this.aChangeRoomEn.InsertItemChangeRooms()
        }
        public void ReloadCustomers()
        { }

        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(viewAvailableCustomers.GetFocusedRowCellValue("ID"));
            frmUpd_Customers afrmUpd_Customers = new frmUpd_Customers(this, ID);
            afrmUpd_Customers.Show();
        }

        private void btnRemoveAvaiableCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsFixTimeAction == true)
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
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
            }
        }
        private void btnRemoveSelectCustomers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (this.IsFixTimeAction == true)
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
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsFixTimeAction == true)
            {
                AccountancyBO aAccountancyBO = new AccountancyBO();
                if (aCurrentRoomInfo.GetAllCustomers().Count <= 3)
                {
                    aCurrentRoomInfo.SetCost(aAccountancyBO.CalculateCostRoom(lueRooms.EditValue.ToString(), this.aBookingRoom.PriceType, aBookingRs.CustomerType.GetValueOrDefault(0), aCurrentRoomInfo.GetAllCustomers().Count).GetValueOrDefault(0));
                    //aCurrentRoomInfo.SetCost(null);
                    this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);
                    ProcessChangeRoom();
                }
                else
                {
                    MessageBox.Show("Phòng không được vượt quá 3 người");
                }
            }
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
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
            return ret;

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
                aItemChangeRoomEN.SetCheckInActual(dtpAction.DateTime);
                aItemChangeRoomEN.SetCheckOutPlan(dtpCheckOut.DateTime);
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
            aItemChangeRoomEN.SetCost(null);

            this.aChangeRoomEn.InsertItemChangeRooms(aItemChangeRoomEN);
            this.aCurrentRoomInfo = aItemChangeRoomEN;
        }

        private List<Rooms> GetAvaiableRoom()
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            BookingRsBO aBookingRsBO = new BookingRsBO();

            List<Rooms> aListAvaiableRooms = aReceptionTaskBO.GetListAvailableRooms(DateTime.Parse(dtpCheckIn.Text.ToString()), DateTime.Parse(dtpCheckOut.Text.ToString()), 1);
            List<Rooms> aListRoomInBookingR = aBookingRsBO.SelectListRooms_ByIDBookingR(this.aBookingRoom.IDBookingR, 1);

            return aListRoomInBookingR.Union(aListAvaiableRooms).ToList(); // Nối và loại trừ trùng lặp
        }
        private void lueRooms_EditValueChanged(object sender, EventArgs e)
        {
            if (this.IsReadyInitData == true)
            {
                // Get list customer for current room
                dgvSelectCustomers.DataSource = this.GetDataForSelectCustomerGridview(lueRooms.EditValue.ToString());

                // Luu lai thong tin cua chuyen phong cu truoc khi select phong moi
                this.aChangeRoomEn.UpdateItemChangeRooms(this.aCurrentRoomInfo);

                // Chuyen sang select phong moi bang thong tin trong aChangeRoomsEN
                this.aCurrentRoomInfo = this.aChangeRoomEn.GetItemChangeRooms(lueRooms.EditValue.ToString());

                if (this.aCurrentRoomInfo == null)
                {
                    //add them mot ItemChangeRooms moi 
                    ItemChangeRoomEN aItemChangeRoomEN = new ItemChangeRoomEN();
                    aItemChangeRoomEN.SetBookingRooms(this.aBookingRoom);

                    aItemChangeRoomEN.SetCodeRoom(lueRooms.EditValue.ToString());

                    if (aItemChangeRoomEN.GetStatusBookingRooms() < 3)
                    {
                        // Phong trang thai dat
                    }
                    else if (aItemChangeRoomEN.GetStatusBookingRooms() == 3) // Phong dang co nguoi o
                    {
                        // Thay doi thoi gian de check in
                        aItemChangeRoomEN.SetCheckInActual(dtpAction.DateTime);
                        aItemChangeRoomEN.SetCheckOutPlan(dtpCheckOut.DateTime);

                        aItemChangeRoomEN.AddCustomer(this.GetDataForSelectCustomerGridview(lueRooms.EditValue.ToString()));


                        if (aItemChangeRoomEN.GetAllCustomers().Count > 0)
                        {
                            AccountancyBO aAccountancyBO = new AccountancyBO();
                           // aItemChangeRoomEN.SetCost(aAccountancyBO.CalculateCostRoom(lueRooms.EditValue.ToString(), this.aBookingRoom.PriceType, aBookingRs.CustomerType.GetValueOrDefault(0), aItemChangeRoomEN.GetAllCustomers().Count).GetValueOrDefault(0));
                            aItemChangeRoomEN.SetCost(null);
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


            // Add vao phong

            List<CustomerInfoEN> ListSelectCustomers = (List<CustomerInfoEN>)dgvSelectCustomers.DataSource;


            ListSelectCustomers.Insert(0, aRemoveCustomer);

            dgvSelectCustomers.DataSource = null;
            dgvSelectCustomers.DataSource = ListSelectCustomers;
            dgvSelectCustomers.RefreshDataSource();

            // update to CurrentRoomInfo Packet
            this.aCurrentRoomInfo.UpdateCustomer(ListSelectCustomers);
            this.ClearControl();
        }

        private void MoveCustomerLeftToRight()
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
            this.aCurrentRoomInfo.UpdateCustomer(ListSelectCustomers);

            this.ClearControl();
        }

        private List<CustomerInfoEN> GetDataForSelectCustomerGridview(string CodeRoom)
        {
            BookingRsBO aBookingRsBO = new BookingRsBO();
            List<Rooms> aListRoom = aBookingRsBO.SelectListRooms_ByIDBookingR(this.aBookingRoom.IDBookingR, 1);

            bool IsRoomInBookingR = false;
            if (aListRoom.Where(p => p.Code == CodeRoom).ToList().Count == 1)
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
                    List<BookingRooms> aListBookingRooms = aBookingRoomsBO.Select_ByIDBookingRsAndCodeRoom(this.aBookingRoom.IDBookingR, CodeRoom);
                    CustomersBO aCustomersBO = new CustomersBO();
                    List<Customers> aList = aCustomersBO.SelectListCustomer_ByIDBookingRoom(aListBookingRooms[0].ID);
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
            // Khi chuyen phong A(RootRoom) -> B, phong A can check out và check In phong B
            // Co doi luc phong A checkout xong thi can check in tro lai (VD nhu van con nguoi trong phong A)
            // Bien nay de xac dinh xem phong A 
            bool IsRootRoomCheckInAgain = false;

            // Vi moi khi check In luon bi tinh mac dinh 1 ngay
            bool IsRootRoomChangeInDay = false;

            // Tinh 2 tham so can thiet cho qua trinh chuyen phong
            //===================================================
            ItemChangeRoomEN RootRoom = new ItemChangeRoomEN();
            RootRoom = this.aChangeRoomEn.GetRootItemChangeRoom();
            if (RootRoom.GetAllCustomers().Count > 0)
            {
                IsRootRoomCheckInAgain = true;
            }
            else
            {
                if (RootRoom.GetStatusBookingRooms() == 3)
                {
                    if (RootRoom.GetCheckInActual().Date == dtpAction.DateTime.Date)
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
                }

            }
            ClearDataBeforeProcessChangeRoom();
            ProcessChangeRoom1(IsRootRoomCheckInAgain, IsRootRoomChangeInDay);

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            // Show message box
            DialogResult result = MessageBox.Show("Chuyển phòng thành công", "Nhà khách chính phủ", buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.afrmMain.RefreshData_auc_StatusRooms(dtpAction.DateTime);
                this.Close();

            }

            //========================================================
        }

        private void ClearDataBeforeProcessChangeRoom()
        {
            ItemChangeRoomEN RootRoom = new ItemChangeRoomEN();
            RootRoom = this.aChangeRoomEn.GetRootItemChangeRoom();

            List<ItemChangeRoomEN> NormalChangeRooms = new List<ItemChangeRoomEN>();
            NormalChangeRooms = this.aChangeRoomEn.GetListItemChangeRoomNotIncludeRootRoom();
            for (int i = 0; i < NormalChangeRooms.Count; i++)
            {
                if (NormalChangeRooms[i].GetAllCustomers().Count == 0)
                {
                    this.aChangeRoomEn.RemoveItemChangeRooms(NormalChangeRooms[i].GetCodeRoom());
                }
            }
        }

        private void ProcessChangeRoom1(bool IsRootRoomCheckInAgain, bool IsRootRoomChangeInDay)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                // Checkout phong ban dau
                aReceptionTaskBO.CheckOutFirstRoom(this.aBookingRoom.ID, dtpAction.DateTime);

                ItemChangeRoomEN aRootItem = new ItemChangeRoomEN();
                // Lay phong goc ban dau
                aRootItem = this.aChangeRoomEn.GetRootItemChangeRoom();
                //============================================================

                // Neu chuyen phong nhung van giu phong cu thi  check in lai phong cu voi cac thong tin moi
                if (IsRootRoomCheckInAgain == true /*&& IsRootRoomChangeInDay == false*/)
                {
                    aRootItem = ProcessRootRoomBeforeCheckIn(aRootItem);
                    if (IsRootRoomChangeInDay == true)  // Doi phong trong ngay, vao roi doi luon nen k tinh tien (cost set = 0)
                    {
                        aRootItem.SetCost(0);
                    }
                    //Xu ly cac thong tin phong goc truoc khi checkIn lai


                    // Thuc hien checkin lai phong ban dau
                    aReceptionTaskBO.CheckInNewRoom(aRootItem);

                }
                // Neu phong goc ban dau khong con nguoi ben trong thi k can checkin lai
                else if (IsRootRoomCheckInAgain == false /*&& IsRootRoomChangeInDay == false*/)
                {
                    if (IsRootRoomChangeInDay == true)  // Doi phong trong ngay, vao roi doi luon nen k tinh tien (cost set = 0)
                    {
                        BookingRooms aBookingRooms = new BookingRooms();
                        aBookingRooms = (new BookingRoomsBO()).Select_ByID(this.aBookingRoom.ID);
                        aBookingRooms.Cost = 0;
                        (new BookingRoomsBO()).Update(aBookingRooms);
                    }
                }

                List<ItemChangeRoomEN> aListNormalRoom = new List<ItemChangeRoomEN>();
                aListNormalRoom = this.aChangeRoomEn.GetListItemChangeRoomNotIncludeRootRoom();
                for (int i = 0; i < aListNormalRoom.Count; i++)
                {
                    ItemChangeRoomEN aItem = ProcessNormalRoomBeforeCheckIn(aRootItem.GetTypeBookingRoom(), aListNormalRoom[i]);
                    aReceptionTaskBO.CheckInNewRoom(aItem);
                }

                //============================================================
                List<ItemChangeRoomEN> aList = this.aChangeRoomEn.GetAllItemChangeRoom();
                List<CustomerInfoEN> aListCustomer = new List<CustomerInfoEN>();
                for (int i = 0; i < aList.Count; i++)
                {
                    aListCustomer.AddRange(aList[i].GetAllCustomers());
                }

                // Lay danh sach khach dang co o trong CustomerGroups_Customers
                // o trong phong hay o trong bookingR chua chac la o trong CustomerGroups_Customers
                // vi danh sach nguoi trong phong hay nguoi trong bookingR thuoc bookingroommember
                CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                List<int> aListOldIDCustomers = aCustomerGroups_CustomersBO.Select_ByIDCustomerGroup(this.aBookingRs.IDCustomerGroup).Select(p => p.IDCustomer).ToList();

                List<int> aListCurrentIDCustomers = aListCustomer.Select(p => p.ID).ToList();

                List<int> aListIDNewCustomer = aListCurrentIDCustomers.Where(p => !aListOldIDCustomers.Contains(p)).ToList();

                // add nhung khach moi vao group customer
                for (int i = 0; i < aListIDNewCustomer.Count; i++)
                {
                    aCustomerGroups_CustomersBO.InsertCustomerIntoCustomerGroup_ByIDBookingRs(aListIDNewCustomer[i], this.aBookingRs.ID);
                }
                //============================================================
            }
            catch (Exception e4)
            {
                MessageBox.Show("Lỗi khi chuyển phòng");
            }
        }

        private void viewSelectCustomers_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (this.IsFixTimeAction == true)
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
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
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
            if (this.IsFixTimeAction == true)
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
                    { this.aCurrentCustomerClick.DateEnterCountry = (DateTime)dtpDateEnterCountry.EditValue; }
                    else { this.aCurrentCustomerClick.TemporaryResidenceDate = DateTime.Parse("01/01/1900"); }

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
                }
            }
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
            }
        }

        private ItemChangeRoomEN ProcessRootRoomBeforeCheckIn(ItemChangeRoomEN aRootRoom)
        {

            // Checkin lai root room thi chi xet CheckIn som
            if (aRootRoom.GetTypeBookingRoom() == 0 || aRootRoom.GetTypeBookingRoom() == 1)
            {
                aRootRoom.SetTypeBookingRoom(0); // Khong set checkIn som
            }
            else
            {
                aRootRoom.SetTypeBookingRoom(1);
            }
            return aRootRoom;
        }

        private ItemChangeRoomEN ProcessNormalRoomBeforeCheckIn(int TypeOfRootRoom, ItemChangeRoomEN aItemRoom)
        {

            // Checkin lai root room thi chi xet CheckIn som
            if (TypeOfRootRoom == 0 || TypeOfRootRoom == 2)
            {
                aItemRoom.SetTypeBookingRoom(0); // Khong set checkIn som
            }
            else
            {
                aItemRoom.SetTypeBookingRoom(1);
            }
            return aItemRoom;
        }

        private void dgvSelectCustomers_Click(object sender, EventArgs e)
        {

        }

        private void btnFixTimeAction_Click(object sender, EventArgs e)
        {
            this.IsFixTimeAction = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.IsFixTimeAction == true)
            {
                frmIns_Customers afrmIns_Customers = new frmIns_Customers(this);
                afrmIns_Customers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần xác nhận thời gian thực hiện hành động này");
            }
        }

        private void dtpAction_EditValueChanged(object sender, EventArgs e)
        {
            dtpCheckIn.DateTime = dtpAction.DateTime;
            InitForm();
            InitData();
            this.IsReadyInitData = true;
        }

        private void dtpCheckOut_EditValueChanged(object sender, EventArgs e)
        {

        }



    }
}