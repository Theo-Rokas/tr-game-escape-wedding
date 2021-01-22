using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public Image healthBar;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void ApplyDamage(float damage)
    {
        healthBar.fillAmount -= damage / 100;
    }

    public void ApplyHeal(float heal)
    {
        healthBar.fillAmount += heal / 100;
    }

    public float ShowHealth()
    {
        return healthBar.fillAmount;
    }
}
