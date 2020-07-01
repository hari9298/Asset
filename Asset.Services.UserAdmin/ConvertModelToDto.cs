using System;
using Asset.DTO.UserAdmin;
using Asset.Model.UserAdmin;
using System.Collections.Generic;
using System.Linq;


namespace Asset.Services.UserAdmin
{
    public static class ConvertModelToDto 
    {
      public static UserDTO ConvertUserModelToDto(this User user)
      {
          return new UserDTO{
                UserID = user.UserID,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                PasswordExpiryDate = user.PasswordExpiryDate,
                PasswordRecvQuestion = user.PasswordRecvQuestion,
                PasswordRecvAnswer = user.PasswordRecvAnswer,
                companyID = user.companyID,
                groupID = user.groupID,
                companyName = user.companyName,
                groupName = user.groupName,
                UserModifiedOn = user.UserModifiedOn,
                UserModifiedBy = user.UserModifiedBy,
                StatusID = user.StatusID,
                StatusName = user.StatusName,
                CreatedOn = user.CreatedOn,
                CreatedBy = user.CreatedBy
              //IsValidUser = user.IsValidUser
          };
      }
      public static List<UserDTO> ConvertUserListModelToDto(this List<User> userList)
    {
        return userList.Select(user => user.ConvertUserModelToDto()).ToList();
    }

      public static RoleDTO ConvertRoleModelToDTO(this Role role)
      {
          return new RoleDTO {

                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleType = role.RoleType,
                RoleDescription = role.RoleDescription,
                ModifiedOn = role.RoleModifiedOn,
                ModifiedBy = role.RoleModifiedBy,
                RoleStatus = role.RoleStatus,
                CreatedBy = role.CreatedBy,
                CreatedOn = role.CreatedOn,
                UserprofileId =role.UserprofileId,
                UserprofileRefType = role.UserprofileRefType,
                UserprofileRefId = role.UserprofileRefId,
                UserprofileRoleId = role.UserprofileRoleId,
                UserprofileModifiedOn =  role.UserprofileModifiedOn,
                UserprofileModifiedBy = role.UserprofileModifiedBy,
                UserprofileStatus = role.UserprofileStatus,
                CheckRole = role.CheckRole
               // ActionRequired = role.ActionRequired
          };
      }

       public static List<RoleDTO> ConvertRoleListModelToDTO(this List<Role> roleList)
    {
        return roleList.Select(role => role.ConvertRoleModelToDTO()).ToList();
    }

     
    
     public static GroupDTO ConvertGroupModelToDTO(this Group group)
        {
            return new GroupDTO{

                GroupId = Convert.ToInt32(group.GroupId),
                GroupName = group.GroupName,
                GroupDescription = group.GroupDescription,
                GroupModifiedOn = group.GroupModifiedOn,
                GroupModifiedBy = group.GroupModifiedBy,
                GroupStatus = group.GroupStatus,
                CreatedBy = group.CreatedBy,
                CreatedOn = group.CreatedOn

            };
        }
   
     public static List<GroupDTO> ConvertGroupListModelToDTO(this List<Group> groupList)
    {
        return groupList.Select(group => group.ConvertGroupModelToDTO()).ToList();
    }

        public static UserRoleDTO ConvertUserRoleModelToDTO(this User user, List<Role> roles)
        {
            return new UserRoleDTO
            {
                user = ConvertUserModelToDto(user),
                roles = ConvertRoleListModelToDTO(roles)
            };
        }

        public static GroupRoleDTO ConvertGroupRoleModelToDTO(this Group group, List<Role> roles)
        {
            return new GroupRoleDTO
            {
                group = ConvertGroupModelToDTO(group),
                roles = ConvertRoleListModelToDTO(roles)
            };
        }

        public static FunctionDTO FunctionModelToDTO(this Function function)
        {
            return new FunctionDTO
            {
                FunctionId = function.FunctionId,
                FunctionName = function.FunctionName,
                FunctionOrder = function.FunctionOrder,
                FunctionType = function.FunctionType,
                FunctionUri = function.FunctionUri,
                RolefunlId = function.RolefunlId,
                RolefunctionlinkRole = function.RolefunctionlinkRole,
                RolefunctionlinkFunction = function.RolefunctionlinkFunction,
                RolefunctionlinkAccessKey = function.RolefunctionlinkAccessKey,
                canAdd = function.canAdd,
                canView = function.canView,
                canDelete = function.canDelete,
                canUpdate = function.canUpdate,
                array = function.array
            };
        }

        public static List<FunctionDTO> FunctionListModelToDTO(this List<Function> functionList)
        {
            return functionList.Select(function => function.FunctionModelToDTO()).ToList();
        }

        public static RoleFunctionDTO ConvertGroupRoleModelToDTO(this Role role, List<Function> functions)
        {
            return new RoleFunctionDTO
            {
                Roles = ConvertRoleModelToDTO(role),
                Funtions = FunctionListModelToDTO(functions)
            };
        }
        public static List<EmailTemplateDTO> ConvertEmailTemplateListModelToDTO(this List<EmailTemplate> templatelist)
        {
            return templatelist.Select(template => template.ConvertEmailTemplateModelToDTO()).ToList();
        }

        public static EmailTemplateDTO ConvertEmailTemplateModelToDTO(this EmailTemplate template)
        {
            return new EmailTemplateDTO
            {
                ETId = template.ETId,
                ETBoday = template.ETBoday,
                ETName = template.ETName,
                ETDescription = template.ETDescription,
                ETCreatedBy = template.ETCreatedBy,
                ETCreatedOn = template.ETCreatedOn,
                ETModifiedBy = template.ETModifiedBy,
                ETModifiedOn = template.ETModifiedOn,
                ETStatus = template.ETStatus

            };
        }

        public static CommonListDTO ConvertToCommonListModelToDto(this CommonList common)
        {
            return new CommonListDTO
            {
                ItemName = common.ItemName,
                ItemID = common.ItemID,
            };
        }
        public static List<CommonListDTO> ConvertCommonLstListModeltoDto(this List<CommonList> commons)
        {
            return commons.Select(cmn => cmn.ConvertToCommonListModelToDto()).ToList();
        }

        public static ProductDTO convertProductModelToDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ProductQuantity = product.ProductQuantity,
                ProductCategoryId = product.ProductCategoryId,
                ProductCategoryName = product.ProductCategoryName
            };
        }

        public static List<ProductDTO> convertProductListModelToDTO(this List<Product> products)
        {
            return products.Select(pro => pro.convertProductModelToDTO()).ToList();
        }
    }
}