using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class TriggerController : MonoBehaviour
{
    float _initialCooldownTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _initialCooldownTime = collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Health>().CooldownTimeAfterHit = _initialCooldownTime;
    }
}
