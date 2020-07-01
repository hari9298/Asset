using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TEmailTemplate
    {
        public int EtId { get; set; }
        public string EtName { get; set; }
        public string EtDescription { get; set; }
        public byte[] EtTemplateBody { get; set; }
        public DateTime? EtCreatedOn { get; set; }
        public int? EtCreatedBy { get; set; }
        public DateTime? EtModifiedOn { get; set; }
        public int? EtModifiedBy { get; set; }
        public int? EtStatus { get; set; }

        public virtual TStatusMaster EtStatusNavigation { get; set; }
    }
}
