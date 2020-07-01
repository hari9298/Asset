using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TGroupMaster
    {
        public int GmId { get; set; }
        public string GmName { get; set; }
        public string GmDescription { get; set; }
        public DateTime? GmModifiedOn { get; set; }
        public int? GmModifiedBy { get; set; }
        public string GmCreatedBy { get; set; }
        public DateTime? GmCreatedOn { get; set; }
        public int? GmStatus { get; set; }
    }
}
