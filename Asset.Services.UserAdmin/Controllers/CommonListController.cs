using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asset.Model.UserAdmin;
using Asset.Repository.UserAdmin;

namespace Asset.Services.UserAdmin.Controllers
{
    [Produces("application/json")]
    [Route("api/Common")]
    public class CommonController : Controller
    {
       
        [HttpGet]
        [Route("all")]
        public  List<CommonList> Get()
        {
       
          var  cml = new CommonListRepositoy();
          var Result =  cml.GetAllCommonAsync();
                    
          return CommonMapper.ConvertToQuestionModelList(Result);
        }

    }
}