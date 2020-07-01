using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Asset.Repository.Common;



namespace Asset.Repository.UserAdmin
{
    public class UserRepository : Repository<TUserMaster>, IUserRepository
    {
     //   RoleRepository  _roler;
        public UserRepository()
        {
               dbContext = new useradminContext ();
             
        }
        public UserRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }
        public useradminContext GetDBContext()
        {
            return dbContext as useradminContext;
        }

        // public List<TUserMaster> GetAllUsersAsync()
        public List<TUserMaster> UserList()
        {
            return base.GetAllAsync();

        }

         

        /// <summary>
        /// To get the user details for a given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        // public TUserMaster GetUserDetails(int userId)
        // {
        //     return base.GetById(a => a.UmId == userId);

        // }

     public List<User> GetAllWithDetails()
        {
         
            var queryUser = from u in dbContext.Set<TUserMaster>().Where(a => a.UmStatus == 1)
                       join c in dbContext.Set<TCompanyMaster>() on u.UmCompany equals c.CmId into cmusr
                       join s in dbContext.Set<TStatusMaster>() on u.UmStatus equals s.SmId into susr
                       join g in dbContext.Set<TGroupMaster>() on u.UmGroup equals g.GmId into cgs
                       from cr in cmusr.DefaultIfEmpty()
                       from d in cgs.DefaultIfEmpty()
                       from sr in susr.DefaultIfEmpty()
                       select new User
                       {
                           UserID = u.UmId,
                           FirstName = u.UmFirstName,
                           MiddleName = u.UmMiddleName,
                           LastName = u.UmLastName,
                           Login = u.UmLogin,
                           Password = u.UmPassword,
                           PasswordRecvAnswer = u.UmPassRecvAnswer,
                           PasswordRecvQuestion = u.UmPassRecvQuestion,
                           UserModifiedBy = u.UmModifiedBy,
                           StatusID = u.UmStatus,
                           StatusName = sr.SmDescription,
                           companyName = cr.CmName,
                           companyID = cr.CmId,
                           groupID = d.GmId,
                           groupName = d.GmName,
                           CreatedBy = u.UmCreatedBy,
                           CreatedOn = u.UmCreatedOn,
                           PasswordExpiryDate = u.UmPasswodExpiry
                       };
            try
            {

                return (queryUser.ToList());
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        public User GetUserDetails(int userID){
                var userbyId = new User();
            var queryUser = from u in dbContext.Set<TUserMaster>().Where(a => a.UmStatus == (int)RecordStatus.Active && (a.UmId==userID))
                            
                                join c in dbContext.Set<TCompanyMaster>() on u.UmCompany equals c.CmId into cmusr
                                join s in dbContext.Set<TStatusMaster>() on u.UmStatus equals s.SmId into susr
                                join g in dbContext.Set<TGroupMaster>() on u.UmGroup equals g.GmId into cgs
                                from cr in cmusr.DefaultIfEmpty()
                                from d in cgs.DefaultIfEmpty()
                                from sr in susr.DefaultIfEmpty()
                                select new User
                                {
                                    UserID = u.UmId,
                                    FirstName = u.UmFirstName,
                                    MiddleName = u.UmMiddleName,
                                    LastName = u.UmLastName,
                                    Login = u.UmLogin,
                                    Password = u.UmPassword,
                                    PasswordRecvAnswer = u.UmPassRecvAnswer,
                                    PasswordRecvQuestion = u.UmPassRecvQuestion,
                                    StatusID = u.UmStatus,
                                    StatusName = sr.SmDescription,
                                    companyName = cr.CmName,
                                    companyID = cr.CmId,
                                    groupID = d.GmId,
                                    groupName = d.GmName,
                                    CreatedBy = u.UmCreatedBy,
                                    CreatedOn = u.UmCreatedOn,
                                    PasswordExpiryDate = u.UmPasswodExpiry

                                };
            try { 

                var userQuery = queryUser.FirstOrDefault();
                //var Result = (userID != 0) ? userQuery : (userQuery.UserID == 0);
                var Result = (userID != 0) ? userQuery : userbyId;
                return Result;

            }
            catch (Exception e)
            {
                throw (e);
            }
            // var Result = (userID != 0) ? GetUsersByIdAsync(userQuery) : userbyId;
        }

        /// <summary>
        /// This method is used to create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       // public async Task<int> AddUser(User userInfo, List<Role> Roles)
             public async Task<User> AddUser(User userInfo, List<Role> Roles)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var userResult =  UserMapper.ConvertToUserEntity(userInfo);
            userResult.UmStatus = (int)RecordStatus.Active;
            await base.Add(userResult);
            userUnitOfWork.Save();
            int latestuserid = (int)userResult.UmId;
            return GetUserDetails(latestuserid);
          //  return latestuserid;

        }

         public async Task<User> UpdateUser(User userInfo, List<Role> Roles, List<Role> RolesDeleted)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var userResult = UserMapper.ConvertToUserEntity(userInfo);
            userResult.UmStatus = (int)RecordStatus.Active;
            await base.Update(userResult);
            userUnitOfWork.Save();
            return GetUserDetails((int)userResult.UmId); 
          //  await dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// This method is used to update the user details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // public async Task UpdateUser(User user)
        // {
        //    var userResult = UserMapper.ConvertToUserModel(user);
        //    userResult.UmStatus = (int)RecordStatus.Active;

        //    await base.Update(userResult);

        // }

        //  public async Task DeleteUsersAsync(UserRole user)
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task  DeleteUser(int user)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getUserDetail = GetUserDetails(user);
            var userResult = UserMapper.ConvertToUserEntity(getUserDetail);
            userResult.UmStatus = (int)RecordStatus.Inactive;
            await base.Update(userResult);
            userUnitOfWork.Save();
           // return GetUserDetails((int)userResult.UmId);

        }

