using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class CertificateExtInfoEN : vw__CertificatesInfo__SystemUsers_Certificates
    {
       public string TrainingTypeDisplay { get; set; }
       public string LevelDisplay { get; set; }
    }
}
