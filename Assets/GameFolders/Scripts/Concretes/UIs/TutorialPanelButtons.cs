using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class TutorialPanelButtons : MonoBehaviour
    {
        public void ExitClick()
        {
            GameManager.Instance.ExitGame();
        }
        public void SkipTutorialClick()
        {
            GameManager.Instance.LoadSceneFromIndex(1);
        }
    }

}
