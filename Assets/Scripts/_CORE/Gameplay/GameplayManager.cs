using UnityEngine;




namespace Mobile_Gameplay
{

    public enum GameStates
    {
        GAME_START,
        GAME_OVER,
        GAME_WON,
    };

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        [SerializeField, Header("TESTING")]GameStates gameState;
        [SerializeField] GameObject player;
        [SerializeField] GameObject spawnManager;


        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            gameState = GameStates.GAME_START;
        }

        public void OnGameState(GameStates state)
        {
            switch (state)
            {
                case GameStates.GAME_OVER:
                    player.SetActive(false);
                    spawnManager.SetActive(false);
                    break;
                case GameStates.GAME_WON:
                    break;
            }
        }

      
      

    }

}