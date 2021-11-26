using UnityEngine;
using UnityEngine.Purchasing;

namespace Mobile_Core
{
    public class IAPHandler : MonoBehaviour
    {
        [Header("BUTTONS")]
        [SerializeField] GameObject restoreBtn;


        [Header("PRODUCTS")]
        [SerializeField] string noAdsProductsId;


        private void Awake()
        {
            DisableRestoreButton();
        }

        public void OnPurchaseComplete(Product product)
        {
            if (product.definition.id == noAdsProductsId)
            {
                // remove ads
                // play purchase sound
                // remove no ads button
                // send notifcation to user for purchase
            }
        }


        void DisableRestoreButton()
        {
            if (Application.platform != RuntimePlatform.IPhonePlayer)
            {
                if (restoreBtn != null)
                    restoreBtn.SetActive(false);
            }
        }

    }



}