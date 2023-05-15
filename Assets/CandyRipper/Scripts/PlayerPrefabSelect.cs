using System;
using CandyRipper.Scripts.Abstract;
using UnityEngine;

namespace CandyRipper.Scripts
{
    public class PlayerPrefabSelect : MonoBehaviour
    {
        private string _key = "SelectedPlayerPrefab";
        private int _selectedPrefabIndex = 0;

        public static PlayerPrefabSelect Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void IncreaseIndex()
        {
            _selectedPrefabIndex++;
        }
        public void SavePlayerPrefs()
        {
            PlayerPrefs.SetInt($"{_key}", _selectedPrefabIndex);
        }
        public void LoadPlayerPrefs()
        {
            if (PlayerPrefs.HasKey($"{_key}"))
            {
                _selectedPrefabIndex = PlayerPrefs.GetInt($"{_key}");
            }
        }
    }
}