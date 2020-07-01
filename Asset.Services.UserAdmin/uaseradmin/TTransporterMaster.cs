using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TTransporterMaster
    {
        public TTransporterMaster()
        {
            TTransporterTransactionDetails = new HashSet<TTransporterTransactionDetails>();
        }

        public int TransporterId { get; set; }
        public DateTime? TimeEntry { get; set; }
        public string BusinessEntityGroup { get; set; }
        public double? SvcReqKey { get; set; }
        public string RateScheduled { get; set; }
        public int? TransStatus { get; set; }

        public virtual ICollection<TTransporterTransactionDetails> TTransporterTransactionDetails { get; set; }
    }
}
