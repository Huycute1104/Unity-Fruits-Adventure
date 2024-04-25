using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField] GameEndPanel _gameEndPanel;
    [SerializeField] GamePausedPanel _gamePausePanel;

    private void OnEnable()
    {
        GameManager.Instance.OnGameEnd += HandleOnGameEnd;
        GameManager.Instance.OnGamePaused += HandleOnGamePaused;
        GameManager.Instance.OnGameUnpaused += HandleOnGameUnpaused;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameEnd -= HandleOnGameEnd;
        GameManager.Instance.OnGamePaused -= HandleOnGamePaused;
        GameManager.Instance.OnGameUnpaused -= HandleOnGameUnpaused;
    }

    private void HandleOnGameUnpaused()
    {
        _gamePausePanel.gameObject.SetActive(false);
    }

    private void HandleOnGamePaused()
    {
        _gamePausePanel.gameObject.SetActive(true);
    }

    private void HandleOnGameEnd()
    {
        _gameEndPanel.gameObject.SetActive(true);
    }
}
