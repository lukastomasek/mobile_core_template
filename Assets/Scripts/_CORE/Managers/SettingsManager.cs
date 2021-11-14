using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;


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

        SaveData data = new SaveData();


        private void Start()
        {
            data = SaveManager.Load();

            if(data == null)
            {
                data.playSound = true;
                data.playMusic = true;
                data.enableHaptic = true;
            }

            if (data.enableHaptic == true)
                hapticsToggle.isOn = true;
            else
                hapticsToggle.isOn = false;

            if (data.playMusic == true)
                musicToggle.isOn = true;
            else
                musicToggle.isOn = false;

            if (data.playSound == true)
                soundToggle.isOn = true;
            else
                soundToggle.isOn = false;
        }



        public void ToggleMusic(Toggle toggle)
        {
            if (toggle.isOn)
            {
                data.playMusic = true;
            }
            else
            {
                data.playMusic = false;
            }

            SaveManager.Save(data);
        }

        public void ToggleSoundFx(Toggle toggle)
        {
            if (toggle.isOn)
            {
                data.playSound = true;

            }
            else
            {
                data.playSound = false;
            }

            SaveManager.Save(data);
        }

        public void ToggleHaptics(Toggle toggle)
        {
            if (toggle.isOn)
            {
                data.enableHaptic = true;
            }
            else
            {
                data.enableHaptic = false;
            }

            SaveManager.Save(data);
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
