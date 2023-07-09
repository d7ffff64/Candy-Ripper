using UnityEngine;
using UnityEngine.UI;

namespace CandyRipper.Scripts.PlayerScripts.Abstract
{
    public abstract class PrefabSelectByIndex : MonoBehaviour
    { 
        protected string key = "KeyName";
        
        [Header("Settings")]
        [SerializeField] protected int selectedPrefabIndex;

        [Header("References")] 
        [SerializeField] protected SpriteRenderer[] objects;
        [SerializeField] protected Image selectedPrefab;
        [SerializeField] protected GameObject selectPrefabButton;
        [SerializeField] protected GameObject selectedPrefabText;
        [SerializeField] protected GameObject buyPrefabButton;
        
        public void SaveSelectedIndex()
        {
            PlayerPrefs.SetInt($"{key}", selectedPrefabIndex);
            Debug.Log($"Key: {key} Selected Prefab Index: {PlayerPrefs.GetInt($"{key}")}");
            CheckCurrentIndexWithSaved();
        }
        protected void LoadSelectedIndex()
        {
            if (PlayerPrefs.HasKey($"{key}"))
            {
                selectedPrefabIndex = PlayerPrefs.GetInt($"{key}");
            }
        }
        public void RightArrowButton()
        {
            if (selectedPrefabIndex < objects.Length - 1)
            {
                selectedPrefabIndex++;
                CheckCurrentIndexWithSaved();
                UpdateSelectedPrefabImage();
            }
        }
        public void LeftArrowButton()
        {
            if (selectedPrefabIndex >= 1)
            {
                selectedPrefabIndex--;
                CheckCurrentIndexWithSaved();
                UpdateSelectedPrefabImage();
            }
        }
        protected void CheckCurrentIndexWithSaved()
        {
            var isSelected = selectedPrefabIndex == PlayerPrefs.GetInt($"{key}");
            
            selectPrefabButton.SetActive(!isSelected);
            selectedPrefabText.SetActive(isSelected);
        }
        protected void UpdateSelectedPrefabImage()
        {
            selectedPrefab.sprite = objects[selectedPrefabIndex].sprite;
        }
    }
}