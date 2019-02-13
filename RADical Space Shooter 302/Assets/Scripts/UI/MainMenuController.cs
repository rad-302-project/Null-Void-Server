using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject quitDialogBox;

    public enum menuState
    {
        MAIN,
        QUIT
    }

    public menuState phase;

	void Start () {
        phase = menuState.MAIN;
        //FindObjectOfType<AudioManager>().Play("Turkish March"); // Play the main menu BGM.
    }

    public void OpenQuitDialog() {
        if (phase == menuState.MAIN) {
            PlayUISound("Confirm");
            phase = menuState.QUIT;
            quitDialogBox.SetActive(true);         
        }
        else PlayUISound("Decline");
    }

    public void StartGame() {
        if (phase == menuState.MAIN)
        {
            PlayUISound("Confirm");
            SceneManager.LoadScene("sc_gameplay");
        }
        else PlayUISound("Decline");
    }    

    public void CloseQuitDialog() {
        if (phase == menuState.QUIT) {
            PlayUISound("Confirm");
            phase = menuState.MAIN;
            quitDialogBox.SetActive(false);          
        }
    }

    public void QuitGame() {
        if (phase == menuState.QUIT) {
            PlayUISound("Confirm");
            Application.Quit(); // Close the game.
        }
    }

    public void PlayUISound(string soundName)
    {
        FindObjectOfType<AudioManager>().Play(soundName);
    }
}