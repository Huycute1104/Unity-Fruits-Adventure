using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] Transform[] _rayOrigins;
        [SerializeField] float _maxRayLength=0.15f;
        [SerializeField] LayerMask _layerMask;
        bool _isOnGround;

        public bool IsOnGround { get => _isOnGround; set => _isOnGround = value; }

        private void Update()
        {
            foreach(Transform rayOrigin in _rayOrigins)
            {
                CheckOnGround(rayOrigin);
                if (_isOnGround) break;
            }
        }
        private void CheckOnGround(Transform rayOrigin)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.down, _maxRayLength,_layerMask);
            // Debug.DrawRay(rayOrigin.position, Vector2.down* _maxRayLength, Color.red);
            if(hit.collider != null && !hit.collider.CompareTag("Trap"))
                _isOnGround= true;
            else
                _isOnGround = false;
        }
    }
}
