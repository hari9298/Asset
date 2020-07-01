using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asset.BO.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.Services.UserAdmin;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Abstractions;

namespace Asset.BO.UserAdmin
{
    [Produces("application/json")]
    [Route("api/EmailTemplate")]
    public class EmailTemplateController : Controller
    {
        EmailTemplateBO objETBO = new EmailTemplateBO();
        [HttpGet]
        [Route("all")]
        public List<EmailTemplateDTO> GetList()
        {
            var Result = objETBO.GetEmailTemplateList();
            var EtDto = ConvertModelToDto.ConvertEmailTemplateListModelToDTO(Result);
            return EtDto;
        }

        [HttpGet]
        [Route("viewdata/{id}")]
        public EmailTemplateDTO Get(int id)
        {
            var Result = objETBO.GetEmailtemplatesData(id);
            var EtDto = ConvertModelToDto.ConvertEmailTemplateModelToDTO(Result);
            return EtDto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmailTemplateDTO eTDTO)
        {
            var Result = objETBO.AddEmailTemplate(ConvertETDTOToModel(eTDTO));
            await Result;
            var roleFunctionDTO = ConvertModelToDto.ConvertEmailTemplateModelToDTO((EmailTemplate)Result.Result);
            if (roleFunctionDTO != null)
            {
                return Ok(roleFunctionDTO);
            }
            else
            {
                return BadRequest(eTDTO);
            }

        }

        [HttpDelete]
        [Route("{templateId}")]
        public async Task<IActionResult> Delete(int templateId)
        {
            var Result = objETBO.DeleteEmailTemplate(templateId);
            await Result;
            if (Result != null)
            {
                return Ok(Result.Result);
            }
            else
            {
                return BadRequest(Result.Result);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EmailTemplateDTO eTDTO)
        {
            var Result = objETBO.UpdateEmailTemplate(ConvertETDTOToModel(eTDTO));
            await Result;
            var roleFunctionDTO = ConvertModelToDto.ConvertEmailTemplateModelToDTO((EmailTemplate)Result.Result);
            if (roleFunctionDTO != null)
            {
                return Ok(roleFunctionDTO);
            }
            else
            {
                return BadRequest(Result);
            }
        }

        public EmailTemplate ConvertETDTOToModel(EmailTemplateDTO eTDTO)
        {
            return ConvertDtoToModel.ConvertEmailTemplateDTOToModel(eTDTO);
        }

    }
}