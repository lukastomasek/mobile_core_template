using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif

namespace Mobile_Social
{
    public class Rating : MonoBehaviour
    {

        [SerializeField] string googlePlayStore_url;
        [SerializeField] GameObject ratePanel;

        public void RateNow()
        {
#if UNITY_IOS
            Device.RequestStoreReview();
#else
            Application.OpenURL(googlePlayStore_url);
            
#endif


        }

        public void CloseRatePanel()
        {
            ratePanel.SetActive(false);
        }

        public void RateLater()
        {
            ratePanel.SetActive(false);
        }

    }

}