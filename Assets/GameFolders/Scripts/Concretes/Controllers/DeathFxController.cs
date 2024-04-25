using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFxController : MonoBehaviour
{
    AddableToObjectPool _objectPool;
    private void Awake()
    {
        _objectPool= GetComponent<AddableToObjectPool>();
    }
    private void OnDisable()
    {
        ObjectPoolManager.Instance.SetPool(_objectPool);
    }
}
