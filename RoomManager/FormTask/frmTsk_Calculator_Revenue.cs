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
using DevExpress.Utils;

namespace RoomManager
{
    public partial class frmTsk_Calculator_Revenue : DevExpress.XtraEditors.XtraForm
    {

        private DateTime FromDate;
        private DateTime ToDate;
        public frmTsk_Calculator_Revenue()
        {
            InitializeComponent();
        }
        private bool ValidateData()
        {
            if (dtpFrom.Text == "")
            {
                MessageBox.Show("Nhập ngày bắt đầu trước khi tính doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (dtpTo.Text == "")
            {
                MessageBox.Show("Nhập ngày kết thúc trước khi tính doanh thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (dtpTo.DateTime < dtpFrom.DateTime)
                {
                    MessageBox.Show("Nhập ngày bắt đầu nhỏ hơn ngày kết thúc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void frmTsk_Calculator_Revenue_Load(object sender, EventArgs e)
        {
            dtpFrom.DateTime = DateTime.Now.AddDays(-30); // Set thoi gian chon lua cach tdiem hien tai 30 ngay
            dtpTo.DateTime = DateTime.Now;
        }

        private void btnCalculatorRevenue_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    //btnPrintRevenue.Enabled = true;
                    this.FromDate = dtpFrom.DateTime;
                    this.ToDate = dtpTo.DateTime;
                    this.LoadDataRevenueRooms(FromDate, ToDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Calculator_Revenue.btnCalculatorRevenue_Click\n"+ ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDataRevenueRooms(DateTime FromDate,DateTime ToDate)
        {
            try
            {
                if (FromDate >= ToDate)
                {
                    MessageBox.Show("Vui lòng nhập ngày bắt đầu kiểm tra nhỏ hơn ngày kết thúc .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReportTaskBO aReportTaskBO = new ReportTaskBO();
                    RoomsBO aRoomsBO = new RoomsBO();
                    List<Rooms> aListRooms = aRoomsBO.Select_ByIDLang(1);
                    List<string> aListCodeRoom = new List<string>();
                    for (int i = 0; i < aListRooms.Count; i++)
                    {
                        string CodeRoom = aListRooms[i].Code;
                        aListCodeRoom.Add(CodeRoom);
                    }
                    List<RevenueEN> aListRevenueEN = aReportTaskBO.GetRevenueRoom(this.FromDate,this.ToDate,aListCodeRoom);
                    colRevenue.DisplayFormat.FormatType = FormatType.Numeric;
                    colRevenue.DisplayFormat.FormatString = "{0:0,0}";
                    dgvRevenue.DataSource = aListRevenueEN;
                    
                    double TotalMoney = aListRevenueEN.Select(r => r.Revenue).Sum();
                    lblTotalRevenue.Text = String.Format("{0:0,0}", TotalMoney);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Calculator_Revenue.LoadDataRevenueRooms\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintRevenue_Click(object sender, EventArgs e)
        {
            try
            {
                frmRpt_Revenue_Rooms afrmRpt_Revenue_Rooms = new frmRpt_Revenue_Rooms(this.FromDate,this.ToDate,1);//1= IDLang
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_Revenue_Rooms);
                tool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_Calculator_Revenue.btnPrintRevenue_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}