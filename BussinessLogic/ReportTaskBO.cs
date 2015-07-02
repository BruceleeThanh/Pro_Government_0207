using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;

namespace BussinessLogic
{
    
    public class ReportTaskBO
    {
        DatabaseDA aDatabaseDA = new DatabaseDA();
        BookingRoomsBO aBookingRoomsBO = new BookingRoomsBO();
        BookingRoomsMembersBO aBookingRoomsMembersBO = new BookingRoomsMembersBO();
        CustomersBO aCustomersBO = new CustomersBO();
        RoomsBO aRoomsBO = new RoomsBO();
        CompaniesBO aCompaniesBO = new CompaniesBO();
        BookingRsBO aBookingRsBO = new BookingRsBO();
        CustomerGroupsBO aCustomerGroupsBO = new CustomerGroupsBO();

        //=======================================================
        //Author: Ngoc
        //Function :
        //=======================================================
        public List<List<RptRoomStatusEN>> RoomsPerformanceInMonth(DateTime aDate)
        {
            List<sp_Get_Status_ListRooms_In_Month_Result> aList = aDatabaseDA.sp_Get_Status_ListRooms_In_Month(aDate.Date).ToList();
            RoomsBO aRoomsBO = new RoomsBO();
            List<RptRoomStatusEN> aRet = new List<RptRoomStatusEN>();
            List<List<RptRoomStatusEN>> aRet2 = new List<List<RptRoomStatusEN>>();


            for (int i = 1; i <= DateTime.DaysInMonth(aDate.Year, aDate.Month); i++)
            {
                aRet2.Add(GetTextInReport(aList, i, aRoomsBO.Select_ByIDLang(1).ToList()));
            }
            return aRet2;
        }

        private List<RptRoomStatusEN> GetTextInReport(List<sp_Get_Status_ListRooms_In_Month_Result> aListData, int Day, List<Rooms> aListAllRoom)
        {

            List<sp_Get_Status_ListRooms_In_Month_Result> tempt = new List<sp_Get_Status_ListRooms_In_Month_Result>();
            List<RptRoomStatusEN> ListRet = new List<RptRoomStatusEN>();
            RptRoomStatusEN retItem = new RptRoomStatusEN();

            for (int i = 0; i < aListAllRoom.Count; i++)
            {
                tempt = new List<sp_Get_Status_ListRooms_In_Month_Result>();
                tempt = aListData.Where(p => p.Rooms_Code == aListAllRoom[i].Code).Where(p => p.DayIndex == Day).ToList();

                retItem = new RptRoomStatusEN();
                retItem.DateIndex = Day;
                if (tempt.Count <= 0)
                {
                    retItem.RoomSku = aListAllRoom[i].Sku;
                    ListRet.Insert(ListRet.Count, retItem);
                }
                if (tempt.Count > 0)
                {
                    retItem.RoomSku = tempt[0].Rooms_Sku;
                    for (int ii = 0; ii < tempt.Count; ii++)
                    {
                        ReturnNumberCustomer(tempt[ii], ref retItem); // Xac dinh chu T/t, B/b 
                        // Kiem tra neu la ngay dau tien checkIn thi set den viec di som
                        if (tempt[0].BookingRooms_CheckInActual.GetValueOrDefault().Day == Day)
                        {
                            if (tempt[0].BookingRooms_AddTimeStart > 0)
                            {
                                retItem.Text = "(" + retItem.Text;
                            }
                            else
                            {
                                retItem.Text = "|" + retItem.Text;
                            }
                        }
                        if (tempt[ii].BookingRooms_CheckOutActual.GetValueOrDefault().Day == Day)
                        {
                            if (tempt[ii].BookingRooms_AddTimeEnd > 0)
                            {
                                retItem.Text = retItem.Text + ")";
                            }
                            else
                            {
                                retItem.Text = retItem.Text + "|";
                            }
                        }

                        retItem.ListCustomers.Add("[" + tempt[ii].Company_Name + "] [" + tempt[ii].CustomerGroups_Name + "] [" + tempt[ii].Customers_Name + "]");
                        retItem.ListIDBookingR.Add(tempt[ii].BookingRs_ID);
                        retItem.ListIDBookingRooms.Add(tempt[ii].BookingRooms_ID);

                    }
                    ListRet.Insert(ListRet.Count, retItem);
                }
            }
            return ListRet;
        }

