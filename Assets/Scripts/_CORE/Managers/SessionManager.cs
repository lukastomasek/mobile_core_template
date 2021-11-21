using UnityEngine;

namespace Mobile_Core
{

    public class SessionManager : SingeltonTemplate<SessionManager>
    {

        public SessionManager() { }


        GameManager _gameManager;



        private void Start()
        {
            _gameManager = GameManager.Instance;

            if(_gameManager.GetData.showRatingPanel == TagManager.SHOW_RATING_PANEL_COUNTER)
            {
                // show rating panel
            }
        }


        public void LoadNextGameplayLevel()
        {
            // incase if game-manager is null
            if (_gameManager == null)
                _gameManager = GameManager.Instance;


            if (_gameManager.GetData.adsPerLevelCounter == TagManager.SHOW_INTERSTITIAL_AD_COUNTER)
            {
                // show intestitial ad


            }

            var data = new SaveData();

            var bg = _gameManager.loadingBackground;
            var progress = _gameManager.loadingProgressImage;
            var txt = _gameManager.loadingTxt;


            SceneLoader.Instance.LoadScene(data.levelCounter.ToString(),
                bg,progress,txt
                );

            data.levelCounter++;

            SaveManager.Save(data);
           
        }





    }

}