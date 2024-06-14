using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static StateHandler;

public class EndScreen : GameState
{
    [SerializeField] private Button ContinueButton;

    protected override void Awake()
    {
        SpecificGameState = GameStates.EndScreen;
        base.Awake();
    }
    protected override void OnEnterThisState()
    {
        gameObject.SetActive(true);
        ContinueButton.onClick.AddListener(OnContinuePress);
    }

    protected override void OnExitThisState()
    {
        ContinueButton.onClick.RemoveListener(OnContinuePress);
        PlayerInformation.Score = 0;
        gameObject.SetActive(false);
    }

    private void OnContinuePress()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.EndScreen, GameStates.HighScore);
    }
}
