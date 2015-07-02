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
using CORESYSTEM;

namespace RoomManager
{
    public partial class frmUpd_ExtraCostRooms : DevExpress.XtraEditors.XtraForm
    {

        private frmLst_ExtraCostRooms afrmLst_ExtraCostRooms = null;
        private int ID = 0;
      

        public frmUpd_ExtraCostRooms(frmLst_ExtraCostRooms afrmLst_ExtraCostRooms,int ID)
        {
            InitializeComponent();
            this.afrmLst_ExtraCostRooms = afrmLst_ExtraCostRooms;
            this.ID = ID;
           
        }
        //Hiennv
        private void frmUpd_ExtraCostRooms_Load(object sender, EventArgs e)
        {
            try
            {
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                ExtraCosts aExtraCosts = new ExtraCosts();
                aExtraCosts = aExtraCostBO.Select_ByID(this.ID);
                txtSku.EditValue = aExtraCosts.Sku;

                lueCustomerType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes;
                lueCustomerType.Properties.DisplayMember = "Name";
                lueCustomerType.Properties.ValueMember = "ID";
              
               lueCustomerType.EditValue = aExtraCosts.CustomerType;

               cbbPriceType.EditValue = aExtraCosts.PriceType;
               txtNumberPepole.EditValue = aExtraCosts.NumberPeople;
               txtExtraCost.EditValue = aExtraCosts.ExtraValue;

            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_ExtraCostRooms.frmUpd_ExtraCostRooms_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                ExtraCosts aExtraCosts = new ExtraCosts();
                aExtraCosts.ID = this.ID;
                aExtraCosts.Sku = txtSku.Text;
                aExtraCosts.CustomerType = lueCustomerType.EditValue.ToString();
                aExtraCosts.NumberPeople = Convert.ToInt32(txtNumberPepole.EditValue);
                aExtraCosts.ExtraValue = Convert.ToDecimal(txtExtraCost.EditValue);
                aExtraCosts.PriceType = cbbPriceType.Text;
                aExtraCostBO.Update(aExtraCosts);

                if (this.afrmLst_ExtraCostRooms != null)
                {
                    this.afrmLst_ExtraCostRooms.LoadExtraCostRooms();
                }
                this.Close();
                MessageBox.Show("Thực hiện thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmUpd_ExtraCostRooms.btnSave_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}