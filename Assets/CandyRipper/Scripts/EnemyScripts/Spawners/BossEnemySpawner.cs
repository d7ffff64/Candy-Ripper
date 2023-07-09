using CandyRipper.Scripts.EnemyScripts.Abstract;
using CandyRipper.Scripts.PlayerScripts;

namespace CandyRipper.Scripts.EnemyScripts.Spawners
{
    public sealed class BossEnemySpawner : EnemySpawner
    {
        public static BossEnemySpawner Instance { get; private set; }
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
