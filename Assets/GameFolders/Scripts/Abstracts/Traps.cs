using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Abstracts
{
    public abstract class Traps : MonoBehaviour
    {
        [SerializeField] float _hitJumpForce;
        protected Damage _hitDamage;
        Rigidbody2D _rb;
        Health _targetHealth;
        protected void HitTarget(Collider2D collision)
        {
            _targetHealth = collision.gameObject.GetComponent<Health>();
            if (_targetHealth != null)
                _hitDamage.HitTarget(_targetHealth);
        }

        protected void MakeTargetJump(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;
            _rb = collision.attachedRigidbody;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _hitJumpForce);
        }

    }

}
