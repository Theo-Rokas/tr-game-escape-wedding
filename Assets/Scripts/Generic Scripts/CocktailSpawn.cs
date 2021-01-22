using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocktailSpawn : MonoBehaviour
{
    public GameObject cosmopolitan,
                      daiquiri,
                      margarita,
                      martini;

    public Transform[] positions;
    private Transform randomPosition;
    
    private GameObject drink;
    private Vector2 drinkPosition;    

    private int randomCocktail;
    private GameObject cocktail;    

    private bool again = true;

    void Update()
    {
        if (again)
        {
            StartCoroutine("Spawn");
        }
    }

    IEnumerator Spawn()
    {
        again = false;

        yield return new WaitForSeconds(5f);

        // Destroy previous
        foreach (Transform child in this.gameObject.transform)
            Destroy(child.gameObject);

        // Create new
        randomCocktail = Random.Range(0, 4);

        if (randomCocktail == 0)
            drink = cosmopolitan;
        else if (randomCocktail == 1)
            drink = daiquiri;
        else if (randomCocktail == 2)
            drink = margarita;
        else if (randomCocktail == 3)
            drink = martini;

        randomPosition = positions[Random.Range(0, positions.Length)];
        drinkPosition = new Vector2(randomPosition.position.x, randomPosition.position.y);        

        cocktail = Instantiate(drink, drinkPosition, Quaternion.identity);

        if (cocktail)
            cocktail.transform.parent = transform;

        again = true;
    }
}
