using CandyRipper.Scripts.Abstract;
using CandyRipper.Scripts.EnemyScripts.Abstract;

namespace CandyRipper.Scripts.EnemyScripts
{
    public class Enemy : Character, IEnemy
    {
        private EnemyItemDropper _enemyItemDropper;
        private void Awake()
        {
            InitializeValues();

            _enemyItemDropper = GetComponent<EnemyItemDropper>();
        }
        protected override void Die()
        {
            Destroy(gameObject);

            _enemyItemDropper.SpawnRandomAmountOfSweetness();
        }
    }
}