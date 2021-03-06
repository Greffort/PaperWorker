﻿using System.Linq;
using Api.Models;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new PaperWorkerDbContext())
            {
                return Ok(context.Users.Select(user => new User
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password
                }).ToList());
            }
        }
    }
}