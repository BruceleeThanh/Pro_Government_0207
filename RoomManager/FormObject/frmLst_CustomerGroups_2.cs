using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using DevExpress.XtraRichEdit.API.Word;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmLst_CustomerGroups_2 : DevExpress.XtraEditors.XtraForm
    {
        #region Room
        private frmLst_CustomerGroups_2 afrmLst_CustomerGroups_Old = null;
        int CurrentIDCustomerGroup = 0;
        public frmLst_CustomerGroups_2()
        {
            InitializeComponent();
            this.IsReadyInit = false;
        }
        public frmLst_CustomerGroups_2(frmLst_CustomerGroups_2 afrmLst_CustomerGroups)
        {
            InitializeComponent();
            afrmLst_CustomerGroups_Old = afrmLst_CustomerGroups;
        }


        private void frmIns_CustomerGroups_Load(object sender, EventArgs e)
        {
            try
            {
                CompaniesBO aCompaniesBO = new CompaniesBO();
                List<Companies> aListCompanies = aCompaniesBO.Select_All();
                Companies aItem = new Companies();
                aItem.Name ="[Tất cả]";
                aItem.ID = 0;
                aListCompanies.Add(aItem);

                lueFilterCompany.Properties.DataSource = aListCompanies;
                lueFilterCompany.Properties.DisplayMember = "Name";
                lueFilterCompany.Properties.ValueMember = "ID";
                

                this.IsReadyInit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CustomerGroups.frmIns_CustomerGroups_Load\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        #endregion
        #region Sale


        #endregion

       
        #region Ngoc New
        private int IDBookingR;
        private bool IsReadyInit ;

        public frmLst_CustomerGroups_2(int IDBookingR)
        {
            InitializeComponent();
            this.IsReadyInit = false;
        }

        private void lueFilterCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (this.IsReadyInit == true)
            {
                if (int.Parse(lueFilterCompany.EditValue.ToString()) > 0)
                {
                    dgvAvailableCustomerGroups.DataSource = (new CustomerGroupsBO()).Select_ByIDCompany(int.Parse(lueFilterCompany.EditValue.ToString()));
                }
                else if (int.Parse(lueFilterCompany.EditValue.ToString()) == 0)
                {
                    dgvAvailableCustomerGroups.DataSource = (new CustomerGroupsBO()).Select_All();
                }
            }
        }
        #endregion


        private void viewAvailableCustomerGroups_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            CurrentIDCustomerGroup = Convert.ToInt32(viewAvailableCustomerGroups.GetFocusedRowCellValue("ID"));
            string CustomerGroupName = viewAvailableCustomerGroups.GetFocusedRowCellValue("Name").ToString();
            txtCustomerGroupName.Text = CustomerGroupName;

            dgvCustomerMember.DataSource = (new BookingRoomsBO()).SelectListInfoCustomer_ByIDBookingR(CurrentIDCustomerGroup).Select(x => new {x.BookingRooms_CheckInActual,x.BookingRooms_CheckInPlan, x.BookingRooms_CheckOutActual , x.BookingRooms_CheckOutPlan, x.Customers_Birthday, x.Customers_Name, x.Customers_Identifier1,x.Rooms_Sku }) .Distinct().ToList();
            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
            //List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups> aListCustomerInGroup = aBookingRoomsBO.SelectListInfoCustomer_ByIDCustomerGroup(CurrentIDCustomerGroup).Distinct().ToList();
            //frmRpt_ListCustomersInGroup afrmRpt_ListCustomersInGroup = new frmRpt_ListCustomersInGroup(aListCustomerInGroup,lueFilterCompany.Text,txtCustomerGroupName.Text);
            //ReportPrintTool tool = new ReportPrintTool(afrmRpt_ListCustomersInGroup);
            //tool.ShowPreview();

        }

    }
}