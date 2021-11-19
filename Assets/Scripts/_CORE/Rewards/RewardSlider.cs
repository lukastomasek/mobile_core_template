using UnityEngine;

namespace Mobile_Rewards
{
    public class RewardSlider : MonoBehaviour
    {
        [HideInInspector] public bool moveToOppositeDir;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Green"))
            {
                moveToOppositeDir = true;
            }
        }


    }

}