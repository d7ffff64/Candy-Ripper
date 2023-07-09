using UnityEngine;

namespace CandyRipper.Scripts.MoneySystemScripts.Abstract
{
    public abstract class MoneySystem : MonoBehaviour
    {
        private int _moneyCount;
        public int MoneyCount => _moneyCount;

        public void IncreaseMoney(int amount)
        {
            _moneyCount += amount;
        }
        public void DecreaseMoney(int amount)
        {
            _moneyCount -= Mathf.Clamp(amount, 0, int.MaxValue);
        }
    }
}