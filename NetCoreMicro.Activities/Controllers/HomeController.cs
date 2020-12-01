using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMicro.Services.Activities.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        //[HttpGet("")]
        //public IActionResult Get() => Content("Hello From NetCoreMicro Activities!");
    }
}