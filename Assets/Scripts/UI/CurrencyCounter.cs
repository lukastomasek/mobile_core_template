using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

namespace Mobile_UI
{
    public class CurrencyCounter : MonoBehaviour
    {
        [SerializeField]
        [Required]
        TextMeshProUGUI currencyTxt;

        [SerializeField] AnimationCurve txtScaleModifier;

        WaitForSecondsRealtime _waitDelay = new WaitForSecondsRealtime(0.05f);


        private void Update()
        {
            if (Input.GetKey(KeyCode.T))
            {
                UpdateCurrencyText(0, 50);
            }
        }


        public void UpdateCurrencyText(int currentAmount, int ammountReceived)
        {
            StartCoroutine(IUpdate(currentAmount, ammountReceived));
        }

        IEnumerator IUpdate(int current, int amount)
        {
            int max = current + amount;

            //current += 1;

            //yield return new WaitForSecondsRealtime(0.1f);

            //currencyTxt.SetText($"${current}");

            //yield return new WaitForEndOfFrame();

            
          //currencyTxt.rectTransform.localScale = new Vector3((int)txtScaleModifier.Evaluate(1f),(int) txtScaleModifier.Evaluate(1f), 0f);

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