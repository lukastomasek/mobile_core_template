using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mobile_UI;
using NaughtyAttributes;

namespace Mobile_Core
{
    /// <summary>
    /// logic of main menu : open/close UI tabs, show progress, load next scenes
    /// </summary>
    public class MainMenu : MonoBehaviour
    {

        public static MainMenu instance;

        [HorizontalLine(color: EColor.Yellow)]
        [Header("UI/TEXT")]
        [SerializeField] TextMeshProUGUI coinsTxt;

        [Space(10)]
        [HorizontalLine(color: EColor.Red)]
        [Header("UI/LOADING SCREEN")]
        [SerializeField] GameObject loadingBackground;
        [SerializeField] Image loadingProgressImage;
        [SerializeField] TextMeshProUGUI loadingTxt;

        SaveData _data = new SaveData();


        AppState _currentAppState;

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

        // test
        public void LoadLevel()
        {
            int level = 1;

            SceneLoader.Instance.LoadScene(level, loadingBackground,
                loadingProgressImage, loadingTxt
                );
        }

        public void PauseState()
        {
            AppManager.Instance.UpdateAppState(AppState.PAUSE);
        }

        public void UpdateState()
        {
            AppManager.Instance.UpdateAppState(AppState.UPDATE);
        }


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