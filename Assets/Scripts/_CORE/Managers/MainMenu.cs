using UnityEngine;
using TMPro;
using Mobile_UI;

namespace Mobile_Core
{
    /// <summary>
    /// logic of main menu : open/close UI tabs, show progress, load next scenes
    /// </summary>
    public class MainMenu : MonoBehaviour
    {

        public static MainMenu instance;

        [SerializeField] TextMeshProUGUI coinsTxt;

        SaveData _data = new SaveData();

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);


            _data = SaveManager.Load();


            if (_data != null)
            {
                coinsTxt.SetText($"${_data.playerCurrency}");
            }
            else
            {
                coinsTxt.SetText($"${0}");
            }

        }

        public SaveData GetData() => _data;


        public void OpenPanel(GameObject panel)
        {
            if (!panel.activeInHierarchy)
            {
                panel.SetActive(true);
            }
        }

        // TESTING
        public void ModalMessage()
        {
            ModalWindow.instance.ShowModal("CANNOT ADD MONEY", "Error Adding Money, please try again later!");
        }

    }

}