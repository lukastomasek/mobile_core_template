using UnityEngine;
using TMPro;
using System;
using Mobile_Rewards;

namespace Mobile_Core
{


    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] Rewards score;


        public static Action OnWon;
        public static Action<int> OnUpdateScore;
        public static Action<int> OnPlayerUIUpdate;

        int _currentScore;


        public void IncreaseScore(int score)
        {
            _currentScore += score;
            Debug.Log($"<b> Current score is : {_currentScore} </b>");
        }

        public void GetDoubleReward()
        {
            _currentScore *= 2;
            OnPlayerUIUpdate.Invoke(_currentScore);
        }

        public void GetBoostedReward()
        {
            RewardSlider booster = FindObjectOfType<RewardSlider>();

            if (booster != null)
            {
                _currentScore += booster.GetRewardBooster;
                OnPlayerUIUpdate?.Invoke(_currentScore);
            }
        }


        public int TotalScore()
        {
            return _currentScore;
        }

    }
}