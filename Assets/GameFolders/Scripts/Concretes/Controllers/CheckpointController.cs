using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    bool _isChecked;

    Animator _anim;

    public bool IsChecked { get => _isChecked; }

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!_isChecked && collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("FlagOut", true);
           SoundManager.Instance.PlaySound(11);
            _isChecked = true;
            
        }
    }
}
