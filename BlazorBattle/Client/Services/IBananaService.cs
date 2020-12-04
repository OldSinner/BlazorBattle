using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattle.Client.Services
{

    public interface IBananaService
    {
        event Action OnChange;
        int Bananas { get; set; }
        
        Task AddBananas(int amount);
        Task GetBananas();
    }
}
