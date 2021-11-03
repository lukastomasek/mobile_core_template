using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Mobile_Core
{
    /// <summary>
    ///  modular scene loader
    /// </summary>

    public class SceneLoader : MonoBehaviour
    {
        AsyncOperation _asyncOperation;
        float _loadingTimer = 0f;



        public void LoadScene(string id)
        {
            StartCoroutine(ILoadLevel(id));
        }


        IEnumerator ILoadLevel(string id)
        {
            _asyncOperation = SceneManager.LoadSceneAsync(id);

            if(_asyncOperation == null)
            {
                Debug.LogError($"missing scene: {_asyncOperation}");

                yield break;
            }

            while (!_asyncOperation.isDone)
            {
                _loadingTimer = _asyncOperation.progress / 0.9f;

                yield return null;
            }
        }
    }

}