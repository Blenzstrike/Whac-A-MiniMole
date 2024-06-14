using UnityEngine;
using static StateHandler;

/// <summary>
/// Base class for game state classes. 
/// </summary>
public abstract class GameState : MonoBehaviour
{
    /// <summary>
    /// This states what type of state this is.
    /// </summary>
    [HideInInspector] public GameStates SpecificGameState;

    protected virtual void Awake()
    {
        StateHandler.OnStateSwitch.AddListener(OnStateSwitch);
        OnExitThisState();
    }

    /// <summary>
    /// This will call the correct funtion based on if it is exiting this state, entering this state or neither.
    /// </summary>
    /// <param name="pOldState">State that the game is exiting.</param>
    /// <param name="pNewState">State that the game enters.</param>
    protected void OnStateSwitch(GameStates pOldState, GameStates pNewState)
    {
        if(pOldState == SpecificGameState) { OnExitThisState(); }
        if(pNewState == SpecificGameState) { OnEnterThisState(); }
    }

    protected abstract void OnExitThisState();
    protected abstract void OnEnterThisState();
}
