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
    public partial class frmTsk_GetCheckOutTime : Form
    {
        DateTime CheckInActual;
        int IDBookingRooms;
        public frmTsk_GetCheckOutTime(DateTime CheckInActual, int IDBookingRooms)
        {
            InitializeComponent();
            this.CheckInActual = CheckInActual;
            this.IDBookingRooms = IDBookingRooms;
        }

        private void frmTsk_GetCheckOutTime_Load(object sender, EventArgs e)
        {
            dtpCheckOutActual.DateTime = DateTime.Now;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckInActual >= dtpCheckOutActual.DateTime)
            {
                MessageBox.Show("Giờ checkout phải sau giờ checkin thực tế");
            }
            else
            {
                MessageBox.Show("OK");
            }
        }
    }
}
