using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlatformTrapController : MonoBehaviour
    {
        Rigidbody2D _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _rb.isKinematic = false;
                _rb.gravityScale = 2f;
                Destroy(this.gameObject, 1.5f);
            }
        }
    }

}
