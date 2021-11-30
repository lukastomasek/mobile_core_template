using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Mobile_Core
{
    /// <summary>
    ///  modular scene loader
    /// </summary>

    public class SceneLoader : SingeltonTemplate<SceneLoader>
    {
        AsyncOperation _asyncOperation;
        float _loadingTimer = 0f;

        protected SceneLoader() { }


        public void LoadScene(int id, GameObject loadingBackground, Image loadingProgress, TMPro.TextMeshProUGUI loadingTxt)
        {
            StartCoroutine(ILoadLevel(id, loadingBackground, loadingProgress, loadingTxt));
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        IEnumerator ILoadLevel(int id, GameObject loadingBackground, Image loadingProgress, TMPro.TextMeshProUGUI loadingTxt)
        {
            _asyncOperation = SceneManager.LoadSceneAsync(id, LoadSceneMode.Single);

            if (_asyncOperation == null)
            {
                Debug.LogError($"missing scene: {_asyncOperation}");

                yield break;
            }

            // show loading screen
            loadingBackground.SetActive(true);

            while (!_asyncOperation.isDone)
            {
                _loadingTimer = _asyncOperation.progress / 0.9f;
                // show loading progress
                loadingTxt.SetText($"loading({_loadingTimer}%)");
                loadingProgress.fillAmount = Mathf.MoveTowards(0, _loadingTimer, _loadingTimer);

                yield return null;
            }
        }
    }

}