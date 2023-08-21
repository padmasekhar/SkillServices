using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillServices.Api.Constants;
using SkillServices.Api.Services;
using Microservices.Dtos;
using SkillServices.Api.LocalModels;

namespace SkillServices.Api.Controllers
{
    [Route("api/skillservice/[controller]")]
    [ApiController]
    //[Authorize(Policy = AppConstants.APP_POLICY)]
    public class SkillController : AppBaseController
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService, IConfiguration config, ILogger<SkillController> logger) : base(config, logger)
        {
            _skillService = skillService;
        }

        [HttpGet("/", Name = "Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _skillService.GetAsync();
            return OkWrapper(result);
        }

        [HttpGet("/{skillId:int}", Name = "GetById")]
        public async Task<IActionResult> GetById(int skillId)
        {
            var result = await _skillService.GetAsync(skillId);

            if (result == null)
                return NotFoundWrapper(skillId);

            return OkWrapper(result);
        }

        [HttpGet(Name = "GetByMultipleId")]
        public async Task<IActionResult> GetByMultipleId([FromQuery] params int[] skillIds)
        {
            var result = await _skillService.GetAsync(skillIds);

            if (result == null)
                return NotFoundWrapper(skillIds);

            return OkWrapper(result);
        }

        [HttpGet("/search",Name = "SearchSkills")]
        public async Task<IActionResult> SearchSkills([FromQuery] SearchSkill skill)
        {
            var result = await _skillService.GetAsync(skill);

            if (result == null || !result.Any())
                return NotFoundWrapper<SearchSkill>($"No skills matching with the given search criteria : {skill.ToString()}");

            return OkWrapper(result);
        }

        [HttpPost(Name = "CreateSkill")]
        public async Task<IActionResult> CreateSkill(SkillCreateDto skill)
        {
            var result = await _skillService.CreateAsync(skill);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "We are sorry, Something went wrong in skill creation!");
            }

            return OkWrapper(result);
        }

        [HttpDelete(Name = "DeleteSkill")]
        public async Task<IActionResult> DeleteSkill([FromBody] int skillId)
        {
            var isSuccess = await _skillService.DeleteSkillAsync(skillId);
            return OkWrapper(isSuccess, isSuccess ? AppConstants.SUCCESS : AppConstants.FAIL);
        }
    }
}
