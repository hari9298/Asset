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
    public class RolesLinkedToGroupRepository : Repository<TUserProfile>, IRolesLinkedToGroupRepository
    {
        GroupRepository groupRepository = new GroupRepository();
        public RolesLinkedToGroupRepository()
        {
            dbContext = new useradminContext();

        }

        public RolesLinkedToGroupRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }

        //public async Task<List<Role>> AddGroupsRole(Group groupInfo, List<Role> Roles)
        //{
        //    UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
        //    var rolesLinkedToUser = GroupMapper.ConvertToGroupRoleProfileEntity(groupInfo, Roles, (int)actionRequest.insert);
        //    await base.AddRange(rolesLinkedToUser);
        //    userUnitOfWork.Save();
        //    return groupRepository.GetRoleListwithId((int)groupInfo.GroupId);
        //}
        //public async Task DeleteGroupRoles(int groupId)
        //{

        //    UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
        //    var getGroupDetail = GetGroupDetails(groupId);
        //    var getRolesDetail = groupRepository.GetRoleListwithId(groupId);
        //    // var deleteRole= getRolesDetail.Where(r => r.CheckRole == true).Select(u => { u.CheckRole = false; return u; }).ToList();
        //    var groupResult = GroupMapper.ConvertToGroupRoleProfileEntity(getGroupDetail, getRolesDetail, (int)actionRequest.delete);
        //    await base.UpdateRange(groupResult);
        //    userUnitOfWork.Save();



        //}
        //public Group GetGroupDetails(int groupId)
        //{
        //    var groupbyId = new Group();
        //    var grp = from gm in dbContext.Set<TGroupMaster>().Where(a => a.GmStatus == 1 && a.GmId == groupId).Distinct()

        //              select new Group
        //              {
        //                  GroupId = gm.GmId,
        //                  GroupName = gm.GmName,
        //                  GroupDescription = gm.GmDescription,
        //                  GroupModifiedOn = gm.GmModifiedOn,
        //                  GroupModifiedBy = gm.GmModifiedBy,
        //                  GroupStatus = gm.GmStatus

        //              };
        //    var roleQuery = grp.FirstOrDefault();
        //    var Result = (groupId != 0) ? roleQuery : groupbyId;
        //    return Result;
        //}

      
    }
}
