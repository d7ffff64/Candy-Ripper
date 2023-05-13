using Assets.CandyRipper.Scripts.Abstract;
using Assets.CandyRipper.Scripts.EnemyScripts.Abstract;

namespace Assets.CandyRipper.Scripts.EnemyScripts
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