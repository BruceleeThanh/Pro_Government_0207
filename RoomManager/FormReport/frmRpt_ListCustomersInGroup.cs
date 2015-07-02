using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BussinessLogic;
using Entity;
using DataAccess;
using DevExpress.XtraRichEdit.API.Word;
using System.Linq;
using Library;
using System.Globalization;

namespace RoomManager
{
    public partial class frmRpt_ListCustomersInGroup : DevExpress.XtraReports.UI.XtraReport
    {
        string CompanyName, GroupName;
        List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups> aListCustomerInGroup = new List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups>();
        public frmRpt_ListCustomersInGroup(List<vw__BookingRInfo__BookingRooms_Room_Customers_CustomerGroups> aListCustomerInGroup, string CompanyName, string GroupName)
        {
            InitializeComponent();
            this.aListCustomerInGroup = aListCustomerInGroup;
            this.CompanyName = CompanyName;
            this.GroupName = GroupName;
            var aListCustomer = aListCustomerInGroup.Select(x => new { x.BookingRooms_CheckInActual, x.BookingRooms_CheckInPlan, x.BookingRooms_CheckOutActual, x.BookingRooms_CheckOutPlan, x.Customers_Birthday, x.Customers_Name, x.Customers_Identifier1, x.Rooms_Sku }).Distinct().ToList();
            
            //Truyền dữ liệu vào report
            lblCompany.Text = this.CompanyName;
            lblGroup.Text = this.GroupName;
            lblNameCustomer.Text = aListCustomer[0].Customers_Name;

            this.DetailReport.DataSource = aListCustomer;
            colCustomerName.DataBindings.Add("Text", this.DetailReport.DataSource, "Customers_Name");
            colBirthday.DataBindings.Add("Text", this.DetailReport.DataSource, "Customers_Birthday", "{0:dd-MM-yyyy}");
            colCheckIn.DataBindings.Add("Text", this.DetailReport.DataSource, "BookingRooms_CheckInActual", "{0:dd-MM-yyyy HH:mm}");
            colCheckOut.DataBindings.Add("Text", this.DetailReport.DataSource, "BookingRooms_CheckOutActual", "{0:dd-MM-yyyy HH:mm}");
            colIndentify.DataBindings.Add("Text", this.DetailReport.DataSource, "Customers_Identifier1");
            colSku.DataBindings.Add("Text", this.DetailReport.DataSource, "Rooms_Sku");

        }
    }
}
