using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Mobile_Core;
using TMPro;


namespace Mobile_Gameplay
{

    public enum GameStates
    {
        GAME_START,
        GAME_OVER,
        GAME_WON,
    };

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        [SerializeField, Header("TESTING")] GameStates gameState;
        [SerializeField] GameObject player;
        [SerializeField] GameObject spawnManager;


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
            Data = SaveManager.Load();
        }

        public void OnGameState(GameStates state)
        {
            switch (state)
            {
                case GameStates.GAME_OVER:
                    player.SetActive(false);
                    spawnManager.SetActive(false);
                    //uiPanel.SetActive(true);
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