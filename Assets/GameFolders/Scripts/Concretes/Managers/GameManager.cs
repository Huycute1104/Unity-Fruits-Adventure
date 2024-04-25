using Abstracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : SingletonObject<GameManager>
    {
        public bool IsGamePaused;
        public bool IsGameEnded;
        public event System.Action OnGameEnd;
        public event System.Action OnGamePaused;
        public event System.Action OnGameUnpaused;
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void EndGame()
        {
            IsGameEnded = true;
            Time.timeScale = 0f;
            OnGameEnd?.Invoke();
        }
        public void PauseGame()
        {
            if (IsGamePaused || IsGameEnded) return;
            IsGamePaused = true;
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();

        }
        public void UnpauseGame()
        {
 
            if (!IsGamePaused || IsGameEnded) return;
            IsGamePaused = false;
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke();
        }
        
        public void RestartGame()
        {
            LoadSceneFromIndex(0);
        }

        public void ExitGame()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
        public void LoadSceneFromIndex(int sceneIndex = 0)
        {
            ResetGame();
            StartCoroutine(LoadSceneFromIndexAsync(sceneIndex));
        }
        public void LoadScene(int sceneIndex = 0)
        {
            ResetGame();
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
        private void ResetGame()
        {
            SoundManager.Instance.StopAllSounds();
            SoundManager.Instance.PlaySound(3);
            SoundManager.Instance.PlaySound(8);
            FruitManager.Instance.ResetFruits();
            IsGamePaused= false;
            IsGameEnded = false;
            Time.timeScale = 1f;
            
        }
        private IEnumerator LoadSceneFromIndexAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + sceneIndex);
        }
        private IEnumerator LoadSceneAsync(int sceneIndex)
        {
            yield return SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}

