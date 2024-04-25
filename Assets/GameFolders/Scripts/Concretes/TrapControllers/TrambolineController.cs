using Controllers;
using Managers;
using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Controllers
{
    public class TrambolineController : MonoBehaviour
    {
        [SerializeField] float _hitJumpForce;
        Rigidbody2D _rb;
        Animator _anim;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            TargetRbAction(collision);
            PlayAnimation();
        }
        private void TargetRbAction(Collision2D collision)
        {
            _rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_rb != null)
                _rb.AddForce(Vector2.up * _hitJumpForce);
        }
        void PlayAnimation()
        {
            _anim.SetTrigger("IsJumped");
            SoundManager.Instance.PlaySound(15);
        }


    }

}
