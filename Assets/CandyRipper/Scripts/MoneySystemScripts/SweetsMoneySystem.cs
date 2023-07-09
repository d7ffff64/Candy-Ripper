using System;
using CandyRipper.Scripts.MoneySystemScripts.Abstract;

namespace CandyRipper.Scripts.MoneySystemScripts
{
    public sealed class SweetsMoneySystem : MoneySystem
    {
        public static SweetsMoneySystem Instance { get; private set; }

        private void Awake()
        {
            InitializeSingletonAndDontDestroyOnLoad();
        }
        private void InitializeSingletonAndDontDestroyOnLoad()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}