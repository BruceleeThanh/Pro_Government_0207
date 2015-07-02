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
    public partial class frmTsk_ChangeRoom : DevExpress.XtraEditors.XtraForm
    {
        private frmMain afrmMain = null;
        string SkuCurrentRoom = string.Empty;
        int IDBookingRs = 0;
        int IDBookingRooms = 0;
        int IDCustomerGroup = 0;
        string NewCodeRoom;
        decimal NewCostRoom = 0;

        private List<RoomMemberEN> aListAvaiableRooms = new List<RoomMemberEN>();

        public frmTsk_ChangeRoom()
        {
            InitializeComponent();
        }
        public frmTsk_ChangeRoom(frmMain afrmMain, int IDBookingRs, int IDBookingRooms)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
            this.IDBookingRs = IDBookingRs;
            this.IDBookingRooms = IDBookingRooms;
        }

        private void frmTsk_ChangeRoom_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                CustomersBO aCustomersBO = new CustomersBO();
                BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                BookingRooms aBookingRooms = new BookingRooms();
                RoomsBO aRoomsBO = new RoomsBO();

                aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRooms);
                if (aBookingRooms != null)
                {
                    lblCheckIn.Text = aBookingRooms.CheckInActual.ToString("dd/MM/yyyy HH:mm");
                    lblCheckOut.Text = aBookingRooms.CheckOutPlan.ToString("dd/MM/yyyy HH:mm");
                    lblRoomSku.Text = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom,1).Sku;
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
                dgvAvaiableRooms.DataSource = this.LoadListAvailableRooms(aBookingRooms.CheckInActual, aBookingRooms.CheckOutPlan);
                dgvAvaiableRooms.RefreshDataSource();



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

        private void grvAvaiableRooms_RowClick(object sender, RowClickEventArgs e)
        {
            this.NewCodeRoom = grvAvaiableRooms.GetFocusedRowCellValue("RoomCode").ToString();
            this.NewCostRoom = Convert.ToDecimal(grvAvaiableRooms.GetFocusedRowCellValue("RoomCostRef"));
        }
        private bool ValidateData()
        {
            if (this.NewCostRoom == null || this.NewCostRoom == 0)
            {
                MessageBox.Show("Vui lòng click chọn phòng chuyển sang ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
                    BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRooms);
                    aBookingRooms.CodeRoom = this.NewCodeRoom;
                    aBookingRooms.Cost = this.NewCostRoom;
                    aBookingRooms.CostRef_Rooms = this.NewCostRoom;
                    aBookingRoomsBO.Update(aBookingRooms);

                    MessageBox.Show("Chuyển phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (afrmMain != null)
                    {
                        this.afrmMain.ReloadData();
                    }
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ChangeRoom.btnUpdate_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}