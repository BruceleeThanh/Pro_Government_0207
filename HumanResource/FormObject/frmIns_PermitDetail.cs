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
    public partial class frmIns_PermitDetail : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        PermitDetailsBO aPermitDetailsBO = new PermitDetailsBO();
        frmLst_PermitDetails afrmLst_PermitDetails_Old =null;

        public frmIns_PermitDetail()
        {
            InitializeComponent();
        }

        public frmIns_PermitDetail(frmLst_PermitDetails afrmLst_PermitDetails)
        {
            InitializeComponent();
            this.afrmLst_PermitDetails_Old = afrmLst_PermitDetails;
        }

        private bool ValidateData()
        {
            if (lueIDPermit.EditValue == null)
            {
                MessageBox.Show("Chọn quyền trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên quyền hạn trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    PermitDetails aPermitDetails = new PermitDetails();
                    aPermitDetails.IDPermit = Convert.ToInt32(lueIDPermit.EditValue);
                    aPermitDetails.Name = txtName.Text;
                    aPermitDetails.PageURL = txtPageURL.Text;
                    aPermitDetails.Status = int.Parse(cbbStatus.Text);
                    aPermitDetails.Type = int.Parse(cbbType.Text);
                    aPermitDetails.Disable = bool.Parse(cbbDisable.Text);
                    aPermitDetailsBO.Insert(aPermitDetails);
                    if (this.afrmLst_PermitDetails_Old != null)
                    {
                        this.afrmLst_PermitDetails_Old.Reload();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_PermitDetail.btnAdd_Click\n"+ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void frmIns_PermitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                PermitsBO aPermitsBO = new PermitsBO();
                List<Permits> aListPermits = aPermitsBO.Select_All();
                lueIDPermit.Properties.DataSource = aListPermits;
                lueIDPermit.Properties.DisplayMember = "Name";
                lueIDPermit.Properties.ValueMember = "ID";
                if (aListPermits.Count > 0)
                {
                    lueIDPermit.EditValue = aListPermits[0].ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_PermitDetail.frmIns_PermitDetail_Load\n" +ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}