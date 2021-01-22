using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundScript : MonoBehaviour
{
    private Text maxRounds;

    void Start()
    {
        maxRounds = GetComponent<Text>();

        if (PlayerPrefs.GetInt("MaxRounds") != 0)
            maxRounds.text = "Max Rounds: " + PlayerPrefs.GetInt("MaxRounds");
    }
}
