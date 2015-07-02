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
    public partial class frmUpd_Certificates : DevExpress.XtraEditors.XtraForm
    {
        private int ID_Old;
        private frmLst_Certificates afrmLst_Certificates_Old = null;
        CertificatesBO aCertificatesBO = new CertificatesBO();
        public frmUpd_Certificates(frmLst_Certificates afrmLst_Certificates,int ID)
        {
            InitializeComponent();
            this.afrmLst_Certificates_Old = afrmLst_Certificates;
            this.ID_Old = ID;
        }

        private void frmUpd_Certificates_Load(object sender, EventArgs e)
        {
            try
            {
                Certificates aCertificates = aCertificatesBO.Select_ByID(ID_Old);
                lblID.Text = ID_Old.ToString();
                txtCertificate.Text = aCertificates.Certificate;
                txtOrganization.Text = aCertificates.Organization;
                lueCertificateTypes.Properties.DataSource = CORE.CONSTANTS.ListCertificatesTypes;
                lueCertificateTypes.Properties.DisplayMember = "Name";
                lueCertificateTypes.Properties.ValueMember = "ID";
                lueCertificateTypes.EditValue = aCertificates.Type;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Certificates_Load" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    Certificates aCertificates = new Certificates();
                    aCertificates.ID = ID_Old;
                    aCertificates.Certificate = txtCertificate.Text;
                    aCertificates.Organization = txtOrganization.Text;
                    aCertificates.Type = Convert.ToInt32(lueCertificateTypes.EditValue);
                    aCertificatesBO.Update(aCertificates);
                    if (this.afrmLst_Certificates_Old != null)
                    {
                        this.afrmLst_Certificates_Old.ReloadData();
                    }

                    MessageBox.Show("Sửa thành công !", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_Certificates.btnEdit_Click\n" + ex.ToString(), "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}