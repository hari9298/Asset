using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TRoleMaster
    {
        public TRoleMaster()
        {
            TUserProfile = new HashSet<TUserProfile>();
        }

        public int RmId { get; set; }
        public string RmName { get; set; }
        public int? RmType { get; set; }
        public string RmDescription { get; set; }
        public DateTime? RmModifiedOn { get; set; }
        public int? RmModifiedBy { get; set; }
        public int? RmStatus { get; set; }
        public string RmCreatedBy { get; set; }
        public DateTime? RmCreatedOn { get; set; }

        public virtual ICollection<TUserProfile> TUserProfile { get; set; }
    }
}
