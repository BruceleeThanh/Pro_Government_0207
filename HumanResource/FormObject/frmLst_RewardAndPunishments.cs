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

namespace HumanResource
{
    public partial class frmLst_RewardAndPunishments : DevExpress.XtraEditors.XtraForm
    {
        RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
        public frmLst_RewardAndPunishments()
        {
            InitializeComponent();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvRewardAndPunishments.GetFocusedRowCellValue("ID").ToString());
            frmUpd_RewardAndPunishments afrmUpd_RewardAndPunishments = new frmUpd_RewardAndPunishments(ID, this);
            afrmUpd_RewardAndPunishments.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvRewardAndPunishments.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa RewardAndPunishments " + ID + " này không?", "Xóa RewardAndPunishments", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aRewardAndPunishmentsBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_RewardAndPunishments.btnDelete_ButtonClick\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_RewardAndPunishments afrmIns_RewardAndPunishments = new frmIns_RewardAndPunishments(this);
            afrmIns_RewardAndPunishments.ShowDialog();
        }

        private void frmLst_RewardAndPunishments_Load(object sender, EventArgs e)
        {
            dgvgrvRewardAndPunishments.DataSource = aRewardAndPunishmentsBO.Select_All();
        }

        public void Reload()
        {
            try
            {
                dgvgrvRewardAndPunishments.DataSource = aRewardAndPunishmentsBO.Select_All();
                dgvgrvRewardAndPunishments.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_RewardAndPunishments.Reload\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}