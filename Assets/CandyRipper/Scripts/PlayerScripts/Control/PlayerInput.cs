using System;
using Assets.CandyRipper.NewInputSystem;
using UnityEngine;

namespace CandyRipper.Scripts.PlayerScripts.Control
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnJumpEvent;
        public event Action OnReloadEvent;
        
        public bool IsShoting => _isShoting;
        public bool IsMoving => _isMoving;
        public Vector2 MovementAxis => _movementAxis;
        
        private Vector2 _movementAxis;
        
        private bool _isShoting = false;
        private bool _isMoving = false;

        private PlayerActionControls _playerActionControls;
        
        private void Awake()
        {
            _playerActionControls = new PlayerActionControls();

            _playerActionControls.Player.Jump.performed += callbackContext => OnJump();
            _playerActionControls.Player.Shot.performed += callbackContext => OnShot();
            _playerActionControls.Player.Reload.performed += callbackContext => OnReload();
        }
        private void OnEnable()
        {
            _playerActionControls.Enable();
        }
        private void Update()
        {
            OnMove();
        }
        private void OnDisable()
        {
            _playerActionControls.Disable();
        }
        private void OnMove()
        {
            _movementAxis = _playerActionControls.Player.Move.ReadValue<Vector2>();
            _isMoving = _movementAxis != Vector2.zero;
        }
        private void OnJump()
        {
            OnJumpEvent?.Invoke();
        }
        private void OnShot()
        {
            _isShoting = !_isShoting;
        }
        private void OnReload()
        {
            OnReloadEvent?.Invoke();
        }
    }
}