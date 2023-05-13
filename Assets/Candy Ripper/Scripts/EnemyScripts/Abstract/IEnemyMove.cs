﻿using UnityEngine;

namespace Candy_Ripper.Scripts.EnemyScripts.Abstract
{
    public interface IEnemyMove
    {
        void Move(Vector2 direction);
        void SetDirection(Vector2 direction);
    }
}