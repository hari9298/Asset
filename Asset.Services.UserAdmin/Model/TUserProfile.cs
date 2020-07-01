using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.Model
{
    public partial class TUserProfile
    {
        public int UpId { get; set; }
        public int? UpRefType { get; set; }
        public int? UpRefId { get; set; }
        public int? UpRoleId { get; set; }
        public DateTime? UpModifiedOn { get; set; }
        public int? UpModifiedBy { get; set; }
        public DateTime? UpCreatedOn { get; set; }
        public string UpCreatedBy { get; set; }
        public int? UpStatus { get; set; }

        public virtual TRoleMaster UpRole { get; set; }
        public virtual TStatusMaster UpStatusNavigation { get; set; }
    }
}
