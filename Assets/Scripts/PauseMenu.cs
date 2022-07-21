using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMeneUI;


    InputController inputController;
    private void Awake() { inputController = new InputController(); }
    private void OnEnable() { inputController.Enable(); }
    private void OnDisable() { inputController.Disable(); }


    private void Update() {
        if (inputController.Normal.Esc.WasPerformedThisFrame())
        {
            if(GameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMeneUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMeneUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }





}
