using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PokemonGo.BaseStats.Service.Models;
using PokemonGo.BaseStats.Service.Services;

namespace PokemonGo.BaseStats.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private IPokemonBaseStatService _baseStatService;
        private int monsPerPage = 20;

        public IndexModel(IPokemonBaseStatService statService, IConfiguration config)
        {
            _config = config;
            _baseStatService = statService;
        }

        [Display(Name = "Pokemon Name", Description = "Enter the name of the Pokemon you wish to see.")]
        public string SearchTerm { get; set; }

        public string ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/{0}.png";

        public List<PokemonBaseStats> Pokemon { get; set; }

        public async Task OnGet()
        {
            Pokemon = (await _baseStatService.GetAllBaseStats(1, monsPerPage)).ToList();
        }

        public async Task<List<PokemonBaseStats>> GetData(int pageNumber)
        {
            return (await _baseStatService.GetAllBaseStats(pageNumber, monsPerPage)).ToList();
        }

        // TODO: Hook up the gol dang search bar, friend!
        //public async Task<IActionResult> OnPostAsync()
        //{

        //}
    }
}
