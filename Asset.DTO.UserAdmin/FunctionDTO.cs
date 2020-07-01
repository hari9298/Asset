using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.DTO.UserAdmin
{
   public class FunctionDTO
    {
        public int? FunctionId { get; set; }
        public string FunctionName { get; set; }
        public int? FunctionType { get; set; }
        public string FunctionUri { get; set; }
        public int? FunctionOrder { get; set; }

        //function role link

        public int? RolefunlId { get; set; }
        public int? RolefunctionlinkRole { get; set; }
        public int? RolefunctionlinkFunction { get; set; }
        public int? RolefunctionlinkAccessKey { get; set; }

        public bool canView { get; set; }
        public bool canAdd { get; set; }
        public bool canUpdate { get; set; }
        public bool canDelete { get; set; }

        public char[] array { get; set; }

       
    }
}
