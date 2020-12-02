using BlazorBattle.Shared;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattle.Client.Services
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;

        public UnitService(IToastService toastService)
        {
            _toastService = toastService;
        }
        public IList<Unit> Units { get; } = new List<Unit>
        {
            new Unit {id=1,name="Knight",Attack=10,Defense=10, BananaCost=100 },
            new Unit {id=2,name="Archer",Attack=15,Defense=5, BananaCost=120 },
            new Unit {id=3,name="Mage",Attack=20,Defense=1, BananaCost=150 }
        };

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();

        public void AddUnit(int unitId)
        {
            Unit unit = Units.First(unit => unit.id == unitId);
            MyUnits.Add(new UserUnit { UnitId = unit.id, HitPoints = unit.HitPoints });
            _toastService.ShowSuccess($"Your {unit.name} has been built!", "Unit Built!");

        }
    }
}
