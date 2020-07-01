using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Asset.Model.UserAdmin;
using Asset.BO.UserAdmin;

namespace Asset.Services.UserAdmin.Controllers
{
    [Produces("application/json")]
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        FunctionObj menuobj;
        private IMemoryCache _cache;
        public MenuController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public List<TreeNode> Get()
        {

            List<Menu> _menu = new List<Menu>();
            menuobj = new FunctionObj();


            String User = _cache.Get<String>("Users");

            //var menus = menuobj.GetUserMenuList(User);
            var menus = menuobj.GetUserMenuList();
            _menu.AddRange(menus);
            List<TreeNode> nodeList = TreeNode.FillRecursive(_menu, 0);

            return nodeList;

        }
    }
}