using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{    
    void Start()
    {
        Invoke("Exit", 1f);
    }

    void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
