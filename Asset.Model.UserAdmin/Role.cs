using System;

namespace Asset.Model.UserAdmin
{
    public class Role
    {
         public int? RoleId { get; set; }
        //
        public string RoleName { get; set; }
        public int? RoleType { get; set; }
        public string RoleDescription { get; set; }
        public DateTime? RoleModifiedOn { get; set; }
        public string RoleModifiedBy { get; set; }
        public int? RoleStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public int? UserprofileId { get; set; }
        public int? UserprofileRefType { get; set; }
        public int? UserprofileRefId { get; set; }
        public int? UserprofileRoleId { get; set; }
        public DateTime? UserprofileModifiedOn { get; set; }
        public string UserprofileModifiedBy { get; set; }
        public int? UserprofileStatus { get; set; }
        public bool CheckRole {get; set;}
       // public char ActionRequired{get;set;}  
       
    }
}