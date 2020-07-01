using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TCommunicationDetails
    {
        public int CdId { get; set; }
        public int? CdRefId { get; set; }
        public int? CdRefType { get; set; }
        public int? CdCommType { get; set; }
        public string CdCommValue { get; set; }
        public string CdCommIsPrimary { get; set; }
        public DateTime? CdModifiedOn { get; set; }
        public int? CdModifiedBy { get; set; }

        public virtual TCommonListMaster CdCommTypeNavigation { get; set; }
    }
}
