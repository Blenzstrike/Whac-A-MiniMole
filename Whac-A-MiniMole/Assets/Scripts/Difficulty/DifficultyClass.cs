using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyClass", menuName = "MenuData/DifficultyClass", order = 0)]
public class DifficultyClass : ScriptableObject
{
    public string Name;
    public Sprite OptionImage;
    public int AmountOfHoles;
    public float ObjectSpawnSpeed;
    public List<MoleObjectClass> MmoleObjects;
    public string UnlockWord;
}
