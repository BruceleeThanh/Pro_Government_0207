using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using BussinessLogic;
using DataAccess;
using System.Linq;
using Entity;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmRpt_VietnameseCustomer : DevExpress.XtraReports.UI.XtraReport
    {
        public frmRpt_VietnameseCustomer(List<OverNightCustomerEN> aListOverNightCustomerEN, List<OverNightCustomerEN> aListNewOverNightCustomerEN, List<OverNightCustomerEN> aListOldOverNightCustomerEN)
        {
            InitializeComponent();
            this.DetailReport.DataSource = aListOverNightCustomerEN;


            lblDateNow.Text = DateTime.Now.Day.ToString();
            lblMonthNow.Text = DateTime.Now.Month.ToString();
            lblYearNow.Text = DateTime.Now.Year.ToString();
            cellName.DataBindings.Add("Text", this.DetailReport.DataSource, "Name");
            cellBirthday.DataBindings.Add("Text", this.DetailReport.DataSource, "Birthday", "{0:dd/MM/yyyy}");
            cellGender.DataBindings.Add("Text", this.DetailReport.DataSource, "Gender");
            cellIdentify.DataBindings.Add("Text", this.DetailReport.DataSource, "Identifier1");
            cellNational.DataBindings.Add("Text", this.DetailReport.DataSource, "Nationality");
            cellAddress.DataBindings.Add("Text", this.DetailReport.DataSource, "Address");
            cellCheckInActual.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckInActual", "{0:dd/MM/yyyy}");
            cellCheckOutPlan.DataBindings.Add("Text", this.DetailReport.DataSource, "CheckOutPlan", "{0:dd/MM/yyyy}");
            cellRoomSku.DataBindings.Add("Text", this.DetailReport.DataSource, "Sku");
            cellGender.DataBindings.Add("Text", this.DetailReport.DataSource, "Gender");
            //Ghi chu'
            //lblTotalCus.Text = aListOverNightCustomerEN.Count.ToString();
            //lblTotalCus.Text = aListOverNightCustomerEN.Count.ToString();
            lblTotalNewCus.Text = aListNewOverNightCustomerEN.Count.ToString();
            lblNewMale.Text = aListNewOverNightCustomerEN.Where(a => a.Gender == "1").ToList().Count.ToString();
            lblNewFemale.Text = aListNewOverNightCustomerEN.Where(a => a.Gender == "2").ToList().Count.ToString();
            lblGov.Text = aListNewOverNightCustomerEN.Where(a => a.CustomerType == 1).ToList().Count.ToString();
            lblTown.Text = aListNewOverNightCustomerEN.Where(a => a.Citizen == 2).ToList().Count.ToString();
            lblHaNoi.Text = aListNewOverNightCustomerEN.Where(a => a.Citizen == 1).ToList().Count.ToString();
            lblNewForeign.Text = aListNewOverNightCustomerEN.Where(a => a.Nationality != "VN").ToList().Count.ToString();

            lblOldCus.Text = aListOldOverNightCustomerEN.Count.ToString();
            lblOldMale.Text = aListOldOverNightCustomerEN.Where(a => a.Gender == "1").ToList().Count.ToString();
            lblOldForeign.Text = aListOldOverNightCustomerEN.Where(a => a.Nationality != "VN").ToList().Count.ToString();
            lblIDSystemUser.Text = CORE.CURRENTUSER.SystemUser.Name;
        }

    }
}
