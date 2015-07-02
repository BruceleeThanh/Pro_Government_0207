using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using Entity;
using BussinessLogic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
namespace RoomManager
{
    public partial class frm_UnPay : DevExpress.XtraEditors.XtraForm
    {
        private int customerType = 0;
       // decimal? costRoom = 0;
       // private NewPaymentEN aNewPaymentEN = new NewPaymentEN();
        private BookingRoomsBO aBookingRoomBO = new BookingRoomsBO();
        List<PaymentExt_GetAllDataEN> aListPaymentExt_GetAllDataEN = new List<PaymentExt_GetAllDataEN>();
       
        public frm_UnPay(int customerType)
        {
            InitializeComponent();
            this.customerType = customerType;
        }

        private void frm_UnPay_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public void LoadData() 
        {
            try
            {


                //-----------------------------------------------------
                lueIDCompanies.Properties.DataSource = this.LoadListCompaniesByType(this.customerType);
                lueIDCompanies.Properties.ValueMember = "ID";
                lueIDCompanies.Properties.DisplayMember = "Name";  
                //-----------------------------------------------------
                
                PaymentBO aPaymentBO = new PaymentBO();
                List<sp_PaymentExt_GetAllData_Result> aListTemp = aPaymentBO.Select_ServicesStatus_ObjectStatus_BillRPaymentStatus().ToList();
       
                PaymentExt_GetAllDataEN aPaymentExt_GetAllDataEN;    
                foreach (sp_PaymentExt_GetAllData_Result item in aListTemp) 
                {
                    
                    BookingRooms aBookingRoom = aBookingRoomBO.Select_ByIDBookingR(item.BookingRs_ID);
                   
                    decimal? cost =  aBookingRoom.Cost;
                    if (cost == null) 
                    {
                        cost = 0;
                    }
                    double? addTimeStart = aBookingRoom.AddTimeStart;
                    if (addTimeStart == null) 
                    {
                        addTimeStart = 0;
                    }
                    double? addTimeEnd = aBookingRoom.AddTimeEnd;
                    if (addTimeEnd == null) 
                    {
                        addTimeEnd = 0;
                    }

                    decimal? timeUser = aBookingRoom.TimeInUse;
                    if (timeUser == null) 
                    {
                        timeUser = 0;
                    }
                    double? tax = aBookingRoom.PercentTax;
                    if (tax == null) 
                    {
                        tax = 0;
                    }
                    decimal? sum = this.CalculatorMoneyRoom(cost, addTimeStart, addTimeEnd, timeUser);
                  
                    aPaymentExt_GetAllDataEN = new PaymentExt_GetAllDataEN();     
                    aPaymentExt_GetAllDataEN.SetValue(item);
                    
                    if (item.Service_PaymentStatus == null)
                    {
                        aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "";
                    }
                    else if (item.Service_PaymentStatus == 8)
                    {
                        aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "Đã thanh toán";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "Chưa thanh toán";
                    }
                    //------------------------------------------------------------------------------------
                    if (item.BillR_PaymentStatus == 8)
                    {
                        aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Đã thanh toán";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Chưa thanh toán";
                    }
                    //------------------------------------------------------------------------------------
                    if (item.Object_PaymentStatus == 8)
                    {
                        aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Đã thanh toán";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Chưa thanh toán";

                    }
                  
                    //------------------------------------------------------------------------------------
                    aPaymentExt_GetAllDataEN.DisplayMoneySumRoom = sum;

                    // --------------------------------------------------------------------------------------------------
                 
                     //  BookingRooms aBookingRoomPending = aBookingRoomBO.SelectByIDBookingR_ByCostPendingRoom(31,20);
                   if (aBookingRoom.CostPendingRoom != null) 
                   {
                       BookingRooms aBookingRoomPending = aBookingRoomBO.SelectByIDBookingR_ByCostPendingRoom(item.BookingRs_ID, aBookingRoom.CostPendingRoom);
                       if (aBookingRoomPending != null)
                       {
                           decimal? CostPending = aBookingRoomPending.Cost;
                           double? AddTimeStartPending = aBookingRoomPending.AddTimeStart;
                           double? AddTimeEndPending = aBookingRoomPending.AddTimeEnd;
                           decimal? TimeUserPending = aBookingRoomPending.TimeInUse;
                           if (CostPending == null)
                           {
                               CostPending = 0;
                           }
                           if (AddTimeStartPending == null)
                           {
                               AddTimeStartPending = 0;
                           }
                           if (AddTimeEndPending == null)
                           {
                               AddTimeEndPending = 0;
                           }
                           if (TimeUserPending == null)
                           {
                               TimeUserPending = 0;
                           }
                           decimal? aMoneyPendingRoom = this.CalculatorMoneyRoom(CostPending, AddTimeStartPending, AddTimeEndPending, TimeUserPending);
                           
                           // aPaymentExt_GetAllDataEN.DisplayMoneyPendingRoom = aMoneyPendingRoom;
                   }       
                   }
                       
                        
                        
                       
                      
                    //------------------------------------------------------------------------------------
                    aListPaymentExt_GetAllDataEN.Add(aPaymentExt_GetAllDataEN);
                   
                }        
                dgvPaymentViewUnPay.DataSource = aListPaymentExt_GetAllDataEN;
                dgvPaymentViewUnPay.RefreshDataSource();
                
                
            }
            catch (Exception ex) 
            {
                throw new Exception("Error frmTsk_UnPay " + ex.Message);
            }
        }
        
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
        private void btnReLoadData_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void lueIDCompanies_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lueIDCompanies.EditValue == null)
                {
                    MessageBox.Show("Vui lòng chọn tên công ty.");
                    lueIDCompanies.Focus();
                    return;
                }
                BookingRsBO abookingRsBO = new BookingRsBO();
                BookingRs abookingRs = new BookingRs();
                List<PaymentExt_GetAllDataEN> aListPaymentExt_GetAllDataEN = new List<PaymentExt_GetAllDataEN>();
                int IDCompany = Convert.ToInt32(lueIDCompanies.EditValue.ToString());

