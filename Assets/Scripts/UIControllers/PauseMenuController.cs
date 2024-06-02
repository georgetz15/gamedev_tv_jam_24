using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;

    public void ShowMenu()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }
}