using BussinessLogic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomManager
{
    public partial class frmTsk_StatusInMonth_Room : Form
    {
        public frmTsk_StatusInMonth_Room()
        {
            InitializeComponent();
        }
        List<List<RptRoomStatusEN>> aRet = new List<List<RptRoomStatusEN>>();
        List<RptRoomStatusForShowEN> DataShow = new List<RptRoomStatusForShowEN>();
            

        private void frmTsk_StatusInMonth_Room_Load(object sender, EventArgs e)
        {
            dtpCheckPoint.DateTime = DateTime.Now;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReportTaskBO aReportTaskBO = new ReportTaskBO();
            

            aRet = aReportTaskBO.RoomsPerformanceInMonth(DateTime.Parse(dtpCheckPoint.Text));
            DataShow = ConvertToForShowReport(aRet);
            
            //gridView1. = ConvertToForShowReport(aRet);
            gridControl1.DataSource = ConvertToForShowReport(aRet);
            //gridControl1.DataBindings.Add("Text", DataShow, "Sku");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date1");


            //gridControl1.DataBindings.Add("Text", DataShow, "Date2");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date3");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date4");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date5");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date6");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date7");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date8");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date9");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date10");

            //gridControl1.DataBindings.Add("Text", DataShow, "Date11");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date12");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date13");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date14");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date15");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date16");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date17");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date18");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date19");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date20");

            //gridControl1.DataBindings.Add("Text", DataShow, "Date21");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date22");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date23");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date24");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date25");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date26");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date27");
            //gridControl1.DataBindings.Add("Text", DataShow, "Date28");

            //if (aRet.Count >= 30)
            //{
            //    gridControl1.DataBindings.Add("Text", DataShow, "Date29");
            //    gridControl1.DataBindings.Add("Text", DataShow, "Date30");
            //}
            //if (aRet.Count == 31)
            //{
            //    gridControl1.DataBindings.Add("Text", DataShow, "Date31");
            //}

        }
        public List<RptRoomStatusForShowEN> ConvertToForShowReport(List<List<RptRoomStatusEN>> aList)
        {
            List<RptRoomStatusForShowEN> aListRet = new List<RptRoomStatusForShowEN>();
            RptRoomStatusForShowEN aTemp = new RptRoomStatusForShowEN();
            if (aList.Count > 0)  // Co danh sach du lieu cac ngay
            {
                if (aList[0].Count > 0) // co danh sach du lieu cac phong
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

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            //int Date = e.Column.ColumnHandle ;
            //int Room = e.RowHandle ;

            //MessageBox.Show(aRet[Date][Room].Text+"-"+ aRet[Date][Room].RoomSku +"-"+aRet[Date][Room].NumberCustomer);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;

            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {

                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                int Date = int.Parse(colCaption);
                int Room = info.RowHandle ;
                
                MessageBox.Show(String.Join(",", aRet[Date-1][Room].ListCustomers));
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmRpt_StatusInMonth_Rooms afrmRpt_StatusInMonth_Rooms = new frmRpt_StatusInMonth_Rooms(aRet);
            ReportPrintTool tool = new ReportPrintTool(afrmRpt_StatusInMonth_Rooms);
            tool.ShowPreview();
        }

        
    }
}
