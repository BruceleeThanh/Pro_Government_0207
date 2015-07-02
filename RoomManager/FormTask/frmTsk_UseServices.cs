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

namespace RoomManager
{
    public partial class frmTsk_UseServices : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
        List<RoomServiceInfoEN> alistRoomServiceInfo = new List<RoomServiceInfoEN>();
        List<Services> aListService = new List<Services>();
        List<RoomExtStatusEN> aListRoomExtStatus = new List<RoomExtStatusEN>();
        NewPaymentEN aNewPayment = new NewPaymentEN();
        List<int> aListIDBookingRoom_Servicers = new List<int>();
        List<BookingRoomsEN> aListBookingRoom = new List<BookingRoomsEN>();

        List<BookingRoom_ServiceEN> aListSelected = new List<BookingRoom_ServiceEN>();
        List<BookingRooms_Services> aListRemove = new List<BookingRooms_Services>();

        private bool IsDataChange = false;

        private frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = null;
        
        string CodeCurrentRoom = string.Empty;
        int IDBookingRs = 0;
        int IDBookingRoom = 0;

        // Biến thông báo ID tạm thời của Service ở phiên làm việc hiện tại
        // Bắt đầu
        int IDCurrent = 0;
        // Kết thúc


        public frmTsk_UseServices()
        {
            InitializeComponent();
        
        }

        //NgocBM
        public frmTsk_UseServices(string CodeRoom, int IDBookingRs, int IDBookingRoom)
        {
            InitializeComponent();
            this.CodeCurrentRoom = CodeRoom;
            this.IDBookingRs = IDBookingRs;
            this.IDBookingRoom = IDBookingRoom;
        }

 
        // Truyền thêm đối số NewPayment để khi thêm dịch vụ từ form Payment sẽ load lại số dịch vụ đã thêm, các thông số còn lại vẫn để nguyên vì chưa chỉnh sửa hết được)
        public frmTsk_UseServices(frmTsk_Payment_Step2 afrmTsk_Payment_Step2, string CodeRoom, int IDBookingRs, int IDBookingRoom, NewPaymentEN aNewPayment)
        {
            InitializeComponent();
            this.afrmTsk_Payment_Step2 = afrmTsk_Payment_Step2;
            this.CodeCurrentRoom = CodeRoom;
            this.IDBookingRs = IDBookingRs;
            this.IDBookingRoom = IDBookingRoom;
            this.aNewPayment = aNewPayment;
        }

