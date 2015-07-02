using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    //Hiennv        tao moi         09/12/2014            Them moi entity de chua du lieu thuc hien nghiep vu chuyen phong
    public class ChangeRoomInformationEN
    {
        public int IDBookingR { get; set; }
        public int IDBookingRoom { get; set; }
        public string CodeRoom { get; set; }
        public string Representative { get; set; }
        public string Tel { get; set; }
        public System.DateTime CheckInActual { get; set; }
        public System.DateTime CheckOutPlan { get; set; }
        public string CustomerType { get; set; }
        public int IDCompany { get; set; }
        public string NameCompany { get; set; }
        public int IDGroup { get; set; }
        public string NameGroup { get; set; }

        public List<Customers> aListAvailableCustomers = new List<Customers>();
        public List<CustomerInfoEN> aListCustomersInRoom = new List<CustomerInfoEN>();
        public List<RoomsEN> aListAvailableRooms = new List<RoomsEN>();

        //Hiennv         tao moi        10/12/2014            xoa 1 customer ra khoi phong
        public void DeleteCustomerInfoInRoom(int IDBookingRoom, int IDCustomer)
        {
            try
            {
                List<CustomerInfoEN> aListCustomerInfoEN = this.aListCustomersInRoom.Where(r => r.IDBookingRoom == IDBookingRoom && r.ID == IDCustomer).ToList();
                if (aListCustomerInfoEN.Count > 0)
                {
                    this.aListCustomersInRoom.Remove(aListCustomerInfoEN[0]);
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        //Hiennv         tao moi        10/12/2014            them 1 customer vao phong
        public void InsertCustomerInfoInRoom(CustomerInfoEN aCustomerInfoEN)
        {
            try
            {
                  this.aListCustomersInRoom.Insert(0,aCustomerInfoEN);
            }
            catch (Exception ex)
            {
 
            }
        }
        //Hiennv         tao moi        10/12/2014            kiem tra xem customer co ton tai trong phong khong
        public bool CheckCustomerInfoExistInRoom(int IDBookingRoom, int IDCustomer)
        {
            try
            {
                List<CustomerInfoEN> aListCustomerInfoEN = this.aListCustomersInRoom.Where(r => r.IDBookingRoom == IDBookingRoom && r.ID == IDCustomer).ToList();
                if (aListCustomerInfoEN.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Hiennv         tao moi        10/12/2014            xoa 1 customer
        public void DeleteCustomer(int IDCustomer)
        {
            try
            {
                List<Customers> aListCustomers = this.aListAvailableCustomers.Where(c => c.ID == IDCustomer).ToList();
                if (aListCustomers.Count > 0)
                {
                    this.aListAvailableCustomers.Remove(aListCustomers[0]);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
