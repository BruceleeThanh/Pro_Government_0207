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
    public partial class frmIns_RewardAndPunishments : DevExpress.XtraEditors.XtraForm
    {
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
        frmLst_RewardAndPunishments afrmLst_RewardAndPunishments_Old = null;
        public frmIns_RewardAndPunishments()
        {
            InitializeComponent();
        }

        public frmIns_RewardAndPunishments(frmLst_RewardAndPunishments afrmLst_RewardAndPunishments)
        {
            InitializeComponent();
            afrmLst_RewardAndPunishments_Old = afrmLst_RewardAndPunishments;
        }

        private void frmIns_RewardAndPunishments_Load(object sender, EventArgs e)
        {
            lueIDSystemUser.Properties.DataSource = aSystemUsersBO.Select_All();
            lueIDSystemUser.Properties.DisplayMember = "Name";
            lueIDSystemUser.Properties.ValueMember = "ID";
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RewardAndPunishments aRewardAndPunishments = new RewardAndPunishments();
                aRewardAndPunishments.IDSystemUser = Convert.ToInt16(lueIDSystemUser.EditValue);
                aRewardAndPunishments.NumberDecision = txtNumberDecision.Text;
                aRewardAndPunishments.Subject = txtSubject.Text;
                aRewardAndPunishments.DecisionLevel = txtDecisionLevel.Text;
                aRewardAndPunishments.Description = txtDescription.Text;
                aRewardAndPunishments.CreatedDate = Convert.ToDateTime(dtpCreatedDate.Text);
                aRewardAndPunishments.DecisionDate = Convert.ToDateTime(dtpDecisionDate.Text);
                aRewardAndPunishments.Type = int.Parse(cbbType.Text);
                aRewardAndPunishments.Status = int.Parse(cbbStatus.Text);
                aRewardAndPunishments.Disable = bool.Parse(cbbDisable.Text);
                aRewardAndPunishmentsBO.Insert(aRewardAndPunishments);
                if (this.afrmLst_RewardAndPunishments_Old != null)
                {
                    this.afrmLst_RewardAndPunishments_Old.Reload();
                }

                MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_RewardAndPunishments.btnAdd_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}