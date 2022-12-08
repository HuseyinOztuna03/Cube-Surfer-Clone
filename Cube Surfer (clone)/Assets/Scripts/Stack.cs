using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public List<GameObject> cubeList = new List<GameObject>();

    private GameObject lastCube;

    void Start()
    {
        UpdateLastCube();
    }

    public void IncCubeStack(GameObject _gameobject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameobject.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - 2f, lastCube.transform.position.z);
        _gameobject.transform.SetParent(transform);
        cubeList.Add(_gameobject);
        UpdateLastCube();
    }
    public void DecCubeStack(GameObject _gameobject)
    {
        _gameobject.transform.parent = null;
        cubeList.Remove(_gameobject);
        UpdateLastCube();
    }

    private void UpdateLastCube()
    {
        lastCube = cubeList[cubeList.Count - 1];
    }
}