        //=======================================================
        //Author: Hien
        //Function : ReportPaymentBookingR
        //=======================================================
        public List<InfoDetailPaymentEN> ReportPaymentBookingR(int IDBookingR)
        {
            PaymentEN aPaymentEN = new PaymentEN();
            BookingRoomsBO aBookingRoomBO = new BookingRoomsBO();
            List<BookingRooms> aListBookingRoom = new List<BookingRooms>();
            ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();

            aListBookingRoom = aBookingRoomBO.Select_ByIDBookingRs(IDBookingR);
            InfoDetailPaymentEN aInfoDetailPaymentEn;
            for (int i = 0; i < aListBookingRoom.Count; i++)
            {
                aInfoDetailPaymentEn = new InfoDetailPaymentEN();
                aInfoDetailPaymentEn.aBookingRooms = aListBookingRoom[i];
                aInfoDetailPaymentEn.aListService = aReceptionTaskBO.GetListService_ByIDBookingRoom(aListBookingRoom[i].ID);
                //aInfoDetailPaymentEn.DateInUse = aReceptionTaskBO.CaculateBooking(aListBookingRoom[i].ID,aListBookingRoom[i].CheckInActual, aListBookingRoom[i].CheckOutActual);
                aPaymentEN.aListInfoDetailPaymentEN.Add(aInfoDetailPaymentEn);
            }

            return aPaymentEN.aListInfoDetailPaymentEN;
        }
        //=======================================================
        //Author: Ngoc
        //Function : GetRevenueRoom
        //=======================================================
        public List<RevenueEN> GetRevenueRoom(DateTime From, DateTime To, List<string> ListCodeRoom)
        {
            try
            {
                ReceptionTaskBO aReceptionTaskBO = new ReceptionTaskBO();
                List<sp_RoomsExt_CalculationRevenue_Result> aListSP = new List<sp_RoomsExt_CalculationRevenue_Result>();
                double UsedDate = new double();
                List<RevenueEN> aListRevenueRoom = new List<RevenueEN>();
                TimeSpan dis = To.Subtract(From);
                double TotalDate = dis.TotalDays;


                RevenueEN aRevenueEN;
                RoomsBO aRoomsBO = new RoomsBO();

                //ListCodeRoom.Count
                for (int i = 0; i < ListCodeRoom.Count; i++)
                {
                    aRevenueEN = new RevenueEN();
                    aRevenueEN.CodeRoom = ListCodeRoom[i];
                    aRevenueEN.Sku = aRoomsBO.Select_ByCodeRoom(ListCodeRoom[i], 1).Sku;
                    aListSP = aDatabaseDA.sp_RoomsExt_CalculationRevenue(ListCodeRoom[i], From, To).ToList();
                    for (int ii = 0; ii < aListSP.Count; ii++)
                    {

                        if (aListSP[ii].TypeCalculationRevenue == 1) // Khach da thanh toan, lay gia theo cost
                        {
                            Double NoTax = Convert.ToDouble(aListSP[ii].Cost) * Convert.ToDouble(aListSP[ii].TimeInUse / 24 / 60);
                            Double Cost = NoTax + NoTax * Convert.ToDouble(aListSP[ii].PercentTax) / 100;

                            Double CostEstimate = Cost;
                            aRevenueEN.Revenue = aRevenueEN.Revenue + CostEstimate;
                        }
                        else if (aListSP[ii].TypeCalculationRevenue == 2) // Khach da check out nhung chua thanh toan, tu dong tinh tien
                        {
                            Double NoTax = Convert.ToDouble(aListSP[ii].Cost) * Convert.ToDouble(aListSP[ii].TimeInUse / 24 /60);
                            Double Cost = NoTax + NoTax * Convert.ToDouble(aListSP[ii].PercentTax) / 100;

                            Double CostEstimate = Cost;
                            aRevenueEN.Revenue = aRevenueEN.Revenue + CostEstimate;
                        }
                        else if (aListSP[ii].TypeCalculationRevenue == 3) // Khach da check in nhung chua check out, lay ngay check out du kien ra de tinh tien
                        {
                            //Double NoTax = Convert.ToDouble(aListSP[ii].Cost) * Convert.ToDouble(aReceptionTaskBO.CaculateBooking(aListSP[ii].ID,aListSP[ii].CheckInActual, aListSP[ii].CheckOutPlan));
                            //Double Cost = NoTax + NoTax * Convert.ToDouble(aListSP[ii].PercentTax) / 100;

                            //Double CostEstimate = Cost;
                            //aRevenueEN.Revenue = aRevenueEN.Revenue + CostEstimate;
                        }
                        else if (aListSP[ii].TypeCalculationRevenue == 4) // khach hang Pending nhung da checkoutActual ,lay ngay checkoutActual de tinh tien
                        {
                            //Double NoTax = Convert.ToDouble(aListSP[ii].Cost) * Convert.ToDouble(aReceptionTaskBO.CaculateBooking(aListSP[ii].ID,aListSP[ii].CheckInActual, aListSP[ii].CheckOutActual)) * Convert.ToDouble(aListSP[ii].CostPendingRoom / 100);
                            //Double Cost = NoTax + NoTax * Convert.ToDouble(aListSP[ii].PercentTax) / 100;

                            //Double CostEstimate = Cost;
                            //aRevenueEN.Revenue = aRevenueEN.Revenue + CostEstimate;
                        }

                    }
                    aListRevenueRoom.Add(aRevenueEN);

                }


                return aListRevenueRoom;
            }
            catch (Exception ex)
            {
                throw new Exception("ReportTaskBO.GetRevenueRoom \n" + ex.ToString());
            }
        }
        //=======================================================
        //Author: LinhTing
        //Function : Tính hiệu suất phòng
        //=======================================================
        public List<EfficiencyEN> GetEfficiencyRoom(DateTime From, DateTime To, List<string> ListCodeRoom)
        {
            try
            {
                List<sp_RoomsExt_CalculationEfficiency_Result> aListSP = new List<sp_RoomsExt_CalculationEfficiency_Result>();
                double UsedDate = new double();
                List<EfficiencyEN> aListEfficiencyEN = new List<EfficiencyEN>();
                TimeSpan dis = To.Subtract(From);
                double TotalDate = dis.TotalDays;
                RoomsBO aRoomBO = new RoomsBO();
                for (int i = 0; i < ListCodeRoom.Count; i++)
                {
                    EfficiencyEN aEfficiencyEN = new EfficiencyEN();
                    aListSP = aDatabaseDA.sp_RoomsExt_CalculationEfficiency(ListCodeRoom[i], From, To).ToList();
                    UsedDate = new double();
                    UsedDate = double.Parse(aListSP.Select(p => p.RankTime).Sum().ToString());
                    //ret.Add((UsedDate / TotalDate) * 100);
                    aEfficiencyEN.CodeRoom = ListCodeRoom[i];
                    Rooms aRooms = aRoomBO.Select_ByCodeRoom(aEfficiencyEN.CodeRoom, 1);
                    aEfficiencyEN.Sku = aRooms.Sku;
                    aEfficiencyEN.Efficiency = Math.Round((UsedDate / TotalDate) * 100, 2);
                    aListEfficiencyEN.Add(aEfficiencyEN);

                }


                return aListEfficiencyEN;
            }
            catch (Exception ex)
            {
                throw new Exception("ReceptionTaskBO.GetEfficiencyRoom \n" + ex.ToString());
            }
        }

