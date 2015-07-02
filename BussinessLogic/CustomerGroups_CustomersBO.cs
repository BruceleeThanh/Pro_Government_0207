using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class CustomerGroups_CustomersBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //----------------Display Customers----------------------
        public List<CustomerGroups_Customers> Select_All()
        {
            try
            {
                return aDatabaseDA.CustomerGroups_Customers.OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Select_All:" + ex.ToString());
            }
        }
        //-----------------Select by id-------------------------------
        public CustomerGroups_Customers Select_ByID(int id)
        {
            try
            {
                List<CustomerGroups_Customers> aListCustomerGroups_Customers = aDatabaseDA.CustomerGroups_Customers.Where(a => a.ID == id).ToList();
                if (aListCustomerGroups_Customers.Count > 0)
                {
                    return aListCustomerGroups_Customers[0];
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Select_ByID:" + ex.ToString());
            }
        }
        //-----------------Select_ByIDCustomer_ByIDCustomerGroup-------------------------------
        public CustomerGroups_Customers Select_ByIDCustomer_ByIDCustomerGroup(int IDCustomer, int IDCustomerGroup)
        {
            try
            {
                if (aDatabaseDA.CustomerGroups_Customers.Where(c => c.IDCustomer == IDCustomer).Where(c => c.IDCustomerGroup == IDCustomerGroup).ToList().Count > 0)
                {
                    return aDatabaseDA.CustomerGroups_Customers.Where(c => c.IDCustomer == IDCustomer).Where(c => c.IDCustomerGroup == IDCustomerGroup).ToList()[0];

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("CustomerGroups_CustomersBO.Select_ByIDCustomer_ByIDCustomerGroup:" + ex.ToString());
            }
        }
        //-----------------Select by IDCustomerGrou-------------------------------
        public List<CustomerGroups_Customers> Select_ByIDCustomerGroup(int IDCustomerGroup)
        {
            try
            {
                return aDatabaseDA.CustomerGroups_Customers.Where(c => c.IDCustomerGroup == IDCustomerGroup).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Select_ByIDCustomerGroup:" + ex.ToString());
            }
        }
        //-----------------Select by Name-------------------------------
        public List<CustomerGroups_Customers> Select_ByName(string name)
        {
            try
            {
                return aDatabaseDA.CustomerGroups_Customers.Where(c => c.Name.Contains(name)).OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Select_ByName:" + ex.ToString());
            }
        }
        //-----------------Add New ---------------------------------

        public int Insert(CustomerGroups_Customers customerGroups_Customers)
        {
            try
            {
                aDatabaseDA.CustomerGroups_Customers.Add(customerGroups_Customers);
                aDatabaseDA.SaveChanges();
                return customerGroups_Customers.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("CustomerGroups_CustomersBO.Insert:" + ex.ToString());
            }
        }
        //----------------Update Customers -----------------------------
        public int Update(CustomerGroups_Customers customerGroups_Customers)
        {
            try
            {
                aDatabaseDA.CustomerGroups_Customers.AddOrUpdate(customerGroups_Customers);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Update:" + ex.ToString());
            }
        }
        //----------------- Delete Customers  ------------------------------
        public int Delete(int IDCustomer, int IDCustomerGroup)
        {
            try
            {

                List<CustomerGroups_Customers> aCustomerGroups_Customers = aDatabaseDA.CustomerGroups_Customers.Where(c => c.IDCustomer == IDCustomer).Where(c => c.IDCustomerGroup == IDCustomerGroup).ToList();
                aDatabaseDA.CustomerGroups_Customers.RemoveRange(aCustomerGroups_Customers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Delete:" + ex.ToString());
            }
        }

        public int Delete(CustomerGroups_Customers customerGroups_Customers)
        {
            try
            {
                aDatabaseDA.CustomerGroups_Customers.Remove(customerGroups_Customers);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("CustomerGroups_CustomersBO.Delete:" + ex.ToString());
            }
        }
        //Linhting - Tự động thêm khách vào nhóm
        public int AutoInsertCustomerToGroup(int IDCustomer, int IDCustomerGroup, DateTime From)
        {
            try
            {
                CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
                aCustomerGroups_Customers = this.Select_ByIDCustomer_ByIDCustomerGroup(IDCustomer, IDCustomerGroup);
                if (aCustomerGroups_Customers != null)
                {
                    return this.Select_ByIDCustomer_ByIDCustomerGroup(IDCustomer, IDCustomerGroup).ID;
                }
                else
                {

                    aCustomerGroups_Customers.IDCustomer = IDCustomer;
                    aCustomerGroups_Customers.IDCustomerGroup = IDCustomerGroup;
                    aCustomerGroups_Customers.FromDate = From;
                    aCustomerGroups_Customers.Disable = false;
                    return this.Insert(aCustomerGroups_Customers);
                }
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception("CustomersBO.AutoInsertCustomer:" + ex.ToString());
            }
        }

        // Ngoc
        public int InsertCustomerIntoCustomerGroup_ByIDBookingRs(int IDCustomer, int IDBookingRs)
        {
            // Add customer vao group
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = new CustomerGroups();
            aCustomerGroups = aCustomerGroupsBO.Select_ByIDBookingR(IDBookingRs);

            CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
            //Kiem tra xe khach do da co trong custome group chua
            CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();
            aCustomerGroups_Customers = aCustomerGroups_CustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(IDCustomer, aCustomerGroups.ID);
            if (aCustomerGroups_Customers == null)
            {
                aCustomerGroups_Customers = new CustomerGroups_Customers();
                Customers aCustomers = (new CustomersBO()).Select_ByID(IDCustomer);
                aCustomerGroups_Customers.IDCustomer = IDCustomer;
                aCustomerGroups_Customers.IDCustomerGroup = aCustomerGroups.ID;
                aCustomerGroups_Customers.Name = aCustomerGroups.Name + "_" + aCustomers.Name + "_" + aCustomers.Identifier1 + "_" + DateTime.Now.ToShortDateString();
                return aCustomerGroups_CustomersBO.Insert(aCustomerGroups_Customers);
            }
            else
            {
                return 0;
            }
        }
        public int InsertCustomerIntoCustomerGroup(int IDCustomer, int IDCustomerGroup)
        {
            // Add customer vao group
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = new CustomerGroups();
            aCustomerGroups = aCustomerGroupsBO.Select_ByID(IDCustomerGroup);

            CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();
            CustomerGroups_Customers aCustomerGroups_Customers = new CustomerGroups_Customers();


            aCustomerGroups_Customers = aCustomerGroups_CustomersBO.Select_ByIDCustomer_ByIDCustomerGroup(IDCustomer, IDCustomerGroup);
            if (aCustomerGroups_Customers == null)
            {
                Customers aCustomers = (new CustomersBO()).Select_ByID(IDCustomer);
                aCustomerGroups_Customers.IDCustomer = IDCustomer;
                aCustomerGroups_Customers.IDCustomerGroup = aCustomerGroups.ID;
                aCustomerGroups_Customers.Name = aCustomerGroups.Name + "_" + aCustomers.Name + "_" + aCustomers.Identifier1 + "_" + DateTime.Now.ToShortDateString();
                return aCustomerGroups_CustomersBO.Insert(aCustomerGroups_Customers);
            }
            else
                return 0;



        }
        public int DeleteCustomerFromCustomerGroup_ByIDBookingRs(int IDCustomer, int IDBookingRs)
        {

            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = new CustomerGroups();
            aCustomerGroups = aCustomerGroupsBO.Select_ByIDBookingR(IDBookingRs);

            CustomerGroups_CustomersBO aCustomerGroups_CustomersBO = new CustomerGroups_CustomersBO();

            return aCustomerGroups_CustomersBO.Delete(IDCustomer, aCustomerGroups.ID);
        }
        public void DeleteAllCustomersFromCustomerGroup_ByIDBookingRs(int IDBookingRs)
        {
            CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();
            CustomerGroups aCustomerGroups = new CustomerGroups();
            aCustomerGroups = aCustomerGroupsBO.Select_ByIDBookingR(IDBookingRs);
            List<CustomerGroups_Customers> aCustomerGroups_Customers = this.Select_ByIDCustomerGroup(aCustomerGroups.ID);
            foreach (CustomerGroups_Customers item in aCustomerGroups_Customers)
            {
                this.Delete(item);
            }

        }


    }
}
