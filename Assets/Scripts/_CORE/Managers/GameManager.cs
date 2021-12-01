using System;
using UnityEngine;
using NaughtyAttributes;


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
        STANDARD,
        BOOSTER,
        GIFT
    };


    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;


        public static Action<GameState> OnGameStateUpdated;
        public static Action<RewardState> OnRewardsChanged;
        public static Action<int> OnUpdateScore;
        public static Action<int> OnUpdateUI;


        public RewardState RewardState { get; set; }
        public GameState GameSate { get; set; }

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
            //if (state == AppState.PAUSE)
            //{
            //    Time.timeScale = 0;
            //}
            //else if (state == AppState.UPDATE)
            //{
            //    Time.timeScale = 1;
            //}
        }


        public void UpdateRewardState(RewardState newState)
        {
            RewardState = newState;

            switch (newState)
            {
                case RewardState.STANDARD:
                    break;
                case RewardState.BOOSTER:
                    break;
                case RewardState.GIFT:
                    break;
                default:
                    break;
            }

            OnRewardsChanged?.Invoke(newState);
        }

        public void UpdateGameState(GameState newState)
        {
            GameSate = newState;

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
            // set the first reward 
            UpdateRewardState(RewardState.STANDARD);
            Debug.Log("You Won!");
        }

        void HandleLose()
        {
            AppManager.Instance.UpdateAppState(AppState.PAUSE);
            Debug.Log("You Lost!");

        }
    }

}