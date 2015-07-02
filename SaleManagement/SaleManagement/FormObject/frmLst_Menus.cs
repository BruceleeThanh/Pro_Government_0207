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
namespace SaleManagement
{
    public partial class frmLst_Menus : DevExpress.XtraEditors.XtraForm
    {
        public frmLst_Menus()
        {
            InitializeComponent();
        }
        //hiennv
        private void frmLst_Menus_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Menus.frmLst_Menus_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        public void LoadDataMenus()
        {
            try
            {
                MenusBO aMenusBO = new MenusBO();
                dgvMenus.DataSource = aMenusBO.Select_All();
                dgvMenus.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Menus.LoadDataMenus\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int menuID = Convert.ToInt32(viewMenus.GetFocusedRowCellValue("ID"));
                    Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                    int status = aMenus_FoodsBO.Delete_ByIDMenu(menuID);
                    MenusBO aMenusBO = new MenusBO();
                    aMenusBO.Delete(menuID);
                    this.LoadDataMenus();
                    MessageBox.Show("Bạn đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Menus.btnDeleteFoods_ButtonClick\n" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDMenu = Convert.ToInt32(viewMenus.GetFocusedRowCellValue("ID"));
                frmLst_DetailMenus afrmLst_DetailMenus = new frmLst_DetailMenus(IDMenu);
                afrmLst_DetailMenus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Menus.btnDetail_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiennv
        private void btnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int IDMenu = Convert.ToInt32(viewMenus.GetFocusedRowCellValue("ID"));
                frmUpd_Menus afrmUpd_Menus = new frmUpd_Menus(this, IDMenu);
                afrmUpd_Menus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmLst_Menus.btnEdit_ButtonClick\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmIns_Menus afrmIns_Menus = new frmIns_Menus(this, 1); //type=1:thuc don mau
            afrmIns_Menus.ShowDialog();
        }
    }
}