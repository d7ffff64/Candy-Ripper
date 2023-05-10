using System;
using Assets.CandyRipper.NewInputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CandyRipper.Scripts.PlayerScripts.Control
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Information")]
        [SerializeField] private bool _isFacingRight = true;

        [Header("Movement Settings")]
        [SerializeField] private float _movementSpeed;
        
        [Header("Jump Settings")]
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _jumpForce;

        [Header("Jump References")]
        [SerializeField] private Transform _groundCheck;

        private Vector2 _movementAxis;

        private PlayerActionControls _playerActionControls;

        private Rigidbody2D _rigidbody2D;

        private SpriteRenderer _spriteRenderer;
        public bool IsFacingRight => _isFacingRight;
        private void Awake()
        {
            _playerActionControls = new PlayerActionControls();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            _playerActionControls.Player.Jump.performed += _ => Jump();
        }
        private void OnEnable()
        {
            _playerActionControls.Enable();
        }
        private void Update()
        {
            ReadMoveAxisValue();
            Move();
            FlipUpdate();
        }
        private void OnDisable()
        {
            _playerActionControls.Disable();
        }
        private void ReadMoveAxisValue()
        {
            _movementAxis = _playerActionControls.Player.Move.ReadValue<Vector2>();
        }
        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_movementAxis.x * _movementSpeed, _rigidbody2D.velocity.y);
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayerMask);
        }
        private void FlipUpdate()
        {
            if (_movementAxis.x > 0 && !_isFacingRight)
            {
                Flip();
            }
            else if (_movementAxis.x < 0 && _isFacingRight)
            {
                Flip();
            }
        }
        public void Jump()
        {
            if (IsGrounded())
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            }
        }
        private void Flip()
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _isFacingRight = !_isFacingRight;
        }
    }
}
