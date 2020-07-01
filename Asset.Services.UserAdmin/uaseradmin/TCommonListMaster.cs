using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TCommonListMaster
    {
        public TCommonListMaster()
        {
            TAddressDetails = new HashSet<TAddressDetails>();
            TCommunicationDetails = new HashSet<TCommunicationDetails>();
        }

        public int ClId { get; set; }
        public string ClListName { get; set; }
        public string ClListDescription { get; set; }
        public int? ClListOrder { get; set; }
        public DateTime? ClModifiedOn { get; set; }
        public int? ClModifiedBy { get; set; }
        public int? ClStatus { get; set; }

        public virtual TStatusMaster ClStatusNavigation { get; set; }
        public virtual ICollection<TAddressDetails> TAddressDetails { get; set; }
        public virtual ICollection<TCommunicationDetails> TCommunicationDetails { get; set; }
    }
}
