using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static SoundScript instance;

    public AudioSource backgroundMusic,
                       clickSound,
                       jumpSound,
                       obtainSound,
                       manAttackSound,
                       manHurtSound,
                       womanAttackSound,
                       womanHurtSound,
                       loseGameSound;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public float ClickSound()
    {
        clickSound.Play();
        float length = clickSound.clip.length;
        return length;
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    public void ObtainSound()
    {
        obtainSound.Play();
    }

    public void ManAttackSound()
    {
        manAttackSound.Play();
    }

    public void ManHurtSound()
    {
        manHurtSound.Play();
    }

    public void WomanAttackSound()
    {
        womanAttackSound.Play();
    }

    public void WomanHurtSound()
    {
        womanHurtSound.Play();
    }

    public void LoseGameSound()
    {
        backgroundMusic.Stop();
        clickSound.Stop();
        jumpSound.Stop();
        obtainSound.Stop();
        manAttackSound.Stop();
        manHurtSound.Stop();
        womanAttackSound.Stop();
        womanHurtSound.Stop();
        loseGameSound.Play();
    }
}