        public async Task<User> ResetPassword(User user)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var userResult = UserMapper.ConvertToUserEntity(user);
            await base.Update(userResult);
            userUnitOfWork.Save();
            return GetUserDetails(userResult.UmId);
        }
        public List<Role> GetRoleDetails()
        {
           var queryRoleList = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()

                               select new Role
                               {
                                   RoleId = rm.RmId,
                                   RoleName = rm.RmName,
                                   RoleType = rm.RmType,
                                   RoleDescription = rm.RmDescription,
                                   RoleModifiedOn = rm.RmModifiedOn,
                                   RoleModifiedBy = rm.RmModifiedBy,
                                   RoleStatus = rm.RmStatus,
                                   CreatedOn = rm.RmCreatedOn,
                                   CreatedBy = rm.RmCreatedBy,

                                   //UserprofileId = (int)UserProfile.userProfileId,
                                   //UserprofileRefType = rm.RmType,
                                   //UserprofileRefId = (int)UserProfile.userProfileId,
                                   //UserprofileRoleId = rm.RmId,
                                   //UserprofileModifiedOn = rm.RmModifiedOn,
                                   //UserprofileModifiedBy = rm.RmModifiedBy,
                                   //UserprofileStatus = rm.RmStatus,

                                   CheckRole = false
                               };

           return ((queryRoleList.GroupBy(f => f.RoleId).Select(o => o.FirstOrDefault())).ToList());

        }
        //public UserRole GetRolesWithUsers()
        //{
        //    var queryUserList = from u in dbContext.Set<TUserMaster>().Where(a => a.UmStatus == (int)RecordStatus.Active)
        //                        join c in dbContext.Set<TCompanyMaster>() on u.UmCompany equals c.CmId into cmusr
        //                        join s in dbContext.Set<TStatusMaster>() on u.UmStatus equals s.SmId into susr
        //                        join g in dbContext.Set<TGroupMaster>() on u.UmGroup equals g.GmId into cgs
        //                        from cr in cmusr.DefaultIfEmpty()
        //                        from d in cgs.DefaultIfEmpty()
        //                        from sr in susr.DefaultIfEmpty()
        //                        select new UserList
        //                        {
        //                            UserID = u.UmId,
        //                            FirstName = u.UmFirstName,
        //                            MiddleName = u.UmMiddleName,
        //                            LastName = u.UmLastName,
        //                            Login = u.UmLogin,
        //                            Password = u.UmPassword,
        //                            PasswordExpiryDate = u.UmPasswodExpiry,
        //                            PasswordRecvAnswer = u.UmPassRecvAnswer,
        //                            PasswordRecvQuestion = u.UmPassRecvQuestion,
        //                            UserModifiedOn = u.UmModifiedOn,
        //                            UserModifiedBy = u.UmModifiedBy,
        //                            StatusID = u.UmStatus,
        //                            StatusName = sr.SmDescription,
        //                            companyName = cr.CmName,
        //                            companyID = cr.CmId,
        //                            groupID = d.GmId,
        //                            groupName = d.GmName
        //                        };

        //    var userList = queryUserList.FirstOrDefault();
        //    var queryRoleList = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
        //                        join tup in dbContext.Set<TUserProfile>().Where(o => o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.User).Distinct()
        //                        on rm.RmId equals tup.UpRoleId
        //                        select new RoleList
        //                        {
        //                            RoleId = rm.RmId,
        //                            RoleName = rm.RmName,
        //                            RoleType = rm.RmType,
        //                            RoleDescription = rm.RmDescription,
        //                            RoleModifiedOn = rm.RmModifiedOn,
        //                            RoleModifiedBy = rm.RmModifiedBy,
        //                            RoleStatus = rm.RmStatus,

        //                            UserprofileId = tup.UpId,
        //                            UserprofileRefType = tup.UpRefType,
        //                            UserprofileRefId = tup.UpRefId,
        //                            UserprofileRoleId = tup.UpRoleId,
        //                            UserprofileModifiedOn = tup.UpModifiedOn,
        //                            UserprofileModifiedBy = tup.UpModifiedBy,
        //                            UserprofileStatus = tup.UpStatus,
        //                            CheckRole = (tup.UpRoleId > 0 && tup.UpStatus == (int)RecordStatus.Active) ? true : false
        //                        };
        //    var queryIdList = queryRoleList.ToList();

        //    var rolesAndUsers = new UserRole
        //    {
        //        UserList = userList,
        //        Roles = queryIdList.Distinct().ToList()

        //    };


        //    return (rolesAndUsers);
        //}
        //public UserList GetUserDetailsWithId(int userId)
        //{

        //    var queryUser = from u in dbContext.Set<TUserMaster>().Where(a => a.UmId == userId && a.UmStatus == (int)RecordStatus.Active)
        //               join c in dbContext.Set<TCompanyMaster>() on u.UmCompany equals c.CmId into cmusr
        //               join s in dbContext.Set<TStatusMaster>().Where(a => a.SmId == (int)RecordStatus.Active) on u.UmStatus equals s.SmId into susr
        //               join g in dbContext.Set<TGroupMaster>() on u.UmGroup equals g.GmId into cgs
        //               from cr in cmusr.DefaultIfEmpty()
        //               from d in cgs.DefaultIfEmpty()
        //               from sr in susr.DefaultIfEmpty()
        //               select new UserList
        //               {
        //                   UserID = u.UmId,
        //                   FirstName = u.UmFirstName,
        //                   MiddleName = u.UmMiddleName,
        //                   LastName = u.UmLastName,
        //                   Login = u.UmLogin,
        //                   Password = u.UmPassword,
        //                   PasswordExpiryDate = u.UmPasswodExpiry,
        //                   PasswordRecvAnswer = u.UmPassRecvAnswer,
        //                   PasswordRecvQuestion = u.UmPassRecvQuestion,
        //                   UserModifiedOn = u.UmModifiedOn,
        //                   UserModifiedBy = u.UmModifiedBy,
        //                   StatusID = u.UmStatus,
        //                   StatusName = sr.SmDescription,
        //                   companyName = cr.CmName,
        //                   companyID = cr.CmId,
        //                   groupID = d.GmId,
        //                   groupName = d.GmName
        //               };

        //    return (queryUser.FirstOrDefault());

        //}
        public List<Role> GetRoleListwithId(int userId)
        {


            var queryRoleId = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
                              join tup in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == userId && o.UpStatus == (int)RecordStatus.Active).Distinct()
                              on rm.RmId equals tup.UpRoleId
                              select new Role
                              {
                                  RoleId = rm.RmId,
                                  RoleName = rm.RmName,
                                  RoleType = rm.RmType,
                                  RoleDescription = rm.RmDescription,
                                  RoleModifiedOn = rm.RmModifiedOn,
                                  RoleModifiedBy = rm.RmModifiedBy,
                                  RoleStatus = rm.RmStatus,
                                  CreatedBy = rm.RmCreatedBy,
                                  CreatedOn = rm.RmCreatedOn,
                                  UserprofileId = tup.UpId,
                                  UserprofileRefType = tup.UpRefType,
                                  UserprofileRefId = tup.UpRefId,
                                  UserprofileRoleId = tup.UpRoleId,
                                  UserprofileModifiedOn = tup.UpModifiedOn,
                                  UserprofileModifiedBy = tup.UpModifiedBy,
                                  UserprofileStatus = tup.UpStatus,
                                  // CheckRole = (tup.UpStatus == 1) ? true : false
                                  CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == userId && tup.UpStatus == (int)RecordStatus.Active) ? true : false

                              };
            var queryIdList = queryRoleId.ToList();
            var queryRoleList = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                                join tup in dbContext.Set<TUserProfile>().Distinct() on rm.RmId equals tup.UpRoleId
                                // where !(from rolm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Inactive)
                                //         join tups in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == userId && o.UpStatus == (int)RecordStatus.Active).Distinct()
                                //         on rolm.RmId equals tups.UpRoleId
                                //         select rolm.RmId).Contains(rm.RmId)

                                select new Role
                                {
                                    RoleId = rm.RmId,
                                    RoleName = rm.RmName,
                                    RoleType = rm.RmType,
                                    RoleDescription = rm.RmDescription,
                                    RoleModifiedOn = rm.RmModifiedOn,
                                    RoleModifiedBy = rm.RmModifiedBy,
                                    RoleStatus = rm.RmStatus,
                                    CreatedBy = rm.RmCreatedBy,
                                    CreatedOn = rm.RmCreatedOn,
                                    UserprofileId = tup.UpId,
                                    UserprofileRefType = tup.UpRefType,
                                    UserprofileRefId = tup.UpRefId,
                                    UserprofileRoleId = tup.UpRoleId,
                                    UserprofileModifiedOn = tup.UpModifiedOn,
                                    UserprofileModifiedBy = tup.UpModifiedBy,
                                    UserprofileStatus = tup.UpStatus,
                                    //CheckRole = (tup.UpStatus == 1) ? true : false
                                    CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == userId && tup.UpRefType == 1 && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                                };
            //var queryRoles = queryRoleList.ToList();

            var Roleexceptgrp = queryRoleList.GroupBy(f => f.RoleId);


            var roletR = Roleexceptgrp.Select(o => o.FirstOrDefault()).Except(queryRoleId);

            var roletResult = (queryIdList
                             .Union(roletR.Where(r => !queryIdList.Any(r1 => r1.RoleId == r.RoleId))));

            var Result = (roletResult.Union(GetRoleByIdAsync(userId).Where(x => !roletResult.Any(x1 => x1.RoleId == x.RoleId))));              
           var Roles = (userId != 0) ? Result.ToList() : GetRoleByIdAsync(userId);
      
            return Roles;

        }

        public List<Role> GetRoleByIdAsync(int userId)
        {
            var roleList = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                               // join tup in dbContext.Set<TUserProfile>().Where(o => o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.User).Distinct()
                                //on rm.RmId equals tup.UpRoleId
                              

                                select new Role
                                {
                                    RoleId = rm.RmId,
                                    RoleName = rm.RmName,
                                    RoleType = rm.RmType,
                                    RoleDescription = rm.RmDescription,
                                    RoleModifiedOn = rm.RmModifiedOn,
                                    RoleModifiedBy = rm.RmModifiedBy,
                                    RoleStatus = rm.RmStatus,
                                    CreatedBy = rm.RmCreatedBy,
                                    CreatedOn = rm.RmCreatedOn,
                                    //UserprofileId = tup.UpId,
                                    //UserprofileRefType = tup.UpRefType,
                                    //UserprofileRefId = tup.UpRefId,
                                    //UserprofileRoleId = tup.UpRoleId,
                                    //UserprofileModifiedOn = tup.UpModifiedOn,
                                    //UserprofileModifiedBy = tup.UpModifiedBy,
                                    //UserprofileStatus = tup.UpStatus,
                                    ////CheckRole = (tup.UpStatus == 1) ? true : false
                                    //CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == userId && tup.UpRefType == 1 && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                                };

            return roleList.ToList();

            //var roleListById = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)


            //                   select new Role
            //                   {
            //                       RoleId = rm.RmId,
            //                       RoleName = rm.RmName,
            //                       RoleType = rm.RmType,
            //                       RoleDescription = rm.RmDescription,
            //                       RoleModifiedOn = rm.RmModifiedOn,
            //                       RoleModifiedBy = rm.RmModifiedBy,
            //                       RoleStatus = rm.RmStatus,

            //                       //  UserprofileId =  (int)UserProfile.userProfileId,
            //                         UserprofileRefType = rm.RmType,
            //                      //   UserprofileRefId =  (int)UserProfile.userProfileId,
            //                         UserprofileRoleId = rm.RmId,
            //                         UserprofileModifiedOn = DateTime.Now,
            //                      //   UserprofileModifiedBy =  (int)UserProfile.UserprofileModifiedBy,
            //                       //  UserprofileStatus = (int)UserProfile.UpStatus,
            //                       CheckRole = false
            //                   };

            //return roleListById.ToList();
        }

        public User GetUsersByIdAsync(int userId)
        {
            var userbyId = new User();
            return userbyId;
        }
        //public List<TUserMaster> GetUsersByIdAsync(int userId)
        //{
        //    return base.GetByIdAsync(a => a.UmId == userId);

        //}

        public TUserMaster GetLoginUserCredentials(Login UserLogin)
        {
            try
            {
                return base.GetLoginCredentials(a => a.UmLogin == UserLogin.loginName);

            }
            catch(Exception e)
            {
                throw (e);
            }

        }

        public Role GetExistingRoles(User userInfo,Role roleInfo)
        {
            var roleList = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                           join tup in dbContext.Set<TUserProfile>().Where(o => o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.User && o.UpRefId == userInfo.UserID).Distinct()
                           on rm.RmId equals tup.UpRoleId

                           select new Role
                           {
                               RoleId = rm.RmId,
                               RoleName = rm.RmName,
                               RoleType = rm.RmType,
                               RoleDescription = rm.RmDescription,
                               RoleModifiedOn = rm.RmModifiedOn,
                               RoleModifiedBy = rm.RmModifiedBy,
                               RoleStatus = rm.RmStatus,
                               CreatedBy = rm.RmCreatedBy,
                               CreatedOn = rm.RmCreatedOn,
                               //UserprofileId = tup.UpId,
                               //UserprofileRefType = tup.UpRefType,
                               //UserprofileRefId = tup.UpRefId,
                               //UserprofileRoleId = tup.UpRoleId,
                               //UserprofileModifiedOn = tup.UpModifiedOn,
                               //UserprofileModifiedBy = tup.UpModifiedBy,
                               //UserprofileStatus = tup.UpStatus,
                               ////CheckRole = (tup.UpStatus == 1) ? true : false
                               //CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == userId && tup.UpRefType == 1 && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                           };

            var userQuery = roleList.FirstOrDefault();
            //var Result = (userID != 0) ? userQuery : (userQuery.UserID == 0);
            return userQuery;

        }


        // public async Task AddUserProfile(UserRole user)
        // {
        //    var userResult = UserMapper.ConvertToUserRolEntity(user);
        //    var UserProfileResult = UserMapper.ConvertToUserRolesEntity(user);
        //    foreach (var tuserprofile in UserProfileResult)
        //    {
        //        tuserprofile.UpRefId = userResult.UmId;
        //        tuserprofile.UpRefType = (int)ProfileType.User;
        //        //tu.UpStatus = 1;
        //        tuserprofile.UpId = (int)UserProfile.userProfileId;
        //        tuserprofile.UpModifiedOn = DateTime.Now;
        //    }
        //    this.dbContext.Set<TUserProfile>().AddRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();


        // }

        // public async Task UpdateUserProfileWithAllEntities(UserRole user)
        // {
        //    var userResult = UserMapper.ConvertToUserRolEntity(user);
        //    var UserProfileResult = UserMapper.ConvertToUserRolesEntity(user);
        //    foreach (var tuserprofile in UserProfileResult)
        //    {
        //        tuserprofile.UpRefId = userResult.UmId;
        //        //tu.UpStatus = 1;
        //        tuserprofile.UpRefType = (int)ProfileType.User;
        //        tuserprofile.UpModifiedOn = DateTime.Now;
        //    }


        //    this.dbContext.Set<TUserProfile>().UpdateRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();


        // }

        // public async Task DeleteUserProfileWithAllEntities(UserRole user)
        // {
        //     var userResult = UserMapper.ConvertToUserRolEntity(user);
        //    var UserProfileResult = UserMapper.ConvertToUserRolesEntity(user);
        //    foreach (var tuserprofile in UserProfileResult)
        //    {
        //        tuserprofile.UpRefId = userResult.UmId;
        //        tuserprofile.UpStatus = (int)UserProfile.userProfileStatus;
        //        tuserprofile.UpRefType = (int)UserProfile.UpRefType;
        //        tuserprofile.UpModifiedOn = DateTime.Now;
        //    }

        //    this.dbContext.Set<TUserProfile>().UpdateRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();


        // }

        //private enum User
        //{
        //userId = 0,
        //userStatus = 1,
        //umStatus = 0,
        //SmId = 1
        //}
        //private enum Role
        //{
        //roleId = 0,
        //roleStatus = 1
        //}
        // public enum UserProfile
        // {
        // userProfileId = 0,
        // userProfileStatus = 0,
        // UpRoleId = 0,
        // UpRefType = 1,
        // UpStatus = 1,
        // UserprofileModifiedBy = 1,

        // }
    }
}