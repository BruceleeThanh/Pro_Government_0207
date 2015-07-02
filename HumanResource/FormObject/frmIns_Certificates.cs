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
using CORESYSTEM;


namespace HumanResource
{
    public partial class frmIns_Certificates : DevExpress.XtraEditors.XtraForm
    {
        frmLst_Certificates afrmLst_Certificates_Old =null;
        private frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation = null;
        private frmTsk_UpdateSystemUser_Infromation afrmTsk_UpdateSystemUser_Infromation = null;
        CertificatesBO aCertificatesBO = new CertificatesBO();
        public frmIns_Certificates()
        {
            InitializeComponent();
        }

        public frmIns_Certificates(frmLst_Certificates afrmLst_Certificates)
        {
            InitializeComponent();
            afrmLst_Certificates_Old = afrmLst_Certificates;
        }

        public frmIns_Certificates(frmTsk_InsertSystemUser_Infromation afrmTsk_SystemUser_Infromation)
        {
            InitializeComponent();
            this.afrmTsk_SystemUser_Infromation = afrmTsk_SystemUser_Infromation;
        }
        public frmIns_Certificates(frmTsk_UpdateSystemUser_Infromation afrmTsk_UpdateSystemUser_Infromation)
        {
            InitializeComponent();
            this.afrmTsk_UpdateSystemUser_Infromation = afrmTsk_UpdateSystemUser_Infromation;
        }

        private bool ValidateData()
        {
            if (txtCertificate.Text == "")
            {
                MessageBox.Show("Nhập chuyên ngành trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtCertificate.Text == "")
            {
                MessageBox.Show("Nhập nơi cấp trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    Certificates aCertificates = new Certificates();
                    aCertificates.Certificate = txtCertificate.Text;
                    aCertificates.Organization = txtOrganization.Text;
                    aCertificates.Type = Convert.ToInt32(lueCertificateTypes.EditValue);
                    int ID = aCertificatesBO.Insert(aCertificates);

                    if (this.afrmLst_Certificates_Old != null)
                    {
                        afrmLst_Certificates_Old.ReloadData();
                    }
                    else if (this.afrmTsk_SystemUser_Infromation != null)
                    {
                        this.afrmTsk_SystemUser_Infromation.ReloadCertificate();
                        this.afrmTsk_SystemUser_Infromation.CallBackCertificate(ID);
                    }
                    else if (this.afrmTsk_UpdateSystemUser_Infromation != null)
                    {
                        this.afrmTsk_UpdateSystemUser_Infromation.LoadCertificate();
                        this.afrmTsk_UpdateSystemUser_Infromation.SetFocusCertificate(ID);

                    }

                    MessageBox.Show("Thêm mới thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Certificates.btnAddNew_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmIns_Certificates_Load(object sender, EventArgs e)
        {
            lueCertificateTypes.Properties.DataSource = CORE.CONSTANTS.ListCertificatesTypes;
            lueCertificateTypes.Properties.DisplayMember = "Name";
            lueCertificateTypes.Properties.ValueMember = "ID";
            lueCertificateTypes.EditValue = CORE.CONSTANTS.SelectedCertificateTypes(1).ID;
        }
    }
}