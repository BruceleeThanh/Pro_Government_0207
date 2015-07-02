using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataAccess;
using Library;
using Entity;
namespace BussinessLogic
{
    public class CustomersBO
    {
        private  DatabaseDA aDatabaseDA =new DatabaseDA();

        //select all customers
        public  List<Customers> Select_All()
        {
            try
            {
                return aDatabaseDA.Customers.OrderByDescending(c=>c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.Select_All:" + ex.ToString());
            }
        }
        //select by id
        public Customers Select_ByID(int id)
        {
            try
            {
                List<Customers> aListCustomers = aDatabaseDA.Customers.Where(a => a.ID == id).ToList();
                if(aListCustomers.Count > 0)
                {
                    return aListCustomers[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception("CustomersBO.Select_ByID:" +ex.ToString());
            }
        }
 
        //select by name
        public List<Customers> Select_ByNameOrIdentifier1(int Choose,string Input)
        {
            try
            {
                List<Customers> ListCustomers=new List<Customers>();
                if (Choose == 0) // hien thi tat cac danh sach khach hang
                {
                    ListCustomers = aDatabaseDA.Customers.OrderByDescending(c=>c.ID).ToList();
                }
                else if (Choose == 1)  // 1 = Tim kiem theo ten
                {
                    ListCustomers = aDatabaseDA.Customers.Where(c=>c.Name.Contains(Input)).OrderByDescending(c => c.ID).ToList();
                }
                else if (Choose == 2) // 2 = Tim kiem theo Identifier1
                {
                    ListCustomers = aDatabaseDA.Customers.Where(c=>c.Identifier1.Contains(Input)).OrderByDescending(c => c.ID).ToList();
                }
                return ListCustomers;
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.Select_ByNameOrIdentifier1:" + ex.ToString());
            }
        }

        //add new customer
        
        public int Insert(Customers customer)
        {
            try
            {
                aDatabaseDA.Customers.Add(customer);
                aDatabaseDA.SaveChanges();
                return customer.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomersBO.Insert:" + ex.ToString());
            }
        }
        //update customers
        public int Update(Customers customer)
        {
            try
            {
                aDatabaseDA.Customers.AddOrUpdate(customer);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.Update:" + ex.ToString());
            }
        }
        //delete customers
        public int Delete(int id)
        {
            try
            {
                Customers aCustomer = aDatabaseDA.Customers.Find(id);
                aDatabaseDA.Customers.Remove(aCustomer);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.Delete:" + ex.ToString());
            }
        }

        //SelectCustomer_ByListIDCustomer
        public List<Customers> SelectListCustomer_ByListIDCustomer(List<int> aListIDCustomer)
        {
            List<Customers> aListCustomer = new List<Customers>();
            for (int i = 0; i < aListIDCustomer.Count; i++)
            {
                aListCustomer.Add(this.Select_ByID(int.Parse(aListIDCustomer[i].ToString()))); 
            }
            return aListCustomer;
        }

        //SelectCustomer_ByIDCustomerGroups
        public List<Customers> SelectListCustomer_ByIDCustomerGroups(int IDCustomerGroup)
        {
            List<vw__SearchCustomer__Companies_CustomerGroups_Customers> aListTemp = new List<vw__SearchCustomer__Companies_CustomerGroups_Customers>();
            aListTemp = aDatabaseDA.vw__SearchCustomer__Companies_CustomerGroups_Customers.Where(c => c.CustomerGroups_ID == IDCustomerGroup).Distinct().ToList();
            List<Customers> aListReturn = new List<Customers>();
            Customers aCustomers;
            foreach (var items in aListTemp)
            {
                aCustomers = new Customers();
                aCustomers.ID = items.Customers_ID;
                aCustomers.Name = items.Customers_Name;
                aCustomers.Identifier1 = items.Customers_Identifier1;
                aCustomers.Identifier2 = items.Customers_Identifier2;
                aCustomers.Identifier3 = items.Customers_Identifier3;
                aCustomers.Nationality = items.Customers_Nationality;
                aCustomers.Birthday = items.Customers_Birthday;
                aCustomers.Tel = items.Customers_Tel;
                aCustomers.Address = items.Customers_Address;
                aCustomers.Email = items.Customers_Email;
                aCustomers.Status = items.Customers_Status;
                aCustomers.Type = items.Customers_Type;
                aCustomers.Disable = items.Customers_Disable;
                aCustomers.Gender = items.Customers_Gender;
                aCustomers.Citizen = items.Customers_Citizen;

                aListReturn.Add(aCustomers);
            }
            return aListReturn;

        }

        //SelectListCustomer_ByCustomerName
        //public List<Customers> SelectListCustomer_ByCustomerName(string NameCustomer)
        //{
        //    List<vw__SearchCustomer__Companies_CustomerGroups_Customers> aListTemp = new List<vw__SearchCustomer__Companies_CustomerGroups_Customers>();
        //    aListTemp = aDatabaseDA.vw__SearchCustomer__Companies_CustomerGroups_Customers.Where(c => c.Customers_Name.Contains(NameCustomer)).Distinct().ToList();
        //    List<Customers> aListReturn = new List<Customers>();
        //    Customers aCustomers;
        //    foreach (var items in aListTemp)
        //    {
        //        aCustomers = new Customers();
        //        aCustomers.ID = items.Customers_ID;
        //        aCustomers.Name = items.Customers_Name;
        //        aCustomers.Identifier1 = items.Customers_Identifier1;
        //        aCustomers.Identifier2 = items.Customers_Identifier2;
        //        aCustomers.Identifier3 = items.Customers_Identifier3;
        //        aCustomers.Nationality = items.Customers_Nationality;
        //        aCustomers.Birthday = items.Customers_Birthday;
        //        aCustomers.Tel = items.Customers_Tel;
        //        aCustomers.Address = items.Customers_Address;
        //        aCustomers.Email = items.Customers_Email;
        //        aCustomers.Status = items.Customers_Status;
        //        aCustomers.Type = items.Customers_Type;
        //        aCustomers.Disable = items.Customers_Disable;
        //        aCustomers.Gender = items.Customers_Gender;
        //        aCustomers.Citizen = items.Customers_Citizen;

        //        aListReturn.Insert(0, aCustomers);
        //    }
        //    return aListReturn;

        //}

        //SelectListCustomer_ByCustomerName_ByIDCustomerGroups
        //public List<Customers> SelectListCustomer_ByCustomerName_ByIDCustomerGroups(string NameCustomer,int IDCustomerGroup)
        //{
        //    List<vw__SearchCustomer__Companies_CustomerGroups_Customers> aListTemp = new List<vw__SearchCustomer__Companies_CustomerGroups_Customers>();
        //    aListTemp = aDatabaseDA.vw__SearchCustomer__Companies_CustomerGroups_Customers.Where(c=>c.Customers_Name.Contains(NameCustomer)).Where(c => c.CustomerGroups_ID == IDCustomerGroup).Distinct().ToList();
        //    List<Customers> aListReturn = new List<Customers>();
        //    Customers aCustomers;
        //    foreach (var items in aListTemp)
        //    {
        //        aCustomers = new Customers();
        //        aCustomers.ID = items.Customers_ID;
        //        aCustomers.Name = items.Customers_Name;
        //        aCustomers.Identifier1 = items.Customers_Identifier1;
        //        aCustomers.Identifier2 = items.Customers_Identifier2;
        //        aCustomers.Identifier3 = items.Customers_Identifier3;
        //        aCustomers.Nationality = items.Customers_Nationality;
        //        aCustomers.Birthday = items.Customers_Birthday;
        //        aCustomers.Tel = items.Customers_Tel;
        //        aCustomers.Address = items.Customers_Address;
        //        aCustomers.Email = items.Customers_Email;
        //        aCustomers.Status = items.Customers_Status;
        //        aCustomers.Type = items.Customers_Type;
        //        aCustomers.Disable = items.Customers_Disable;
        //        aCustomers.Gender = items.Customers_Gender;
        //        aCustomers.Citizen = items.Customers_Citizen;

        //        aListReturn.Insert(0, aCustomers);
        //    }
        //    return aListReturn;

        //}


        public List<Customers> SelectListCustomer_ByListIDBookingRoom(List<int> ListIDBookingRoom)
        {
            try
            {
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                List<int> aListIDCustomer = aBookingRoomsMembersBO.Select_ByListIDBookingRoom(ListIDBookingRoom).Select(b => b.IDCustomer).Distinct().ToList();
                return this.SelectListCustomer_ByListIDCustomer(aListIDCustomer);
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.SelectListCustomer_ByListIDBookingRoom\n" + ex.ToString());
            }
        }

        public List<Customers> SelectListCustomer_ByIDBookingRoom(int IDBookingRoom)
        {
            try
            {
                BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
                List<int> aListIDCustomer = aBookingRoomsMembersBO.Select_ByIDBookingRoom(IDBookingRoom).Select(b => b.IDCustomer).Distinct().ToList();
                return this.SelectListCustomer_ByListIDCustomer(aListIDCustomer);
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.SelectListCustomer_ByIDBookingRoom\n" + ex.ToString());
            }
        }
        public List<Customers> SelectListCustomer_ByIDBookingR(int IDBookingR)
        {
            try
            {
                
                List<int> aList = aDatabaseDA.BookingRooms.Where(p => p.IDBookingR == IDBookingR).Select(p=>p.ID).ToList();
                if (aList.Count > 0)
                {
                    return this.SelectListCustomer_ByListIDBookingRoom(aList);
                }
                else
                {
                    return new List<Customers>();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("CustomersBO.SelectListCustomer_ByIDBookingRoom\n" + ex.ToString());
            }
        }
        

        //Lingting - Tự động thêm khách hàng và đưa vào nhóm
        public int AutoInsertCustomer(string Name, int IDCustomerGroup, string Tel,DateTime FromDate)
        {
            try
            {
                Customers aCustomer = new Customers();
                aCustomer.Name = Name;
                aCustomer.Tel = Tel;
                aCustomer.Disable = false;
                this.Insert(aCustomer);

                CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
                aCustomerGroups_CustomersBO.AutoInsertCustomerToGroup(aCustomer.ID, IDCustomerGroup, FromDate);
                return aCustomer.ID;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("CustomersBO.AutoInsertCustomer:" + ex.ToString());
            }
        }
        //Lay danh sach khach hang thuoc 1 phong nao do
        public List<Customers> SelectListCustomerInRoom(int IDBookingRoom)
        {
            CustomersBO aCustomersBO = new CustomersBO();
            return aCustomersBO.SelectListCustomer_ByIDBookingRoom(IDBookingRoom);
        }
    }
}
