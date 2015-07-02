using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BussinessLogic;
using Entity;
using System.Linq;
using System.Collections.Generic;

namespace RoomManager
{
    public partial class frmRpt_StatusInMonth_Rooms : DevExpress.XtraReports.UI.XtraReport
    {
        public frmRpt_StatusInMonth_Rooms(List<List<RptRoomStatusEN>> aRet)
        {
            InitializeComponent();

            //DateTime dt = DateTime.Now.AddMonths(-5);

            XRBinding aXRBinding = new XRBinding();

           

            this.DataSource = ConvertToForShowReport(aRet);


            colSku.DataBindings.Add("Text", this.DataSource, "Sku");



            col1.DataBindings.Add("Text", this.DataSource, "Date1");


            col2.DataBindings.Add("Text", this.DataSource, "Date2");
            col3.DataBindings.Add("Text", this.DataSource, "Date3");
            col4.DataBindings.Add("Text", this.DataSource, "Date4");
            col5.DataBindings.Add("Text", this.DataSource, "Date5");
            col6.DataBindings.Add("Text", this.DataSource, "Date6");
            col7.DataBindings.Add("Text", this.DataSource, "Date7");
            col8.DataBindings.Add("Text", this.DataSource, "Date8");
            col9.DataBindings.Add("Text", this.DataSource, "Date9");
            col10.DataBindings.Add("Text", this.DataSource, "Date10");

            col11.DataBindings.Add("Text", this.DataSource, "Date11");
            col12.DataBindings.Add("Text", this.DataSource, "Date12");
            col13.DataBindings.Add("Text", this.DataSource, "Date13");
            col14.DataBindings.Add("Text", this.DataSource, "Date14");
            col15.DataBindings.Add("Text", this.DataSource, "Date15");
            col16.DataBindings.Add("Text", this.DataSource, "Date16");
            col17.DataBindings.Add("Text", this.DataSource, "Date17");
            col18.DataBindings.Add("Text", this.DataSource, "Date18");
            col19.DataBindings.Add("Text", this.DataSource, "Date19");
            col20.DataBindings.Add("Text", this.DataSource, "Date20");

            col21.DataBindings.Add("Text", this.DataSource, "Date21");
            col22.DataBindings.Add("Text", this.DataSource, "Date22");
            col23.DataBindings.Add("Text", this.DataSource, "Date23");
            col24.DataBindings.Add("Text", this.DataSource, "Date24");
            col25.DataBindings.Add("Text", this.DataSource, "Date25");
            col26.DataBindings.Add("Text", this.DataSource, "Date26");
            col27.DataBindings.Add("Text", this.DataSource, "Date27");
            col28.DataBindings.Add("Text", this.DataSource, "Date28");

            if (aRet.Count >= 30)
            {
                col29.DataBindings.Add("Text", this.DataSource, "Date29");
                col30.DataBindings.Add("Text", this.DataSource, "Date30");
            }
            if (aRet.Count == 31)
            {
                col31.DataBindings.Add("Text", this.DataSource, "Date31");
            }

            colTotalCustomer.DataBindings.Add("Text", this.DataSource, "TotalCustomer");


            string fromDateToDate = string.Empty;

            if (aRet.Count == 28)
            {
                fromDateToDate = "Từ ngày 01 đến ngày 28 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
            }
            else if (aRet.Count == 30)
            {
                fromDateToDate = "Từ ngày 01 đến ngày 30 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
            }
            else
            {
                fromDateToDate = "Từ ngày 01 đến ngày 31 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString();
            }


            lblFromDateToDate.Text = fromDateToDate;
            lblDatePrint.Text = "Ngày in:" + DateTime.Now.ToString("dd-MM-yyyy");

        }
        public frmRpt_StatusInMonth_Rooms()
        {
            InitializeComponent();

            ReportTaskBO aReportTaskBO = new ReportTaskBO();
            List<List<RptRoomStatusEN>> aRet = new List<List<RptRoomStatusEN>>();
            
            //DateTime dt = DateTime.Now.AddMonths(-5);

            XRBinding aXRBinding = new XRBinding();
                 
            aRet = aReportTaskBO.RoomsPerformanceInMonth(DateTime.Now);

            this.DataSource = ConvertToForShowReport(aRet);


            colSku.DataBindings.Add("Text", this.DataSource, "Sku");



            col1.DataBindings.Add("Text", this.DataSource, "Date1");


            col2.DataBindings.Add("Text", this.DataSource, "Date2");
            col3.DataBindings.Add("Text", this.DataSource, "Date3");
            col4.DataBindings.Add("Text", this.DataSource, "Date4");
            col5.DataBindings.Add("Text", this.DataSource, "Date5");
            col6.DataBindings.Add("Text", this.DataSource, "Date6");
            col7.DataBindings.Add("Text", this.DataSource, "Date7");
            col8.DataBindings.Add("Text", this.DataSource, "Date8");
            col9.DataBindings.Add("Text", this.DataSource, "Date9");
            col10.DataBindings.Add("Text", this.DataSource, "Date10");

            col11.DataBindings.Add("Text", this.DataSource, "Date11");
            col12.DataBindings.Add("Text", this.DataSource, "Date12");
            col13.DataBindings.Add("Text", this.DataSource, "Date13");
            col14.DataBindings.Add("Text", this.DataSource, "Date14");
            col15.DataBindings.Add("Text", this.DataSource, "Date15");
            col16.DataBindings.Add("Text", this.DataSource, "Date16");
            col17.DataBindings.Add("Text", this.DataSource, "Date17");
            col18.DataBindings.Add("Text", this.DataSource, "Date18");
            col19.DataBindings.Add("Text", this.DataSource, "Date19");
            col20.DataBindings.Add("Text", this.DataSource, "Date20");

            col21.DataBindings.Add("Text", this.DataSource, "Date21");
            col22.DataBindings.Add("Text", this.DataSource, "Date22");
            col23.DataBindings.Add("Text", this.DataSource, "Date23");
            col24.DataBindings.Add("Text", this.DataSource, "Date24");
            col25.DataBindings.Add("Text", this.DataSource, "Date25");
            col26.DataBindings.Add("Text", this.DataSource, "Date26");
            col27.DataBindings.Add("Text", this.DataSource, "Date27");
            col28.DataBindings.Add("Text", this.DataSource, "Date28");

            if (aRet.Count >= 30)
            {
                col29.DataBindings.Add("Text", this.DataSource, "Date29");
                col30.DataBindings.Add("Text", this.DataSource, "Date30");
            }
            if (aRet.Count == 31)
            {
                col31.DataBindings.Add("Text", this.DataSource, "Date31");
            }

            colTotalCustomer.DataBindings.Add("Text", this.DataSource, "TotalCustomer");


            string fromDateToDate=string.Empty;
            
            if(aRet.Count == 28 )
            {
                fromDateToDate="Từ ngày 01 đến ngày 28 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString(); 
            }
            else if(aRet.Count == 30)
            {
                fromDateToDate="Từ ngày 01 đến ngày 30 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString(); 
            }
            else
            {
                fromDateToDate="Từ ngày 01 đến ngày 31 tháng " + DateTime.Now.Month.ToString() + " Năm " + DateTime.Now.Year.ToString(); 
            }


            lblFromDateToDate.Text = fromDateToDate;
            lblDatePrint.Text = "Ngày in:" + DateTime.Now.ToString("dd-MM-yyyy");

        }

