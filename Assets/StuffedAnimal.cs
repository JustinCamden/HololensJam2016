using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffedAnimal : MonoBehaviour {

    gameManager theGameManager;

	// Use this for initialization
	void Start () {
        theGameManager = FindObjectOfType<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die()
    {
        theGameManager.LoseAnimal();
        Destroy(gameObject);
    }
}
