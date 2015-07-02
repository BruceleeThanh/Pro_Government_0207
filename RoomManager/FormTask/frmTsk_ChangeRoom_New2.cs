using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;
using Entity;
namespace RoomManager
{
    public partial class frmTsk_ChangeRoom_New2 : Form
    {
        public frmTsk_ChangeRoom_New2()
        {
            InitializeComponent();

        }
        private int IDBookingRoom_Case1;
        private List<Customers> ListCustomerInRoomBeforeChange_Case1;
        private Customers CustomerRemove_Case1;
        private ItemChangeRoomEN aItemChangeRoomEN_Case1 = new ItemChangeRoomEN();
        private void frmTsk_ChangeRoom_New2_Load(object sender, EventArgs e)
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            //-------------------------------
            //Case 1
            //-------------------------------
            this.dtpFrom_Case1.DateTime = DateTime.Now;
            this.lueListAvaiableRooms_Case1.Properties.DataSource = aReceptionTaskBO.GetListRoomInUse().Where(p=>p.BookingRooms_Status == 3);
            this.lueListAvaiableRooms_Case1.Properties.ValueMember = "BookingRooms_ID";
            this.lueListAvaiableRooms_Case1.Properties.DisplayMember = "Rooms_Sku";

        }

        private void lueListAvaiableRooms_Case1_EditValueChanged(object sender, EventArgs e)
        {
          
            CustomersBO aCustomersBO = new CustomersBO();
            List<Customers> aList = aCustomersBO.SelectListCustomerInRoom(int.Parse(this.lueListAvaiableRooms_Case1.EditValue.ToString()));
            this.lueListCustomerInRoom_Case1.Properties.DataSource = aList;
            this.lueListCustomerInRoom_Case1.Properties.ValueMember = "ID";
            this.lueListCustomerInRoom_Case1.Properties.DisplayMember = "Name";
            this.ListCustomerInRoomBeforeChange_Case1 = aList;
            this.IDBookingRoom_Case1 = int.Parse(this.lueListAvaiableRooms_Case1.EditValue.ToString());


        }

        private void lueListCustomerInRoom_Case1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ListCustomerInRoomBeforeChange_Case1.Count > 0)
            {
                this.CustomerRemove_Case1 = this.ListCustomerInRoomBeforeChange_Case1.Where(p => p.ID == int.Parse(lueListCustomerInRoom_Case1.EditValue.ToString())).ToList()[0];
               
                
            }
            else
            {
                MessageBox.Show("Phòng không có dữ liệu người ở");
            }
        }

        private void btnChangeRoom_Case1_Click(object sender, EventArgs e)
        {

            ChangeRoom_Case1();
        }
        private bool ChangeRoom_Case1()
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            BookingRooms aBookingRooms = new BookingRooms();
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            
           // Neu phong chi co 1 nguoi, va nguoi do chuyen di mat thi coi nhu checkout luon 
            if (this.ListCustomerInRoomBeforeChange_Case1.Count == 1)
            {
                aReceptionTaskBO.CheckOut(this.IDBookingRoom_Case1, dtpFrom_Case1.DateTime);
            }
            else if (this.ListCustomerInRoomBeforeChange_Case1.Count > 1)
            {

                aBookingRooms = aBookingRoomsBO.Select_ByID(this.IDBookingRoom_Case1);
                
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
              
                List<BookingRoomsMembers> aListCustomer = aBookingRoomsMembersBO.Select_ByIDBookingRoom(this.IDBookingRoom_Case1);
                BookingRoomsMembers aBookingRoomsMembers = aListCustomer.Where(p => p.IDCustomer == int.Parse(lueListCustomerInRoom_Case1.EditValue.ToString())).ToList()[0];
                aListCustomer.Remove(aBookingRoomsMembers);

                aReceptionTaskBO.CheckOutFirstRoom(this.IDBookingRoom_Case1, dtpFrom_Case1.DateTime);

                aBookingRooms.CheckInActual = dtpFrom_Case1.DateTime;
                aBookingRooms.CheckInPlan = dtpFrom_Case1.DateTime;
                aBookingRooms.AddTimeEnd = null;
                aBookingRooms.AddTimeStart = null;
                aBookingRooms.TimeInUse = null;

                //BookingRooms Item = new BookingRooms();
                //Item.AcceptDate = aBookingRooms.AcceptDate;
                //Item.AdditionalColumn1 = aBookingRooms.AdditionalColumn1;
                //Item.AddTimeEnd = aBookingRooms.AddTimeEnd;

                //Item.AddTimeStart = aBookingRooms.AddTimeStart;
                //Item.BookingStatus = aBookingRooms.BookingStatus;
                //Item.CheckInActual = aBookingRooms.CheckInActual;

                //Item.CheckInPlan = aBookingRooms.CheckInPlan;
                //Item.CheckOutActual = aBookingRooms.CheckOutActual;
                //Item.CheckOutPlan = aBookingRooms.CheckOutPlan;

                //Item.CodeRoom = aBookingRooms.CodeRoom;
                //Item.Color = aBookingRooms.Color;
                //Item.Cost = aBookingRooms.Cost;

                //Item.CostPendingRoom = aBookingRooms.CostPendingRoom;
                //Item.CostRef_Rooms = aBookingRooms.CostRef_Rooms;
                //Item.Disable = aBookingRooms.Disable;

                //Item.EndTime = aBookingRooms.EndTime;

                //Item.IDBookingR = aBookingRooms.IDBookingR;

                //Item.IndexSubPayment = aBookingRooms.IndexSubPayment;
                //Item.InvoiceDate = aBookingRooms.InvoiceDate;
                //Item.InvoiceNumber = aBookingRooms.InvoiceNumber;

                //Item.IsAllDayEvent = aBookingRooms.IsAllDayEvent;
                //Item.IsEditable = aBookingRooms.IsEditable;
                //Item.IsRecurring = aBookingRooms.IsRecurring;

                //Item.Note = aBookingRooms.Note;
                //Item.PercentTax = aBookingRooms.PercentTax;
                //Item.PriceType = aBookingRooms.PriceType;

                //Item.StartTime = aBookingRooms.StartTime;
                //Item.Status = aBookingRooms.Status;
                //Item.TimeInUse = aBookingRooms.TimeInUse;
                //Item.Type = aBookingRooms.Type;


                int NewIDBookingRoom = aBookingRoomsBO.Insert(aBookingRooms);
                for (int i = 0; i < aListCustomer.Count; i++)
                {
                    aListCustomer[i].IDBookingRoom = NewIDBookingRoom;
                    aBookingRoomsMembersBO.Insert(aListCustomer[i]); 
                }
                
            }
            return true;
        }
        
    }
}
