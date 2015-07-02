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
    public partial class frmUpd_RewardAndPunishments : DevExpress.XtraEditors.XtraForm
    {
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        RewardAndPunishmentsBO aRewardAndPunishmentsBO = new RewardAndPunishmentsBO();
        frmLst_RewardAndPunishments afrmLst_RewardAndPunishments_Old = null;
        int ID_Old;
        public frmUpd_RewardAndPunishments(int ID, frmLst_RewardAndPunishments afrmLst_RewardAndPunishments)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_RewardAndPunishments_Old = afrmLst_RewardAndPunishments;
        }

     

        private void frmUpd_RewardAndPunishments_Load(object sender, EventArgs e)
        {
            try
            {
                RewardAndPunishments aRewardAndPunishments = aRewardAndPunishmentsBO.Select_ByID(ID_Old);
                lblID.Text = ID_Old.ToString();
                lueIDSystemUser.Properties.DataSource = aSystemUsersBO.Select_All();
                lueIDSystemUser.Properties.DisplayMember = "Name";
                lueIDSystemUser.Properties.ValueMember = "ID";
                lueIDSystemUser.EditValue = aRewardAndPunishments.IDSystemUser;
                txtDecisionLevel.Text = aRewardAndPunishments.DecisionLevel;
                txtDescription.Text = aRewardAndPunishments.Description;
                txtNumberDecision.Text = aRewardAndPunishments.NumberDecision;
                txtSubject.Text = aRewardAndPunishments.Subject;
                dtpCreatedDate.Text = aRewardAndPunishments.CreatedDate.ToString();
                dtpDecisionDate.Text = aRewardAndPunishments.DecisionDate.ToString();
                cbbDisable.Text = aRewardAndPunishments.Disable.ToString();
                cbbStatus.Text = aRewardAndPunishments.Status.ToString();
                cbbType.Text = aRewardAndPunishments.Type.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_RewardAndPunishments_Load\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                RewardAndPunishments aRewardAndPunishments = new RewardAndPunishments();
                aRewardAndPunishments.ID = ID_Old;
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
                aRewardAndPunishmentsBO.Update(aRewardAndPunishments);
                if (this.afrmLst_RewardAndPunishments_Old != null)
                {
                    this.afrmLst_RewardAndPunishments_Old.Reload();
                }

                MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_RewardAndPunishments.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
    }
}