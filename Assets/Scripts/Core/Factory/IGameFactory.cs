using System.Collections.Generic;
using System.Threading.Tasks;
using Main.Enemy;
using Main.FrogGirl;
using Main.Player;

namespace Core.Factory
{
    public interface IGameFactory : IService
    {
        Frog Frog { get; }
        Girl Girl { get; }
        List<EnemySpawner> EnemySpawners { get; }
        
        Task InstantiatePlayer();
        Task InstantiateFrogGirl();
        Task InstantiateSpawners();
    }
}