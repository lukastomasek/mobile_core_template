using UnityEngine;
using Mobile_Gameplay;

namespace Mobile_Core
{

    public class SessionManager : SingeltonTemplate<SessionManager>
    {

        public SessionManager() { }


        GameplayManager _gameplay;



        private void Start()
        {
            _gameplay = GameplayManager.instance;

            if(_gameplay.Data.showRatingPanel == TagManager.SHOW_RATING_PANEL_COUNTER)
            {
                // show rating panel
            }
        }


        public void LoadNextGameplayLevel()
        {
            // incase if game-manager is null
            if (_gameplay == null)
                _gameplay = GameplayManager.instance;


            if (_gameplay.Data.adsPerLevelCounter == TagManager.SHOW_INTERSTITIAL_AD_COUNTER)
            {
                // show intestitial ad


            }

            var data = new SaveData();

            var bg = _gameplay.loadingBackground;
            var progress = _gameplay.loadingProgressImage;
            var txt = _gameplay.loadingTxt;


            SceneLoader.Instance.LoadScene(data.levelCounter.ToString(),
                bg,progress,txt
                );

            data.levelCounter++;

            SaveManager.Save(data);
           
        }





    }

}