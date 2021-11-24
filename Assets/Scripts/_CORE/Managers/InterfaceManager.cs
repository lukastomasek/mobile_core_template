using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using Mobile_Core;

namespace Mobile_UI
{
    public class InterfaceManager : MonoBehaviour
    {
        [HorizontalLine(color: EColor.Green)]
        [Header("UI/LOADING")]
        public GameObject loadingBackground;
        public Image loadingProgressImage;
        public TextMeshProUGUI loadingTxt;

        [Header("UI/PLAYER"), HorizontalLine(color: EColor.Blue)]
        [SerializeField] TextMeshProUGUI playerCurrencyTxt;
        [SerializeField] CurrencyCounter currencyCounter;

        [Header("UI/REWARS"), HorizontalLine(color: EColor.Yellow)]
        [SerializeField] GameObject rewardBooster;
        [SerializeField] GameObject doubleBooster;


        private void OnEnable()
        {
            ScoreManager.OnPlayerUIUpdate += UpdateWallet;
        }

        private void OnDisable()
        {
            ScoreManager.OnPlayerUIUpdate -= UpdateWallet;
        }

        public void UpdateWallet(int moneyReceived)
        {
            currencyCounter.UpdateCurrencyText(Wallet.currentAmount, moneyReceived);
            Wallet.AddMoney(moneyReceived);
        }

        public void SetRewardPanel(bool set)
        {
            if (set)
            {
                rewardBooster.SetActive(true);
            }
            else
            {
                rewardBooster.SetActive(false);
            }
        }

        public void SetDoublePanel(bool set)
        {
            if (set)
            {
                doubleBooster.SetActive(true);
            }
            else
            {
                doubleBooster.SetActive(false);
            }
        }

    }

}