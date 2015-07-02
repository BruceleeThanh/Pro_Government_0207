using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class BookingEN
    {
        //============== FORM 1 =========
        public DateTime CheckInActual = DateTime.Parse("01/01/1900");
        public DateTime CheckOutPlan = DateTime.Parse("01/01/1900");
        public DateTime CheckOutActual = DateTime.Parse("01/01/1900");  // thoi diem nhan phong gan tam CheckoutActual = CheckOutPlan
        public List<RoomsEN> aListRoomsEN = new List<RoomsEN>();

        //============== FORM 2 =========
        public DateTime CreateDate = DateTime.Now;
        public int CustomerType;
        public int BookingType;
        public string Note;
        public int IDCustomerGroup;
        public int IDCustomer;
        public int IDSystemUser;
        public int PayMenthod;
        public int StatusPay;
        public decimal BookingMoney;
        public decimal ExchangeRate;
        public int Status;
        public int Type;
        public bool Disable;
        public int Level;
        public string Subject;
        public string Description;
        public DateTime DatePay = DateTime.Parse("01/01/1900");
        public DateTime DateEdit = DateTime.Parse("01/01/1900");
    }
}
