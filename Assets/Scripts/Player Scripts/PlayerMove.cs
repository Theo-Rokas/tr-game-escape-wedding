using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    public Joystick js;

    public static bool isGrounded, facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        isGrounded = true;
        facingRight = true;
    }

    void Update()
    {
        Move();
        Jump();
        Die();
    }

    void Move()
    {
        Vector3 movement;

        if(js.Horizontal >= 0.2f)
        {
            if (js.Vertical < 0.5f && isGrounded)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);

            movement = new Vector3(js.Horizontal, 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
            sp.flipX = false;
            facingRight = true;
        }
        else if(js.Horizontal <= -0.2f)
        {
            if (js.Vertical < 0.5f && isGrounded)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);

            movement = new Vector3(js.Horizontal, 0f, 0f);
            transform.position -= movement * Time.deltaTime * -moveSpeed;
            sp.flipX = true;
            facingRight = false;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        if (js.Vertical >= 0.5f && isGrounded)
        {
            SoundScript.instance.JumpSound();

            rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void Die()
    {
        if (PlayerHealth.instance.ShowHealth() <= 0f)
        {
            this.gameObject.SetActive(false);
            GameScript.instance.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        
        if (collision.collider.tag == "Enemy")
        {
            if (ButtonScript.isBride)
            {
                SoundScript.instance.WomanHurtSound();
            }
            else
            {
                SoundScript.instance.ManHurtSound();
            }

            PlayerHealth.instance.ApplyDamage(10f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            PlayerHealth.instance.ApplyDamage(1f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Cocktails
        if (collider.tag == "Cosmopolitan")
        {
            SoundScript.instance.ObtainSound();

            PlayerHealth.instance.ApplyHeal(5f);

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Daiquiri")
        {
            SoundScript.instance.ObtainSound();

            PlayerHealth.instance.ApplyHeal(10f);

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Margarita")
        {
            SoundScript.instance.ObtainSound();

            PlayerHealth.instance.ApplyHeal(15f);

            Destroy(collider.gameObject);
        }

        if (collider.tag == "Martini")
        {
            SoundScript.instance.ObtainSound();

            PlayerHealth.instance.ApplyHeal(20f);

            Destroy(collider.gameObject);
        }

        // Flowers
        if (collider.tag == "FlowerPink")
        {
            if (ButtonScript.isBride)
            {
                SoundScript.instance.WomanHurtSound();
            }
            else
            {
                SoundScript.instance.ManHurtSound();
            }

            Destroy(collider.gameObject);

            PlayerHealth.instance.ApplyDamage(25f);
        }

        if (collider.tag == "FlowerPurple")
        {
            if (ButtonScript.isBride)
            {
                SoundScript.instance.WomanHurtSound();
            }
            else
            {
                SoundScript.instance.ManHurtSound();
            }

            Destroy(collider.gameObject);

            PlayerHealth.instance.ApplyDamage(30f);
        }

        if (collider.tag == "FlowerRed")
        {
            if (ButtonScript.isBride)
            {
                SoundScript.instance.WomanHurtSound();
            }
            else
            {
                SoundScript.instance.ManHurtSound();
            }

            Destroy(collider.gameObject);

            PlayerHealth.instance.ApplyDamage(35f);
        }

        if (collider.tag == "FlowerYellow")
        {
            if (ButtonScript.isBride)
            {
                SoundScript.instance.WomanHurtSound();
            }
            else
            {
                SoundScript.instance.ManHurtSound();
            }

            Destroy(collider.gameObject);

            PlayerHealth.instance.ApplyDamage(40f);
        }
    }
}
