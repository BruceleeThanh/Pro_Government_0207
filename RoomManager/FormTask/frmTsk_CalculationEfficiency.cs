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
    public partial class frmTsk_CalculationEfficiency : DevExpress.XtraEditors.XtraForm
    {
        RoomsBO aRoomsBO = new RoomsBO();
        ReportTaskBO aReportTaskBO = new ReportTaskBO();
        public frmTsk_CalculationEfficiency()
        {
            InitializeComponent();
        }


        private bool ValidateData()
        {
            if (String.IsNullOrEmpty(dtpFrom.Text) == true)
            {
                dtpFrom.Focus();
                MessageBox.Show("Nhập ngày bắt đầu trước khi tính hiệu suất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (String.IsNullOrEmpty(dtpTo.Text) == true)
            {
                dtpTo.Focus();
                MessageBox.Show("Nhập ngày kết thúc trước khi tính hiệu suất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (dtpTo.DateTime < dtpFrom.DateTime)
                {
                    dtpFrom.Focus();
                    MessageBox.Show("Nhập ngày bắt đầu nhỏ hơn ngày kết thúc !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData() == true)
                {
                    List<Rooms> aListRooms = aRoomsBO.Select_ByIDLang(1);
                    List<string> aListCodeRoom = new List<string>();

                    for (int i = 0; i < aListRooms.Count; i++)
                    {
                        string CodeRoom = aListRooms[i].Code;
                        aListCodeRoom.Add(CodeRoom);
                    }
                    List<EfficiencyEN> aListEfficiencyEN = aReportTaskBO.GetEfficiencyRoom(dtpFrom.DateTime, dtpTo.DateTime, aListCodeRoom);

                    dgvEfficiency.DataSource = aListEfficiencyEN;
                    dgvEfficiency.RefreshDataSource();
                    
                    
                   

                    double x = aListEfficiencyEN.Select(a => a.Efficiency).Sum();
                    double y = aListEfficiencyEN.Count;
                    lblResult.Text = (Math.Round(x / y, 2)).ToString();

                    btnPrintPerformance.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_CalculationEfficiency.btnCaculate_Click\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTsk_CalculationEfficiency_Load(object sender, EventArgs e)
        {
            btnPrintPerformance.Enabled = false;
            dtpTo.DateTime = DateTime.Now;
            dtpFrom.DateTime = DateTime.Now.AddDays(-30);
        }

        private void btnPrintPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                frmRpt_Performance_Rooms afrmRpt_Performance_Rooms = new frmRpt_Performance_Rooms(dtpFrom.DateTime, dtpTo.DateTime, 1);// 1 = IDLang 
                ReportPrintTool tool = new ReportPrintTool(afrmRpt_Performance_Rooms);
                tool.ShowPreview();
            }catch(Exception ex)
            {
                MessageBox.Show("frmTsk_CalculationEfficiency.btnPrintPerformance_Click\n" + ex.ToString());
            }
            
            
        }

       

    }
}