        //=======================================================
        //Author: LinhTing
        //Function : Tìm danh sách khách qua đêm
        //=======================================================   

        //public List<OverNightCustomerEN> GetOverNightCustomer(DateTime CheckPoint, int Status)
        //{

        //    List<BookingRooms> aListBookingRooms = aBookingRoomsBO.Select_ByStatus_ByTime(CheckPoint, Status);
        //    List<BookingRoomsMembers> aListBookingRoomsMembers = new List<BookingRoomsMembers>();
        //    List<OverNightCustomerEN> aListOverNightCustomer = new List<OverNightCustomerEN>();
        //    OverNightCustomerEN aOverNightCustomer = new OverNightCustomerEN();
        //    Customers aCustomers;

        //    string a = DateTime.Now.Ticks.ToString();
        //    for (int i = 0; i < aListBookingRooms.Count; i++)
        //    {
        //        aListBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom(aListBookingRooms[i].ID);

        //        for (int y = 0; y < aListBookingRoomsMembers.Count; y++)
        //        {
        //            aOverNightCustomer = new OverNightCustomerEN();

        //            aCustomers = new Customers();
        //            int IDCustomer = aListBookingRoomsMembers[y].IDCustomer;
        //            aCustomers = aCustomersBO.Select_ByID(IDCustomer);

