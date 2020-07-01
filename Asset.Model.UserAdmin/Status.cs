using System;
using System.Collections.Generic;


namespace Asset.Model.UserAdmin
{
    public class Status
    {

        public int? StatusId { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? StatusModifiedOn { get; set; }
        public int? StatusModifiedBy { get; set; }

    }
}