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
    public class RolesLinkedToUserRepository : Repository<TUserProfile>, IRoleLinkedToUserRepository
    {
        // private readonly useradminContext _dbContext;
        UserRepository userRepository = new UserRepository();
        GroupRepository groupRepository = new GroupRepository();
        public RolesLinkedToUserRepository()
        {
            dbContext = new useradminContext();
           // userRepository = new UserRepository();

        }


        public RolesLinkedToUserRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }

      

        public async Task<List<Role>> UpdateUsersRoles(User userInfo, List<Role> rolesAdded, List<Role> rolesDeleted)
        {
            
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesAddedToUser = UserMapper.ConvertToUserRolesEntity(userInfo, rolesAdded, (int)actionRequest.insert);
            var ExistingRoleList = new List<TUserProfile>();
            var NewRoleList = new List<TUserProfile>();

            for (int i = 0; i < rolesAddedToUser.Count; i++)
            {
                var data = GetExistingRoles(userInfo, rolesAddedToUser[i]);
                if(data == null)
                {
                    NewRoleList.Add(rolesAddedToUser[i]);
                }
                else
                {
                    ExistingRoleList.Add(data);
                }
            }
            if (NewRoleList.Count > 0)
            {
                await base.AddRange(NewRoleList);
            }
            else if (ExistingRoleList.Count > 0)
            {
                await base.UpdateRange(ExistingRoleList);
            }
            userUnitOfWork.Save();
            var rolesDeletedToUser = UserMapper.ConvertToUserRolesEntity(userInfo, rolesDeleted, (int)actionRequest.delete);
            await base.UpdateRange(rolesDeletedToUser);
            userUnitOfWork.Save();

            return userRepository.GetRoleListwithId((int)userInfo.UserID);
        }

        public async Task<List<Role>> UpdateGroupRoles(Group groupInfo, List<Role> rolesAdded, List<Role> rolesDeleted)
        {

            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesAddedToGroup = GroupMapper.ConvertToGroupRoleProfileEntity(groupInfo, rolesAdded, (int)actionRequest.insert);
            await base.AddRange(rolesAddedToGroup);
            userUnitOfWork.Save();
            var rolesDeletedToGroup = GroupMapper.ConvertToGroupRoleProfileEntity(groupInfo, rolesDeleted, (int)actionRequest.delete);
            await base.UpdateRange(rolesDeletedToGroup);
            userUnitOfWork.Save();
            return groupRepository.GetRoleListwithId((int)groupInfo.GroupId);
        }
        public async Task<List<Role>> AddUsersRole(User userInfo, List<Role> Roles)
        {
           
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesLinkedToUser = UserMapper.ConvertToUserRolesEntity(userInfo, Roles, (int)actionRequest.insert);
            await base.AddRange(rolesLinkedToUser);
            userUnitOfWork.Save();
            return  userRepository.GetRoleListwithId((int)userInfo.UserID);
        }

        public async Task<List<Role>> AddGroupsRole(Group groupInfo, List<Role> Roles)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesLinkedToUser = GroupMapper.ConvertToGroupRoleProfileEntity(groupInfo, Roles, (int)actionRequest.insert);
            await base.AddRange(rolesLinkedToUser);
            userUnitOfWork.Save();
            return groupRepository.GetRoleListwithId((int)groupInfo.GroupId);
        }


        public List<Role> GetActiveRolesForuser(int userId)
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

            return queryIdList.ToList();
        }
       

        public async Task DeleteUserRoles(int userId)
        {
            try
            {
                UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getUserDetail =userRepository.GetUserDetails(userId);
            var getRolesDetail = GetActiveRolesForuser(userId);
           // var deleteRole= getRolesDetail.Where(r => r.CheckRole == true).Select(u => { u.CheckRole = false; return u; }).ToList();
            var userResult = UserMapper.ConvertToUserRolesEntity(getUserDetail, getRolesDetail, (int)actionRequest.delete);
              
                this.dbContext.Set<TUserProfile>().UpdateRange(userResult);
           
                await this.dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw (e);
            }

        }

        public async Task DeleteGroupRoles(int groupId)
        {

            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getGroupDetail = groupRepository.GetGroupDetails(groupId);
            var getRolesDetail = groupRepository.GetRoleListwithId(groupId);
            // var deleteRole= getRolesDetail.Where(r => r.CheckRole == true).Select(u => { u.CheckRole = false; return u; }).ToList();
            var groupResult = GroupMapper.ConvertToGroupRoleProfileEntity(getGroupDetail, getRolesDetail, (int)actionRequest.delete);
            await base.UpdateRange(groupResult);
            userUnitOfWork.Save();



        }

        public TUserProfile GetExistingRoles(User userInfo,  TUserProfile up)
        {
            var roleList = from tup in dbContext.Set<TUserProfile>().Where(o => o.UpRefType == (int)ProfileType.User && o.UpRefId == userInfo.UserID && o.UpRoleId == up.UpRoleId).Distinct()

                              select new TUserProfile
                              {
                                  UpId = tup.UpId,
                                  UpRefType = up.UpRefType,
                                  UpRefId = userInfo.UserID,
                                  UpRoleId =up.UpRoleId,
                                  UpModifiedOn = userInfo.UserModifiedOn,
                                  UpModifiedBy = userInfo.UserModifiedBy,
                                  UpStatus = up.UpStatus,
                                  UpCreatedBy = userInfo.CreatedBy,
                                  UpCreatedOn = userInfo.CreatedOn

                              };
            var userQuery = roleList.FirstOrDefault();
            //var Result = (userID != 0) ? userQuery : (userQuery.UserID == 0);
            return userQuery;

        }

    }
}