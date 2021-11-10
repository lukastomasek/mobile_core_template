using System;

namespace Mobile_Core
{
    [Serializable]
    public class SaveData 
    {
        // player data goes here...

        public int playerCurrency;    



        // reset all data
        public void Reset()
        {
            playerCurrency = 0;
        }
    }
}
