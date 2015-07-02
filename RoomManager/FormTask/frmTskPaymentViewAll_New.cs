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

namespace RoomManager
{
    public partial class frmTsk_PaymentViewAll_New : DevExpress.XtraEditors.XtraForm
    {
        List<PaymentExt_GetAllDataEN> aListPaymentExt_GetAllDataEN = new List<PaymentExt_GetAllDataEN>();
        public frmTsk_PaymentViewAll_New()
        {
            InitializeComponent();
        }

        private void frmTsk_PaymentViewAll_New_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }
        public void LoadData()
        {
            //-----------------------------------------------------
            lueIDCompanies.Properties.DataSource = this.LoadListCompaniesByType();
            lueIDCompanies.Properties.ValueMember = "ID";
            lueIDCompanies.Properties.DisplayMember = "Name";
            //-----------------------------------------------------

            this.aListPaymentExt_GetAllDataEN = new List<PaymentExt_GetAllDataEN>();
            List<sp_PaymentExt_GetAllData_Ext_Result> aListData = new List<sp_PaymentExt_GetAllData_Ext_Result>(); 
            DatabaseDA aDatabaseDA = new DatabaseDA();

            aListData = aDatabaseDA.sp_PaymentExt_GetAllData_Ext().ToList();
            PaymentExt_GetAllDataEN aPaymentExt_GetAllDataEN;

            foreach (sp_PaymentExt_GetAllData_Ext_Result item in aListData)
            {
                
                aPaymentExt_GetAllDataEN = new PaymentExt_GetAllDataEN();
                aPaymentExt_GetAllDataEN.SetValue(item);
                if (item.Service_PaymentStatus == null)
                {
                    aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "";
                }

                else if (item.Service_PaymentStatus == 8 )
                {
                    aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "Đã thanh toán";
                }
                else 
                {
                    //aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "Chưa thanh toán";
                    aPaymentExt_GetAllDataEN.DisplayService_PaymentStatus = "";
                 
                }


                //-----------------------------------------------------------
                if (item.Object_PaymentStatus == null)
                {
                    aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "";
                }

                else if (item.Object_PaymentStatus == 8)
                {
                    aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Đã thanh toán";
                }
                else
                {
                    //aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "Chưa thanh toán";
                    aPaymentExt_GetAllDataEN.DisplayObject_PaymentStatus = "";

                }
                //------------------------------------------------------------------------------------
                if (item.BillR_PaymentStatus == 8)
                {
                    aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Đã thanh toán";
                }
                else
                {
                    //aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "Chưa thanh toán";
                    aPaymentExt_GetAllDataEN.DisplayBillR_PaymentStatus = "";
                }
                //------------------------------------------------------------
                if (item.Object_InvoiceDate.GetValueOrDefault().Year == 0001 || item.Object_InvoiceDate.GetValueOrDefault().Year == 1900)
                {
                    aPaymentExt_GetAllDataEN.Object_InvoiceDate = "";
                }
                //------------------------------------------------------------
                if (item.Object_AcceptDate.GetValueOrDefault().Year == 0001 || item.Object_AcceptDate.GetValueOrDefault().Year == 1900)
                {
                    aPaymentExt_GetAllDataEN.Object_AcceptDate = null;
                }
                aListPaymentExt_GetAllDataEN.Add(aPaymentExt_GetAllDataEN);
            }
            dgvPaymentViewAll.DataSource = aListPaymentExt_GetAllDataEN;
            dgvPaymentViewAll.RefreshDataSource();
        }

        private void btnPaymentInfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDBookingR = Convert.ToInt32(grvPaymentViewAll.GetFocusedRowCellValue("BookingRs_ID"));
            string ObjectType = grvPaymentViewAll.GetFocusedRowCellValue("ObjectType").ToString();
            bool IsFocusTab1 = true; 
            if (ObjectType == "Phòng")
            {
                IsFocusTab1 = true;
            }
            else
            {
                IsFocusTab1 = false;
            }

