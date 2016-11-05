using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffedAnimal : MonoBehaviour {

    gameManager theGameManager;

    public GameObject[] animals;
    int currIndex = 0;
    public int animalsCount = 3;

    public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
        theGameManager = FindObjectOfType<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        if (currIndex < animalsCount)
        {
            theGameManager.LoseAnimal();
            Instantiate(explosionPrefab, animals[currIndex].transform.position, animals[currIndex].transform.rotation);
            Destroy(animals[currIndex]);
            currIndex++;
        }
    }
}
