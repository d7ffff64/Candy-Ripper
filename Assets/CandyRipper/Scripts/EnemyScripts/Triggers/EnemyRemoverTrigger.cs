using UnityEngine;

namespace CandyRipper.Scripts.EnemyScripts.Triggers
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