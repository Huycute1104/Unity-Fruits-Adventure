using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstracts;
using Combat;

namespace Controllers
{
    public class SpikesController : Traps
    {
        private void Awake()
        {
            _hitDamage = GetComponent<Damage>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            HitTarget(collision);
            MakeTargetJump(collision);
        }


    }
}

