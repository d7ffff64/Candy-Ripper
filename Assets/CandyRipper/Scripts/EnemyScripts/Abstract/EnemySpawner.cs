using System.Collections;
using UnityEngine;

namespace CandyRipper.Scripts.EnemyScripts.Abstract
{
    public abstract class EnemySpawner : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] protected Transform[] _spawnPoints;
        
        [Header("Enemy's Prefabs")] 
        [SerializeField] protected Enemy[] _enemies;

        [Header("Enemy's Settings")]
        [SerializeField] protected int _spawnCount;
        [SerializeField] protected float _startTimeToSpawn;
        [SerializeField] protected float _waitingTimeBetween;

        protected IEnumerator SpawnRandom(Enemy[] enemys, Transform[] spawnPoints, int spawnCount, float startTimeToSpawn, float waitingTimeBetween)
        {
            yield return new WaitForSeconds(startTimeToSpawn);
            
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnRandomPoint(enemys, spawnPoints);
                yield return new WaitForSeconds(waitingTimeBetween);
            }
        }
        protected bool CheckSpawnPoints()
        {
            if (_spawnPoints == null)
            {
                return false;
            }
            return true;
        }
        private void SpawnRandomPoint(Enemy[] enemys, Transform[] spawnPoints)
        {
            Instantiate(enemys[Random.Range(0, enemys.Length)],
                new Vector2(spawnPoints[Random.Range(0, spawnPoints.Length)].position.x, 0),
                Quaternion.identity);
        }
    }
}