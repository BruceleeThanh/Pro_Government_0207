using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using DataAccess;

namespace BussinessLogic
{
    public class DocumentSystemUsersBO
    {
        private DatabaseDA aDatabaseDA = new DatabaseDA();

        //=======================================================
        //Author: Hiennv
        //Function : Select_All
        //=======================================================
        public List<DocumentSystemUsers> Select_All()
        {
            try
            {
                return aDatabaseDA.DocumentSystemUsers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Select_All :"+ ex.Message.ToString()));
            }
        }
        //=======================================================
        //Author: Hiennv
        //Function : Select_ByID
        //=======================================================
        public DocumentSystemUsers Select_ByID(int ID)
        {
            try
            {
                List<DocumentSystemUsers> aListDocumentSystemUsers = aDatabaseDA.DocumentSystemUsers.Where(c => c.ID == ID).ToList();
                if (aListDocumentSystemUsers.Count > 0)
                {
                    return aDatabaseDA.DocumentSystemUsers.Where(c => c.ID == ID).ToList()[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Select_ByID :"+ ex.Message.ToString()));
            }
        }


        //=======================================================
        //Author: Hiennv
        //Function : Insert
        //=======================================================
        public int Insert(DocumentSystemUsers aDocumentSystemUsers)
        {
            try
            {
                aDatabaseDA.DocumentSystemUsers.Add(aDocumentSystemUsers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Insert :" + ex.Message));
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
                DocumentSystemUsers aDocumentSystemUsers = aDatabaseDA.DocumentSystemUsers.Find(ID);
                aDatabaseDA.DocumentSystemUsers.Remove(aDocumentSystemUsers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Delete :" + ex.Message));
            }
        }

        //=======================================================
        //Author: Hiennv
        //Function : Update
        //=======================================================
        public int Update(DocumentSystemUsers aDocumentSystemUsers)
        {
            try
            {
                aDatabaseDA.DocumentSystemUsers.AddOrUpdate(aDocumentSystemUsers);
                return aDatabaseDA.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Update :" + ex.Message));
            }
        }
        //Author: Linhting
        // Select by IDSystemUser
        public List<DocumentSystemUsers> Select_ByIDSystemUser(int IDSystemUser)
        {
            try
            {
                List<DocumentSystemUsers> aList = aDatabaseDA.DocumentSystemUsers.Where(a => a.IDSystemUser == IDSystemUser).ToList();
                return aList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("DocumentSystemUsersBO.Select_ByIDSystemUser :"+ ex.Message.ToString()));
            }
        }
    }
}
