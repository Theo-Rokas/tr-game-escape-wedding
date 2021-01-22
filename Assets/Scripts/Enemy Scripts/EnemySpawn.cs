using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject chaseGroom,
                      chaseBride,
                      shootBride,
                      shootGroom;

    private Vector2 enemyPos1, enemyPos2;

    private bool isChase = false,
                 isShoot = false,
                 isBoth = true,
                 again = true;

    public Transform[] positions;
    private Transform randomPos1, randomPos2;

    private GameObject chaseEnemy1,
                       chaseEnemy2,
                       shootEnemy1,
                       shootEnemy2;

    public Text roundsText;
    private int roundsNumber = 0;

    public static int lives;
    public static float moveSpeed,
                        shootRate;

    void Start()
    {
        lives = 1;
        moveSpeed = 2f;
        shootRate = 2f;
    }

    void Update()
    {
        if (again && (!chaseEnemy1 && !chaseEnemy2))
            StartCoroutine("Spawn");
    }

    void ChangeRounds()
    {
        roundsNumber++;
        roundsText.text = "Rounds: " + roundsNumber;

        if (roundsNumber > PlayerPrefs.GetInt("MaxRounds"))
            PlayerPrefs.SetInt("MaxRounds", roundsNumber);
    }

    void ChangeDifficulty()
    {
        if (roundsNumber % 5 == 0)
        {
            if (moveSpeed < 3f)
                moveSpeed += 0.1f;

            if (shootRate > 1f)
                shootRate -= 0.1f;
        }

        if (roundsNumber % 25 == 0)
        {
            if (lives < 3)
                lives++;
        }        
    }

    void ChangeMode()
    {
        if (isChase)
        {
            isChase = false;
            isShoot = true;
        }
        else if (isShoot)
        {
            isShoot = false;
            isBoth = true;
        }
        else if (isBoth)
        {
            isBoth = false;
            isChase = true;
        }
    }

    IEnumerator Spawn()
    {
        again = false;

        ChangeRounds();
        ChangeDifficulty();
        ChangeMode();

        // Destroy previous
        foreach (Transform child in this.gameObject.transform)
            Destroy(child.gameObject);        

        // Create new
        randomPos1 = positions[Random.Range(0, positions.Length)];
        randomPos2 = positions[Random.Range(0, positions.Length)];

        while (randomPos1 == randomPos2)
        {
            randomPos2 = positions[Random.Range(0, positions.Length)];
        }        

        enemyPos1 = new Vector2(randomPos1.position.x, randomPos1.position.y);
        enemyPos2 = new Vector2(randomPos2.position.x, randomPos2.position.y);

        
        if (isChase)
        {
            if(ButtonScript.isBride)
            {
                chaseEnemy1 = Instantiate(chaseGroom, enemyPos1, Quaternion.identity);
                chaseEnemy2 = Instantiate(chaseGroom, enemyPos2, Quaternion.identity);
            }
            else
            {
                chaseEnemy1 = Instantiate(chaseBride, enemyPos1, Quaternion.identity);
                chaseEnemy2 = Instantiate(chaseBride, enemyPos2, Quaternion.identity);
            }
            
        }
        else if(isShoot)
        {
            if (ButtonScript.isBride)
            {
                shootEnemy1 = Instantiate(shootGroom, enemyPos1, Quaternion.identity);
                shootEnemy2 = Instantiate(shootGroom, enemyPos2, Quaternion.identity);
            }
            else
            {
                shootEnemy1 = Instantiate(shootBride, enemyPos1, Quaternion.identity);
                shootEnemy2 = Instantiate(shootBride, enemyPos2, Quaternion.identity);
            }
        }
        else if(isBoth)
        {
            if (ButtonScript.isBride)
            {
                chaseEnemy1 = Instantiate(chaseGroom, enemyPos1, Quaternion.identity);
                shootEnemy2 = Instantiate(shootGroom, enemyPos2, Quaternion.identity);
            }
            else
            {
                chaseEnemy1 = Instantiate(chaseBride, enemyPos1, Quaternion.identity);
                shootEnemy2 = Instantiate(shootBride, enemyPos2, Quaternion.identity);
            }
        }

        // Parent transform
        if (chaseEnemy1 && chaseEnemy2)
        {
            chaseEnemy1.transform.parent = transform;
            chaseEnemy2.transform.parent = transform;
        }

        if (shootEnemy1 && shootEnemy2)
        {
            shootEnemy1.transform.parent = transform;
            shootEnemy2.transform.parent = transform;
        }

        if (chaseEnemy1 && shootEnemy2)
        {
            chaseEnemy1.transform.parent = transform;
            shootEnemy2.transform.parent = transform;
        }

        yield return new WaitForSeconds(10f);

        again = true;        
    }
}
