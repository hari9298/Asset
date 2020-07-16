using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Model.UserAdmin;



namespace Asset.Model.UserAdmin
{
    public static class FunctionMenuDTO
    {
         public static Menu ConvertToDTOMenu(this Menu menu)
        {
        return new Menu { 
            Id = menu.Id,
            Name = menu.Name,
            URI = menu.URI,
            ParentId = Convert.ToInt32(menu.ParentId),
            MenuImagePath = menu.MenuImagePath
                
        };
        }
         public static List<Menu> ConvertToDTOMenuList(this List<Menu> menuss)
    {
        return menuss.Select(menu => menu.ConvertToDTOMenu()).ToList();
    }

       public static CommonList ConvertToCommoncmpListEntity(this CommonList common)
        {
        return new CommonList { 
                ItemName = common.ItemName,
                ItemID = common.ItemID
                };
        }
        public static List<CommonList> ConvertToCommoncmpListEntityList(this List<CommonList> commons)
         {
        return commons.Select(cmn => cmn.ConvertToCommoncmpListEntity()).ToList();
            
         }

        public static Status ConvertToStatusEntity(this Status Sts)
        {
        return new Status { 
                StatusId = Sts.StatusId,
                StatusDescription = Sts.StatusDescription
                };
        }
        public static List<Status> ConvertToStatusEntityList(this List<Status> Stss)
         {
        return Stss.Select(cmn => cmn.ConvertToStatusEntity()).ToList();
         }
    }
}