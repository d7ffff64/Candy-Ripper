using System.Collections;
using Assets.CandyRipper.Scripts.PlayerScripts.Control;
using UnityEngine;

namespace Assets.CandyRipper.Scripts.PlayerScripts.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [Header("Weapon References")] 
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform[] _accurateBulletsBarrels;
        [SerializeField] private Transform[] _notAccurateBulletsBarrels;

        [Header("Weapon Timer Information")]
        [SerializeField] private float _currentTimeTimer;

        [Header("Weapon Timer Settings")]
        [SerializeField] private float _timeToNextBullet;

        [Header("Weapon Reload Settings")]
        [SerializeField] private float _timeToStartReloading;
        [SerializeField] private float _timeToEndReloading;

        [Header("Weapon Information")]
        [SerializeField] private int _bullets;
        [SerializeField] private bool _isReloading = false;
        
        [Header("Weapon Settings")]
        [SerializeField] private int _maximumBullets;
        [SerializeField] private int _damagePower;
        public int DamagePower => _damagePower;
        
        private PlayerInput _playerInput;
        private PlayerUIAttributes _playerUIAttributes;
        private void Awake()
        {
            _playerInput = GetComponentInParent<PlayerInput>();
            _playerUIAttributes = GetComponentInParent<PlayerUIAttributes>();

            _bullets = _maximumBullets;
            _playerUIAttributes.UpdateAmmoAttribute(_bullets, _maximumBullets);
        }
        private void OnEnable()
        {
            _playerInput.OnReloadEvent += CoroutineReload;
        }
        private void Update()
        {
            if (_playerInput.IsShoting && !_isReloading)
            {
                _currentTimeTimer += Time.deltaTime;
                if (_currentTimeTimer >= _timeToNextBullet)
                {
                    Shot();
                    _currentTimeTimer = 0f;
                }
            }
        }
        private void OnDisable()
        {
            _playerInput.OnReloadEvent -= CoroutineReload;
        }
        private void CoroutineReload()
        {
            StartCoroutine(Reload());
        }
        private IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(_timeToStartReloading);
            _bullets = _maximumBullets;
            _playerUIAttributes.UpdateAmmoAttribute(_bullets, _maximumBullets);
            yield return new WaitForSeconds(_timeToEndReloading);
            _currentTimeTimer = 0f;
            _isReloading = false;
        }
        private void Shot()
        {
            if (_bullets > 0 && !_isReloading)
            {
                CreateABullet(_playerInput.IsMoving ? _notAccurateBulletsBarrels : _accurateBulletsBarrels);
            }
            else
            {
                if (!_isReloading)
                {
                    StartCoroutine(Reload());
                }
            }
        }
        private void CreateABullet(Transform[] barrels)
        {
            Transform indexTransform;
            indexTransform = barrels.Length == 1 ? barrels[0] : barrels[UnityEngine.Random.Range(0, barrels.Length)];

            Instantiate(_bulletPrefab, new Vector2(indexTransform.position.x, barrels[0].position.y), indexTransform.transform.rotation);
            _bullets -= 1;
            _playerUIAttributes.UpdateAmmoAttribute(_bullets, _maximumBullets);
        }
    }
}