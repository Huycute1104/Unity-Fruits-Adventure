using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIs
{
    public class EmptyHeartsImages : MonoBehaviour
    {
        [SerializeField] Health _playerHealth;
        Image[] _emptyHearts;
        private void Awake()
        {
            _emptyHearts = GetComponentsInChildren<Image>();
            if(_emptyHearts.Length>_playerHealth.MaxHealth)
            {
                int deleteCount = _emptyHearts.Length - _playerHealth.MaxHealth;
                for(int i=1;i<deleteCount+1;i++)
                {
                    Destroy(_emptyHearts[_emptyHearts.Length - i]);
                }
            }
        }
    }

}
