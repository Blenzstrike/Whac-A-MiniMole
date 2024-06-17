using UnityEngine.Events;

/// <summary>
/// Holds the information of the states in the game.
/// </summary>
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
