using System;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

namespace RoomManager
{
    public partial class frmIns_CheckPoint : DevExpress.XtraEditors.XtraForm
    {
        CheckPointBO aCheckPointBO = new CheckPointBO();
        frmLst_CheckPoint frmCheckPoint_Old = null;

        public frmIns_CheckPoint()
        {
            InitializeComponent();
        }

        public frmIns_CheckPoint(frmLst_CheckPoint frmCheckPoint)
        {
            InitializeComponent();
            frmCheckPoint_Old = frmCheckPoint;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckPoints aCheckPoint = new CheckPoints();

            try
            {
                aCheckPoint.From = tetFrom.Time.TimeOfDay;
                aCheckPoint.To = tetTo.Time.TimeOfDay;

                double AddTime = 0;
                
                if(cbbAddTime.SelectedIndex == -1)
                {
                    AddTime = 0;
                }
                else if (cbbAddTime.SelectedIndex == 0)
                {
                    AddTime = 1;
                }
                else if (cbbAddTime.SelectedIndex == 1 )
                {
                    AddTime = 0.5;
                }

                aCheckPoint.AddTime = AddTime;
                aCheckPoint.Type = cbbType.SelectedIndex + 1;
                aCheckPoint.Status = cbbStatus.SelectedIndex + 1;
                aCheckPoint.Disable = Convert.ToBoolean(cbbDisable.Text);
                aCheckPointBO.Insert(aCheckPoint);

                MessageBox.Show("Thêm check point thành công");
                this.Close();
                if(this.frmCheckPoint_Old != null)
                {
                    this.frmCheckPoint_Old.ReloadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_CheckPoint.btnAdd_Click \n" + ex.Message);
            }
        }
   
    }
}