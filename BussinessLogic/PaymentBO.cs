using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;

namespace BussinessLogic
{
    public class PaymentBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<Payment> Select_All()
        {
            try
            {
                return aDatabaseDA.Payment.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("PaymentBO.Select_All :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public Payment Select_ByID(int ID)
        {
            try
            {
                List<Payment> aListPayment = aDatabaseDA.Payment.Where(c => c.ID == ID).ToList();
                if (aListPayment.Count > 0)
                {
                    return aListPayment[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("PaymentBO.Select_ByID :" + ex.Message.ToString()));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(Payment aPayment)
        {
            try
            {
                aDatabaseDA.Payment.Add(aPayment);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("PaymentBO.Insert :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByID
        //=======================================================
        public int Delete(int ID)
        {
            try
            {
                Payment aPayment = aDatabaseDA.Payment.Find(ID);
                aDatabaseDA.Payment.Remove(aPayment);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("PaymentBO.Delete :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(Payment aPayment)
        {
            try
            {
                aDatabaseDA.Payment.AddOrUpdate(aPayment);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("PaymentBO.Update :" + ex.Message));
            }
        }
    }
}
