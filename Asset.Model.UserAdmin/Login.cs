using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Model.UserAdmin
{
    public class Login
    {

     
        public string loginName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public int userId { get; set; }
        //
        public List<TreeNode> MenuNavigation {get; set;}
    }
}