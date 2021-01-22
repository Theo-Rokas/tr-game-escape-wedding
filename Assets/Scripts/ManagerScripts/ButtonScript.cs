using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public static bool isBride = false;

    public GameObject soundOffButton, soundOnButton;

    // Main Menu
    public void ChoosePlayer()
    {
        StartCoroutine(ChoosePlayerDelay(SoundScript.instance.ClickSound()));
    }

    public void HelpScreen()
    {
        StartCoroutine(HelpScreenDelay(SoundScript.instance.ClickSound()));
    }

    public void CreditsScreen()
    {
        StartCoroutine(CreditsScreenDelay(SoundScript.instance.ClickSound()));
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameDelay(SoundScript.instance.ClickSound()));
    }

    // Choose Player
    public void PlayGameBride()
    {
        isBride = true;

        StartCoroutine(PlayGameDelay(SoundScript.instance.ClickSound()));
    }

    public void PlayGameGroom()
    {
        isBride = false;

        StartCoroutine(PlayGameDelay(SoundScript.instance.ClickSound()));
    }

    // Play Game
    public void VolumeOff()
    {
        AudioListener.volume = 0f;

        soundOffButton.SetActive(false);
        soundOnButton.SetActive(true);
    }

    public void VolumeOn()
    {
        AudioListener.volume = 1f;

        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
    }

    public void PlayAgain()
    {
        AudioListener.volume = 1f;

        StartCoroutine(PlayAgainDelay(SoundScript.instance.ClickSound()));
    }

    public void GoToMenu()
    {
        AudioListener.volume = 1f;

        StartCoroutine(GoToMenuDelay(SoundScript.instance.ClickSound()));
    }

    IEnumerator ChoosePlayerDelay(float length)
    {
        yield return new WaitForSeconds(length);

        SceneManager.LoadScene("ChoosePlayer");
    }

    IEnumerator HelpScreenDelay(float length)
    {
        yield return new WaitForSeconds(length);

        SceneManager.LoadScene("HelpScreen");
    }

    IEnumerator CreditsScreenDelay(float length)
    {
        yield return new WaitForSeconds(length);

        SceneManager.LoadScene("CreditsScreen");
    }

    IEnumerator QuitGameDelay(float length)
    {
        yield return new WaitForSeconds(length);

        Application.Quit();
    }

    IEnumerator PlayGameDelay(float length)
    {
        yield return new WaitForSeconds(length);

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        SceneManager.LoadScene("PlayGame");
    }

    IEnumerator PlayAgainDelay(float length)
    {
        yield return new WaitForSeconds(length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GoToMenuDelay(float length)
    {
        Screen.orientation = ScreenOrientation.Portrait;

        yield return new WaitForSeconds(length);

        SceneManager.LoadScene("MainMenu");        
    }
}
