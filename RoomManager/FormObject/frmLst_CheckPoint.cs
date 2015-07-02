using System;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraRichEdit.API.Word;
using DataAccess;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace RoomManager
{
    public partial class frmLst_CheckPoint : DevExpress.XtraEditors.XtraForm
    {
        int IDCheckPoint;
        public frmLst_CheckPoint()
        {
            InitializeComponent();
        }

        //=======================================================
        //Author: LinhTN
        //Function : Load Check Point
        //=======================================================
        private void frmCheckPoint_Load(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        //=======================================================
        //Author: LinhTN
        //Function : Load Check Point
        //=======================================================
        public void ReloadData()
        {
            CheckPointBO aCheckPointBO = new CheckPointBO();
            List<CheckPoints> aListTemp = aCheckPointBO.Select_All();
            List<CheckPointEN> aListCheckPoints = new List<CheckPointEN>();
            CheckPointEN aCheckPointEN;
            for (int i = 0; i < aListTemp.Count; i++)
            {
                aCheckPointEN = new CheckPointEN();
                aCheckPointEN.SetValue(aListTemp[i]);
                if (aCheckPointEN.Type == 1)
                {
                    aCheckPointEN.TypeDisplay = "Check In Sớm";
                }
                else
                {
                    aCheckPointEN.TypeDisplay = "Check Out Muộn";
                }
                aListCheckPoints.Add(aCheckPointEN);
            }

            dgvCheckPoint.DataSource = aListCheckPoints;
            dgvCheckPoint.RefreshDataSource();
        }

        //=======================================================
        //Author: LinhTN
        //Function : Xoa Check Point
        //=======================================================
        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CheckPointBO aCheckPointBO = new CheckPointBO();
            IDCheckPoint = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            DialogResult result = MessageBox.Show("Bạn có muốn xóa check point " + IDCheckPoint.ToString() + " này không?", "Xóa check point", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                aCheckPointBO.Delete_ByID(IDCheckPoint);
                MessageBox.Show("Xóa thành công");
                ReloadData();
            }
        }

        private void btnAddCheckPoint_Click(object sender, EventArgs e)
        {
            frmIns_CheckPoint afrmAddCheckPoint = new frmIns_CheckPoint(this);
            afrmAddCheckPoint.ShowDialog();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
             IDCheckPoint = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
             frmUpd_CheckPoint afrmEditCheckPoint = new frmUpd_CheckPoint(IDCheckPoint, this);
             afrmEditCheckPoint.ShowDialog();
        }

    }
}