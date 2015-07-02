using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Entity
{
    public class PermitViewAllEN : vw__PermitInfo__SystemUsers_Permits_PermitDetails
    {
        public void Convert(vw__PermitInfo__SystemUsers_Permits_PermitDetails Item)
        {
            
            this.PermitDetails_Disable = Item.PermitDetails_Disable;
            this.PermitDetails_ID = Item.PermitDetails_ID;
            this.PermitDetails_Name = Item.PermitDetails_Name;
            this.PermitDetails_PageURL = Item.PermitDetails_PageURL;

            this.PermitDetails_Status = Item.PermitDetails_Status;
            this.PermitDetails_Type = Item.PermitDetails_Type;

            this.Permits_Disable = Item.Permits_Disable;

            this.Permits_ID = Item.Permits_ID;
            this.Permits_IsAdmin = Item.Permits_IsAdmin;
            this.Permits_IsContent = Item.Permits_IsContent;
       

            this.Permits_IsPartner = Item.Permits_IsPartner;
            this.Permits_Name = Item.Permits_Name;
            this.Permits_Status = Item.Permits_Status;
            this.Permits_SystemKey = Item.Permits_SystemKey;

            this.Permits_SystemUsers_Description = Item.Permits_SystemUsers_Description;
            this.Permits_SystemUsers_Disable = Item.Permits_SystemUsers_Disable;
            this.Permits_SystemUsers_ID = Item.Permits_SystemUsers_ID;

            this.Permits_SystemUsers_IsDelete = Item.Permits_SystemUsers_IsDelete;
            this.Permits_SystemUsers_IsSpecial = Item.Permits_SystemUsers_IsSpecial;
            this.Permits_SystemUsers_IsUpdate = Item.Permits_SystemUsers_IsUpdate;

            this.Permits_Type = Item.Permits_Type;
            this.SystemUsers_Birthday = Item.SystemUsers_Birthday;
            this.SystemUsers_Email = Item.SystemUsers_Email;

            this.SystemUsers_ID = Item.SystemUsers_ID;
            this.SystemUsers_Identifier1 = Item.SystemUsers_Identifier1;
            this.SystemUsers_Identifier2 = Item.SystemUsers_Identifier2;

            this.SystemUsers_Identifier3 = Item.SystemUsers_Identifier3;
            this.SystemUsers_IDRefAnotherSystem = Item.SystemUsers_IDRefAnotherSystem;
            this.SystemUsers_IDRefMailSystem = Item.SystemUsers_IDRefMailSystem;

            this.SystemUsers_Image = Item.SystemUsers_Image;
            this.SystemUsers_Name = Item.SystemUsers_Name;
            this.SystemUsers_Password = Item.SystemUsers_Password;

            this.SystemUsers_Status = Item.SystemUsers_Status;
            this.SystemUsers_Type = Item.SystemUsers_Type;
            this.SystemUsers_UserGroup = Item.SystemUsers_UserGroup;

            this.SystemUsers_Username = Item.SystemUsers_Username;
      
        }
    }
}
