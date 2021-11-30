using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using System;

namespace Mobile_Core
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] string privacyPolicyLink;

        [HorizontalLine(color: EColor.Red)]
        [Header("Icons")]
        [SerializeField] Image musicIcon;
        [SerializeField] Image soundIcon;
        [SerializeField] Image hapticsIcon;

        [Header("Sprites")]
        [HorizontalLine(color: EColor.Blue)]
        [SerializeField] Sprite musicOnSpr;
        [SerializeField] Sprite musicOffSpr;
        [SerializeField] Sprite soundOnSpr;
        [SerializeField] Sprite soundOffSpr;
        [SerializeField] Sprite hapticsOnSpr;
        [SerializeField] Sprite hapticsOffSpr;

        public static Action<bool> UpdateMusicState;
        public static Action<bool> UpdateSoundState;
        public static Action<bool> UpdateHapticsState;


        public bool MusicState { get; private set; } = true;
        public bool SoundState { get; private set; } = true;
        public bool HapticState { get; private set; } = true;


        SaveData _data = new SaveData();


        private void Start()
        {
            
            LoadSettingStates();
        }


        void LoadSettingStates()
        {
            var active = "#FFFFFF";
            var deactivated = "#A4A4A4";

            Color activeCol;
            Color deactivatedCol;

            if (_data == null || !SaveManager.fileExist)
            {
                _data.playSound = true;
                _data.playMusic = true;
                _data.enableHaptic = true;
            }
            else
            {
                MusicState = _data.playMusic;
                SoundState = _data.playSound;
                HapticState = _data.enableHaptic;


                UpdateMusicState?.Invoke(MusicState);
                UpdateSoundState?.Invoke(SoundState);
                UpdateHapticsState?.Invoke(HapticState);
            }

            if (_data.playMusic)
            {
                musicIcon.sprite = musicOnSpr;
            }
            else
            {
                musicIcon.sprite = musicOffSpr;
            }

            if (_data.playSound)
            {
                soundIcon.sprite = soundOnSpr;
            }
            else
            {
                soundIcon.sprite = soundOffSpr;
            }
            if (_data.enableHaptic)
            {
                if (ColorUtility.TryParseHtmlString(active, out activeCol))
                {
                    hapticsIcon.color = activeCol;
                }
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(deactivated, out deactivatedCol))
                {
                    hapticsIcon.color = deactivatedCol;
                }

            }
        }


        public void ToggleMusic()
        {
            MusicState = !MusicState;

            if (MusicState == true)
            {
                musicIcon.sprite = musicOnSpr;
                _data.playMusic = true;
                UpdateMusicState?.Invoke(true);
            }
            else
            {
                musicIcon.sprite = musicOffSpr;
                _data.playMusic = false;
                UpdateMusicState?.Invoke(false);
            }

            SaveManager.Save(_data);
        }

        public void ToggleSound()
        {
            SoundState = !SoundState;

            if (SoundState == true)
            {
                soundIcon.sprite = soundOnSpr;
                _data.playSound = true;
                UpdateSoundState?.Invoke(true);
            }
            else
            {
                soundIcon.sprite = soundOffSpr;
                _data.playSound = false;
                UpdateSoundState?.Invoke(false);
            }

            SaveManager.Save(_data);
        }

        public void ToggleHaptics()
        {
            HapticState = !HapticState;

            var active = "#FFFFFF";
            var deactivated = "#A4A4A4";

            Color activeCol;
            Color deactivatedCol;

            if (HapticState == true)
            {
                if (ColorUtility.TryParseHtmlString(active, out activeCol))
                {
                    hapticsIcon.color = activeCol;
                }

                _data.enableHaptic = true;
                UpdateHapticsState?.Invoke(true);
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(deactivated, out deactivatedCol))
                {
                    hapticsIcon.color = deactivatedCol;
                }
                _data.enableHaptic = false;
                UpdateHapticsState?.Invoke(false);
            }

            SaveManager.Save(_data);
        }

        [ContextMenu("Rest Settings")]
        public void ResetSettings()
        {
            _data.playMusic = true;
            _data.playSound = true;
            _data.enableHaptic = true;

            SaveManager.Save(_data);

            Debug.Log("<b> Resseting Settings! </b>");
        }



        public void OpenCreditPanel(GameObject panel)
        {
            if (!panel.activeInHierarchy)
                panel.SetActive(true);
        }


        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

        public void OpenPrivacySettings() => Application.OpenURL(privacyPolicyLink);

        public void RestorePurchases()
        {

        }
    }

}
