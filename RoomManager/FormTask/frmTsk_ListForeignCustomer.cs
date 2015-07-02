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
using TeamNet.Data.FileExport;
using System.Net.Mail;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_ListForeignCustomer : DevExpress.XtraEditors.XtraForm
    {
        List<OverNightCustomerEN> aListForeign = null;
        string FileName;
        public frmTsk_ListForeignCustomer(List<OverNightCustomerEN> aListForeign)
        {
            InitializeComponent();
            this.aListForeign = aListForeign;
        }

        private void btnShowForeign_Click(object sender, EventArgs e)
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
            FileName = aReceptionTaskBO.ExportDBF(aListForeign);
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
           string SendEmail = CORE.CONSTANTS.ListEmails.SenderMail.ID;
           string Pass = CORE.CONSTANTS.ListEmails.SenderMail.PassWord;
           string ReceiveEmail = CORE.CONSTANTS.ListEmails.ReceiverMail1.ID;
           string subject = "Gửi thông báo tạm trú ngày :" + String.Format("{0:MM-dd-yyyy}", DateTime.Now);
           string filename = this.FileName;
           aReceptionTaskBO.SendMail(SendEmail, Pass, ReceiveEmail, subject, filename);
           MessageBox.Show("Gửi Email thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmTsk_ListForeignCustomer_Load(object sender, System.EventArgs e)
        {
            dgvCustomer.DataSource = aListForeign;
            dgvCustomer.RefreshDataSource();
        }
    }
}