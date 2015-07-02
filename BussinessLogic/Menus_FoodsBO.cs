using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using DataAccess;
namespace BussinessLogic
{
    public class Menus_FoodsBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();
        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<Menus_Foods> Select_All()
        {
            try
            {
                return aDatabaseDA.Menus_Foods.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Select_All :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public Menus_Foods Select_ByID(int ID)
        {
            try
            {
                List<Menus_Foods> aListFoods = aDatabaseDA.Menus_Foods.Where(c => c.ID == ID).ToList();
                if (aListFoods.Count > 0)
                {
                    return aDatabaseDA.Menus_Foods.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Select_ByID :" + ex.Message.ToString()));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Select_ByIDFoodAndIDMenu
        //=======================================================
        public Menus_Foods Select_ByIDFoodAndIDMenu(int IDFood, int IDMenu)
        {
            try
            {
                List<Menus_Foods> aListFoods = aDatabaseDA.Menus_Foods.Where(c => c.IDFood == IDFood && c.IDMenu == IDMenu).ToList();
                if (aListFoods.Count > 0)
                {
                    return aDatabaseDA.Menus_Foods.Where(c => c.IDFood == IDFood && c.IDMenu == IDMenu).ToList()[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Select_ByIDFoodAndIDMenu :" + ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(Menus_Foods aMenus_Foods)
        {
            try
            {
                aDatabaseDA.Menus_Foods.Add(aMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Insert :" + ex.Message));
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
                Menus_Foods aMenus_Foods = aDatabaseDA.Menus_Foods.Find(ID);
                aDatabaseDA.Menus_Foods.Remove(aMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Delete :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByIDFood
        //=======================================================
        public int Delete_ByIDFood(int IDFood)
        {
            try
            {
                List<Menus_Foods> aListMenus_Foods = aDatabaseDA.Menus_Foods.Where(mf => mf.IDFood == IDFood).ToList();
                aDatabaseDA.Menus_Foods.RemoveRange(aListMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Delete_ByIDFood :" + ex.Message));
            }
        }

        ////=======================================================
        ////Author: Hiennv
        ////Function : Delete_ByIDMenu
        ////=======================================================
        public int Delete_ByIDMenu(int IDMenu)
        {
            try
            {
                List<Menus_Foods> aListMenus_Foods = aDatabaseDA.Menus_Foods.Where(mf => mf.IDMenu == IDMenu).ToList();
                aDatabaseDA.Menus_Foods.RemoveRange(aListMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Delete_ByIDMenu :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Delete_ByIDMenuAndIDFood
        //=======================================================
        public int Delete_ByIDMenuAndIDFood(int IDMenu, int IDFood)
        {
            try
            {
                Menus_Foods aListMenus_Foods = aDatabaseDA.Menus_Foods.Where(mf => mf.IDMenu == IDMenu && mf.IDFood == IDFood).ToList()[0];
                aDatabaseDA.Menus_Foods.Remove(aListMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Delete_ByIDMenuAndIDFood :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(Menus_Foods aMenus_Foods)
        {
            try
            {
                aDatabaseDA.Menus_Foods.AddOrUpdate(aMenus_Foods);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Update :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : SelectListFoods_ByListIDFood()
        //=======================================================
        public List<Foods> SelectListFoods_ByListIDFood(List<int> aListIDFood)
        {
            FoodsBO aFoodsBO = new FoodsBO();
            List<Foods> aListFoods = new List<Foods>();
            for (int i = 0; i < aListIDFood.Count; i++)
            {
                aListFoods.Add(aFoodsBO.Select_ByID(aListIDFood[i]));
            }
            return aListFoods;
        }

        //=======================================================
        //Author: Hiennv
        //Function : SelectListFoods_ByIDMenu()
        //=======================================================
        public List<Foods> SelectListFoods_ByIDMenu(int IDMenu)
        {
            try
            {
                Menus_FoodsBO aMenus_FoodsBO = new Menus_FoodsBO();
                List<Menus_Foods> aList = aDatabaseDA.Menus_Foods.Where(a => a.IDMenu == IDMenu).ToList();
                List<Foods> aListFoods = new List<Foods>();
                Foods aFoods;
                FoodsBO aFoodsBO = new FoodsBO();
                for (int i = 0; i < aList.Count; i++)
                {
                    aFoods = new Foods();
                    aFoods = aFoodsBO.Select_ByID(aList[i].IDFood);
                    aListFoods.Add(aFoods);
                }
                return aListFoods;
            }
            catch (Exception ex)
            {

                throw new Exception("Menus_FoodsBO.SelectListFoods_ByIDMenu\n" + ex.ToString());
            }
        }
        //Linhting
        public List<Menus_Foods> Select_ByIDMenu(int IDMenu)
        {
            try
            {
                return aDatabaseDA.Menus_Foods.Where(a=>a.IDMenu==IDMenu).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Menus_FoodsBO.Select_ByIDMenu :" + ex.Message.ToString()));
            }
        }
        //Linhting
        //public int Delete_ByIDMenu(int IDMenu)
        //{
        //    try
        //    {
        //        List<Menus_Foods> aList = Select_ByIDMenu(IDMenu);
        //        foreach (Menus_Foods item in aList)
        //        {
        //            this.Delete(item.ID);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("Menus_FoodsBO.Delete_ByIDMenu :" + ex.Message));
        //    }
        //}
    }
}
