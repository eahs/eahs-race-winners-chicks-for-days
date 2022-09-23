using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.Json;
using System.Threading.Tasks;
using RaceWinners.Models;
using ShellProgressBar;

namespace RaceWinners
{
    public class DataService
    {

        private ProgressBarOptions _options = new ProgressBarOptions
        {
            ProgressCharacter = '─',
            ProgressBarOnBottom = true
        };
        private int _totalTicks = 10;


        public async Task<List<Group>> GetGroupRanksAsync()
        {
            var groups = new List<Group>();
            using (var pbar = new ProgressBar(_totalTicks, "Fetching Data...", _options))
            {
                for(int i = 0; i < _totalTicks; i++)
                {
                    await Task.Delay(500);
                    pbar.Tick();
                }

            }
            // Simulate a little bit of delay as if we were loading this from a network
            
            // Add a group
            string json = File.ReadAllText("./Data/Groups.json");
            groups = JsonSerializer.Deserialize<List<Group>>(json);

            return groups;
        }

    }
}