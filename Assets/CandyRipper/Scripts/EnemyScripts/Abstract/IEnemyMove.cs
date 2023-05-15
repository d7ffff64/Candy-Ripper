using UnityEngine;

namespace CandyRipper.Scripts.EnemyScripts.Abstract
{
    public interface IEnemyMove
    {
        void Move(Vector2 direction);
    }
}