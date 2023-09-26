using System.Collections.Generic;
using Enemy;

namespace Core.Factory
{
    public interface IGameFactory : IService
    {
        Player.Player Player { get; }
        FrogGirl.FrogGirl FrogGirl { get; }
        List<EnemySpawner> EnemySpawners { get; }
        
        void InstantiatePlayer();
        void InstantiateFrogGirl();
        void InstantiateSpawners();
    }
}