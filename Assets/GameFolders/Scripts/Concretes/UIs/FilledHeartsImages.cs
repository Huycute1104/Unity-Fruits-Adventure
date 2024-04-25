using Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class FilledHeartsImages : MonoBehaviour
    {
        [SerializeField] Health _playerHealth;
        Image[] _filledHearts;

        private void Awake()
        {
            _filledHearts = GetComponentsInChildren<Image>();
        }
        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += HandleHealthChanged;
            _playerHealth.OnDead += HandleOnDead;
        }
        private void Start()
        {
            HandleHealthChanged();
        }

        private void HandleOnDead()
        {
            for(int i=0; i< _playerHealth.MaxHealth;i++)
            {
                _filledHearts[i].gameObject.SetActive(true);
            }
        }

        private void HandleHealthChanged()
        {
            if (_filledHearts.Length > _playerHealth.CurrentHealth)
            {
                int deleteCount = _filledHearts.Length - _playerHealth.CurrentHealth;
                for (int i = 1; i < deleteCount + 1; i++)
                {
                    _filledHearts[_filledHearts.Length - i].gameObject.SetActive(false);
                }
            }
        }
    }

}