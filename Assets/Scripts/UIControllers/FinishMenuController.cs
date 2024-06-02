using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIControllers
{
    public class FinishMenuController : MonoBehaviour
    {
        [SerializeField] private TMP_Text announcementText;
        [SerializeField] private GameObject restartButton;

        public void ShowMenu(bool win, int score)
        {
            var announcement = win
                ? $"THE MOTHERSHIP IS SAFE\nTHANKS TO YOU!\n\nSCORE: {score}"
                : $"YOU HAVE BEEN DESTROYED!\n\nSCORE: {score}";
            announcementText.text = announcement;

            gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(restartButton);
        }
    }
}