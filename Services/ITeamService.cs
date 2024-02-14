using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaligaInformationApi.Models;

namespace LaLigaInformationApi.Services
{    
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);
        Task<Team> AddTeam(Team team);
        Task<bool> AddAllTeams(IEnumerable<Team> teams);
        Task<IEnumerable<Team>> GetAllTeamsOrderBy(string key);
    }
}
