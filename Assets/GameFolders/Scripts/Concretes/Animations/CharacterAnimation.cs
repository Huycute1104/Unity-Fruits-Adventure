using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] float _appearAnimPostDelay;
        Animator _anim;
        private void Awake()
        {
            _anim= GetComponent<Animator>();
        }
        private void OnEnable()
        {
            AppearAnim(_appearAnimPostDelay);
        }
        public void AppearAnim(float delay)
        {
            SoundManager.Instance.PlaySound(3);
            _anim.SetBool("IsAppearing", true);
            StartCoroutine(AnimationFinishDelay(delay));
        }
        public void HorizontalAnim(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_anim.GetFloat("moveSpeed") == mathfValue) return;
            _anim.SetFloat("moveSpeed", mathfValue);
        }
        public void JumpAnFallAnim(bool isOnGround, float yVelocity)
        {
            _anim.SetBool("IsInAir", !isOnGround);
            if (!isOnGround)
            {
                _anim.SetFloat("yVelocity", yVelocity);
            }
        }
        public void TakeHitAnim(bool isInvulnerable)
        {
           
            _anim.SetBool("TakeHit", isInvulnerable);
        }

        IEnumerator AnimationFinishDelay(float time)
        {
            yield return new WaitForSeconds(time);
            _anim.SetBool("IsAppearing", false);
        }
    }

}
