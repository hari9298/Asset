using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TStatusMaster
    {
        public TStatusMaster()
        {
            TCommonListMaster = new HashSet<TCommonListMaster>();
            TEmailTemplate = new HashSet<TEmailTemplate>();
            TUserProfile = new HashSet<TUserProfile>();
        }

        public int SmId { get; set; }
        public string SmDescription { get; set; }
        public DateTime? SmModifiedOn { get; set; }
        public int? SmModifiedBy { get; set; }

        public virtual ICollection<TCommonListMaster> TCommonListMaster { get; set; }
        public virtual ICollection<TEmailTemplate> TEmailTemplate { get; set; }
        public virtual ICollection<TUserProfile> TUserProfile { get; set; }
    }
}
