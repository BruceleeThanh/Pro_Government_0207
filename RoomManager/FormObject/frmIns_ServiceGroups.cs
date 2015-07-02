using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmIns_ServiceGroups : DevExpress.XtraEditors.XtraForm
    {
        frmIns_Services afrmIns_Services = null;
        public frmIns_ServiceGroups()
        {
            InitializeComponent();
        }
        public frmIns_ServiceGroups(frmIns_Services afrmIns_Services)
        {
            InitializeComponent();
            this.afrmIns_Services = afrmIns_Services;
        }
        private void bnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {                    
                    ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                    ServiceGroups aServiceGroups = new ServiceGroups();
                    aServiceGroups.Name = txtName.Text;
                    aServiceGroups.Type = Convert.ToInt32(lueType.EditValue);

                    aServiceGroups.Disable = bool.Parse(cbxDisable.SelectedItem.ToString());

                    int ret = aServiceGroupsBO.Insert(aServiceGroups);
                    if (ret == 1)
                    {
                        lblID.Text = "";
                        txtName.Text = "";
                        lueType.EditValue = 0;
                        cbxDisable.SelectedIndex = 0;
                        MessageBox.Show("Thêm mới thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.ReloadData();
                        if (afrmIns_Services != null)
                        {
                            this.afrmIns_Services.ReloadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thất mới nhóm dịch vụ thất bại.","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.bnAdd_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool ValidateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nhập tên nhóm dịch vụ trước khi thêm/sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public void ReloadData()
        {
            try
            {
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                dgvSerGroup.DataSource = aServiceGroupsBO.Sel_all();
                dgvSerGroup.RefreshDataSource();

                lueType.Properties.DataSource = CORE.CONSTANTS.ListServiceTypes;
                lueType.Properties.DisplayMember = "Name";
                lueType.Properties.ValueMember = "ID";
                lueType.EditValue = CORE.CONSTANTS.SelectedServiceType(2).ID;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.ReloadData\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddServiceGroups_Load(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = "";
                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.frmAddServiceGroups_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSerGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int i = gridView1.FocusedRowHandle;
                txtName.Text = gridView1.GetRowCellValue(i, "Name").ToString();
                lueType.EditValue = gridView1.GetRowCellValue(i, "Type");
                cbxDisable.Text = gridView1.GetRowCellValue(i, "Disable").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.dgvSerGroup_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtName.Text) == true)
                {
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập tên nhóm dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bnAdd.Enabled = true;
                    bnEdit.Enabled = false;
                    ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                    ServiceGroups aServiceGroups = new ServiceGroups();
                    aServiceGroups.ID =Convert.ToInt32(lblID.Text);
                    aServiceGroups.Name = txtName.Text;
                    aServiceGroups.Type = Convert.ToInt32(lueType.EditValue);
                    aServiceGroups.Disable = bool.Parse(cbxDisable.SelectedItem.ToString());
                    aServiceGroupsBO.Update(aServiceGroups);
                    this.ReloadData();
                    if (afrmIns_Services != null)
                    {
                        this.afrmIns_Services.ReloadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.bnEdit_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                bnEdit.Enabled = true;
                bnAdd.Enabled = false;
                ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtName.Text = aServiceGroupsBO.Sel_ByID(ID).Name;
                lueType.EditValue = aServiceGroupsBO.Sel_ByID(ID).Type;
                cbxDisable.Text = aServiceGroupsBO.Sel_ByID(ID).Disable.ToString();
                lblID.Text = ID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.gridView1_RowClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int ID =Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                DialogResult result = MessageBox.Show("Bạn có muốn xóa nhóm dịch vụ " + ID + " này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
                    aServiceGroupsBO.Delete_ByID(ID);
                    MessageBox.Show("Xóa thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.ReloadData();

                    bnAdd.Enabled = true;
                    bnEdit.Enabled = false;
                    lblID.Text = "";
                    txtName.Text = "";                    
                    cbxDisable.SelectedIndex = 0;
                    if (afrmIns_Services != null)
                    {
                        this.afrmIns_Services.ReloadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.bnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}