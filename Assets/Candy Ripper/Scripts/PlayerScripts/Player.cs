using Assets.CandyRipper.Scripts.Abstract;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.PlayerScripts
{
    [RequireComponent(typeof(PlayerUIAttributes))]
    public class Player : MonoBehaviour, IDamageable
    {
        [Header("Information")]
        [SerializeField] private int _health;
        [SerializeField] private int _protection;
        
        [Header("Settings")]
        [SerializeField] private int _maximumHealth;
        [SerializeField] private int _maximumProtection;
        
        public int Health => _health;

        private PlayerUIAttributes _playerUIAttributes;

        private void Awake()
        {
            _playerUIAttributes = GetComponent<PlayerUIAttributes>();

            _health = _maximumHealth;
            _protection = _maximumProtection;
            _playerUIAttributes.UpdateHealthAttribute(_health, _maximumHealth);
        }
        public void TakeDamage(int damage)
        {
            if (_health >= 0)
            {
                _health -= Mathf.Clamp(damage, 0, _maximumHealth);
                _playerUIAttributes.UpdateHealthAttribute(_health, _maximumHealth);
            }
            else
            {
                Die();
            }
        }
        public void Die()
        {
            _playerUIAttributes.UpdateHealthAttribute(_health, _maximumHealth);
        }
    }
}