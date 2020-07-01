using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using System.Linq;
using Asset.Repository.Common;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class GroupMapper
    {
        //TUserMaster destinationUsr ;
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }
     

        public static Group ConvertToGroupModel(this TGroupMaster grp)
        {
            return new Group
            {
                GroupId = grp.GmId,
                GroupDescription = grp.GmDescription,
                GroupModifiedOn = grp.GmModifiedOn,
                GroupModifiedBy = grp.GmModifiedBy
            };
        }

        public static List<Group> ConvertToGroupModelList(this List<TGroupMaster> grp)
        {
            return grp.Select(g => g.ConvertToGroupModel()).ToList();
        }

        public static TGroupMaster ConvertToGroupEntity(this Group grp)
        {
            return new TGroupMaster
            {
                GmId = Convert.ToInt32(grp.GroupId),
                GmName = grp.GroupName,
                GmDescription = grp.GroupDescription,
                GmModifiedOn = grp.GroupModifiedOn,
                GmModifiedBy = grp.GroupModifiedBy,
                GmStatus = grp.GroupStatus,
                GmCreatedBy = grp.CreatedBy,
                GmCreatedOn = grp.CreatedOn
               
            };
        }
        public static List<TGroupMaster> ConvertToGroupEntityList(this List<Group> grps)
        {
            return grps.Select(g => g.ConvertToGroupEntity()).ToList();

        }


        
        public static TGroupMaster ConvertToGroupEntityLst(this List<Group> groups)
        {
            return new TGroupMaster
            {
                GmId = Convert.ToInt32(groups[0].GroupId),
                GmDescription = groups[0].GroupDescription,
                GmModifiedOn = groups[0].GroupModifiedOn,
                GmModifiedBy = groups[0].GroupModifiedBy,
                GmCreatedBy = groups[0].CreatedBy,
                GmCreatedOn = groups[0].CreatedOn
            };
        }
        
        public static TGroupMaster ConvertToGroupsREntity(this GroupRole groups)
        { 
            return new TGroupMaster
            {
                GmId = Convert.ToInt32(groups.Groups.GroupId),
                GmName = groups.Groups.GroupName,
                GmDescription = groups.Groups.GroupDescription,
                GmModifiedOn = groups.Groups.GroupModifiedOn,
                GmModifiedBy = groups.Groups.GroupModifiedBy,
                GmStatus = groups.Groups.GroupStatus
                
            };
        }

         public static List<TUserProfile> ConvertToGroupRoleProfileEntity(this Group groupInfo, List<Role> Roles, int action)
        {
         var   rGrpL = new List<TUserProfile>();
        
              for( int i = 0; i< Roles.Count; i++)
                {

                if (action == (int)actionRequest.insert)
                {

                    rGrpL.Add(new TUserProfile
                    {

                        UpRefId = groupInfo.GroupId,
                        UpRefType = (int)ProfileType.Group,
                        UpRoleId = Roles[i].RoleId,
                        UpModifiedOn = groupInfo.GroupModifiedOn,
                        UpModifiedBy = groupInfo.GroupModifiedBy,
                        UpStatus = (Roles[i].CheckRole) ? 1 : 0,
                        UpCreatedBy = groupInfo.CreatedBy,
                        UpCreatedOn = groupInfo.CreatedOn

                    });
                }
                else if (action == (int)actionRequest.delete)
                {

                    rGrpL.Add(new TUserProfile
                    {
                        UpId = Convert.ToInt32(Roles[i].UserprofileId),
                        UpRefType = (int)ProfileType.Group,
                        UpRefId = groupInfo.GroupId,
                        UpRoleId = Roles[i].UserprofileRoleId,
                        UpModifiedOn = groupInfo.GroupModifiedOn,
                        UpModifiedBy = groupInfo.GroupModifiedBy,
                        UpStatus = (int)RecordStatus.Inactive,
                        UpCreatedBy = groupInfo.CreatedBy,
                        UpCreatedOn = groupInfo.CreatedOn


                    });
                }


            }
         return rGrpL;
        }

        
        
        public static CommonList ConvertToGrpModel(this TGroupMaster grp)
        {
            return new CommonList
            {
                ItemID = grp.GmId,
                ItemName = grp.GmDescription
               
            };
        }

        public static List<CommonList> ConvertToGrpModelList(this List<TGroupMaster> grp)
        {
            return grp.Select(g => g.ConvertToGrpModel()).ToList();
        }

        public static TGroupMaster ConvertToGroupEntity(this CommonList grp)
        {
            return new TGroupMaster
            {
                GmId = Convert.ToInt32(grp.ItemID),
                GmDescription = grp.ItemName
               
            };
        }
        public static List<TGroupMaster> ConvertToGroupEntityList(this List<CommonList> grps)
        {
            return grps.Select(g => g.ConvertToGroupEntity()).ToList();

        }
    }


}