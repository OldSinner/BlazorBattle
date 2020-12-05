using BlazorBattle.Server.Data;
using BlazorBattle.Server.Services;
using BlazorBattle.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUnitController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUtilityService _utilityService;

        public UserUnitController(DataContext context,IUtilityService utilityService)
        {
            _context = context;
            _utilityService = utilityService;
        }

         [HttpPost]
         public async Task<IActionResult> BuildUserUnit([FromBody] int unitId)
        {
            var unit = await _context.Units.FirstOrDefaultAsync<Unit>(x => x.id == unitId);
            var user = await _utilityService.GetUser();
            if(user.Bananas <unit.BananaCost)
            {
                return BadRequest("Not Enough Bananas!");
            }
            user.Bananas -= unit.BananaCost;

            UserUnit userUnit = new UserUnit
            {
                UnitId = unit.id,
                UserId = user.id,
                HitPoints = unit.HitPoints
            };
            await _context.UserUnits.AddAsync(userUnit);
            await _context.SaveChangesAsync();
            return Ok(userUnit);

        }
        [HttpGet]
        public async Task<IActionResult> GetUserUnits()
        {
            var user = await _utilityService.GetUser();
            var userUnits = await _context.UserUnits.Where(unit => unit.UserId == user.id).ToListAsync();
            var response = userUnits.Select(
                unit => new UserUnitResponse
                {
                    Unitid = unit.UnitId,
                    HitPoints = unit.HitPoints
                }
                );
            return Ok(response); 
        }

    }
}
