using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Mobile_Core;


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

        [Space(20), HorizontalLine(color: EColor.Blue), Header("SETTINGS")]
        [SerializeField, Required] GameObject uiPanel;
        [SerializeField, Required] Button restartBtn;
        [SerializeField, Required] Button quitBtn;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            restartBtn.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene("Test_Scene");
            });

            quitBtn.onClick.AddListener(() =>
            {
                SceneLoader.Instance.LoadScene("Test");
            });
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
                    //player.SetActive(false);
                    //spawnManager.SetActive(false);
                    //uiPanel.SetActive(true);
                    break;
                case GameStates.GAME_WON:
                    break;
            }
        }

      
      

    }

}