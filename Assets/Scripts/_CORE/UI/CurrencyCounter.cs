using System.Collections;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using Mobile_Core;

namespace Mobile_UI
{
    public class CurrencyCounter : MonoBehaviour
    {
        [SerializeField]
        [Required]
        TextMeshProUGUI currencyTxt;

        [SerializeField] AnimationCurve txtScaleModifier;

        WaitForSecondsRealtime _waitDelay = new WaitForSecondsRealtime(0.05f);

        private void OnEnable()
        {
            Wallet.onUpdate += UpdateCurrencyText;
        }

        private void OnDisable()
        {
            Wallet.onUpdate -= UpdateCurrencyText;
        }

        //public void UpdateMoney()
        //{

        //    Wallet.onUpdate?.Invoke(0,50);
        //}


        public void UpdateCurrencyText(int currentAmount, int ammountReceived)
        {
            StartCoroutine(IUpdate(currentAmount, ammountReceived));

        }

        IEnumerator IUpdate(int current, int amount)
        {
            int max = current + amount;


            while (current != max)
            {
                current += 1;

                yield return _waitDelay;

                currencyTxt.SetText($"${current}");

                yield return null;
            }

        }
    }

}