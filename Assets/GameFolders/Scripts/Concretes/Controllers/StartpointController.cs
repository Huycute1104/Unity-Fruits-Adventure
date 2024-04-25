using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartpointController : MonoBehaviour
{
    Animator _anim;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _anim.SetTrigger("IsMoving");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _anim.SetTrigger("IsMoving");
    }

}
