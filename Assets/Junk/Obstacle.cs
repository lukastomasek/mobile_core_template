using UnityEngine;
using Mobile_Core;
using Mobile_Gameplay;


namespace Mobile_Test
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagManager.PLAYER))
            {
                Debug.Log("<b>GAME OVER</b>");
                GameplayManager.instance.OnGameState(GameStates.GAME_OVER);
            }
        }
    }

}