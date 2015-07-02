using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace Entity
{
    public class SystemUsersEN:SystemUsers
    {
        public SystemUserExts aSystemUserExts = new SystemUserExts();
        public List<FamilyMembersExtEN> aListFamilyMembersExtEN = new List<FamilyMembersExtEN>();
        public List<SystemUsers_CertificatesEN> aListSystemUsers_CertificatesEN = new List<SystemUsers_CertificatesEN>();
        public List<AuditHistories> aListAuditHistories = new List<AuditHistories>();
        public List<RewardAndPunishments> aListRewardAndPunishments = new List<RewardAndPunishments>();
        public List<DocumentSystemUsers> aListDocumentSystemUsers = new List<DocumentSystemUsers>();
    }
}
