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
using System.IO;

namespace RoomManager
{
    public partial class frmRpt_ListFoods : DevExpress.XtraReports.UI.XtraReport
    {
        private List<Foods> aListFoods;
        //hiennv
        public frmRpt_ListFoods(List<Foods> aListFoods)
        {
            InitializeComponent();
            this.aListFoods = aListFoods;
            try
            {
                this.DataSource = this.aListFoods;

                PicImage1.DataBindings.Add("Image", this.DataSource, "Image1");
                colName.DataBindings.Add("Text", this.DataSource, "Name");
                colName1.DataBindings.Add("Text", this.DataSource, "Name1");
                colName2.DataBindings.Add("Text", this.DataSource, "Name2");
                colName3.DataBindings.Add("Text", this.DataSource, "Name3");
                colTag.DataBindings.Add("Text", this.DataSource, "Tag");

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmRpt_ListFoods.frmRpt_ListFoods\n" + ex.ToString());
            }
        }
    }
}
