using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaligaInformationApi.Data;
using LaligaInformationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaLigaInformationApi.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }
        public async Task<IEnumerable<Team>> GetAllTeamsAsyncOrderByKey<TKey>(Expression<Func<Team, TKey>> keySelector)
        {
            return await _context.Teams.OrderBy(keySelector).ToListAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> AddAllTeamsAsync(IEnumerable<Team> teams)
        {
            _context.Teams.AddRangeAsync(teams);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}