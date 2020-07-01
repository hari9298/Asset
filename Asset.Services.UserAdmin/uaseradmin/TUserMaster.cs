using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TUserMaster
    {
        public int UmId { get; set; }
        public string UmFirstName { get; set; }
        public string UmMiddleName { get; set; }
        public string UmLastName { get; set; }
        public string UmLogin { get; set; }
        public string UmPassword { get; set; }
        public DateTime? UmPasswodExpiry { get; set; }
        public int? UmPassRecvQuestion { get; set; }
        public string UmPassRecvAnswer { get; set; }
        public int? UmCompany { get; set; }
        public int? UmGroup { get; set; }
        public DateTime? UmModifiedOn { get; set; }
        public int? UmModifiedBy { get; set; }
        public int? UmStatus { get; set; }
    }
}
