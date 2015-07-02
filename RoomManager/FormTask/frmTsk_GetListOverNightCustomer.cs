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
using System.IO;
using System.Drawing.Printing;
using TeamNet.Data.FileExport;

namespace RoomManager
{
    public partial class frmTsk_GetListOverNightCustomer : DevExpress.XtraEditors.XtraForm
    {
        ReportTaskBO aReportTaskBO = new ReportTaskBO();
        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
        RoomsBO aRoomsBO = new RoomsBO();
        DateTime CheckPoint;
        int Status = 3;
        List<OverNightCustomerEN> aListAllCustomer, aListNewCustomer, aListOldCustomer;


        public frmTsk_GetListOverNightCustomer()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Select ra danh sách toàn bộ khách ở qua đêm ở thời điểm check 
                this.CheckPoint = dtpCheckPoint.DateTime;
                aListAllCustomer = aReportTaskBO.GetOverNightCustomer(this.CheckPoint, Status);
                dgvCustomer.DataSource = aListAllCustomer;

                lblSumCustomers.Text = aListAllCustomer.Count.ToString();
                // Select ra danh sách khách nước ngoài
                lblSumForeignCustomers.Text = (aListAllCustomer.Where(a => a.Nationality != "VN").Count()).ToString();

                // Select ra danh sách khách đăng ký mới
                aListNewCustomer = aReportTaskBO.GetNewOverNightCustomer(this.CheckPoint, Status);
                aListOldCustomer = aReportTaskBO.GetOverNightCustomer(this.CheckPoint.AddDays(-1), Status);
                lblSumNewCustomers.Text = aListNewCustomer.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("frmTsk_GetListOverNightCustomer.btnSearch_Click \n" + ex.ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmRpt_OverNightCustomer afrmRpt_OverNightCustomer = new frmRpt_OverNightCustomer(aListAllCustomer);
            ReportPrintTool tool = new ReportPrintTool(afrmRpt_OverNightCustomer);
            tool.ShowPreview();
        }

        private void btnPrintList_Click(object sender, EventArgs e)
        {

            frmRpt_VietnameseCustomer aPage1 = new frmRpt_VietnameseCustomer(aListAllCustomer, aListNewCustomer, aListOldCustomer);
            aPage1.DefaultPrinterSettingsUsing.UseLandscape = true;
            aPage1.DefaultPrinterSettingsUsing.UsePaperKind = false;

            aPage1.PrintingSystem.PageSettings.Landscape = true;
            aPage1.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;

            ReportPrintTool tool = new ReportPrintTool(aPage1);
            aPage1.AssignPrintTool(tool);



            tool.PreviewForm.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            tool.PreviewForm.PrintingSystem.PageSettings.Landscape = true;

            tool.PreviewRibbonForm.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            tool.PreviewRibbonForm.PrintingSystem.PageSettings.Landscape = true;
            tool.ShowPreviewDialog();


        }

        private void frmTsk_GetListOverNightCustomer_Load(object sender, EventArgs e)
        {
            dtpCheckPoint.DateTime = DateTime.Now;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            List<OverNightCustomerEN> aListForeign = aListAllCustomer.Where(a => a.Nationality != "VN").ToList();
            frmTsk_ListForeignCustomer afrmTsk_ListForeignCustomer = new frmTsk_ListForeignCustomer(aListForeign);
            afrmTsk_ListForeignCustomer.Show();
        }

      




    }
}