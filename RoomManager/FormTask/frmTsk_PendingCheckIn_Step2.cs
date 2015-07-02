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
using BussinessLogic;
using DataAccess;

namespace RoomManager
{
    public partial class frmTsk_PendingCheckIn_Step2 : DevExpress.XtraEditors.XtraForm
    {
        private frmTsk_PendingCheckIn_Step1 afrmTsk_PendingCheckIn_Step1 = null;
        private int IDBookingRoom;
        private int IDBookingR;
        private string CodeRoom;
        private DateTime CheckOutPlan;
        private int Status;
        public frmTsk_PendingCheckIn_Step2(frmTsk_PendingCheckIn_Step1 afrmTsk_PendingCheckIn_Step1, int IDBookingRoom, int IDBookingR, string CodeRoom, DateTime CheckOutPlan, int Status)
        {
            InitializeComponent();
            this.afrmTsk_PendingCheckIn_Step1 = afrmTsk_PendingCheckIn_Step1;
            this.IDBookingRoom = IDBookingRoom;
            this.IDBookingR = IDBookingR;
            this.CodeRoom = CodeRoom;
            this.CheckOutPlan = CheckOutPlan;
            this.Status = Status;
        }

        private void frmTsk_PendingCheckIn_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = aBookingRsBO.Select_ByID(IDBookingR);
                lblIDBookingR.Text = aBookingRs.ID.ToString();

                CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                CustomerGroups aCustomerGroups = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup);
                lblNameCustomerGroup.Text = aCustomerGroups.Name;

                CompaniesBO aCompaniesBO = new CompaniesBO();
                Companies aCompanies = aCompaniesBO.Select_ByID(aCustomerGroups.IDCompany);
                lblNameCompany.Text = aCompanies.Name;

                CustomersBO aCustomersBO = new CustomersBO();
                Customers aCustomers = aCustomersBO.Select_ByID(aBookingRs.IDCustomer);
                lblNameCustomer.Text = aCustomers.Name;

                RoomsBO aRoomsBO = new RoomsBO();
                Rooms aRooms = aRoomsBO.Select_ByCodeRoom(CodeRoom, 1);//1=IDLang
                lblSku.Text = aRooms.Sku;

                dtpTo.DateTime = CheckOutPlan;
                dtpFrom.DateTime = DateTime.Now;
                dtpFrom.Enabled = false;
                dtpFrom.Properties.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step2.frmTsk_PendingCheckIn_Step2_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

            try
            {
                if (dtpFrom.DateTime < dtpTo.DateTime)
                {
                    if (this.Status == 2)
                    {
                        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                        //cap nhat bookingroom
                        BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRoom);

                        //aBookingRooms.CheckInPlan = DateTime.Now;
                        //aBookingRooms.CheckInActual = DateTime.Now;

                        aBookingRooms.CheckInPlan = dtpFrom.DateTime;
                        aBookingRooms.CheckInActual = dtpFrom.DateTime;

                        aBookingRooms.CheckOutPlan = dtpTo.DateTime;
                        aBookingRooms.CheckOutActual = dtpTo.DateTime;
                        //aBookingRooms.PriceType = "G1";
                        aBookingRooms.Status = 3;// 3= Da check in

                        aBookingRoomsBO.Update(aBookingRooms);



                        if (this.afrmTsk_PendingCheckIn_Step1 != null)
                        {
                            this.afrmTsk_PendingCheckIn_Step1.LoadDataBookingRoom(this.Status);
                            if (this.afrmTsk_PendingCheckIn_Step1.afrmMain != null)
                            {
                                this.afrmTsk_PendingCheckIn_Step1.afrmMain.ReloadData();
                            }
                        }

                        MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                    }
                    else if (this.Status == 5)
                    {
                        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                        RoomsBO aRoomsBO = new RoomsBO();
                        AccountancyBO aAccountancyBO = new AccountancyBO();
                        //Check out giai doan pending
                        aAccountancyBO.CheckOut(this.IDBookingRoom, dtpFrom.DateTime);

                        //them moi mot bookingroom
                        BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRoom);
                        BookingRooms aBookingRoomsAddNew = new BookingRooms();
                        aBookingRoomsAddNew.IDBookingR = IDBookingR;
                        aBookingRoomsAddNew.CodeRoom = CodeRoom;

                        aBookingRoomsAddNew.PercentTax = aBookingRooms.PercentTax;
                        aBookingRoomsAddNew.CostRef_Rooms = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom, 1).CostRef;
                        aBookingRoomsAddNew.Note = aBookingRooms.Note;

