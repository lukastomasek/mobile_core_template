using System;

namespace Mobile_Core
{
    [Serializable]
    public class SaveData
    {
        // player data goes here...

        public int playerCurrency;


        // options data
        public bool playMusic;
        public bool playSound;
        public bool enableHaptic;


        // social
        // keep track of the rating counter to show rating panel
        public int showRatingPanel;
        public int adsPerLevelCounter;
        public int levelCounter;


        // reset all data
        public void Reset()
        {
            playerCurrency = 0;
            playMusic = true;
            playSound = true;
            enableHaptic = true;
            showRatingPanel = 0;
            adsPerLevelCounter = 0;
        }

    }
}
