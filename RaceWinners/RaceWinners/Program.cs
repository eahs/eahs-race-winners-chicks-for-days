using RaceWinners.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceWinners
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService ds = new DataService();
 
            // Asynchronously retrieve the group (class) data
            var data = await ds.GetGroupRanksAsync();
            var winners = CalculateWinners(data);

            var sorted = winners.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var winner in sorted)
            {
                Console.WriteLine(winner.Key + " - " + winner.Value);
            }
        }

        static Dictionary<string, double> CalculateWinners(List<Group> data)
        {
            Dictionary<string, double> winners = new Dictionary<string, double>();
            for (int i = 0; i < data.Count; i++)
            {
                var group = data[i];
                winners.Add(group.Name, group.Ranks.Average());

            };

            return winners;
        }
    }
}