using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    int gameState;
    const int BUILDING = 1;
    const int FIGHTING = 2;
    const int WIN = 3;
    const int SCANNING =0;
 
    public float fightTimer = 60f;
    float currfightTimer;

    public GameObject ghostPillow;

	// Use this for initialization
	void Start () {
        gameState = SCANNING;
        currfightTimer = fightTimer;
	}

    // Update is called once per frame
    void Update() {
        switch (gameState) {
            case SCANNING:
                {
                    ghostPillow.active = false;
                  
                    break;
                }
            case BUILDING:
                {
                    ghostPillow.active = true;
                    ghostPillow.transform.SetParent(null);
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
                    gameState = BUILDING;
                    break;
                }
            case BUILDING:
                {
                    gameState = FIGHTING;
                    break;
                }
            case FIGHTING:
                {
                    gameState = WIN;
                    break;

                }
        }
    }
}
