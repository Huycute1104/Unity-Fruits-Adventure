using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedPanel : GameEndPanel
{
    public void PauseClick()
    {
        GameManager.Instance.UnpauseGame();
    }
    public void PlayLevel1()
    {
        GameManager.Instance.LoadScene(1);
    }
    public void SeeNextLevel()
    {
        GameManager.Instance.LoadSceneFromIndex(1);
    }
}
