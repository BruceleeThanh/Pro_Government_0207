using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using DevExpress.XtraEditors.Controls;

namespace RoomManager
{
    public partial class frmIns_Services : DevExpress.XtraEditors.XtraForm
    {
        #region Room
        private frmLst_Services afrmLst_Services = null;
        private frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New = null;
        private frmTsk_UseServices afrmTsk_UseServices = null;

        public frmIns_Services()
        {
            InitializeComponent();
        }
        public frmIns_Services(frmLst_Services afrmLst_Services)
        {
            InitializeComponent();
            this.afrmLst_Services = afrmLst_Services;
        }
        public frmIns_Services(frmTsk_BookingHall_Customer_New afrmTsk_BookingHall_Customer_New)
        {
            InitializeComponent();
            this.afrmTsk_BookingHall_Customer_New = afrmTsk_BookingHall_Customer_New;
        }
        public frmIns_Services(frmTsk_UseServices afrmTsk_UseServices)
        {
            InitializeComponent();
            this.afrmTsk_UseServices = afrmTsk_UseServices;
        }
        public void ReloadData()
        {
            try
            {
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                List<ServiceGroups> aListServiceGroups = aServiceGroupsBO.Sel_all();
                lueIDServiceGroup.Properties.DataSource = aListServiceGroups;
                lueIDServiceGroup.Properties.DisplayMember = "Name";
                lueIDServiceGroup.Properties.ValueMember = "ID";
                if (aListServiceGroups.Count > 0)
                {
                    lueIDServiceGroup.EditValue = aListServiceGroups[0].ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddServices_Load(object sender, EventArgs e)
        {
            ReloadData();

        }

        //hiennv
        private bool CheckData()
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Nhập tên dịch vụ trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtCost.Text == "")
                {
                    MessageBox.Show("Nhập giá dịch vụ trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (txtUnit.Text == "")
                {
                    MessageBox.Show("Nhập đơn vị tính trước khi thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }           
                if (lueIDServiceGroup.EditValue == null)
                {
                    lueIDServiceGroup.Focus();
                    MessageBox.Show("Vui lòng chọn nhóm dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.CheckData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.CheckData()==true)
                {
                    ServicesBO aServiceBO = new ServicesBO();
                    Services aService = new Services();
                    aService.Name = txtName.Text;
                    aService.CostRef = string.IsNullOrEmpty(txtCost.Text) == true ? 0 : Convert.ToDecimal(txtCost.Text);
                    aService.Unit = txtUnit.Text;
                    aService.Status = 1;
                    aService.Type = cboType.SelectedIndex + 1;
                    aService.Disable = false;
                    aService.IDServiceGroups = Convert.ToInt32(lueIDServiceGroup.EditValue);

                    aServiceBO.Insert(aService);

                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.afrmLst_Services != null)
                    {
                        this.afrmLst_Services.ReloadData();
                    }
                    if (this.afrmTsk_BookingHall_Customer_New != null)
                    {
                        this.afrmTsk_BookingHall_Customer_New.CallBackService(aService);
                    }
                    if (this.afrmTsk_UseServices != null)
                    {
                        this.afrmTsk_UseServices.Reload();
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_Services.bnAdd_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnAddSerGroup_Click(object sender, EventArgs e)
        {
            frmIns_ServiceGroups afrmIns_ServiceGroups = new frmIns_ServiceGroups(this);
            afrmIns_ServiceGroups.ShowDialog();
        }
        #endregion
        #region Sale
        private frmIns_BookingHalls_Services afrmIns_BookingHalls_Services = null;
        public frmIns_Services(frmIns_BookingHalls_Services afrmIns_BookingHalls_Services)
        {
            InitializeComponent();
            this.afrmIns_BookingHalls_Services = afrmIns_BookingHalls_Services;
        }
        #endregion

    }
}