                CustomerGroupsBO aCustomerGroupBO = new CustomerGroupsBO();
                List<int> aListIDCustomerGroup = aCustomerGroupBO.Select_All().Where(x => x.IDCompany == IDCompany).Select(p => p.ID).ToList();
                 
                List<int> ListIDBookingR = abookingRsBO.Select_ByListCustomerGroup(aListIDCustomerGroup).Select(p => p.ID).ToList();

                PaymentBO aPaymentBO = new PaymentBO();
                List<sp_PaymentExt_GetAllData_Result> aListTemp = aPaymentBO.Search_ServicesStatus_ObjectStatus_BillRPaymentStatusByCompany(ListIDBookingR);
                PaymentExt_GetAllDataEN aPaymentExt_GetAllDataEN;

                foreach (sp_PaymentExt_GetAllData_Result item in aListTemp)
                {
                    BookingRooms aBookingRoom = aBookingRoomBO.Select_ByIDBookingR(item.BookingRs_ID);

                    decimal? cost = aBookingRoom.Cost;
                    if (cost == null)
                    {
                        cost = 0;
                    }
                    double? addTimeStart = aBookingRoom.AddTimeStart;
                    if (addTimeStart == null)
                    {
                        addTimeStart = 0;
                    }
                    double? addTimeEnd = aBookingRoom.AddTimeEnd;
                    if (addTimeEnd == null)
                    {
                        addTimeEnd = 0;
                    }

                    decimal? timeUser = aBookingRoom.TimeInUse;
                    if (timeUser == null)
                    {
                        timeUser = 0;
                    }
                    double? costPendingRoom = aBookingRoom.CostPendingRoom;
                    if (costPendingRoom == null)
                    {
                        costPendingRoom = 0;
                    }
                    double? tax = aBookingRoom.PercentTax;
                    if (tax == null)
                    {
                        tax = 0;
                    }
                    decimal? sum = CalculatorMoneyRoom(cost, addTimeStart, addTimeEnd, timeUser);

                    // Tinh pending 
                    aPaymentExt_GetAllDataEN = new PaymentExt_GetAllDataEN();
                    aPaymentExt_GetAllDataEN.SetValue(item);
                    if (item.IDService == null)
                    {
                        aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "Đã thanh toán";
                    }
                    if (item.BillR_PaymentStatus == 8)
                    {
                        aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Đã thanh toán";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Chưa thanh toán";
                    }
                    if (item.Object_PaymentStatus == 8)
                    {
                        aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Đã thanh toán";
                    }
                    else
                    {
                        aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Chưa thanh toán";

                    }

                    aPaymentExt_GetAllDataEN.DisplayMoneySumRoom = sum;
                    aListPaymentExt_GetAllDataEN.Add(aPaymentExt_GetAllDataEN);
                }
                dgvPaymentViewUnPay.DataSource = aListPaymentExt_GetAllDataEN;
                dgvPaymentViewUnPay.RefreshDataSource();


            }
            catch (Exception ex)
            {
                throw new Exception("frmTsk_UnPay " + ex.ToString());
            }
        }

        public decimal? CalculatorMoneyRoom(decimal? cost,double? addTimeStart,double? addTimeEnd,decimal? timeUser) 
        {
           // ReportTaskBO repo = new ReportTaskBO();
           // AccountancyBO ac = new AccountancyBO();
         
            decimal? Sum = (cost * Convert.ToDecimal(timeUser / (24 * 60) + Convert.ToDecimal(addTimeStart) + Convert.ToDecimal(addTimeEnd)));
            return Sum;
        }
        
       
        
    }
}
