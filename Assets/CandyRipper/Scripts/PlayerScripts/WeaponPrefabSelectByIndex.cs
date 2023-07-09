using CandyRipper.Scripts.PlayerScripts.Abstract;

namespace CandyRipper.Scripts.PlayerScripts
{
    public class WeaponPrefabSelectByIndex : PrefabSelectByIndex
    {
        public static WeaponPrefabSelectByIndex Instance { get; private set; }
        
        private void Awake()
        {
            InitializeSingleton();
            
            key = "WeaponPrefabSelectedIndex";
            
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