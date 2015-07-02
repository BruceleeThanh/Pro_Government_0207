﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BussinessLogic;
using DataAccess;

namespace RoomManager
{
    public partial class frmUpd_PermitDetail : DevExpress.XtraEditors.XtraForm
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        PermitDetailsBO aPermitDetailsBO = new PermitDetailsBO();
        int ID_Old;
        frmLst_PermitDetails afrmLst_PermitDetails_Old;

        public frmUpd_PermitDetail(int ID, frmLst_PermitDetails afrmLst_PermitDetails)
        {
            InitializeComponent();
            ID_Old = ID;
            afrmLst_PermitDetails_Old = afrmLst_PermitDetails;
        }

        private void frmUpd_PermitDetail_Load(object sender, EventArgs e)
        {
            lblIDPermitDetail.Text = ID_Old.ToString();
            PermitDetails aPermitDetails = aPermitDetailsBO.Select_ByIDPermitDetail(ID_Old);
            PermitsBO aPermitsBO = new PermitsBO();
            lueIDPermit.Properties.DataSource = aPermitsBO.Select_All();
            lueIDPermit.Properties.DisplayMember = "Name";
            lueIDPermit.Properties.ValueMember = "ID";
            lueIDPermit.EditValue = aPermitDetails.IDPermit;
            txtName.Text = aPermitDetails.Name;
            txtPageURL.Text = aPermitDetails.PageURL;
            cbbDisable.Text = aPermitDetails.Disable.ToString();
            cbbStatus.Text = aPermitDetails.Status.ToString();
            cbbType.Text = aPermitDetails.Type.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PermitDetails aPermitDetails = new PermitDetails();
            aPermitDetails.ID = int.Parse(lblIDPermitDetail.Text);
            aPermitDetails.IDPermit = Convert.ToInt32(lueIDPermit.EditValue);
            aPermitDetails.Name = txtName.Text;
            aPermitDetails.PageURL = txtPageURL.Text;
            aPermitDetails.Status = int.Parse(cbbStatus.Text);
            aPermitDetails.Type = int.Parse(cbbType.Text);
            aPermitDetails.Disable = bool.Parse(cbbDisable.Text);
            aPermitDetailsBO.Update(aPermitDetails);
            afrmLst_PermitDetails_Old.Reload();
            this.Close();
        }
    }
}