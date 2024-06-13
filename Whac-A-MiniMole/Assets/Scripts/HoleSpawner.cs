using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawner : MonoBehaviour
{
    public GameObject SpawnHoles(GameObject pHoleLayout)
    {
           return  GameObject.Instantiate(pHoleLayout, gameObject.transform);
    }
}
