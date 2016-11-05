using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject[] pillows;
    public GameObject animals;
    public int randNum = 0;
    public gameManager myGame;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public void spawnPillow()
    {
        randNum = Random.Range(0, pillows.Length);
        Instantiate(pillows[randNum], new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
    }

    public void spawnAnimals()
    {
        if (myGame.myState() == 1)
        {
            if (!myGame.areAnimalsDown())
            {
                GameObject animalTown = Instantiate(animals, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                myGame.switchAnimals();
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Target"));
                GameObject animalTown = Instantiate(animals, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
            }
        }
    } 
}
