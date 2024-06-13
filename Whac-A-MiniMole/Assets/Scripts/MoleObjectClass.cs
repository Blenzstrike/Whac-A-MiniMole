using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoleObject", menuName = "MoleDataClasses/MoleObjectClass", order = 1)]
public class MoleObjectClass : ScriptableObject
{
    public Sprite ObjectVisualizations;
    public float MovementSpeed;
}
