using UnityEngine;

namespace Mobile_Social
{
    public class SocialMediaLinker : MonoBehaviour
    {
        [Header("URLS")]
        [SerializeField] string facebookURL;
        [SerializeField] string instagramURL;
        [SerializeField] string twitterURL;
        [SerializeField] string websiteURL;
        [SerializeField] string privacyURL;
        [SerializeField] string discordURL;


        public void OpenFacebook() => Application.OpenURL(facebookURL);

        public void OpenInstagram() => Application.OpenURL(instagramURL);

        public void OpenTwitter() => Application.OpenURL(twitterURL);

        public void OpenWebsite() => Application.OpenURL(websiteURL);

        public void OpenPrivacy() => Application.OpenURL(privacyURL);

        public void OpenDiscrod() => Application.OpenURL(discordURL);

    }

}