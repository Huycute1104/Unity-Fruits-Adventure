using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class PlatformHandler : MonoBehaviour
    {
        private GameObject _currentPlatform;
        private BoxCollider2D _playerCollider;
        private BoxCollider2D _currentPlatformCollider;
        private void Awake()
        {
            _playerCollider = GetComponent<BoxCollider2D>();
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("OneWayPlatform"))
                _currentPlatform = collision.gameObject;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _currentPlatform = null;
        }
        public void DisableCollider()
        {
            if (_currentPlatform != null)
                StartCoroutine(DisableColliderCoroutine());
        }

        private IEnumerator DisableColliderCoroutine()
        {
            _currentPlatformCollider = _currentPlatform.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(_playerCollider, _currentPlatformCollider);
            yield return new WaitForSeconds(0.25f);
            Physics2D.IgnoreCollision(_playerCollider, _currentPlatformCollider, false);

        }
    }
}

