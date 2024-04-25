using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddableToObjectPool : MonoBehaviour
{
    [SerializeField] PoolObjectsEnum _objectType;

    public PoolObjectsEnum ObjectType => _objectType;

}
