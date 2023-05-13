using Assets.CandyRipper.Scripts.Abstract;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.PlayerScripts
{
    [RequireComponent(typeof(PlayerUIAttributes))]
    public class Player : Character
    {
        private PlayerUIAttributes _playerUIAttributes;

        private void Awake()
        {
            _playerUIAttributes = GetComponent<PlayerUIAttributes>();
            
            InitializeValues();
            UpdateAttributes(_playerUIAttributes);
        }
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            UpdateAttributes(_playerUIAttributes);
        }
        protected override void Die()
        {
            Debug.Log("You die!");
            UpdateAttributes(_playerUIAttributes);
        }
    }
}