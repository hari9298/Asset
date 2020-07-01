using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.DTO.UserAdmin
{
    public class RoleFunctionDTO
    {
        public RoleDTO Roles { get; set; }

        public List<FunctionDTO> Funtions { get; set; }
    }
}
