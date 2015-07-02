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
using BussinessLogic;
using DataAccess;
using Entity;

using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmRpt_Performance_Rooms : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime From;
        private DateTime To;
        private int IDLang;

        public frmRpt_Performance_Rooms(DateTime From, DateTime To, int IDLang)
        {
            InitializeComponent();
            this.From = From;
            this.To = To;
            this.IDLang = IDLang;

            lblFrom.Text = From.ToString();
            lblTo.Text = To.ToString();
            RoomsBO aRoomsBO = new RoomsBO();
            ReportTaskBO aReportTaskBO = new ReportTaskBO();
            List<Rooms> aListRooms = aRoomsBO.Select_ByIDLang(IDLang);
            List<string> aListCodeRoom = new List<string>();
            for (int i = 0; i < aListRooms.Count; i++)
            {
                string CodeRoom = aListRooms[i].Code;
                aListCodeRoom.Add(CodeRoom);
            }

            List<EfficiencyEN> aListEfficiencyEN = aReportTaskBO.GetEfficiencyRoom(From, To, aListCodeRoom);

            //List<EfficiencyEN> List1 = new List<EfficiencyEN>();
            //List<EfficiencyEN> List2 = new List<EfficiencyEN>();

            //List1 = aListEfficiencyEN.GetRange(0, Convert.ToInt32(Math.Floor(Convert.ToDouble(aListEfficiencyEN.Count / 2))));
            //List2 = aListEfficiencyEN.GetRange(Convert.ToInt32(Math.Ceiling(Convert.ToDouble(aListEfficiencyEN.Count / 2))), aListEfficiencyEN.Count);

            this.DataSource = aListEfficiencyEN;
            cellSkuRoom.DataBindings.Add("Text", this.DataSource, "Sku");
            cellPerformance.DataBindings.Add("Text", this.DataSource, "Efficiency");



            double x = aListEfficiencyEN.Select(a => a.Efficiency).Sum();
            double y = aListEfficiencyEN.Count;
            lblPerformance.Text = (Math.Round(x / y, 2)).ToString() + "%";

        }

    }
}
