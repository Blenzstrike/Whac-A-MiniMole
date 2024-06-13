using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public static class StateHandler
{
    public enum GameStates
    {
        MainMenu,
        ExplenationScreen,
        GameScreen,
        EndScreen,
        HighScore,
        NoState
    }

    public static UnityEvent<GameStates, GameStates> OnStateSwitch = new UnityEvent<GameStates, GameStates>();
    
}
