using System;
using TMPro;
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
        [FormerlySerializedAs("pointsText")] [SerializeField] private TMP_Text scoreText;

        public UnityEvent onResumeGame = new();

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