using Service.Repository;

namespace Service
{
    public class EasterService
    {
        private readonly ICioccEventRepository _cioccEventRepository;

        public EasterService(ICioccEventRepository cioccEventRepository)
        {
            _cioccEventRepository = cioccEventRepository;
        }

        public async Task<CioccEvent> SaveAsync(CioccEvent ciocc)
        {
            return await _cioccEventRepository.AddAsync(ciocc);
        }
    }
}