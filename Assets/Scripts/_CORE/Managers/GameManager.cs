using System;
using UnityEngine;
using NaughtyAttributes;
using Mobile_UI;

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
            Time.timeScale = 0;
            Debug.Log("You Won!");
        }

        void HandleLose()
        {
            Time.timeScale = 0;
            Debug.Log("You Lost!");
            
        }
    }

}