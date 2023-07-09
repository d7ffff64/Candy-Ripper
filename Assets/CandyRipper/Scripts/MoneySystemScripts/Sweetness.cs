using UnityEngine;

namespace CandyRipper.Scripts.MoneySystemScripts
{
    public sealed class Sweetness : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private float _lifeTime;
        
        private SweetsMoneySystem _sweetsMoneySystem;
        private void Awake()
        {
            _sweetsMoneySystem = FindObjectOfType<SweetsMoneySystem>();
            
            Destroy(gameObject, _lifeTime);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    _sweetsMoneySystem.IncreaseMoney(1);
                    Destroy(gameObject);
                }
            }
        }
    }
}