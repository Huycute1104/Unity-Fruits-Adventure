using Cinemachine;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class LeverTeleportController : MonoBehaviour
    {
         
        [SerializeField] Transform _teleportPos;
        [SerializeField] CinemachineVirtualCamera _followingCam;
        [SerializeField] float _lensValue;
        PlayerController _player;
        Animator _anim;
        Animator _playerAnim;
        bool IsLeverOn;
  
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
        public void LeverInteraction()
        {
                TriggerLever();
        }

        private void TriggerLever()
        {
            if (IsLeverOn)
                LeverOff();
            else
                LeverOn();

        }
        private void LeverOn()
        {
            SoundManager.Instance.PlaySound(6);
            _followingCam.m_Lens.OrthographicSize = _lensValue;
            _playerAnim.SetTrigger("IsAppear");
            SoundManager.Instance.PlaySound(3);
            IsLeverOn = true;
            _anim.SetBool("IsActive", true);
            _player.transform.position = _teleportPos.position;

        }
        private void LeverOff()
        {
            SoundManager.Instance.PlaySound(7);
            IsLeverOn = false;
            _anim.SetBool("IsActive", false);

        }
        private void OnTriggerStay2D(Collider2D collision) 
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                _player = collision.gameObject.GetComponent<PlayerController>();
                _playerAnim = collision.gameObject.GetComponent<Animator>();
            }
        }

    }

}
