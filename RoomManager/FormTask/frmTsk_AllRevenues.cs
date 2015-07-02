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
using Entity;
using DataAccess;
using BussinessLogic;
using DevExpress.Utils;
using CORESYSTEM;
using System.Globalization;
using DevExpress.XtraReports.UI;

namespace RoomManager
{
    public partial class frmTsk_AllRevenues : DevExpress.XtraEditors.XtraForm
    {
        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
        DateTime From,To;
        List<AllBookingEN> aListAllBookingEN = new List<AllBookingEN>();
        public Nullable<decimal> SumServiceRooms1_NotTax ;
        public Nullable<decimal> SumServiceRooms2_NotTax ;
        public Nullable<decimal> SumServiceRooms3_NotTax ;
        public Nullable<decimal> SumServiceHalls1_NotTax ;
        public Nullable<decimal> SumServiceHalls2_NotTax ;
        public Nullable<decimal> SumServiceHalls3_NotTax ;

        public frmTsk_AllRevenues()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            From = dtpFrom.DateTime;
            To = dtpTo.DateTime;
            aListAllBookingEN.Clear();
            aListAllBookingEN = aReceptionTaskBO.GetAllRevenues(From, To);
            foreach (AllBookingEN item in aListAllBookingEN)
            {
                SumServiceHalls1_NotTax = SumServiceHalls1_NotTax.GetValueOrDefault(0) + item.ServiceHalls1_NotTax;
                SumServiceHalls2_NotTax = SumServiceHalls2_NotTax.GetValueOrDefault(0) + item.ServiceHalls2_NotTax;
                SumServiceHalls3_NotTax = SumServiceHalls3_NotTax.GetValueOrDefault(0) + item.ServiceHalls3_NotTax;

                SumServiceRooms1_NotTax = SumServiceRooms1_NotTax.GetValueOrDefault(0) + item.ServiceRooms1_NotTax;
                SumServiceRooms2_NotTax = SumServiceRooms2_NotTax.GetValueOrDefault(0) + item.ServiceRooms2_NotTax;
                SumServiceRooms3_NotTax = SumServiceRooms3_NotTax.GetValueOrDefault(0) + item.ServiceRooms3_NotTax;
            }

            dgvAllBooking.DataSource = aListAllBookingEN;
            dgvAllBooking.RefreshDataSource();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           // List<sp_BookingExt_GetAllBooking_Result> aListAllBookingEN = new List<sp_BookingExt_GetAllBooking_Result>();

            frmRpt_Revenues aReport = new frmRpt_Revenues(aListAllBookingEN, From,To,
                SumServiceHalls1_NotTax, SumServiceHalls2_NotTax, SumServiceHalls3_NotTax,
                SumServiceRooms1_NotTax, SumServiceRooms2_NotTax, SumServiceRooms3_NotTax);
            ReportPrintTool tool = new ReportPrintTool(aReport);
            tool.ShowPreview();
        }
    }
}