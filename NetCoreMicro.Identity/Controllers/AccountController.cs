using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMicro.Common.Commands;
using NetCoreMicro.Services.Identity.Services;

namespace NetCoreMicro.Services.Identity.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
            => Json(await userService.LoginAsync(command.Email, command.Password));
    }
}