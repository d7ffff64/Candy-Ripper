using CandyRipper.Scripts.Abstract;
using CandyRipper.Scripts.EnemyScripts.Abstract;

namespace CandyRipper.Scripts.EnemyScripts
{
    public class Enemy : Character, IEnemy
    {
        private void Awake()
        {
            InitializeValues();
        }
        protected override void Die()
        {
            Destroy(this.gameObject);
        }
    }
}