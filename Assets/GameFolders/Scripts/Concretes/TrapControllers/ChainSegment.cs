using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSegment : MonoBehaviour
{
    [SerializeField] float _maxTime;
    [SerializeField] float _zRotation;
    float _currentTime;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + _zRotation);
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime>_maxTime)
        {          
            if(transform.rotation.z>0)
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - _zRotation);
            else
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + _zRotation);
            _currentTime = 0;
        }
    }
}
