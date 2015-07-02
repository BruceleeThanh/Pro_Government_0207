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

    public partial class frmLst_Certificates : DevExpress.XtraEditors.XtraForm
    {
        
        private frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation = null;
        private frmTsk_UpdateSystemUser_Infromation afrmTsk_UpdateSystemUser_Infromation = null;


        public frmLst_Certificates()
        {
            InitializeComponent();
        }

        public frmLst_Certificates(frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation)
        {
            InitializeComponent();
            this.afrmTsk_SystemUser_Infromation = afrmTsk_SystemUser_Infromation;
        }
        public frmLst_Certificates(frmTsk_UpdateSystemUser_Infromation afrmTsk_UpdateSystemUser_Infromation)
        {
            InitializeComponent();
            this.afrmTsk_UpdateSystemUser_Infromation = afrmTsk_UpdateSystemUser_Infromation;
        }

        private void frmLst_Certificates_Load(object sender, EventArgs e)
        {
            if (afrmTsk_SystemUser_Infromation == null && afrmTsk_UpdateSystemUser_Infromation == null)
            {
                gridColumn10.Visible = false;
            }
            ReloadData();
        }
        public void ReloadData()
        {
            try
            {
                CertificatesBO aCertificatesBO = new CertificatesBO();
                dgvCertificates.DataSource = aCertificatesBO.Select_All();
                dgvCertificates.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Certificates.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmIns_Certificates afrmIns_Certificates = new frmIns_Certificates(this);
            afrmIns_Certificates.ShowDialog();
        }

        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = int.Parse(grvCertificates.GetFocusedRowCellValue("ID").ToString());
            frmUpd_Certificates afrmUpd_Certificates = new frmUpd_Certificates(this,ID);
            afrmUpd_Certificates.ShowDialog();
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID = int.Parse(grvCertificates.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa Certificates " + ID + " này không?", "Xóa Certificates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CertificatesBO aCertificatesBO = new CertificatesBO();
                    aCertificatesBO.Delete(ID);
                    MessageBox.Show("Xóa thành công");
                    this.ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Certificates.btnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFill_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(this.afrmTsk_SystemUser_Infromation !=null)
                {
                    this.afrmTsk_SystemUser_Infromation.ReloadCertificate();
                    int ID = Convert.ToInt32(grvCertificates.GetFocusedRowCellValue("ID"));
                    this.afrmTsk_SystemUser_Infromation.CallBackCertificate(ID);
                    this.Close();
                }
                else if(this.afrmTsk_UpdateSystemUser_Infromation !=null)
                {
                    this.afrmTsk_UpdateSystemUser_Infromation.LoadCertificate();
                    int ID = Convert.ToInt32(grvCertificates.GetFocusedRowCellValue("ID"));
                    this.afrmTsk_UpdateSystemUser_Infromation.SetFocusCertificate(ID);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Certificates.btnFill_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}