using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [HideInInspector] public bool pauseMenuIsShown;

    [Header("Elements")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject pauseMenuBG;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseMenuState(!pauseMenuIsShown);
        }
    }

    public void ChangePauseMenuState(bool state)
    {
        pauseMenuIsShown = state;
        pauseMenuUI.SetActive(state);
        pauseMenuBG.SetActive(state);

        if (state)
        {
            //Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            //Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
