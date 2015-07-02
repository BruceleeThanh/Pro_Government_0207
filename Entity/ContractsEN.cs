using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class ContractsEN:Contracts
    {
        public string Name { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Identifier1 { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Phone { get; set; }
        public string DisplayContractType { get; set; }
        public string DisplayGender { get; set; }
        public void SetValue(Contracts aContracts)
        {
            this.ID = aContracts.ID;
            this.CreatedDate = aContracts.CreatedDate;
            this.ContractDate = aContracts.ContractDate;
            this.NumberContract = aContracts.NumberContract;
            this.NumberTemplateContract = aContracts.NumberTemplateContract;
            this.IDSystemUser = aContracts.IDSystemUser;
            this.Company = aContracts.Company;
            this.StatutoryRepresent = aContracts.StatutoryRepresent;
            this.StatutoryRepresentGender = aContracts.StatutoryRepresentGender;
            this.StatutoryRepresentIdentifier = aContracts.StatutoryRepresentIdentifier;
            this.ContractType = aContracts.ContractType;
            this.FromDate = aContracts.FromDate;
            this.ToDate = aContracts.ToDate;
            this.SkuTableSalary = aContracts.SkuTableSalary;
            this.Coefficent = aContracts.Coefficent;
            this.SalaryNet = aContracts.SalaryNet;
            this.SalaryCross = aContracts.SalaryCross;
            this.Type = aContracts.Type;
            this.Status = aContracts.Status;
            this.Disable = aContracts.Disable;

        }
    }
}
