using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Entity
{
   public class UserInfomationEN : SystemUsers
   {
       public SystemUserExts aSystemUserExts = new SystemUserExts();
       public List<CertificateExtInfoEN> aListCertificateExt_Regular = new List<CertificateExtInfoEN>();
       public List<CertificateExtInfoEN> aListCertificateExt_Sub = new List<CertificateExtInfoEN>();
       public List<CertificateExtInfoEN> aListCertificateExt_PoliticGorvenmentManager = new List<CertificateExtInfoEN>();

       public List<FamilyMembersExtEN> aListFamilyMembers = new List<FamilyMembersExtEN>();
       public List<AuditHistories> aListAuditHistories = new List<AuditHistories>();
       public List<RewardAndPunishments> aListReward = new List<RewardAndPunishments>();
       public List<RewardAndPunishments> aListPunishments = new List<RewardAndPunishments>();
       public List<DocumentSystemUsers> aListDocumentSystemUsers = new List<DocumentSystemUsers>();
    }
}
