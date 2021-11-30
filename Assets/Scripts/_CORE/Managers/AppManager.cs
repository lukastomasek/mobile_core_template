using UnityEngine;
using System;

namespace Mobile_Core
{

    public enum AppState
    {
        PAUSE,
        UPDATE
    }

    public class AppManager : SingeltonTemplate<AppManager>
    {

        [SerializeField] int targetFramerate = 60;
        [SerializeField] int pauseFramerate = 15;

        public AppManager() { }

        public AppState State { get; set; }

        public static Action<AppState> OnAppStateUpdated;

        private void Start()
        {
            UpdateAppState(AppState.UPDATE);
        }

        public void UpdateAppState(AppState newState)
        {
            State = newState;

            Debug.Log(State);

            switch (newState)
            {
                case AppState.UPDATE:
                    HandleAppUpdate();
                    break;
                case AppState.PAUSE:
                    HandleAppPause();
                    break;
                default:
                    break;
            }

            OnAppStateUpdated?.Invoke(newState);
        }


        void HandleAppUpdate()
        {
            Application.targetFrameRate = targetFramerate;
            Time.timeScale = 1;
        }

        void HandleAppPause()
        {
            Application.targetFrameRate = pauseFramerate;
            Time.timeScale = 0;
        }

    }

}