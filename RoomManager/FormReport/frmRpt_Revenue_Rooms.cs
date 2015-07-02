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
using Entity;

using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmRpt_Revenue_Rooms : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime From;
        private DateTime To;
        private int IDLang;
        public frmRpt_Revenue_Rooms(DateTime From, DateTime To, int IDLang)
        {
            InitializeComponent();
            this.From = From;
            this.To = To;
            this.IDLang = IDLang;

            try
            {
                lblFrom.Text = From.ToString();
                lblTo.Text = To.ToString();
                ReportTaskBO aReportTaskBO = new ReportTaskBO();
                RoomsBO aRoomsBO = new RoomsBO();
                List<Rooms> aListRooms = aRoomsBO.Select_ByIDLang(IDLang);
                List<string> aListCodeRoom = new List<string>();
                for (int i = 0; i < aListRooms.Count; i++)
                {
                    string CodeRoom = aListRooms[i].Code;
                    aListCodeRoom.Add(CodeRoom);
                }
                List<RevenueEN> aListRevenueEN = aReportTaskBO.GetRevenueRoom(From, To, aListCodeRoom);
                this.DataSource = aListRevenueEN;

                cellSkuRoom.DataBindings.Add("Text", this.DataSource, "Sku");
                cellRevenue.DataBindings.Add("Text", this.DataSource, "Revenue","{0:0,0}");


                double TotalMoney = aListRevenueEN.Select(r => r.Revenue).Sum();
                lblRevenue.Text = String.Format("{0:0,0} (VND)",TotalMoney);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRpt_Revenue_Rooms.frmRpt_Revenue_Rooms\n" + ex.ToString());
            }

        }

    }
}
