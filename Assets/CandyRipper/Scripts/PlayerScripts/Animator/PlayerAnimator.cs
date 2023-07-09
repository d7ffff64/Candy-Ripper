using System;
using CandyRipper.Scripts.PlayerScripts.Control;
using UnityEngine;

namespace CandyRipper.Scripts.PlayerScripts.Animator
{
    public class PlayerAnimator : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerMovement _playerMovement;
        private UnityEngine.Animator _animator;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _animator = GetComponent<UnityEngine.Animator>();
        }
        private void Update()
        {
            _animator.SetBool("IsMoving", _playerInput.IsMoving);
            if (!_playerMovement.IsGrounded())
            {
                _animator.SetBool("IsJumping",true);
            }
            else
            {
                _animator.SetBool("IsJumping",false);
            }
        }
    }
}