using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;

    public GameObject soundOffButton,
                      soundOnButton,
                      playerHealthBar,
                      joystick,
                      attackButton,                      
                      gameOverPanel,
                      enemySpawner,
                      cocktailSpawner,
                      attackHolder,
                      playerBride,
                      playerGroom;


    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        if (ButtonScript.isBride)
            playerBride.SetActive(true);
        else
            playerGroom.SetActive(true);
    }

    public void GameOver()
    {
        SoundScript.instance.LoseGameSound();        

        soundOffButton.SetActive(false);
        soundOnButton.SetActive(false);
        playerHealthBar.SetActive(false);
        joystick.SetActive(false);
        attackButton.SetActive(false);
        enemySpawner.SetActive(false);
        cocktailSpawner.SetActive(false);
        attackHolder.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
