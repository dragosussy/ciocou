using Service;

namespace Service.Repository
{
    public interface ICioccEventRepository
    {
        Task<CioccEvent> AddAsync(CioccEvent cioccEvent);

        Task<CioccEvent> GetByGuidAsync(string guid);

        IEnumerable<CioccEvent> GetAll();

        Task<CioccEvent> UpdateAsync(CioccEvent cioccEvent);
    }
}
