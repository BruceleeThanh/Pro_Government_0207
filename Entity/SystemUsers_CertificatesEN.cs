using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
    public class SystemUsers_CertificatesEN : SystemUsers_Certificates
    {
        public string Organization_SystemUsers_Certificates { get; set; }
        public string Certificate { get; set; }
        public string LevelDisplay { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Gender { get; set; }


    }
}
