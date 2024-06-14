using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using static StateHandler;

/// <summary>
/// Class that saves and retrieves the infromation of the game to the device.
/// </summary>
public class GameInformationSaver : MonoBehaviour
{
    /// <summary>
    /// The difficulty dropdown, used to retrieve a difficulty class based on a name.
    /// </summary>
    [SerializeField] private DifficultyDropdown difficultyDropdown;
    private string directoryPath;

    void Start()
    {
        directoryPath = Path.Combine(Application.persistentDataPath, "SaveData.txt");
        RetreiveData();
        StateHandler.OnStateSwitch.Invoke(StateHandler.GameStates.NoState, StateHandler.GameStates.MainMenu);
        StateHandler.OnStateSwitch.AddListener(OnStateSwitch);
    }

    /// <summary>
    /// Called when the state machine switches states. Based on which state the old state is will alow us to save specific infromation.
    /// </summary>
    /// <param name="pOldState">Specific state that the game was in</param>
    /// <param name="pNewState">Specific state that the game enters</param>
    private void OnStateSwitch(GameStates pOldState, GameStates pNewState)
    {
        //If the game just left the main menu we will save the name and selected difficulty for the user to go through the main screen quickly the next time
        if(pOldState == GameStates.MainMenu)
        {
            PlayerInformation.SaveGameInformation.LastFilledInName = PlayerInformation.Name;
            PlayerInformation.SaveGameInformation.LastSelectedDifficultyName = PlayerInformation.SelectedDifficulty.name;
            SaveInformation();
        }
        //If the game just left the game screen we save the score to the highscore list.
        if(pOldState == GameStates.GameScreen)
        {
            PlayerInformation.SaveGameInformation.AddItemToHighscore(PlayerInformation.Name, PlayerInformation.Score, PlayerInformation.SelectedDifficulty.name);
            SaveInformation();
        }
    }

    /// <summary>
    /// Function to take the current information 
    /// </summary>
    public void SaveInformation()
    {
        //Convert all savegameinformation to a json
        string _saveInformationJsonFormat = JsonConvert.SerializeObject(PlayerInformation.SaveGameInformation);
        
        //If there is no file yet create it and then save the information into the file
        //ToImprove: encrypt infromation before saving. At the moment no personal data has been saved but if it would be this would be an issue.
        if(!File.Exists(directoryPath))
        {
            StreamWriter _file = File.CreateText(directoryPath);
            _file.Write(_saveInformationJsonFormat);
            _file.Close();
        }

        //Save information to file
        //ToImprove: Put this in an else
        File.WriteAllText(directoryPath, _saveInformationJsonFormat);
    }

    /// <summary>
    /// Take the saved data and apply it to the player information.
    /// </summary>
    public void RetreiveData()
    {
        //If there is no file yet make sure there is some SaveGameInformation. This is expected to never be null. 
        if (!File.Exists(directoryPath)) 
        {
            PlayerInformation.SaveGameInformation = new SaveGameInformation();
            return; 
        }

        //Read the file and deserialize object from json.
        string _savedInformation = File.ReadAllText(directoryPath);
        SaveGameInformation _savedDataInClass = JsonConvert.DeserializeObject<SaveGameInformation>(_savedInformation);
        
        //Apply information to the playerinformation.
        PlayerInformation.Name = _savedDataInClass.LastFilledInName;
        PlayerInformation.SelectedDifficulty = difficultyDropdown.GetDifficultyClassOnName(_savedDataInClass.LastSelectedDifficultyName);
        PlayerInformation.SaveGameInformation = _savedDataInClass;
    }
}
