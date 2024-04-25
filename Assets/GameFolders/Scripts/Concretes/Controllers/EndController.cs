using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class EndController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.EndGame();
            SoundManager.Instance.StopAllSounds();
            SoundManager.Instance.PlaySound(13);
            SoundManager.Instance.PlaySound(14);
        }
    }

}
