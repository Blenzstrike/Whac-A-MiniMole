using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that holds the contents required for a difficulty level.
/// </summary>
[CreateAssetMenu(fileName = "DifficultyClass", menuName = "MenuData/DifficultyClass", order = 0)]
public class DifficultyClass : ScriptableObject
{
    public string Name;
    public Sprite OptionImage;
    public GameObject HoleLayout;
    public float ObjectSpawnSpeedMultiplier;
    public List<MoleObjectDataClass> MoleObjects;
    public int GameTimeInSeconds;
}
