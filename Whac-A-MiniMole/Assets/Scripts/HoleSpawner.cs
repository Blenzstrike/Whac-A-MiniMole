using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject MoleHoles;
    
    public void Start()
    {
       
    }

    public List<GameObject> SpawnHoles(int pRequiredHoles)
    {
        Vector2 _holeSize = MoleHoles.GetComponent<RectTransform>().sizeDelta;
        List<Vector3> _occupiedSpaces = new List<Vector3>();
        List<GameObject> _spawnedHoles = new List<GameObject>();
        for(int i = 0; i < pRequiredHoles; i++)
        {
            float _spawnX = Random.Range(0, Screen.width);
            float _spawnY = Random.Range(0, Screen.height);
            _occupiedSpaces.Add(new Vector3(_spawnX, _spawnY,0));
        }

        foreach(Vector3 _occupiedSpace in  _occupiedSpaces)
        {
            _spawnedHoles.Add(GameObject.Instantiate(MoleHoles, _occupiedSpace, default, gameObject.transform));
        }

        return _spawnedHoles;
    }
}
