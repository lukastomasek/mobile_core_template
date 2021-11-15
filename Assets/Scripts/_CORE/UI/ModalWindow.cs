using UnityEngine;
using TMPro;

namespace Mobile_UI
{
    public class ModalWindow : MonoBehaviour
    {
        [SerializeField] GameObject modalWindow;
        [SerializeField] TextMeshProUGUI header;
        [SerializeField] TextMeshProUGUI body;

        public static ModalWindow instance;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }


        public void ShowModal(string header, string body)
        {
            this.header.text = header;
            this.body.text = body;

            modalWindow.SetActive(true);
        }

        public void HideModal() => modalWindow.SetActive(false);

    }
}