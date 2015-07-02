using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using BussinessLogic;
using DataAccess;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmRpt_OverNightCustomer : DevExpress.XtraReports.UI.XtraReport
    {
        
        public frmRpt_OverNightCustomer(List<OverNightCustomerEN> aListOverNightCustomerEN)
        {
            InitializeComponent();
            this.DetailReport.DataSource = aListOverNightCustomerEN;
            lblRoomSku.DataBindings.Add("Text", this.DetailReport.DataSource, "Sku");
            lblName.DataBindings.Add("Text", this.DetailReport.DataSource, "Name");
            lblBirthday.DataBindings.Add("Text", this.DetailReport.DataSource, "Birthday","{0:dd/MM/yyyy}");

            lblIdentify.DataBindings.Add("Text", this.DetailReport.DataSource, "Identifier1");
            lblCompany.DataBindings.Add("Text", this.DetailReport.DataSource, "CompanyName");
            lblCreatedDate.DataBindings.Add("Text", this.DetailReport.DataSource, "Identifier1CreatedDate", "{0:dd/MM/yyyy}");
            lblAdress.DataBindings.Add("Text", this.DetailReport.DataSource, "Address");
            lblPlaceOfIssue1.DataBindings.Add("Text", this.DetailReport.DataSource, "PlaceOfIssue1");
            lblCheckInActual.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckInActual", "{0:dd/MM/yyyy}");
            lblCheckOutPlan.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutPlan", "{0:dd/MM/yyyy}");
            lblDateNow.Text = DateTime.Now.Day.ToString();
            lblMonthNow.Text = DateTime.Now.Month.ToString();
            lblYearNow.Text = DateTime.Now.Year.ToString();

            lblIDSystem.Text = CORE.CURRENTUSER.SystemUser.Name;

        }



    }
}
