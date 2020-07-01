using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asset.Model.UserAdmin;
using Asset.Repository.UserAdmin;
using Asset.BO.UserAdmin;



namespace Asset.Services.UserAdmin.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        FunctionObj cmpobj;
        [HttpGet]
        [Route("all")]
        public  List<CommonList> Get()
        {
          cmpobj = new FunctionObj();  
           var Result = cmpobj.GetCompany();

            return Result;
        }

    }
}