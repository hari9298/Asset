using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json.Serialization; 
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Asset.BO.UserAdmin;
using Asset.Model.UserAdmin;


namespace Asset.Services.UserAdmin.Controllers
{
 
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
       
        FunctionObj menuobj;
        private IUserService _userService;
        private IMemoryCache _cache;
        
        public LoginController(IUserService userService,IMemoryCache memoryCache )
        {
            _userService = userService;
            _cache = memoryCache;
           
        }
  
        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody]Login login)
        {

            var loginModel  = LoginDTO.ConvertToDTOLoginEntity(login);

            var userEntity = _userService.Authenticate(loginModel);
            
           var user = LoginDTO.ConvertToDTOLogin(userEntity);
          
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
             else
             {
                
                    menuobj = new FunctionObj();
                    List<Menu> _menu = new List<Menu>();
                    //var menus = menuobj.GetUserMenuList(user.loginName);
                   var menus = menuobj.GetUserMenuList();
                   _menu.AddRange(menus);
                   List<TreeNode> nodeList = TreeNode.FillRecursive(_menu, 0);
                   user.MenuNavigation = nodeList;
                  _cache.Remove("Users");  
             String cacheEntry =    ""; 
        // Look for cache key.
        if (!_cache.TryGetValue("Users", out cacheEntry))
        {
            // Key not in cache, so get data.
            cacheEntry =    login.loginName;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions();
                // Keep in cache for this time, reset time if accessed.
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(1));
               cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddHours(48);
               cacheEntryOptions.Priority = CacheItemPriority.Normal;
            // Save data in cache.
            _cache.Set("Users", cacheEntry, cacheEntryOptions);
        }
           

        }
         return Ok(user);
        }

       [HttpGet]
       [Route("all")]
        public IActionResult GetAll(Login luser)
        {
        //    luser.loginName = "SharanS";
        //     luser.Password = "hell";
             var loginModel  = LoginDTO.ConvertToDTOLoginEntity(luser);

            var userEntity = _userService.GetAll(loginModel);
            
             var users = LoginDTO.ConvertToDTOLogin(userEntity);
            
            return Ok(users);
        }


       
    }

    
}