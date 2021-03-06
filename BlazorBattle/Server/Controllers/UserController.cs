﻿using BlazorBattle.Server.Data;
using BlazorBattle.Server.Services;
using BlazorBattle.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorBattle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utilityService;

        public UserController(DataContext context, IUtilityService utilityService)
        {
            _context = context;
            _utilityService = utilityService;
        }

        [HttpGet("GetBananas")]
        public async Task<IActionResult> GetBananas()
        {

            var user = await _utilityService.GetUser();
            return Ok(user.Bananas);
        }
        [HttpPut("AddBananas")]
        public async Task<IActionResult> AddBananas([FromBody] int bananas)
        {
            var user = await _utilityService.GetUser();
            user.Bananas += bananas;
            await _context.SaveChangesAsync();
            return Ok(user.Bananas);
        }
        [HttpGet("leaderboard")]
        public async Task<IActionResult> GetLeaderboard()
        {
            var user = await _context.Users.Where(x => !x.IsDeleted).ToListAsync();
            user = user.OrderByDescending(u => u.Victories)
                .ThenBy(u => (u.Battles - u.Victories))
                .ThenBy(u => u.DateCreated)
                .ToList();
            int rank = 1;
            var response = user.Select(
                user => new UserStatistic
                {
                    Rank = rank++,
                    UserId = user.id,
                    Username = user.Username,
                    Battles = user.Battles,
                    Victories = user.Victories,
                    Deafeat = user.Battles - user.Victories
                });
            return Ok(response);

        }
    }
}
