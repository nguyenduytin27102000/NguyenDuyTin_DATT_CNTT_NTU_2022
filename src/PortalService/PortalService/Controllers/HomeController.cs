using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortalService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/test")]
        public async Task<IActionResult> Test()
        {
            var trinhDo = new TrinhDo()
            {
                CapBac = "Final",
                VietTat = "FF"
            };

            var body = new StringContent(
                        JsonSerializer.Serialize<TrinhDo>(trinhDo),
                    Encoding.UTF8,
                    "application/json");

            /*var request = new HttpRequestMessage(HttpMethod.Post,
            "https://localhost:5001/api/TrinhDoes");*/

            var client = _clientFactory.CreateClient();

            var response = await client.PostAsync("https://localhost:5001/api/TrinhDoes",body);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else 
                return BadRequest(response.Content);
        }
    }
}
