using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaligaInformationApi.Models;
using LaLigaInformationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaLigaInformationApi.Controllers
{
    /// <summary>
    /// API endpoints for managing teams.
    /// </summary>
    [Route("api/v2/Team")]
    [ApiController]
    public class TeamControllerV1 : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamControllerV1(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Retrieves a list of all teams.
        /// </summary>
        /// <returns>A list of all teams.</returns>
        [HttpGet]
        public async Task<IActionResult> ListTeams()
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(teams);
        }

        /// <summary>
        /// Retrieves a team by its ID.
        /// </summary>
        /// <param name="id">The ID of the team.</param>
        /// <returns>The team with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        /// <summary>
        /// Adds a new team.
        /// </summary>
        /// <param name="team">The team to add.</param>
        /// <returns>The newly added team.</returns>
        [Authorize]
        [HttpPost("AddTeam", Name = "AddTeam")]
        public async Task<IActionResult> AddTeam(Team team)
        {
            var addedTeam = await _teamService.AddTeam(team);
            return CreatedAtAction(nameof(GetTeamById), new { id = addedTeam.Id }, addedTeam);
        }

        /// <summary>
        /// Adds multiple teams.
        /// </summary>
        /// <param name="teams">The teams to add.</param>
        /// <returns>The newly added teams.</returns>
        [Authorize]
        [HttpPost("AddAllTeams", Name = "AddAllTeams")]
        public async Task<IActionResult> AddAllTeams(IEnumerable<Team> teams)
        {
            var addedTeams = await _teamService.AddAllTeams(teams);
            return CreatedAtAction(nameof(ListTeams), addedTeams);
        }

        /// <summary>
        /// Retrieves a list of teams ordered by the specified property.
        /// </summary>
        /// <param name="key">The property to order by.</param>
        /// <returns>A list of teams ordered by the specified property.</returns>
        [Authorize]
        [HttpGet("OrderBy/{key}")]
        public async Task<IActionResult> ListTeamsOrderBy(string key)
        {
            try
            {
                var teams = await _teamService.GetAllTeamsOrderBy(key);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }    
    }
}
