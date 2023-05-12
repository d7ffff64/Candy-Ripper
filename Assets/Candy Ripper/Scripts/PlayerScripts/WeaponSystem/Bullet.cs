using Assets.CandyRipper.Scripts.Abstract;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.PlayerScripts.WeaponSystem
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
            _weapon = GameObject.Find("Player").GetComponentInChildren<Weapon>();
            _rigidBody2D = GetComponent<Rigidbody2D>();

            _rigidBody2D.velocity = transform.right * _movementSpeed;
            Destroy(gameObject, _destroyTime);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                if (collision.tag == "Enemy")
                {
                    var damageable = collision.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(_weapon.DamagePower);
                        Destroy(gameObject, _destroyTimeOnHit);
                    }
                }
            }
        }
    }
}