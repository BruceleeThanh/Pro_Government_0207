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
using DevExpress.Utils;

namespace HumanResource
{
    public partial class frmLst_SystemUsers_Divisions : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_SystemUsers_Divisions()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            try
            {
                SystemUsers_DivisionsBO aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                colSystemUsers_Birthday.DisplayFormat.FormatType = FormatType.DateTime;
                colSystemUsers_Birthday.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatType = FormatType.DateTime;
                colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatType = FormatType.DateTime;
                colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";

                dgvSystemUsers_Divisions.DataSource = aSystemUsers_DivisionsBO.Select_BySystemUsersDivisions_Disable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers_Divisions.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLst_SystemUsers_Divisions_Load(object sender, EventArgs e)
        {
            try
            {
                dtpChooseDate.DateTime = DateTime.Now;
                DivisionsBO aDivisonsBO = new DivisionsBO();
                List<Divisions> aListDivisions = aDivisonsBO.Select_All();
                cboDivisions.Properties.Items.Add("Tất cả");
                foreach(Divisions aDivisions in aListDivisions)
                {
                    cboDivisions.Properties.Items.Add(aDivisions.Name);
                }
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers_Divisions.frmLst_SystemUsers_Divisions_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmTsk_ChooseSystemUsersToDivisions afrmIns_SystemUsers_Divisions = new frmTsk_ChooseSystemUsersToDivisions(this);
                afrmIns_SystemUsers_Divisions.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers_Divisions.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(viewSystemUsers_Divisions.GetFocusedRowCellValue("SystemUsers_Divisions_ID"));
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện ???", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                try
                {
                    SystemUsers_DivisionsBO aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                    SystemUsers_Divisions aSystemUsers_Divisions = aSystemUsers_DivisionsBO.Select_ByID(ID);
                    aSystemUsers_Divisions.Disable = true;
                    SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                    SystemUsers aSystemUsers = aSystemUsersBO.Select_ByID(aSystemUsers_Divisions.IDSystemUser);
                    aSystemUsers.Disable = false;
                    aSystemUsers_DivisionsBO.Update(aSystemUsers_Divisions);
                    aSystemUsersBO.Update(aSystemUsers);

                    MessageBox.Show("Bạn đã thực hiện thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("frmLst_SystemUsers_Divisions.btnDisable_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ReloadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string NameDivision = cboDivisions.Text;
                DateTime ChooseDate = dtpChooseDate.DateTime;

                if (NameDivision == "Tất cả")
                {
                    ReloadData();
                }
                else
                {
                    SystemUsers_DivisionsBO aSystemUsers_DivisionsBO = new SystemUsers_DivisionsBO();
                    colSystemUsers_Birthday.DisplayFormat.FormatType = FormatType.DateTime;
                    colSystemUsers_Birthday.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                    colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatType = FormatType.DateTime;
                    colSystemUsers_Divisions_AvaiableDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                    colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatType = FormatType.DateTime;
                    colSystemUsers_Divisions_ExpireDate.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
                    dgvSystemUsers_Divisions.DataSource = aSystemUsers_DivisionsBO.Select_ByIDDivisionAndDate(NameDivision, ChooseDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_SystemUsers_Divisions.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}