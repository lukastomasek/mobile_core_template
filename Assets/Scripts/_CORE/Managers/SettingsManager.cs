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


        MainMenu _main;


        private void Start()
        {
            _main = MainMenu.instance;

            LoadSettingStates();
        }


        void LoadSettingStates()
        {
            var active = "#FFFFFF";
            var deactivated = "#A4A4A4";

            Color activeCol;
            Color deactivatedCol;

            if (_main.GetData() == null || !SaveManager.fileExist)
            {
                _main.GetData().playSound = true;
                _main.GetData().playMusic = true;
                _main.GetData().enableHaptic = true;
            }
            else
            {
                MusicState = _main.GetData().playMusic;
                SoundState = _main.GetData().playSound;
                HapticState = _main.GetData().enableHaptic;


                UpdateMusicState?.Invoke(MusicState);
                UpdateSoundState?.Invoke(SoundState);
                UpdateHapticsState?.Invoke(HapticState);
            }

            if (_main.GetData().playMusic)
            {
                musicIcon.sprite = musicOnSpr;
            }
            else
            {
                musicIcon.sprite = musicOffSpr;
            }

            if (_main.GetData().playSound)
            {
                soundIcon.sprite = soundOnSpr;
            }
            else
            {
                soundIcon.sprite = soundOffSpr;
            }
            if (_main.GetData().enableHaptic)
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
                _main.GetData().playMusic = true;
                UpdateMusicState?.Invoke(true);
            }
            else
            {
                musicIcon.sprite = musicOffSpr;
                _main.GetData().playMusic = false;
                UpdateMusicState?.Invoke(false);
            }

            SaveManager.Save(_main.GetData());
        }

        public void ToggleSound()
        {
            SoundState = !SoundState;

            if (SoundState == true)
            {
                soundIcon.sprite = soundOnSpr;
                _main.GetData().playSound = true;
                UpdateSoundState?.Invoke(true);
            }
            else
            {
                soundIcon.sprite = soundOffSpr;
                _main.GetData().playSound = false;
                UpdateSoundState?.Invoke(false);
            }

            SaveManager.Save(_main.GetData());
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

                _main.GetData().enableHaptic = true;
                UpdateHapticsState?.Invoke(true);
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(deactivated, out deactivatedCol))
                {
                    hapticsIcon.color = deactivatedCol;
                }
                _main.GetData().enableHaptic = false;
                UpdateHapticsState?.Invoke(false);
            }

            SaveManager.Save(_main.GetData());
        }

        [ContextMenu("Rest Settings")]
        public void ResetSettings()
        {
            _main.GetData().playMusic = true;
            _main.GetData().playSound = true;
            _main.GetData().enableHaptic = true;

            SaveManager.Save(_main.GetData());

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
