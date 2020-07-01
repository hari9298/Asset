using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Model.UserAdmin
{
    public class EmailTemplate
    {
        public int ETId { get; set; }
        public string ETName { get; set; }
        public string ETDescription { get; set; }
        public string ETBoday { get; set; }
        public DateTime? ETCreatedOn { get; set; }
        public string ETCreatedBy { get; set; }
        public DateTime? ETModifiedOn { get; set; }
        public string ETModifiedBy { get; set; }
        public int? ETStatus { get; set; }
    }
}