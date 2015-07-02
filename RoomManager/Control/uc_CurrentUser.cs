using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using System.IO;

namespace RoomManager
{
    public partial class uc_CurrentUser : UserControl
    {
        public DataAccess.SystemUsers DataSource = new SystemUsers();
        public DataAccess.SystemUserExts DataSourceExtend = new SystemUserExts();

        public uc_CurrentUser()
        {
            InitializeComponent();
        }

        private void uc_CurrentUser_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            
            if (DataSource != null)
            {
                lbUsername.Text = DataSource.Username;
                lblNames.Text = DataSource.Name;
                lblPhone.Text = DataSource.Phone;

                byte[] data = (byte[])DataSource.Image;
                if (data != null)
                {
                    MemoryStream ms = new MemoryStream(data);
                    imgUser.Image = Image.FromStream(ms);
                }
                else
                {
                    Image ImageFromResource = (Image)Properties.Resources.ResourceManager.GetObject("noimage1");
                    imgUser.Image = ImageFromResource;
                }
                
            }

        }
    }
}
