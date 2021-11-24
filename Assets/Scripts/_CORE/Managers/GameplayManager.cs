using UnityEngine;
using Mobile_UI;
using NaughtyAttributes;
using Mobile_Core;



namespace Mobile_Gameplay
{

    public enum GameStates
    {
        GAME_START,
        GAME_OVER,
        GAME_WON,
    };

    public enum RewardStates
    {
        RANDOM_REWARD,
        DOUBLE,
        CHEST
    };

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        [SerializeField, Header("TESTING")] GameStates gameState;
        [SerializeField, Header("TESTING")] RewardStates rewardState;
        [SerializeField] GameObject player;
        [SerializeField] GameObject spawnManager;
        [SerializeField] InterfaceManager uiManager;

        ScoreManager _score;

        public SaveData Data { get; set; }

        private void Awake()
        {
            if (instance == null)
                instance = this;


            _score = FindObjectOfType<ScoreManager>();


        }



        private void OnEnable()
        {
            ScoreManager.OnWon += GameWon;
        }

        private void OnDisable()
        {
            ScoreManager.OnWon -= GameWon;
        }

        void GameWon()
        {
            Debug.Log("won the game");
            OnGameState(GameStates.GAME_WON);
        }

        private void Start()
        {
            gameState = GameStates.GAME_START;
            rewardState = RewardStates.RANDOM_REWARD;
            Data = SaveManager.Load();
        }

        public void ChangeRewardStateToDouble()
        {
            rewardState = RewardStates.DOUBLE;
        }
        public void ChangeRewardStateToChest()
        {
            rewardState = RewardStates.CHEST;
        }

        public void OnGameState(GameStates state)
        {
            switch (state)
            {
                case GameStates.GAME_OVER:
                    player.SetActive(false);
                    spawnManager.SetActive(false);
                    //uiPanel.SetActive(true);

                    switch (rewardState)
                    {
                        case RewardStates.RANDOM_REWARD:
                            uiManager.SetRewardPanel(true);
                            break;
                        case RewardStates.DOUBLE:
                            print("double");
                            uiManager.SetRewardPanel(false);
                            uiManager.SetDoublePanel(true);
                            break;

                        case RewardStates.CHEST:
                            uiManager.SetRewardPanel(false);
                            uiManager.SetDoublePanel(false);
                            break;
                    }

                    break;
                case GameStates.GAME_WON:
                    player.SetActive(false);
                    spawnManager.SetActive(false);
                    //uiPanel.SetActive(true);
                    // update wallet 
                    Wallet.AddMoney(_score.TotalScore());
                    Wallet.onUpdate?.Invoke(Wallet.currentAmount, _score.TotalScore());
                    break;
            }
        }

    }

}