        //            if (aCompaniesBO.Select_ByIDBookingRoom(aListBookingRooms[i].ID) != null)
        //            {
        //                aOverNightCustomer.CompanyName = aCompaniesBO.Select_ByIDBookingRoom(aListBookingRooms[i].ID).Name;
        //            }


        //            aOverNightCustomer.PurposeComeVietnam = aListBookingRoomsMembers[y].PurposeComeVietnam;
        //            aOverNightCustomer.IDBookingRoom = aListBookingRooms[i].ID;
        //            if (aRoomsBO.Select_ByCodeRoom(aListBookingRooms[i].CodeRoom, 1) != null)
        //            {
        //                aOverNightCustomer.Sku = aRoomsBO.Select_ByCodeRoom(aListBookingRooms[i].CodeRoom, 1).Sku;
        //            }

        //            if (aBookingRsBO.Select_ByID(aListBookingRooms[i].IDBookingR) != null)
        //            {
        //                aOverNightCustomer.CustomerType = aBookingRsBO.Select_ByID(aListBookingRooms[i].IDBookingR).CustomerType;
        //            }
        //            aOverNightCustomer.CheckInActual = aListBookingRooms[i].CheckInActual;
        //            aOverNightCustomer.CheckOutPlan = aListBookingRooms[i].CheckOutPlan;
        //            aOverNightCustomer.Name = aCustomers.Name;
        //            aOverNightCustomer.IDCustomer = aCustomers.ID;
        //            aOverNightCustomer.Identifier1 = aCustomers.Identifier1;
        //            aOverNightCustomer.Identifier2 = aCustomers.Identifier2;
        //            aOverNightCustomer.Identifier3 = aCustomers.Identifier3;
        //            aOverNightCustomer.Nationality = aCustomers.Nationality;
        //            aOverNightCustomer.Birthday = aCustomers.Birthday;
        //            aOverNightCustomer.Tel = aCustomers.Tel;
        //            aOverNightCustomer.Address = aCustomers.Address;
        //            aOverNightCustomer.Email = aCustomers.Email;
        //            aOverNightCustomer.Info = aCustomers.Info;
        //            aOverNightCustomer.Gender = aCustomers.Gender;
        //            aOverNightCustomer.Citizen = aCustomers.Citizen;
        //            aOverNightCustomer.Identifier1CreatedDate = aCustomers.Identifier1CreatedDate;
        //            aOverNightCustomer.Identifier2CreatedDate = aCustomers.Identifier2CreatedDate;
        //            aOverNightCustomer.Identifier3CreatedDate = aCustomers.Identifier3CreatedDate;
        //            aOverNightCustomer.PlaceOfIssue1 = aCustomers.PlaceOfIssue1;
        //            aOverNightCustomer.PlaceOfIssue2 = aCustomers.PlaceOfIssue2;
        //            aOverNightCustomer.PlaceOfIssue3 = aCustomers.PlaceOfIssue3;

        //            aListOverNightCustomer.Add(aOverNightCustomer);
        //        }
        //    }
        //    a = a + "---" + DateTime.Now.Ticks.ToString();

