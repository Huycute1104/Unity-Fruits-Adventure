using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Managers;

namespace Controllers
{
    public class FruitController : MonoBehaviour
    {
        [SerializeField] Fruits _fruitType;
        Animator _anim;
        bool _isCollected;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !_isCollected)
            {
                SoundManager.Instance.PlaySound(5);
                FruitManager.Instance.IncreaseFruitNumber(_fruitType);
                _anim.Play("Collected");
                _isCollected = true;
                Destroy(this.gameObject, 0.5f);

            }
        }
    }
}

