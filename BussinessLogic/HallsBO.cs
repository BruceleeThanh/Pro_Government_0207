using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic;
using DataAccess;

using Entity;

namespace BussinessLogic
{
    public class HallsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();



        // Author : Linhting
        public List<Halls> Select_All()
        {
            try
            {
                return aDatabaseDA.Halls.OrderByDescending(c => c.ID).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("HallsBO.Select_All:" + ex.ToString());
            }
        }

        // Author : Linhting
        public Halls Select_ByID(int IDHall)
        {
            try
            {
                List<Halls> aListHalls = aDatabaseDA.Halls.Where(a => a.ID == IDHall).ToList();
                if (aListHalls.Count > 0)
                {
                    return aListHalls[0];
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("HallsBO.Select_ByID:" + ex.ToString());
            }
        }
        // Author : Linhting
        public int Delete(int id)
        {
            try
            {
                Halls aHalls = aDatabaseDA.Halls.Find(id);
                aDatabaseDA.Halls.Remove(aHalls);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("HallsBO.Delete:" + ex.ToString());
            }

        }

      

        public string CreateHall(Halls aHall)
        {
            string result = "";
            try
            {
                aDatabaseDA.Halls.Add(aHall);
                aDatabaseDA.SaveChanges();
                result = " Thêm mới thành công";
            }
            catch (Exception ex)
            {
                result = "Lỗi hệ thống : " + ex.Message;
            }
            return result;
        }

        public string EditHall(int id, string sku, string intro, string info, int numstandard, int nummax, decimal costref)
        {
            string result = "";
            try
            {
                var hall = (from h in aDatabaseDA.Halls
                            where h.ID == id
                            select h).FirstOrDefault();

                if (hall != null)
                {
                    hall.Sku = sku;
                    hall.NumTableMax = nummax;
                    hall.NumTableStandard = numstandard;
                    hall.Intro = intro;
                    hall.Info = info;
                    hall.CostRef = costref;
                }

                aDatabaseDA.SaveChanges();
                result = " Thay đổi thành công";
            }
            catch (Exception ex)
            {


                result = "Lỗi hệ thống";
            }
            return result;
        }

        public List<Halls> SearchFreeHall(DateTime date, DateTime starTime, DateTime endTime)
        {
            List<Halls> freehall = new List<Halls>();
            try
            {
                int time1 = starTime.Hour;

                var busyhall = (from bh in aDatabaseDA.BookingHalls
                                join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                where bh.Date == date && (bh.StartTime.Value.Hours <= time1 && time1 <= bh.EndTime.Value.Hours)
                                select h.Sku).Distinct();

                freehall = (from h in aDatabaseDA.Halls
                                where !busyhall.Contains(h.Sku)
                                select h).Distinct().ToList();

   

            }
            catch (Exception ex)
            {


            }
            return freehall;
        }

        // Author : Linhting
        public int Insert(Halls aHalls)
        {
            try
            {
                aDatabaseDA.Halls.Add(aHalls);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("HallsBO.Insert:" + ex.ToString());
            }
        }

        // Author : Linhting
        public int Update(Halls aHalls)
        {
            try
            {
                aDatabaseDA.Halls.AddOrUpdate(aHalls);
                return aDatabaseDA.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception("HallsBO.Update:" + ex.ToString());
            }
        }

        // Author : NgocBM
        public Halls Select_ByCodeHall(string CodeHall, int IDLang)
        {
             HallsBO aHallsBO = new HallsBO();
             List<Halls> aList = aHallsBO.Select_All().Where(p => p.Code == CodeHall).Where(p => p.IDLang == IDLang).ToList();
             if (aList.Count > 0)
             {
                 return aList[0];
             }
             else
             {
                 return null;
             }
        }

        public HallExtStatusEN GetStatusHall(string CodeHall, DateTime now, bool IsLunarDate)
        {
            HallExtStatusEN aHallExtStatusEN = new HallExtStatusEN();
            Halls aHalls = this.Select_ByCodeHall(CodeHall, 1);
            if (aHalls != null)
            {
                aHallExtStatusEN = this.GetStatusHall(aHalls.ID, now,  IsLunarDate);
                return aHallExtStatusEN;
            }
            else
            {
                return null;
            }

        }
        public HallExtStatusEN GetStatusHall(int IDHall, DateTime now, bool IsLunarDate)
        {
            List<sp_HallExt_GetCurrentStatusHalls_ByIDHall_ByTime_Result> aList = this.aDatabaseDA.sp_HallExt_GetCurrentStatusHalls_ByIDHall_ByTime(IDHall, now, IsLunarDate).ToList();

            HallExtStatusEN aHallExtStatusEN = new HallExtStatusEN();

            if (aList.Count > 0)
            {
                for (int i = 0; i < aList.Count; i++)
                {
                    aHallExtStatusEN = new HallExtStatusEN();
                    aHallExtStatusEN.ID = aList[i].ID;


                    aHallExtStatusEN.CostRef = aList[i].CostRef;
                    aHallExtStatusEN.Code = aList[i].Code;
                    aHallExtStatusEN.Sku = aList[i].Sku;
                    aHallExtStatusEN.Note = aList[i].Note;
                    aHallExtStatusEN.Type = aList[i].Type;
                    aHallExtStatusEN.BookingHalls_ID = aList[i].BookingHalls_ID;

                    aHallExtStatusEN.BookingHs_BookingMoney = aList[i].BookingHs_BookingMoney;
                    aHallExtStatusEN.BookingHs_CustomerType = aList[i].BookingHs_CustomerType;
                    aHallExtStatusEN.BookingHs_ID = aList[i].BookingHs_ID;
                    aHallExtStatusEN.BookingHs_Subject = aList[i].BookingHs_Subject;


                    aHallExtStatusEN.Date = aList[i].Date;
                    aHallExtStatusEN.LunarDate = aList[i].LunarDate;
                    aHallExtStatusEN.StartTime = aList[i].StartTime;
                    aHallExtStatusEN.EndTime = aList[i].EndTime;
                    aHallExtStatusEN.Color = aList[i].Color;
                    aHallExtStatusEN.Companies_Name = aList[i].Companies_Name;
                    aHallExtStatusEN.CostRef = aList[i].CostRef;
                    aHallExtStatusEN.CustomerGroups_Name = aList[i].CustomerGroups_Name;
                    aHallExtStatusEN.Customers_Address = aList[i].Customers_Address;
                    aHallExtStatusEN.Customers_Name = aList[i].Customers_Name;
                    aHallExtStatusEN.Customers_Nationality = aList[i].Customers_Nationality;
                    aHallExtStatusEN.Customers_Tel = aList[i].Customers_Tel;
                    //aHallExtStatusEN.Code = aList[i].Code;
   
                       aHallExtStatusEN.Location = aList[i].Location;
                       aHallExtStatusEN.NumTableMax = aList[i].NumTableMax;
                       aHallExtStatusEN.NumTableStandard = aList[i].NumTableStandard;
                       aHallExtStatusEN.Unit = aList[i].Unit;
                       aHallExtStatusEN.TableOrPerson = aList[i].TableOrPerson; 


                    if (aList[i].BookingHalls_Status == 1)
                    {
                        aHallExtStatusEN.HallStatus = 1;
                    }
                    else if (aList[i].BookingHalls_Status == 2)
                    {
                        aHallExtStatusEN.HallStatus = 2;
                    }
                    else if (aList[i].BookingHalls_Status == 3)
                    {
                        aHallExtStatusEN.HallStatus = 3;
                    }
                    else if (aList[i].BookingHalls_Status == 4)
                    {
                        aHallExtStatusEN.HallStatus = 4;
                    }
                    else if (aList[i].BookingHalls_Status == 5)
                    {
                        aHallExtStatusEN.HallStatus = 5;
                    }
                    else if (aList[i].BookingHalls_Status == 6)
                    {
                        aHallExtStatusEN.HallStatus = 6;
                    }
                    else if ((aList[i].BookingHalls_Status == 7) || (aList[i].BookingHalls_Status == 8))
                    {
                        aHallExtStatusEN.HallStatus = 0;
                    }

                }
                return aHallExtStatusEN;
            }
            else
            {
                HallsBO aHallsBO = new HallsBO();
                Halls aHalls = aHallsBO.Select_ByID(IDHall);
                if (aHalls != null)
                {
                    aHallExtStatusEN = new HallExtStatusEN();
                    aHallExtStatusEN.HallStatus = 0;
                    aHallExtStatusEN.Code = aHalls.Code;
                    aHallExtStatusEN.Sku = aHalls.Sku;

                    aHallExtStatusEN.Type = aHalls.Type;

                    aHallExtStatusEN.CostRef = aHalls.CostRef;
                    aHallExtStatusEN.Code = aHalls.Code;
                    aHallExtStatusEN.Sku = aHalls.Sku;

                    aHallExtStatusEN.Type = aHalls.Type;

                    aHallExtStatusEN.CostRef = aHalls.CostRef;
                    aHallExtStatusEN.NumTableMax = aHalls.NumTableMax;
                    aHallExtStatusEN.NumTableStandard = aHalls.NumTableStandard;


                }
                else
                {
                    throw new Exception("Hội trường cần check trạng thái không tồn tại");

                }
                return aHallExtStatusEN;

            }
        }

        public List<HallExtStatusEN> GetListStatusHall(DateTime now, bool IsLunarDate)
        {
            HallsBO aHallsBO = new HallsBO();
            List<Halls> aList = aHallsBO.Select_All().Where(p => p.IDLang == 1).ToList();
            List<HallExtStatusEN> ret = new List<HallExtStatusEN>();
            for (int i = 0; i < aList.Count; i++)
            {
                try
                {
                    ret.Add(this.GetStatusHall(aList[i].ID, now, IsLunarDate));
                }
                catch (Exception e)
                {
                    throw new Exception("Có lỗi khi lấy trạng thái hội trường " + aList[i].ID.ToString() + "-" + aList[i].Sku + "|" + e.Message.ToString());
                }
            }
            return ret;
        }



    }
}
