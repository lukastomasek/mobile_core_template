using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// game manager should control the core system of the application
/// </summary>
///

namespace Mobile_Core
{
    public enum GameState
    {
        APP_START,
        APP_UPDATE,
        APP_PAUSE,
        APP_EXIT

    }


    public class GameManager : SingeltonTemplate<GameManager>
    {
        [SerializeField] int pauseFramerate = 15;
        [SerializeField] int gameFramerate = 30;

        public GameState gameState;

        protected GameManager() { }

        private void Start()
        {
            gameState = GameState.APP_START;
            SetTargetFramerate(gameState);
        }


        void Update()
        {
            //testing
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameState = GameState.APP_PAUSE;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                gameState = GameState.APP_UPDATE;
            }

            switch (gameState)
            {
                case GameState.APP_UPDATE:
                    SetTargetFramerate(gameState);
                    break;

                case GameState.APP_PAUSE:
                    SetTargetFramerate(gameState);
                    break;

                case GameState.APP_EXIT:
                    break;

                default:
                    gameState = GameState.APP_START;
                    break;
            }

        }

        void SetTargetFramerate(GameState state)
        {
            if (state == GameState.APP_UPDATE || state == GameState.APP_START)
            {
                if (Application.targetFrameRate != gameFramerate)
                    Application.targetFrameRate = gameFramerate;
            }
            if (state == GameState.APP_PAUSE)
            {
                if (Application.targetFrameRate != pauseFramerate)
                    Application.targetFrameRate = pauseFramerate;
            }
            //Debug.Log(Application.targetFrameRate);
        }
    }

}