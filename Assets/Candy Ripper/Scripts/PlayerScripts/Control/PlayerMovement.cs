using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.PlayerScripts.Control
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Information")]
        [SerializeField] private bool _isFacingRight = true;

        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed;

        [Header("Jump Information")]
        [SerializeField] private bool _isGrounded;
        
        [Header("Jump Settings")]
        [SerializeField] private LayerMask _groundLayerMask;

        [SerializeField] private float _jumpForce;

        [Header("Jump References")]
        [SerializeField] private Transform _groundCheck;
        
        private PlayerInput _playerInput;
        
        private Rigidbody2D _rigidbody2D;

        private SpriteRenderer _spriteRenderer;

        public bool IsFacingRight => _isFacingRight;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();

            _rigidbody2D = GetComponent<Rigidbody2D>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            Move();
            FlipUpdate();
            GroundUpdate();
        }
        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_playerInput.Movement.x * _movementSpeed, _rigidbody2D.velocity.y);
        }
        private void GroundUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayerMask);
            Jump(_jumpForce);
        }
        private void FlipUpdate()
        {
            if (Input.GetAxis("Horizontal") > 0 && !_isFacingRight)
            {
                Flip();
            }
            else if (Input.GetAxis("Horizontal") < 0 && _isFacingRight)
            {
                Flip();
            }
        }
        public void Jump(float jumpForce)
        {
            if (_isGrounded && _playerInput.IsJumping)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            }
        }
        private void Flip()
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _isFacingRight = !_isFacingRight;
        }
    }
}
