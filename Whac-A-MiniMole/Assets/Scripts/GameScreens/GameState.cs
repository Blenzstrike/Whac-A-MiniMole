using UnityEngine;
using static StateHandler;

public abstract class GameState : MonoBehaviour
{
    [HideInInspector] public GameStates SpecificGameState;

    protected virtual void Awake()
    {
        StateHandler.OnStateSwitch.AddListener(OnStateSwitch);
        OnExitThisState();
    }

    protected void OnStateSwitch(GameStates pOldState, GameStates pNewState)
    {
        if(pOldState == SpecificGameState) { OnExitThisState(); }
        if(pNewState == SpecificGameState) { OnEnterThisState(); }
    }

    protected abstract void OnExitThisState();
    protected abstract void OnEnterThisState();
}
