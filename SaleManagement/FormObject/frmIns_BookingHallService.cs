using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinessLogic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;


namespace SaleManagement
{
    public partial class frmIns_BookingServices : DevExpress.XtraEditors.XtraForm
    {
        public frmIns_BookingServices()
        {
            InitializeComponent();
        }

        public DataTable _dtchange = new DataTable();
       // private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ServicesBO _ServicesBO = new ServicesBO();
        private void AddBookingService_Load(object sender, EventArgs e)
        {
            try
            {
                CreateDataTable();
                GetService();
            }
            catch (Exception ex)
            {
                
                //Logger.Error(ex);
            }
        }

        private void GetService()
        {
            try
            {
                //var dt = _ServicesBO.GetListService();
                //gcServiceList.DataSource = dt;
            }
            catch (Exception ex)
            {
                
              //  Logger.Error(ex);
            }
           
        }

        private void gvServiceList_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.CellValue == null) return;

            if (e.Column.Name.Equals(gridColumn9.Name))
            {
                e.RepositoryItem = CreateCheckEdit(e.CellValue);
            }
        }

        private void gvServiceList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private RepositoryItemCheckEdit CreateCheckEdit(object value)
        {
            var ri = new RepositoryItemCheckEdit();
            try
            {
                // you can cache your items here

                ri.Assign(rceCheck);
                ri.LockEvents();

                if (value.ToString().Equals("Y"))
                {
                    //Uncheck
                    ri.Enabled = true;
                    ri.ValueChecked = "Y";
                }
                else if (value.ToString().Equals("N"))
                {
                    //Uncheck
                    ri.Enabled = true;
                    ri.ValueUnchecked = "N";
                }
                return ri;
            }
            catch (Exception ex)
            {

             //   Logger.Error(ex);
            }
            return ri;
        }

        private void CreateDataTable()
        {
            try
            {
                _dtchange.Clear();
                _dtchange.Columns.Add("Name");
                _dtchange.Columns.Add("ID");
            }
            catch (Exception ex)
            {

               // Logger.Error(ex);
            }
        }

        private void rceCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var edit = sender as CheckEdit;
                if (edit == null) return;

                var id = gvServiceList.GetRowCellValue(gvServiceList.FocusedRowHandle, gvServiceList.Columns["ID"]).ToString();
                var name = gvServiceList.GetRowCellValue(gvServiceList.FocusedRowHandle, gvServiceList.Columns["Name"]).ToString();
                
                // Nếu check thì add thêm, uncheck thì xóa
                if (edit.CheckState == CheckState.Checked)
                {
                    DataRow newrow = _dtchange.NewRow();
                    newrow["ID"] = id;
                    newrow["Name"] = name;
                    _dtchange.Rows.Add(newrow);
                }
                else if (edit.CheckState == CheckState.Unchecked)
                {
                    var rowsToDelete = _dtchange.Rows.Cast<DataRow>().Where(dr => dr["ID"].ToString() == id).ToList();
                    if (rowsToDelete.Count > 0)
                    {
                        foreach (var r in rowsToDelete)
                            _dtchange.Rows.Remove(r);
                    }

                }

                // XtraMessageBox.Show(_dtchange.Rows.Count.ToString());
            }
            catch (Exception ex)
            {

              //  Logger.Error(ex);
            }
        }      

        private void ClearForm()
        {
            GetService();
           _dtchange.Rows.Clear();
        }

        private void sbClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void sbCreate_Click(object sender, EventArgs e)
        {
            try
            {
              DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                
              //  Logger.Error(ex);
            }
        }


    }
}