using UnityEngine;
using TMPro;

namespace Mobile_Core
{
    /// <summary>
    /// logic of main menu : open/close UI tabs, show progress, load next scenes
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI coinsTxt;


        private void Start()
        {
            SaveData data = new SaveData();

            data = SaveManager.Load();


            if(data != null)
            {
                coinsTxt.SetText($"${data.playerCurrency}");
            }
            else
            {
                coinsTxt.SetText($"${0}");
            }

        }


        public void OpenPanel(GameObject panel)
        {
            if (!panel.activeInHierarchy)
            {
                panel.SetActive(true);
            }
        }
     
    }

}