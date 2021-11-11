using UnityEngine;
using TMPro;
using System;

namespace Mobile_Core
{

    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] Rewards score;
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] TextMeshProUGUI currencyTxt;

        public static Action OnWon;

        int _currentScore;

       
        private void Start()
        {

            Wallet.Load();
             
            Debug.Log(Wallet.currentAmount);

            currencyTxt.SetText($"${Wallet.currentAmount}");
        }

        public void IncreaseScore()
        {
            _currentScore += score.basicReward;

            scoreTxt.SetText(_currentScore.ToString());

            if (_currentScore >= 30)
                OnWon?.Invoke();
        }


        public int TotalScore()
        {
            return _currentScore;
        }

    }
}