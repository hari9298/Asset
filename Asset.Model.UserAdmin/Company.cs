using System;
using System.Collections.Generic;


namespace Asset.Model.UserAdmin
{
    public class Company
    {
      
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? CompanyParentComp { get; set; }
        public string CompanyPrimaryContact { get; set; }
        public string CompanyWebsite { get; set; }
        public int? CompanyType { get; set; }
        public int? CompanyBusinessType { get; set; }
        public DateTime? CompanyModifiedOn { get; set; }
        public int? CompanyModifiedBy { get; set; }
        public int? CompanyStatus { get; set; }

        
    }
}