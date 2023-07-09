using CandyRipper.Scripts.PlayerScripts.Abstract;

namespace CandyRipper.Scripts.PlayerScripts
{
    public sealed class PlayerPrefabSelectByIndex : PrefabSelectByIndex
    {
        public static PlayerPrefabSelectByIndex Instance { get; private set; }
        
        private void Awake()
        {
            InitializeSingleton();
            
            key = "PlayerPrefabSelectedIndex";
            
            LoadSelectedIndex();
            
            CheckCurrentIndexWithSaved();

            UpdateSelectedPrefabImage();
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