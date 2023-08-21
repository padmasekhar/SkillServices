using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ps.EfCoreRepository.SqlServer;
using SkillServices.Data.DbModels;
using Microservices.Dtos;
using SkillServices.Api.LocalModels;
using System.Linq.Expressions;
using System.Linq;

namespace SkillServices.Api.Services.Definitions
{
    public class SkillService : ServiceBase, ISkillService
    {
        public SkillService(IRepository repository, ILogger<SkillService> logger, IConfiguration config, IMapper mapper, IHttpContextAccessor context) : base(repository, logger, config, mapper, context)
        {
        }

        public async Task<SkillReadDto> CreateAsync(SkillCreateDto skillDto)
        {
            if (skillDto == null) 
                throw new ArgumentNullException(nameof(skillDto));

            Skill skill = Mapper.Map<Skill>(skillDto);
            await Repository.InsertAsync(skill);
            return await GetAsync(skill.SkillId);
        }

        public async Task<bool> DeleteSkillAsync(int skillId)
        {
            await Repository.DeleteAsync<Skill>(skillId);
            return true;
        }

        public async Task<List<SkillReadDto>> GetAsync()
        {
            var skills = await Repository.GetAll<Skill>().Include(x => x.SubCategory)
                                                            .ThenInclude(x => x.Category)
                                                            .ToListAsync();
            return Mapper.Map<List<SkillReadDto>>(skills);
        }

        public async Task<SkillReadDto> GetAsync(int skillId)
        {
            var skill = await Repository.GetAll<Skill>().Include(x => x.SubCategory)
                                                            .ThenInclude(x => x.Category)
                                                            .FirstOrDefaultAsync(x => x.SkillId == skillId);
            return Mapper.Map<SkillReadDto>(skill);
        }

        public async Task<List<SkillReadDto>> GetAsync(params int[] skillIds)
        {
            var skills = await Repository.GetAll<Skill>().Include(x => x.SubCategory)
                                                            .ThenInclude(x => x.Category)
                                                            .Where(x => skillIds.Contains(x.SkillId))
                                                            .ToListAsync();
            return Mapper.Map<List<SkillReadDto>>(skills);
        }

        public async Task<List<SkillReadDto>> GetAsync(SearchSkill skill)
        {
            int row = skill.Rows ?? 5;
            int page = (skill.Page ?? 1) - 1; //From UI, first page starts from 1. But, here logic start from 0;

            int skipCount = page * row;

            var skills = Repository.GetAll<Skill>().Include(x => x.SubCategory)
                                                            .ThenInclude(x => x.Category)
                                                            .Where(x => (skill.SkillId.HasValue ? (x.SkillId == skill.SkillId.Value) : true)
                                                                        && (!string.IsNullOrEmpty(skill.SkillName) ?
                                                                            (x.Name.ToLower().Contains(skill.SkillName.ToLower())) : true)
                                                                        && (!string.IsNullOrEmpty(skill.SubCatName) ?
                                                                            (x.SubCategory.Name.ToLower().Contains(skill.SubCatName.ToLower())) : true))
                                                            .Skip(skipCount)
                                                            .Take(row);

            return Mapper.Map<List<SkillReadDto>>((await skills.ToListAsync()));
        }
    }
}
