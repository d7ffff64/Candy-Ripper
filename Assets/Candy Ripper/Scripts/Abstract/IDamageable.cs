using UnityEngine;

namespace Assets.CandyRipper.Scripts.Abstract
{
    public interface IDamageable
    {
        void TakeDamage(int damage);
        void Die();
    }
}