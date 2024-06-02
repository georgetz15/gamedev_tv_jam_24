using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        [SerializeField] private GameObject pauseMenu;

        public UnityEvent onResumeGame = new();

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
        }

        public void RestartGame()
        {
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
    }
}