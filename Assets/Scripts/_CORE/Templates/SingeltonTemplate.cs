using UnityEngine;

namespace Mobile_Core
{
    public class SingeltonTemplate<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _shuttingDown = false;
        private static object _lock = new object();
        private static T _instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        ///

        public static T Instance
        {
            get
            {
                if (_shuttingDown)
                {
                    Debug.LogWarning($"[Singelton] instance{typeof(T)} is destroyed, returning null");
                    return null;
                }
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        // search for exisitng instance
                        _instance = (T)FindObjectOfType(typeof(T));

                        // create new instance if doesn't already exist

                        if (_instance == null)
                        {
                            GameObject singelton = new GameObject();
                            _instance = singelton.AddComponent<T>();
                            singelton.name = typeof(T).ToString() + "(Singelton)";

                            DontDestroyOnLoad(singelton);
                        }
                    }

                    return _instance;
                }
            }

        }

        private void OnApplicationQuit() => _shuttingDown = true;

        //lprivate void OnDestroy() => _shuttingDown = true;


    }

}