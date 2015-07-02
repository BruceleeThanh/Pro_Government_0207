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
using CORESYSTEM;
using Library;
using Entity;
using DataAccess;
using BussinessLogic;

namespace RoomManager
{
    public partial class frmLst_ExtraCostRooms : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_ExtraCostRooms()
        {
            InitializeComponent();
        }

        //Hiennv
        public void LoadExtraCostRooms()
        {
            try
            {
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                dgvExtraCostRooms.DataSource = aExtraCostBO.Select_All();
                dgvExtraCostRooms.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_ExtraCostRooms.LoadExtraCostRooms\n" + ex.ToString(),"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void frmLst_ExtraCostRooms_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadExtraCostRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_ExtraCostRooms.frmLst_ExtraCostRooms_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnAddExtraCost_Click(object sender, EventArgs e)
        {
            try
            {
                frmIns_ExtraCostRooms afrmIns_ExtraCostRooms = new frmIns_ExtraCostRooms(this);
                afrmIns_ExtraCostRooms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_ExtraCostRooms.btnAddExtraCost_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnEditExtraCostRooms_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewExtraCostRooms.GetFocusedRowCellValue("ID"));             

                frmUpd_ExtraCostRooms afrmUpd_ExtraCostRooms = new frmUpd_ExtraCostRooms(this, ID);
                afrmUpd_ExtraCostRooms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_ExtraCostRooms.btnEditExtraCostRooms_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int ID = Convert.ToInt32(viewExtraCostRooms.GetFocusedRowCellValue("ID"));
                    aExtraCostBO.Delete(ID);
                    this.LoadExtraCostRooms();
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_ExtraCostRooms.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}