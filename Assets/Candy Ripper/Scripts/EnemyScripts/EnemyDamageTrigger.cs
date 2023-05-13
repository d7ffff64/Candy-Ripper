using Candy_Ripper.Scripts.PlayerScripts;
using UnityEngine;

namespace Candy_Ripper.Scripts.EnemyScripts
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