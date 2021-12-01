using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using Mobile_Core;
using System;

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
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] TextMeshProUGUI walletTxt;
        [SerializeField] CurrencyCounter currencyCounter;

        [Header("UI/REWARS"), HorizontalLine(color: EColor.Yellow)]
        [SerializeField] GameObject rewardBooster;
        [SerializeField] GameObject firtReward;

        [Header("UI/BUTTONS"), HorizontalLine(color: EColor.Violet)]
        [SerializeField] Button openOptionsBtn;
        [SerializeField] Button closeOptionsBtn;
        [SerializeField] Button mainMenuBtn;

        [Header("UI/PANEL"), HorizontalLine(color: EColor.Red)]
        [SerializeField] GameObject endPanel;


        public static Action<int> OnUpdatePlayerUI;


        private void Awake()
        {
            OnUpdatePlayerUI += AddMoneyToWallet;
            GameManager.OnGameStateUpdated += UpdateGameState;

        }

        private void Start()
        {
            walletTxt.SetText($"${Wallet.currentAmount}");

            // handle application states
            openOptionsBtn.onClick.AddListener(() => AppManager.Instance.UpdateAppState(AppState.PAUSE));
            closeOptionsBtn.onClick.AddListener(() => AppManager.Instance.UpdateAppState(AppState.UPDATE));
            mainMenuBtn.onClick.AddListener(() => SessionManager.Instance.GoBackToMainMenu());
        }

        private void OnDestroy()
        {
            OnUpdatePlayerUI -= AddMoneyToWallet;
            GameManager.OnGameStateUpdated -= UpdateGameState;
        }



        public void UpdateGameState(GameState state)
        {
            if (state == GameState.LOSE)
            {
                endPanel.SetActive(true);
            }
            else if (state == GameState.VICTORY)
            {
                firtReward.SetActive(true);
            }
        }

        public void OpenPanel(GameObject panel)
        {
            if (!panel.activeInHierarchy)
            {
                panel.SetActive(true);
            }
        }

        public void ClosePanel(GameObject panel) => panel.SetActive(false);



        void AddMoneyToWallet(int money)
        {
            Debug.Log("passing to wallet" + money);

            //walletTxt.SetText($"${Wallet.currentAmount}");

            int oldAmount = Wallet.currentAmountBeforeUpdating;
            int newAmount = Wallet.currentAmount;

            currencyCounter.UpdateCurrencyText(oldAmount, newAmount);

            // update the old amount to keep track
            Wallet.currentAmountBeforeUpdating = Wallet.currentAmount;
        }




    }

}