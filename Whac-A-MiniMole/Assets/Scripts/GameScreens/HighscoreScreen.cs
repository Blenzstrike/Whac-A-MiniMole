using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StateHandler;

/// <summary>
/// State class for the Highscore screen.
/// </summary>
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

    /// <summary>
    /// Takes the saved highscore list and defides it into list for each difficulity.
    /// </summary>
    private void CreateAndSetHighScoreLists()
    {
        List<SavedHighscoreItem> _savedHighscoreList = PlayerInformation.SaveGameInformation.SavedHighscoreItems;
        List<(string, string)> _easyHighscoreList = new List<(string, string)>();
        List<(string, string)> _mediumHighscoreList = new List<(string, string)>();
        List<(string, string)> _hardHighscoreList = new List<(string, string)>();

        //Go through each item and put it in the corrosponding list. The earlier the score is in the list the higher the score is.
        foreach(SavedHighscoreItem _highScoreItem in _savedHighscoreList)
        {
            switch (_highScoreItem.DifficultyName)
            {
                case "EasyDifficulty":
                    _easyHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
                case "MediumDifficulty":
                    _mediumHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
                case "HardDifficulty":
                    _hardHighscoreList.Add((_highScoreItem.Name, _highScoreItem.Score.ToString()));
                    break;
            }
        }

        EasyHighscoreList.SetHighscoreLists(_easyHighscoreList);
        MediumHighscoreList.SetHighscoreLists(_mediumHighscoreList);
        HardHighscoreList.SetHighscoreLists(_hardHighscoreList);
    }
}
