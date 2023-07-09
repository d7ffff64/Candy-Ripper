using UnityEngine;

namespace CandyRipper.Scripts.EnemyScripts
{
    public class EnemyItemDropper : MonoBehaviour
    {
        [Header("Item Prefabs References")]
        [SerializeField] private GameObject[] _sweetnessObjects;

        [Header("Item Settings")] 
        [SerializeField] private int _maximumRandomSpawnSweetness;

        public void SpawnRandomAmountOfSweetness()
        {
            SpawnRandomAmountOfItem(_sweetnessObjects[0], _maximumRandomSpawnSweetness);
        }
        private void SpawnRandomAmountOfItem(GameObject item, int maximumAmount)
        {
            for (int i = 0; i < Random.Range(0, maximumAmount); i++)
            {
                SpawnItem(item);
            }
        }
        private void SpawnItem(GameObject item)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}