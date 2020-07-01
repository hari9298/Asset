using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.Repository.Common;

namespace Asset.Repository.UserAdmin
{
    public class GroupRepository : Repository<TGroupMaster>, IGroupRepository
    {
        //private enum EGroup
        //{
        //    groupId = 0,
        //    groupStatus = 1,
        //    gmStatus = 0,
        //    SmId = 1
        //}
        //private enum UserProfile
        //{
        //    userProfileId = 0,
        //    userProfileStatus = 0,
        //    UpRoleId = 0,
        //    UpRefType = 1,
        //    UpStatus = 1,
        //    UserprofileModifiedBy = 1,

        //}


        public GroupRepository()
        {
            dbContext = new useradminContext();
        }
        public GroupRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }
        public useradminContext GetDBContext()
        {
            return dbContext as useradminContext;
        }
        public List<TGroupMaster> GetAllGroupAsync()

        {
            return base.GetAllAsync();
        }
       
        public List<Group> GetGroupWithDetails()
        {

            var queryGroupM = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == (int)RecordStatus.Active).Distinct()
                              select new Group {
                                  GroupId = gm.GmId,
                                  GroupName = gm.GmName,
                                  GroupDescription = gm.GmDescription,
                                  GroupModifiedOn = gm.GmModifiedOn,
                                  GroupModifiedBy = gm.GmModifiedBy,
                                  GroupStatus = gm.GmStatus,
                                  CreatedBy = gm.GmCreatedBy,
                                  CreatedOn = gm.GmCreatedOn

                              };


