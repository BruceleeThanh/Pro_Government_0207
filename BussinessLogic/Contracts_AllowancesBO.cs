using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;
using Entity;
namespace BussinessLogic
{
    public class Contracts_AllowancesBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //Author :Hiennv
        public List<Contracts_Allowances> Select_All()
        {
            try
            {
                return aDatabaseDA.Contracts_Allowances.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Select_All :"+ ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public List<vw__ContractsInfo__SystemUsers_Contracts_Allowances> Select_ByContractsAllowances_Disable(bool Disalbe)
        {
            try
            {
                return aDatabaseDA.vw__ContractsInfo__SystemUsers_Contracts_Allowances.Where(c => c.Contracts_Allowances_Disable == Disalbe).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Select_ByContractsAllowances_Disable :"+ ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public Contracts_Allowances Select_ByID(int ID)
        {
            try
            {
                List<Contracts_Allowances> aListContracts_Allowances = aDatabaseDA.Contracts_Allowances.Where(c => c.ID == ID).ToList();
                if(aListContracts_Allowances.Count > 0)
                {
                    return aListContracts_Allowances[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }

        
        //Author : Hiennv
        public int Insert(Contracts_AllowancesEN aContracts_AllowancesEN)
        {
            try
            {
                Contracts_Allowances aContracts_Allowances = new Contracts_Allowances();

                aContracts_Allowances.RealSalaryPlus = aContracts_AllowancesEN.RealSalaryPlus;
                aContracts_Allowances.CreatedDate = DateTime.Now;
                aContracts_Allowances.ApplyDate = aContracts_AllowancesEN.ApplyDate;
                aContracts_Allowances.Type = aContracts_AllowancesEN.Type;
                aContracts_Allowances.Status = aContracts_AllowancesEN.Status;
                aContracts_Allowances.Disable = aContracts_AllowancesEN.Disable;

                for (int i = 0; i < aContracts_AllowancesEN.aListAllowances.Count; i++)
                {
                    aContracts_Allowances.IDAllowance = aContracts_AllowancesEN.aListAllowances[i].ID;
                    for (int j = 0; j < aContracts_AllowancesEN.aListAllowances[i].aListContracts.Count; j++)
                    {
                        aContracts_Allowances.IDContract = aContracts_AllowancesEN.aListAllowances[i].aListContracts[j].ID;
                        aDatabaseDA.Contracts_Allowances.Add(aContracts_Allowances);
                        return aDatabaseDA.SaveChanges();
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Insert :"+ ex.Message.ToString()));
            }
        }

        //Author : Hiennv
        public int Update(Contracts_Allowances aContracts_Allowances)
        {
            try
            {
                aDatabaseDA.Contracts_Allowances.AddOrUpdate(aContracts_Allowances);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Update :"+ ex.Message.ToString()));
            }
        }

        //Author :Hiennv
        public int Delete(int ID)
        {
            try
            {
                Contracts_Allowances aContracts_Allowances = this.Select_ByID(ID);
                aDatabaseDA.Contracts_Allowances.Remove(aContracts_Allowances);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Contracts_AllowancesBO.Delete :"+ ex.Message.ToString()));
            }
        }
        
    }
}
