using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Serialization;


namespace BaseballBackend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseballController : ControllerBase

    {
        private static readonly string[] BaseballPlayers = new[] {
        "David Ortiz","Sammy Sosa", "Mariano Rivera","Hideki Matsui", "Randy Orton", "Yasiel Puig", "Alonzo Ball", "Brett Farve"
        };
        private static readonly string[] BaseballTeams = new[]
        {
        "NY Yankees", "MA Red sox", "LA Dodgers", "NY Mets", "Houston Astros", "Atlanta Braves", "Chicago Cubs",
            "Detroit Tigers", "Tampa Rays", "Nationals", "Baltimore Orioles"
    };

        private readonly ILogger<BaseballController> _logger;

        /* public static Player[] PlayerAr()
         {
             Player[] result = new Player[8];
         }
        */
        public BaseballController(ILogger<BaseballController> logger)
        {
            _logger = logger;
        }

        private static Team[] TeamArray()
        {
            Team[] result = new Team[11];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Team { Id = i + 1, TeamName = BaseballTeams[i] };
            }
            return result;
        }
        private static readonly Team[] Team = TeamArray();
        private static IEnumerable<Player> PlayersArray()
        {
        
            return Enumerable.Range(0, 8).Select(index => new Player
            {

                Name = BaseballPlayers[index],
                Id = BaseballTeams[Random.Shared.Next(BaseballPlayers.Length)].Id
            }).ToArray();
        }
        [HttpGet]
        public Team[] GetTeam()
        {
            return Team;

            [HttpGet]

             IEnumerable<Player> GetPlayer()
            {
                return PlayersArray();
            }
        }

    }
}