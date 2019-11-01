using Newtonsoft.Json;
using PokemonGo.BaseStats.Service.Models;
using PokemonGo.BaseStats.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.BaseStats.Service.Services
{
    public abstract class PokemonBaseStatService : IPokemonBaseStatService
    {

        protected List<PokemonBaseStats> BaseStatCache { get; set; }
        protected DateTime LastCacheTime { get; set; }

        public PokemonBaseStatService()
        {
            BaseStatCache = new List<PokemonBaseStats>();
        }

        public async Task<IEnumerable<PokemonBaseStats>> GetAllBaseStats(int pageNumber, int pokemonPerPage)
        {
            await CheckCache();

            return BaseStatCache.Skip(pageNumber * pokemonPerPage).Take(pokemonPerPage).ToList();
        }

        public async Task<PokemonBaseStats> GetBaseStatById(int pokemonId)
        {
            await CheckCache(); 

            return BaseStatCache.FirstOrDefault(mon => mon.Id == pokemonId);
        }

        public async Task<PokemonBaseStats> GetBaseStatByName(string pokemonName)
        {
            await CheckCache();

            return BaseStatCache.FirstOrDefault(mon => mon.Name.Equals(pokemonName));
        }

        public abstract Task CheckCache();
    }
}
