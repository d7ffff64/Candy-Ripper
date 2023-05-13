using TMPro;
using UnityEngine;

namespace Candy_Ripper.Scripts.PlayerScripts
{
    public class PlayerUIAttributes : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _healthTMP;
        [SerializeField] private TextMeshProUGUI _protectionTMP;
        [SerializeField] private TextMeshProUGUI _ammoTMP;
        
        public void UpdateHealthAttribute(int firstValue, int secondValue)
        {
            UpdateAttribute(_healthTMP, firstValue, secondValue);
        }
        public void UpdateProtectionAttribute(int firstValue, int secondValue)
        {
            UpdateAttribute(_protectionTMP, firstValue, secondValue);
        }
        public void UpdateAmmoAttribute(int firstValue, int secondValue)
        {
            UpdateAttribute(_ammoTMP, firstValue, secondValue);
        }
        private void UpdateAttribute(TextMeshProUGUI textMeshProUGUI, int firstValue, int secondValue)
        {
            textMeshProUGUI.text = $"{firstValue}/{secondValue}";
        }
    }   
}
