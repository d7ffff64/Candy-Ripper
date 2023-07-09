using UnityEngine;

namespace CandyRipper.Scripts.PlayerScripts.Abstract
{    
    public abstract class PrefabSpawnerByIndex : MonoBehaviour
     {
         protected string key = "KeyName";
         
         [Header("References")] 
         [SerializeField] protected GameObject[] prefabs;

         private int _selectedPrefabIndex;
         
         protected void SpawnGameObjectByIndex()
         {
             Instantiate(prefabs[PlayerPrefs.GetInt(key)], Vector3.zero, Quaternion.identity);
             Debug.Log($"Spawned by index: {_selectedPrefabIndex}");
         }
         protected void SpawnGameObjectByIndexInParent(Transform parent)
         {
             Instantiate(prefabs[PlayerPrefs.GetInt(key)], new Vector3(1, 0), Quaternion.identity, parent);
             Debug.Log($"Spawned by index in parent: {_selectedPrefabIndex}");
         }
     }
}
