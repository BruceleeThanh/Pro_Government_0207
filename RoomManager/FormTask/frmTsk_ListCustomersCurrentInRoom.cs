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
using DataAccess;
using Entity;
using BussinessLogic;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmTsk_ListCustomersCurrentInRoom : DevExpress.XtraEditors.XtraForm
    {
        public frmTsk_ListCustomersCurrentInRoom()
        {
            InitializeComponent();
        }

        private void frmTsk_ListCustomersCurrentInRoom_Load(object sender, EventArgs e)
        {
            dtpCreateDate.DateTime = DateTime.Now.AddDays(-60);
            this.LoadData(DateTime.Now.AddDays(-30));
        }

        //Hiennv
        public void LoadData(DateTime createDate)
        {
            try
            {
                List<CustomerEN> aListCustomersCurrentInRooms = new List<CustomerEN>();
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                List<CustomerEN> aListCustomerEN = aReceptionTaskBO.GetListCustomersCurrentInRooms_ByCreateDateBookingR(createDate);
                CustomerEN aCustomerEN;
                foreach (CustomerEN items in aListCustomerEN)
                {
                    aCustomerEN = new CustomerEN();
                    aCustomerEN.SetValue(items);
                    if (String.IsNullOrEmpty(items.Gender) == false)
                    {
                        aCustomerEN.GenderDisplay = CORE.CONSTANTS.SelectedGender(Convert.ToInt32(items.Gender)).Name;
                    }
                    if (String.IsNullOrEmpty(items.Nationality) == false)
                    {
                        aCustomerEN.NationalityDisplay = CORE.CONSTANTS.SelectedCountry(Convert.ToString(items.Nationality)).Name;
                    }
                    if (items.Citizen != null)
                    {
                        aCustomerEN.CitizenDisplay = CORE.CONSTANTS.SelectedCitizen(Convert.ToInt32(items.Citizen)).Name;
                    }
                    aCustomerEN.IDCompany = items.IDCompany;
                    aCustomerEN.NameCompany = items.NameCompany;
                    aCustomerEN.IDGroup = items.IDGroup;
                    aCustomerEN.NameGroup = items.NameGroup;
                    aCustomerEN.CodeRoom = items.CodeRoom;
                    aCustomerEN.SkuRoom = items.SkuRoom;
                    aListCustomersCurrentInRooms.Add(aCustomerEN);
                }
                dgvCustomers.DataSource = aListCustomersCurrentInRooms;
                dgvCustomers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ListCustomersCurrentInRoom.LoadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadData(dtpCreateDate.DateTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmTsk_ListCustomersCurrentInRoom.btnSearch_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}