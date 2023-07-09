using CandyRipper.Scripts.PlayerScripts.Abstract;

namespace CandyRipper.Scripts.PlayerScripts
{
    public sealed class PlayerPrefabSpawnerByIndex : PrefabSpawnerByIndex
    {
        public static PlayerPrefabSpawnerByIndex Instance { get; private set; }
        private void Awake()
        {
            InitializeSingleton();
            
            key = "PlayerPrefabSelectedIndex";

            SpawnGameObjectByIndex();
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