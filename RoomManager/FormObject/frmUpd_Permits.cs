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
    public partial class frmUpd_Permits : DevExpress.XtraEditors.XtraForm
    {
        PermitsBO aPermitsBO = new PermitsBO();
        private frmLst_Permits afrmLst_Permits_Old;
        int ID_Old;
        public frmUpd_Permits(int ID, frmLst_Permits afrmLst_Permits)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_Permits_Old = afrmLst_Permits;
        }

       

        private void frmUpd_Permits_Load(object sender, EventArgs e)
        {
            try
            {
                Permits aPermits = aPermitsBO.Select_ByID(ID_Old);
                lblID.Text = aPermits.ID.ToString();
                cbxIsAdmin.Checked = true;
                aPermits.IsAdmin = (bool?)cbxIsAdmin.Checked;
                txtName.Text = aPermits.Name;
                cbxIsPartner.Checked = true;
                aPermits.IsPartner = (bool?)cbxIsPartner.Checked;
                cbbType.Text = aPermits.Type.ToString();
                cbbStatus.Text = aPermits.Status.ToString();
                cbbDisable.Text = aPermits.Disable.ToString();
                cbxIsContent.Checked = true;
                aPermits.IsContent = (bool?)cbxIsContent.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Permits aPermits = new Permits();
                aPermits.ID = ID_Old;
                aPermits.IsAdmin = cbxIsAdmin.Checked;
                aPermits.Name = txtName.Text;
                aPermits.IsContent = cbxIsContent.Checked;
                aPermits.IsPartner = cbxIsPartner.Checked;
                aPermits.Type = int.Parse(cbbType.Text);
                aPermits.Status = int.Parse(cbbStatus.Text);
                aPermits.Disable = bool.Parse(cbbDisable.Text);
                aPermitsBO.Update(aPermits);
                MessageBox.Show("Sửa permit thành công");
                afrmLst_Permits_Old.Reload();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}