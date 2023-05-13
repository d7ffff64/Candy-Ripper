using Candy_Ripper.Scripts.PlayerScripts;
using UnityEngine;

namespace Candy_Ripper.Scripts.Abstract
{
    public abstract class Character : MonoBehaviour
    {
        [Header("Information")]
        [SerializeField] protected int _health;
        [SerializeField] protected int _protection;
        
        [Header("Settings")]
        [SerializeField] protected int _maximumHealth;
        [SerializeField] protected int _maximumProtection;

        protected void InitializeValues()
        {
            _health = _maximumHealth;
            _protection = _maximumProtection;
        }
        protected void UpdateAttributes(PlayerUIAttributes playerUIAttributes)
        {
            playerUIAttributes.UpdateHealthAttribute(_health, _maximumHealth);
            playerUIAttributes.UpdateProtectionAttribute(_protection, _maximumProtection);
        }
        public virtual void TakeDamage(int damage)
        {
            if (_protection > 0)
            {
                _protection -= Mathf.Clamp(damage, 0, _maximumProtection);
            }
            else if (_health > 0)
            {
                _health -= Mathf.Clamp(damage, 0, _maximumHealth);
            }
            else
            {
                Die();
            }
        }
        protected abstract void Die();
    }
}
