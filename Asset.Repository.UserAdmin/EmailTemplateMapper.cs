using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class EmailTemplateMapper
    {
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }


        public static EmailTemplate ConvertToETModel(this TEmailTemplate et)
        {
            return new EmailTemplate
            {
                ETId = et.EtId,
                ETName = et.EtName,
                ETDescription = et.EtDescription,
                ETBoday = et.EtTemplateBody,
                ETCreatedBy = et.EtCreatedBy,
                ETCreatedOn = et.EtCreatedOn,
                ETModifiedBy = et.EtModifiedBy,
                ETModifiedOn = et.EtModifiedOn,
                ETStatus = et.EtStatus
            };
        }

        public static List<EmailTemplate> ConvertToETModelList(this List<TEmailTemplate> ETs)
        {
            return ETs.Select(et => et.ConvertToETModel()).ToList();
        }

        public static TEmailTemplate ConvertToETEntity(this EmailTemplate et)
        {
            return new TEmailTemplate
            {
                EtId = et.ETId,
                EtName = et.ETName,
                EtDescription = et.ETDescription,
                EtTemplateBody = et.ETBoday,
                EtCreatedBy = et.ETCreatedBy,
                EtCreatedOn = et.ETCreatedOn,
                EtModifiedBy = et.ETModifiedBy,
                EtModifiedOn = et.ETModifiedOn,
                EtStatus = et.ETStatus
            };
        }
        public static List<TEmailTemplate> ConvertToETEntityList(this List<EmailTemplate> cmps)
        {
            return cmps.Select(usr => usr.ConvertToETEntity()).ToList();

        }
    }
}
