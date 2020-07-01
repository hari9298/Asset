using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.Model
{
    public partial class TAddressDetails
    {
        public int AdId { get; set; }
        public int? AdRefId { get; set; }
        public string AdRefType { get; set; }
        public int? AdAddrType { get; set; }
        public string AdAddress { get; set; }
        public string AdPostalCode { get; set; }
        public int? AdCity { get; set; }
        public int? AdState { get; set; }
        public int? AdCountry { get; set; }
        public DateTime? AdModifiedOn { get; set; }
        public int? AdModifiedBy { get; set; }

        public virtual TCommonListMaster AdAddrTypeNavigation { get; set; }
    }
}
