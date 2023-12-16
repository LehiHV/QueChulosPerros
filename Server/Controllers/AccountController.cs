﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueChulosPerros.Server.Authentication;
using QueChulosPerros.Shared.Model;

namespace Psicología.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserAccountService _userAccountService;

        public AccountController(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
            var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserName!, loginRequest.Password!, loginRequest.Branch.Value!);
            if (userSession is null)
                return Unauthorized();
            else
                return userSession;
        }
    }
}