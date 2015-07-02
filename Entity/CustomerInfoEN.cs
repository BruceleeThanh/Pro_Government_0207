using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class CustomerInfoEN : Customers
    {
        public CustomerInfoEN()
        {
            Customers aItem = new Customers();

            this.Address = aItem.Address;
            this.Birthday = aItem.Birthday;
            this.Citizen = aItem.Citizen;

            this.Description = aItem.Description;
            this.Disable = aItem.Disable;
            this.Email = aItem.Email;
            this.Gender = aItem.Gender;
            this.ID = aItem.ID;
            this.Identifier1 = aItem.Identifier1;
            this.Identifier2 = aItem.Identifier2;
            this.Identifier3 = aItem.Identifier3;
            this.Identifier1CreatedDate = aItem.Identifier1CreatedDate;
            this.Identifier2CreatedDate = aItem.Identifier2CreatedDate;
            this.Identifier3CreatedDate = aItem.Identifier3CreatedDate;

            this.Info = aItem.Info;
            this.Name = aItem.Name;
            this.Nationality = aItem.Nationality;
            this.Note = aItem.Note;

            this.PlaceOfIssue1 = aItem.PlaceOfIssue1;
            this.PlaceOfIssue2 = aItem.PlaceOfIssue2;
            this.PlaceOfIssue3 = aItem.PlaceOfIssue3;

            this.Status = aItem.Status;
            this.Tel = aItem.Tel;
            this.Type = aItem.Type;

        }
        public CustomerInfoEN(Customers aItem)
        {
            this.Address = aItem.Address;
            this.Birthday = aItem.Birthday;
            this.Citizen = aItem.Citizen;

            this.Description = aItem.Description;
            this.Disable = aItem.Disable;
            this.Email = aItem.Email;
            this.Gender = aItem.Gender;
            this.ID = aItem.ID;
            this.Identifier1 = aItem.Identifier1;
            this.Identifier2 = aItem.Identifier2;
            this.Identifier3 = aItem.Identifier3;
            this.Identifier1CreatedDate = aItem.Identifier1CreatedDate;
            this.Identifier2CreatedDate = aItem.Identifier2CreatedDate;
            this.Identifier3CreatedDate = aItem.Identifier3CreatedDate;

            this.Info = aItem.Info;
            this.Name = aItem.Name;
            this.Nationality = aItem.Nationality;
            this.Note = aItem.Note;

            this.PlaceOfIssue1 = aItem.PlaceOfIssue1;
            this.PlaceOfIssue2 = aItem.PlaceOfIssue2;
            this.PlaceOfIssue3 = aItem.PlaceOfIssue3;

            this.Status = aItem.Status;
            this.Tel = aItem.Tel;
            this.Type = aItem.Type;


        }
        public int IDBookingRoom { get; set; }
        public string RoomCode { get; set; }
        public string PurposeComeVietnam { get; set; }
        public Nullable<System.DateTime> DateEnterCountry { get; set; }
        public string EnterGate { get; set; }
        public Nullable<System.DateTime> TemporaryResidenceDate { get; set; }
        public Nullable<System.DateTime> LeaveDate { get; set; }
        public string Organization { get; set; }
        public Nullable<System.DateTime> LimitDateEnterCountry { get; set; }
        //Hiennv        bo xung them truong de hien thi nguoi duoc chon lam dai dien
        public Nullable<bool> PepoleRepresentative { get; set; }
    }
}
