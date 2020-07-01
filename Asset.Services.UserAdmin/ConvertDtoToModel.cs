using System;
using System.Collections.Generic;
using System.Linq;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;

namespace Asset.Services.UserAdmin
{
    public static class ConvertDtoToModel
    {
        public static User ConvertUserDtoToUserModel(this UserDTO user)
        {
            return new User
            {

                UserID = user.UserID,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                PasswordExpiryDate =user.PasswordExpiryDate,
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
                CreatedBy = user.CreatedBy,
                CreatedOn = user.CreatedOn
                //IsValidUser = user.IsValidUser
            };
        }
        public static List<User> ConvertUserListDtoToUserModel(this List<UserDTO> userList)
            {
                return userList.Select(user => user.ConvertUserDtoToUserModel()).ToList();
            }
        public static Role ConvertRoleDtoToRoleModel(this RoleDTO role)
        {
            return new Role{
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleType = role.RoleType,
                RoleDescription = role.RoleDescription,
                RoleModifiedOn = role.ModifiedOn,
                RoleModifiedBy = role.ModifiedBy,
                RoleStatus = role.RoleStatus,
                CreatedBy = role.CreatedBy,
                CreatedOn = role.CreatedOn,
                UserprofileId = role.UserprofileId,
                UserprofileRefType = role.UserprofileRefType,
                UserprofileRefId = role.UserprofileRefId,
                UserprofileRoleId = role.UserprofileRoleId,
                UserprofileModifiedOn =  role.UserprofileModifiedOn,
                UserprofileModifiedBy = role.UserprofileModifiedBy,
                UserprofileStatus = role.UserprofileStatus,
                CheckRole = role.CheckRole,
              //  ActionRequired = role.ActionRequired

            };
        }

         public static List<Role> ConvertRoleListDtoToRoleModel(this List<RoleDTO> roleList)
            {
                return roleList.Select(role => role.ConvertRoleDtoToRoleModel()).ToList();
            }

        //  public static UserRole ConvertUserRoleDtoToModel(this UserRoleDTO userRole)
        // {
        //    return new UserRole
        //    { 
        //        UserList = ConvertUserDtoToUserModel(userRole.UserListDTO),
        //        Roles = ConvertRoleListDtoToRoleModel(userRole.RoleListDTO)
        //    };
        // }
   

             public static Group ConvertGroupDtoToGroupModel(this GroupDTO group)
                {
                    return new Group{

                        GroupId = Convert.ToInt32(group.GroupId),
                        GroupName = group.GroupName,
                        GroupDescription = group.GroupDescription,
                        GroupModifiedOn = group.GroupModifiedOn,
                        GroupModifiedBy = group.GroupModifiedBy,
                        GroupStatus = group.GroupStatus,
                        CreatedOn = group.CreatedOn,
                        CreatedBy = group.CreatedBy
                
                    };
                }
            public static List<Group> ConvertGroupListDtoToGroupModel(this List<GroupDTO> groupList)
            {
                return groupList.Select(group => group.ConvertGroupDtoToGroupModel()).ToList();
            }

        // public static GroupRole ConvertGroupRoleDtoToModel(this GroupRoleDTO groupRole)
        //{
        //    return new GroupRole
        //    { 
        //        Groups = ConvertGroupDtoToGroupModel(groupRole.GroupDTO),
        //        Roles = ConvertRoleListDtoToRoleModel(groupRole.RoleDTO)
        //    };
        //}


        public static Function FunctionDtoToModel(this FunctionDTO functionDto)
        {
            return new Function
            {
                FunctionId = functionDto.FunctionId,
                FunctionName = functionDto.FunctionName,
                FunctionOrder = functionDto.FunctionOrder,
                FunctionType = functionDto.FunctionType,
                FunctionUri = functionDto.FunctionUri,
                RolefunlId = functionDto.RolefunlId,
                RolefunctionlinkRole = functionDto.RolefunctionlinkRole,
                RolefunctionlinkFunction = functionDto.RolefunctionlinkFunction,
                RolefunctionlinkAccessKey = functionDto.RolefunctionlinkAccessKey,
                canAdd = functionDto.canAdd,
                canView = functionDto.canView,
                canDelete = functionDto.canDelete,
                canUpdate = functionDto.canUpdate,
                array = functionDto.array

            };
        }
        public static List<Function> FunctionListDtoToModel(this List<FunctionDTO> functionList)
        {
            return functionList.Select(function => function.FunctionDtoToModel()).ToList();
        }
        public static List<EmailTemplate> ConvertEmailTemplateListDTOTOModel(this List<EmailTemplateDTO> templatelist)
        {
            return templatelist.Select(template => template.ConvertEmailTemplateDTOToModel()).ToList();
        }

        public static EmailTemplate ConvertEmailTemplateDTOToModel(this EmailTemplateDTO template)
        {
            return new EmailTemplate
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

        public static Product ConvertProductDTOToModel(this ProductDTO product)
        {
            return new Product
            {
               Id = product.Id,
               ProductCode = product.ProductCode,
               ProductName = product.ProductName,
               ProductPrice = product.ProductPrice,
               ProductDescription = product.ProductDescription,
               ProductQuantity = product.ProductQuantity,
               ProductCategoryId = product.ProductCategoryId
            };
        }

    }
}
