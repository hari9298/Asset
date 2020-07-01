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
    public static class RoleMapper
    {
        //TUserMaster destinationUsr ;
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }


        // public static CoreApi.Model.RoleList ConvertToRoleModel(this TRoleMaster roles, TRoleFunctionLink tfunl,TUserProfile tusp)
        // {
        //     return new CoreApi.Model.RoleList
        //     {
        //         RoleId = roles.RmId,
        //         RoleName = roles.RmName,
        //         RoleDescription = roles.RmDescription,
        //         RolefunlRole = tfunl.RflRole,
        //         RolefunlAccessKey = tfunl.RflAccessKey,
        //         RolefunlId = tfunl.RflId,
        //         RoleStatus = roles.RmStatus,
        //         RolefunlFunction = tfunl.RflFunction,
        //         RoleType = roles.RmType,
        //         RoleModifiedBy = roles.RmModifiedBy,
        //         RoleModifiedOn = roles.RmModifiedOn,
        //         RolefunlModifiedBy = tfunl.RflModifiedBy,
        //         RolefunlModifiedOn = tfunl.RflModifiedOn,
        //         RolefunlStatus = tfunl.RflStatus,
        //         UserprofileId = tusp.UpId,
        //         UserprofileRefId = tusp.UpRefId,
        //         UserprofileRoleId = tusp.UpRoleId,
        //         UserprofileStatus = tusp.UpStatus,
        //         UserprofileRefType = tusp.UpRefType
        //     };
        // }

        // public static List<CoreApi.Model.RoleList> ConvertToUserModelList(this List<TRoleMaster> roless, List<TRoleFunctionLink> tfunl,List<TUserProfile> tusp)
        // {
           
        //     return roless.Select(usr => usr.ConvertToRoleModel()).ToList();
        // }

        public static TRoleMaster ConvertToRoleEntity(this List<Role> roles)
        {
            return new TRoleMaster
            {
                RmId = Convert.ToInt32(roles[0].RoleId),
                RmName = roles[0].RoleName,
                RmDescription = roles[0].RoleDescription,
                RmModifiedOn = roles[0].RoleModifiedOn,
                RmModifiedBy =  roles[0].RoleModifiedBy,
                RmStatus = roles[0].RoleStatus,
                RmType = roles[0].RoleType,
                RmCreatedBy = roles[0].CreatedBy,
                RmCreatedOn = roles[0].CreatedOn
                
            };
        }

        // public static CoreApi.Entities.TRoleFunctionLink ConvertToRolefunEntity(this List<CoreApi.Model.RoleList> roles)
        // {
        //     return new CoreApi.Entities.TRoleFunctionLink
        //     {
        //         RflId = Convert.ToInt32(roles[0].RolefunlId),
        //         RflFunction = roles[0].RolefunlFunction,
        //         RflRole = roles[0].RolefunlRole,
        //         RflAccessKey = roles[0].RolefunlAccessKey,
        //         RflStatus =  roles[0].RolefunlStatus,
        //         RflModifiedOn = roles[0].RolefunlModifiedOn,
        //         RflModifiedBy = roles[0].RolefunlModifiedBy
                
        //     };
        // }
         public static TUserProfile ConvertToUserProfileEntity(this List<Role> roles)
        {
            return new TUserProfile
            {
                UpId = Convert.ToInt32(roles[0].UserprofileId),
                UpStatus = roles[0].UserprofileStatus,
                UpRoleId = roles[0].UserprofileRoleId,
                UpRefId = roles[0].UserprofileRefId,
                UpRefType =  roles[0].UserprofileRefType,
                UpModifiedBy = roles[0].UserprofileModifiedBy,
                UpModifiedOn = roles[0].UserprofileModifiedOn
                
            };
        }
       
        public static TRoleMaster ConvertToRolesEntity(this Role roles)
        {
            return new TRoleMaster
            {
                RmId = Convert.ToInt32(roles.RoleId),
                RmName = roles.RoleName,
                RmDescription = roles.RoleDescription,
                RmModifiedOn = roles.RoleModifiedOn,
                RmModifiedBy =  roles.RoleModifiedBy,
                RmStatus = roles.RoleStatus,
                RmType = roles.RoleType,
                RmCreatedOn =roles.CreatedOn,
                RmCreatedBy = roles.CreatedBy
                
            };
        }

        // public static CoreApi.Entities.TRoleFunctionLink ConvertToRolesfunEntity(this CoreApi.Model.RoleList roles)
        // {
        //     return new CoreApi.Entities.TRoleFunctionLink
        //     {
        //         RflId = Convert.ToInt32(roles.RolefunlId),
        //         RflFunction = roles.RolefunlFunction,
        //         RflRole = roles.RolefunlRole,
        //         RflAccessKey = roles.RolefunlAccessKey,
        //         RflStatus =  roles.RolefunlStatus,
        //         RflModifiedOn = roles.RolefunlModifiedOn,
        //         RflModifiedBy = roles.RolefunlModifiedBy
                
        //     };
        // }
         public static TUserProfile ConvertToUserProfilesEntity(this Role roles)
        {
            return new TUserProfile
            {
                UpId = Convert.ToInt32(roles.UserprofileId),
                UpStatus = roles.UserprofileStatus,
                UpRoleId = roles.UserprofileRoleId,
                UpRefId = roles.UserprofileRefId,
                UpRefType =  roles.UserprofileRefType,
                UpModifiedBy = roles.UserprofileModifiedBy,
                UpModifiedOn = roles.UserprofileModifiedOn
                
            };
        }

        //public static TRoleMaster ConvertToRoleFEntity(this List<RoleFunction> roles)
        //{
        //    return new TRoleMaster
        //    {
        //        RmId = Convert.ToInt32(roles[0].Roles.RoleId),
        //        RmName = roles[0].Roles.RoleName,
        //        RmDescription = roles[0].Roles.RoleDescription,
        //        RmModifiedOn = roles[0].Roles.RoleModifiedOn,
        //        RmModifiedBy =  roles[0].Roles.RoleModifiedBy,
        //        RmStatus = roles[0].Roles.RoleStatus,
        //        RmType = roles[0].Roles.RoleType

        //    };
        //}

        //public static List<TRoleFunctionLink> ConvertToRolefunEntity(this List<CoreApi.Model.RoleFunction> roles)
        //{
        //    // return new CoreApi.Entities.TRoleFunctionLink
        //    // {
        //    //     RflId = Convert.ToInt32(roles[0].Funtions[0].RolefunlId),
        //    //     RflFunction = roles[0].Funtions[0].RolefunctionlinkFunction,
        //    //     RflRole = roles[0].Funtions[0].RolefunctionlinkRole,
        //    //     RflAccessKey = roles[0].Funtions[0].RolefunctionlinkAccessKey,
        //    //     RflStatus =  roles[0].Roles.RoleStatus,
        //    //     RflModifiedOn = roles[0].Roles.RoleModifiedOn,
        //    //     RflModifiedBy = roles[0].Roles.RoleModifiedBy

        //    // };
        //    var   rFunL = new List<CoreApi.Entities.TRoleFunctionLink>();

        //       for( int i = 0; i< roles[0].Funtions.Count; i++)
        //        {
        //         rFunL.Add(new CoreApi.Entities.TRoleFunctionLink{
        //        RflId = Convert.ToInt32(roles[0].Funtions[i].RolefunlId),
        //       RflFunction = roles[0].Funtions[i].RolefunctionlinkFunction,
        //        RflRole = roles[0].Funtions[i].RolefunctionlinkRole,
        //        RflAccessKey = Conversions.ConvertBinaryStringtoInt(Convert.ToBoolean(roles[0].Funtions[i].canView), Convert.ToBoolean(roles[0].Funtions[i].canAdd), Convert.ToBoolean(roles[0].Funtions[i].canUpdate), Convert.ToBoolean(roles[0].Funtions[i].canDelete)),
        //         RflStatus =  roles[0].Roles.RoleStatus,
        //         RflModifiedOn = roles[0].Roles.RoleModifiedOn,
        //         RflModifiedBy = roles[0].Roles.RoleModifiedBy

        //        });

        // }
        // return rFunL;
        //}
        // public static CoreApi.Entities.TFunctionMaster ConvertToFunctionEntity(this List<CoreApi.Model.RoleFunction> roles)
        //{
        //    return new CoreApi.Entities.TFunctionMaster
        //    {
        //        FmId = Convert.ToInt32(roles[0].Funtions[0].FunctionId),
        //        FmName = roles[0].Funtions[0].FunctionName,
        //        FmUri = roles[0].Funtions[0].FunctionUri,
        //        FmOrder = roles[0].Funtions[0].FunctionOrder,
        //        FmType =   roles[0].Funtions[0].FunctionType,
        //        FmModifiedBy = roles[0].Roles.RoleModifiedBy,
        //        FmModifiedOn = roles[0].Roles.RoleModifiedOn,
        //        FmStatus = roles[0].Roles.RoleStatus

        //    };
        //}

        public static TRoleMaster ConvertToRolesFEntity(this Role roles)
        {
            return new TRoleMaster
            {
                RmId = Convert.ToInt32(roles.RoleId),
                RmName = roles.RoleName,
                RmDescription = roles.RoleDescription,
                RmModifiedOn = roles.RoleModifiedOn,
                RmModifiedBy = roles.RoleModifiedBy,
                RmStatus = roles.RoleStatus,
                RmType = roles.RoleType,
                RmCreatedBy = roles.CreatedBy,
                RmCreatedOn = roles.CreatedOn
            };
        }

        public static List<TRoleFunctionLink> ConvertToRolesfunEntity(this Role role , List<Function> functions, int action)
        {
            var rFunL = new List<TRoleFunctionLink>();

            for (int i = 0; i < functions.Count; i++)
            {
                if (action == (int)actionRequest.insert)
                {
                    rFunL.Add(new TRoleFunctionLink
                    {
                        RflFunction = functions[i].RolefunctionlinkFunction,
                        RflRole = role.RoleId,
                        RflAccessKey = Conversion.ConvertBinaryStringtoInt(Convert.ToBoolean(functions[i].canView), Convert.ToBoolean(functions[i].canAdd), Convert.ToBoolean(functions[i].canUpdate), Convert.ToBoolean(functions[i].canDelete)),
                        RflStatus = (int)RecordStatus.Active,
                        RflModifiedOn = role.RoleModifiedOn,
                        RflModifiedBy = role.RoleModifiedBy,
                        RflCreatedBy = role.CreatedBy,
                        RflCreatedOn = role.CreatedOn
                    });
                }
                else if (action == (int)actionRequest.delete)
                {
                    rFunL.Add(new TRoleFunctionLink
                    {
                        RflId = Convert.ToInt32(functions[i].RolefunlId),
                        RflFunction = functions[i].RolefunctionlinkFunction,
                        RflRole = functions[i].RolefunctionlinkRole,
                        RflAccessKey = Conversion.ConvertBinaryStringtoInt(Convert.ToBoolean(functions[i].canView), Convert.ToBoolean(functions[i].canAdd), Convert.ToBoolean(functions[i].canUpdate), Convert.ToBoolean(functions[i].canDelete)),
                        RflStatus = (int)RecordStatus.Inactive,
                        RflModifiedOn = role.RoleModifiedOn,
                        RflModifiedBy = role.RoleModifiedBy,
                        RflCreatedBy = role.CreatedBy,
                        RflCreatedOn = role.CreatedOn
                    });
                }

                else if (action == (int)actionRequest.edit)
                {
                    rFunL.Add(new TRoleFunctionLink
                    {
                        RflId = Convert.ToInt32(functions[i].RolefunlId),
                        RflFunction = functions[i].RolefunctionlinkFunction,
                        RflRole = functions[i].RolefunctionlinkRole,
                        RflAccessKey = Conversion.ConvertBinaryStringtoInt(Convert.ToBoolean(functions[i].canView), Convert.ToBoolean(functions[i].canAdd), Convert.ToBoolean(functions[i].canUpdate), Convert.ToBoolean(functions[i].canDelete)),
                        RflStatus = (int)RecordStatus.Active,
                        RflModifiedOn = role.RoleModifiedOn,
                        RflModifiedBy = role.RoleModifiedBy,
                        RflCreatedBy = role.CreatedBy,
                        RflCreatedOn = role.CreatedOn
                    });
                }


            }
            return rFunL;
        }
        // public static CoreApi.Entities.TFunctionMaster ConvertToFunctionsEntity(this CoreApi.Model.RoleFunction roles)
        //{
        //   return new CoreApi.Entities.TFunctionMaster
        //    {
        //        FmId = Convert.ToInt32(roles.Funtions[0].FunctionId),
        //        FmName = roles.Funtions[0].FunctionName,
        //        FmUri = roles.Funtions[0].FunctionUri,
        //        FmOrder = roles.Funtions[0].FunctionOrder,
        //        FmType =   roles.Funtions[0].FunctionType,
        //        FmModifiedBy = roles.Roles.RoleModifiedBy,
        //        FmModifiedOn = roles.Roles.RoleModifiedOn,
        //        FmStatus = roles.Roles.RoleStatus

        //    };
        //}

        // public static List<CoreApi.Entities.TUserMaster> ConvertToUserEntityList(this List<CoreApi.Model.UserList> userss)
        // {
        //     return userss.Select(usr => usr.ConvertToUserEntity()).ToList();

        // }
    }


}