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
using BussinessLogic;
using Entity;
namespace HumanResource
{
    public partial class frmTsk_ChooseSystemUsersToDivisions : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_SystemUsers_Divisions afrmLst_SystemUsers_Divisions = null;
        private SystemUsers_DivisionsEN aSystemUsers_DivisionsEN = new SystemUsers_DivisionsEN();
        private List<SystemUsers> aListAvailableSystemUsers = new List<SystemUsers>();
        private int IDDivision = 0;
        public frmTsk_ChooseSystemUsersToDivisions()
        {
            InitializeComponent();
        }
        public frmTsk_ChooseSystemUsersToDivisions(frmLst_SystemUsers_Divisions afrmLst_SystemUsers_Divisions)
        {
            InitializeComponent();
            this.afrmLst_SystemUsers_Divisions = afrmLst_SystemUsers_Divisions;
        }



        private void frmIns_SystemUsers_Divisions_Load(object sender, EventArgs e)
        {
            try
            {
                DivisionsBO aDivisionsBO = new DivisionsBO();
                List<Divisions> aListDivisions = aDivisionsBO.Select_All();
                lueIDDivision.Properties.DataSource = aListDivisions;
                lueIDDivision.Properties.DisplayMember = "Name";
                lueIDDivision.Properties.ValueMember = "ID";

                if (aListDivisions.Count > 0)
                {
                    lueIDDivision.EditValue = aListDivisions[0].ID;
                }
                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                this.aListAvailableSystemUsers = aSystemUsersBO.Select_ByDisable(false); //Disable = false 
                this.LoadListAvailableSystemUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.frmIns_SystemUsers_Divisions_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadListAvailableSystemUsers()
        {
            try
            {
                dgvAvailableSystemUsers.DataSource = this.aListAvailableSystemUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.LoadListAvailableSystemUsers\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(dtpAvaiableDate.Text))
            {
                MessageBox.Show("Bạn phải chọn ngày chuyển vào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(dtpExpireDate.Text))
            {
                MessageBox.Show("Bạn phải chọn ngày chuyển đi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
           
            else
            {
                return true;
            }
        }
        private void btnSelectSystemUsers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {


                SystemUsers aSystemUsers = new SystemUsers();
                aSystemUsers.ID = Convert.ToInt32(viewAvailableSystemUsers.GetFocusedRowCellValue("ID"));
                aSystemUsers.Username = Convert.ToString(viewAvailableSystemUsers.GetFocusedRowCellValue("Username"));
                aSystemUsers.Name = Convert.ToString(viewAvailableSystemUsers.GetFocusedRowCellValue("Name"));
                aSystemUsers.Identifier1 = Convert.ToString(viewAvailableSystemUsers.GetFocusedRowCellValue("Identifier1"));

                DivisionsEN aDivisionsEN = new DivisionsEN();
                List<DivisionsEN> aListTemps = aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d => d.ID ==IDDivision).ToList();
                if (aListTemps.Count == 0)
                {
                    aDivisionsEN.ID = Convert.ToInt32(lueIDDivision.EditValue);
                    aSystemUsers_DivisionsEN.aListDivisionsEN.Add(aDivisionsEN);
                }
                aDivisionsEN = aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d => d.ID == IDDivision).ToList()[0];
                int Index = aSystemUsers_DivisionsEN.aListDivisionsEN.IndexOf(aDivisionsEN);
                if (aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Where(s => s.ID == aSystemUsers.ID).ToList().Count > 0)
                {
                    SystemUsers aSystemUsersTemps = aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Where(d => d.ID == aSystemUsers.ID).ToList()[0];
                    aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Remove(aSystemUsersTemps);
                }
                aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Add(aSystemUsers);
                

                dgvSelectSystemUsers.DataSource = aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers;
                dgvSelectSystemUsers.RefreshDataSource();

                SystemUsers Temps = aListAvailableSystemUsers.Where(d => d.ID == Convert.ToInt32(viewAvailableSystemUsers.GetFocusedRowCellValue("ID"))).ToList()[0];
                aListAvailableSystemUsers.Remove(Temps);
                dgvAvailableSystemUsers.DataSource = aListAvailableSystemUsers;
                dgvAvailableSystemUsers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.btnSelectSystemUsers_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == true)
                {
                    if (dtpAvaiableDate.DateTime < DateTime.Now.AddDays(-1))
                    {
                        MessageBox.Show("Vui lòng chọn ngày chuyển vào phải lớn hơn hoặc bằng ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (DateTime.ParseExact(dtpAvaiableDate.Text, "dd/MM/yyyy", null) >= DateTime.ParseExact(dtpExpireDate.Text, "dd/MM/yyyy", null))
                    {
                        MessageBox.Show("Ngày chuyển vào phải nhỏ hơn ngày chuyển đi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                        aSystemUsers_DivisionsEN.AvaiableDate = DateTime.ParseExact(dtpAvaiableDate.Text, "dd/MM/yyyy", null);


                        aSystemUsers_DivisionsEN.ExpireDate = DateTime.ParseExact(dtpExpireDate.Text, "dd/MM/yyyy",null);
                        aSystemUsers_DivisionsEN.Type = cboType.SelectedIndex + 1;
                        aSystemUsers_DivisionsEN.Status = cboStatus.SelectedIndex + 1;
                        aSystemUsers_DivisionsEN.Disable = Convert.ToBoolean(cboDisable.Text);
                        aReceptionTaskBO.InsertSystemUsersToDivisions(aSystemUsers_DivisionsEN);
                        MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (afrmLst_SystemUsers_Divisions != null)
                        {
                            this.afrmLst_SystemUsers_Divisions.ReloadData();
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverSystemUsers_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                SystemUsers aSystemUsers = new SystemUsers();
                aSystemUsers.ID = Convert.ToInt32(viewSelectSystemUsers.GetFocusedRowCellValue("ID"));
                aSystemUsers.Username = Convert.ToString(viewSelectSystemUsers.GetFocusedRowCellValue("Username"));
                aSystemUsers.Name = Convert.ToString(viewSelectSystemUsers.GetFocusedRowCellValue("Name"));
                aSystemUsers.Identifier1 = Convert.ToString(viewSelectSystemUsers.GetFocusedRowCellValue("Identifier1"));

                aListAvailableSystemUsers.Add(aSystemUsers);
                dgvAvailableSystemUsers.DataSource = aListAvailableSystemUsers;
                dgvAvailableSystemUsers.RefreshDataSource();

                DivisionsEN aDivisionsEN = aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d => d.ID == Convert.ToInt32(lueIDDivision.EditValue)).ToList()[0];
                int Index = aSystemUsers_DivisionsEN.aListDivisionsEN.IndexOf(aDivisionsEN);
                SystemUsers Temps = aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Where(d => d.ID == Convert.ToInt32(viewSelectSystemUsers.GetFocusedRowCellValue("ID"))).ToList()[0];
                aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Remove(Temps);
                dgvSelectSystemUsers.DataSource = aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers;
                dgvSelectSystemUsers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.btnRemoverSystemUsers_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lueIDDivision_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.IDDivision = Convert.ToInt32(lueIDDivision.EditValue);
                DivisionsBO aDivisionsBO = new DivisionsBO();
                

                Divisions aDivisions = aDivisionsBO.Select_ByID(this.IDDivision);

                DivisionsEN aTemp = new DivisionsEN();
                aTemp.ID = aDivisions.ID;

                if (this.aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d=>d.ID == this.IDDivision).ToList().Count == 0)
                {
                    this.aSystemUsers_DivisionsEN.aListDivisionsEN.Add(aTemp);
                }

                SystemUsersBO aSystemUsersBO = new SystemUsersBO();
                List<SystemUsers> aListTemp = aSystemUsersBO.SelectListAllSystemUsers_ByIDDivision(this.IDDivision);
                SystemUsers aSystemUsers;

                foreach (DivisionsEN aDivisionsEN in this.aSystemUsers_DivisionsEN.aListDivisionsEN)
                {
                    if(aDivisionsEN.ID == this.IDDivision)
                    {
                        if (aDivisionsEN.aListSystemUsers.Count <= 0)
                        {
                            foreach (SystemUsers item in aListTemp)
                            {
                                aSystemUsers = new SystemUsers();
                                aSystemUsers.ID = item.ID;
                                aSystemUsers.Username = item.Username;
                                aSystemUsers.Name = item.Name;
                                aSystemUsers.Identifier1 = item.Identifier1;
                                aDivisionsEN.aListSystemUsers.Add(aSystemUsers);
                            }
                        }
                    }
                }

                List<DivisionsEN> aListTemps = this.aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d => d.ID == this.IDDivision).ToList();
                if (aListTemps.Count > 0)
                {
                    DivisionsEN aDivisionsEN = this.aSystemUsers_DivisionsEN.aListDivisionsEN.Where(d => d.ID == this.IDDivision).ToList()[0];
                    int Index = this.aSystemUsers_DivisionsEN.aListDivisionsEN.IndexOf(aDivisionsEN);
                    dgvSelectSystemUsers.DataSource = this.aSystemUsers_DivisionsEN.aListDivisionsEN[Index].aListSystemUsers.Distinct();
                    dgvSelectSystemUsers.RefreshDataSource();
                    this.aSystemUsers_DivisionsEN.aListDivisionsEN.Clear();
                }
                else
                {
                    dgvSelectSystemUsers.DataSource = null;
                    dgvSelectSystemUsers.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_SystemUsers_Divisions.lueIDDivision_EditValueChanged\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}