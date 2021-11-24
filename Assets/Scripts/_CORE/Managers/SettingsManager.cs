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
        [Header("TOGGLES")]
        [SerializeField] Toggle musicToggle;
        [SerializeField] Toggle soundToggle;
        [SerializeField] Toggle hapticsToggle;

        MainMenu _main;
        SaveData _data;

        //public static Action<bool> changeMusicSettings;
        //public static Action<bool> changeSoundSettings;


        private void Start()
        {
            _main = MainMenu.instance;
            _data = _main.GetData();

            if (_data == null)
            {
                _data.playSound = true;
                _data.playMusic = true;
                _data.enableHaptic = true;
            }

            if (_data.enableHaptic == true)
                hapticsToggle.isOn = true;
            else
                hapticsToggle.isOn = false;

            if (_data.playMusic == true)
                musicToggle.isOn = true;
            else
                musicToggle.isOn = false;

            if (_data.playSound == true)
                soundToggle.isOn = true;
            else
                soundToggle.isOn = false;

            //changeMusicSettings(musicToggle.isOn);
            //changeSoundSettings(soundToggle.isOn);

            //Debug.Log($"music is: {_data.playMusic}");
            //Debug.Log($"sound is: {_data.playSound}");
        }



        public void ToggleMusic(Toggle toggle)
        {
            if (toggle.isOn)
            {
                _data.playMusic = true;
            }
            else
            {
                _data.playMusic = false;
            }

            //SaveManager.Save(_data);
            //changeMusicSettings(toggle.isOn);
        }

        public void ToggleSoundFx(Toggle toggle)
        {
            if (toggle.isOn)
            {
                _data.playSound = true;

            }
            else
            {
                _data.playSound = false;
            }

            //SaveManager.Save(_data);
            //changeSoundSettings(toggle.isOn);

        }

        public void ToggleHaptics(Toggle toggle)
        {
            if (toggle.isOn)
            {
                _data.enableHaptic = true;
            }
            else
            {
                _data.enableHaptic = false;
            }

            //SaveManager.Save(_data);
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
