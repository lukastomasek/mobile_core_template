using UnityEngine;
using Mobile_Rewards;
using Mobile_UI;

namespace Mobile_Core
{


    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] Rewards score;
        public int maxScore = 60;


        int _currentScore = 0;

        private void Awake()
        {
            GameManager.OnUpdateScore += IncreaseScore;

        }

        private void OnDestroy()
        {
            GameManager.OnUpdateScore -= IncreaseScore;
        }


        void IncreaseScore(int score)
        {
            _currentScore += score;

            if (_currentScore == maxScore)
            {
                GameManager.instance.UpdateGameState(GameState.VICTORY);
            }
        }


        public void GetStandardReward()
        {
            Wallet.AddMoney(_currentScore);
            print($"<color=orange> adding money to wallet: ${_currentScore} </color>");
            InterfaceManager.OnUpdatePlayerUI?.Invoke(_currentScore);
        }

        public void GetDoubleReward()
        {
            _currentScore *= 2;

            Wallet.AddMoney(_currentScore);
            print($"<color=orange> adding money to wallet: ${_currentScore} </color>");
            InterfaceManager.OnUpdatePlayerUI?.Invoke(_currentScore);
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