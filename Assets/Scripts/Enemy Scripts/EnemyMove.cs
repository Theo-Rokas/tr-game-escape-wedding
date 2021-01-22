using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private Animator anim;

    private Vector3 targetPosition;

    private int lives;

    private bool isGrounded;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

        lives = EnemySpawn.lives;

        isGrounded = false;
    }

    void Update()
    {
        if (isGrounded)
            Move();
    }

    void Move()
    {
        targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

        if (Vector3.Distance(transform.position, targetPosition) > 0.5f)
        {
            transform.LookAt(targetPosition);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.Translate(new Vector3(EnemySpawn.moveSpeed * Time.deltaTime, 0, 0));

            anim.SetBool("isWalking", true);            
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "HeartKiss")
        {
            lives--;

            if (ButtonScript.isBride)
            {
                SoundScript.instance.ManHurtSound();
            }
            else
            {
                SoundScript.instance.WomanHurtSound();
            }

            if (lives == 0)
                Destroy(this.gameObject);

            Destroy(collider.gameObject);
        }
    }
}
