using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;

public class TrunkProjectileController : Traps
{
    [SerializeField] float _maxLifeTime;
    [SerializeField] float _pushForce;
    RbMovement _rbMovement;
    AddableToObjectPool _objectPool;
    float _direction;

    public float Direction { get => _direction; set => _direction = value; }

    private void Awake()
    {
        _hitDamage = GetComponent<Damage>();
        _rbMovement= GetComponent<RbMovement>();
        _objectPool = GetComponent<AddableToObjectPool>();
    }
    private void OnEnable()
    {
        _direction = transform.localScale.x;
        StartCoroutine(SetPoolAfterDelay());
    }
    private void FixedUpdate()
    {
        _rbMovement.HorizontalMove(_direction);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitTarget(collision);
            MakeTargetJump(collision);
            collision.attachedRigidbody.AddRelativeForce(new Vector2(_direction * _pushForce, 0));
            ObjectPoolManager.Instance.SetPool(_objectPool);
        }
        else if(collision.gameObject.CompareTag("Box"))
        {
            ObjectPoolManager.Instance.SetPool(_objectPool);
        }
    }
    IEnumerator SetPoolAfterDelay()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        ObjectPoolManager.Instance.SetPool(_objectPool);
    }
}
