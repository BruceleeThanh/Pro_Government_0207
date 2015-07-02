using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace RoomManager
{
    public partial class frmTsk_SendReport : Form
    {
        public frmTsk_SendReport()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ProcessDBF aProcessDBF = new ProcessDBF();
            DataTable aDataTable = new DataTable();
            aDataTable = aProcessDBF.ImportDBF(openFileDialog1.FileName);
            gridControl1.DataSource = aDataTable;
        }
    }
}
