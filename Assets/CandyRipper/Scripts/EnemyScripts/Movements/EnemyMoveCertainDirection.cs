using System;
using System.Collections;
using System.Collections.Generic;
using CandyRipper.Scripts.EnemyScripts.Abstract;
using UnityEditor.Localization.Platform.Android;
using UnityEngine;

namespace CandyRipper.Scripts.EnemyScripts.Movements
{
    public class EnemyMoveCertainDirection : MonoBehaviour, IEnemyMove
    {
        [Header("Information")] 
        [SerializeField] private Vector2 _direction;
        
        [Header("Settings")] 
        [SerializeField] private float _movementSpeed;

        private Rigidbody2D _rigidbody2D;

        private Transform _playerTransform;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        private void Start()
        {
            if (_playerTransform != null)
            {
                _direction = (_playerTransform.position - transform.position).normalized;
            }
        }
        private void Update()
        {
            Move(_direction);
        }
        public void Move(Vector2 direction)
        {
            _rigidbody2D.velocity = new Vector2(direction.x * _movementSpeed, _rigidbody2D.velocity.y);
        }
    }
}

