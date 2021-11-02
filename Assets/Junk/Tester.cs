using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mobile_Core;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(GameManager.Instance.appState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.appState = AppStates.APP_UPDATE;
            print(GameManager.Instance.appState);
        }
    }
}
