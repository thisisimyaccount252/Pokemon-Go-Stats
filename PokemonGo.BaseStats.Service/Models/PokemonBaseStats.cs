using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PokemonGo.BaseStats.Service.Models
{
    public class PokemonBaseStats
    {
        [JsonProperty("pokemon_id")]
        public int Id { get; set; }
        [JsonProperty("pokemon_name")]
        public string Name { get; set; }
        [JsonProperty("base_attack")]
        [Display(Name = "Base Attack")]
        public int BaseAttack { get; set; }
        [JsonProperty("base_defense")]
        [Display(Name = "Base Defense")]
        public int BaseDefense { get; set; }
        [JsonProperty("base_stamina")]
        [Display(Name = "Base Stamina")]
        public int BaseStamina { get; set; }
    }
}
