using CandyRipper.Scripts.EnemyScripts.Abstract;
using UnityEngine;

namespace CandyRipper.Scripts.PlayerScripts.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [Header("Bullet Information")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _destroyTime;
        [SerializeField] private float _destroyTimeOnHit;

        private Weapon _weapon;
        private Rigidbody2D _rigidBody2D;

        private void Awake()
        {
            _weapon = FindObjectOfType<Player>().GetComponentInChildren<Weapon>();
            _rigidBody2D = GetComponent<Rigidbody2D>();

            _rigidBody2D.velocity = transform.right * _movementSpeed;
            Destroy(gameObject, _destroyTime);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.CompareTag("Enemy"))
                {
                    var enemy = collision.GetComponent<IEnemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(_weapon.DamagePower);
                        Destroy(gameObject, _destroyTimeOnHit);
                    }
                }
            }
        }
    }
}