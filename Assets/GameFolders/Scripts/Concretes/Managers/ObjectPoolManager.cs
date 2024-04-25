using Abstracts;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonObject<ObjectPoolManager>
{
    [SerializeField] AddableToObjectPool[] _prefabs;
    [SerializeField] int _queueLength;
    Dictionary<PoolObjectsEnum, Queue<AddableToObjectPool>> _objectsDictionary = new Dictionary<PoolObjectsEnum, Queue<AddableToObjectPool>>();

    private void Awake()
    {
        SingletonThisObject(this);
    }
    private void Start()
    {
        InitalizePool();
    }
    private void InitalizePool()
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            Queue<AddableToObjectPool> objectQueue = new Queue<AddableToObjectPool>();
            for (int j = 0; j < _queueLength; j++)
            {
                AddableToObjectPool newObject = Instantiate(_prefabs[i]);
                newObject.gameObject.SetActive(false);
                newObject.transform.parent = this.transform;
                objectQueue.Enqueue(newObject);
            }
            _objectsDictionary.Add((PoolObjectsEnum)i, objectQueue);
        }
    }
    public void SetPool(AddableToObjectPool newObj)   //add to pool
    {
        newObj.gameObject.SetActive(false);
        newObj.transform.parent = this.transform;
        Queue<AddableToObjectPool> gameObjectsQueue = _objectsDictionary[newObj.ObjectType];
        gameObjectsQueue.Enqueue(newObj);
    }
    public AddableToObjectPool GetFromPool(PoolObjectsEnum newObjectType)
    {
        Queue<AddableToObjectPool> gameObjectsQueue = _objectsDictionary[newObjectType];
        if (gameObjectsQueue.Count == 0)
        {
            AddableToObjectPool newObj = Instantiate(_prefabs[(int)newObjectType]);
            gameObjectsQueue.Enqueue(newObj);
        }
        return gameObjectsQueue.Dequeue();
    }
}
