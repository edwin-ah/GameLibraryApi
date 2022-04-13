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

        //GET: api/Games/ListGames
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

        // GET: api/Games/AllGames
        [HttpGet]
        [Route("AllGames/{page}")]
        public async Task<ActionResult<GameListPagination>> GetGames(int page)
        {
            var allGames = await _context.Games.ToListAsync();
            double pageResults = 4d;
            GameListPagination response = GetGameListPagination(page, allGames, pageResults);

            return response;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> LoadGame(string id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<bool>> PostGame(AddGame newGame)
        {
            newGame.Game.Identifier = newGame.Identifier;
            _context.Games.Add(newGame.Game);
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

        private GameListPagination GetGameListPagination(int page, List<Game> allGames, double pageResults)
        {
            double pageCount = Math.Ceiling(allGames.Count / pageResults);

            var games = allGames
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToArray();

            var response = new GameListPagination()
            {
                Games = games,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return response;
        }
    }
}