        //    return aListOverNightCustomer;
        //}
        // Author : LinhTing
        // Select list khách qua đêm mới
        public List<OverNightCustomerEN> GetNewOverNightCustomer(DateTime CheckPoint, int Status)
        {

            List<BookingRooms> aListNewBookingRooms = aBookingRoomsBO.Select_ByStatus_ByTime(CheckPoint, CheckPoint.AddDays(-1), Status);
            List<BookingRoomsMembers> aListNewBookingRoomsMembers = new List<BookingRoomsMembers>();
            List<OverNightCustomerEN> aListNewOverNightCustomer = new List<OverNightCustomerEN>();
            OverNightCustomerEN aNewOverNightCustomer = new OverNightCustomerEN();
            Customers aCustomers;

            for (int i = 0; i < aListNewBookingRooms.Count; i++)
            {
                aListNewBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByIDBookingRoom(aListNewBookingRooms[i].ID);

                for (int y = 0; y < aListNewBookingRoomsMembers.Count; y++)
                {
                    aNewOverNightCustomer = new OverNightCustomerEN();

                    aCustomers = new Customers();
                    int IDCustomer = aListNewBookingRoomsMembers[y].IDCustomer;
                    aCustomers = aCustomersBO.Select_ByID(IDCustomer);

                    aNewOverNightCustomer.CompanyName = aCompaniesBO.Select_ByIDBookingRoom(aListNewBookingRooms[i].ID).Name;

                    aNewOverNightCustomer.PurposeComeVietnam = aListNewBookingRoomsMembers[y].PurposeComeVietnam;
                    aNewOverNightCustomer.IDBookingRoom = aListNewBookingRooms[i].ID;

                    aNewOverNightCustomer.Sku = aRoomsBO.Select_ByCodeRoom(aListNewBookingRooms[i].CodeRoom, 1).Sku;

                    aNewOverNightCustomer.CustomerType = aBookingRsBO.Select_ByID(aListNewBookingRooms[i].IDBookingR).CustomerType;

                    aNewOverNightCustomer.CheckInActual = aListNewBookingRooms[i].CheckInActual;
                    aNewOverNightCustomer.CheckOutPlan = aListNewBookingRooms[i].CheckOutPlan;
                    aNewOverNightCustomer.Name = aCustomers.Name;
                    aNewOverNightCustomer.IDCustomer = aCustomers.ID;
                    aNewOverNightCustomer.Identifier1 = aCustomers.Identifier1;
                    aNewOverNightCustomer.Identifier2 = aCustomers.Identifier2;
                    aNewOverNightCustomer.Identifier3 = aCustomers.Identifier3;
                    aNewOverNightCustomer.Nationality = aCustomers.Nationality;
                    aNewOverNightCustomer.Birthday = String.Format("{0:MM-dd-yyyy}", aCustomers.Birthday);

                    aNewOverNightCustomer.Tel = aCustomers.Tel;
                    aNewOverNightCustomer.Address = aCustomers.Address;
                    aNewOverNightCustomer.Email = aCustomers.Email;
                    aNewOverNightCustomer.Info = aCustomers.Info;
                    aNewOverNightCustomer.Gender = aCustomers.Gender;
                    aNewOverNightCustomer.Citizen = aCustomers.Citizen;
                    aNewOverNightCustomer.Identifier1CreatedDate = aCustomers.Identifier1CreatedDate;
                    aNewOverNightCustomer.Identifier2CreatedDate = aCustomers.Identifier2CreatedDate;
                    aNewOverNightCustomer.Identifier3CreatedDate = aCustomers.Identifier3CreatedDate;
                    aNewOverNightCustomer.PlaceOfIssue1 = aCustomers.PlaceOfIssue1;
                    aNewOverNightCustomer.PlaceOfIssue2 = aCustomers.PlaceOfIssue2;
                    aNewOverNightCustomer.PlaceOfIssue3 = aCustomers.PlaceOfIssue3;

                    aListNewOverNightCustomer.Add(aNewOverNightCustomer);
                }
            }
            return aListNewOverNightCustomer;
        }
        public List<OverNightCustomerEN> GetOverNightCustomer(DateTime CheckPoint, int Status)
        {

            List<BookingRooms> aListBookingRooms = aBookingRoomsBO.Select_ByStatus_ByTime(CheckPoint, Status);
            List<BookingRoomsMembers> aListBookingRoomsMembers = new List<BookingRoomsMembers>();
            List<OverNightCustomerEN> aListOverNightCustomer = new List<OverNightCustomerEN>();
            OverNightCustomerEN aOverNightCustomer = new OverNightCustomerEN();
            Customers aCustomers;


            // get tất cả dữ liệu
            List<int> aListIDBookingRoom = new List<int>();
            int aTemp;
            for (int i = 0; i < aListBookingRooms.Count; i++)
            {
                aTemp = new int();
                aTemp = aListBookingRooms[i].ID;
                aListIDBookingRoom.Add(aTemp);
            }
            List<string> aListCodeRoom = new List<string>();

            for (int i = 0; i < aListBookingRooms.Count; i++)
            {
                string aCode;
                aCode = aListBookingRooms[i].CodeRoom;
                aListCodeRoom.Add(aCode);
            }

            List<BookingRoomsMembers> aListAllBookingRoomsMembers = aBookingRoomsMembersBO.Select_ByListIDBookingRoom(aListIDBookingRoom);
            List<Companies> aListCompanies = aCompaniesBO.Select_ByListIDBookingRoom(aListIDBookingRoom);
            List<CustomerGroups> aListCustomerGroups = aCustomerGroupsBO.Select_ByListIDBookingRoom(aListIDBookingRoom);
            List<Rooms> aListRooms = aRoomsBO.Select_ByListCodeRoom(aListCodeRoom, 1);
            List<Customers> aListCustomers = aCustomersBO.SelectListCustomer_ByListIDBookingRoom(aListIDBookingRoom);
            List<BookingRs> aListBookingRs = aBookingRsBO.Select_ByListIDBookingRoom(aListIDBookingRoom);


            for (int i = 0; i < aListBookingRooms.Count; i++)
            {
                aListBookingRoomsMembers = aListAllBookingRoomsMembers.Where(p => p.IDBookingRoom == aListBookingRooms[i].ID).ToList();

                for (int y = 0; y < aListBookingRoomsMembers.Count; y++)
                {
                    aOverNightCustomer = new OverNightCustomerEN();

                    aCustomers = new Customers();
                    int IDCustomer = aListBookingRoomsMembers[y].IDCustomer;
                    aCustomers = aListCustomers.Where(p => p.ID == IDCustomer).ToList()[0];

                    int IDCustomerGroup = aListBookingRs.Where(p => p.ID == aListBookingRooms[i].IDBookingR).ToList()[0].IDCustomerGroup;
                    int IDCompany = aListCustomerGroups.Where(p => p.ID == IDCustomerGroup).ToList()[0].IDCompany;
                    if (IDCompany != null)
                    {
                        aOverNightCustomer.CompanyName = aListCompanies.Where(p => p.ID == IDCompany).ToList()[0].Name;
                    }

                    aOverNightCustomer.PurposeComeVietnam = aListBookingRoomsMembers[y].PurposeComeVietnam;
                    aOverNightCustomer.DateEnterCountry = aListBookingRoomsMembers[y].DateEnterCountry;
                    aOverNightCustomer.EnterGate = aListBookingRoomsMembers[y].EnterGate;
                    aOverNightCustomer.TemporaryResidenceDate = aListBookingRoomsMembers[y].TemporaryResidenceDate;
                    aOverNightCustomer.LeaveDate = aListBookingRoomsMembers[y].LeaveDate;
                    aOverNightCustomer.Organization = aListBookingRoomsMembers[y].Organization;
                    aOverNightCustomer.LimitDateEnterCountry = aListBookingRoomsMembers[y].LimitDateEnterCountry;

                    aOverNightCustomer.IDBookingRoom = aListBookingRooms[i].ID;

                    if (aListRooms.Where(p => p.Code == aListBookingRooms[i].CodeRoom).ToList()[0] != null)
                    {
                        aOverNightCustomer.Sku = aListRooms.Where(p => p.Code == aListBookingRooms[i].CodeRoom).ToList()[0].Sku;
                    }

                    if (aListBookingRs.Where(p => p.ID == aListBookingRooms[i].IDBookingR).ToList()[0] != null)
                    {
                        aOverNightCustomer.CustomerType = aListBookingRs.Where(p => p.ID == aListBookingRooms[i].IDBookingR).ToList()[0].CustomerType;
                    }
                    aOverNightCustomer.CheckInActual = aListBookingRooms[i].CheckInActual;
                    aOverNightCustomer.CheckOutPlan = aListBookingRooms[i].CheckOutPlan;
                    aOverNightCustomer.Name = aCustomers.Name;
                    aOverNightCustomer.IDCustomer = aCustomers.ID;
                    aOverNightCustomer.Identifier1 = aCustomers.Identifier1;
                    aOverNightCustomer.Identifier2 = aCustomers.Identifier2;
                    aOverNightCustomer.Identifier3 = aCustomers.Identifier3;
                    aOverNightCustomer.Nationality = aCustomers.Nationality;
                    aOverNightCustomer.Birthday = String.Format("{0:MM-dd-yyyy}", aCustomers.Birthday);
                    aOverNightCustomer.Tel = aCustomers.Tel;
                    aOverNightCustomer.Address = aCustomers.Address;
                    aOverNightCustomer.Email = aCustomers.Email;
                    aOverNightCustomer.Info = aCustomers.Info;
                    aOverNightCustomer.Gender = aCustomers.Gender;
                    aOverNightCustomer.Citizen = aCustomers.Citizen;
                    aOverNightCustomer.Identifier1CreatedDate = aCustomers.Identifier1CreatedDate;
                    aOverNightCustomer.Identifier2CreatedDate = aCustomers.Identifier2CreatedDate;
                    aOverNightCustomer.Identifier3CreatedDate = aCustomers.Identifier3CreatedDate;
                    aOverNightCustomer.PlaceOfIssue1 = aCustomers.PlaceOfIssue1;
                    aOverNightCustomer.PlaceOfIssue2 = aCustomers.PlaceOfIssue2;
                    aOverNightCustomer.PlaceOfIssue3 = aCustomers.PlaceOfIssue3;
                    aOverNightCustomer.CAN_BO_NM = "NVNK";
                    aOverNightCustomer.IsVietNam = "N";
                    aOverNightCustomer.Quan = "HK";
                    aOverNightCustomer.DIACHI_TT = "2 Lê Thạch";
                    aOverNightCustomer.NgayTruyen = DateTime.Now.Date.ToShortDateString();

                    aListOverNightCustomer.Add(aOverNightCustomer);
                }
            }


            return aListOverNightCustomer;
        }

