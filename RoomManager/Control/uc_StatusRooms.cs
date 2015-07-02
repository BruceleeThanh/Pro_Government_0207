using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using Entity;
using BussinessLogic;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler;


namespace RoomManager
{
    public partial class uc_StatusRooms : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_StatusRooms()
        {
            InitializeComponent();
        }
        public List<RoomExtStatusEN> Datasource { set; get; }
        public DateTime CheckTime {set; get;}
        public int StatusButtonPopup = 0;
        private void Uc_ProcessImage_Load(object sender, EventArgs e)
        {
            //hiennv
            flowLayoutPanel1.AutoScroll = true;
        }

        public void DataBind()
        {
            uc_RoomStatusItem[] Item;
            Item = new uc_RoomStatusItem[Datasource.Count];
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < Datasource.Count; i++)
            {
                //---------------------------------------------
                // Process when display in past
                if (this.StatusButtonPopup == 1) // qua khu / past
                {
                    if (this.Datasource[i].RoomStatus == 0 && this.Datasource[i].CheckInActual <= CheckTime && CheckTime <= this.Datasource[i].CheckOutActual )
                    {
                        this.Datasource[i].RoomStatus = 3;
                    }
                }
                //---------------------------------------------
                Item[i] = new uc_RoomStatusItem(this.Datasource[i]);
                Item[i].Visible = true;
                Item[i].StatusButtonPopup = this.StatusButtonPopup;
                flowLayoutPanel1.Controls.Add(Item[i]);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
