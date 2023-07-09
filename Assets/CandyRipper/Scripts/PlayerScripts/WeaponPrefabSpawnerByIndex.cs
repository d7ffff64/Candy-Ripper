using System;
using CandyRipper.Scripts.PlayerScripts.Abstract;

namespace CandyRipper.Scripts.PlayerScripts
{
    public class WeaponPrefabSpawnerByIndex : PrefabSpawnerByIndex
    {
        public static WeaponPrefabSpawnerByIndex Instance { get; private set; }
        
        private void Awake()
        {
            InitializeSingleton();
            
            key = "WeaponPrefabSelectedIndex";
        }
        private void Start()
        {
            SpawnGameObjectByIndexInParent(FindObjectOfType<Player>().transform);
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