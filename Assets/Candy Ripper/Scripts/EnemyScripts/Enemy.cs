using Candy_Ripper.Scripts.Abstract;
using Candy_Ripper.Scripts.EnemyScripts.Abstract;

namespace Candy_Ripper.Scripts.EnemyScripts
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