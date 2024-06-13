using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject moleHoles;
    [SerializeField] private float minimumBorder = 10;

    public List<GameObject> SpawnHoles(int pRequiredHoles)
    {
        Vector2 _holeSize = moleHoles.GetComponent<RectTransform>().sizeDelta;
        List<Vector3> _occupiedSpaces = new List<Vector3>();
        List<GameObject> _spawnedHoles = new List<GameObject>();

        var _canvasTransform = gameObject.GetComponent<RectTransform>();
    
        for(int i = 0; i < pRequiredHoles; i++)
        {
            float _spawnX = 0;
            float _spawnY = 0;

            while (_spawnX == 0 || _spawnY == 0 || IsSpawnedObjectZeroOrOverlapping(new Vector2(_spawnX, _spawnY), _holeSize, _occupiedSpaces) == true)
            {
                // Using Unity Engine random as having one static class with a "global" stream of random values is fine.  
                _spawnX = UnityEngine.Random.Range(0+minimumBorder, Screen.width-minimumBorder);
                _spawnY = UnityEngine.Random.Range(0+minimumBorder, Screen.height-minimumBorder);
            }
            Debug.Log(_spawnX + " " + _spawnY);
            _occupiedSpaces.Add(new Vector3(_spawnX, _spawnY,0));
        }

        foreach(Vector3 _occupiedSpace in  _occupiedSpaces)
        {
            _spawnedHoles.Add(GameObject.Instantiate(moleHoles, _occupiedSpace, default, gameObject.transform));
        }

        return _spawnedHoles;
    }

    private bool IsSpawnedObjectZeroOrOverlapping(Vector2 pDesiredLocation, Vector2 pHoleSize, List<Vector3> pOccupiedSpaces)
    {
        float _radiusX = pHoleSize.x/2;
        float _radiusY = pHoleSize.y/2;

        float _minLocationX = pDesiredLocation.x - _radiusX;
        float _maxLocationX = pDesiredLocation.x + _radiusX;
        float _minLocationY = pDesiredLocation.y - _radiusY;
        float _maxLocationY = pDesiredLocation.y + _radiusY;

        foreach (Vector3 _occupiedSpace in pOccupiedSpaces)
        {
            if(_occupiedSpace.x < _minLocationX || _occupiedSpace.x > _maxLocationX)
            {
                if(_occupiedSpace.y < _minLocationY || _minLocationY > _maxLocationY)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
