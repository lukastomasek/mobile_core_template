using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mobile_UI;
using NaughtyAttributes;

namespace Mobile_Core
{

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

        [ContextMenu("Reset Wallet")]
        public void ResetWallet() => Wallet.ResetMoney();

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

        private void Start()
        {
            AppManager.Instance.UpdateAppState(AppState.UPDATE);

            // load wallet
            Wallet.Load();
            Debug.Log("current amount in player's save file is:" + _data.playerCurrency);
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

        public void AddMoney(int amount) => Wallet.AddMoney(amount);

    }

}