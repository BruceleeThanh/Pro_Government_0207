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

namespace SaleManagement
{
    public partial class frmIns_Permits : DevExpress.XtraEditors.XtraForm
    {
        PermitsBO aPermitsBO = new PermitsBO();
        frmLst_Permits afrmLst_Permits_Old;
        public frmIns_Permits()
        {
            InitializeComponent();
        }
        public frmIns_Permits(frmLst_Permits afrmLst_Permits)
        {
            InitializeComponent();
            afrmLst_Permits_Old = afrmLst_Permits;
        }

      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Permits aPermits = new Permits();
            aPermits.IsAdmin = cbxIsAdmin.Checked;
            aPermits.Name = txtName.Text;
            aPermits.IsContent = cbxIsContent.Checked;
            aPermits.IsPartner = cbxIsPartner.Checked;
            aPermits.Type = int.Parse(cbbType.Text);
            aPermits.Status = int.Parse(cbbStatus.Text);
            aPermits.Disable = bool.Parse(cbbDisable.Text);
            aPermitsBO.Insert(aPermits);
            MessageBox.Show("Thêm permit thành công");

            afrmLst_Permits_Old.Reload();
            this.Close();
        }
 
       
    }
}