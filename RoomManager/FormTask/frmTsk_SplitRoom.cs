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
    public partial class frmTsk_SplitRoom : DevExpress.XtraEditors.XtraForm
    {
        private frmMain afrmMain = null;
        string SkuCurrentRoom = string.Empty;
        int IDBookingRs = 0;
        int IDBookingRooms = 0;
        int IDCustomerGroup = 0;
        string NewCodeRoom;
        int NewCostRoom = 0;

        private List<RoomMemberEN> aListAvaiableRooms = new List<RoomMemberEN>();
        private List<Customers> aListCustomersInRoom = new List<Customers>();
        private List<Customers> aListCustomersSplited = new List<Customers>();


        public frmTsk_SplitRoom()
        {
            InitializeComponent();
        }
        public frmTsk_SplitRoom(frmMain afrmMain, int IDBookingRs, int IDBookingRooms)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.IDBookingRs = IDBookingRs;
            this.IDBookingRooms = IDBookingRooms;
        }

        private void frmTsk_SplitRoom_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = new BookingRooms();
                RoomsBO aRoomsBO = new RoomsBO();

                // Load các thông tin chung về phòng
                aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRooms);
                if (aBookingRooms != null)
                {
                    lblCheckIn.Text = aBookingRooms.CheckInActual.ToString("dd/MM/yyyy HH:mm");
                    lblCheckOut.Text = aBookingRooms.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
                    lblRoomSku.Text = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom, 1).Sku;
                }
                BookingRsBO aBookingRsBO = new BookingRsBO();
                BookingRs aBookingRs = new BookingRs();
                aBookingRs = aBookingRsBO.Select_ByID(this.IDBookingRs);
                if (aBookingRs != null)
                {
                    lblCustomerType.Text = CORE.CONSTANTS.SelectedCustomerType(Convert.ToInt32(aBookingRs.CustomerType)).Name;

                    CompaniesBO aCompaniesBO = new CompaniesBO();
                    lblCompany.Text = aCompaniesBO.Select_ByIDBookingRoom(this.IDBookingRooms).Name;

                    lblCustomer.Text = aCustomersBO.Select_ByID(aBookingRs.IDCustomer).Name;

                    CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
                    lblGroup.Text = aCustomerGroupsBO.Select_ByID(aBookingRs.IDCustomerGroup).Name;

                    lblTel.Text = aCustomersBO.Select_ByID(aBookingRs.IDCustomer).Tel;

                    this.IDCustomerGroup = aBookingRs.IDCustomerGroup;
                }
                //Load danh sách phòng còn trống
                lueRooms.Properties.DataSource = this.LoadListAvailableRooms(aBookingRooms.CheckInActual, aBookingRooms.CheckOutPlan);
                lueRooms.Properties.ValueMember = "RoomCode";
                lueRooms.EditValue = this.IDBookingRooms;
                //Load danh sách khách trong phòng
                this.aListCustomersInRoom = aCustomersBO.SelectListCustomer_ByIDBookingRoom(this.IDBookingRooms);
                dgvAvailableCustomers.DataSource = this.aListCustomersInRoom;
                dgvAvailableCustomers.RefreshDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_EditBooking.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<RoomMemberEN> LoadListAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

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
                return this.aListAvaiableRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CheckIn.LoadListAvailableRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void lueRooms_EditValueChanged(object sender, EventArgs e)
        {
            this.NewCodeRoom = lueRooms.EditValue.ToString();


        }
        
    }
}