using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Button btn;

    public GameObject heartAttack;
    private Vector2 heartPosition;

    public Transform holder;

    private bool again = false;

    void Start()
    {
        btn.onClick.AddListener(UseAttack);
    }

    void Update()
    {
        if (again)
            StartCoroutine("Attack");
    }

    void UseAttack()
    {
        btn.onClick.RemoveAllListeners();
        again = true;        
    }

    IEnumerator Attack()
    {
        again = false;

        heartPosition = transform.position;
        GameObject heart = null;

        if (PlayerMove.facingRight)
        {
            heartPosition += new Vector2(0f, 0.2f);
            heart = Instantiate(heartAttack, heartPosition, Quaternion.identity, holder);
            heart.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
            Destroy(heart, 2f);
        }
        else
        {
            heartPosition += new Vector2(0f, 0.2f);
            heart = Instantiate(heartAttack, heartPosition, Quaternion.identity, holder);
            heart.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
            Destroy(heart, 2f);
        }

        yield return new WaitForSeconds(0.5f);

        btn.onClick.AddListener(UseAttack);
    }    
}
