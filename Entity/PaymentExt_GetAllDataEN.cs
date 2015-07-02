using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class PaymentExt_GetAllDataEN : sp_PaymentExt_GetAllData_Ext_Result
    {
        public string DisplayService_PaymentStatus { get; set; }
        public string DisplayObject_PaymentStatus { get; set; }
        public string DisplayBillR_PaymentStatus { get; set; }
        public string Object_InvoiceDate { get; set; }
        public string Subject { get; set; }

        public void SetValue(sp_PaymentExt_GetAllData_Ext_Result aTemp)
        {
            this.BookingRs_ID = aTemp.BookingRs_ID;
            this.ObjectType = aTemp.ObjectType;
            this.SkuObject = aTemp.SkuObject;

            this.IDBookingService = aTemp.IDBookingService;
            this.IDService = aTemp.IDService;
            this.Services_Name = aTemp.Services_Name;

            this.Service_DateUse = aTemp.Service_DateUse;
            this.Services_SubPayment = aTemp.Services_SubPayment;
            this.Object_SubPayment = aTemp.Object_SubPayment;

            this.Object_PaymentStatus = aTemp.Object_PaymentStatus;
            this.BillH_PaymentStatus = aTemp.BillH_PaymentStatus;
            this.BillR_PaymentStatus = aTemp.BillR_PaymentStatus;
            this.Time1 = aTemp.Time1;
            this.Time2 = aTemp.Time2;

            this.FeeObjectNotTax = aTemp.FeeObjectNotTax;
            this.FeeObjectWithTax = aTemp.FeeObjectWithTax;
            this.FeeServiceNotTax = aTemp.FeeServiceNotTax;
            this.FeeServiceWithTax = aTemp.FeeServiceWithTax;

            this.Object_AcceptDate = aTemp.Object_AcceptDate;
            this.Object_InvoiceDate = aTemp.Object_InvoiceDate.GetValueOrDefault().ToShortDateString();
            this.Object_SubPayment = aTemp.Object_SubPayment;
            this.Object_InvoiceNumber = aTemp.Object_InvoiceNumber;
            if (aTemp.ObjectType.ToUpper() == "PHÒNG")
            {
                this.Subject = aTemp.BookingRs_Subject;
            }
            else if (aTemp.ObjectType.ToUpper() == "HỘI TRƯỜNG")
            {
                this.Subject = aTemp.BookingHs_Subject;
            } 
        }

    }
}
