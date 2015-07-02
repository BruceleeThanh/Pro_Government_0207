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
using BussinessLogic;
using DataAccess;

namespace RoomManager
{
    public partial class frmUpd_CheckPoint : DevExpress.XtraEditors.XtraForm
    {
        CheckPointBO aCheckPointBO = new CheckPointBO();
        frmLst_CheckPoint frmCheckPoint_Old =  null;
        int IDCheckPoint_Old;
        public frmUpd_CheckPoint(int IDCheckPoint, frmLst_CheckPoint frmCheckPoint)
        {
            InitializeComponent();
            frmCheckPoint_Old = frmCheckPoint;
            IDCheckPoint_Old = IDCheckPoint;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditCheckPoint_Load(object sender, EventArgs e)
        {
            try
            {
                CheckPoints aCheckPoint = aCheckPointBO.Select_ByID(IDCheckPoint_Old);
                lblID.Text = IDCheckPoint_Old.ToString();
                tetFrom.EditValue = aCheckPoint.From;
                tetTo.EditValue = aCheckPoint.To;
                int addtime = -1;
                if(aCheckPoint.AddTime == 1)
                {
                    addtime = 0;
                }
                else if(aCheckPoint.AddTime == 0.5)
                {
                    addtime = 1;
                }

                cbbAddTime.SelectedIndex = addtime;
                cbbType.SelectedIndex = aCheckPoint.Type - 1;
                cbbStatus.SelectedIndex = aCheckPoint.Status.GetValueOrDefault() - 1;
                cbbDisable.Text = Convert.ToString(aCheckPoint.Disable);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            CheckPoints aCheckPoint = new CheckPoints();
            try
            {
                aCheckPoint.ID = IDCheckPoint_Old;
                aCheckPoint.From = tetFrom.Time.TimeOfDay;
                aCheckPoint.To = tetTo.Time.TimeOfDay;

                double AddTime = 0;

                if (cbbAddTime.SelectedIndex == -1)
                {
                    AddTime = 0;
                }
                else if (cbbAddTime.SelectedIndex == 0)
                {
                    AddTime = 1;
                }
                else if (cbbAddTime.SelectedIndex == 1)
                {
                    AddTime = 0.5;
                }

                aCheckPoint.AddTime = AddTime;
                aCheckPoint.Type = cbbType.SelectedIndex + 1;
                aCheckPoint.Status = cbbStatus.SelectedIndex + 1;
                aCheckPoint.Disable = Convert.ToBoolean(cbbDisable.Text);
                aCheckPointBO.Update(aCheckPoint);

                MessageBox.Show("Sửa check point thành công");
                this.Close();
                if(this.frmCheckPoint_Old != null)
                {
                    this.frmCheckPoint_Old.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại \n" + ex.Message);
            }
        }

      
    }
}