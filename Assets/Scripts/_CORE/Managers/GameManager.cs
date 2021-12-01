using System;
using UnityEngine;
using NaughtyAttributes;


/// <summary>
/// game manager should control the core system of the application
/// </summary>
///

namespace Mobile_Core
{
    public enum GameState
    {
        GAME_START,
        VICTORY,
        LOSE
    };
    public enum RewardState
    {
        COINS,
        DOUBLE_COINS,
        CHEST
    };


    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;


        public static Action<GameState> OnGameStateUpdated;
        public static Action<int> OnUpdateScore;
        public static Action<int> OnUpdateUI;



        public GameState State { get; set; }

        [ContextMenu("Reset Wallet")]
        public void ResetWallet()
        {
            Wallet.ResetMoney();

        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                DestroyImmediate(instance);
        }

        private void Start()
        {
            Wallet.Load();

            // keep the initial value in the wallet
            Wallet.currentAmountBeforeUpdating = Wallet.currentAmount;

            AppManager.OnAppStateUpdated += HandleAppSate;

            // initialize the first state of app
            AppManager.Instance.UpdateAppState(AppState.UPDATE);
        }

        private void OnDestroy()
        {
            AppManager.OnAppStateUpdated -= HandleAppSate;
        }

        void HandleAppSate(AppState state)
        {
            if (state == AppState.PAUSE)
            {
                Time.timeScale = 0;
            }
            else if (state == AppState.UPDATE)
            {
                Time.timeScale = 1;
            }
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch (newState)
            {
                case GameState.GAME_START:
                    break;
                case GameState.VICTORY:
                    HandleVictory();
                    break;
                case GameState.LOSE:
                    HandleLose();
                    break;
                default:
                    break;
            }

            OnGameStateUpdated?.Invoke(newState);
        }


        void HandleVictory()
        {
            AppManager.Instance.UpdateAppState(AppState.PAUSE);
            Debug.Log("You Won!");
        }

        void HandleLose()
        {
            AppManager.Instance.UpdateAppState(AppState.PAUSE);
            Debug.Log("You Lost!");

        }
    }

}