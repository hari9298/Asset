using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.Model
{
    public partial class TCompanyMaster
    {
        public int CmId { get; set; }
        public string CmName { get; set; }
        public int? CmParentComp { get; set; }
        public string CmPrimaryContact { get; set; }
        public string CmWebsite { get; set; }
        public int? CmType { get; set; }
        public int? CmBusinessType { get; set; }
        public DateTime? CmModifiedOn { get; set; }
        public int? CmModifiedBy { get; set; }
        public int? CmStatus { get; set; }
    }
}
