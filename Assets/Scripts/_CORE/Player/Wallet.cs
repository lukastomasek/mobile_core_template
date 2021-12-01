using UnityEngine;
using System;

namespace Mobile_Core
{
    public static class Wallet
    {
        public static int currentAmount = 0;
        public static int currentAmountBeforeUpdating = 0;

        public static Action<int, int> onUpdate;



        public static void AddMoney(int receivingAmount)
        {
            currentAmount += receivingAmount;

            SaveData data = new SaveData();

            data.playerCurrency = currentAmount;

            SaveManager.Save(data);


            // reset amount recieved after saving 
            //ammountRecieved = 0;

        }

        public static void RemoveMoney(int removingAmount)
        {
            if (currentAmount < removingAmount)
            {
                Debug.Log("<b>Don't have enough currency!</b>");
                return;
            }

            currentAmount -= removingAmount;

            if (currentAmount <= 0)
                currentAmount = 0;

            SaveData data = new SaveData()
            {
                playerCurrency = currentAmount,
            };

            SaveManager.Save(data);

        }


        public static void ResetMoney()
        {
            SaveData data = new SaveData();
            currentAmount = 0;
            data.playerCurrency = currentAmount;
            Debug.Log("<b>reseting currency to: </b>" + currentAmount);
            SaveManager.Save(data);
        }


        public static void Load()
        {
            SaveData data = new SaveData();

            data = SaveManager.Load();

            currentAmount = data.playerCurrency;
            Debug.Log("<b>current amounnt in the wallet is: </b>" + currentAmount);

        }
    }

}