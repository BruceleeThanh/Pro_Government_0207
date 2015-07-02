using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BussinessLogic;
using DataAccess;
using Entity;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class BookingHallsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        private HelperClass aHelperClass = new HelperClass();


        public string UpdateBookingStatus(int id, int status)
        {
            string result = "";
            try
            {
                var bh = (from b in aDatabaseDA.BookingHalls
                          where b.ID == id
                          select b).FirstOrDefault();
                bh.BookingStatus = status;
                aDatabaseDA.SaveChanges();
                result = "Cập nhật thành công";
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.UpdateBookingStatus\n" + ex.ToString());
            }
            return result;
        }
        // Tạo ra list khách hàng đã đặt tiệc
        public DataTable CreateListUserOrder()
        {
            var dt = new DataTable();
            try
            {

                var result = from c in aDatabaseDA.Customers
                             select new
                             {
                                 CDVAL = c.ID,
                                 CDCONTENT = c.Name,
                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.CreateListUserOrder\n" + ex.ToString());
            }

            return dt;
        }

        //Tạo list khách mời đã dự tiệc
        public DataTable CreateListGuest()
        {
            var dt = new DataTable();
            try
            {
                var result = from g in aDatabaseDA.Guests
                             select new
                             {
                                 CDVAL = g.ID,
                                 CDCONTENT = g.Name
                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.CreateListGuest\n" + ex.ToString());
            }
            return dt;
        }

        // List danh sách các buổi liệc (tra cứu)
        public DataTable SearchBookingHall(string type, string ownername, string status, string level, DateTime fromdate, DateTime todate)
        {
            var dt = new DataTable();
            try
            {
                //Cách này rất nông dân, nhưng chưa tìm ra giải pháp tối ưu

                if (string.IsNullOrEmpty(status) && string.IsNullOrEmpty(level) && string.IsNullOrEmpty(type))
                {
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 //join g in db.Guests on bhs.IDGuest equals g.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                    c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,

                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(status) && string.IsNullOrEmpty(level))
                {
                    var _type = Convert.ToInt32(type);
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 // join g in db.Guests on bhs.IDGuest equals g.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                    c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bhs.CustomerType == _type
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(status) && string.IsNullOrEmpty(type))
                {
                    var _level = Convert.ToInt32(level);
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                     c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bhs.Level == Convert.ToInt32(_level)
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(level) && string.IsNullOrEmpty(type))
                {
                    var _status = Convert.ToInt32(status);
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bh.BookingStatus == _status
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(status))
                {
                    var _level = Convert.ToInt32(level);
                    var _type = Convert.ToInt32(type);
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                     c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bhs.CustomerType == _type && bhs.Level == _level
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(level))
                {
                    var _status = Convert.ToInt32(status);
                    var _type = Convert.ToInt32(type);
                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                     c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bh.BookingStatus == _status && bhs.CustomerType == _type
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

                else if (string.IsNullOrEmpty(type))
                {
                    var _status = Convert.ToInt32(status);
                    var _level = Convert.ToInt32(level);

                    var result = from bh in aDatabaseDA.BookingHalls
                                 join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                 join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                 join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                 join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                 where
                                   c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                     bh.Date <= todate && bh.BookingStatus == _status && bhs.Level == _level
                                 //&& SqlMethods.Like(bh.BookingStatus.ToString(), status) &&
                                 //SqlMethods.Like(bhs.Level.ToString(), level) && SqlMethods.Like(bhs.Type.ToString(), type)
                                 select new
                                 {
                                     BookingHallId = bh.ID,
                                     BookingHsId = bhs.ID,
                                     CustomerName = c.Name,
                                     bh.Date,
                                     bh.LunarDate,
                                     GroupName = cg.Name,
                                     bh.StartTime,
                                     bh.EndTime,
                                     bhs.BookingType,
                                     h.Sku,
                                     bhs.StatusPay,
                                     BhStatus = bh.BookingStatus,
                                     bhs.CustomerType,
                                     bhs.Level,
                                     bhs.Note,
                                 };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }
                else
                {
                    var _status = Convert.ToInt32(status);
                    var _level = Convert.ToInt32(level);
                    var _type = Convert.ToInt32(type); var result = from bh in aDatabaseDA.BookingHalls
                                                                    join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                                                                    join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                                                                    join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                                                                    join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                                                                    where
                                                                      c.Name.Contains(ownername) && bh.Date >= fromdate &&
                                                                        bh.Date <= todate && bh.BookingStatus == _status && bhs.Level == _level && bhs.CustomerType == _type
                                                                    //&& SqlMethods.Like(bh.BookingStatus.ToString(), status) &&
                                                                    //SqlMethods.Like(bhs.Level.ToString(), level) && SqlMethods.Like(bhs.Type.ToString(), type)
                                                                    select new
                                                                    {
                                                                        BookingHallId = bh.ID,
                                                                        BookingHsId = bhs.ID,
                                                                        CustomerName = c.Name,
                                                                        bh.Date,
                                                                        bh.LunarDate,
                                                                        GroupName = cg.Name,
                                                                        bh.StartTime,
                                                                        bh.EndTime,
                                                                        bhs.BookingType,
                                                                        h.Sku,
                                                                        bhs.StatusPay,
                                                                        BhStatus = bh.BookingStatus,
                                                                        bhs.CustomerType,
                                                                        bhs.Level,
                                                                        bhs.Note,
                                                                    };
                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.SearchBookingHall\n" + ex.ToString());
            }

            return dt;
        }

        // Chỉnh sửa thông tin buổi tiệc
        public string EditBookingHall()
        {
            string result;
            try
            {
                result = "Thay đổi thành công";
            }
            catch (Exception ex)
            {


                result = "Lỗi hệ thống";
            }
            return result;
        }

        //Xem thông tin chi tiết buổi tiệc
        public DataTable BookingHallDetail(int id)
        {
            var dt = new DataTable();
            try
            {
                var result = from bh in aDatabaseDA.BookingHalls
                             join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                             join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                             join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                             join g in aDatabaseDA.Guests on bhs.IDGuest equals g.ID
                             join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                             where
                                bh.ID == id
                             select new
                             {
                                 BookingHallId = bh.ID,
                                 CustomerName = c.Name,
                                 bh.Date,
                                 bh.LunarDate,
                                 GroupName = cg.Name,
                                 bh.StartTime,
                                 bh.EndTime,
                                 bhs.BookingType,
                                 bhs.Status,
                                 h.Sku,
                                 bhs.StatusPay,
                                 HsStatus = bhs.Status
                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.BookingHallDetail\n" + ex.ToString());
            }
            return dt;
        }

        //Lấy danh sách món ăn của bữa tiệc
        public DataTable GetMenuFood(int bookinghallId)
        {
            var dt = new DataTable();
            try
            {
                var result = from bh in aDatabaseDA.BookingHalls
                             join m in aDatabaseDA.Menus on bh.ID equals m.IDBookingHall
                             join mf in aDatabaseDA.Menus_Foods on m.ID equals mf.IDMenu
                             join f in aDatabaseDA.Foods on mf.IDFood equals f.ID
                             join su in aDatabaseDA.SystemUsers on m.IDSystemUser equals su.ID


                             where bh.ID == bookinghallId
                             select new
                             {
                                 f.Name,
                                 f.Name1,
                                 f.Name2,
                                 f.Name3,
                                 f.Tag,
                                 f.Note,
                                 UserName = su.Name
                             };

                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetMenuFood\n" + ex.ToString());
            }
            return dt;
        }

        // Lấy danh sách dịch vụ của bữa tiệc
        public DataTable GetService(int bookinghallId)
        {
            var dt = new DataTable();
            try
            {
                var result = from bh in aDatabaseDA.BookingHalls
                             join bhs in aDatabaseDA.BookingHalls_Services on bh.ID equals bhs.IDBookingHall
                             join sv in aDatabaseDA.Services on bhs.IDService equals sv.ID
                             where bh.ID == bookinghallId
                             select new
                             {
                                 sv.Name,
                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetService\n" + ex.ToString());
            }
            return dt;
        }
        //----------------------------------------------------------------------------------------
        //Lấy danh sách các bữa tiệc mới/ chưa có menu tại form chính(1 tiệc mới, 2 tiệc chưa có menu )
        public DataTable GetNewfeedBooking(int bookingstatus)
        {
            var dt = new DataTable();
            try
            {
                var result = from bh in aDatabaseDA.BookingHalls
                             join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                             join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                             join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                             //join g in db.Guests on bhs.IDGuest equals g.ID
                             join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                             where bh.BookingStatus == bookingstatus && bhs.Status != 5 && bhs.Status != 7 && bhs.Status != 8
                             select new
                             {
                                 BookingHallId = bh.ID,
                                 BookingHsId = bhs.ID,
                                 CustomerName = c.Name,
                                 bh.Date,
                                 bh.LunarDate,
                                 GroupName = cg.Name,
                                 bh.StartTime,
                                 bh.EndTime,
                                 bhs.BookingType,
                                 h.Sku,
                                 bhs.StatusPay,
                                 BhStatus = bh.BookingStatus,
                                 bhs.CustomerType,
                                 bhs.Level,
                                 bhs.Note,

                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetNewfeedBooking\n" + ex.ToString());
            }

            return dt;
        }

        //Lấy danh sách những bữa tiệc theo loại khách hàng
        public DataTable GetCompanyBooking(int type)
        {
            var dt = new DataTable();
            try
            {
                var result = from bh in aDatabaseDA.BookingHalls
                             join bhs in aDatabaseDA.BookingHs on bh.IDBookingH equals bhs.ID
                             join c in aDatabaseDA.Customers on bhs.IDCustomer equals c.ID
                             join cg in aDatabaseDA.CustomerGroups on bhs.IDCustomerGroup equals cg.ID
                             // join g in db.Guests on bhs.IDGuest equals g.ID
                             join h in aDatabaseDA.Halls on bh.CodeHall equals h.Code
                             where bhs.CustomerType == type
                             select new
                             {
                                 BookingHallId = bh.ID,
                                 BookingHsId = bhs.ID,
                                 CustomerName = c.Name,
                                 bh.Date,
                                 bh.LunarDate,
                                 GroupName = cg.Name,
                                 bh.StartTime,
                                 bh.EndTime,
                                 bhs.BookingType,
                                 h.Sku,
                                 bhs.StatusPay,
                                 BhStatus = bh.BookingStatus,
                                 bhs.CustomerType,
                                 bhs.Level,
                                 bhs.Note,

                             };
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetCompanyBooking\n" + ex.ToString());
            }
            return dt;
        }



        public bool CreateBookingHs(DateTime createdate, int cusomertype, int bookingtype, string note, int paymethod,
            int statuspay, decimal bookingmoney, int sysuserid, int guestid, int customerid, int groupid, int level, string subject, int status)
        {
            try
            {
                var bhs = new BookingHs
                          {
                              CreatedDate = createdate,
                              CustomerType = cusomertype,
                              BookingType = bookingtype,
                              Note = note,
                              PayMenthod = paymethod,
                              StatusPay = statuspay,
                              BookingMoney = bookingmoney,
                              IDSystemUser = sysuserid,
                              IDGuest = guestid,
                              IDCustomer = customerid,
                              IDCustomerGroup = groupid,
                              Subject = subject,
                              Level = level
                          };
                aDatabaseDA.BookingHs.Add(bhs);
                aDatabaseDA.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.CreateBookingHs\n" + ex.ToString());
                return false;
            }

        }

        public int GetCreatedBookingHsId()
        {
            int id = 0;
            try
            {
                id = (from hs in aDatabaseDA.BookingHs
                      orderby hs.ID descending
                      select hs.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetCreatedBookingHsId\n" + ex.ToString());
            }
            return id;
        }

        //public string CreateBookingHall(string codehall, decimal cost, DateTime date, DateTime lunardate,
        //    int bookingstatus, int tableorpersion, DateTime starttime, DateTime endtime, int bookinghsid)
        //{
        //    string result = "";
        //    try
        //    {
        //        var bh = new BookingHalls
        //                 {
        //                     CodeHall = codehall,
        //                     Cost = cost,
        //                     Date = date,
        //                     LunarDate = lunardate,
        //                     BookingStatus = bookingstatus,
        //                     TableOrPerson = tableorpersion,
        //                     StartTime = starttime,
        //                     EndTime = endtime,
        //                     IDBookingH = bookinghsid
        //                 };
        //        aDatabaseDA.BookingHalls.Add(bh);
        //        aDatabaseDA.SaveChanges();
        //        result = "Đặt tiệc thành công";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("BookingHallsBO.CreateBookingHall\n" + ex.ToString());
        //    }
        //    return result;
        //}

        public int GetCreatedBookingHallId()
        {
            int id = 0;
            try
            {
                id = (from bh in aDatabaseDA.BookingHalls
                      orderby bh.ID descending
                      select bh.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.GetCreatedBookingHallId\n" + ex.ToString());
            }
            return id;
        }
        public List<BookingHalls> Select_ByRankTime(DateTime From, DateTime To, bool IsLunarDate)
        {
            try
            {
                HallsBO aHallBO = new HallsBO();

                List<BookingHalls> aList = new List<BookingHalls>();
                if (IsLunarDate == false)
                {

                    return aDatabaseDA.BookingHalls.Where(p => p.Date <= To).Where(p => p.Date >= From).ToList();
                }
                else
                {
                    return aDatabaseDA.BookingHalls.Where(p => p.LunarDate <= To).Where(p => p.LunarDate >= From).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.Select_ByRankTime:" + ex.ToString());
            }
        }
        public List<HallExtStatusEN> GetStatusBookingHalls(DateTime From, DateTime To, bool IsLunarDate)
        {
            List<sp_HallExt_GetStatusBookingHalls_ByRankTime_Result> aList = this.aDatabaseDA.sp_HallExt_GetStatusBookingHalls_ByRankTime(From, To, IsLunarDate).ToList();

            List<HallExtStatusEN> aList_HallExtStatusEN = new List<HallExtStatusEN>();
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
                    else if ( (aList[i].BookingHalls_Status == 7) || (aList[i].BookingHalls_Status == 8))
                    {
                        aHallExtStatusEN.HallStatus = 0;
                    }
                    aList_HallExtStatusEN.Add(aHallExtStatusEN);
                }

            }

            return aList_HallExtStatusEN.Where(p => p.HallStatus > 0).ToList(); //Loai cac hoi truong Avail
        }
        public HallExtStatusEN GetStatusHall(string CodeHall, DateTime CheckPoint, bool IsLunarDate)
        {
            HallsBO aHallsBO = new HallsBO();
            HallExtStatusEN aHallExtStatusEN = new HallExtStatusEN();
            Halls aHalls = aHallsBO.Select_ByCodeHall(CodeHall, 1);
            if (aHalls != null)
            {
                aHallExtStatusEN = this.GetStatusHall(aHalls.ID, CheckPoint, IsLunarDate);
                return aHallExtStatusEN;
            }
            else
            {
                return null;
            }

        }
        public HallExtStatusEN GetStatusHall(int IDHall, DateTime CheckPoint, bool IsLunarDate)
        {
            List<sp_HallExt_GetCurrentStatusHalls_ByIDHall_ByTime_Result> aList = this.aDatabaseDA.sp_HallExt_GetCurrentStatusHalls_ByIDHall_ByTime(IDHall, CheckPoint, IsLunarDate).ToList();

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
                    else if ( (aList[i].BookingHalls_Status == 7) || (aList[i].BookingHalls_Status == 8))
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

        public List<HallExtStatusEN> GetListStatusHall(DateTime CheckPoint, bool IsLunarDate)
        {
            HallsBO aHallsBO = new HallsBO();
            List<Halls> aList = aHallsBO.Select_All().Where(p => p.IDLang == 1).ToList();
            List<HallExtStatusEN> ret = new List<HallExtStatusEN>();
            for (int i = 0; i < aList.Count; i++)
            {
                try
                {
                    ret.Add(this.GetStatusHall(aList[i].ID, CheckPoint, IsLunarDate));
                }
                catch (Exception e)
                {
                    throw new Exception("Có lỗi khi lấy trạng thái hội trường " + aList[i].ID.ToString() + "-" + aList[i].Sku + "|" + e.Message.ToString());
                }
            }
            return ret;
        }

        //Author: Linhting
        public int Insert(BookingHalls bookingHalls)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                aDatabaseDA.BookingHalls.Add(bookingHalls);
                aBookingHsBO.AutoChangeStatusBookingH(bookingHalls.IDBookingH);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.Insert:" + ex.ToString());
            }
        }


        //Author: Linhting
        public int Update(BookingHalls bookingHalls)
        {
            try
            {
                BookingHsBO aBookingHsBO = new BookingHsBO();
                aDatabaseDA.BookingHalls.AddOrUpdate(bookingHalls);
                aBookingHsBO.AutoChangeStatusBookingH(bookingHalls.IDBookingH);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.Update:" + ex.ToString());
            }
        }

        //Author: Linhting
        public int Delete(int id)
        {
            try
            {
                BookingHalls aBookingHalls = aDatabaseDA.BookingHalls.Find(id);
                aDatabaseDA.BookingHalls.Remove(aBookingHalls);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHalls.Delete:" + ex.ToString());
            }
        }

        public void DeleteListBookingHalls(int IDBookingH)
        {
            try
            {
                List<BookingHalls> aList = this.Select_ByIDBookigH(IDBookingH);
                for (int i = 0; i < aList.Count; i++)
                { 
                    this.Delete(aList[i].ID);
                }
                aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHalls.DeleteListBookingHalls:" + ex.ToString());
            }
        }
        //Hiennv
        public BookingHalls Select_ByID(int ID)
        {
            try
            {
                List<BookingHalls> aListBookingHalls = aDatabaseDA.BookingHalls.Where(bh=>bh.ID==ID).ToList();
                if (aListBookingHalls.Count > 0)
                {
                    return aListBookingHalls[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHalls.Select_ByID:" + ex.ToString());
            }
        }

        //Author: Linhting
        public List<BookingHalls> Select_ByIDBookigH(int IDBookingH)
        {
            try
            {
               return aDatabaseDA.BookingHalls.Where(a => a.IDBookingH == IDBookingH).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.Select_ByIDBookigH:" + ex.ToString());
            }
        }

        //Author: Linhting
        public void AutoChangeStatusBookingHalls(int IDBookingH)
        {
            BookingHsBO aBookingHsBO = new BookingHsBO();
            BookingHallsBO aBookingHallsBO = new BookingHallsBO();
            List<BookingHalls> aListBookingHalls = aBookingHallsBO.Select_ByIDBookigH(IDBookingH);
            int Status = Convert.ToInt32( aBookingHsBO.Select_ByID(IDBookingH).Status);
            for (int i = 0; i < aListBookingHalls.Count; i++)
            {
                aListBookingHalls[i].Status = Status;
                aBookingHallsBO.UpdateUnSync(aListBookingHalls[i]);
            }
        }

        //Author: Linhting
        public void InsertUnSync(BookingHalls bookingHalls)
        {
            try
            {
                aDatabaseDA.BookingHalls.Add(bookingHalls);
                aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.InsertUnSync:" + ex.ToString());
            }
        }
        //Author: Linhting
        public void UpdateUnSync(BookingHalls bookingHalls)
        {
            try
            {
                aDatabaseDA.BookingHalls.AddOrUpdate(bookingHalls);
                aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.UpdateUnSync:" + ex.ToString());
            }
        }
        //Hiennv
        public List<BookingHalls> Select_ByIDBookingH_ByStatus(int IDBookingH, int Status)
        {
            try
            {
                return aDatabaseDA.BookingHalls.Where(b => b.IDBookingH == IDBookingH && b.Status != Status).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("BookingHallsBO.Select_ByIDBookingH_ByStatus:" + ex.ToString());
            }
        }
    }
}
