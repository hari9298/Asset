using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;  
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;

//using CoreApi.Repositories;
//using CoreApi.Entities;

namespace Asset.Services.UserAdmin.Controllers
{
    public class UserService : IUserService
    {
      
        private readonly AppSettings _appSettings;
        useradminContext dbcontext;
        
        public UserService(IOptions<AppSettings> appSettings)
        {
             _appSettings = appSettings.Value;
        }

        public Login Authenticate(Login loginUser)
        {
            
            dbcontext = new useradminContext();
            var _usr = new UserRepository();

            // var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            var loggedinUser = _usr.GetLoginUserCredentials(loginUser);
            
            // return null if user not found
            if(loggedinUser == null)
            {
                return null;
            }
            else
            {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
             _appSettings.Secret = "1234567890 a very long word";
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loggedinUser.UmLogin.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, loggedinUser.UmLogin.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,loggedinUser.UmId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             loginUser.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            loginUser.Password = null;

            return loginUser;
            }
        }

        public Login GetAll(Login loginUser)
        {
            dbcontext = new useradminContext();
            var _usr = new UserRepository();
            var loggedinUser =  _usr.GetLoginUserCredentials(loginUser);
             return new Login
            {
               
                loginName= loggedinUser.UmLogin,
                Password = loggedinUser.UmPassword
            };
           
        }

    }
}