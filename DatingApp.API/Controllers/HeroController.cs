using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHeroRepository _repo;

        public HeroController(DataContext context, IHeroRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET api/heroes
        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> GetValues()
        {
            var heroes = await _context.Heroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(HeroForAddDto heroForAddDto)
        {
            try
            {
                Hero heroToCreate = new Hero
                {
                    FirstName = heroForAddDto.FirstName,
                    LastName = heroForAddDto.LastName,
                    Capes = heroForAddDto.Capes,
                    Origin = DateTime.Parse(heroForAddDto.Origin),
                    Description = heroForAddDto.Description
                };

                Hero hero = await _repo.AddHero(heroToCreate);

                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, "Failed adding hero!");
            }
        }

        [HttpPost("modify")]
        public async Task<IActionResult> Modify(HeroForModifyDto heroForModifyDto)
        {
            try
            {
                Hero heroToModify = new Hero
                {
                    Id = heroForModifyDto.Id,
                    FirstName = heroForModifyDto.FirstName,
                    LastName = heroForModifyDto.LastName,
                    Description = heroForModifyDto.Description,
                    Capes = heroForModifyDto.Capes,
                    Origin = DateTime.Parse(heroForModifyDto.Origin)
                };

                Hero hero = await _repo.ModifyHero(heroToModify);

                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, "Failed modifying hero!");
            }
        }
    }
}