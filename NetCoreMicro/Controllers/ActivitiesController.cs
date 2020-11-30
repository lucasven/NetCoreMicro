using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMicro.API.Repositories;
using NetCoreMicro.Common.Commands;
using RawRabbit;

namespace NetCoreMicro.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IActivityRepository repository;

        public ActivitiesController(IBusClient busClient, IActivityRepository repository)
        {
            _busClient = busClient;
            this.repository = repository;
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody]CreateActivity command)
        {
            command.ID = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);
            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.ID}");
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var activities = await repository.BrowseAsync(Guid.Parse(User.Identity.Name));

            return new JsonResult(activities.Select(x => new { x.Id, x.Name, x.Category, x.CreatedAt }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var activitiy = await repository.GetAsync(id);
            if (activitiy == null)
                return NotFound();
            if (activitiy.User != Guid.Parse(User.Identity.Name))
                return Unauthorized();

            return new JsonResult(activitiy);
        }
    }
}