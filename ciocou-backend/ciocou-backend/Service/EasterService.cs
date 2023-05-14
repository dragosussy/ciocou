using Service.DTOs;
using Service.Mappers;
using Service.Repository;

namespace Service
{
    public class EasterService
    {
        private static Random rng = new Random();
        private readonly ICioccEventRepository _cioccEventRepository;

        public EasterService(ICioccEventRepository cioccEventRepository)
        {
            _cioccEventRepository = cioccEventRepository;
        }

        public async Task<CioccEvent> SaveAsync(CreateCioccEventDto createCioccEventDto)
        {
            return await _cioccEventRepository.AddAsync(
                CioccEventMapper.fromDto(createCioccEventDto)
            );
        }

        public async Task<CioccEvent> UpdateAsync(UpdateCioccEventDto updateCioccEventDto)
        {
            var existing = await _cioccEventRepository.GetByGuidAsync(updateCioccEventDto.Guid);

            var winner = GetRandomWinner(existing.UserName1, updateCioccEventDto.UserName2);

            var updated = existing.Complete(updateCioccEventDto.UserName2, winner);

            return await _cioccEventRepository.UpdateAsync(updated);
        }

        public async Task<CioccEvent> GetCioccEvent(string guid)
        {
            return await _cioccEventRepository.GetByGuidAsync(guid);
        }

        private string GetRandomWinner(string userName1, string userName2)
        {
            return new List<string>() { userName1, userName1 }[rng.Next(2)];
        }
    }
}