        public List<RptRoomStatusForShowEN> ConvertToForShowReport(List<List<RptRoomStatusEN>> aList)
        {
            List<RptRoomStatusForShowEN> aListRet = new List<RptRoomStatusForShowEN>();
            RptRoomStatusForShowEN aTemp = new RptRoomStatusForShowEN();
            if (aList.Count >0 )  // Co danh sach du lieu cac ngay
            {
                if (aList[0].Count >0) // co danh sach du lieu cac phong
                {
                    for (int room = 0; room < aList[0].Count; room++)
                    {
                        aTemp = new RptRoomStatusForShowEN();
                        aTemp.Sku = aList[0][room].RoomSku;
                        
                        for (int date = 0; date < aList.Count; date++)
                        {
                            switch (date)
                            {
                                 case 0:
                                    aTemp.Date1 = aList[date][room].Text;
                                    break;
                                 case 1:
                                    aTemp.Date2 = aList[date][room].Text;
                                    break;
                                 case 2:
                                    aTemp.Date3 = aList[date][room].Text;
                                    break;
                                 case 3:
                                    aTemp.Date4 = aList[date][room].Text;
                                    break;
                                 case 4:
                                    aTemp.Date5 = aList[date][room].Text;
                                    break;
                                 case 5:
                                    aTemp.Date6 = aList[date][room].Text;
                                    break;
                                 case 6:
                                    aTemp.Date7 = aList[date][room].Text;
                                    break;
                                 case 7:
                                    aTemp.Date8 = aList[date][room].Text;
                                    break;
                                 case 8:
                                    aTemp.Date9 = aList[date][room].Text;
                                    break;
                                 case 9:
                                    aTemp.Date10 = aList[date][room].Text;
                                    break;
                                 case 10:
                                    aTemp.Date11 = aList[date][room].Text;
                                    break;
                                 case 11:
                                    aTemp.Date12 = aList[date][room].Text;
                                    break;
                                 case 12:
                                    aTemp.Date13 = aList[date][room].Text;
                                    break;
                                 case 13:
                                    aTemp.Date14 = aList[date][room].Text;
                                    break;
                                 case 14:
                                    aTemp.Date15 = aList[date][room].Text;
                                    break; 
                                case 15:
                                    aTemp.Date16 = aList[date][room].Text;
                                    break; 
                                case 16:
                                    aTemp.Date17 = aList[date][room].Text;
                                    break; 
                                case 17:
                                    aTemp.Date18 = aList[date][room].Text;
                                    break;
                                 case 18:
                                     aTemp.Date19 = aList[date][room].Text;
                                     break; 
                                case 19:
                                     aTemp.Date20 = aList[date][room].Text;
                                     break; 
                                case 20:
                                     aTemp.Date21 = aList[date][room].Text;
                                     break; 
                                case 21:
                                     aTemp.Date22 = aList[date][room].Text;
                                     break; 
                                case 22:
                                     aTemp.Date23 = aList[date][room].Text;
                                     break; 
                                case 23:
                                     aTemp.Date24 = aList[date][room].Text;
                                     break; 
                                case 24:
                                     aTemp.Date25 = aList[date][room].Text;
                                     break; 
                                case 25:
                                    aTemp.Date26 = aList[date][room].Text;
                                    break;
                                 case 26:
                                    aTemp.Date27 = aList[date][room].Text;
                                    break;
                                 case 27:
                                    aTemp.Date28 = aList[date][room].Text;
                                    break;
                                 case 28:
                                    aTemp.Date29 = aList[date][room].Text;
                                    break;
                                 case 29:
                                    aTemp.Date30 = aList[date][room].Text;
                                    break;
                                 case 30:
                                    aTemp.Date31 = aList[date][room].Text;
                                    break;

                            }
                            aTemp.TotalCustomer = aTemp.TotalCustomer + aList[date][room].NumberCustomer;   
                        }
                        aListRet.Add(aTemp);
                    }
                    
                }
            }
            return aListRet;
        }

    }
}
