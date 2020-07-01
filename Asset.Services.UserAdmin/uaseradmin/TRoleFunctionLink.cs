using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TRoleFunctionLink
    {
        public int RflId { get; set; }
        public int? RflRole { get; set; }
        public int? RflFunction { get; set; }
        public int? RflAccessKey { get; set; }
        public DateTime? RflModifiedOn { get; set; }
        public int? RflModifiedBy { get; set; }
        public int? RflStatus { get; set; }
    }
}
