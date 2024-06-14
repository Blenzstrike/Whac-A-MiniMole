using UnityEngine;
using UnityEngine.UI;
using static StateHandler;

/// <summary>
/// State class for the Main menu screen.
/// </summary>
public class MainMenu : GameState
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private DifficultyDropdown difficultyDropdown;

    protected override void Awake()
    {
        SpecificGameState = GameStates.MainMenu;
        base.Awake();
    }

    protected override void OnEnterThisState()
    {
        gameObject.SetActive(true);
        startGameButton.onClick.AddListener(OnStartGamePress);
    }

    protected override void OnExitThisState()
    {
        PlayerInformation.SelectedDifficulty = difficultyDropdown.CurrentDifficultyClass;
        startGameButton.onClick.RemoveListener(OnStartGamePress);
        gameObject.SetActive(false);
    }

    private void OnStartGamePress()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.MainMenu, GameStates.ExplenationScreen);
    }
}
