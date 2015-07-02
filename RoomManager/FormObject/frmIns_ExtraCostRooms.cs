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
using CORESYSTEM;
using BussinessLogic;


namespace RoomManager
{
    public partial class frmIns_ExtraCostRooms : DevExpress.XtraEditors.XtraForm
    {
        private frmLst_ExtraCostRooms afrmLst_ExtraCostRooms = null;
        public frmIns_ExtraCostRooms(frmLst_ExtraCostRooms afrmLst_ExtraCostRooms)
        {
            InitializeComponent();
            this.afrmLst_ExtraCostRooms = afrmLst_ExtraCostRooms;
        }
        //Hiennv
        private void frmIns_ExtraCostRooms_Load(object sender, EventArgs e)
        {
            try
            {
                RoomsBO aRoomsBO = new RoomsBO();

                List<Rooms> aListRooms = aRoomsBO.Select_ByIDLang(1).Where(r=>r.Disable==false).ToList();
                lueSku.Properties.DataSource = aListRooms;
                lueSku.Properties.DisplayMember = "Sku";
                lueSku.Properties.ValueMember = "ID";

                lueCustomerType.Properties.DataSource = CORE.CONSTANTS.ListCustomerTypes;
                lueCustomerType.Properties.DisplayMember = "Name";
                lueCustomerType.Properties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ExtraCostRooms.frmIns_ExtraCostRooms_Load\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Hiennv
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ExtraCostBO aExtraCostBO = new ExtraCostBO();
                ExtraCosts aExtraCosts = new ExtraCosts();
                aExtraCosts.Sku = lueSku.Text;
                aExtraCosts.CustomerType = lueCustomerType.EditValue.ToString();
                aExtraCosts.NumberPeople = Convert.ToInt32(txtNumberPepole.EditValue);
                aExtraCosts.ExtraValue = Convert.ToDecimal(txtExtraCost.EditValue);
                aExtraCosts.PriceType = cbbPriceType.Text;
                aExtraCostBO.Insert(aExtraCosts);

                if(this.afrmLst_ExtraCostRooms !=null)
                {
                    this.afrmLst_ExtraCostRooms.LoadExtraCostRooms();
                }
                this.Close();
                MessageBox.Show("Thực hiện thành công .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmIns_ExtraCostRooms.btnAddNew_Click\n" + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}