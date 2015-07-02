using System;
using System.Windows.Forms;
using DataAccess;
using BussinessLogic;
using CORESYSTEM;

namespace SaleManagement
{
    public partial class frmIns_ServiceGroups : DevExpress.XtraEditors.XtraForm
    {
        ServiceGroupsBO aServiceGroupsBO = new ServiceGroupsBO();
        ServiceGroups aServiceGroups = new ServiceGroups();
        frmIns_Services afrmIns_Services_Old = null;
       
        public frmIns_ServiceGroups()
        {
            InitializeComponent();
            //gridView1.RowCellClick += gridView1_RowCellClick;
        }
        public frmIns_ServiceGroups(frmIns_Services afrmIns_Services)
        {
            InitializeComponent();
            afrmIns_Services_Old = afrmIns_Services;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    aServiceGroups.Name = txtName.Text;
                    aServiceGroups.Type = Convert.ToInt32(lueType.EditValue);
                    aServiceGroups.Disable = bool.Parse(cbxDisable.SelectedItem.ToString());

                    int ret = aServiceGroupsBO.Ins(aServiceGroups);
                    if (ret == 1)
                    {
                        MessageBox.Show("Thêm mới thành công");
                        ReloadData();
                        if (afrmIns_Services_Old != null)
                        {
                            afrmIns_Services_Old.Reload();
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Thất Bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.bnAdd_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void ReloadData()
        {
            try
            {
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
                ReloadData();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    aServiceGroups.ID = int.Parse(lblID.Text); ;
                    aServiceGroups.Name = txtName.Text;
                    aServiceGroups.Type = Convert.ToInt32(lueType.EditValue);
                    aServiceGroups.Disable = bool.Parse(cbxDisable.SelectedItem.ToString());
                    aServiceGroupsBO.Upd(aServiceGroups);
                    if (afrmIns_Services_Old != null)
                    {
                        afrmIns_Services_Old.Reload();
                        this.Close();
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
                int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa nhóm dịch vụ " + ID + " này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    aServiceGroupsBO.Del_ByID(ID);
                    MessageBox.Show("Xóa thành công");
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ServiceGroups.bnDelete_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}