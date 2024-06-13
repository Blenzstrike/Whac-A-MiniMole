using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static StateHandler;

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

    public void SpawnHoles()
    {
        currentMoleObject = holeSpawner.SpawnHoles(selectedDifficulty.HoleLayout).GetComponent<MoleObjectSpawner>();
        currentMoleObject.SetSpawnData(selectedDifficulty.ObjectSpawnSpeedMultiplier, selectedDifficulty.MoleObjects);
        currentMoleObject.IsSpawning = true;
    }

    private void OnGameStop()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.GameScreen, GameStates.EndScreen);
    }

}
