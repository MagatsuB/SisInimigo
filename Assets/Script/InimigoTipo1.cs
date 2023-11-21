using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class InimigoTipo1 : MonoBehaviour
{
    public static InimigoTipo1 _SharedInstance;
    public List<GameObject> _pooledObjects;
    public GameObject _objectToPool;
    public int _amountToPool;
    void Awake()
    {
        _SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
