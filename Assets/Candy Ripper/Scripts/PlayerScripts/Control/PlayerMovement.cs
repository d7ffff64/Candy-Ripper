using UnityEngine;

namespace Candy_Ripper.Scripts.PlayerScripts.Control
{
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
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

        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;
        public bool IsFacingRight => _isFacingRight;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            _playerInput.OnJumpEvent += Jump;
        }
        private void Update()
        {
            Move();
            FlipUpdate();
        }
        private void OnDisable()
        {
            _playerInput.OnJumpEvent -= Jump;
        }
        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_playerInput.MovementAxis.x * _movementSpeed, _rigidbody2D.velocity.y);
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayerMask);
        }
        private void FlipUpdate()
        {
            if (_playerInput.MovementAxis.x > 0 && !_isFacingRight)
            {
                Flip();
            }
            else if (_playerInput.MovementAxis.x < 0 && _isFacingRight)
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
            transform.Rotate(0f, 180f, 0f);
            
            _isFacingRight = !_isFacingRight;
        }
    }
}
