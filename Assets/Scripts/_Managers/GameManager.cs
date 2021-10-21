using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// game manager should control the core system of the application
/// </summary>
///

public enum GameState
{
    APP_START,
    APP_UPDATE,
    APP_PAUSE,
    APP_EXIT

}


public class GameManager : SingeltonTemplate<GameManager>
{

    public GameState gameState;

    protected GameManager() { }

    private void Start()
    {
        gameState = GameState.APP_START;
    }
}
