using UnityEngine;

/// <summary>
/// Class that spawns holes.
/// </summary>
public class HoleSpawner : MonoBehaviour
{
    public GameObject SpawnHoles(GameObject pHoleLayout)
    {
           return  GameObject.Instantiate(pHoleLayout, gameObject.transform);
    }
}
