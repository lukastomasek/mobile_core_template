using UnityEngine;
using TMPro;
using System;
using Mobile_Rewards;
using Mobile_UI;

namespace Mobile_Core
{


    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] Rewards score;
        public int maxScore = 60;
        InterfaceManager _uiManager;

        int _currentScore;

        private void Awake()
        {
            GameManager.OnUpdateScore += IncreaseScore;
            _uiManager = FindObjectOfType<InterfaceManager>();
        }

        private void OnDestroy()
        {
            GameManager.OnUpdateScore -= IncreaseScore;
        }


        void IncreaseScore(int score)
        {
            _currentScore += score;
            Debug.Log($"<b> Current score is : {_currentScore} </b>");
            GameManager.OnUpdateUI?.Invoke(score);

            if (_currentScore == maxScore)
            {
                GameManager.instance.UpdateGameState(GameState.VICTORY);
            }
        }


        public void GetScore()
        {
            Wallet.AddMoney(_currentScore);

            _uiManager.UpdateWallet(_currentScore);
        }

        public void GetDoubleReward()
        {
            _currentScore *= 2;
            Wallet.AddMoney(_currentScore);
            _uiManager.UpdateWallet(_currentScore);
        }

        public void GetBoostedReward()
        {
            RewardSlider booster = FindObjectOfType<RewardSlider>();

            if (booster != null)
            {
                _currentScore += booster.GetRewardBooster;
                //GameManager.OnUpdateUI?.Invoke(_currentScore);

            }
        }


        public int TotalScore()
        {
            return _currentScore;
        }

    }
}