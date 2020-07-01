using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class StatusMapper
    {
        //TUserMaster destinationUsr ;
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }


        public static Status ConvertToStatusModel(this TStatusMaster stat)
        {
            return new Status
            {
                StatusId = stat.SmId,
                StatusDescription = stat.SmDescription,
                StatusModifiedOn = stat.SmModifiedOn,
                StatusModifiedBy = stat.SmModifiedBy
               

            };
        }

        public static List<Status> ConvertToStatusModelList(this List<TStatusMaster> stat)
        {
            return stat.Select(s => s.ConvertToStatusModel()).ToList();
        }

        public static TStatusMaster ConvertToStatusEntity(this Status stat)
        {
            return new TStatusMaster
            {
                SmId = Convert.ToInt32(stat.StatusId),
                SmDescription = stat.StatusDescription,
                SmModifiedOn = stat.StatusModifiedOn,
                SmModifiedBy = stat.StatusModifiedBy
               
               
               
            };
        }
        public static List<TStatusMaster> ConvertToStatusEntityList(this List<Status> stat)
        {
            return stat.Select(s => s.ConvertToStatusEntity()).ToList();

        }
    }


}