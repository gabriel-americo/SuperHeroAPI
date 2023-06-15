using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {   Id = 1,
                    Name = "Spider Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
                },
                new SuperHero
                {   Id = 2,
                    Name = "Iron Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetOneHeroes(int id)
        {
            var hero = superHeroes.FirstOrDefault(x => x.Id == id);

            if (hero == null)
                return NotFound("Sorry, but this hero doen't exist.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }
    }
}
