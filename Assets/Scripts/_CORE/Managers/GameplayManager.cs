using UnityEngine;
using Mobile_UI;
using NaughtyAttributes;
using Mobile_Core;



namespace Mobile_Gameplay
{

    
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager instance;

        [SerializeField] GameObject player;
        [SerializeField] GameObject spawnManager;
        [SerializeField] InterfaceManager uiManager;

        ScoreManager _score;

        public SaveData Data { get; set; }

        private void Awake()
        {
            if (instance == null)
                instance = this;


            _score = FindObjectOfType<ScoreManager>();


        }



    

    }

}