            return (queryGroupM.ToList());

        }

        public List<CommonList> GetGroupDP()
        {

            var queryGroupM = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == (int)RecordStatus.Active).Distinct()
                              select new CommonList
                              {
                                  ItemID = gm.GmId,
                                  ItemName = gm.GmName,
                              };


            return (queryGroupM.ToList());

        }
        public List<Role> GetRoleWithGroupDetails()
        {


            var rolet = from

           rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()

                        select new Role
                        {
                            RoleId = rm.RmId,
                            RoleName = rm.RmName,
                            RoleType = rm.RmType,
                            RoleDescription = rm.RmDescription,
                            RoleModifiedOn = rm.RmModifiedOn,
                            RoleModifiedBy = rm.RmModifiedBy,
                            RoleStatus = rm.RmStatus,

                            UserprofileId = 0,
                            UserprofileRefType = rm.RmType,
                            UserprofileRefId = 0,
                            UserprofileRoleId = rm.RmId,
                            UserprofileModifiedOn = rm.RmModifiedOn,
                            UserprofileModifiedBy = rm.RmModifiedBy,
                            UserprofileStatus = rm.RmStatus,
                            CheckRole = false
                        };


            return ((rolet.GroupBy(f => f.RoleId).Select(o => o.FirstOrDefault())).ToList());

        }
        public GroupRole GetGroupsWithRoles()
        {

            var grpt = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == (int)RecordStatus.Active).Distinct()
                       select new Group
                       {
                           GroupId = gm.GmId,
                           GroupName = gm.GmName,
                           GroupDescription = gm.GmDescription,
                           GroupModifiedOn = gm.GmModifiedOn,
                           GroupModifiedBy = gm.GmModifiedBy,
                           GroupStatus = gm.GmStatus

                       };
            var grps = grpt.FirstOrDefault();
            var rolet = from gm in dbContext.Set<TGroupMaster>().Distinct()
                        join tup in dbContext.Set<TUserProfile>().Where(t => t.UpRefType == (int)ProfileType.Group) on gm.GmId equals tup.UpRefId
                        join rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active) on tup.UpRoleId equals rm.RmId into rgroups
                        from rl in rgroups.DefaultIfEmpty()
                        select new Role
                        {
                            RoleId = rl.RmId,
                            RoleName = rl.RmName,
                            RoleType = rl.RmType,
                            RoleDescription = rl.RmDescription,
                            RoleModifiedOn = rl.RmModifiedOn,
                            RoleModifiedBy = rl.RmModifiedBy,
                            RoleStatus = rl.RmStatus,

                            UserprofileId = tup.UpId,
                            UserprofileRefType = tup.UpRefType,
                            UserprofileRefId = tup.UpRefId,
                            UserprofileRoleId = tup.UpRoleId,
                            UserprofileModifiedOn = tup.UpModifiedOn,
                            UserprofileModifiedBy = tup.UpModifiedBy,
                            UserprofileStatus = tup.UpStatus,
                            CheckRole = (tup.UpRoleId > 0 && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                        };

            var rolesAndgroups = new GroupRole
            {

                Groups = grps,
                Roles = (rolet.GroupBy(f => f.RoleId).Select(o => o.FirstOrDefault())).Distinct().ToList()

            };
            return (rolesAndgroups);
        }

        public GroupRole GetGroupByIdAsync(int groupId)
        {

            var grp = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == (int)RecordStatus.Active && a.GmId == groupId).Distinct()

                      select new Group
                      {
                          GroupId = gm.GmId,
                          GroupName = gm.GmName,
                          GroupDescription = gm.GmDescription,
                          GroupModifiedOn = gm.GmModifiedOn,
                          GroupModifiedBy = gm.GmModifiedBy,
                          GroupStatus = gm.GmStatus,
                          CreatedBy = gm.GmCreatedBy,
                          CreatedOn = gm.GmCreatedOn

                      };
            var grps = grp.FirstOrDefault();
            var grpwithId = new Group();
            var rolwithId = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()

                            select new Role
                            {
                                RoleId = rm.RmId,
                                RoleName = rm.RmName,
                                RoleType = rm.RmType,
                                RoleDescription = rm.RmDescription,
                                RoleModifiedOn = rm.RmModifiedOn,
                                RoleModifiedBy = rm.RmModifiedBy,
                                RoleStatus = rm.RmStatus,

                                UserprofileId = 0,
                                UserprofileRefType = (int)ProfileType.Group,
                                UserprofileRefId = 0,
                                UserprofileRoleId = rm.RmId,
                                UserprofileModifiedOn = DateTime.Now,
                                UserprofileModifiedBy = rm.RmModifiedBy,
                                UserprofileStatus = (int)RecordStatus.Active,
                                CheckRole = false
                            };
            var queryRoleGId = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
                               join tup in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == groupId && o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.Group).Distinct()
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
                                   CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == groupId && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                               };
            var qidList = queryRoleGId.ToList();
            var rolest = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                         join tup in dbContext.Set<TUserProfile>().Distinct() on rm.RmId equals tup.UpRoleId
                         where !(from rolm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
                                 join tups in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == groupId && o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.Group).Distinct()
                                 on rolm.RmId equals tups.UpRoleId
                                 select rolm.RmId).Contains(rm.RmId)

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
                             CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == groupId && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                         };

            var Roleexceptgrp = rolest.GroupBy(f => f.RoleId);


            var roletR = Roleexceptgrp.Select(o => o.FirstOrDefault()).Except(queryRoleGId);
            var roletResult = (roletR
                              .Union(qidList));
            var rolesAndgroups = new GroupRole
            {
                Groups = (groupId != 0) ? grps : grpwithId,

                Roles = (groupId != 0) ? roletResult.ToList() : rolwithId.ToList()

            };

            return (rolesAndgroups);
        }

        public TGroupMaster GetRolesById(int groupId) {
            return base.GetById(a => a.GmId == groupId);
        }

        //public async Task AddGroup(GroupRole group)
        //{
        //    var groupResult = GroupMapper.ConvertToGroupsREntity(group);
        //    groupResult.GmStatus = (int)EGroup.groupStatus;
        //    await base.Add(groupResult);
        //}
        public async Task<Group> AddGroup(Group group, List<Role> roles)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var groupResult = GroupMapper.ConvertToGroupEntity(group);
            groupResult.GmStatus = (int)RecordStatus.Active;
            await base.Add(groupResult);
            userUnitOfWork.Save();
            int latestGroupid = (int)groupResult.GmId;
            return GetGroupDetails(latestGroupid);
        }

        public async Task<Group> UpdateGroup(Group groupInfo, List<Role> Roles, List<Role> RolesDeleted)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var groupResult = GroupMapper.ConvertToGroupEntity(groupInfo);
            groupResult.GmStatus = (int)RecordStatus.Active;
            await base.Update(groupResult);
            userUnitOfWork.Save();
            return GetGroupDetails((int)groupResult.GmId);
          
        }
        //public async Task UpdateGroup(GroupRole group)
        //{
        //    var groupResult = GroupMapper.ConvertToGroupsREntity(group);
        //  //  groupResult.GmStatus = (int)EGroup.groupStatus;
        //    await base.Update(groupResult);
        //}

        public async Task DeleteGroup(int groupId)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getGroupDetail = GetGroupDetails(groupId);
            var groupResult = GroupMapper.ConvertToGroupEntity(getGroupDetail);
            groupResult.GmStatus = (int)RecordStatus.Inactive; 
            await base.Update(groupResult);
            userUnitOfWork.Save();
        }


        //public async Task AddGroupsWithAllEntities(GroupRole group) {
        //    var groupResult = GroupMapper.ConvertToGroupsREntity(group);
        //    var UserProfileResult = GroupMapper.ConvertToGroupRoleProfileEntity(group);

        //    foreach (var tuserProfile in UserProfileResult)
        //    {
        //        tuserProfile.UpRefId = groupResult.GmId;
        //        tuserProfile.UpRefType = (int)UserProfile.UpRefType; ;
        //        //tu.UpStatus = 1;
        //        tuserProfile.UpId = (int)UserProfile.userProfileId;
        //        tuserProfile.UpModifiedOn = DateTime.Now;
        //    }
        //    this.dbContext.Set<TUserProfile>().AddRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateGroupsWithAllEntities(GroupRole group)
        //{
        //    var groupResult = GroupMapper.ConvertToGroupsREntity(group);
        //    var UserProfileResult = GroupMapper.ConvertToGroupRoleProfileEntity(group);
        //    foreach (var tuserprofile in UserProfileResult)
        //    {
        //        tuserprofile.UpRefId = groupResult.GmId;
        //        tuserprofile.UpRefType = (int)UserProfile.UpRefType;
        //        tuserprofile.UpModifiedOn = DateTime.Now;
        //    }


        //    this.dbContext.Set<TUserProfile>().UpdateRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();


        //}

        //public async Task DeleteGroupsWithAllEntities(GroupRole group) {
        //    var groupResult = GroupMapper.ConvertToGroupsREntity(group);
        //    var UserProfileResult = GroupMapper.ConvertToGroupRoleProfileEntity(group);
        //    foreach (var tuserprofile in UserProfileResult)
        //    {
        //        tuserprofile.UpRefId = groupResult.GmId;
        //        tuserprofile.UpStatus = (int)UserProfile.userProfileStatus;
        //        tuserprofile.UpRefType = (int)UserProfile.UpRefType;
        //        tuserprofile.UpModifiedOn = DateTime.Now;
        //    }

        //    this.dbContext.Set<TUserProfile>().UpdateRange(UserProfileResult);

        //    await this.dbContext.SaveChangesAsync();


        //}

        ////////////added 07-05-2019
        ///
        public Group GetGroupDetails(int groupId)
        {
            var groupbyId = new Group();
            var grp = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == (int)RecordStatus.Active && a.GmId == groupId).Distinct()

                      select new Group
                      {
                          GroupId = gm.GmId,
                          GroupName = gm.GmName,
                          GroupDescription = gm.GmDescription,
                          GroupModifiedOn = gm.GmModifiedOn,
                          GroupModifiedBy = gm.GmModifiedBy,
                          GroupStatus = gm.GmStatus

                      };
            var roleQuery = grp.FirstOrDefault();
            var Result = (groupId != 0) ? roleQuery : groupbyId;
            return Result;
        }

        public List<Role> GetRoleListwithId(int groupId)
        {

              var grpwithId = new Group();
        var rolwithId = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                        join tup in dbContext.Set<TUserProfile>().Distinct() on rm.RmId equals tup.UpRoleId

                        select new Role
                        {
                            RoleId = rm.RmId,
                            RoleName = rm.RmName,
                            RoleType = rm.RmType,
                            RoleDescription = rm.RmDescription,
                            RoleModifiedOn = rm.RmModifiedOn,
                            RoleModifiedBy = rm.RmModifiedBy,
                            RoleStatus = rm.RmStatus,

                            UserprofileId = 0,
                            UserprofileRefType = (int)ProfileType.Group,
                            UserprofileRefId = 0,
                            UserprofileRoleId = rm.RmId,
                            UserprofileModifiedOn = DateTime.Now,
                            UserprofileModifiedBy = tup.UpModifiedBy,
                            UserprofileStatus = (int)RecordStatus.Active,
                            CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == groupId && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                        };
        var queryRoleGId = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
                           join tup in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == groupId && o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.Group).Distinct()
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
                               CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == groupId && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                           };
        var qidList = queryRoleGId.ToList();
        var rolest = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active).Distinct()
                     join tup in dbContext.Set<TUserProfile>().Distinct() on rm.RmId equals tup.UpRoleId
                     where !(from rolm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == (int)RecordStatus.Active)
                             join tups in dbContext.Set<TUserProfile>().Where(o => o.UpRefId == groupId && o.UpStatus == (int)RecordStatus.Active && o.UpRefType == (int)ProfileType.Group).Distinct()
                             on rolm.RmId equals tups.UpRoleId
                             select rolm.RmId).Contains(rm.RmId)

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
                         CheckRole = (tup.UpRoleId > 0 && tup.UpRefId == groupId && tup.UpRefType == (int)ProfileType.Group && tup.UpStatus == (int)RecordStatus.Active) ? true : false
                     };

        var Roleexceptgrp = rolest.GroupBy(f => f.RoleId);


        var roletR = Roleexceptgrp.Select(o => o.FirstOrDefault()).Except(queryRoleGId);
        var roletResult = (roletR
                          .Union(qidList));
            //var rolesAndgroups = new GroupRole
            //{
            //    Groups = (groupId != 0) ? grps : grpwithId,

            //    Roles = (groupId != 0) ? roletResult.ToList() : rolwithId.ToList()

            //};

            // return (rolesAndgroups);

            return roletResult.ToList();


            }

}
}