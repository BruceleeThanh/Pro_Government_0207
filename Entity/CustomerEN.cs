using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Entity
{
    public class CustomerEN : Customers
    {
        public int IDCompany { get; set; }
        public string NameCompany { get; set; }
        public int IDGroup { get; set; }
        public string NameGroup { get; set; }
        public string SkuRoom { get; set; }
        public string CodeRoom { get; set; }

        public string GenderDisplay { get; set; }
        public string NationalityDisplay { get; set; }
        public string CitizenDisplay { get; set; }
        public void SetValue(Customers aCustomers)
        {
            this.ID = aCustomers.ID;
            this.Name = aCustomers.Name;
            this.Identifier1 = aCustomers.Identifier1;
            this.Identifier1CreatedDate = aCustomers.Identifier1CreatedDate;
            this.Identifier2 = aCustomers.Identifier2;
            this.Identifier2CreatedDate = aCustomers.Identifier2CreatedDate;
            this.Identifier3 = aCustomers.Identifier3;
            this.Identifier3CreatedDate = aCustomers.Identifier3CreatedDate;
            this.Nationality = aCustomers.Nationality;
            this.Birthday = aCustomers.Birthday;
            this.Tel = aCustomers.Tel;
            this.Address = aCustomers.Address;
            this.Email = aCustomers.Email;
            this.Info = aCustomers.Info;
            this.Note = aCustomers.Note;
            this.Description = aCustomers.Description;
            this.Status = aCustomers.Status;
            this.Type = aCustomers.Type;
            this.Disable = aCustomers.Disable;
            this.Gender = aCustomers.Gender;
            this.Citizen = aCustomers.Citizen;
            this.PlaceOfIssue1 = aCustomers.PlaceOfIssue1;
            this.PlaceOfIssue2 = aCustomers.PlaceOfIssue2;
            this.PlaceOfIssue3 = aCustomers.PlaceOfIssue3;
        }
    }

}
