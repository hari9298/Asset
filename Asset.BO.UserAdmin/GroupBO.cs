using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;


namespace Asset.BO.UserAdmin
{

    public  class GroupBO
    {
     
        GroupRepository groupRepository ;

        RolesLinkedToUserRepository roleLinkToUserRepository;
        public Group GroupInfo { get; set; }
        public List<Role> RolesLinkedToGroup { get; set; }
        public GroupBO()
        {
            groupRepository= new GroupRepository();
            roleLinkToUserRepository = new RolesLinkedToUserRepository(groupRepository.GetDBContext());
        }

        public GroupBO(int groupId)
        {
            groupRepository = new GroupRepository();
            GroupInfo = GetGroupData(groupId);
            RolesLinkedToGroup = GetGroupRole(groupId);
        }

        //neharika
        public Group GetGroupData(int groupId)
        {
            var groupEntity = groupRepository.GetGroupDetails(groupId);
            return groupEntity;
        }

        public List<Role> GetGroupRole(int groupId)
        {
            var Result = groupRepository.GetRoleListwithId(groupId);
            return Result;

        }


        //
        public List<Group> GetGroupList()
        {
        
           var Result = groupRepository.GetGroupWithDetails();
            return Result;
        }
         public List<Role> GetRoles()
        {   
            var Result = groupRepository.GetRoleWithGroupDetails();
            return Result.ToList();
           
        }

        public List<CommonList> GetGroup()
        {
            var Result = groupRepository.GetGroupDP();
            return Result.ToList();

        }
        public GroupRole GetGroupRoleAll()
        {
            var Result = groupRepository.GetGroupsWithRoles();
            return Result;
           
        }
         public GroupRole GetGroupwithId(int id)
        {

            var Result = groupRepository.GetGroupByIdAsync(id);       
            return Result;
        }
        public async Task<List<object>> Add(Group groupInfo, List<Role> Roles)
        {
            List<object> groupRoles = new List<object>();
            var currentGroup =await groupRepository.AddGroup(groupInfo, Roles);
            var roles = await roleLinkToUserRepository.AddGroupsRole(currentGroup, Roles);
            groupRoles.Add(currentGroup);
            groupRoles.Add(roles);
            return groupRoles;

        }

        public async Task<List<object>> UpdateGroupDetails(Group groupInfo, List<Role> rolesAdded, List<Role> rolesDeleted)
        {
            List<object> groupRoles = new List<object>();
            var user = await groupRepository.UpdateGroup(groupInfo, rolesAdded, rolesDeleted);
            var roles = await roleLinkToUserRepository.UpdateGroupRoles(groupInfo, rolesAdded, rolesDeleted);
            groupRoles.Add(user);
            groupRoles.Add(roles);
            return groupRoles;

        }
        //public  async Task<GroupRole> Update(GroupRole grouprole)
        //{   
        //    await groupRepository.UpdateGroup(grouprole);
        //    await groupRepository.UpdateGroupsWithAllEntities(grouprole);
        //    var Result =  groupRepository.GetGroupByIdAsync(Convert.ToInt32(grouprole.Groups.GroupId));
        //        return Result;
        //}

        public async Task<Group> Delete(int groupId)
        {
            var getRoleDetails = groupRepository.GetGroupDetails(Convert.ToInt32(groupId));
            if (getRoleDetails != null)
            {
               
                await roleLinkToUserRepository.DeleteGroupRoles(groupId);
                await groupRepository.DeleteGroup(groupId);
            }

            return getRoleDetails;
        }


    }
}