            BookingRs_BookingHsBO aBookingRs_BookingHsBO = new BookingRs_BookingHsBO();
            int IDBookingH = 0;
            if (aBookingRs_BookingHsBO.Select_ByIDBookingR(IDBookingR) == null)
            {
                IDBookingH = 0;
            }
            else
            {
                IDBookingH = Convert.ToInt32(aBookingRs_BookingHsBO.Select_ByIDBookingR(IDBookingR).IDBookingH);
            }

            List<int?> ListStatus = aListPaymentExt_GetAllDataEN.Where(p => p.BookingRs_ID == IDBookingR).Select(p => p.BillR_PaymentStatus).ToList();

            frmTsk_Payment_Step2 afrmTsk_Payment_Step2 = new frmTsk_Payment_Step2(this, IDBookingR, IDBookingH, ListStatus[0].GetValueOrDefault(0), IsFocusTab1);
            afrmTsk_Payment_Step2.ShowDialog();

        }

        private void btnReLoadData_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private List<Companies> LoadListCompaniesByType()
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                Companies aItem = new Companies();
                aItem.Name = "[Hiện tất cả]";
                aItem.ID = 0;
                List<Companies> aList = new List<Companies>();
                aList = aCompaniesBO.Select_All();
                aList.Add(aItem);
                return aList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_BookingForRoom.LoadListCompaniesByType()\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void lueIDCompanies_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIDCompanies.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn tên công ty.");
                lueIDCompanies.Focus();
           
            }
            BookingRsBO aBookingRsBO = new BookingRsBO();
            BookingRs aBookingRs = new BookingRs();
            List<PaymentExt_GetAllDataEN> aListPaymentExt_GetAllDataEN = new List<PaymentExt_GetAllDataEN>();
            int IDCompany = Convert.ToInt32(lueIDCompanies.EditValue.ToString());

            CustomerGroupsBO aCustomerGroupBO = new CustomerGroupsBO();
            List<int> aListIDCustomerGroup = aCustomerGroupBO.Select_All().Where(x => x.IDCompany == IDCompany).Select(p => p.ID).ToList();

            CompaniesBO aCompaniesBO = new CompaniesBO();
            List<int> ListIDBookingR = aBookingRsBO.Select_ByIDCompany(int.Parse(lueIDCompanies.EditValue.ToString())).Select(p=>p.ID).ToList();
            dgvPaymentViewAll.DataSource = this.aListPaymentExt_GetAllDataEN.Where(p => ListIDBookingR.Contains(p.BookingRs_ID));
          
        }


        private void txtSubject_Leave(object sender, EventArgs e)
        {
            int IDBookingR = Convert.ToInt32(grvPaymentViewAll.GetFocusedRowCellValue("BookingRs_ID"));
            string ObjectType = grvPaymentViewAll.GetFocusedRowCellValue("ObjectType").ToString();
            string Subject = grvPaymentViewAll.GetFocusedRowCellValue("Subject").ToString();

            if (ObjectType == "Phòng")
            {
                BookingRs aItem = new BookingRs();
                BookingRsBO aBookingRsBO = new BookingRsBO();
                aItem = aBookingRsBO.Select_ByID(IDBookingR);
                aItem.Subject = Subject;
                aBookingRsBO.Update(aItem);
                this.LoadData();
            }
            else
            {
                BookingHs aItem = new BookingHs();
                BookingHsBO aBookingHsBO = new BookingHsBO();
                BookingRs_BookingHsBO aBookingRs_BookingHsBO = new BookingRs_BookingHsBO();
                int IDBookingH = aBookingRs_BookingHsBO.Select_ByIDBookingR(IDBookingR).IDBookingH.GetValueOrDefault(0);

                aItem = aBookingHsBO.Select_ByID(IDBookingH);
                aItem.Subject = Subject;
                aBookingHsBO.Update(aItem);
                this.LoadData();
            }
        }
    }
}