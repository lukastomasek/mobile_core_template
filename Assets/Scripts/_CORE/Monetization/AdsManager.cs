using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Networking;
using System;
using System.Collections;
using NaughtyAttributes;
using Mobile_Gameplay;

namespace Mobile_Core
{
    public class AdsManager : SingeltonTemplate<AdsManager>, IUnityAdsListener
    {

        public AdsManager() { }

        public static Action OnSkipableAdFinsihed;
        public static Action OnRewardedAdFinished;


        public bool OnWifiConnected { get; private set; } = false;
        public static Action<bool> OnWifiConnector;


        public bool showAds = true;

        [Header("REWARDS")]
        [SerializeField] Rewards rewardOptions;


        [Header("TEST MODE")]
        [HorizontalLine(color: EColor.Red)]
        [InfoBox("Disable Test Mode for Final Build", EInfoBoxType.Normal)]
        [SerializeField] bool testMode = true;


        [Header("IDS")]
        [Space]
        [HorizontalLine(color: EColor.Blue)]
        [SerializeField] string IOS_GAME_ID;
        [SerializeField] string GOOGLE_PLAY_ID;

        public bool PlayableAdFinished { get; set; } = false;

        const string BANNER_ID = "banner";
        const string REWARED_VIDEO_ID = "rewardedVideo";
        const string PLAYABLE_VIDEO_ID = "video";

        AudioSource[] _audios;

        IEnumerator Start()
        {
#if UNITY_IOS
            Advertisement.Initialize(IOS_GAME_ID, testMode);
#else
            Advertisement.Initialize(GOOGLE_PLAY_ID, testMode);

#endif

            StartCoroutine(ICheckConnection((isConnected) =>
            {
                if (isConnected)
                {
                    Debug.Log("<color=green> Device connected to wifi! </color>");

                    OnWifiConnected = true;
                    OnWifiConnector?.Invoke(OnWifiConnected);

                }
                else
                {
                    Debug.LogWarning("Device is not connected to wifi!");

                    OnWifiConnected = false;
                    OnWifiConnector?.Invoke(OnWifiConnected);

                }

            }));

            while (!Advertisement.IsReady())
                yield return null;

            Advertisement.AddListener(this);

            if (showAds)
            {
                Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
                Advertisement.Banner.Show(BANNER_ID);

                AudioPlaying(false);
            }
        }

        public void ShowInterstitialAd()
        {
            if (showAds == false)
            {
                OnSkipableAdFinsihed?.Invoke();

                return;
            }
            if (!Advertisement.isInitialized)
            {
                OnSkipableAdFinsihed?.Invoke();

                return;
            }

            if (Advertisement.IsReady(PLAYABLE_VIDEO_ID))
            {
                PlayableAdFinished = false;
                Advertisement.Show(PLAYABLE_VIDEO_ID);

            }
        }


        public void ShowRewardedVideo()
        {
            if (showAds == false)
            {
                OnRewardedAdFinished?.Invoke();

                return;
            }
            if (!Advertisement.isInitialized)
            {
                OnSkipableAdFinsihed?.Invoke();

                return;
            }

            if (Advertisement.IsReady(REWARED_VIDEO_ID))
            {
                Advertisement.Show(REWARED_VIDEO_ID);
                AudioPlaying(false);
            }
        }

        public void OnUnityAdsDidError(string message)
        {
            Debug.LogError(message);
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (placementId == PLAYABLE_VIDEO_ID)
            {
                // reset
                GameplayManager.instance.Data.adsPerLevelCounter = 0;

                OnSkipableAdFinsihed?.Invoke();

                Debug.Log("Load next level after ad");
            }



            if (showResult == ShowResult.Finished)
            {
                AudioPlaying(true);

                Debug.Log("Reward Player");

                if (placementId == REWARED_VIDEO_ID)
                {
                    switch (SessionManager.Instance.rewardType)
                    {
                        case EREWARD_TYPE.COINS:
                            Wallet.AddMoney(10);
                            Wallet.onUpdate?.Invoke(Wallet.currentAmount, 10);
                            break;

                        case EREWARD_TYPE.DOUBLE_COINS:
                            Wallet.AddMoney(20);
                            Wallet.onUpdate?.Invoke(Wallet.currentAmount, 20);
                            break;

                        case EREWARD_TYPE.CHEST:
                            // open chest
                            break;
                    }
                }

            }
            else if (showResult == ShowResult.Skipped)
            {
                AudioPlaying(true);
                Debug.Log($"<b>Ad was skipped </b>");
            }
            else if (showResult == ShowResult.Failed)
            {
                AudioPlaying(true);
                Debug.Log($"<b> ad failed to load: {placementId} </b>");
            }
        }

        public void OnUnityAdsDidStart(string placementId)
        {

        }

        public void OnUnityAdsReady(string placementId)
        {

        }



        IEnumerator ICheckConnection(Action<bool> isConnected)
        {
            using (UnityWebRequest url = UnityWebRequest.Get("http://google.com"))
            {
                yield return url.SendWebRequest();

                if (url.result == UnityWebRequest.Result.Success)
                {
                    isConnected(true);
                }
                else if (url.result == UnityWebRequest.Result.ConnectionError ||
                  url.result == UnityWebRequest.Result.ProtocolError)
                {
                    isConnected(false);
                    Debug.LogError(url.error);
                }
            }


        }


        void AudioPlaying(bool mute)
        {
            _audios = FindObjectsOfType<AudioSource>();

            if (mute)
            {
                if (_audios.Length > 0)
                {
                    foreach (var a in _audios)
                        a.mute = false;
                }
            }
            else
            {
                if (_audios.Length > 0)
                {
                    foreach (var a in _audios)
                        a.mute = true;
                }
            }
        }

        void OnDestroy() => Advertisement.RemoveListener(this);

    }


}