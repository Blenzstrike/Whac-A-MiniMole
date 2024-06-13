using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoleObject", menuName = "MoleDataClasses/MoleObjectDataClass", order = 1)]
public class MoleObjectDataClass : ScriptableObject
{
    public GameObject ObjectVisualizations;
    public float AliveTimerInSeconds;
    public int TapScore;
    /// <summary>
    /// A value between 0 and 100 what the chance is this object spawns. 
    /// If this is set to 0 it will take the a value that is left after all other objects spawn chances are added to each other.
    /// </summary>
    public int SpawnChance;
}
