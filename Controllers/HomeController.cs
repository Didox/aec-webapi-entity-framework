using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aec_webapi_entity_framework.Apresentacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aec_webapi_entity_framework.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public HomeView Get()
        {
            return new HomeView();
        }
    }
}
