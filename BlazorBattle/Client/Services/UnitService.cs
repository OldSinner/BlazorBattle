﻿using BlazorBattle.Shared;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBattle.Client.Services
{
    public class UnitService : IUnitService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;
        private readonly IBananaService _bananaService;

        public UnitService(IToastService toastService, HttpClient http, IBananaService bananaService)
        {
            _toastService = toastService;
            _http = http;
            _bananaService = bananaService;
        }
        public IList<Unit> Units { get; set; } = new List<Unit>();
        

        public IList<UserUnit> MyUnits { get; set; } = new List<UserUnit>();
        

        public async Task AddUnit(int unitId)
        {
            Unit unit = Units.First(unit => unit.id == unitId);
            var result = await _http.PostAsJsonAsync<int>("api/UserUnit", unitId);
            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _toastService.ShowError(await result.Content.ReadAsStringAsync());
            }
            else 
            {
                await _bananaService.GetBananas();
                _toastService.ShowSuccess($"Your {unit.name} has been built!", "Unit Built!");
            }
            
            

        }

        public async Task LoadUnistAsync()
        {
            if(Units.Count==0)
            {
                Units = await _http.GetFromJsonAsync<IList<Unit>>("api/unit");
            }
        }

        public async Task LoadUserUnitsAsync()
        {
            MyUnits = await _http.GetFromJsonAsync<IList<UserUnit>>("api/UserUnit");
        }
    }
}