        private void ReturnNumberCustomer(sp_Get_Status_ListRooms_In_Month_Result tempt, ref RptRoomStatusEN retItem)
        {

            if (tempt.BookingRs_PayMethod == 4) // Bao cap
            {
                if (tempt.Company_Type == 5) //Khách bộ ngoại giao
                {
                    retItem.NumberCustomer = retItem.NumberCustomer + 1;
                    retItem.Text =  Convert.ToString(retItem.NumberCustomer) + "B";
                }
                else  // Tat cac cac khach bao cap khac
                {
                    retItem.NumberCustomer = retItem.NumberCustomer + 1;
                    retItem.Text = Convert.ToString(retItem.NumberCustomer) + "b";
                }
            }
            else if (tempt.BookingRs_PayMethod == 1) // Tu tra
            {
                if (tempt.Company_Type == 5) //Khách bộ ngoại giao
                {

                    retItem.NumberCustomer = retItem.NumberCustomer + 1;
                    retItem.Text = Convert.ToString(retItem.NumberCustomer) + "T";

                }
                else  // Tat cac cac khach bao cap khac
                {
                    retItem.NumberCustomer = retItem.NumberCustomer + 1;
                    retItem.Text = Convert.ToString(retItem.NumberCustomer) + "t";

                }
            }
        }


    }
}
