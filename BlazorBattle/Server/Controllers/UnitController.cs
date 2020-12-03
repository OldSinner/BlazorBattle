using BlazorBattle.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        public IList<Unit> Units { get; } = new List<Unit>
        {
            new Unit {id=1,name="Knight",Attack=10,Defense=10, BananaCost=100 },
            new Unit {id=2,name="Archer",Attack=15,Defense=5, BananaCost=120 },
            new Unit {id=3,name="Mage",Attack=20,Defense=1, BananaCost=150 }
        };
        [HttpGet]
        public IActionResult GetUnits()
        {
            return Ok(Units);
        }
    }
}
