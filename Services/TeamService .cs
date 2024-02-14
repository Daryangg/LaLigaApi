using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaligaInformationApi.Models;
using LaLigaInformationApi.Repositories;

namespace LaLigaInformationApi.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _teamRepository.GetAllTeamsAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _teamRepository.GetTeamByIdAsync(id);
        }

        public async Task<Team> AddTeam(Team team)
        {
            return await _teamRepository.AddTeamAsync(team);
        }

        public async Task<bool> AddAllTeams(IEnumerable<Team> teams)
        {
            return await _teamRepository.AddAllTeamsAsync(teams);
        }
        public async Task<IEnumerable<Team>> GetAllTeamsOrderBy(string key)
        {            
            Expression<Func<Team, object>> keySelector = key.ToLower() switch
            {
                "id" => team => team.Id,
                "name" => team => team.Name,
                "position" => team => team.Position,
                "matchesplayed" => team => team.MatchesPlayed,
                "wins" => team => team.Wins,
                "draws" => team => team.Draws,
                "losses" => team => team.Losses,
                "goalsfor" => team => team.GoalsFor,
                "goalsagainst" => team => team.GoalsAgainst,
                "goaldifference" => team => team.GoalDifference,
                _ => throw new ArgumentException("Invalid key name", key)
            };

            return await _teamRepository.GetAllTeamsAsyncOrderByKey(keySelector);
        }
    }
}
