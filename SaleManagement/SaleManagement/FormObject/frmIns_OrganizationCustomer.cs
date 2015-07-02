using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;

namespace SaleManagement
{
    public partial class frmIns_OrganizationCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmIns_OrganizationCustomer()
        {
            InitializeComponent();
        }

        private CustomersBO _CustomersBO = new CustomersBO();
        //private readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int CompanyID { get; set; }
        public int GroupID { get; set; }
        public int Type { get; set; }

        private void sbCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ValidCondition())
                //{
                //    var message = _CustomersBO.CreateNewGuest(_fullname, _datebirth, _idcode, _phone, _address, _email,Type);
                //    XtraMessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    _CustomersBO.CreateCustomerGroupCustomer(GroupID, _CustomersBO.GetLastCustomerId(), "Mapping -" + _fullname);
                //    DialogResult = DialogResult.OK;

                //}

            }
            catch (Exception ex)
            {

               // Logger.Error(ex);
            }
        }

        private string _fullname;
        private string _idcode;
        private string _phone;
        private string _email;
        private DateTime _datebirth;
        private string _address;
        private bool ValidCondition()
        {
            try
            {
                if (teFullName.EditValue == null)
                {
                    XtraMessageBox.Show("Tên không được bỏ trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return false;
                }

                if (teIDCode.EditValue == null)
                {
                    XtraMessageBox.Show("CMDN/ Hộ chiếu không được bỏ trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                    return false;
                }

                _fullname = teFullName.EditValue.ToString();
                _idcode = teIDCode.EditValue.ToString();
                _address = teAdress.EditValue == null ? null : teAdress.EditValue.ToString();
                _phone = teMobile.EditValue == null ? null : teMobile.EditValue.ToString();
                _datebirth = teBirthDate.EditValue == null ? new DateTime() : teBirthDate.DateTime;
                _email = teEmail1.EditValue == null ? null : teEmail1.EditValue.ToString();


            }
            catch (Exception ex)
            {
                //Logger.Error(ex);
                return false;
            }
            return true;
        }

        private void CreateOrganizationCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}