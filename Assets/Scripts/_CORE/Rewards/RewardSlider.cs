using UnityEngine;
using Mobile_Core;
using System;

namespace Mobile_Rewards
{
    public class RewardSlider : MonoBehaviour
    {
        [HideInInspector] public bool moveToOppositeDir;

        public int GetRewardBooster { get; private set; }


        public static Action<int> OnRewardChanged;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagManager.GREEN_BAR))
            {
                moveToOppositeDir = true;
                GetRewardBooster = 2;
                OnRewardChanged?.Invoke(GetRewardBooster);
            }
            if (collision.CompareTag(TagManager.YELLOW_BAR))
            {
                GetRewardBooster = 3;
                OnRewardChanged?.Invoke(GetRewardBooster);
            }
            if (collision.CompareTag(TagManager.ORANGE_BAR))
            {
                GetRewardBooster = 4;
                OnRewardChanged?.Invoke(GetRewardBooster);
            }
            if (collision.CompareTag(TagManager.RED_BAR))
            {
                GetRewardBooster = 5;
                OnRewardChanged?.Invoke(GetRewardBooster);
            }
        }



    }

}