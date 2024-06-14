using UnityEngine;
using static StateHandler;

/// <summary>
/// State class for the Game screen.
/// </summary>
public class GameScreen : GameState
{
    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private TimeHandler timeHandler;
    private DifficultyClass selectedDifficulty;
    private MoleObjectSpawner currentMoleObject;

    protected override void Awake()
    {
        SpecificGameState = GameStates.GameScreen;
        base.Awake();
    }
    protected override void OnEnterThisState()
    {
        gameObject.SetActive(true);
        selectedDifficulty = PlayerInformation.SelectedDifficulty;
        SpawnHoles();
        timeHandler.OnGameStop.AddListener(OnGameStop);
    }

    protected override void OnExitThisState()
    {
        Destroy(currentMoleObject?.gameObject);
        gameObject.SetActive(false);
        timeHandler.OnGameStop.RemoveListener(OnGameStop);
    }

    /// <summary>
    /// Starts the holespawner to create the holes from which the moles will spring. 
    /// </summary>
    public void SpawnHoles()
    {
        //Create the holes required and gets the newly created mole object spawner.
        currentMoleObject = holeSpawner.SpawnHoles(selectedDifficulty.HoleLayout).GetComponent<MoleObjectSpawner>();
        //Set the difficulty specific infromation to the MoleSpawner.
        currentMoleObject.SetSpawnData(selectedDifficulty.ObjectSpawnSpeedMultiplier, selectedDifficulty.MoleObjects);
        currentMoleObject.IsSpawning = true;
    }

    private void OnGameStop()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.GameScreen, GameStates.EndScreen);
    }

}
