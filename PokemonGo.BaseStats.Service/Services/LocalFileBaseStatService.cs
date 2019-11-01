using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokemonGo.BaseStats.Service.Models;

namespace PokemonGo.BaseStats.Service.Services
{
    public class LocalFileBaseStatService : PokemonBaseStatService
    {
        public LocalFileBaseStatService() : base() { }

        public override async Task CheckCache()
        {
            if (BaseStatCache.Count == 0
                || (DateTime.Now - LastCacheTime).TotalDays >= 1) // It's been longer than one day
            {
                try
                {
                    // Read the file
                    string file = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\PoGoBaseStats.json");

                    if (file != null)
                    {
                        // Deserialize it to our list of base stats
                        BaseStatCache = JsonConvert.DeserializeObject<List<PokemonBaseStats>>(file);

                        // If that worked. Set the last cache time
                        if (BaseStatCache != null && BaseStatCache.Count > 0)
                        {
                            LastCacheTime = DateTime.Now;
                        }
                        else
                        {
                            // TODO: what if it doesn't work? Do we want to keep trying to do this?
                            throw new Exception("We had some issues deserializing the file. Damn it.");
                        }
                        
                    }
                }
                catch(Exception ex)
                {
                    // TODO: LOG!
                    throw;
                }
            }
        }
    }
}
