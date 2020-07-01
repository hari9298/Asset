using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;
using Asset.Repository.Common;

namespace Asset.Repository.UserAdmin
{

    public class EmailTemplateRepository : Repository<TEmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository()
        {
            dbContext = new useradminContext();
        }

        public List<TEmailTemplate> GetAllEmailTemplateAsync()
        {
            return base.GetByIdAsync(a => a.EtStatus == 1);

        }

        public List<TEmailTemplate> GetEmailTemplateByIdAsync(int userId)
        {
            return base.GetByIdAsync(a => a.EtStatus == 1 && a.EtId == userId);

        }
        public TEmailTemplate GetEmailTemplateById(int userId)
        {
            return base.GetById(a => a.EtId == userId);

        }

        public async Task<EmailTemplate> AddEmailTemplate(TEmailTemplate templates)
        {
            // var cmp = GetEmailTemplateByIdAsync(templates.Id);
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            templates.EtStatus = (int)RecordStatus.Active;
            await base.Add(templates);
            userUnitOfWork.Save();
            int latestid = (int)templates.EtId;
            var Result = EmailTemplateMapper.ConvertToETModel(GetEmailTemplateById(latestid));
            return Result;

        }

        public async Task<EmailTemplate> UpdateEmailTemplateAsync(TEmailTemplate templates)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            templates.EtStatus = (int)RecordStatus.Active;
            await base.Update(templates);
            userUnitOfWork.Save();
            var Result = EmailTemplateMapper.ConvertToETModel(GetEmailTemplateById((int)templates.EtId));
            return Result;
        }

        public async Task DeleteEmailTemplateAsync(int id)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getRoleDetail = GetEmailTemplateById(id);
            getRoleDetail.EtStatus = (int)RecordStatus.Inactive;
            await base.Update(getRoleDetail);
            userUnitOfWork.Save();
        }
    }
}
