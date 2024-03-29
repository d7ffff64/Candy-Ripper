using CandyRipper.Scripts.EnemyScripts.Abstract;

namespace CandyRipper.Scripts.EnemyScripts.Spawners
{
    public sealed class LowLevelEnemySpawner : EnemySpawner
    {
        public static LowLevelEnemySpawner Instance { get; private set; }
        private void Awake()
        {
            InitializeSingleton();
            
            if (CheckSpawnPoints())
            { 
                StartCoroutine(SpawnRandom(_enemies, _spawnPoints, _spawnCount, _startTimeToSpawn, _waitingTimeBetween));
            }
        }
        private void InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }   
}
