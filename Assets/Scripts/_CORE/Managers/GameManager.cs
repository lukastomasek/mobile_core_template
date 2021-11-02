using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// game manager should control the core system of the application
/// </summary>
///

namespace Mobile_Core
{
    public enum AppStates
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

        public AppStates appState;

        protected GameManager() { }

        private void Start()
        {
            appState = AppStates.APP_UPDATE;
            SetTargetFramerate(appState);
        }


        void Update()
        {
            //testing
            if (Input.GetKeyDown(KeyCode.Space))
            {
                appState = AppStates.APP_PAUSE;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                appState = AppStates.APP_UPDATE;
            }

            switch (appState)
            {
                case AppStates.APP_UPDATE:
                    SetTargetFramerate(appState);
                    break;

                case AppStates.APP_PAUSE:
                    SetTargetFramerate(appState);
                    break;

                case AppStates.APP_EXIT:
                    break;

                default:
                    appState = AppStates.APP_START;
                    Time.timeScale = 1;
                    break;
            }

        }

        void SetTargetFramerate(AppStates state)
        {
            if (state == AppStates.APP_UPDATE || state == AppStates.APP_START)
            {
                if (Application.targetFrameRate != gameFramerate)
                    Application.targetFrameRate = gameFramerate;
            }
            if (state == AppStates.APP_PAUSE)
            {
                if (Application.targetFrameRate != pauseFramerate)
                    Application.targetFrameRate = pauseFramerate;
            }
            //Debug.Log(Application.targetFrameRate);
        }


        public void PauseGame(bool isPaused)
        {
            if (isPaused)
            {
                appState = AppStates.APP_PAUSE;
                Time.timeScale = 0;
            }
            else
            {
                appState = AppStates.APP_UPDATE;
                Time.timeScale = 1;
            }
        }
    }

}