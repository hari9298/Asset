using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Asset.Model.UserAdmin;

namespace Asset.Services.UserAdmin.Controllers
{
    public interface IUserService
    {
          Login Authenticate(Login loginUser);
           Login GetAll(Login loginUser);
    }
}