                        aBookingRoomsAddNew.CheckInPlan = dtpFrom.DateTime;
                        aBookingRoomsAddNew.CheckInActual = dtpFrom.DateTime;
                        aBookingRoomsAddNew.CheckOutPlan = dtpTo.DateTime;
                        aBookingRoomsAddNew.CheckOutActual = dtpTo.DateTime;
                        aBookingRoomsAddNew.PriceType = aBookingRooms.PriceType;
                        aBookingRoomsAddNew.Type = 1;

                        aBookingRoomsAddNew.BookingStatus = aBookingRooms.BookingStatus;

                        aBookingRoomsAddNew.Status = 3;// 3 = Da CheckIn

                        aBookingRoomsAddNew.StartTime = aBookingRooms.StartTime;
                        aBookingRoomsAddNew.EndTime = aBookingRooms.EndTime;
                        aBookingRoomsAddNew.IsAllDayEvent = aBookingRooms.IsAllDayEvent;
                        aBookingRoomsAddNew.Color = aBookingRooms.Color;
                        aBookingRoomsAddNew.IsRecurring = aBookingRooms.IsRecurring;
                        aBookingRoomsAddNew.IsEditable = aBookingRooms.IsEditable;
                        aBookingRoomsAddNew.AdditionalColumn1 = aBookingRooms.AdditionalColumn1;
                        int ID = aBookingRoomsBO.Insert(aBookingRoomsAddNew);

                        if (ID > 0)
                        {
                            BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                            List<BookingRoomsMembers> aListBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom(this.IDBookingRoom);
                            BookingRoomsMembers aBookingRoomsMembers;
                            foreach (BookingRoomsMembers item1 in aListBookingRoomsMembers)
                            {
                                aBookingRoomsMembers = new BookingRoomsMembers();
                                aBookingRoomsMembers.IDBookingRoom = ID;
                                aBookingRoomsMembers.IDCustomer = item1.IDCustomer;
                                aBookingRoomsMembers.PurposeComeVietnam = item1.PurposeComeVietnam;
                                aBookingRoomsMembers.DateEnterCountry = item1.DateEnterCountry;
                                aBookingRoomsMembers.EnterGate = item1.EnterGate;
                                aBookingRoomsMembers.TemporaryResidenceDate = item1.TemporaryResidenceDate;
                                aBookingRoomsMembers.LimitDateEnterCountry = item1.LimitDateEnterCountry;
                                aBookingRoomsMembers.Organization = item1.Organization;
                                aBookingRoomsMembers.LeaveDate = item1.LeaveDate;

                                aBookingRoomsMembersBO.Insert(aBookingRoomsMembers);

                            }
                        }





                        if (this.afrmTsk_PendingCheckIn_Step1 != null)
                        {
                            this.afrmTsk_PendingCheckIn_Step1.LoadDataBookingRoom(Status);
                            if (this.afrmTsk_PendingCheckIn_Step1.afrmMain != null)
                            {
                                this.afrmTsk_PendingCheckIn_Step1.afrmMain.ReloadData();
                            }
                        }

                        MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Ngày giờ không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_PendingCheckIn_Step2.btnCheckIn_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dtpFrom.Enabled = true;
            dtpFrom.Properties.ReadOnly = false;
        }
    }
}