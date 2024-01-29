namespace Core.AssetManagement
{
    public static class AssetPath
    {
        // Scenes
        public const string MenuScene = "Menu";
        public const string GameScene = "Game";
        
        // GameObjects
        public const string Frog = "Frog";
        public const string Girl = "Girl";

        // Spawners
        private const string EnemySpawnersFolder = "Spawners/EnemySpawners";
        public static readonly string FlySpawner = $"{EnemySpawnersFolder}/FlySpawner";
        public static readonly string MosquitoSpawner = $"{EnemySpawnersFolder}/MosquitoSpawner";
        public static readonly string DragonflySpawner = $"{EnemySpawnersFolder}/DragonflySpawner";
        public static readonly string WaspSpawner = $"{EnemySpawnersFolder}/WaspSpawner";
        public static readonly string SpiderSpawner = $"{EnemySpawnersFolder}/SpiderSpawner";
    }
}