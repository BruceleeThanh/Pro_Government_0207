using System;
using System.Windows.Forms;
using BussinessLogic;
using System.Collections.Generic;
using DataAccess;

namespace RoomManager
{
    public partial class frmLst_Rooms : DevExpress.XtraEditors.XtraForm
    {
        public frmMain afrmMain = null;
        public frmLst_Rooms(frmMain afrmMain)
        {
            InitializeComponent();
            this.afrmMain = afrmMain;
        }
        //=======================================================
        //Author: LinhTN
        //Function : Load Rooms
        //=======================================================
        private void frmRooms_Load(object sender, EventArgs e)
        {
            this.ReloadData();
        }
        //=======================================================
        //Author: LinhTN
        //Function : Add Rooms
        //=======================================================
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            frmIns_Rooms afrmAddRooms = new frmIns_Rooms(this);
            afrmAddRooms.ShowDialog();
        }
        //=======================================================
        //Author: LinhTN
        //Function : ReLoad Rooms
        //=======================================================
        public void ReloadData()
        {
            RoomsBO aRoomsBO = new RoomsBO();
            dgvRooms.DataSource = aRoomsBO.Select_ByIDLang(1);
            dgvRooms.RefreshDataSource();

        }

        private void btnEditRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int IDRoom = Convert.ToInt32(viewRooms.GetFocusedRowCellValue("ID"));
            frmUpd_Rooms afrmUpd_Rooms = new frmUpd_Rooms(IDRoom, this);
            afrmUpd_Rooms.Show();
        }

        //=======================================================
        //Author: LinhTN
        //Function : Xóa Rooms bằng Code       
        //=======================================================

        private void btnDeleteRoom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();
                string Code = viewRooms.GetFocusedRowCellValue("Code").ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa phòng " + Code + " này không?", "Xóa phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aRoomsBO.Delete_ByCode(Code);
                    MessageBox.Show("Xóa thành công");
                    this.ReloadData();
                    if (this.afrmMain != null)
                    {
                        this.afrmMain.ReloadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Rooms.btnDeleteRoom_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void chkDisable_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(viewRooms.GetFocusedRowCellValue("ID"));
                bool disableOld = Convert.ToBoolean(viewRooms.GetFocusedRowCellValue("Disable"));

                bool disalbeNew = false;
                string disable = string.Empty;
                if (disableOld == false)
                {
                    disalbeNew = true;
                    disable = "Khóa";
                }
                else
                {
                    disalbeNew = false;
                    disable = "Mở";
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn " + disable + " phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    RoomsBO aRoomsBO = new RoomsBO();
                    Rooms aRooms = aRoomsBO.Select_ByID(ID);
                    if (aRooms != null)
                    {
                        aRooms.Disable = disalbeNew;
                        int count = aRoomsBO.Update(aRooms);
                        if (count > 0)
                        {
                            this.ReloadData();
                            if (this.afrmMain != null)
                            {
                                this.afrmMain.ReloadData();
                            }
                            MessageBox.Show("Thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Rooms.chkDisable_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnListExtraCostRooms_Click(object sender, EventArgs e)
        {
            try
            {
                frmLst_ExtraCostRooms afrmLst_ExtraCostRooms = new frmLst_ExtraCostRooms();
                afrmLst_ExtraCostRooms.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Rooms.btnListExtraCostRooms_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}