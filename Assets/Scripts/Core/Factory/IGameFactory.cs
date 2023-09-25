using System.Collections.Generic;
using Enemy;

namespace Core.Factory
{
    public interface IGameFactory : IService
    {
        Player.Player InstantiatePlayer();
        FrogGirl.FrogGirl InstantiateFrogGirl();
        List<EnemySpawner> InstantiateSpawners();
    }
}