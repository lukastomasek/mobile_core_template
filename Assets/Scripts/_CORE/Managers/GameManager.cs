using System;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;

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
        [Header("APPLICATION SETTINGS")]
        [HorizontalLine(color: EColor.Pink)]
        [SerializeField] int pauseFramerate = 15;
        [SerializeField] int gameFramerate = 30;

        [Header("UI/LOADING")]
        [HorizontalLine(color: EColor.Yellow)]
        public GameObject loadingBackground;
        public Image loadingProgressImage;
        public TextMeshProUGUI loadingTxt;

        public AppStates appState;


        SaveData _data = new SaveData();

        protected GameManager() { }

        private void Start()
        {
            appState = AppStates.APP_UPDATE;
            SetTargetFramerate(appState);

            _data = SaveManager.Load();

            CheckHapticsSettings();
          
        }


        void CheckHapticsSettings()
        {
            if(_data.enableHaptic)
            {
                Handheld.Vibrate();
            }
        }


        public SaveData GetData
        {
            get { return _data; }
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