using UnityEngine;

namespace Candy_Ripper.Scripts.EnemyScripts
{
    public class EnemyRemoverTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                if (other.CompareTag("Enemy"))
                {
                    Debug.Log(other.name);
                    Destroy(other.gameObject);
                }
            }
        }
    }   
}
