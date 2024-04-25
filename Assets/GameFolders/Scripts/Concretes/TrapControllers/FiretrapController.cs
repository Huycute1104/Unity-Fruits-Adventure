using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;
namespace Controllers
{
    public class FiretrapController : Traps
    {
        Animator _anim;
        BoxCollider2D _collider;
        float _currentTime;

        [SerializeField] float _maxTime;
        [SerializeField] float _startDelay;
        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.enabled = false;
            _anim = GetComponent<Animator>();
            _hitDamage = GetComponent<Damage>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            HitTarget(collision);

        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            MakeTargetJump(collision);
        }
        private void Update()
        {

            if (Time.timeSinceLevelLoad < _startDelay) return;
            _currentTime += Time.deltaTime;
            if (_currentTime > _maxTime)
            {
                _anim.SetBool("IsFire", true);
                _anim.SetBool("PreFire", false);
                _collider.enabled = true;
                _currentTime = 0f;
            }
            else if (_currentTime > _maxTime / 1.18)
            {
                _anim.SetBool("PreFire", true);
            }
            else if (_currentTime > _maxTime / 3)
            {
                _anim.SetBool("IsFire", false);
                _collider.enabled = false;
            }


        }

    }

}
