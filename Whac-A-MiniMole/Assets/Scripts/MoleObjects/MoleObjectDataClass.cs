using UnityEngine;

/// <summary>
/// Scriptable object for the mole data. Allows the variables of the differnt moles to be set in the editor.
/// </summary>
[CreateAssetMenu(fileName = "MoleObject", menuName = "MoleDataClasses/MoleObjectDataClass", order = 1)]
public class MoleObjectDataClass : ScriptableObject
{
    /// <summary>
    /// Prefab of the mole you want.
    /// </summary>
    public GameObject ObjectVisualizations;
    /// <summary>
    /// How long the mole should be allowed to stay on the screen.
    /// </summary>
    public float AliveTimerInSeconds;
    /// <summary>
    /// Score recieved by the player when the moles has been tapped.
    /// </summary>
    public int TapScore;
    /// <summary>
    /// A value between 0 and 100 what the chance is this object spawns. 
    /// If this is set to 0 it will take the a value that is left after all other objects spawn chances are added to each other.
    /// </summary>
    public int SpawnChance;
}
