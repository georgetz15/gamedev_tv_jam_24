using System;
using TMPro;
using UIControllers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        [SerializeField] private GameObject pauseMenu;

        [SerializeField] private TMP_Text scoreText;

        [SerializeField] private FinishMenuController finishMenu;

        public UnityEvent onResumeGame = new();
        public UnityEvent onFinishGame = new();

        private int score = 0;

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.
            if (instance && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }

            scoreText.text = "0";
        }

        public void RestartGame()
        {
            score = 0;
            SceneManager.LoadScene("SampleScene");
        }

        public void FinishGameDeath()
        {
            // Show finish menu with death text
            finishMenu.ShowMenu(win: false, score);
            onFinishGame.Invoke();
        }

        public void FinishGameWin()
        {
            // Show finish menu with win text
            finishMenu.ShowMenu(win: true, score);
            onFinishGame.Invoke();
        }

        public void QuitGame()
        {
            Application.Quit(0);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.GetComponent<PauseMenuController>().ShowMenu();
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            onResumeGame.Invoke();
        }

        public void AddScore(int points)
        {
            score += points;
            scoreText.text = score.ToString();
        }
    }
}