using Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Combat;
using Managers;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] Health _playerHealth;
    CheckpointController[] _checkpoints;
    StartpointController _startpoint;
    private void Awake()
    {
        _startpoint = GetComponentInChildren<StartpointController>();
        _checkpoints = GetComponentsInChildren<CheckpointController>();
    }
    private void OnEnable()
    {
        _playerHealth.OnDead += HandleOnDead;
    }
    public void HandleOnDead()
    {
        SoundManager.Instance.PlaySound(10);
        if(_checkpoints.LastOrDefault(x => x.IsChecked) == null)
            _playerHealth.transform.position = _startpoint.transform.position;
        else
        {
            _playerHealth.transform.position = _checkpoints.LastOrDefault(x=>x.IsChecked).transform.position;
        }  
    }

}
