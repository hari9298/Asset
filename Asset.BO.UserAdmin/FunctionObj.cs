using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Model.UserAdmin;
using Asset.Repository.UserAdmin;

namespace Asset.BO.UserAdmin
{
    public  class FunctionObj
    {
      
        
      public  List<Menu>  GetUserMenuList()
        {
          
            var menuList = new FunctionRepository();
            var MenuList = FunctionMenuDTO.ConvertToDTOMenuList(menuList.GetMenuListForUser());


            return MenuList.ToList();
        }
         public  List<Menu>  GetUserMenuList(String User)
        {
          
            var menuList = new FunctionRepository();
            var MenuList = FunctionMenuDTO.ConvertToDTOMenuList(menuList.GetMenuListForUser(User));

            return MenuList.ToList();
        }
          public  List<CommonList> GetCompany()
        {
            
          var  cmp = new CompanyRepository();
          var Result =  cmp.GetAllCompanyAsync();
         
          return FunctionMenuDTO.ConvertToCommoncmpListEntityList(CommonMapper.ConvertToCommonModelList(Result));
        }
        public List<CommonList> GetGroup()
        {

            var grp = new GroupRepository();
            var Result = grp.GetAllGroupAsync();

            return FunctionMenuDTO.ConvertToCommoncmpListEntityList(GroupMapper.ConvertToGrpModelList(Result));
        }
        public List<Status> GetStatus()
        {

            var stat = new StatusRepository();
            var Result = stat.GetAllStatusAsync();

            return FunctionMenuDTO.ConvertToStatusEntityList(StatusMapper.ConvertToStatusModelList(Result));
        }

    }
}