using CandyRipper.Scripts.Abstract;
using UnityEngine;

namespace CandyRipper.Scripts.PlayerScripts
{
    public class Player : Character
    {
        private PlayerUIAttributes _playerUIAttributes;

        private void Awake()
        {
            _playerUIAttributes = FindObjectOfType<PlayerUIAttributes>().GetComponent<PlayerUIAttributes>();
            
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