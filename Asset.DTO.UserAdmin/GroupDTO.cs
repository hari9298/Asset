using System;


namespace Asset.DTO.UserAdmin
{
    public class GroupDTO
    {

        public int? GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? GroupModifiedOn { get; set; }
        public string GroupModifiedBy { get; set; }
        public int? GroupStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}