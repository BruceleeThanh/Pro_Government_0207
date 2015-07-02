using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MOBSystemUsersEN
    {
        public int SystemUsers_ID { get; set; }
        public Nullable<int> SystemUsers_UserGroup { get; set; }
        public string SystemUsers_Email { get; set; }
        public string SystemUsers_Username { get; set; }
        public string SystemUsers_Name { get; set; }
        public Nullable<System.DateTime> SystemUsers_Birthday { get; set; }
        public string SystemUsers_Identifier1 { get; set; }
        public string SystemUsers_Identifier2 { get; set; }
        public string SystemUsers_Identifier3 { get; set; }
        public byte[] SystemUsers_Image { get; set; }
        public Nullable<bool> SystemUsers_Disable { get; set; }
        public int Divisions_ID { get; set; }
        public string Divisions_Name { get; set; }
        public Nullable<bool> Divisions_Disable { get; set; }
    }
}
