using SkillServices.Data.DbModels;
using Microservices.Dtos;
using SkillServices.Api.LocalModels;

namespace SkillServices.Api.Services
{
    public interface ISkillService
    {
        Task<bool> DeleteSkillAsync(int skillId);
        Task<List<SkillReadDto>> GetAsync();
        Task<SkillReadDto> GetAsync(int skillId);
        Task<List<SkillReadDto>> GetAsync(params int[] skillIds);
        Task<List<SkillReadDto>> GetAsync(SearchSkill skill);
        Task<SkillReadDto> CreateAsync(SkillCreateDto skill);
    }
}
