using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;

namespace HumanResource
{
    public partial class uc_SystemUsers_Certificates : UserControl
    {
        SystemUsers_CertificatesBO aSystemUsers_CertificatesBO = new SystemUsers_CertificatesBO();
        CertificatesBO aCertificatesBO = new CertificatesBO();
        SystemUsersBO aSystemUsersBO = new SystemUsersBO();
        int IDSystemUser_Old;
        public uc_SystemUsers_Certificates(int IDSystemUser)
        {
            InitializeComponent();
            IDSystemUser_Old = IDSystemUser;
        }
        public uc_SystemUsers_Certificates()
        {
            InitializeComponent();

        }
        private void uc_SystemUsers_Certificates_Load(object sender, EventArgs e)
        {
            lueCertificateType.Properties.DataSource = aCertificatesBO.Select_All();
            lueCertificateType.Properties.DisplayMember = "Certificate";
            lueCertificateType.Properties.ValueMember = "ID";
            SystemUsers aSystemUsers = new SystemUsers();
            aSystemUsers = aSystemUsersBO.Select_ByID(IDSystemUser_Old);
            lblSystemUser.Text = aSystemUsers.Name;
            dgvSystemUsers_Certificates.DataSource = aSystemUsers_CertificatesBO.GetCertificateInfo(IDSystemUser_Old);

        }
        public void Reload()
        {
            dgvSystemUsers_Certificates.DataSource = aSystemUsers_CertificatesBO.GetCertificateInfo(IDSystemUser_Old);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.IDSystemUser_Old != null )
            {
                Insert(this.IDSystemUser_Old);
            }

            
        }
        public int Insert(int IDSystemUser)
        {
            this.IDSystemUser_Old = IDSystemUser;
            SystemUsers_Certificates aSystemUsers_Certificates = new SystemUsers_Certificates();
            aSystemUsers_Certificates.IDCertificate = Convert.ToInt32(lueCertificateType.EditValue);
            aSystemUsers_Certificates.IDSystemUser = IDSystemUser_Old;
            aSystemUsers_Certificates.Level = cbbLevel.Text;
            aSystemUsers_Certificates.ExpirationDate = dtpExpirationDate.Value;
            aSystemUsers_Certificates.CreatedDate = dtpCreatedDate.Value;
            aSystemUsers_Certificates.Organization = txtOrganization.Text;
            return aSystemUsers_CertificatesBO.Insert(aSystemUsers_Certificates);
        }
    }
}
