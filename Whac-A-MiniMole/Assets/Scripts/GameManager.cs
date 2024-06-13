using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private DifficultyDropdown difficultyDropdown;
    private DifficultyClass selectedDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.OnStartGame.AddListener(StartGame);
    }

    private void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
        selectedDifficulty = difficultyDropdown.CurrentDifficultyClass;
        
        holeSpawner.SpawnHoles(selectedDifficulty.AmountOfHoles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
