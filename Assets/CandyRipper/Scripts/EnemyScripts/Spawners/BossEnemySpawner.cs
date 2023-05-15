using CandyRipper.Scripts.EnemyScripts.Abstract;

namespace CandyRipper.Scripts.EnemyScripts.Spawners
{
    public class BossEnemySpawner : EnemySpawner
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
        protected void InitializeSingleton()
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
