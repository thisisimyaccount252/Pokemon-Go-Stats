using PokemonGo.BaseStats.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.BaseStats.Service.Services
{
    public interface IPokemonBaseStatService
    {
        Task<IEnumerable<PokemonBaseStats>> GetAllBaseStats(int pageNumber, int pokemonPerPage);

        Task<PokemonBaseStats> GetBaseStatById(int pokemonId);

        Task<PokemonBaseStats> GetBaseStatByName(string pokemonName);
    }
}
