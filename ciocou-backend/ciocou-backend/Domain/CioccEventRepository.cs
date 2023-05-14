using Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Repository;

namespace Data
{
    public class CioccEventRepository : ICioccEventRepository
    {
        private readonly CiocouPostgresDbContext _repository;

        public CioccEventRepository(CiocouPostgresDbContext repository)
        {
            _repository = repository;
        }

        public async Task<CioccEvent> AddAsync(CioccEvent cioccEvent)
        {
            await _repository.AddAsync(cioccEvent);
            await _repository.SaveChangesAsync();
            return cioccEvent;
        }

        public IEnumerable<CioccEvent> GetAll()
        {
            return _repository.CioccEvents;
        }

        public async Task<CioccEvent> GetByGuidAsync(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                throw new ArgumentNullException(nameof(guid));

            return await _repository.CioccEvents
                .FirstOrDefaultAsync(ciocc => ciocc.Guid.Equals(guid, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<CioccEvent> UpdateAsync(CioccEvent cioccEvent)
        {
            _repository.CioccEvents.Update(cioccEvent);
            await _repository.SaveChangesAsync();
            return cioccEvent;
        }
    }
}
