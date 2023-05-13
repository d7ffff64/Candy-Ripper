using Assets.CandyRipper.Scripts.PlayerScripts;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.EnemyScripts
{
    public class EnemyDamageTrigger : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private int _damagePower;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                if (other.CompareTag("Player"))
                {
                    var player = other.GetComponent<Player>();
                    if (player != null)
                    {
                        player.TakeDamage(_damagePower);
                    }
                }
            }
        }
    }
}