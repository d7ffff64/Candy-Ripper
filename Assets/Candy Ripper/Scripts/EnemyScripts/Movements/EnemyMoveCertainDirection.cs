using System;
using System.Collections;
using System.Collections.Generic;
using Assets.CandyRipper.Scripts.EnemyScripts.Abstract;
using UnityEngine;

public class EnemyMoveCertainDirection : MonoBehaviour, IEnemyMove
{
    [Header("Settings")] 
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector2 _direction;

    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move(_direction);
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    public void Move(Vector2 direction)
    {
        _rigidbody2D.velocity = new Vector2(direction.x * _movementSpeed, _rigidbody2D.velocity.y);
    }
}
