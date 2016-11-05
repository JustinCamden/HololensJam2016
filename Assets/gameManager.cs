using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {
    int gameState;
    const int BUILDING = 1;
    const int FIGHTING = 2;
    const int WIN = 3;
    const int SCANNING =0;
    const int LOSE = 4;
    public int currentAnimals = 3;

    public float respawnTimer = 5f;
 
    public float fightTimer = 60f;
    float currfightTimer;

    public GameObject ghostPillow;
    public GameObject enemySpawner;
    public GameObject target;

    public TextMesh anouncerTextMesh;

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
                        int timer = (int)currfightTimer;
                        anouncerTextMesh.text = "Time Remaining: " + timer.ToString();
                    }
                    else
                    {
                        switchState();
                    }
                    break;
                }
            case WIN:
                {
                    if (respawnTimer >= 0f)
                    {
                        respawnTimer -= Time.deltaTime;
                    }
                    else
                    {
                        Reload();
                    }
                    break;
                }
            case LOSE:
                {
                    if (respawnTimer >= 0f)
                    {
                        respawnTimer -= Time.deltaTime;
                    }
                    else
                    {
                        Reload();
                    }
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
            case WIN:
                {
                    enemySpawner.GetComponent<Enemy_Spawner>().DestroyEnemies();
                    enemySpawner.active = false;
                    anouncerTextMesh.text = "You saved your toys! Hurray!";
                    break;
                }
            case LOSE:
                {
                    enemySpawner.GetComponent<Enemy_Spawner>().DestroyEnemies();
                    enemySpawner.active = false;
                    anouncerTextMesh.text = "Oh noes! Your friends are dead!";
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
        gameState = LOSE;
    }

    public void switchAnimals()
    {
        AnimalsDown = !AnimalsDown;
    }

    public bool areAnimalsDown()
    {
        if (AnimalsDown)
        {
            return true;
        }
        return false;
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
