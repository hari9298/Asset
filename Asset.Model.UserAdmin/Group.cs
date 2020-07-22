using System;
using System.Collections.Generic;


namespace Asset.Model.UserAdmin
{
    public class Group
    {
        
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        //
        public DateTime? GroupModifiedOn { get; set; }
        public string GroupModifiedBy { get; set; }
        public int? GroupStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}