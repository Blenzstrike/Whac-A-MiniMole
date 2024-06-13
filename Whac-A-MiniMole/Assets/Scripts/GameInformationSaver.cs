using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static StateHandler;


public class GameInformationSaver : MonoBehaviour
{
    private string directoryPath;
    [SerializeField] private DifficultyDropdown difficultyDropdown;

    // Start is called before the first frame update
    void Start()
    {
        directoryPath = Path.Combine(Application.persistentDataPath, "SaveData.txt");
        RetreiveData();
        StateHandler.OnStateSwitch.Invoke(StateHandler.GameStates.NoState, StateHandler.GameStates.MainMenu);
        StateHandler.OnStateSwitch.AddListener(OnStateSwitch);
    }

    private void OnStateSwitch(GameStates pOldState, GameStates pNewState)
    {
        if(pOldState == GameStates.MainMenu)
        {
            PlayerInformation.SaveGameInformation.LastFilledInName = PlayerInformation.Name;
            PlayerInformation.SaveGameInformation.LastSelectedDifficultyName = PlayerInformation.SelectedDifficulty.name;
            SaveInformation();
        }
        if(pOldState == GameStates.GameScreen)
        {
            PlayerInformation.SaveGameInformation.AddItemToHighscore(PlayerInformation.Name, PlayerInformation.Score, PlayerInformation.SelectedDifficulty.name);
            SaveInformation();
        }
    }

    public void SaveInformation()
    {
        string _saveInformationJsonFormat = JsonConvert.SerializeObject(PlayerInformation.SaveGameInformation);
        if(!File.Exists(directoryPath))
        {
            StreamWriter _file = File.CreateText(directoryPath);
            _file.Write(_saveInformationJsonFormat);
            _file.Close();
        }

        File.WriteAllText(directoryPath, _saveInformationJsonFormat);
    }

    public void RetreiveData()
    {
        if (!File.Exists(directoryPath)) 
        {
            PlayerInformation.SaveGameInformation = new SaveGameInformation();
            return; 
        }
        string _savedInformation = File.ReadAllText(directoryPath);
        SaveGameInformation _savedDataInClass = JsonConvert.DeserializeObject<SaveGameInformation>(_savedInformation);
        PlayerInformation.Name = _savedDataInClass.LastFilledInName;
        PlayerInformation.SelectedDifficulty = difficultyDropdown.GetDifficultyClassOnName(_savedDataInClass.LastSelectedDifficultyName);
        PlayerInformation.SaveGameInformation = _savedDataInClass;
    }
}
