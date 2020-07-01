using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.Common;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;


namespace Asset.Repository.UserAdmin
{
    public static class UserMapper
    {

        
        public static TEntity ConvertToEntity<TEntity, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEntity)Convert.ChangeType(value, typeof(TEntity));

        }

        public static User ConvertToUserModel(this TUserMaster users)
        {
            return new User
            {
                UserID = Convert.ToInt32(users.UmId),
                FirstName = users.UmFirstName,
                MiddleName = users.UmMiddleName,
                LastName = users.UmLastName,
                Login = users.UmLogin,
                Password = users.UmPassword,
                PasswordRecvQuestion = users.UmPassRecvQuestion,
                PasswordRecvAnswer = users.UmPassRecvAnswer,
                companyID = users.UmCompany,
                groupID = users.UmGroup,
                UserModifiedBy = users.UmModifiedBy,
                StatusID = users.UmStatus,
                UserModifiedOn = users.UmModifiedOn,
                CreatedBy = users.UmCreatedBy,
                CreatedOn =users.UmCreatedOn,
                PasswordExpiryDate = users.UmPasswodExpiry
            };
        }

        public static List<User> ConvertToUserModelList(this List<TUserMaster> userss)
        {
            return userss.Select(usr => usr.ConvertToUserModel()).ToList();
        }
             
        public static TUserMaster ConvertToUserEntity(this User users)
        {
            return new TUserMaster
            {
                UmId = Convert.ToInt32(users.UserID),
                UmFirstName = users.FirstName,
                UmMiddleName = users.MiddleName,
                UmLastName = users.LastName,
                UmLogin = users.Login,
                UmPassword = users.Password,
                UmPassRecvQuestion = users.PasswordRecvQuestion,
                UmPassRecvAnswer = users.PasswordRecvAnswer,
                UmCompany = users.companyID,
                UmGroup = users.groupID,
                UmModifiedBy = users.UserModifiedBy,
                UmStatus = users.StatusID,
                UmModifiedOn = users.UserModifiedOn,
                UmCreatedBy = users.CreatedBy,
                UmCreatedOn = users.CreatedOn,
                UmPasswodExpiry = users.PasswordExpiryDate,
            };
        }

        //public static TUserMaster ConvertToUserRolEntity(this UserRole users)
        //{
        //    var UserEntity = new TUserMaster()
        //    {
        //        UmId = Convert.ToInt32(users.UserList.UserID),
        //        UmFirstName = users.UserList.FirstName,
        //        UmMiddleName = users.UserList.MiddleName,
        //        UmLastName = users.UserList.LastName,
        //        UmLogin = users.UserList.Login,
        //        UmPassword = users.UserList.Password,
        //        UmPasswodExpiry = users.UserList.PasswordExpiryDate,
        //        UmPassRecvQuestion = users.UserList.PasswordRecvQuestion,
        //        UmPassRecvAnswer = users.UserList.PasswordRecvAnswer,
        //        UmCompany = users.UserList.companyID,
        //        UmGroup = users.UserList.groupID,
        //        UmModifiedOn = users.UserList.UserModifiedOn,
        //        UmModifiedBy = users.UserList.UserModifiedBy,
        //        UmStatus = users.UserList.StatusID

        //    };
        //    return UserEntity;
        //}
        public static List<TUserMaster> ConvertToUserEntityList(this List<User> users)
        {
            return users.Select(usr => usr.ConvertToUserEntity()).ToList();

        }

        public static TUserMaster ConvertToUserEntityLst(this List<User> userss)
        {
            return new TUserMaster
            {
                UmId = Convert.ToInt32(userss[0].UserID),
                UmFirstName = userss[0].FirstName,
                UmMiddleName = userss[0].MiddleName,
                UmLastName = userss[0].LastName,
                UmLogin = userss[0].Login,
                UmPassword = userss[0].Password,
                UmPassRecvQuestion = userss[0].PasswordRecvQuestion,
                UmPassRecvAnswer = userss[0].PasswordRecvAnswer,
                UmCompany = userss[0].companyID,
                UmGroup = userss[0].groupID,
                UmModifiedBy = userss[0].UserModifiedBy,
                UmStatus = userss[0].StatusID,
                UmCreatedBy = userss[0].CreatedBy,
                UmCreatedOn = userss[0].CreatedOn,
                UmPasswodExpiry = userss[0].PasswordExpiryDate,
                UmModifiedOn = userss[0].UserModifiedOn
            };
        }
        /// <summary>
        /// This function convert the roles model list to profile entity
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
       
  

        public static List<TUserProfile> ConvertToUserRolesEntity(this User userInfo, List<Role> roles, int action)
        {
            var UserProfileList = new List<TUserProfile>();


            for (int i = 0; i < roles.Count; i++)
            {


                if (action == (int)actionRequest.insert)
                {

                    UserProfileList.Add(new TUserProfile
                    {

                        UpRefType = roles[i].RoleType,
                        UpRefId = userInfo.UserID,
                        UpRoleId = roles[i].RoleId,
                        UpModifiedOn = userInfo.UserModifiedOn,
                        UpModifiedBy = userInfo.UserModifiedBy,
                        UpStatus = (roles[i].CheckRole) ? 1 : 2,
                        UpCreatedBy = userInfo.CreatedBy,
                        UpCreatedOn = userInfo.CreatedOn,
                    });
                }

                else if (action == (int)actionRequest.delete)
                {

                    UserProfileList.Add(new TUserProfile
                    {


                        UpId = Convert.ToInt32(roles[i].UserprofileId),
                        UpRefType = roles[i].RoleType,
                        UpRefId = userInfo.UserID,
                        UpRoleId = roles[i].RoleId,
                        UpModifiedOn = userInfo.UserModifiedOn,
                        UpModifiedBy = userInfo.UserModifiedBy,
                        UpStatus = (int)RecordStatus.Inactive,
                        UpCreatedBy = userInfo.CreatedBy,
                        UpCreatedOn = userInfo.CreatedOn

                    });
                }
                


            }
            return UserProfileList;
        }
    }
}