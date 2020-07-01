using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;


namespace Asset.BO.UserAdmin
{
    public class EmailTemplateBO
    {
        EmailTemplateRepository emailTemplateRepository;
        public EmailTemplate RoleInfo { get; set; }

        public EmailTemplateBO()
        {
            emailTemplateRepository = new EmailTemplateRepository();
        }

        public List<EmailTemplate> GetEmailTemplateList()
        {
            var Result = emailTemplateRepository.GetAllEmailTemplateAsync();
            return EmailTemplateMapper.ConvertToETModelList(Result);

        }
        public EmailTemplate GetEmailtemplatesData(int templateId)
        {
            var Result = emailTemplateRepository.GetEmailTemplateByIdAsync(templateId).FirstOrDefault();
            return EmailTemplateMapper.ConvertToETModel(Result);
        }

        public async Task<EmailTemplate> AddEmailTemplate(EmailTemplate emailTemplate)
        {
            return await emailTemplateRepository.AddEmailTemplate(ConvertEntiy(emailTemplate));
        }
        public async Task<EmailTemplate> UpdateEmailTemplate(EmailTemplate emailTemplate)
        {
            return await emailTemplateRepository.UpdateEmailTemplateAsync(ConvertEntiy(emailTemplate));

        }
        public async Task<EmailTemplate> DeleteEmailTemplate(int templateId)
        {


            var getRoleDetail = emailTemplateRepository.GetEmailTemplateById(templateId);
            if (getRoleDetail != null)
            {
                await emailTemplateRepository.DeleteEmailTemplateAsync(templateId);
            }
            return EmailTemplateMapper.ConvertToETModel(getRoleDetail);

        }

        private TEmailTemplate ConvertEntiy(EmailTemplate emailTemplate)
        {
            var convertEntiy = EmailTemplateMapper.ConvertToETEntity(emailTemplate);
            return convertEntiy;
        }

    }
}