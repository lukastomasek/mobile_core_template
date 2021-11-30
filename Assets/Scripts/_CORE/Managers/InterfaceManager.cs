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
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] TextMeshProUGUI playerScoreTxt;
        [SerializeField] CurrencyCounter currencyCounter;

        [Header("UI/REWARS"), HorizontalLine(color: EColor.Yellow)]
        [SerializeField] GameObject rewardBooster;
        [SerializeField] GameObject firtReward;


        [Header("UI/PANEL")]
        [SerializeField] GameObject endPanel;


        ScoreManager _score;

        private void Awake()
        {
            GameManager.OnUpdateUI += UpdateScore;
            GameManager.OnGameStateUpdated += UpdateGameState;
            _score = FindObjectOfType<ScoreManager>();
          

        }

        private void Start()
        {
            playerScoreTxt.SetText($"${Wallet.currentAmount}");
        }

        private void OnDestroy()
        {
            GameManager.OnUpdateUI -= UpdateScore;
            GameManager.OnGameStateUpdated -= UpdateGameState;
        }

        void UpdateScore(int scoreRecieved)
        {
            scoreRecieved = _score.TotalScore();
            scoreTxt.SetText($"${scoreRecieved}/ {_score.maxScore}");
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

        public void UpdateWallet(int moneyReceived)
        {
            currencyCounter.UpdateCurrencyText(Wallet.currentAmount, moneyReceived);
           
        }




    }

}