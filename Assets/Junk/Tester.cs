using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(GameManager.Instance.gameState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.gameState = GameState.APP_UPDATE;
            print(GameManager.Instance.gameState);
        }
    }
}
