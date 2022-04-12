#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameLibraryApi.Models;

namespace GameLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameLibraryContext _context;

        public GamesController(GameLibraryContext context)
        {
            _context = context;
        }

        //GET: api/ListGames
        [HttpGet]
        [Route("ListGames")]
        public async Task<ActionResult<IEnumerable<Game>>> ListGames(string name = null, string company = null)
        {
            var gameList = await _context.Games.ToListAsync();

            if (name != null)
            {
                gameList = gameList.Where(g => g.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            if (company != null)
            {
                gameList = gameList.Where(g => g.Company.ToLower().Contains(company.ToLower())).ToList();
            }

            return gameList.ToArray();
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(string id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(string id, Game game)
        {
            if (id != game.Identifier)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<bool>> PostGame(string identifier, Game game)
        {
            game.Identifier = identifier;
            _context.Games.Add(game);
            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, true);
            }
            catch (Exception)
            {
                // Todo: log ex.Message
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(string id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(string id)
        {
            return _context.Games.Any(e => e.Identifier == id);
        }
    }
}
