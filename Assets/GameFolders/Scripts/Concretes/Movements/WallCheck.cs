using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movements
{
    public class WallCheck : MonoBehaviour
    {
        [SerializeField] Transform[] _rayOrigins;
        [SerializeField] float _maxRayLength;
        [SerializeField] LayerMask _layerMask;
        bool _isThereWall;

        RbMovement _rbMovement;
        public bool IsThereWall { get => _isThereWall; }

        private void Awake()
        {
            _rbMovement = GetComponent<RbMovement>();
        }
        private void Update()
        {
            foreach(Transform rayOrigin in _rayOrigins)
            {
                CheckWalls(rayOrigin);
                if (_isThereWall) break;

            }
           
        }
        void CheckWalls(Transform rayOrigin)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.right * _rbMovement.HorizontalDirection, _maxRayLength, _layerMask);
            Debug.DrawRay(rayOrigin.position, Vector2.right * _rbMovement.HorizontalDirection * _maxRayLength, Color.red);
            if (hit.collider != null)
            {
                _isThereWall = true;
            }

            else
                _isThereWall = false;
        }
    }
}

