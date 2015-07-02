using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Migrations;

namespace BussinessLogic
{
    public class FoodsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();


        //private ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HelperClass aHelperClass = new HelperClass();
        private ObjectContext objectContext;
        // Danh sách các món ăn (Tra cứu)
        public DataTable SearchFoodResult(string name, int type, string tag)
        {
            var dt = new DataTable();
            try
            {

                // lấy tất cả các loại
                if (type == 0)
                {
                    var result = (from f in aDatabaseDA.Foods
                                  where (f.Name.Contains(name) || f.Name1.Contains(name) || f.Name2.Contains(name) ||
                                        f.Name3.Contains(name)) //&&  f.Tag.Contains(tag)
                                  select f);

                    dt = aHelperClass.LinqToDataTable(result.ToList());
                }
                // tìm theo loại
                else
                {
                    var result = from f in aDatabaseDA.Foods
                                 where (f.Name.Contains(name) || f.Name1.Contains(name) || f.Name2.Contains(name) ||
                                       f.Name3.Contains(name)) && f.Tag.Contains(tag) && f.Type == type
                                 select f;
                    //dt = result.CopyToDataTable();
                    dt = EntityToDatatable(result, objectContext);
                    // dt = _helperClass.LinqToDataTable(result.ToList());

                }

            }
            catch (Exception ex)
            {

                //Logger.Error(ex);
            }
            return dt;
        }
        // Danh sách các món ăn (Tra cứu)
        public DataTable GetMenuFoodList()
        {
            var dt = new DataTable();
            try
            {
                var result = from f in aDatabaseDA.Foods
                             select new
                                        {
                                            f.Name,
                                            f.Name1,
                                            f.Name2,
                                            f.Name3,
                                            f.ID,
                                            Check = "N"
                                        };

                dt = aHelperClass.LinqToDataTable(result.ToList());

            }
            catch (Exception ex)
            {

                /// Logger.Error(ex);
            }
            return dt;
        }
        // Lấy thông tin chi tiết các món ăn
        public DataTable GetFoodDetail(int id)
        {
            var dt = new DataTable();
            try
            {
                var result = from f in aDatabaseDA.Foods
                             where f.ID == id
                             select f;
                dt = aHelperClass.LinqToDataTable(result.ToList());
            }
            catch (Exception ex)
            {

                ///Logger.Error(ex);
            }

            return dt;
        }
        //Xóa món ăn
        public string DeleteFood(int id)
        {
            string result;
            try
            {

                result = "Xóa thành công";
            }
            catch (Exception ex)
            {

                //Logger.Error(ex);
                result = "Lỗi hệ thống";
            }
            return result;
        }
        protected DataTable EntityToDatatable(IEnumerable Result, ObjectContext ctx)
        {
            try
            {
                EntityConnection conn = ctx.Connection as EntityConnection;
                using (SqlConnection SQLCon = new SqlConnection(conn.StoreConnection.ConnectionString))
                {
                    ObjectQuery query = Result as ObjectQuery;
                    using (SqlCommand Cmd = new SqlCommand(query.ToTraceString(), SQLCon))
                    {
                        foreach (var param in query.Parameters)
                        {
                            Cmd.Parameters.AddWithValue(param.Name, param.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<Foods> Select_All()
        {
            try
            {
                return aDatabaseDA.Foods.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Select_All :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public Foods Select_ByID(int ID)
        {
            try
            {
                List<Foods> aListFoods = aDatabaseDA.Foods.Where(c => c.ID == ID).ToList();
                if (aListFoods.Count > 0)
                {
                    return aDatabaseDA.Foods.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Select_ByID :" + ex.Message.ToString()));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : Select_ByListID
        //=======================================================
        public List<Foods> Select_ByListID(List<int> ID)
        {
            try
            {
                 return aDatabaseDA.Foods.Where(f =>ID.Contains(f.ID)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Select_ByListID :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_ByNameAndTypeAndTag
        //=======================================================
        public List<Foods> Select_ByNameAndTypeAndTag(string name,int type,string tag)
        {
            try
            {
                List<Foods> aListFoods = new List<Foods>();
                if (type <= 0 )
                {
                    aListFoods = aDatabaseDA.Foods.Where(f => f.Name.Contains(name) || f.Name1.Contains(name) || f.Name2.Contains(name) || f.Name3.Contains(name)).Where(f => f.Tag.Contains(tag)).OrderByDescending(f=>f.ID).ToList();
                }
                else
                {
                    aListFoods = aDatabaseDA.Foods.Where(f => f.Name.Contains(name) || f.Name1.Contains(name) || f.Name2.Contains(name) || f.Name3.Contains(name)).Where(f => f.Type == type && f.Tag.Contains(tag)).OrderByDescending(f => f.ID).ToList();
                }
                return aListFoods;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Select_ByNameAndTypeAndTag :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(Foods aFoods)
        {
            try
            {
                aDatabaseDA.Foods.Add(aFoods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Insert :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByID
        //=======================================================
        public int Delete(int ID)
        {
            try
            {
                Foods aFoods = aDatabaseDA.Foods.Find(ID);
                aDatabaseDA.Foods.Remove(aFoods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Delete :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(Foods aFoods)
        {
            try
            {
                aDatabaseDA.Foods.AddOrUpdate(aFoods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("FoodsBO.Update :" + ex.Message));
            }
        }
       
    }
}
