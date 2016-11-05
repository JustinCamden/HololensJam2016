using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    int gameState;
    const int BUILDING = 1;
    const int FIGHTING = 2;
    const int WIN = 3;
    const int SCANNING =0;
    public int currentAnimals = 3;
 
    public float fightTimer = 60f;
    float currfightTimer;

    public GameObject ghostPillow;
    public GameObject enemySpawner;
    public GameObject target;

    bool AnimalsDown;
	// Use this for initialization
	void Start () {
        gameState = SCANNING;
        currfightTimer = fightTimer;
        AnimalsDown = false;
        if (enemySpawner == null)
        {
            enemySpawner = FindObjectOfType<Enemy_Spawner>().gameObject;
        }
	}

    // Update is called once per frame
    void Update() {
        switch (gameState) {
            case SCANNING:
                {
                    ghostPillow.active = false;
                    enemySpawner.active = false;
                    break;
                }
            case BUILDING:
                {
                   
                    break;
                }
            case FIGHTING:
                {
                    if (currfightTimer >= 0f)
                    {
                        currfightTimer -= Time.deltaTime;
                    }
                    else
                    {
                        switchState();
                    }
                    break;
                }
            case WIN:
                {
                    enemySpawner.active = false;
                    break;
                }
        }
	}

    public void switchState()
    {
        switch (gameState)
        {
            case SCANNING:
                {
                    ghostPillow.active = true;
                    ghostPillow.transform.SetParent(null);
                    gameState = BUILDING;
                    break;
                }
            case BUILDING:
                {
                    if (AnimalsDown)
                    {
                        gameState = FIGHTING;
                        enemySpawner.active = true;
                        enemySpawner.GetComponent<Enemy_Spawner>().InitializeSpawners();
                    }
                    break;
                }
            case FIGHTING:
                {
                    ghostPillow.active = false;
                    gameState = WIN;
                    break;

                }
        }
    }

    public int myState()
    {
        return gameState;
    }


    public void LoseAnimal()
    {
        currentAnimals--;
        if (currentAnimals <= 0)
        {
            Lose();
        }
    }

    void Lose()
    {

    }

    public void switchAnimals()
    {
        AnimalsDown = !AnimalsDown;
    }
}
