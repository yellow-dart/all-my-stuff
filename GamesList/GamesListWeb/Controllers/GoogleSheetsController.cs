using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GamesListWeb.Models;

namespace GamesListWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/GoogleSheets")]
    public class GoogleSheetsController : Controller
    {

        [HttpGet]
        public IEnumerable<Nes> GetNesGames()
        {
            var service = new GoogleSheetsService();
            return service.ReadEntries("NES", "A2:K");
        }
    }
}