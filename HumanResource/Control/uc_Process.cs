using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource
{
    public partial class uc_Process : UserControl
    {
        public uc_Process()
        {
            InitializeComponent();
        }

        private void uc_Process_Load(object sender, EventArgs e)
        {
            Step1.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("Booking2");
            Step1.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("Booking1");
            Step1.Title = "1.ĐẶT PHÒNG";
            Step1.Show();


            Step2.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("CheckIn2");
            Step2.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("CheckIn1");
            Step2.Title = "2.CHECKIN";
            Step2.Show();

            Step3.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("Service2");
            Step3.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("Service1");
            Step3.Title = "3.DÙNG DỊCH VỤ";
            Step3.Show();

            Step4.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("Lock2");
            Step4.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("Lock1");
            Step4.Title = "4.KHÓA PHÒNG";
            Step4.Show();

            Step5.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("CheckOut2");
            Step5.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("CheckOut1");
            Step5.Title = "5.CHECKOUT";
            Step5.Show();

            Step6.IconActive = (Image)Properties.Resources.ResourceManager.GetObject("Pay2");
            Step6.IconDisable = (Image)Properties.Resources.ResourceManager.GetObject("Pay1");
            Step6.Title = "6.THANH TOÁN";
            Step6.Show();

            this.Dock = DockStyle.Fill;

        }
    }
}
