using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.Exceptions.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;

namespace Asset.BO.UserAdmin
{
      public class UserAdminBO
    {
        UserRepository  userRepository;

        RolesLinkedToUserRepository roleLinkToUserRepository;

        UserUnitOfWork userUnitofwork = new UserUnitOfWork(); // code added 28 April


        public User UserInfo { get; set; }
        public  List<Role> RolesLinkedToUser { get; set; }
       
       public UserAdminBO()
       {
            userRepository = new UserRepository();
            roleLinkToUserRepository = new RolesLinkedToUserRepository(userRepository.GetDBContext());

        }

       public UserAdminBO(int UserID)
       {
             userRepository = new UserRepository();
             UserInfo = GetUserData(UserID);
             RolesLinkedToUser = GetUserRole(UserID);
       }
   
        public async Task<User> ResetPassword(User user)
        {
            var userEntites =await userRepository.ResetPassword(user);
            return userEntites;
        }
        public List<User> GetList()
        {    
           var UserEntities = userRepository.GetAllWithDetails(); 
            if(UserEntities == null)
            {
                throw new BusinessException("Details are not available");
            }
           return  UserEntities;   
        }
        public User GetUserData(int UserID)
        {
            var userEntity = userRepository.GetUserDetails(UserID);
            return userEntity;
        }

        public List<Role> GetRoleList()

        {       
           var Result = userRepository.GetRoleDetails();
           return Result.ToList();
        }
        public  List<Role> GetUserRole(int userId)
        {
          var Result = userRepository.GetRoleListwithId(userId);
          return Result;

        }      
          public async Task<List<object>> UpdateUserDetails(User userInfo, List<Role> rolesAdded,List<Role> rolesDeleted)
        {
            List<object> userRoles = new List<object>();    
            var user = await userRepository.UpdateUser(userInfo, rolesAdded,rolesDeleted);
            var roles =await roleLinkToUserRepository.UpdateUsersRoles(user, rolesAdded, rolesDeleted); 
            userRoles.Add(user);
            userRoles.Add(roles);
            return userRoles;

        }
        public async Task<List<object>>  Add(User userInfo, List<Role> Roles)
        {
                List<object> userRoles = new List<object>();
                var CurrentUser=await userRepository.AddUser(userInfo, Roles);
                var roles = await roleLinkToUserRepository.AddUsersRole(CurrentUser, Roles);
                userRoles.Add(CurrentUser);
                userRoles.Add(roles);
                return userRoles;


        }


     
        /// <summary>
        /// This method is used for deleting user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
      

        public async Task<User> Delete(int userId)
        {
          
            var getUserDetail = userRepository.GetUserDetails(userId);

            if (getUserDetail != null)
            {
               
                    await roleLinkToUserRepository.DeleteUserRoles(userId);
               
                await userRepository.DeleteUser(userId);
            }
            return  getUserDetail;
          
        }
    }

}