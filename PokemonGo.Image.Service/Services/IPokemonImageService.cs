using PokemonGo.Image.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.Image.Service.Services
{
    public interface IPokemonImageService
    {
        Task<IPokemonImage> GetPokemonImage(int pokemonId, string pokemonName);
    }
}
