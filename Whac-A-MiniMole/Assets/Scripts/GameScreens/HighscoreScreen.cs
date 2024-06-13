using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static StateHandler;

public class HighscoreScreen : GameState
{
    [SerializeField] private Button ContinueButton;
    [SerializeField] private HighscoreList EasyHighscoreList;
    [SerializeField] private HighscoreList MediumHighscoreList;
    [SerializeField] private HighscoreList HardHighscoreList;

    protected override void Awake()
    {
        SpecificGameState = GameStates.HighScore;
        base.Awake();
    }

    protected override void OnEnterThisState()
    {
        gameObject.SetActive(true);
        ContinueButton.onClick.AddListener(OnContinuePress);
        CreateAndSetHighScoreLists();
    }

    protected override void OnExitThisState()
    {
        ContinueButton.onClick.RemoveListener(OnContinuePress);
        EasyHighscoreList.ClearHighscore();
        MediumHighscoreList.ClearHighscore();
        HardHighscoreList.ClearHighscore();
        gameObject.SetActive(false);
    }

    private void OnContinuePress()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.HighScore, GameStates.MainMenu);
    }

    private void CreateAndSetHighScoreLists()
    {
        List<SavedHighscoreItem> _savedHighscoreList = PlayerInformation.SaveGameInformation.SavedHighscoreItems;
        List<(string, string)> _easyHighscoreList = new List<(string, string)>();
        List<(string, string)> _mediumHighscoreList = new List<(string, string)>();
        List<(string, string)> _hardHighscoreList = new List<(string, string)>();

        foreach(SavedHighscoreItem _highScoreItem in _savedHighscoreList)
        {
            switch (_highScoreItem.DifficultyName)
            {
                case "Easy":
                    _easyHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
                case "Medium":
                    _mediumHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
                case "Hard":
                    _hardHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
            }
        }

        EasyHighscoreList.SetHighscoreLists(_easyHighscoreList);
        MediumHighscoreList.SetHighscoreLists(_mediumHighscoreList);
        HardHighscoreList.SetHighscoreLists(_hardHighscoreList);
    }
}
