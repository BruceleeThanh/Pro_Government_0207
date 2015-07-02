using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class ChangeRoomEN
    {

       private List<ItemChangeRoomEN> aListItemChangeRoomEN { set; get; }

        public ChangeRoomEN()
        {
            this.aListItemChangeRoomEN = new List<ItemChangeRoomEN>();
        }
        public ItemChangeRoomEN GetItemChangeRooms(string CodeRoom)
        {
           List < ItemChangeRoomEN > aListTempt = this.aListItemChangeRoomEN.Where(p => p.GetCodeRoom() == CodeRoom).ToList();
           if (aListTempt.Count > 0)
           {
               return aListTempt[0];
           }
           else
           {
               return null;
           }

       }
        private int GetIndexItemChangeRooms(string CodeRoom)
        {
            for (int i = 0; i < this.aListItemChangeRoomEN.Count; i++)
            {
                if (this.aListItemChangeRoomEN[i].GetCodeRoom() == CodeRoom)
                {
                    return i;
                }   
            }
            return -1;
        }
        public List<ItemChangeRoomEN> GetAllItemChangeRoom()
        {
            List<ItemChangeRoomEN> aRet = new List<ItemChangeRoomEN>();
            ItemChangeRoomEN Item = new ItemChangeRoomEN();
            for (int i = 0; i < this.aListItemChangeRoomEN.Count; i++)
            {
                Item = new ItemChangeRoomEN();
                Item.SetValue(this.aListItemChangeRoomEN[i]);
                aRet.Add(Item);
            }
            return aRet;
        }
        public List<ItemChangeRoomEN> GetListItemChangeRoomNotIncludeRootRoom()
        {
            List<ItemChangeRoomEN> aList = new List<ItemChangeRoomEN>();
            for (int i = 0 ; i < this.aListItemChangeRoomEN.Count ; i ++)
            {
                if (this.aListItemChangeRoomEN[i].IsRootRoom == false)
                {
                    aList.Add(this.aListItemChangeRoomEN[i]);
                }
            }
            return aList;
        }

        public bool InsertItemChangeRooms(ItemChangeRoomEN cust) 
        {
            try
            {
                ItemChangeRoomEN temp = new ItemChangeRoomEN();
                temp.AddCustomer(cust.GetAllCustomers());
                temp.SetBookingRooms(cust.GetBookingRooms());

                this.aListItemChangeRoomEN.Insert(0, temp);
                return true;
            }
            catch (Exception e2)
            {
                return false;
            }
        }
        public bool UpdateItemChangeRooms(ItemChangeRoomEN cust)
        {
            try
            {
                if (this.IsExitRoom(cust.GetCodeRoom()) == true)
                {
                    int Index = this.GetIndexItemChangeRooms(cust.GetCodeRoom());
                    this.aListItemChangeRoomEN[Index] = cust;
                    return true;
                }
                return false;
            }
            catch (Exception e1)
            {
                return false;
            }

        }
        public ItemChangeRoomEN RemoveItemChangeRooms(string CodeRoom)
        {
            List<ItemChangeRoomEN> aListTempt = this.aListItemChangeRoomEN.Where(p => p.GetCodeRoom() == CodeRoom).ToList();
            if (aListTempt.Count > 0)
            {
                this.aListItemChangeRoomEN.Remove(aListTempt[0]);
                return aListTempt[0];
            }
            else
            {
                return null;
            }
        }
        public ItemChangeRoomEN GetRootItemChangeRoom() 
        {
            for (int i = 0 ; i < this.aListItemChangeRoomEN.Count ; i ++ )
            {
                if (this.aListItemChangeRoomEN[i].IsRootRoom == true)
                {
                    return this.aListItemChangeRoomEN[i];
                }

            }
            return null;
        }
        public bool IsExitRoom(string CodeRoom)
        {
            List<ItemChangeRoomEN> aListTempt = this.aListItemChangeRoomEN.Where(p => p.GetCodeRoom() == CodeRoom).ToList();
            if (aListTempt.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



       
    }
}
 