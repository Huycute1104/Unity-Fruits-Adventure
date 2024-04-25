using Movements;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Combat;
using Managers;

public class TrunkBehaviour : Enemies
{
    [SerializeField] float _maxChangeDirectionTime;
    [SerializeField] float _maxAttackTime;
    [SerializeField] Transform _projectileSpawnTransform;
    [SerializeField] Transform _projectiles;
    [SerializeField] bool _dontChangeDirection;
    float _horizontalDirection;
    float _currentTime;
    bool _isPlayerFound;
    Flip _flip;
    WallCheck _playerCheck;
    RbMovement _rbMovement;
    Animator _anim;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _hitDamage = GetComponent<Damage>();
        _playerCheck = GetComponent<WallCheck>();
        _rbMovement= GetComponent<RbMovement>();
        _flip = GetComponent<Flip>();
    }
    private void Start()
    { 
        
        GetRandomHorizontalAxis();
    }
    private void Update()
    {
        if (!_isPlayerFound)
            ChangeDirectionWithTime();
        else
            SendProjectilesWithTime();

        PlayerCheck();
        _flip.FlipCharacter(_horizontalDirection);
       _rbMovement.HorizontalDirection= _horizontalDirection;
        
    }
    void GetRandomHorizontalAxis()
    {
        if (_dontChangeDirection) { _horizontalDirection = 1; return; } 
        _horizontalDirection = Random.Range(1, 3);
        if (_horizontalDirection == 2) _horizontalDirection = -1;
    }
    void ChangeDirectionWithTime()
    {
        if (_dontChangeDirection) return;
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxChangeDirectionTime)
        {
            _horizontalDirection = -_horizontalDirection;
            _currentTime = 0;
        }
    }
    void SendProjectilesWithTime()
    {
        
        _currentTime += Time.deltaTime;
        if (_currentTime > _maxAttackTime)
        {
            _anim.SetTrigger("IsAttack");
            AddableToObjectPool projectile = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.TrunkBullet);
            projectile.transform.SetParent(_projectiles);
            projectile.transform.position = _projectileSpawnTransform.position;
            projectile.transform.localScale = new Vector2(_horizontalDirection, 1);
            projectile.gameObject.SetActive(true);
            _currentTime = 0;
        }
    }
    private void PlayerCheck()
    {
        if (_playerCheck.IsThereWall)
        {
            _isPlayerFound = true;
            
        }
        else
        {
            _isPlayerFound = false;
           
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y == -1)
            {
                MakeTargetJump(collision);
                _anim.SetTrigger("IsHit");
                AddableToObjectPool deathFx = ObjectPoolManager.Instance.GetFromPool(PoolObjectsEnum.DeathEfx);
                deathFx.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -4.3f);
                deathFx.gameObject.SetActive(true);
                Destroy(gameObject,0.5f);
                SoundManager.Instance.PlaySound(9);
            }
            else
            {
                HitTarget(collision);
                MakeTargetJump(collision);
            }
        }
    }
}

