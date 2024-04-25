using Abstracts.Input;
using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Animations;
using Mechanics;
using Managers;
using System;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        bool _isJumped;
        float _horizontalAxis;
        IPlayerInput _input;
        CharacterAnimation _anim;
        RbMovement _rb;
        Flip _flip;
        GroundCheck _groundCheck;
        PlatformHandler _platform;
        InteractHandler _interact;
        private bool _isPaused;

        private void Awake()
        {
            _rb= GetComponent<RbMovement>();
            _anim= GetComponent<CharacterAnimation>();
            _flip = GetComponent<Flip>();
            _groundCheck = GetComponent<GroundCheck>();
            _platform = GetComponent<PlatformHandler>();
            _interact = GetComponent<InteractHandler>();
            _input = new PcInput();
        }
        private void OnEnable()
        {
            GameManager.Instance.OnGamePaused += HandleGamePaused;
            GameManager.Instance.OnGameUnpaused += HandleGameUnpaused;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGamePaused -= HandleGamePaused;
            GameManager.Instance.OnGameUnpaused -= HandleGameUnpaused;
        }


        private void Update()
        {
            if (_input.IsExitButton)
            {
                SoundManager.Instance.PlaySound(2);
                if (_isPaused)
                {
                    GameManager.Instance.UnpauseGame();
                    
                }
                else
                {
                    GameManager.Instance.PauseGame();
                    
                }
            }
            if (_isPaused) return;
            _horizontalAxis = _input.HorizontalAxis;

            if(_horizontalAxis!=0 && _groundCheck.IsOnGround) SoundManager.Instance.PlaySound(1);
            else SoundManager.Instance.StopSound(1);

            if (_input.IsJumpButtonDown && _groundCheck.IsOnGround)
            {
                _isJumped = true;               
            }
            if(_input.IsDownButton)
                _platform.DisableCollider();
            if(_input.IsInteractButton)
            {
                _interact.Interact();
            }
            _anim.JumpAnFallAnim(_groundCheck.IsOnGround, _rb.VelocityY);
            _anim.HorizontalAnim(_horizontalAxis);
            _flip.FlipCharacter(_horizontalAxis);
        }
        private void FixedUpdate()
        {
            _rb.HorizontalMove(_horizontalAxis);  //if a gameObject has rb, dont use transform for movement
            if (_isJumped )
            {
                SoundManager.Instance.PlaySound(0);
                _rb.Jump();
                _isJumped = false;
            }
        }
        private void HandleGameUnpaused()
        {
            _isPaused= false;
        }

        private void HandleGamePaused()
        {
            _isPaused = true;
        }

    }

}
