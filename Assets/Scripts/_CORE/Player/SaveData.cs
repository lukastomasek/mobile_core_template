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
       


        // reset all data
        public void Reset()
        {
            playerCurrency = 0;
        }

    }
}
