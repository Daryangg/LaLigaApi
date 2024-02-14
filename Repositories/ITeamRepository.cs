using System.Linq.Expressions;
using System.Threading.Tasks;
using LaligaInformationApi.Models;

namespace LaLigaInformationApi.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<IEnumerable<Team>> GetAllTeamsAsyncOrderByKey<TKey>(Expression<Func<Team, TKey>> keySelector);
        Task<Team> GetTeamByIdAsync(int id);
        Task<Team> AddTeamAsync(Team team);
        Task<bool> AddAllTeamsAsync(IEnumerable<Team> teams);
    }
}