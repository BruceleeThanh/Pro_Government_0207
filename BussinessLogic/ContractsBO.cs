using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;

namespace BussinessLogic
{
    public class ContractsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //Author :Hiennv
        public List<Contracts> Select_All()
        {
            try
            {
                return aDatabaseDA.Contracts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Select_All :"+ ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public Contracts Select_ByID(int ID)
        {
            try
            {
                List<Contracts> aListContracts = aDatabaseDA.Contracts.Where(c => c.ID == ID).ToList();
                if(aListContracts.Count > 0)
                {
                    return aListContracts[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }
       //Linhting
        public List<Contracts> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<Contracts> aListContracts = aDatabaseDA.Contracts.Where(c => c.IDSystemUser == IDSystemUser).ToList();
                if (aListContracts.Count > 0)
                {
                    return aListContracts;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Select_ByIDSystemUser :" + ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public List<Contracts> Select_ByFromDate_ByToDate(DateTime From,DateTime To )
        {
            try
            {
                return aDatabaseDA.Contracts.Where(c => c.CreatedDate >=From).Where(c => c.CreatedDate <= To).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Select_ByFromDate_ByToDate :"+ ex.Message.ToString()));
            }
        }


        //Author : Hiennv
        public int Insert(Contracts aContracts)
        {
            try
            {
                aDatabaseDA.Contracts.Add(aContracts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public int Update(Contracts aContracts)
        {
            try
            {
                aDatabaseDA.Contracts.AddOrUpdate(aContracts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public int Delete(int ID)
        {
            try
            {
                Contracts aContracts =this.Select_ByID(ID);
                aDatabaseDA.Contracts.Remove(aContracts);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Delete :"+ ex.Message.ToString()));
            }
        }
        //Author : Hiennv
        public List<Contracts> Select_ByIDAllowances(int IDAllowances)
        {
            try
            {
                List<sp_Contracts_GetCurrentHaveNotAllowances_Result> aListTemps = new List<sp_Contracts_GetCurrentHaveNotAllowances_Result>();
                aListTemps = aDatabaseDA.sp_Contracts_GetCurrentHaveNotAllowances(IDAllowances).ToList();
                List<Contracts> aListContracts = new List<Contracts>();
                for (int i = 0; i < aListTemps.Count; i++)
                {
                    Contracts aContracts = new Contracts();
                    aContracts.ID = aListTemps[i].ID;
                    aContracts.CreatedDate = aListTemps[i].CreatedDate;
                    aContracts.ContractDate = aListTemps[i].ContractDate;
                    aContracts.NumberContract = aListTemps[i].NumberContract;
                    aContracts.NumberTemplateContract = aListTemps[i].NumberTemplateContract;
                    aContracts.IDSystemUser = aListTemps[i].IDSystemUser;
                    aContracts.Company = aListTemps[i].Company;
                    aContracts.StatutoryRepresent = aListTemps[i].StatutoryRepresent;
                    aContracts.StatutoryRepresentGender = aListTemps[i].StatutoryRepresentGender;
                    aContracts.StatutoryRepresentIdentifier = aListTemps[i].StatutoryRepresentIdentifier;
                    aContracts.ContractType = aListTemps[i].ContractType;
                    aContracts.FromDate = aListTemps[i].FromDate;
                    aContracts.ToDate = aListTemps[i].ToDate;
                    aContracts.SkuTableSalary = aListTemps[i].SkuTableSalary;
                    aContracts.Coefficent = aListTemps[i].Coefficent;
                    aContracts.SalaryNet = aListTemps[i].SalaryNet;
                    aContracts.SalaryCross = aListTemps[i].SalaryCross;
                    aContracts.Type = aListTemps[i].Type;
                    aContracts.Status = aListTemps[i].Status;
                    aContracts.Disable = aListTemps[i].Disable;

                    aListContracts.Add(aContracts);
                }
                return aListContracts;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ContractsBO.Select_ByIDAllowances :"+ ex.Message.ToString()));
            }
        }
    }
}
