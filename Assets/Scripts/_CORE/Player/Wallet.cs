using UnityEngine;
using System;

namespace Mobile_Core
{
    public static class Wallet
    {
        public static int currentAmount;
        private static int ammountRecieved;

        //public delegate void  OnUpdateWallet(int currentAmount, int ammountReceiving);
        //public static event OnUpdateWallet OnUpdate;

        public static Action<int, int> onUpdate;

        public static void AddMoney(int receivingAmount)
        {
            ammountRecieved = receivingAmount;

          
        }

        public static void RemoveMoney(int removingAmount)
        {
            if(currentAmount < removingAmount)
            {
                Debug.Log("<b>Don't have enough currency!</b>");
                return;
            }

            currentAmount -= removingAmount;

            if (currentAmount <= 0)
                currentAmount = 0;

        }
    }

}