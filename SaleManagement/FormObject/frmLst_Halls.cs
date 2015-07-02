using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DataAccess;
using Entity;
using CORESYSTEM;

namespace SaleManagement
{
    public partial class frmLst_Halls : DevExpress.XtraEditors.XtraForm
    {
        //private HallsBO aHallsBO = new HallsBO();
        public frmLst_Halls()
        {
            InitializeComponent();
        }
        //private ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void frmLst_Halls_Load(object sender, EventArgs e)
        {
            try
            {
                this.ReloadData();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("frmLst_Halls_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void ReloadData()
        {
            try
            {
                HallsBO aHallsBO = new HallsBO();
                List<Halls> aListHalls = aHallsBO.Select_All();
                List<HallsEN> aListHallEN = new List<HallsEN> ();
                HallsEN aHallEN;
                 for (int i = 0; i < aListHalls.Count; i++)
                    {
                        aHallEN = new HallsEN();
                        aHallEN.SetValue(aListHalls[i]);
                        aHallEN.TypeDisplay = CORE.CONSTANTS.SelectedHallType(Convert.ToInt32(aListHalls[i].Type)).Name;
                        aListHallEN.Add(aHallEN);
                    }

                 dgvHalls.DataSource = aListHallEN;
                dgvHalls.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Halls.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rebeEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDHall = Convert.ToInt32(grvHall.GetFocusedRowCellValue("ID"));
                frmUpd_Halls afrmUpd_Halls = new frmUpd_Halls(this,IDHall);
                afrmUpd_Halls.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Halls.rebeEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            HallsBO aHallsBO = new HallsBO();
            int IDHall = Convert.ToInt32(grvHall.GetFocusedRowCellValue("ID"));
            string Name = grvHall.GetFocusedRowCellValue("Sku").ToString();
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hội trường " + Name + " này không?", "Xóa hội trường", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aHallsBO.Delete(IDHall);
                MessageBox.Show("Xóa thành công");
                this.ReloadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Halls afrmIns_Halls = new frmIns_Halls(this);
            afrmIns_Halls.ShowDialog();
        }

        private void btnDelete_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

      
    }
}