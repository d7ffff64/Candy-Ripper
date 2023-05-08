using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CandyRipper.Scripts.PlayerScripts.Control
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Player Input Information")]
        [SerializeField] private Vector2 _movement;
        [SerializeField] private bool _isMoving;
        [SerializeField] private bool _isJumping;
        public Vector2 Movement => _movement;
        public bool IsMoving => _isMoving;
        public bool IsJumping => _isJumping;
        public void OnMove(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();

            if (context.started)
            {
                _isMoving = true;
            }

            if (context.canceled)
            {
                _isMoving = false;
            }
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _isJumping = true;
                
            }

            if (context.canceled)
            {
                _isJumping = false;
            }
        }
    }
}
