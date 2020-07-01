using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.Model
{
    public partial class TFunctionMaster
    {
        public int FmId { get; set; }
        public string FmName { get; set; }
        public int? FmType { get; set; }
        public string FmUri { get; set; }
        public string MenuImagePath { get; set; }
        public int? FmOrder { get; set; }
        public DateTime? FmModifiedOn { get; set; }
        public int? FmModifiedBy { get; set; }
        public int? FmStatus { get; set; }
    }
}
