using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RptPaymentStyle1_ForDisplay
    {
        public int Index { set; get; }
        public DateTime Date { set; get; }
        public string Note { set; get; }
        public int CountCustomerInGroup { set; get; }

        public int IDBookingR { set; get; }
        public DateTime AcceptDate { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }

        public decimal Room_Fee { set; get; }
        public decimal Hall_Fee { set; get; }


        public decimal ServiceGroup2_Fee { set; get; }
        public decimal ServiceGroup3_Fee { set; get; }

        public decimal ServiceGroup4_Fee { set; get; }
        public decimal ServiceGroup5_Fee { set; get; }
        public decimal ServiceGroup6_Fee { set; get; }

        public decimal ServiceGroup7_Fee { set; get; }
        public decimal ServiceGroup8_Fee { set; get; }
        public decimal ServiceGroup9_Fee { set; get; }

        public decimal ServiceGroup10_Fee { set; get; }
        public decimal ServiceGroup11_Fee { set; get; }
        public decimal ServiceGroup12_Fee { set; get; }

        
        public decimal ServiceGroup13_Fee { set; get; }
        public decimal ServiceGroup14_Fee { set; get; }
        public decimal ServiceGroup15_Fee { set; get; }
        public decimal TotalMoney { set; get; }

        public void ConvertForViewAndPrint (RptPaymentStyle1 aItem)
        {
            this.Index = aItem.Index;
            this.CountCustomerInGroup = aItem.CountCustomerInGroup;
            this.Date = aItem.Date;
            this.Note = aItem.Note;
            
            this.IDBookingR = aItem.IDBookingR;
            this.InvoiceDate = aItem.InvoiceDate;
            this.InvoiceNumber = aItem.InvoiceNumber;

            this.Room_Fee = aItem.ServiceGroup_Fee[0];
            this.Hall_Fee = aItem.ServiceGroup_Fee[1];
            this.ServiceGroup2_Fee = aItem.ServiceGroup_Fee[2];
            this.ServiceGroup3_Fee = aItem.ServiceGroup_Fee[3];
            this.ServiceGroup4_Fee = aItem.ServiceGroup_Fee[4];
            this.ServiceGroup5_Fee = aItem.ServiceGroup_Fee[5];
            this.ServiceGroup6_Fee = aItem.ServiceGroup_Fee[6];
            this.ServiceGroup7_Fee = aItem.ServiceGroup_Fee[7];
            this.ServiceGroup8_Fee = aItem.ServiceGroup_Fee[8];
            this.ServiceGroup9_Fee = aItem.ServiceGroup_Fee[9];
            this.ServiceGroup10_Fee = aItem.ServiceGroup_Fee[10];
            this.ServiceGroup11_Fee = aItem.ServiceGroup_Fee[11];
            this.ServiceGroup12_Fee = aItem.ServiceGroup_Fee[12];
            this.ServiceGroup13_Fee = aItem.ServiceGroup_Fee[13];
            this.ServiceGroup14_Fee = aItem.ServiceGroup_Fee[14];
            this.ServiceGroup15_Fee = aItem.ServiceGroup_Fee[15];

        }      
        public RptPaymentStyle1_ForDisplay(RptPaymentStyle1 aItem)
        {
            this.Index = aItem.Index;
            this.CountCustomerInGroup = aItem.CountCustomerInGroup;
            this.Date = aItem.Date;
            this.Note = aItem.Note;
            

            this.Room_Fee = aItem.ServiceGroup_Fee[0];
            this.Hall_Fee = aItem.ServiceGroup_Fee[1];
            this.ServiceGroup2_Fee = aItem.ServiceGroup_Fee[2];
            this.ServiceGroup3_Fee = aItem.ServiceGroup_Fee[3];
            this.ServiceGroup4_Fee = aItem.ServiceGroup_Fee[4];
            this.ServiceGroup5_Fee = aItem.ServiceGroup_Fee[5];
            this.ServiceGroup6_Fee = aItem.ServiceGroup_Fee[6];
            this.ServiceGroup7_Fee = aItem.ServiceGroup_Fee[7];
            this.ServiceGroup8_Fee = aItem.ServiceGroup_Fee[8];
            this.ServiceGroup9_Fee = aItem.ServiceGroup_Fee[9];
            this.ServiceGroup10_Fee = aItem.ServiceGroup_Fee[10];
            this.ServiceGroup11_Fee = aItem.ServiceGroup_Fee[11];
            this.ServiceGroup12_Fee = aItem.ServiceGroup_Fee[12];
            this.ServiceGroup13_Fee = aItem.ServiceGroup_Fee[13];
            this.ServiceGroup14_Fee = aItem.ServiceGroup_Fee[14];
            this.ServiceGroup15_Fee = aItem.ServiceGroup_Fee[15];
        }
        public RptPaymentStyle1_ForDisplay()
        { 
        }
    }

    public class RptPaymentStyle1_ForPrint : RptPaymentStyle1_ForDisplay
    {

        public decimal TotalMoney { set; get; }
        public decimal MealMoney { set; get; }
        public decimal DrinkMoney { set; get; }
        public decimal RoomServiceMoney { set; get; }
        public decimal OtherMoney { set; get; }
        public decimal TotalServiceMoney { set; get; }

        public void SetValue(RptPaymentStyle1_ForDisplay aTemp)
        {
            this.Date = aTemp.Date;
            this.Note = aTemp.Note;
            this.CountCustomerInGroup = aTemp.CountCustomerInGroup;

            this.IDBookingR = aTemp.IDBookingR;
            this.InvoiceDate = aTemp.InvoiceDate;
            this.InvoiceNumber = aTemp.InvoiceNumber;

            this.Room_Fee = aTemp.Room_Fee;
            this.Hall_Fee = aTemp.Hall_Fee;

            this.ServiceGroup2_Fee = aTemp.ServiceGroup2_Fee;
            this.ServiceGroup3_Fee = aTemp.ServiceGroup3_Fee;
            this.ServiceGroup4_Fee = aTemp.ServiceGroup4_Fee;
            this.ServiceGroup5_Fee = aTemp.ServiceGroup5_Fee;
            this.ServiceGroup6_Fee = aTemp.ServiceGroup6_Fee;
            this.ServiceGroup7_Fee = aTemp.ServiceGroup7_Fee;
            this.ServiceGroup8_Fee = aTemp.ServiceGroup8_Fee;
            this.ServiceGroup9_Fee = aTemp.ServiceGroup9_Fee;
            this.ServiceGroup10_Fee = aTemp.ServiceGroup10_Fee;
            this.ServiceGroup11_Fee = aTemp.ServiceGroup11_Fee;
            this.ServiceGroup12_Fee = aTemp.ServiceGroup12_Fee;
            this.ServiceGroup13_Fee = aTemp.ServiceGroup13_Fee;
            this.ServiceGroup14_Fee = aTemp.ServiceGroup14_Fee;
            this.ServiceGroup15_Fee = aTemp.ServiceGroup15_Fee;


            this.TotalMoney = aTemp.Room_Fee + aTemp.Hall_Fee+aTemp.ServiceGroup2_Fee + aTemp.ServiceGroup3_Fee + aTemp.ServiceGroup4_Fee + aTemp.ServiceGroup5_Fee + aTemp.ServiceGroup6_Fee + aTemp.ServiceGroup7_Fee + aTemp.ServiceGroup8_Fee + aTemp.ServiceGroup9_Fee + aTemp.ServiceGroup10_Fee + aTemp.ServiceGroup11_Fee + aTemp.ServiceGroup12_Fee + aTemp.ServiceGroup13_Fee + aTemp.ServiceGroup14_Fee + aTemp.ServiceGroup15_Fee;

            this.MealMoney = aTemp.ServiceGroup8_Fee;
            this.DrinkMoney = aTemp.ServiceGroup7_Fee;
            this.RoomServiceMoney = aTemp.ServiceGroup6_Fee;
            this.OtherMoney = aTemp.ServiceGroup2_Fee + aTemp.ServiceGroup3_Fee + aTemp.ServiceGroup4_Fee + aTemp.ServiceGroup5_Fee + aTemp.ServiceGroup9_Fee;
            this.TotalServiceMoney = this.MealMoney + this.DrinkMoney + this.RoomServiceMoney + this.OtherMoney;


        }
        public RptPaymentStyle1_ForPrint()
        {}

    }
    public class RptPaymentStyle1
    {
        public int Index { set; get; }
        public DateTime Date { set; get; }
        public string Note { set; get; }
        public int CountCustomerInGroup { set; get; }

        public int IDBookingR { set; get; }
        public DateTime AcceptDate { set; get; }
        public string InvoiceNumber { set; get; }
        public DateTime InvoiceDate { set; get; }

        //public decimal Food_Service_Fee { set; get; }
        //public decimal Drink_Service_Fee { set; get; }
        //public decimal Room_Fee { set; get; }
        //public decimal Service_InRoom_Fee { set; get; }
        //public decimal Another_Service_Fee { set; get; }



        public List<Decimal> ServiceGroup_Fee { set; get; }

        public RptPaymentStyle1()
        {
            this.ServiceGroup_Fee = new List<decimal>();
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);

            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);

            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);

            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);

            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);
            this.ServiceGroup_Fee.Add(0);

            this.ServiceGroup_Fee.Add(0);
        }

    }

}
