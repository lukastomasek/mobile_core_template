using UnityEngine;
using Mobile_Gameplay;
using Mobile_UI;
using UnityEngine.SceneManagement;

namespace Mobile_Core
{


    public class SessionManager : SingeltonTemplate<SessionManager>
    {

        public SessionManager() { }




        GameplayManager _gameplay;
        InterfaceManager _interface;


        private void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {

                //_gameplay = GameplayManager.instance;
                _interface = FindObjectOfType<InterfaceManager>();

                //if (_gameplay.Data.showRatingPanel == TagManager.SHOW_RATING_PANEL_COUNTER)
                //{
                //    // show rating panel
                //}
            }
        }

        [ContextMenu("Reset Wallet")]
        public void ResetWallet() => Wallet.ResetMoney();

        public void LoadNextGameplayLevel()
        {
            // incase if game-manager is null
            //if (_gameplay == null)
            //    _gameplay = GameplayManager.instance;

            if (_interface == null)
                _interface = FindObjectOfType<InterfaceManager>();

            //if (_gameplay.Data.adsPerLevelCounter == TagManager.SHOW_INTERSTITIAL_AD_COUNTER)
            //{
            //    // show intestitial ad


            //}

            var data = new SaveData();

            var bg = _interface.loadingBackground;
            var progress = _interface.loadingProgressImage;
            var txt = _interface.loadingTxt;

            SceneLoader.Instance.LoadScene(data.levelCounter, bg, progress, txt);

            data.levelCounter++;

            SaveManager.Save(data);

        }

        public void GoBackToMainMenu()
        {
            if (_interface == null)
                _interface = FindObjectOfType<InterfaceManager>();

           
            var bg = _interface.loadingBackground;
            var progress = _interface.loadingProgressImage;
            var txt = _interface.loadingTxt;


            SceneLoader.Instance.LoadScene(0, bg, progress, txt);
        }


    }

}