        //NgocBM
        private void frmTsk_UseServices_Load(object sender, EventArgs e)
        {
            try
            {
                    dtpDate.DateTime = DateTime.Now;
                    this.Reload();
                    this.LoadServicesInRoom();
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UseServices.frmTsk_UseServices_Load\n" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //hàm tính tiền 
        decimal SumCostService(int RowIndex)
        {
            decimal Cost = Convert.ToDecimal(grvServices.GetListSourceRowCellValue(RowIndex, "grcCost"));
            decimal Quantity = Convert.ToDecimal(grvServices.GetListSourceRowCellValue(RowIndex, "grcQuantity"));
            decimal VAT = Convert.ToDecimal(grvServices.GetListSourceRowCellValue(RowIndex, "grcPercentTax"));
            
            return ((Cost * Quantity) + (Cost * Quantity * (VAT / 100)));
        }

        // Lỗi số lượng nhập được số âm

        // Tạo thêm MessageBox
        // Bắt đầu

        private void grvServiceInRoom_CellValueChanged (object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            if (Convert.ToDouble(e.Value) < 1) {
                MessageBox.Show("Đơn vị số lượng nhỏ nhất là 1.\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                this.IsDataChange = true;
                int ID = Convert.ToInt32(grvServiceInRoom.GetFocusedRowCellValue("ID"));
                if (e.Column.Name == "grcQuantity") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Quantity = Convert.ToDouble(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcDate") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Quantity = Convert.ToDouble(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcCost") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].Cost = Convert.ToDecimal(e.Value);
                        }
                    }
                }
                if (e.Column.Name == "grcPercentTax") {
                    for (int i = 0; i < aListSelected.Count; i++) {
                        if (aListSelected[i].ID == ID) {
                            aListSelected[i].PercentTax = Convert.ToDouble(e.Value);
                        }
                    }
                }
                // đã cmt từ trước - bắt đầu
                //BookingRoom_ServiceEN aTemp = aListSelected.Where(a => a.IDBookingRoom == IDBookingRoom).Where(b => b.IDService == IDService).Where(c => c.Date == Date).ToList()[0];
                //aListSelected.Where(a => a.IDBookingRoom == IDBookingRoom).Where(b => b.IDService == IDService).Where(c => c.Date == Date).ToList()[0].Sum = Convert.ToDecimal(aTemp.Quantity) * aTemp.Cost * Convert.ToDecimal((aTemp.PercentTax / 100 + 1));
                // đã cmt từ trước - kết thúc
                dgvServiceInRoom.DataSource = aListSelected;
                dgvServiceInRoom.RefreshDataSource();
            }
        }

        // Kết thúc
       
        #region New
        public void Reload()
        {
            BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            RoomsBO aRoomsBO = new RoomsBO();

            
            BookingRoomsEN aBookingRoomsEN = new BookingRoomsEN();
            BookingRooms aBookingRooms = aBookingRoomsBO.Select_ByID(IDBookingRoom);
            aBookingRoomsEN.SetValue(aBookingRooms);
            aBookingRoomsEN.ID = aBookingRooms.ID;
            aBookingRoomsEN.RoomSku = aRoomsBO.Select_ByCodeRoom(aBookingRooms.CodeRoom, 1).Sku;
            this.lbCurrentRoom.Text = "Phòng số : " + aBookingRoomsEN.RoomSku;

            aListBookingRoom.Add(aBookingRoomsEN);
            dgvRooms.DataSource = aListBookingRoom;
            dgvRooms.RefreshDataSource();

            ServicesBO aServicesBO = new ServicesBO();
            aListService = aServicesBO.Select_ByType(2);
            dgvServices.DataSource = aListService;
            dgvServices.RefreshDataSource();


        }
        private void LoadServicesInRoom()
        {
            try
            {
                ServicesBO aServicesBO = new ServicesBO();
                BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                List<BookingRooms_Services> aListTemp = aBookingRooms_ServicesBO.Select_ByIDBookingRooms(this.IDBookingRoom);
                BookingRoom_ServiceEN aBookingRoom_ServiceEN;

                for (int i = 0; i < aListTemp.Count; i++)
                {
                    aBookingRoom_ServiceEN = new BookingRoom_ServiceEN();
                    aBookingRoom_ServiceEN.ID = aListTemp[i].ID;
                    aBookingRoom_ServiceEN.Info = aListTemp[i].Info;
                    aBookingRoom_ServiceEN.Type = aListTemp[i].Type;
                    aBookingRoom_ServiceEN.Status = aListTemp[i].Status;
                    aBookingRoom_ServiceEN.Disable = aListTemp[i].Disable;
                    aBookingRoom_ServiceEN.IDBookingRoom = aListTemp[i].IDBookingRoom;
                    aBookingRoom_ServiceEN.IDService = aListTemp[i].IDService;
                    aBookingRoom_ServiceEN.Service_Name = aServicesBO.Select_ByID(aListTemp[i].IDService).Name;
                    aBookingRoom_ServiceEN.Service_Unit = aServicesBO.Select_ByID(aListTemp[i].IDService).Unit;
                    aBookingRoom_ServiceEN.Cost = aListTemp[i].Cost == null ? aListTemp[i].CostRef_Services : aListTemp[i].Cost;
                    aBookingRoom_ServiceEN.CostRef_Services = aListTemp[i].CostRef_Services;
                    aBookingRoom_ServiceEN.Date = aListTemp[i].Date;
                    aBookingRoom_ServiceEN.PercentTax = aListTemp[i].PercentTax;
                    aBookingRoom_ServiceEN.Quantity = aListTemp[i].Quantity;
                   
                    aListSelected.Add(aBookingRoom_ServiceEN);
                }
                dgvServiceInRoom.DataSource = aListSelected;
                dgvServiceInRoom.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_BookingRooms_Services.grvRooms_RowClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddService_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.IsDataChange = true;
            if (String.IsNullOrEmpty(this.CodeCurrentRoom) == true)
            {
                MessageBox.Show("Vui lòng chọn phòng muốn sử dụng dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BookingRoom_ServiceEN aBookingRoom_ServiceEN = new BookingRoom_ServiceEN();
                // Tạo IDCurrent cho những Room Service được thêm ở thời điểm hiện tại - lỗi số lượng dịch vụ thêm mới bị đồng bộ
                // Bắt đầu
                aBookingRoom_ServiceEN.ID = --IDCurrent;
                // Kết thúc

                int IDService = int.Parse(grvServices.GetFocusedRowCellValue("ID").ToString());
                aBookingRoom_ServiceEN.IDService = IDService;
                aBookingRoom_ServiceEN.IDBookingRoom = this.IDBookingRoom;
                aBookingRoom_ServiceEN.Service_Name = grvServices.GetFocusedRowCellValue("Name").ToString();
                aBookingRoom_ServiceEN.Cost = Convert.ToDecimal(grvServices.GetFocusedRowCellValue("CostRef"));
                aBookingRoom_ServiceEN.CostRef_Services = Convert.ToDecimal(grvServices.GetFocusedRowCellValue("CostRef"));
                aBookingRoom_ServiceEN.Service_Unit = grvServices.GetFocusedRowCellValue("Unit").ToString();
                aBookingRoom_ServiceEN.Date = dtpDate.DateTime;
                aBookingRoom_ServiceEN.PercentTax = 10;
                aBookingRoom_ServiceEN.Quantity = 1;
               

                this.aListSelected.Insert(0, aBookingRoom_ServiceEN);
                dgvServiceInRoom.DataSource = aListSelected;
                dgvServiceInRoom.RefreshDataSource();
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                this.IsDataChange = true;
                int IDBookingRoomService = Convert.ToInt32(grvServiceInRoom.GetFocusedRowCellValue("ID"));
                List<BookingRoom_ServiceEN> aListTemp = aListSelected.Where(a => a.ID == IDBookingRoomService).ToList();
                if (aListTemp.Count > 0)
                {
                    aListSelected.Remove(aListTemp[0]);
                    dgvServiceInRoom.DataSource = aListSelected;
                    dgvServiceInRoom.RefreshDataSource();
                }
                BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
                BookingRooms_Services aTemp = aBookingRooms_ServicesBO.Select_ByID(IDBookingRoomService);
                if (aTemp != null)
                {                   
                    this.aListRemove.Add(aTemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UseServices.btnDelete_ButtonClick\n" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsDataChange = false;
            Save();
        }
        private void Save()
        {
            BookingRooms_ServicesBO aBookingRooms_ServicesBO = new BookingRooms_ServicesBO();
            BookingRooms_Services aBookingRooms_Services;
            for (int i = 0; i < aListSelected.Count; i++)
            {
                aBookingRooms_Services = aBookingRooms_ServicesBO.Select_ByID(aListSelected[i].ID);
                if (aBookingRooms_Services != null)
                {
                    aBookingRooms_Services.Cost = aListSelected[i].Cost;
                    aBookingRooms_Services.Quantity = aListSelected[i].Quantity;
                    aBookingRooms_Services.PercentTax = aListSelected[i].PercentTax;
                    aBookingRooms_Services.Date = aListSelected[i].Date;


                    aBookingRooms_ServicesBO.Update(aBookingRooms_Services);
                }
                else
                {
                    aBookingRooms_Services = new BookingRooms_Services();
                    aBookingRooms_Services.Info = "";
                    aBookingRooms_Services.Type = 1;
                    aBookingRooms_Services.Status = 1;
                    aBookingRooms_Services.Disable = false;
                    aBookingRooms_Services.IDBookingRoom = this.IDBookingRoom;
                    aBookingRooms_Services.IDService = aListSelected[i].IDService;
                    aBookingRooms_Services.Cost = aListSelected[i].Cost;
                    aBookingRooms_Services.Date = dtpDate.DateTime;
                    aBookingRooms_Services.CostRef_Services = aListSelected[i].CostRef_Services;
                    aBookingRooms_Services.PercentTax = 10;// de mac dinh
                    aBookingRooms_Services.Quantity = aListSelected[i].Quantity;
                    aBookingRooms_ServicesBO.Insert(aBookingRooms_Services);
                }
            }
            foreach (BookingRooms_Services items in this.aListRemove)
            {
                aBookingRooms_ServicesBO.Delete(items.ID);
            }

            if (this.afrmTsk_Payment_Step2 != null)
            {
                this.afrmTsk_Payment_Step2.Reload();
            }

            MessageBox.Show("Thực hiện thành công!", "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }


        #endregion

        private void LoadDataServiceInUseForEachRoom(string CodeRoom)
        {
            try
            {
                List<RoomServiceInfoEN> aList = this.alistRoomServiceInfo.Where(p => p.CodeRoom == CodeRoom).ToList();
                this.dgvServiceInRoom.DataSource = aList;
                this.dgvServiceInRoom.RefreshDataSource();
                if (this.aListRoomExtStatus.Where(p => p.Code == CodeRoom).ToList().Count > 0)
                {
                    this.lbCurrentRoom.Text = "Phòng số : " + this.aListRoomExtStatus.Where(p => p.Code == CodeRoom).ToList()[0].Sku;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UseServices.LoadDataServiceInUseForEachRoom\n" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.IsDataChange = true;
            frmIns_Services afrmIns_Services = new frmIns_Services(this);
            afrmIns_Services.ShowDialog();
        }

        private void frmTsk_UseServices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsDataChange == true)
            {

                DialogResult result1 = MessageBox.Show("Bạn có muốn lưu lại thông tin không ?", "Save ?", MessageBoxButtons.YesNo);
                if (result1 == System.Windows.Forms.DialogResult.Yes)
                {
                    this.IsDataChange = false;
                    this.Save();
                }
            }
        }

        private void grvRoom_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                this.CodeCurrentRoom = grvRooms.GetRowCellValue(e.RowHandle, "CodeRoom").ToString();
                this.IDBookingRoom = this.aListBookingRoom.Where(p => p.CodeRoom == CodeCurrentRoom).Select(p => p.ID).ToList()[0];
                this.IDBookingRs = this.aListBookingRoom.Where(p => p.CodeRoom == CodeCurrentRoom).Select(p => p.IDBookingR).ToList()[0];
                this.lbCurrentRoom.Text = "Phòng số : " + this.aListBookingRoom.Where(p => p.CodeRoom == CodeCurrentRoom).ToList()[0].RoomSku;
                LoadServicesInRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_UseServices.grvRoom_RowClick\n" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




      
       
    }

}