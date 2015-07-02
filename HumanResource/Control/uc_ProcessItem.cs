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
    public partial class uc_ProcessItem : UserControl
    {
        public uc_ProcessItem(string Title,  Image IconActive, Image IconDisable)
        {
            InitializeComponent();
            this.Title = Title;
            this.IconActive = IconActive;
            this.IconDisable = IconDisable;
        }
        public uc_ProcessItem()
        {
            InitializeComponent();
        }
        public string Title = "";
        public Image IconDisable;
        public Image IconActive;


        private void uc_Process_Load(object sender, EventArgs e)
        {
          //  this.Visible = false;
        }
        public void Show()
        {
            lbTitle.Text = Title;
            int x = this.Width / 2 - lbTitle.Width / 2;
            int y = lbTitle.Location.Y;
            Point a = new Point(x, y);
            lbTitle.Location = a;
            this.Visible = true;
        }


        private void ovalShape1_MouseEnter(object sender, EventArgs e)
        {
            lbTitle.ForeColor = Color.White;
            ovalShape1.BackgroundImage = IconActive;
            
            ovalShape1.BorderColor = Color.DimGray;
            ovalShape1.BorderWidth = 10;
        }

        private void ovalShape1_MouseLeave(object sender, EventArgs e)
        {
            lbTitle.ForeColor = Color.DimGray;

            ovalShape1.BackgroundImage = IconDisable;
            ovalShape1.BorderColor = Color.White;
            ovalShape1.BorderWidth = 5;
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            ovalShape1.BorderColor = Color.Yellow;
            ovalShape1.BorderWidth = 5;
        }
    }
}
