using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { MENU, GAME, LEVEL_COMPLETE, GAME_OVER }

    private GameState currentState;

    public static Action<GameState> onGameStateChanged;

    private void Awake() {
        if(Instance == null) { Instance = this; }
        else Destroy(this.gameObject);
    }

    public void SetGameState(GameState gameState) { 
        currentState = gameState;
        onGameStateChanged?.Invoke(gameState);
    }

    public bool IsGameState() {
        return currentState == GameState.GAME; 
    }
}
