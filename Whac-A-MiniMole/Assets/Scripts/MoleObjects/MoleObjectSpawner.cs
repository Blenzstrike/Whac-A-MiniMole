using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleObjectSpawner : MonoBehaviour
{
    private float baseObjectSpawnSpeedInSeconds = 3;
    [SerializeField] private List<GameObject> molesHoles;
    private float elapsedTime = 0;
    [HideInInspector] public bool IsSpawning = false;
    private float ObjectSpawnSpeedMultiplier = 1;
    private List<(int topValueChance, MoleObjectDataClass objectToSpawn)> weightedSpawnObjectList = new List<(int topValueChance, MoleObjectDataClass objectToSpawn)> ();

    public void SetSpawnData(float pSpawnMultiplier, List<MoleObjectDataClass> pObjectsToSpawn)
    {
        CreateWeightedList(pObjectsToSpawn);
        ObjectSpawnSpeedMultiplier = pSpawnMultiplier;
    }

    /// <summary>
    /// Create a weighted list based on a list of object to use for spawning based on chance.
    /// </summary>
    /// <param name="pObjectToSpawn">List of MoleObjects that we desire to spawn.</param>
    private void CreateWeightedList(List<MoleObjectDataClass> pObjectToSpawn)
    {
        //Clear weightedList
        weightedSpawnObjectList.Clear();
      
        List<MoleObjectDataClass> _undefinedChanceObjects = new List<MoleObjectDataClass>();
        
        //Go through all object that we need to spawn
        foreach (MoleObjectDataClass _objectToSpawn in pObjectToSpawn)
        {
            //Check if they have a defined SpawnChance. If not add them to a temp list for later.
            if(_objectToSpawn.SpawnChance == 0 || _objectToSpawn.SpawnChance > 99){
                _undefinedChanceObjects.Add(_objectToSpawn);
                continue;
            }
            //Add each object with the value of the SpawnChance added with the number before it.
            if(weightedSpawnObjectList.Count == 0)
            {
                weightedSpawnObjectList.Add((_objectToSpawn.SpawnChance, _objectToSpawn));
            }
            else
            {
                weightedSpawnObjectList.Add((_objectToSpawn.SpawnChance + weightedSpawnObjectList[weightedSpawnObjectList.Count - 1].topValueChance, _objectToSpawn));
            }
        }

        //Calculate a SpawnChance for each undefiend object based on the chance left. Check if wieghtedspawnObjectList has a count, if not use 100 as number.
        int _leftChances = (weightedSpawnObjectList.Count > 0? (100-weightedSpawnObjectList[weightedSpawnObjectList.Count - 1].topValueChance): 100)/_undefinedChanceObjects.Count;

        //Add undefied object to the weightedList.
        foreach (MoleObjectDataClass _objectToSpawn in _undefinedChanceObjects)
        {
            if (weightedSpawnObjectList.Count > 0) { weightedSpawnObjectList.Add((_leftChances + weightedSpawnObjectList[weightedSpawnObjectList.Count - 1].topValueChance, _objectToSpawn)); }
            else { weightedSpawnObjectList.Add((_leftChances, _objectToSpawn)); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpawning)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime*ObjectSpawnSpeedMultiplier > baseObjectSpawnSpeedInSeconds)
            {
                SpawnMoleObject();
                elapsedTime = 0;
            }
        }
    }

    private void SpawnMoleObject()
    {
        int _moleHoleIndex = UnityEngine.Random.Range(0, molesHoles.Count);
        int _moleIndex = UnityEngine.Random.Range(0, 100);

        MoleObjectDataClass _desiredMoleObject = GetCorrectObjectFromWeightedList(_moleIndex);
        MoleObjectController _moleObjectController = Instantiate(_desiredMoleObject.ObjectVisualizations, molesHoles[_moleHoleIndex].transform).GetComponent<MoleObjectController>();
        _moleObjectController.TapScore = _desiredMoleObject.TapScore;
        _moleObjectController.LiveTimerInSeconds = _desiredMoleObject.AliveTimerInSeconds;
    }

    private MoleObjectDataClass GetCorrectObjectFromWeightedList(int pIndex)
    {
        for(int i = 0; i < weightedSpawnObjectList.Count; i++)
        {
            if (weightedSpawnObjectList[i].topValueChance > pIndex)
            {
                return weightedSpawnObjectList[i].objectToSpawn;
            }
        }

        return weightedSpawnObjectList[weightedSpawnObjectList.Count].objectToSpawn;
    }
}
