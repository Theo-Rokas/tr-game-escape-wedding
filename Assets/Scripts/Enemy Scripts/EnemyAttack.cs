using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform target, holder;  
    
    private Vector3 targetPosition;

    public GameObject flowerPink,
                      flowerPurple,
                      flowerRed,
                      flowerYellow;    

    private GameObject flowerAttack;
    private Vector2 flowerPosition;

    private GameObject flower;
    private int randomflower;

    private Vector2 moveDirection;    
    public float moveSpeed = 7f;    

    private bool again = true;    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        holder = GameObject.FindGameObjectWithTag("Holder").transform;
    }

    void Update()
    {
        if (again)
            StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        again = false;        

        yield return new WaitForSeconds(EnemySpawn.shootRate);

        targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        
        transform.LookAt(targetPosition);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        randomflower = Random.Range(0, 4);

        if (randomflower == 0)
            flowerAttack = flowerPink;
        else if (randomflower == 1)
            flowerAttack = flowerPurple;
        else if (randomflower == 2)
            flowerAttack = flowerRed;
        else if (randomflower == 3)
            flowerAttack = flowerYellow;

        flowerPosition = transform.position;
        flowerPosition += new Vector2(0f, 0.2f);

        flower = Instantiate(flowerAttack, flowerPosition, Quaternion.identity, holder);

        moveDirection = (target.position - transform.position).normalized * moveSpeed;
        flower.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(flower, 3f);

        if (ButtonScript.isBride)
        {
            SoundScript.instance.ManAttackSound();
        }
        else
        {
            SoundScript.instance.WomanAttackSound();
        }

        again = true;
    }    
}
